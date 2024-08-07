using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Repositories
{
    public class AtivoRepository : IAtivoRepository
    {
        public void Alterar(Ativo entidade)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Ativo entidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Ativo ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Ativo> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Ativo>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
