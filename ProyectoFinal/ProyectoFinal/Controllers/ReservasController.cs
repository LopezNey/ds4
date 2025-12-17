using ProyectoFinal.Data;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class ReservasController : Controller
    {
        // GET: Reservas
        private readonly CatalogoService _catalogo = new CatalogoService();
        private readonly AgendaService _agenda = new AgendaService();

        [HttpGet]
        public ActionResult Crear(int destinoId, string tipoVehiculo, decimal precio)
        {
            var vm = new ReservaCreateViewModel
            {
                DestinoId = destinoId,
                PrecioEstimado = precio,
                Fecha = DateTime.Today
            };

            vm.Destinos = _catalogo.ListarDestinosActivos()
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = $"{d.Nombre} ({d.Zona})", Selected = d.Id == destinoId })
                .ToList();

            vm.Vehiculos = _catalogo.ListarVehiculosActivos()
                .Where(v => v.Tipo.Equals(tipoVehiculo, StringComparison.OrdinalIgnoreCase))
                .Select(v => new SelectListItem { Value = v.Id.ToString(), Text = $"{v.Nombre} - {v.Capacidad} pax" })
                .ToList();

            vm.SlotsDisponibles = _agenda.ObtenerSlotsLibres(vm.Fecha);
            vm.Pasajeros = 1;

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(ReservaCreateViewModel vm)
        {
            // recargar listas por si hay error
            vm.Destinos = _catalogo.ListarDestinosActivos()
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = $"{d.Nombre} ({d.Zona})", Selected = d.Id == vm.DestinoId })
                .ToList();

            vm.Vehiculos = _catalogo.ListarVehiculosActivos()
                .Select(v => new SelectListItem { Value = v.Id.ToString(), Text = $"{v.Nombre} ({v.Tipo})", Selected = v.Id == vm.VehiculoId })
                .ToList();

            vm.SlotsDisponibles = _agenda.ObtenerSlotsLibres(vm.Fecha);

            if (string.IsNullOrWhiteSpace(vm.NombreCliente) || string.IsNullOrWhiteSpace(vm.Telefono))
            {
                ViewBag.Error = "Nombre y teléfono son obligatorios.";
                return View(vm);
            }

            try
            {
                var reserva = new Reserva
                {
                    NombreCliente = vm.NombreCliente,
                    Telefono = vm.Telefono,
                    Email = vm.Email,
                    VehiculoId = vm.VehiculoId,
                    DestinoId = vm.DestinoId,
                    Fecha = vm.Fecha,
                    Hora = vm.Hora,
                    Pasajeros = vm.Pasajeros,
                    PrecioEstimado = vm.PrecioEstimado
                };

                int reservaId = _agenda.CrearReserva(reserva);

                return RedirectToAction("Confirmacion", new { id = reservaId });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(vm);
            }
        }

        public ActionResult Confirmacion(int id)
        {
            ViewBag.ReservaId = id;
            return View();
        }
    }
}