using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProyectoFinal.Models
{
    public class CotizacionViewModel
    {
        public int DestinoId { get; set; }
        public string TipoVehiculo { get; set; }

        public int Pasajeros { get; set; }

        public decimal? Precio { get; set; }

        public List<SelectListItem> Destinos { get; set; }
        public List<SelectListItem> TiposVehiculo { get; set; }

        public CotizacionViewModel()
        {
            Destinos = new List<SelectListItem>();
            TiposVehiculo = new List<SelectListItem>();
        }
    }
}