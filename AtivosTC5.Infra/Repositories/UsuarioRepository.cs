using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Repositories;
using AtivosTC5.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario ObterPorEmail(string email)
        {
            using (var context = new SqlServerContext())
            {
                return context.Usuario
                     .FirstOrDefault(u => u.Email.Equals(email));
            }
        }

        public Usuario ObterPorEmailESenha(string email, string senha)
        {
            using (var context = new SqlServerContext())
            {

#pragma warning disable CS8603 // Possible null reference return.
                return context.Usuario
                    .FirstOrDefault(u => u.Email.Equals(email)
                                      && u.Senha.Equals(senha));
#pragma warning restore CS8603 // Possible null reference return.


            }
        }
    }
}
