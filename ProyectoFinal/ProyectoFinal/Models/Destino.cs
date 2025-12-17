using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Destino
    {
        public int Id { get; set; }
        public string Nombre { get; set; }         
        public string Zona { get; set; }           
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }
        public bool Activo { get; set; }
    }
}