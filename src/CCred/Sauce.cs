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

        public static bool Verify(string rawInput, string hashedInput)
        {
            var input = GetHash(rawInput);
            return string.Equals(input, hashedInput);
        }

        public static bool Verify(string rawInput, string hashedInput, Encoding encoding)
        {
            var input = GetHash(rawInput, encoding);
            return string.Equals(input, hashedInput);
        }

        public static bool Verify(string rawInput, string salt, string hashedInput)
        {
            var input = GetHash(rawInput, salt);
            return string.Equals(input, hashedInput);
        }

        public static bool Verify(string rawInput, string salt, string hashedInput, Encoding encoding)
        {
            var input = GetHash(rawInput, salt, encoding);
            return string.Equals(input, hashedInput);
        }

        public static bool Verify<T>(string rawInput, string hashedInput) where T : HashAlgorithm
        {
            var input = GetHash<T>(rawInput);
            return string.Equals(input, hashedInput);
        }

        public static bool Verify<T>(string rawInput, string hashedInput, Encoding encoding) where T : HashAlgorithm
        {
            var input = GetHash<T>(rawInput, encoding);
            return string.Equals(input, hashedInput);
        }

        public static bool Verify<T>(string rawInput, string salt, string hashedInput) where T : HashAlgorithm
        {
            var input = GetHash<T>(rawInput, salt);
            return string.Equals(input, hashedInput);
        }

        public static bool Verify<T>(string rawInput, string salt, string hashedInput, Encoding encoding) where T : HashAlgorithm
        {
            var input = GetHash<T>(rawInput, salt, encoding);
            return string.Equals(input, hashedInput);
        }

        public static string GenerateGibberish(int length, string extraChars = "")
        {
            return Chef.CookString(length, extraChars);
        }

        public static string GenerateSalt(int length)
        {
            return Chef.CookString(length);
        }

        public static string Seasoning(string former, string latter)
        {
            return Chef.Seasoning(former, latter);
        }
    }
}