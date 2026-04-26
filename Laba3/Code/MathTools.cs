using System;

namespace OpenKey
{
    public static class MathTools
    {
        // Быстрое возведение в степень по модулю
        public static long FastExp(long foundation, long degree, long mod)
        {
            long result = 1;
            foundation = foundation % mod;

            while (degree > 0)
            {
                if ((degree & 1) == 1)
                    result = (result * foundation) % mod;

                degree >>= 1;
                foundation = (foundation * foundation) % mod;
            }
            return result;
        }

        // Проверка на простоту
        public static bool IsPrime(long n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;

            long i = 5;
            while (i * i <= n)
            {
                if (n % i == 0 || n % (i + 2) == 0) return false;
                i += 6;
            }
            return true;
        }

        // Проверка на взаимную простоту
        public static bool IsRelativelyPrime(long a, long b)
        {
            return Gcd(a, b) == 1;
        }

        // НОД
        private static long Gcd(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Расширенный алгоритм Евклида
        private static long ExtendedGcd(long a, long b, out long x, out long y)
        {
            if (b == 0)
            {
                x = 1;
                y = 0;
                return a;
            }

            long x1, y1;
            long gcd = ExtendedGcd(b, a % b, out x1, out y1);
            x = y1;
            y = x1 - (a / b) * y1;
            return gcd;
        }

        // Нахождение обратного элемента по модулю
        public static long ModInverse(long a, long m)
        {
            long x, y;
            long g = ExtendedGcd(a, m, out x, out y);
            if (g != 1)
                throw new ArgumentException("Обратный элемент не существует");
            return (x % m + m) % m;
        }
    }
}