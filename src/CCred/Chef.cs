using System;
using System.Collections.Generic;
using System.Text;

namespace CCred
{
    internal static class Chef
    {
        internal static string CookString(int length)
        {
            if(length <= 0)
            {
                throw new InvalidOperationException();
            }

            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
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

        internal static string Seasoning(string former, string latter)
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