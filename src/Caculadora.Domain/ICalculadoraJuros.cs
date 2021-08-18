namespace Caculadora.Domain
{
    public interface ICalculadoraJuros
    {
        double GetTaxaJuros { get; }

        double CalcuraJurosCompostos(double valorInicial, int tempo, double taxa);
     
    }
}
