
using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Application.Interfaces
{
    public interface IPortfolioAppService
    {
        Task<PortfolioResponseModel> GetPortfolioPorId(int id);
        Task<IList<PortfolioResponseModel>> GetPortfolioPorIdUsuario(int id);
        Task<String> PostPortfolio(Portfolio portfolio);
    }
}
