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
    public class AtivoRepository : RepositoryBase<Ativo>, IAtivoRepository
    {
        public override async Task<IList<Ativo>> ObterTodosAsync()
        {
            var Ativos = await _context.Ativo.AsQueryable().Select(x => new Ativo
            {
               Id= x.Id,
                Sigla=x.Sigla,
                Nome=x.Nome,
                ativoTipo=x.ativoTipo
            }).ToListAsync();
            return Ativos;
        }

    }
}
