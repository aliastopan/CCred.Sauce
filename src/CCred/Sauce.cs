using System;
using System.Collections.Generic;
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

        public static string GetHash<T>(string input, string salt) where T : HashAlgorithm
        {
            input = Seasoning(input, salt);
            return GetHash<T>(input, Encoding.UTF8);
        }

        public static string GetHash<T>(string input, string salt, Encoding encoding) where T : HashAlgorithm
        {
            input = Seasoning(input, salt);
            return GetHash<T>(input, encoding);
        }

        public static string GetHash<T>(string input) where T : HashAlgorithm
        {
            return GetHash<T>(input, Encoding.UTF8);
        }

        public static string GetHash(string input, Encoding encoding)
        {
            return GetHash<SHA384>(input, encoding);
        }

        public static string GetHash(string input, string salt)
        {
            input = Seasoning(input, salt);
            return GetHash<SHA384>(input, Encoding.UTF8);
        }

        public static string GetHash(string input, string salt, Encoding encoding)
        {
            input = Seasoning(input, salt);
            return GetHash<SHA384>(input, encoding);
        }

        public static string GetHash(string input)
        {
            return GetHash<SHA384>(input, Encoding.UTF8);
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

        public static string Seasoning(string former, string latter)
        {
            List<char[]> inputs = new List<char[]>()
            {
                former.ToCharArray(),
                latter.ToCharArray()
            };

            if(latter.Length > former.Length)
            {
                inputs.Reverse();
            }

            StringBuilder output = new StringBuilder();
            int pointer = 0;

            for(int i = 0; i < (inputs[0].Length * 2) - 1; i++)
            {
                if(i % 2 == 0)
                {
                    output.Append(inputs[0][i/2]);
                }
                else
                {
                    output.Append(inputs[1][pointer]);
                    pointer = pointer + 1 >= inputs[1].Length
                        ? 0
                        : pointer + 1;
                }
            }

            return output.ToString();
        }
    }
}