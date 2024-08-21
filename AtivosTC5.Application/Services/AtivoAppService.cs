using AtivosTC5.Domain.Models.Responses;
using AtivosTC5.Application.Interfaces;
using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Application.Services
{
    public class AtivoAppService: IAtivoAppService
    {
        private readonly IAtivoDomainService _domainService;

        public AtivoAppService(IAtivoDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<IList<AtivoReponseModel>> ListaAtivos()
        {
            try
            {
                var ativos = await _domainService.ListaAtivos();
                var response = ativos.Select(a => new AtivoReponseModel
                {
                    Id = a.Id,
                    Sigla = a.Sigla,
                    Nome = a.Nome,
                    ativoTipo = new AtivoTipoReponseModel {Id= a.ativoTipo.Id,Nome=a.ativoTipo.Nome }

                }).ToList();


                return  response;//ListaAtivos() não retonar uma lista de AtivoReponseModel
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
