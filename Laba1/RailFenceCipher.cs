using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers
{
    public static class RailFenceCipher
    {
        // Английский алфавит (26 букв)
        private const string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Проверяет, является ли символ английской буквой
        /// </summary>
        private static bool IsEnglishLetter(char c)
        {
            char upper = char.ToUpper(c);
            return EnglishAlphabet.IndexOf(upper) >= 0;
        }

        /// <summary>
        /// Очищает текст от не-английских символов и приводит к верхнему регистру
        /// </summary>
        private static string CleanText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            StringBuilder result = new StringBuilder();
            foreach (char c in text)
            {
                if (IsEnglishLetter(c))
                {
                    result.Append(char.ToUpper(c));
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Шифрование методом железнодорожной изгороди
        /// </summary>
        public static string Encrypt(string text, int rails)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            if (rails <= 0)
                throw new ArgumentException("Высота изгороди должна быть положительным числом");

            string cleanText = CleanText(text);
            if (string.IsNullOrEmpty(cleanText))
                return string.Empty;

            if (rails == 1)
                return cleanText;

            int length = cleanText.Length;

            char[,] fence = new char[rails, length];

            for (int i = 0; i < rails; i++)
                for (int j = 0; j < length; j++)
                    fence[i, j] = '\0';

            int currentRail = 0;
            int direction = 1;

            for (int i = 0; i < length; i++)
            {
                fence[currentRail, i] = cleanText[i];
                currentRail += direction;
                if (currentRail == rails - 1 || currentRail == 0)
                    direction *= -1;
            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < rails; i++)
                for (int j = 0; j < length; j++)
                    if (fence[i, j] != '\0')
                        result.Append(fence[i, j]);

            return result.ToString();
        }

        /// <summary>
        /// Дешифрование методом железнодорожной изгороди
        /// </summary>
        public static string Decrypt(string text, int rails)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            if (rails <= 0)
                throw new ArgumentException("Высота изгороди должна быть положительным числом");

            string cleanText = CleanText(text);

            if (string.IsNullOrEmpty(cleanText))
                return string.Empty;

            int length = cleanText.Length;

            if (rails == 1)
                return cleanText;

            char[,] fence = new char[rails, length];

            int currentRail = 0;
            int direction = 1;

            for (int i = 0; i < length; i++)
            {
                if (currentRail == rails - 1 || currentRail == 0)
                    direction *= -1;
                currentRail += direction;
            }

            int index = 0;
            for (int i = 0; i < rails; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    int rail = 0;
                    int dir = 1;
                    bool hasChar = false;

                    for (int k = 0; k <= j; k++)
                    {
                        if (k == j && rail == i)
                        {
                            hasChar = true;
                            break;
                        }
                        rail += dir;
                        if (rail == rails - 1 || rail == 0)
                            dir *= -1;
                    }

                    if (hasChar && index < length)
                    {
                        fence[i, j] = cleanText[index];
                        index++;
                    }
                    else
                    {
                        fence[i, j] = '\0';
                    }
                }
            }

            StringBuilder result = new StringBuilder();
            currentRail = 0;
            direction = 1;

            for (int i = 0; i < length; i++)
            {
                result.Append(fence[currentRail, i]);
                currentRail += direction;
                if (currentRail == rails - 1 || currentRail == 0)
                    direction *= -1;
            }

            return result.ToString();
        }
    }
}
