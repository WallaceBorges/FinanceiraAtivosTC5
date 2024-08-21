using AtivosTC5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Interfaces.Repositories
{
    public interface ITransacaoRepository : IRepositoryBase<Transacao>
    {
        Task<IList<Transacao>> ListaTransacao(int idUsaurio);
        Task<IList<Transacao>> ListaTransacaoPorData(DateTime dtTransacao, int idUser);
        Task<IList<Transacao>> ListaTransacaoPortfolio(int idPort, int idUser);
    }
}
