internal class Program
{
    private int[] sueldos;

    public void Cargar()
    {
        sueldos = new int[6];
        for (int f = 1; f <= 5; f++)
        {
            Console.Write("Ingrese sueldo del operario " + f + ": ");
            sueldos[f] = Convert.ToInt32(Console.ReadLine());
        }
    }

    public void Imprimir()
    {
        Console.Write("Los 5 sueldos de los operarios \n");
        for (int f = 1; f <= 5; f++)
        {
            Console.Write("["+sueldos[f]+"] ");
        }
        Console.ReadKey();

    }
    private static void Main(string[] args)
    {
        Program pv = new Program();
        pv.Cargar();
        pv.Imprimir();
    }
} 