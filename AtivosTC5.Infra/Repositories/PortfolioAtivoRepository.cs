using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Repositories;
using AtivosTC5.Domain.ValueObjects;
using AtivosTC5.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Data.Repositories
{
    public class PortfolioAtivoRepository : IPortfolioAtivoRepository
    {
        protected SqlServerContext _context;
        protected DbSet<PortfolioAtivo> _dbSet;

        public PortfolioAtivoRepository()
        {
            _context = new SqlServerContext();
            _dbSet = _context.Set<PortfolioAtivo>();
        }

        public virtual void Alterar(PortfolioAtivo entidade)
        {
            _dbSet.Update(entidade);
            _context.SaveChanges();
        }

        public virtual void Cadastrar(PortfolioAtivo entidade)
        {
            _dbSet.Add(entidade);
            _context.SaveChanges();
        }

        public virtual void Deletar(int idPort,int idAtivo)
        {
            _dbSet.Remove(ObterPorIdPortifolioAtivo(idPort,idAtivo));
            _context.SaveChanges();
        }

        public virtual PortfolioAtivo ObterPorIdPortifolio(int id)
        {
            return _dbSet.FirstOrDefault(t => t.Portfolio_Id == id);
        }

        public virtual PortfolioAtivo ObterPorIdPortifolioAtivo(int id,int idAtivo)
        {
            return _dbSet.FirstOrDefault(t => t.Portfolio_Id == id && t.Ativo_Id==idAtivo);
        }

    }
}
