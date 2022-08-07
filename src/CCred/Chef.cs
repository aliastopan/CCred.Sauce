using System;
using System.Collections.Generic;
using System.Text;

namespace CCred
{
    internal static class Chef
    {
        internal static string CookString(int length, string extraChars = "")
        {
            if(length <= 0)
            {
                throw new InvalidOperationException();
            }

            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numeric = "0123456789";
            var rng = new Random();
            char[] chars = new char[length];

            for(int i = 0; i < length; i++)
            {
                if(rng.Next(2) > 0)
                {
                    chars[i] = alphabet[rng.Next(alphabet.Length)];
                    chars[i] = rng.Next(2) > 0
                        ? chars[i] = Char.ToLower(chars[i])
                        : chars[i];
                    continue;
                }

                chars[i] = numeric[rng.Next(numeric.Length)];
            }

            if(extraChars?.Length == 0)
                return new string(chars);

            for(int i = 0; i < length; i++)
            {
                if(rng.Next(4) == 0)
                    chars[i] = extraChars[rng.Next(extraChars.Length)];
            }

            return new string(chars);
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