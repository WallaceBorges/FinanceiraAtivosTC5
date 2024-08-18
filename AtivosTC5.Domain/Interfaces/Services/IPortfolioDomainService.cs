using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Repositories;
using AtivosTC5.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Interfaces.Services
{
    public interface IPortfolioDomainService 
    {
        Task<Portfolio> ObterPorid(int id);
        Task<IList<Portfolio>> ObterPoridUsuario(int id);
        Task<string> GravaPortfolio(Portfolio portfolio);
    }
}
