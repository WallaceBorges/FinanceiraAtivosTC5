using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Interfaces.Repositories
{
    public interface IPortfolioAtivoRepository 
    {
        PortfolioAtivo ObterPorIdPortifolio(int id);
        PortfolioAtivo ObterPorIdPortifolioAtivo(int idPort, int Ativo);
        void Cadastrar(PortfolioAtivo entidade);
        void Alterar(PortfolioAtivo entidade);
        void Deletar(int idPort, int Ativo);
    }
}
