using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Interfaces.UseCases.Ativo
{
    public interface IRetornaListaTransacao
    {
        Task<IList<TransacaoReponseModel>> ListaTransacao(int idUsaurio);
        Task<IList<TransacaoReponseModel>> ListaTransacaoPorData(DateTime data, int idUser);
        Task<IList<TransacaoReponseModel>> ListaTransacaoPortfolio(int idPort,int idUser);

    }
}
