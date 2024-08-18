using AtivosTC5.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Interfaces.UseCases.Ativo
{
    public interface IEfetuaTransacaoCompra
    {
        Task<string> EfetuarTransacao(TransacaoRequestModel transacao);
    }
}
