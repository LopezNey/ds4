internal class Program
{
    private int[,] mat;

    public void Ingresar()
    {
        mat = new int[3, 4];
        for (int f = 0; f < 3; f++)
        {
            for (int c = 0; c < 4; c++)
            {
                Console.Write("Ingrese posicion ["+(f+1)+","+(c+1)+"]: ");
                mat[f, c] = Convert.ToInt32(Console.ReadLine());
            }

        }
    }

    public void Imprimir()
    {
        for (int f = 0; f < 3; f++)
        {
            for (int c = 0;c < 4; c++)
            {
                Console.Write(mat[f, c] + " ");
            }
            Console.WriteLine();
        }
        Console.ReadKey();

    }
    private static void Main(string[] args)
    {
        Program pv = new Program();
        pv.Ingresar();
        pv.Imprimir();
    }
}