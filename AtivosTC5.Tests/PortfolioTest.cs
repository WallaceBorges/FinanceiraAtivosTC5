using AtivosTC5.Domain.Models.Requests;
using AtivosTC5.Tests.Helper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Tests
{
    public class PortfolioTest
    {
        [Fact]
        public async Task Test_Portfolio_Post_Returns_OK()
        {
            var content = TestHelper.CreateContent(new PortfolioRequestModel { Descricao = "Portfolio Criado nas rotinas de teste de integração", Nome = "Portfolio de Teste" });
            var result = await TestHelper.CreateClient().PostAsync($"api/portfolio/cadastra-portfolio", content);

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_Portfolio_Post_Returns_BadRequest()
        {
            var content = TestHelper.CreateContent(new PortfolioRequestModel { Descricao = "Portfolio Criado nas rotinas de teste de integração" });
            var result = await TestHelper.CreateClient().PostAsync($"api/portfolio/cadastra-portfolio", content);

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public async Task Test_Portfolio_GetById_Returns_OK()
        {
             await Test_Portfolio_Post_Returns_OK();
            var result = await TestHelper.CreateClient().GetAsync($"api/portfolio/obter-portifolio-id/1");

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_Portfolio_GetById_Returns_BadRequest()
        {

            var result = await TestHelper.CreateClient().GetAsync($"api/portfolio/obter-portifolio-id/-1");

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Test_Portfolio_GetByUser_Returns_OK()
        {
            var result = await TestHelper.CreateClient().GetAsync($"api/portfolio/obter-lista-por-usuario");

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

    }
}
