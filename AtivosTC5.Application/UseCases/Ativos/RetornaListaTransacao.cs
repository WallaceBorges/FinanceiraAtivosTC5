using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.UseCases.Ativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Application.UseCases.Ativos
{
    public class RetornaListaTransacao : IRetornaListaTransacao
    {
        public IList<Transacao> ListaTransacao(int idUsaurio)
        {
            throw new NotImplementedException();
        }

        public IList<Transacao> ListaTransacaoPorData(int idUsaurio)
        {
            throw new NotImplementedException();
        }
    }
}
