using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Tarifa
    {
        public int Id { get; set; }
        public int DestinoId { get; set; }
        public string TipoVehiculo { get; set; }
        public decimal Precio { get; set; }
    }
}