using Caculadora.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Api
{
    public class InjectCDI
    {
        public InjectCDI(IServiceCollection services)
        {
            services.AddSingleton<ICalculadoraJuros, CalculadoraJuros>();            
        }
    }
}
