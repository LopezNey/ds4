using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class CatalogoController : Controller
    {
        // GET: Catalogo
        private readonly CatalogoService _catalogo = new CatalogoService();

        public ActionResult Flota()
        {
            var vehiculos = _catalogo.ListarVehiculosActivos();
            return View(vehiculos);
        }

        public ActionResult Destinos()
        {
            var destinos = _catalogo.ListarDestinosActivos();
            return View(destinos);
        }
    }
}