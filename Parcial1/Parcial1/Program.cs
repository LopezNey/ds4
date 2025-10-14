using System;
using System.Drawing;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {

        Console.Write("Ingrese el valor de N (DEBE SER PAR Y MINIMO EL 6: ");
        int valor = int.Parse(Console.ReadLine());

        if (valor >= 6 && valor % 2 == 0)
        {
            Matriz(valor);

        }
        else
        {
            Console.Write("Ingresaste un numero incorrecto, vuelve a intentarlo mas tarde");
        }
        Console.ReadKey();


    }

    public static void Matriz(int N)
    {

        int[,] matriz = new int[N, N];
        Random r = new Random();

        int bloque = 2; 

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if ((i < bloque && j < bloque) ||
                    (i < bloque && j >= N - bloque) ||
                    (i >= N - bloque && j < bloque) ||
                    (i >= N - bloque && j >= N - bloque)) 
                {
                    matriz[i, j] = r.Next(1, 101);
                }
                else
                {
                    matriz[i, j] = 0;
                }
            }
        }

        Console.WriteLine("\nMatriz generada:\n");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(matriz[i, j].ToString("D2") + "  ");
            }
            Console.WriteLine();
        }

        BigInteger producto = 1;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (matriz[i, j] != 0)
                    producto *= matriz[i, j];
            }
        }

        Console.WriteLine($"\nEl producto de los elementos aleatorios es: {producto}");
    }
}