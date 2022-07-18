using System;
using System.Security.Cryptography;
using System.Text;

namespace CCred
{
    public class Sauce
    {
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