using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio81
{
    internal class Persona
    {
        public string Nombre, NIF;
        public int Edad;

        public void Cumple()
        {
            Edad++;

        }

        public Persona(string nombre, string nif, int edad)
        {
            Nombre = nombre;
            NIF = nif;
            Edad = edad;
        }


    }
    internal class Trabajador : Persona
    {
        public int Sueldo;

        public Trabajador(String nombre, int edad, string nif, int sueldo) : base(nombre, nif, edad)
        {
            Sueldo = sueldo;
        }

    }
}
