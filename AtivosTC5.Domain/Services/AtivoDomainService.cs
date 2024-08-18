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
    public class AtivoDomainService : IAtivoDomainService
    {
		private readonly IAtivoRepository _repository;

        public AtivoDomainService(IAtivoRepository repository)
        {
            _repository = repository;
        }

        public Task<IList<Ativo>> ListaAtivos()
        {
			try
			{
                return _repository.ObterTodosAsync();
			}
			catch (Exception e)
			{

				throw new Exception($"Erro ao buscar lista de Ativos: {e.Message}");
			}
        }
    }
}
