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
    public class TransacaoRepository : RepositoryBase<Transacao>, ITransacaoRepository
    {
        public async Task<IList<Transacao>> ListaTransacao(int idUsuario)
        {
            var  trans=await _context.Transacao
                            .Include(x=>x.ativo)
                            .ThenInclude(x => x.ativoTipo)
                            .Where(x => x.portfolio.Usuario_Id == idUsuario).ToListAsync();
            return trans;
        }

        public async  Task<IList<Transacao>> ListaTransacaoPorData(DateTime dtTransacao, int idUser)
        {
            var trans = await _context.Transacao
                             .Include(x => x.ativo)
                             .ThenInclude(x => x.ativoTipo)
                             .Where(x => x.DataTransacao.Date == dtTransacao.Date && x.portfolio.Usuario_Id == idUser).ToListAsync();
            return trans;
        }

        public async Task<IList<Transacao>> ListaTransacaoPortfolio(int idPort, int idUser)
        {
            var trans = await _context.Transacao
                             .Include(x => x.ativo)
                             .ThenInclude(x => x.ativoTipo)
                             .Where(x => x.portfolio.Usuario_Id == idUser && x.Portifolio_Id==idPort).ToListAsync();
            return trans;
        }
    }
}
