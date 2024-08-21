using AtivosTC5.Domain.Models.Requests;
using AtivosTC5.Domain.Interfaces.UseCases.Ativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtivosTC5.Domain.Interfaces.Repositories;
using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.ValueObjects;
using System.Runtime.InteropServices.ComTypes;
using AtivosTC5.Domain.Enums;

namespace AtivosTC5.Application.UseCases.Ativos
{
    public class EfetuaTransacaoCompra : IEfetuaTransacaoCompra
    {
        private readonly ITransacaoRepository _repository;
        private readonly IPortfolioAtivoRepository _portfolioAtivo;
        public EfetuaTransacaoCompra(ITransacaoRepository repository,IPortfolioAtivoRepository portfolioAtivo)
        {
            _repository = repository;
            _portfolioAtivo = portfolioAtivo;
        }

        public  Task<string> EfetuarTransacao(TransacaoRequestModel requestModel)
        {
            
            try
            {
                
                var transacao = new Transacao
                {
                    Portifolio_Id = requestModel.Portifolio_Id,
                    Ativo_Id = requestModel.Ativo_Id,
                    TipoTransacao =(int)TipoTransacao.Compra,
                    Quantidade = requestModel.Quantidade,
                    Preco = requestModel.Preco,
                    DataTransacao = DateTime.Now,
                };
                var portAtivo = _portfolioAtivo.ObterPorIdPortifolioAtivo(requestModel.Portifolio_Id,requestModel.Ativo_Id);

                if (portAtivo != null)
                {
                    portAtivo.Preco=requestModel.Preco;
                    portAtivo.Quantidade+=requestModel.Quantidade;
                    _portfolioAtivo.Alterar(portAtivo);

                }
                else
                {
                    portAtivo = new PortfolioAtivo 
                    { 
                        Ativo_Id=requestModel.Ativo_Id,
                        Portfolio_Id=requestModel.Portifolio_Id,
                        Preco=requestModel.Preco,
                        Quantidade=requestModel.Quantidade,
                       
                    };
                    _portfolioAtivo.Cadastrar(portAtivo);
                }

                
                _repository.Cadastrar(transacao);
                return Task.FromResult("Transação de compra efetuada com sucesso");

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
