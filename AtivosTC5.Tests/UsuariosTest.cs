using AtivosTC5.Application.Interfaces;
using AtivosTC5.Application.Services;
using AtivosTC5.Domain.Entities;
using AtivosTC5.Domain.Interfaces.Repositories;
using AtivosTC5.Domain.Models.Requests;
using AtivosTC5.Domain.Models.Responses;
using AtivosTC5.Presentation.Controllers;
using AtivosTC5.Tests.Helper;
using Bogus;
using Bogus.DataSets;
using FluentAssertions;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Tests
{
    public class UsuariosTest
    {

        Faker faker = new Faker("pt_BR");
        CriarContaRequestModel _request;

        public UsuariosTest()
        {

            _request = new CriarContaRequestModel
            {
                Nome = faker.Person.FullName,
                Email = faker.Person.Email,
                Senha = "SenhaTeste",
            };
        }

        [Fact]
        public async Task Test_Usuarios_Post_Returns_Created()
        {
            var content = TestHelper.CreateContent(_request);
            var response = await TestHelper.CreateClient().PostAsync("api/usuario/Criar-Conta", content);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

        }

        [Fact]
        public async Task Test_Usuarios_Post_Returns_BadRequest()
        {
            var User = UserTeste();

            var content = TestHelper.CreateContent(User);
            var result = await TestHelper.CreateClient().PostAsync("api/usuario/Criar-Conta", content);
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Test_Usuarios_GetById_Returns_OK()
        {
            var result = await TestHelper.CreateClient().GetAsync($"api/usuario/obter-por-usuario-id/1");
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_Usuarios_GetById_Returns_BadRequest()
        {
            var result = await TestHelper.CreateClient().GetAsync($"api/usuario/obter-por-usuario-id/-1");
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Test_Usuarios_Autenticar_Returns_OK()
        {
          
            var content = TestHelper.CreateContent(new AutenticarRequestModel { Email = UserTeste().Email, Senha = UserTeste().Senha });
            var result = await TestHelper.CreateClient().PostAsync($"api/usuario/Autenticar",content);
            var Token = TestHelper.ReadContent<AutenticarResponseModel>(result).AccessToken;

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        
        }

        [Fact]
        public async Task Test_Usuarios_Autenticar_Returns_BadRequest()
        {

            var content = TestHelper.CreateContent(new AutenticarRequestModel { Email = "Email@SemCad.com.br", Senha = "SenhaNãoCad" });
            var result = await TestHelper.CreateClient().PostAsync($"api/usuario/Autenticar", content);

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        private CriarContaRequestModel UserTeste()
        {
            return _request = new CriarContaRequestModel
            {
                Nome = "UserTeste",
                Email = "UserTeste@teste.com",
                Senha = "UserTeste",
            };
        }

    }
}
