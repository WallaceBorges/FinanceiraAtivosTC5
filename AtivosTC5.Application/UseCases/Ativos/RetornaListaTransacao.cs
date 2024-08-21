using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Repositories;
using AtivosTC5.Domain.Interfaces.UseCases.Ativo;
using AtivosTC5.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AtivosTC5.Application.UseCases.Ativos
{
    public class RetornaListaTransacao : IRetornaListaTransacao
    {
        private readonly ITransacaoRepository _repository;
        public RetornaListaTransacao(ITransacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<TransacaoReponseModel>> ListaTransacao(int idUsaurio)
        {
            var lista = await _repository.ListaTransacao(idUsaurio);

            if (lista != null)
            {
                var model = lista.Select(x => new TransacaoReponseModel
                {
                    DataTransacao = x.DataTransacao,
                    Quantidade = x.Quantidade,
                    Preco = x.Preco,
                    TipoTransacao = x.TipoTransacao,
                    Portifolio_Id = x.Portifolio_Id,
                    Ativo = new AtivoReponseModel
                    {
                        Id = x.ativo.Id,
                        Nome = x.ativo.Nome,
                        Sigla = x.ativo.Sigla,
                        ativoTipo = new AtivoTipoReponseModel
                        {
                            Id= x.ativo.ativoTipo.Id,
                            Nome= x.ativo.ativoTipo.Nome,
                        }
                    },
                    NomeTipoTransacao = x.TipoTransacao == 1 ? "Compra" :"Venda"

                }).ToList();
                return model;
            }
            else
            {
                throw new Exception("Nenhuma Transação encontrada para o usuário logado");
            }

        }

        public async Task<IList<TransacaoReponseModel>> ListaTransacaoPorData(DateTime date, int idUser)
        {
            var lista = await _repository.ListaTransacaoPorData(date,idUser);

            if (lista != null)
            {
                var model = lista.Select(x => new TransacaoReponseModel
                {
                    DataTransacao = x.DataTransacao,
                    Quantidade = x.Quantidade,
                    Preco = x.Preco,
                    TipoTransacao = x.TipoTransacao,
                    Portifolio_Id = x.Portifolio_Id,
                    Ativo = new AtivoReponseModel
                    {
                        Id = x.ativo.Id,
                        Nome = x.ativo.Nome,
                        Sigla = x.ativo.Sigla,
                        ativoTipo = new AtivoTipoReponseModel
                        {
                            Id = x.ativo.ativoTipo.Id,
                            Nome = x.ativo.ativoTipo.Nome,
                        }
                    },
                    NomeTipoTransacao = x.TipoTransacao == 1 ? "Compra" : "Venda"

                }).ToList();
                return model;
            }
            else
            {
                throw new Exception("Nenhuma Transação encontrada para o usuário logado ou data selecionada");
            }
        }

        public async Task<IList<TransacaoReponseModel>> ListaTransacaoPortfolio(int idPort, int idUser)
        {
            var lista = await _repository.ListaTransacaoPortfolio(idPort, idUser);

            if (lista != null)
            {
                var model = lista.Select(x => new TransacaoReponseModel
                {
                    DataTransacao = x.DataTransacao,
                    Quantidade = x.Quantidade,
                    Preco = x.Preco,
                    TipoTransacao = x.TipoTransacao,
                    Portifolio_Id = x.Portifolio_Id,
                    Ativo = new AtivoReponseModel
                    {
                        Id = x.ativo.Id,
                        Nome = x.ativo.Nome,
                        Sigla = x.ativo.Sigla,
                        ativoTipo = new AtivoTipoReponseModel
                        {
                            Id = x.ativo.ativoTipo.Id,
                            Nome = x.ativo.ativoTipo.Nome,
                        }
                    },
                    NomeTipoTransacao = x.TipoTransacao == 1 ? "Compra" : "Venda"

                }).ToList();
                return model;
            }
            else
            {
                throw new Exception("Nenhuma Transação encontrada para o usuário logado ou Portfolio selecionado");
            }
        }

    }
}
