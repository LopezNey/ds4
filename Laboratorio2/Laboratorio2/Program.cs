using System;
using System.Reflection.Metadata.Ecma335;

namespace Laboratorio1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Client client = new Client();
            //Ejemplo utilizando las variables de instancia de Clase.
            client.FirstName = "Su_Nombre";
            client.LastName = "Su_Apellido";
            client.Age = 15;
            client.Id = 1;

            Console.WriteLine(client.GetFullName());
        }
    }

    public class Client
    {
        //Utilizando variables de instancia en clase.
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ushort Age { get; set; }

        public string GetFullName()
        {
            //Utilizadndo variables de instancia dentro de metodos de clase.
            return FirstName + " " + LastName;
        }
    }

}