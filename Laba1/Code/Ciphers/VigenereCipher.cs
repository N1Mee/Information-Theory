using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers
{
    public static class VigenereCipher
    {
        // Русский алфавит (33 буквы)
        private static readonly char[] RussianAlphabet = new char[]
        {
            'А','Б','В','Г','Д','Е','Ё','Ж','З','И','Й','К','Л','М','Н','О','П',
            'Р','С','Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю','Я'
        };

        private const int AlphabetSize = 33;

        // Словарь для быстрого получения индекса буквы
        private static readonly Dictionary<char, int> _alphabetIndex;

        static VigenereCipher()
        {
            _alphabetIndex = new Dictionary<char, int>();
            for (int i = 0; i < AlphabetSize; i++)
                _alphabetIndex[RussianAlphabet[i]] = i;
        }

        /// <summary>
        /// Проверяет, является ли символ русской буквой
        /// </summary>
        private static bool IsRussianLetter(char c)
        {
            return _alphabetIndex.ContainsKey(char.ToUpper(c));
        }

        /// <summary>
        /// Очищает ключ от не-русских символов и приводит к верхнему регистру
        /// </summary>
        private static string CleanKey(string key)
        {
            if (string.IsNullOrEmpty(key))
                return string.Empty;

            StringBuilder result = new StringBuilder();
            foreach (char c in key)
            {
                char upper = char.ToUpper(c);
                if (_alphabetIndex.ContainsKey(upper))
                    result.Append(upper);
            }
            return result.ToString();
        }

        /// <summary>
        /// Шифрование методом Виженера с прямым ключом.
        /// Формула: C = (P + K) mod N
        ///   P — индекс буквы открытого текста
        ///   K — индекс буквы ключа
        ///   N — размер алфавита (33)
        ///   C — индекс зашифрованной буквы
        /// </summary>
        public static string Encrypt(string text, string baseKey)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            string cleanBaseKey = CleanKey(baseKey);
            if (string.IsNullOrEmpty(cleanBaseKey))
                throw new ArgumentException("Ключ должен содержать хотя бы одну русскую букву");

            StringBuilder result = new StringBuilder();
            int keyIndex = 0;

            foreach (char currentChar in text)
            {
                if (IsRussianLetter(currentChar))
                {
                    int P = _alphabetIndex[char.ToUpper(currentChar)];              // индекс буквы текста
                    int K = _alphabetIndex[cleanBaseKey[keyIndex % cleanBaseKey.Length]]; // индекс буквы ключа
                    keyIndex++;

                    int C = (P + K) % AlphabetSize;  // формула шифрования

                    result.Append(RussianAlphabet[C]);
                }
                else
                {
                    result.Append(currentChar); // пробелы, цифры — не трогаем
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Дешифрование методом Виженера с прямым ключом.
        /// Формула: P = (C - K + N) mod N
        ///   C — индекс буквы зашифрованного текста
        ///   K — индекс буквы ключа
        ///   N — размер алфавита (33)
        ///   P — индекс восстановленной буквы открытого текста
        /// </summary>
        public static string Decrypt(string encryptedText, string baseKey)
        {
            if (string.IsNullOrEmpty(encryptedText))
                return string.Empty;

            string cleanBaseKey = CleanKey(baseKey);
            if (string.IsNullOrEmpty(cleanBaseKey))
                throw new ArgumentException("Ключ должен содержать хотя бы одну русскую букву");

            StringBuilder result = new StringBuilder();
            int keyIndex = 0;

            foreach (char currentChar in encryptedText)
            {
                if (IsRussianLetter(currentChar))
                {
                    int C = _alphabetIndex[char.ToUpper(currentChar)];              // индекс зашифрованной буквы
                    int K = _alphabetIndex[cleanBaseKey[keyIndex % cleanBaseKey.Length]]; // индекс буквы ключа
                    keyIndex++;

                    int P = (C - K + AlphabetSize) % AlphabetSize;  // формула дешифрования

                    result.Append(RussianAlphabet[P]);
                }
                else
                {
                    result.Append(currentChar);
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Возвращает развёрнутый прямой ключ в виде строки (для отображения)
        /// </summary>
        public static string GetKeyString(string text, string baseKey)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(baseKey))
                return string.Empty;

            string cleanBaseKey = CleanKey(baseKey);
            if (string.IsNullOrEmpty(cleanBaseKey))
                return string.Empty;

            StringBuilder result = new StringBuilder();
            int keyIndex = 0;

            foreach (char c in text)
            {
                if (IsRussianLetter(c))
                {
                    result.Append(cleanBaseKey[keyIndex % cleanBaseKey.Length]);
                    keyIndex++;
                }
                else
                {
                    result.Append(' ');
                }
            }

            return result.ToString();
        }
    }
}
