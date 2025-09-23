internal class Program
{
    private static void Main(string[] args)
    {
        int radio;

        Console.Write("Introduce el radio del circulo: ");
        radio = Convert.ToInt32(Console.ReadLine());

        CalculosMatematicos calculos = new CalculosMatematicos();


        Console.WriteLine("El area del circulo con radio {0} es: {1}", radio, calculos.CalcularArea(radio));
    }

    public class CalculosMatematicos
    {
        public double CalcularArea(double a)
        {
            return 3.1416 * (a * a);
        }
    }
}
