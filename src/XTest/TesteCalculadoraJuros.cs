using System;
using Xunit;
using Caculadora.Domain;

namespace XTest
{
    public class TesteCalculadoraJuros
    {
        [Fact]
        public void TesteJurosCompostos()
        {
            var cal = new CalculadoraJuros();
            var result = cal.CalcuraJurosCompostos(100, 5, CalculadoraJuros.TAXA_JUROS);
            var expected = 105.10;

            Assert.Equal(expected, result);
        }


        [Fact]
        public void TesteJurosCompostosSemValorInicial()
        {
            var cal = new CalculadoraJuros();
            Assert.Throws<ArgumentException>(() => cal.CalcuraJurosCompostos(0, 5, CalculadoraJuros.TAXA_JUROS));
        }


        [Theory]      
        [InlineData(100, 12, 112.68)]
        [InlineData(500, 5, 525.51)]
        [InlineData(130, 6, 138.00)]
        [InlineData(130, 0, 130)]
        public void TesteJurosCompostosVariasSimulacoes(double valorInicial, int tempo, double valorEsperado)
        {
            var cal = new CalculadoraJuros();
            Assert.Equal(valorEsperado, cal.CalcuraJurosCompostos(valorInicial, tempo, CalculadoraJuros.TAXA_JUROS));
        }
    }
}
