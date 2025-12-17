using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }         
        public string Tipo { get; set; }           
        public int Capacidad { get; set; }
        public int Maletas { get; set; }
        public decimal PrecioBase { get; set; }
        public string FotoUrl { get; set; }
        public bool Activo { get; set; }
    }
}