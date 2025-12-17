using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Models
{
    public class ReservaCreateViewModel
    {

        public string NombreCliente { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }


        public int VehiculoId { get; set; }
        public int DestinoId { get; set; }
        public int Pasajeros { get; set; }


        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }


        public decimal PrecioEstimado { get; set; }


        public List<SelectListItem> Vehiculos { get; set; }
        public List<SelectListItem> Destinos { get; set; }


        public List<Slot> SlotsDisponibles { get; set; }

        public ReservaCreateViewModel()
        {
            Vehiculos = new List<SelectListItem>();
            Destinos = new List<SelectListItem>();
            SlotsDisponibles = new List<Slot>();
        }
    }
}