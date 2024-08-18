using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Helpers
{
    public static class Sha1Helper
    {
        public static string Encrypt(string input)
        {
            using (var sha1 = SHA1.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(input);
                var hashBytes = sha1.ComputeHash(inputBytes); //criptografando..

                var sb = new StringBuilder();
                foreach (var item in hashBytes)
                    // Converte cada byte em uma representação hexadecimal
                    sb.Append(item.ToString("x2"));

                return sb.ToString();
            }
        }
    }
}
