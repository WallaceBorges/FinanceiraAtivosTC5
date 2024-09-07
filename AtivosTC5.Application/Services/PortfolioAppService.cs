using AtivosTC5.Domain;
using AtivosTC5.Application.Interfaces;
using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtivosTC5.Domain.Models;

namespace AtivosTC5.Application.Services
{
    public class PortfolioAppService : IPortfolioAppService
    {
        private readonly IPortfolioDomainService _domainService;

        public PortfolioAppService(IPortfolioDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<PortfolioResponseModel> GetPortfolioPorId(int idPortfolio)
        {
            var portfolio=await _domainService.ObterPorid(idPortfolio);
            if (portfolio == null)
                throw new Exception("Portfolio Não Cadastrado");


            var response = new PortfolioResponseModel
            {
                Descricao = portfolio.Descricao,
                Usuario_Id = portfolio.Usuario_Id,
                Portifolio_Id = idPortfolio,
                Ativos = portfolio.portfolioAtivos?.Select(x => new AtivoPortfolioDTO {
                    Ativo_Id = x.Ativo_Id,
                    Sigla=x.ativo.Sigla,
                    Quantidade=x.Quantidade,
                    AtivoTipoNome=x.ativo.ativoTipo.Nome,
                    AtivoTipo_Id=x.ativo.ativoTipo.Id,
                }).ToList()

            };
            return response;
        }

        public async Task<IList<PortfolioResponseModel>> GetPortfolioPorIdUsuario(int idUser)
        {
            var portfolio = await _domainService.ObterPoridUsuario(idUser);
            if (portfolio == null)
                throw new Exception("Portfolio Não Cadastrado");


            var response = portfolio.Select(x=>new PortfolioResponseModel
            {
                Descricao = x.Descricao,
                Nome = x.Nome,
                Usuario_Id = x.Usuario_Id,
                Portifolio_Id = x.Id,
                Ativos = x.portfolioAtivos.Select(y => new AtivoPortfolioDTO
                {
                    Ativo_Id = y.Ativo_Id,
                    Sigla = y.ativo.Sigla,
                    Quantidade = y.Quantidade,
                    AtivoTipoNome = y.ativo.ativoTipo.Nome,
                    AtivoTipo_Id = y.ativo.ativoTipo.Id,
                    ValorUnitario=y.Preco
                }).ToList()
            }).ToList();
                
             
            return response;
        }
        
        public async Task<string> PostPortfolio(Portfolio requestModel)
        {
         var resposta= await _domainService.GravaPortfolio(requestModel);
         return resposta;
        }


    }
}
