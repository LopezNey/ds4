public class Laboratorio91
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese el precio del producto: ");
        double precio = Convert.ToDouble(Console.ReadLine());

        if (precio <= 0)
        {
            Console.WriteLine("El precio debe ser positivo.");
            return;
        }

        Console.Write("Ingrese forma de pago (efectivo/tarjeta): ");
        string formaPago = Console.ReadLine().ToLower();

        if (formaPago.ToLower() == "tarjeta")
        {
            Console.Write("Ingrese número de cuenta (16 dígitos): ");
            string cuenta = Console.ReadLine();

            if (cuenta.Length == 16)
                Console.WriteLine("Pago exitoso con tarjeta. Precio: $" + precio);
            else
                Console.WriteLine("Número de cuenta inválido.");
        }
        else if (formaPago.ToLower() == "efectivo")
        {
            Console.WriteLine("Pago en efectivo. Precio: $" + precio);
        }
        else
        {
            Console.WriteLine("Forma de pago inválida.");
        }
    }
}