using System.Security.Cryptography;
using System.Text;

namespace MyDice.Utils
{
    public class HmacHelper
    {
        private readonly int _min;
        private readonly int _max;
        private readonly int _value;
        private readonly byte[] _key;
        private readonly string _hmac;

        public int Value => _value;
        public string KeyHex => Convert.ToHexString(_key);
        public string Hmac => _hmac;

        private static readonly int DefaultKeyLength = 32;

        public HmacHelper(int minInclusive, int maxExclusive)
        {
            _min = minInclusive;
            _max = maxExclusive;
            _key = GenerateKey(DefaultKeyLength);
            _value = RandomNumberGenerator.GetInt32(_min, _max);
            _hmac = ComputeHmac(_key, _value.ToString());
        }

        private static byte[] GenerateKey(int length)
        {
            byte[] key = new byte[length];
            RandomNumberGenerator.Fill(key);
            return key;
        }

        private static string ComputeHmac(byte[] key, string message)
        {
            using var hmac = new HMACSHA256(key);
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
            return Convert.ToHexString(hash);
        }

    }
}