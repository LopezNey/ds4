internal class Program
{
    private static void Main(string[] args)
    {
        int suma, cant, numero, promedio;

        suma = 0;
        cant = 0;

        do
        {
            Console.Write("Ingrese un numero entero (0 para finalizar): ");
            numero = Convert.ToInt32(Console.ReadLine());
            if (numero != 0)
            {
                suma = suma + numero;
                cant++;
            }
        } while (numero != 0);
        if (cant != 0)
        {
            promedio = suma / cant;
            Console.Write("El promedio de los valores ingresados es: " + promedio);

        }    
        else
        {
            Console.Write("No se ingresaron valores");
        }
        Console.ReadLine();

    }
}