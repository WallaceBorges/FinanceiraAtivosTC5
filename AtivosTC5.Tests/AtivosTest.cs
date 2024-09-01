using AtivosTC5.Domain.Models.Requests;
using AtivosTC5.Domain.Models.Responses;
using AtivosTC5.Tests.Helper;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Tests
{
    public class AtivosTest
    {

        [Fact]
        public async Task Test_Ativos_GetAll_Returns_OK()
        {
            var result = await TestHelper.CreateClient().GetAsync($"api/ativo/obter-lista-ativos");

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        private CriarContaRequestModel UserTeste()
        {
            return  new CriarContaRequestModel
            {
                Nome = "UserTeste",
                Email = "UserTeste@teste.com",
                Senha = "UserTeste",
            };
        }

    }
}
