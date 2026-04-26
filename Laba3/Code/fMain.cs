using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenKey
{
    public partial class fMain : Form
    {
        private Checker _checker;
        private RSA     _rsa;
        private Model   _model;

        public fMain()
        {
            InitializeComponent();
            _checker = new Checker();
            _rsa     = new RSA();
            _model   = new Model();

            btnEncryption.Enabled = false;
            btnDecryption.Enabled = false;
        }

        private void btnAcceptP_Click(object sender, EventArgs e)
        {
            if (!_checker.IsValidPrime(tbP.Text, "P")) return;
            if (!_checker.IsValidPrime(tbQ.Text, "Q")) return;

            long p = long.Parse(tbP.Text);
            long q = long.Parse(tbQ.Text);

            if (p == q)
            {
                MessageBox.Show("P и Q должны быть разными простыми числами!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_checker.IsValidModulus(p, q)) return;

            long n   = p * q;
            long phi = (p - 1) * (q - 1);

            if (!_checker.IsValidKC(tbKC.Text, phi)) return;
            long kc = long.Parse(tbKC.Text);

            if (_rsa.Initialize(p, q, kc))
            {
                lYValue.Text     = _rsa.KO.ToString();
                lEilerValue.Text = phi.ToString();
                lNValue.Text     = n.ToString();

                btnEncryption.Enabled = true;
                btnDecryption.Enabled = true;

                MessageBox.Show(
                    $"Параметры RSA вычислены!\n\n" +
                    $"P = {p},  Q = {q}\n" +
                    $"Модуль n = P·Q = {n}\n" +
                    $"φ(n) = (P-1)·(Q-1) = {phi}\n\n" +
                    $"Закрытый ключ KC (введён): {kc}\n" +
                    $"Открытый ключ KO (вычислен): {_rsa.KO}\n\n" +
                    $"Проверка: KC · KO mod φ(n) = {(kc * _rsa.KO) % phi}\n" +
                    $"Блок (байт): 0..255 < n = {n}  ✓",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Одна кнопка для открытия любого файла.
        /// Автоматически определяет, зашифрован файл или нет:
        ///   — если размер чётный И хотя бы одно ushort-значение >= 256 → зашифрованный
        ///   — иначе → незашифрованный (исходный)
        /// </summary>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                byte[] bytes = File.ReadAllBytes(openFileDialog.FileName);

                bool isEncrypted = DetectEncrypted(bytes);

                _model.SourceDataBytes = bytes;

                if (isEncrypted)
                {
                    // Показываем как ushort-пары (шифртексты)
                    var sb = new StringBuilder();
                    for (int i = 0; i < bytes.Length - 1; i += 2)
                        sb.Append(BitConverter.ToUInt16(bytes, i) + " ");
                    tbOpenedFile.Text = sb.ToString().TrimEnd();

                    lOpenedFile.Text = "СОДЕРЖИМОЕ ФАЙЛА  —  зашифрованный (ushort-блоки)";
                    lOpenedFile.ForeColor = System.Drawing.Color.FromArgb(243, 139, 168);
                }
                else
                {
                    // Показываем как сырые байты (0..255)
                    tbOpenedFile.Text = string.Join(" ", bytes.Select(b => b.ToString()));

                    lOpenedFile.Text = "СОДЕРЖИМОЕ ФАЙЛА  —  исходный (байты 0..255)";
                    lOpenedFile.ForeColor = System.Drawing.Color.FromArgb(137, 180, 250);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка чтения файла!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Определяет, зашифрован ли файл.
        /// Зашифрованный файл: размер чётный, и хотя бы одно ushort-значение >= 256
        /// (т.к. незашифрованные байты всегда <= 255).
        /// </summary>
        private bool DetectEncrypted(byte[] bytes)
        {
            if (bytes.Length == 0 || bytes.Length % 2 != 0) return false;

            for (int i = 0; i < bytes.Length - 1; i += 2)
            {
                if (BitConverter.ToUInt16(bytes, i) >= 256)
                    return true;
            }
            return false;
        }

        private void btnEncryption_Click(object sender, EventArgs e)
        {
            if (_model.SourceDataBytes == null || _model.SourceDataBytes.Length == 0)
            {
                MessageBox.Show("Откройте файл!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _model.ResultDataBytes = _rsa.EncryptData(_model.SourceDataBytes);

            var sb = new StringBuilder();
            for (int i = 0; i < _model.ResultDataBytes.Length; i += 2)
                sb.Append(BitConverter.ToUInt16(_model.ResultDataBytes, i) + " ");
            tbResult.Text = sb.ToString().TrimEnd();
        }

        private void btnDecryption_Click(object sender, EventArgs e)
        {
            if (_model.SourceDataBytes == null || _model.SourceDataBytes.Length == 0)
            {
                MessageBox.Show("Откройте зашифрованный файл!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _model.ResultDataBytes = _rsa.DecryptData(_model.SourceDataBytes);

            if (_model.ResultDataBytes != null)
                tbResult.Text = string.Join(" ", _model.ResultDataBytes.Select(b => b.ToString()));
            else
                MessageBox.Show("Ошибка дешифрования! Проверьте формат файла.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (_model.ResultDataBytes == null)
            {
                MessageBox.Show("Нет данных для сохранения!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllBytes(saveFileDialog.FileName, _model.ResultDataBytes);
                    MessageBox.Show("Файл сохранён!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка сохранения!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e) => Close();
    }
}
