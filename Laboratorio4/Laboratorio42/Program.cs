internal class Program
{
    private static void Main(string[] args)
    {
        int numero, fact=1;

        Console.Write("Ingrese un numero entero: ");
        numero = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= numero; i++)
        {
            fact = fact * i;
        }
        Console.WriteLine("La factorial es: "+fact);

    }
}