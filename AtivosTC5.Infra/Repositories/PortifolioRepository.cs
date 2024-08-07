using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Repositories
{
    public class PortifolioRepository : IPortifolioRepository
    {
        public void Alterar(Portifolio entidade)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Portifolio entidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Portifolio ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Portifolio> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Portifolio>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
