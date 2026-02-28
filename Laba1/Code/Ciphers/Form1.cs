using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ciphers;

namespace Ciphers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Rail Fence выбран по умолчанию — сразу блокируем поле ключа
            txtKey.Enabled = false;
            txtKey.BackColor = System.Drawing.SystemColors.Control;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbRailFence.Checked)
                {
                    string inputText = txtInput.Text;
                    int rails = (int)numRails.Value;

                    string encryptedText = RailFenceCipher.Encrypt(inputText, rails);
                    txtOutput.Text = encryptedText;
                }
                else if (rbVigenere.Checked)
                {
                    string inputText = txtInput.Text;
                    string key = txtKey.Text;

                    if (string.IsNullOrWhiteSpace(key))
                    {
                        MessageBox.Show("Введите ключевое слово!", "Предупреждение",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string encryptedText = VigenereCipher.Encrypt(inputText, key);
                    txtOutput.Text = encryptedText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при шифровании: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbRailFence.Checked)
                {
                    string inputText = txtInput.Text;
                    int rails = (int)numRails.Value;

                    if (string.IsNullOrWhiteSpace(inputText))
                    {
                        MessageBox.Show("Введите текст для расшифровки",
                            "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string decryptedText = RailFenceCipher.Decrypt(inputText, rails);
                    txtOutput.Text = decryptedText;
                }
                else if (rbVigenere.Checked)
                {
                    string inputText = txtInput.Text;
                    string key = txtKey.Text;

                    if (string.IsNullOrWhiteSpace(key))
                    {
                        MessageBox.Show("Введите ключевое слово!", "Предупреждение",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string decryptedText = VigenereCipher.Decrypt(inputText, key);
                    txtOutput.Text = decryptedText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расшифровке: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            txtOutput.Clear();
            txtKey.Clear();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string content = File.ReadAllText(openDialog.FileName, Encoding.UTF8);
                txtInput.Text = content;
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOutput.Text))
            {
                MessageBox.Show("Нет результата для сохранения");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveDialog.FileName, txtOutput.Text, Encoding.UTF8);
                MessageBox.Show("Файл сохранен");
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOutput.Text))
            {
                Clipboard.SetText(txtOutput.Text);
            }
        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
        }

        private void rbRailFence_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRailFence.Checked)
            {
                lblRails.Visible = true;
                numRails.Visible = true;

                lblKey.Visible = true;
                txtKey.Visible = true;

                // Делаем поле ключа серым и недоступным
                txtKey.Enabled = false;
                txtKey.BackColor = System.Drawing.SystemColors.Control;
                txtKey.Clear();
            }
        }

        private void rbVigenere_CheckedChanged(object sender, EventArgs e)
        {
            if (rbVigenere.Checked)
            {
                lblRails.Visible = false;
                numRails.Visible = false;

                lblKey.Visible = true;
                txtKey.Visible = true;

                // Восстанавливаем доступность поля ключа
                txtKey.Enabled = true;
                txtKey.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
