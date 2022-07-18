using System;
using System.Security.Cryptography;
using System.Text;

namespace CCred
{
    public static class Sauce
    {

        public static string GetHash<T>(string input, Encoding encoding) where T : HashAlgorithm
        {
            using(T hashObj = (T) HashAlgorithm.Create(typeof(T).ToString()))
            {
                byte[] buffer = encoding.GetBytes(input);
                byte[] hash = hashObj.ComputeHash(buffer);

                StringBuilder output = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    output.Append(hash[i].ToString("x2"));
                }

                return output.ToString();
            }
        }

        public static string GetHash(string input)
        {
            return GetHash<SHA384>(input, Encoding.Default);
        }

        public static string GetHash<T>(string input) where T : HashAlgorithm
        {
            return GetHash<T>(input, Encoding.Default);
        }

        public static string GetHash<T>(string input, string salt, Encoding encoding) where T : HashAlgorithm
        {
            input = string.Concat(input, salt);
            return GetHash<T>(input, encoding);
        }

        public static string GetHash<T>(string input, string salt) where T : HashAlgorithm
        {
            input = string.Concat(input, salt);
            return GetHash<T>(input, Encoding.Default);
        }

        public static string GenerateSalt(int length)
        {
            if(length <= 0)
            {
                throw new InvalidOperationException();
            }

            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXY";
            string numeric = "0123456789";
            var rng = new Random();
            char[] salt = new char[length];

            for (int i = 0; i < length; i++)
            {
                if(rng.Next(2) < 1)
                {
                    salt[i] = alphabet[rng.Next(alphabet.Length - 1)];
                    salt[i] = rng.Next(2) > 0
                        ? salt[i] = Char.ToLower(salt[i])
                        : salt[i];
                    continue;
                }

                salt[i] = numeric[rng.Next(numeric.Length - 1)];
            }

            return new string(salt);
        }
    }
}