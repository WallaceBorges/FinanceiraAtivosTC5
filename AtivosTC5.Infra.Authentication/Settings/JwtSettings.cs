using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Authentication.Settings
{
    public static class JwtSettings
    {
        /// <summary>
        /// Chave secreta utilizada para criptografar os Tokens (assinatura)
        /// </summary>
        public static string SecretKey
            => "B495566D-B9F0-409F-ACED-7546353EC838";

        /// <summary>
        /// Tempo de expiração dos tokens
        /// </summary>
        public static int ExpirationInHours
            => 4;
    }
}
