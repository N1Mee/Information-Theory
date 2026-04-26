using System;

namespace OpenKey
{
    /// <summary>
    /// Реализация RSA с побайтовым блочным шифрованием.
    ///
    /// Роли ключей:
    ///   KC (закрытый, private exponent d) — вводит пользователь.
    ///   KO (открытый, public exponent e)  — вычисляется как KC⁻¹ mod φ(n)
    ///                                       через расширенный алгоритм Евклида (не перебором!).
    ///
    /// Шифрование открытым ключом:  c = m^KO mod n
    /// Дешифрование закрытым ключом: m = c^KC mod n
    ///
    /// Блок = 1 байт (значение 0..255).
    /// Требование: n = p*q > 255, чтобы все 256 возможных блоков
    /// давали уникальные (различные) остатки по модулю n.
    /// </summary>
    public class RSA
    {
        private long _p;
        private long _q;
        private long _n;
        private long _phi;
        private long _kc;   // закрытый ключ d: вводится пользователем
        private long _ko;   // открытый ключ e: вычисляется через расширенный алгоритм Евклида

        public long KO  => _ko;
        public long KC  => _kc;
        public long N   => _n;
        public long Phi => _phi;

        /// <summary>
        /// Инициализация. Принимает простые p, q и закрытый ключ KC (d).
        /// Вычисляет:
        ///   n   = p * q
        ///   φ(n) = (p-1)*(q-1)
        ///   KO  = KC⁻¹ mod φ(n)  — через расширенный алгоритм Евклида
        /// </summary>
        public bool Initialize(long p, long q, long kc)
        {
            _p   = p;
            _q   = q;
            _n   = p * q;
            _phi = (p - 1) * (q - 1);
            _kc  = kc;

            try
            {
                // KO * KC ≡ 1 (mod φ(n)) — расширенный алгоритм Евклида, не перебор
                _ko = MathTools.ModInverse(_kc, _phi);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        /// <summary>
        /// Шифрование открытым ключом KO: c = m^KO mod n
        /// Каждый байт m → 2 байта (ushort), т.к. c может быть до n-1 > 255.
        /// Условие корректности: n > 255 (все блоки дают разные остатки).
        /// </summary>
        public byte[] EncryptData(byte[] data)
        {
            // 1 байт → 2 байта в результате
            byte[] result = new byte[data.Length * 2];
            for (int i = 0; i < data.Length; i++)
            {
                long m = data[i];                          // блок: значение 0..255
                long c = MathTools.FastExp(m, _ko, _n);   // c = m^KO mod n
                byte[] cipher = BitConverter.GetBytes((ushort)c);
                result[i * 2]     = cipher[0];
                result[i * 2 + 1] = cipher[1];
            }
            return result;
        }

        /// <summary>
        /// Дешифрование закрытым ключом KC: m = c^KC mod n
        /// Каждые 2 байта (ushort) → 1 байт исходного текста.
        /// </summary>
        public byte[] DecryptData(byte[] data)
        {
            if (data.Length % 2 != 0) return null;

            byte[] result = new byte[data.Length / 2];
            for (int i = 0; i < data.Length; i += 2)
            {
                ushort c = BitConverter.ToUInt16(data, i);
                long m   = MathTools.FastExp((long)c, _kc, _n);  // m = c^KC mod n
                result[i / 2] = (byte)m;
            }
            return result;
        }
    }
}
