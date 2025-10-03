Imports System

Module peso
    Sub Main()
        ' se usa: " ' " para comentar una linea
        Dim M As Double
        Dim G As Double
        Dim P As Double

        G = 9.8
        Console.Write("Ingrese la masa del objeto:")
        M = Console.ReadLine()

        P = M * G
        Console.WriteLine("El peso del objeto es: {0}", P)
        Console.ReadKey()
    End Sub
End Module