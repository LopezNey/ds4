internal class Program
{
    private static void Main(string[] args)
    {
        int numero, x;

        Console.Write("Ingrese el valor de 'n': ");
        numero = Convert.ToInt32(Console.ReadLine());

        x = 1;
        while (x <= numero)
        {
            Console.WriteLine(x);
            x++;

        }

    }
}