using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Repositories;
using AtivosTC5.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected SqlServerContext _context;
        protected DbSet<T> _dbSet;

        public RepositoryBase()
        {
            _context = new SqlServerContext();
            _dbSet = _context.Set<T>();
        }

        public virtual void Alterar(T entidade)
        {
            _dbSet.Update(entidade);
            _context.SaveChanges();
        }

        public virtual void Cadastrar(T entidade)
        {
            _dbSet.Add(entidade);
            _context.SaveChanges();
        }

        public virtual  void Deletar(int id)
        {
            _dbSet.Remove(ObterPorId(id));
            _context.SaveChanges();
        }

        public virtual T ObterPorId(int id)
        {
            return _dbSet.FirstOrDefault(t => t.Id == id);
        }

        public virtual IList<T> ObterTodos()
        {
            return _dbSet.ToList();
        }

        public virtual async Task<IList<T>> ObterTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
