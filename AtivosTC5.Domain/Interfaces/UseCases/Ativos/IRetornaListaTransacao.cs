using AtivosTC5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Interfaces.UseCases.Ativo
{
    public interface IRetornaListaTransacao
    {
        IList<Transacao> ListaTransacao(int idUsaurio);
        IList<Transacao> ListaTransacaoPorData(int idUsaurio);

    }
}
