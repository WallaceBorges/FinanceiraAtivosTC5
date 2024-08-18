using AtivosTC5.Application.Interfaces;
using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Services;
using AtivosTC5.Domain.Models.Requests;
using AtivosTC5.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioDomainService? _usuarioDomainService;

        //construtor para injeção de dependência (inicialização)
        public UsuarioAppService(IUsuarioDomainService? usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }


        /// <summary>
        /// Serviço da aplicação para criação da conta do usuário.
        /// </summary>
        public CriarContaResponseModel CriarConta(CriarContaRequestModel model)
        {


            //capturando os dados do usuário enviado pelo request
            var usuario = new Usuario
            {
                Nome = model.Nome,
                Email = model.Email,
                Senha = model.Senha
            };

            //criando a conta do usuário
            _usuarioDomainService?.CriarConta(usuario);

            //retornando a resposta com os dados do usuário cadastrado
            return new CriarContaResponseModel
            {
                Mensagem = "Parabéns! Sua conta de usuário foi criada com sucesso.",
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
            };
        }

        /// <summary>
        /// Serviço da aplicação para autenticação do usuário.
        /// </summary>
        public AutenticarResponseModel Autenticar(AutenticarRequestModel model)
        {
            try
            {
                var usuario = _usuarioDomainService?.Autenticar(model.Email, model.Senha);

                //retornando a resposta com os dados do usuário cadastrado
                return new AutenticarResponseModel
                {
                    Mensagem = "Autenticação realizada com sucesso.",
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    AccessToken = usuario.AccessToken
                };

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
