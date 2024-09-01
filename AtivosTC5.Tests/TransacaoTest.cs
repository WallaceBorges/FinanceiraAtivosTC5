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
    public class TransacaoTest
    {
        [Fact]
        public async Task Test_Transacao_EfetuaCompra_Post_Returns_OK()
        {
            var content = TestHelper.CreateContent(new TransacaoRequestModel { Portifolio_Id = 1, Ativo_Id = 1,Quantidade=100,Preco= 3.99M });
            var result = await TestHelper.CreateClient().PostAsync($"api/transacao/efetua-compra-ativo", content);

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_Transacao_EfetuaCompra_Post_Returns_BadRequest()
        {
            var content = TestHelper.CreateContent(new TransacaoRequestModel { Portifolio_Id = -1, Ativo_Id = -1, Quantidade = 100, Preco = 3.99M });
            var result = await TestHelper.CreateClient().PostAsync($"api/transacao/efetua-compra-ativo", content);

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Test_Transacao_EfetuaVenda_Post_Returns_OK()
        {
            var content = TestHelper.CreateContent(new TransacaoRequestModel { Portifolio_Id = 1, Ativo_Id = 1, Quantidade = 100, Preco = 3.99M });
            var result = await TestHelper.CreateClient().PostAsync($"api/transacao/efetua-venda-ativo", content);

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_Transacao_EfetuaVenda_Post_Returns_BadRequest()
        {
            var content = TestHelper.CreateContent(new TransacaoRequestModel { Portifolio_Id = -1, Ativo_Id = -1, Quantidade = 100, Preco = 3.99M });
            var result = await TestHelper.CreateClient().PostAsync($"api/transacao/efetua-Venda-ativo", content);

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Test_Transacao_GetByUserId_Returns_OK()
        {

            var result = await TestHelper.CreateClient().GetAsync($"api/transacao/retorna-transacoes-usuario");

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_Transacao_GetByDate_Returns_OK()
        {
            var result = await TestHelper.CreateClient().GetAsync($"api/transacao/retorna-transacoes-usuario-data/{DateTime.Today.ToString("yyyy-MM-dd")}");

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_Transacao_GetByDate_Returns_BadRequest()
        {
            var result = await TestHelper.CreateClient().GetAsync($"api/transacao/retorna-transacoes-usuario-data/{new DateTime(1010-01-01).ToString("yyyy-MM-dd")}");

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Test_Transacao_GetByPortfolio_Returns_OK()
        {
            Test_Transacao_EfetuaCompra_Post_Returns_OK();
            var result = await TestHelper.CreateClient().GetAsync($"api/transacao/retorna-transacoes-usuario-portfolio/1");

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_Transacao_GetByPortfolio_Returns_BadRequest()
        {
            var result = await TestHelper.CreateClient().GetAsync($"api/transacao/retorna-transacoes-usuario-portfolio/-1");

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

    }
}
