using AtivosTC5.Application.Interfaces;
using AtivosTC5.Domain.Models.Requests;
using AtivosTC5.Domain.Models.Responses;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Tests.Helper
{
    /// <summary>
    /// Métodos auxiliares para desenvolvimento das rotinas de teste
    /// </summary>
    public class TestHelper
    {
        /// <summary>
        /// Método para retornar uma instancia de HttpClient
        /// já conectado na API de clientes
        /// </summary>
        public static HttpClient CreateClient()
        {
           
            var content = TestHelper.CreateContent(new AutenticarRequestModel { Email = "UserTeste@teste.com", Senha = "UserTeste" });
         
            var factory = new WebApplicationFactory<Program>();
            var clienteToken = factory.CreateClient().PostAsync($"api/usuario/Autenticar", content);
            var Token =TestHelper.ReadContent<AutenticarResponseModel>(clienteToken.Result).AccessToken;
            
            
            var client= factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            return client;
        }

        /// <summary>
        /// Método para receber o objeto de uma requisição
        /// e serializa-lo para JSON para fazer o envio
        /// </summary>
        public static StringContent CreateContent<T>(T request)
            => new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");

        /// <summary>
        /// Método para deserializar um objeto JSON obtido
        /// de uma requisiçaõ feita para a API
        /// </summary>
        public static T ReadContent<T>(HttpResponseMessage response)
            => JsonConvert.DeserializeObject<T>
                (response.Content.ReadAsStringAsync().Result);

    }
}
