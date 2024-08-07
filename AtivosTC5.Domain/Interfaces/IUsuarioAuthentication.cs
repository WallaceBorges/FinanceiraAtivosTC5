
using AtivosTC5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Interfaces
{
    /// <summary>
    /// Interface para abstração das operações de autenticação de Usuario
    /// </summary>
    public interface IUsuarioAuthentication
    {
        /// <summary>
        /// Método para gerar o token de acesso do usuário
        /// </summary>
        string CreateToken(Usuario usuario);
    }
}
