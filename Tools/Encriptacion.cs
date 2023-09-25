using System;
using System.Security.Cryptography;
using System.Text;

namespace Tools
{
    public class Encriptacion
    {
        public static string Encriptar(string plainText, int shift)
        {
            StringBuilder cipherText = new StringBuilder();

            foreach (char character in plainText)
            {
                if (char.IsLetter(character))
                {
                    char start = char.IsLower(character) ? 'a' : 'A';
                    cipherText.Append((char)(((character - start + shift) % 26) + start));
                }
                else
                {
                    cipherText.Append(character);
                }
            }

            return cipherText.ToString();
        }

        public static string Desencriptar(string cipherText, int shift)
        {
            return Encriptar(cipherText, 26 - shift);
        }
    }
}
