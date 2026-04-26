using System.Windows.Forms;

namespace OpenKey
{
    public class Checker
    {
        // Максимальное значение одного блока (байта): 0..255
        public const long BLOCK_MAX = 255;

        public bool IsValidPrime(string str, string paramName)
        {
            if (!long.TryParse(str, out long val))
            {
                ShowError($"Некорректное значение {paramName}! Введите целое число.");
                return false;
            }

            if (val < 2)
            {
                ShowError($"Некорректное значение {paramName}! Число должно быть > 2.");
                return false;
            }

            if (!MathTools.IsPrime(val))
            {
                ShowError($"Некорректное значение {paramName}! Число должно быть простым.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверяет модуль n = p*q: он должен быть строго больше максимального
        /// значения блока (255), иначе разные открытые тексты могут давать
        /// одинаковые шифртексты (нарушение биекции).
        /// </summary>
        public bool IsValidModulus(long p, long q)
        {
            long n = p * q;
            if (n <= BLOCK_MAX)
            {
                ShowError(
                    $"Модуль n = p·q = {p}·{q} = {n} слишком мал!\n\n" +
                    $"Размер блока (байт) может принимать значения 0..{BLOCK_MAX}.\n" +
                    $"Модуль n должен быть строго больше {BLOCK_MAX}, иначе\n" +
                    $"шифрование будет некорректным (разные блоки дадут одинаковые остатки).\n\n" +
                    $"Подберите P и Q так, чтобы n = P·Q > {BLOCK_MAX}.\n" +
                    $"Например: P=17, Q=19 → n=323."
                );
                return false;
            }
            return true;
        }

        /// <summary>
        /// Проверка закрытого ключа KC (= d в RSA):
        ///   — целое число
        ///   — 1 < KC < φ(n)
        ///   — gcd(KC, φ(n)) = 1  (то же условие, что и для открытого ключа)
        /// На его основе вычисляется открытый ключ KO через расширенный алгоритм Евклида.
        /// </summary>
        public bool IsValidKC(string str, long phi)
        {
            if (!long.TryParse(str, out long val))
            {
                ShowError("Некорректное значение KC! Введите целое число.");
                return false;
            }

            if (val <= 1 || val >= phi)
            {
                ShowError($"Некорректное значение KC!\nКC должно быть в диапазоне (1, {phi}).");
                return false;
            }

            if (!MathTools.IsRelativelyPrime(val, phi))
            {
                ShowError(
                    $"Некорректное значение KC!\n" +
                    $"KC должно быть взаимно простым с φ(n) = {phi}.\n" +
                    $"НОД(KC, φ(n)) должен быть равен 1."
                );
                return false;
            }

            return true;
        }

        public bool IsValidSourceData(byte[] data)
        {
            if (data == null || data.Length == 0)
            {
                ShowError("Файл не выбран или пуст!");
                return false;
            }
            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
