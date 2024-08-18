using AtivosTC5.Domain.Models.Requests;
using AtivosTC5.Domain.Interfaces.UseCases.Ativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtivosTC5.Domain.Interfaces.Repositories;
using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Enums;

namespace AtivosTC5.Application.UseCases.Ativos
{
    public class EfetuaTransacaoVenda : IEfetuaTransacaoVenda
    {
        private readonly ITransacaoRepository _repository;

        public EfetuaTransacaoVenda(ITransacaoRepository repository)
        {
            _repository = repository;
        }

        public  Task<string> EfetuarTransacao(TransacaoRequestModel requestModel)
        {

            try
            {
                var transacao = new Transacao
                {
                    Portifolio_Id = requestModel.Portifolio_Id,
                    Ativo_Id = requestModel.Ativo_Id,
                    TipoTransacao = (int)TipoTransacao.Venda,
                    Quantidade = requestModel.Quantidade,
                    Preco = requestModel.Preco,
                    DataTransacao = DateTime.Now,
                };

                
                _repository.Cadastrar(transacao);
                return Task.FromResult("Transação de Venda efetuada com sucesso");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
