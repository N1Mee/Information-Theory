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

        // Таблица Виженера 33x33
        private static char[,] _vigenereTable;

        // Для быстрого поиска индекса буквы
        private static Dictionary<char, int> _alphabetIndex;

        static VigenereCipher()
        {
            CreateVigenereTable();
        }

        /// <summary>
        /// Создает таблицу Виженера 33x33
        /// </summary>
        private static void CreateVigenereTable()
        {
            int size = RussianAlphabet.Length;
            _vigenereTable = new char[size, size];
            _alphabetIndex = new Dictionary<char, int>();

            for (int i = 0; i < size; i++)
            {
                _alphabetIndex[RussianAlphabet[i]] = i;
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    int encryptedIndex = (col + row) % size;
                    _vigenereTable[row, col] = RussianAlphabet[encryptedIndex];
                }
            }
        }

        /// <summary>
        /// Проверяет, является ли символ русской буквой
        /// </summary>
        private static bool IsRussianLetter(char c)
        {
            char upper = char.ToUpper(c);
            return _alphabetIndex.ContainsKey(upper);
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
                {
                    result.Append(upper);
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Шифрование методом Виженера с прямым (повторяющимся) ключом
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

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];

                if (IsRussianLetter(currentChar))
                {
                    char upperChar = char.ToUpper(currentChar);
                    int textIdx = _alphabetIndex[upperChar];

                    // Прямой ключ: повторяем ключевое слово циклически
                    char keyChar = cleanBaseKey[keyIndex % cleanBaseKey.Length];
                    int keyIdx = _alphabetIndex[keyChar];
                    keyIndex++;

                    char encryptedChar = _vigenereTable[keyIdx, textIdx];
                    result.Append(encryptedChar);
                }
                else
                {
                    // Не русская буква — оставляем как есть
                    result.Append(currentChar);
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Дешифрование методом Виженера с прямым (повторяющимся) ключом
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

            for (int i = 0; i < encryptedText.Length; i++)
            {
                char currentChar = encryptedText[i];

                if (IsRussianLetter(currentChar))
                {
                    // Прямой ключ: повторяем ключевое слово циклически
                    char keyChar = cleanBaseKey[keyIndex % cleanBaseKey.Length];
                    int keyIdx = _alphabetIndex[keyChar];
                    keyIndex++;

                    // Ищем в строке ключа столбец, где находится currentChar
                    int textIdx = -1;
                    for (int col = 0; col < RussianAlphabet.Length; col++)
                    {
                        if (_vigenereTable[keyIdx, col] == currentChar)
                        {
                            textIdx = col;
                            break;
                        }
                    }

                    if (textIdx != -1)
                        result.Append(RussianAlphabet[textIdx]);
                    else
                        result.Append(currentChar);
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

            for (int i = 0; i < text.Length; i++)
            {
                if (IsRussianLetter(text[i]))
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
