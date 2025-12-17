using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        public string NombreCliente { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public int VehiculoId { get; set; }
        public int DestinoId { get; set; }

        public DateTime Fecha { get; set; }   
        public TimeSpan Hora { get; set; }        

        public int Pasajeros { get; set; }
        public decimal PrecioEstimado { get; set; }

        public string Estado { get; set; }   
        public DateTime CreadoEn { get; set; }
    }
}