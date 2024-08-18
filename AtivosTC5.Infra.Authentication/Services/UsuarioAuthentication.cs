using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces;
using AtivosTC5.Infra.Authentication.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Authentication.Services
{
    /// <summary>
    /// Classe para implementar a geração dos TOKENS JWT
    /// </summary>
    public class UsuarioAuthentication : IUsuarioAuthentication
    {
        public string CreateToken(Usuario usuario)
        {
            //gerando a assinatura antifalsificação do token (VERIFY SIGNATURE)
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSettings.SecretKey);

            //criando o conteúdo do token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //nome do usuário autenticado (usaremos o email)
                Subject = new ClaimsIdentity(new Claim[]
                { 
                    new Claim(ClaimTypes.Name, usuario.Email)
                   ,new Claim("Id", usuario.Id.ToString()) 
                }),
                //definindo a data de expiração do token
                Expires = DateTime.Now.AddHours(JwtSettings.ExpirationInHours),
                //assinando o token (chave antifalsificação)
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            //retornando o token
            var accessToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(accessToken);
        }
    }
}
