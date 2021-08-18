using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Teste.Configuracao
{
    public abstract class ConfigIntegracao: IClassFixture<WebApplicationFactory<Application.Api.Startup>>
    {    
        protected readonly HttpClient _client;

        public ConfigIntegracao(WebApplicationFactory<Application.Api.Startup> factory)
        {          
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = true
            });
        }

    }
}
