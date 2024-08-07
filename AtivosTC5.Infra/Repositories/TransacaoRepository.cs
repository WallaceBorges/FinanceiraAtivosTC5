using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        public void Alterar(Transacao entidade)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Transacao entidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Transacao ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Transacao> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Transacao>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
