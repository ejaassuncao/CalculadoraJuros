using System;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;
using Teste.Configuracao;
using Application.Api;

namespace Teste
{
    public class TesteCalculadoraController : ConfigIntegracao
    {
        public TesteCalculadoraController(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]      
        [InlineData("/api/calculadora/taxajuros")]
        public async Task TesteContentType(string url)
        {      
            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/plain; charset=utf-8",   response.Content.Headers.ContentType.ToString());
        }


        [Theory]
        [InlineData("/api/calculadora/taxajuros")]     
        public async Task TesteRetornotaxajuros(string url)
        {  
            var response = await _client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("0,01", response.Content.ReadAsStringAsync().Result);
        }


        [Theory]       
        [InlineData("/api/calculadora/calculajuros", 100, 5)]
        public async Task TesteRetornoCalculajuros(string url, double valorinicial, int meses)
        {
            //Arrange   
            var urlnew = $"{url}?valorinicial={valorinicial}&meses={meses}";
                       
            // Act
            var response = await _client.GetAsync(urlnew);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299 
            Assert.Equal("R$ 105,10", response.Content.ReadAsStringAsync().Result);
        }

    }
}
