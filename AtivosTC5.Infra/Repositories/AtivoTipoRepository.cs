using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Repositories
{
    public class AtivoTipoRepository : IAtivoTipoRepository
    {
        public void Alterar(AtivoTipo entidade)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(AtivoTipo entidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public AtivoTipo ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<AtivoTipo> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<IList<AtivoTipo>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
