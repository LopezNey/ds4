internal class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("Ingrese la nota del estudiante: ");
        float nota = float.Parse(Console.ReadLine());

        if (nota >= 70)
        {
            Console.WriteLine();
            Console.WriteLine($"Su nota es {nota} ha aprobado");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($"Su nota es {nota} ha reprobado, debe repetir");
        }

    }
}