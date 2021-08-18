using System;

namespace Caculadora.Domain
{
    public class CalculadoraJuros : ICalculadoraJuros
    {
        public static double TAXA_JUROS => 0.01;   

        public double CalcuraJurosCompostos(double valorInicial, int tempo, double taxa)
        {
            if (valorInicial <= 0) throw new ArgumentException("O parametro valor Inicial não poderá ser menor ou igual a zero ");
            
            return Math.Round(valorInicial * Math.Pow((taxa + 1), tempo),2);
        }

        public double GetTaxaJuros => TAXA_JUROS;
      
    }
}
