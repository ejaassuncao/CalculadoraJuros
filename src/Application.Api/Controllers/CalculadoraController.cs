using Caculadora.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Application.Api.Controllers
{   
    [Route("/api/calculadora")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        private readonly ICalculadoraJuros _calculadoraJuros;
      
        public CalculadoraController(ICalculadoraJuros calculadoraJuros)
        {
            _calculadoraJuros = calculadoraJuros;
        }

        /// <summary>
        /// Retorna o juros de 1% ou 0,01
        /// </summary>      
        [HttpGet("taxajuros")]
        public IActionResult Get()
        {
            var taxaDeJuros = string.Format("{0:N}", _calculadoraJuros.GetTaxaJuros);

            return Ok(new { taxaJuros = taxaDeJuros });
        }

        /// <summary>
        /// Ela faz um cálculo em memória, de juros compostos, conforme abaixo: Valor Final = Valor Inicial * (1 + juros) ^ Tempo
        /// </summary>      
        [HttpGet("calculajuros")]
        public IActionResult Get(double valorinicial, int meses)
        {
            var valorCalculado = string.Format("{0:c2}", _calculadoraJuros.CalcuraJurosCompostos(valorinicial, meses, _calculadoraJuros.GetTaxaJuros));

            return Ok(new { ValorCalculado = valorCalculado });
        }
    }
}
