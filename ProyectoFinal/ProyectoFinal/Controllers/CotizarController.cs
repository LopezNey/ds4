using ProyectoFinal.Data;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class CotizarController : Controller
    {
        // GET: Cotizar
        private readonly CatalogoService _catalogo = new CatalogoService();
        private readonly CotizacionService _cotizacion = new CotizacionService();

        [HttpGet]
        public ActionResult Index(int? destinoId, string tipoVehiculo)
        {
            var vm = new CotizacionViewModel();

            vm.Destinos = _catalogo.ListarDestinosActivos()
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = $"{d.Nombre} ({d.Zona})",
                    Selected = destinoId.HasValue && d.Id == destinoId.Value
                })
                .ToList();

            vm.TiposVehiculo = new[]
            {
                new SelectListItem { Value = "Sedan", Text = "Sedán", Selected = string.Equals(tipoVehiculo, "Sedan", System.StringComparison.OrdinalIgnoreCase) },
                new SelectListItem { Value = "SUV",   Text = "SUV",   Selected = string.Equals(tipoVehiculo, "SUV",   System.StringComparison.OrdinalIgnoreCase) },
                new SelectListItem { Value = "Van",   Text = "Van",   Selected = string.Equals(tipoVehiculo, "Van",   System.StringComparison.OrdinalIgnoreCase) }
            }.ToList();

            if (destinoId.HasValue)
                vm.DestinoId = destinoId.Value;

            if (!string.IsNullOrWhiteSpace(tipoVehiculo))
                vm.TipoVehiculo = tipoVehiculo;

            vm.Pasajeros = 1;
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CotizacionViewModel vm)
        {
            vm.Destinos = _catalogo.ListarDestinosActivos()
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = $"{d.Nombre} ({d.Zona})" })
                .ToList();

            vm.TiposVehiculo = new[]
            {
                new SelectListItem { Value = "Sedan", Text = "Sedán" },
                new SelectListItem { Value = "SUV", Text = "SUV" },
                new SelectListItem { Value = "Van", Text = "Van" }
            }.ToList();

            var precio = _cotizacion.Cotizar(vm.DestinoId, vm.TipoVehiculo);
            vm.Precio = precio;

            return View(vm);
        }
    }
}