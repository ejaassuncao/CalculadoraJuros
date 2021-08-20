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
        private readonly string _baseUrl = "api/calculadora";

        public TesteCalculadoraController(WebApplicationFactory<Startup> factory) : base(factory)
        {          
        }

        [Theory]
        [InlineData("/taxajuros")]
        public async Task TesteContentType(string url)
        {           
            var response = await _client.GetAsync(_baseUrl+url);
            //response.EnsureSuccessStatusCode();
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            response.EnsureSuccessStatusCode(); // Status Code 200-299

            Assert.Equal("text/plain; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }


        [Theory]
        [InlineData("/taxajuros")]
        public async Task TesteRetornotaxajuros(string url)
        {
            var response = await _client.GetAsync(_baseUrl + url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("0,01", response.Content.ReadAsStringAsync().Result);
        }


        [Theory]
        [InlineData("/calculajuros", 100, 5)]
        public async Task TesteRetornoCalculajuros(string url, double valorinicial, int meses)
        {
            //Arrange   
            var urlnew = $"{url}?valorinicial={valorinicial}&meses={meses}";

            // Act            
            var response = await _client.GetAsync(_baseUrl + urlnew);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299 
            Assert.Equal("R$ 105,10", response.Content.ReadAsStringAsync().Result);
        }

    }
}
