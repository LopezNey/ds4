using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3.Models
{
    public class Caso
    {
        public int CasoId { get; set; }
        public string Cliente { get; set; }
        public string Abogado { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string Estado { get; set; }
    }
}