
public class Aleatorios
{
    Random r = new Random();


    public int GenNum(int min, int max)
    {
        return r.Next(min, max + 1);
    }


    public int[] GenArr(int cantidad)
    {
        int min = r.Next(1, 50);
        int max = r.Next(min + 1, 100);

        int[] arr = new int[cantidad];
        for (int i = 0; i < cantidad; i++)
        {
            arr[i] = GenNum(min, max);
        }

        Console.WriteLine($"Límites aleatorios usados: {min} y {max}");
        return arr;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Aleatorios a = new Aleatorios();


        Console.Write("Ingrese límite mínimo: ");
        int min = int.Parse(Console.ReadLine());

        Console.Write("Ingrese límite máximo: ");
        int max = int.Parse(Console.ReadLine());

        int numero = a.GenNum(min, max);
        Console.WriteLine($"Número generado entre {min} y {max}: {numero}");


        Console.Write("\nIngrese cantidad de números a generar en arreglo: ");
        int cantidad = int.Parse(Console.ReadLine());

        int[] arr = a.GenArr(cantidad);

        Console.Write("Arreglo generado: ");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}