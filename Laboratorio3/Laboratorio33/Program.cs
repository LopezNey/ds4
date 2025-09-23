internal class Program
{
    private static void Main(string[] args)
    {
        int primerNumero, segundoNumero;

        Console.Write("Ingrese el primer lado del rectángulo: ");
        primerNumero = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ingrese el segundo lado del rectángulo: ");
        segundoNumero = Convert.ToInt32(Console.ReadLine());

        CalculosMatematicos calculos = new CalculosMatematicos();


        Console.WriteLine("El perímetro del rectángulo es: {0}", calculos.CalcularPerimetro(primerNumero, segundoNumero));
    }

    public class CalculosMatematicos
    {
        public int CalcularPerimetro(int a, int b)
        {
            return 2 * (a + b);
        }
    }
}