using System;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;
using Teste.Configuracao;
using Application.Api;

namespace Teste
{
    public class TesteAjudaController : ConfigIntegracao
    {
        private readonly string _baseUrl = "/api/ajuda";

        public TesteAjudaController(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }        
      
        [Theory]      
        [InlineData("/showmethecode")]     
        public async Task TesteContentType(string url)
        {                  
             var response = await _client.GetAsync(_baseUrl+url);
             response.EnsureSuccessStatusCode(); // Status Code 200-299

             Assert.Equal("text/plain; charset=utf-8",   response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/showmethecode")]
        public async Task TesteRetorno(string url)
        {           
            // Act
            var response = await _client.GetAsync(_baseUrl + url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299  

            Assert.Equal("https://github.com/ejaassuncao/CalculadoraJuros", response.Content.ReadAsStringAsync().Result);
        }

    }
}
