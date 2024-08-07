using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Data.Repositories
{
    public class PortfolioRepository : IPortifolioRepository
    {
        public void Alterar(Portfolio entidade)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Portfolio entidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Portfolio ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Portfolio> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Portfolio>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
