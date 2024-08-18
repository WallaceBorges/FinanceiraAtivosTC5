using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Data.Repositories
{
    public class PortfolioRepository : RepositoryBase<Portfolio>, IPortfolioRepository
    {
        public async Task<IList<Portfolio>> ObterPorIdUsuario(int idUser)
        {
            var portfolio = await _context.Portifolio
                                       .Where(x => x.Usuario_Id == idUser)
                                       .Select(x => new Portfolio
                                       {
                                           Id = x.Id,
                                           Descricao = x.Descricao,
                                           Nome = x.Nome,
                                           Usuario_Id = x.Usuario_Id,
                                           portfolioAtivos = x.portfolioAtivos
                                       }).ToListAsync();
            return portfolio;

        }

        async Task<Portfolio> IPortfolioRepository.ObterPorId(int portfolioId)
        {
            var portfolio = await _context.Portifolio
                                        .Where(x => x.Id == portfolioId)
                                        .Select(x => new Portfolio
                                        {
                                            Id=x.Id,
                                            Descricao = x.Descricao,
                                            Nome = x.Nome,
                                            Usuario_Id = x.Usuario_Id,
                                            portfolioAtivos = x.portfolioAtivos
                                        }).FirstOrDefaultAsync();
            return portfolio;
        }
    }
}
