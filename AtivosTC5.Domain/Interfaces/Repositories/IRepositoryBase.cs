using AtivosTC5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Domain.Interfaces.Repositories
{
   
        public interface IRepositoryBase<T> where T : EntityBase
        {
            IList<T> ObterTodos();
            Task<IList<T>> ObterTodosAsync();
            T ObterPorId(int id);
            void Cadastrar(T entidade);
            void Alterar(T entidade);
            void Deletar(int id);
        }
  
}
