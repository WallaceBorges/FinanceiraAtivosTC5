using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService 
    {
        Usuario Autenticar(string email, string senha);
        void CriarConta(Usuario usuario);
    }
}
