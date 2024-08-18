using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Repositories;
using AtivosTC5.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Services
{
    public class PortfolioDomainService : IPortfolioDomainService
    {
        private readonly IPortfolioRepository _repository;

        public PortfolioDomainService(IPortfolioRepository repository)
        {
            _repository = repository;
        }

        public Task<string> GravaPortfolio(Portfolio portfolio)
        {
            try
            {
                _repository.Cadastrar(portfolio);
               
                return Task.FromResult("Portfolio cadastrado com sucesso.");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Portfolio> ObterPorid(int id)
        {
          return await  _repository.ObterPorId(id);
        }

        public async Task<IList<Portfolio>> ObterPoridUsuario(int id)
        {
            return await _repository.ObterPorIdUsuario(id);
        }
    }
}
