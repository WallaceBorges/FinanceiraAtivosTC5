﻿using AtivosTC5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Interfaces.Repositories
{
    public interface IPortfolioRepository : IRepositoryBase<Portfolio>
    {
        Task<Portfolio> ObterPorId(int portfolioId);
        Task<IList<Portfolio>> ObterPorIdUsuario(int idUser);
    }
}
