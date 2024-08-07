using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Alterar(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Usuario>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
