internal class Program
{
    private static void Main(string[] args)
    {
        int primerNumero, segundoNumero;

        Console.Write("Introduce el primer numero: ");
        primerNumero = Convert.ToInt32(Console.ReadLine());

        Console.Write("Introduce el segundo numero: ");
        segundoNumero = Convert.ToInt32(Console.ReadLine());

        CalculosMatematicos calculos = new CalculosMatematicos();


        Console.WriteLine("El resultado de ({0}+{1})*({0}-{1}) es: {2}", primerNumero, segundoNumero, calculos.Calcular(primerNumero, segundoNumero));
    }

    public class CalculosMatematicos
    {
        public int Calcular(int a, int b)
        {
            return (a + b) * (a - b);
        }
    }
}
