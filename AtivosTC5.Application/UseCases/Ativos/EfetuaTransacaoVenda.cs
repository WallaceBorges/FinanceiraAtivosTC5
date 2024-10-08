﻿using AtivosTC5.Domain.Models.Requests;
using AtivosTC5.Domain.Interfaces.UseCases.Ativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtivosTC5.Domain.Interfaces.Repositories;
using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Enums;
using AtivosTC5.Domain.ValueObjects;

namespace AtivosTC5.Application.UseCases.Ativos
{
    public class EfetuaTransacaoVenda : IEfetuaTransacaoVenda
    {
        private readonly ITransacaoRepository _repository;
        private readonly IPortfolioAtivoRepository _portfolioAtivo;
        public EfetuaTransacaoVenda(ITransacaoRepository repository, IPortfolioAtivoRepository portfolioAtivo)
        {
            _repository = repository;
            _portfolioAtivo = portfolioAtivo;
        }

        public Task<string> EfetuarTransacao(TransacaoRequestModel requestModel)
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

                var portAtivo = _portfolioAtivo.ObterPorIdPortifolioAtivo(requestModel.Portifolio_Id, requestModel.Ativo_Id);
                if (portAtivo == null || portAtivo.Quantidade < requestModel.Quantidade)
                {
                    throw new Exception("Você não possui quantidade suficiente para efetuar a venda");
                }
                else
                {
                    if (portAtivo.Quantidade == transacao.Quantidade)
                    {
                        _portfolioAtivo.Deletar(portAtivo.Portfolio_Id, portAtivo.Ativo_Id);
                    }
                    else
                    {
                        portAtivo.Quantidade -= transacao.Quantidade;
                        _portfolioAtivo.Alterar(portAtivo);
                    }
                    _repository.Cadastrar(transacao);
                }

                return Task.FromResult("Transação de Venda efetuada com sucesso");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
