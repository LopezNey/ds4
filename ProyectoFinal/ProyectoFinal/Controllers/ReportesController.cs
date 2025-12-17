using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        private readonly ReporteService _reportes = new ReporteService();

        public ActionResult TopDestinos()
        {
            var data = _reportes.TopDestinos();
            return View(data);
        }

        public ActionResult Ingresos()
        {
            var data = _reportes.IngresosPorMes();
            return View(data);
        }

        public ActionResult Ocupacion()
        {
            var data = _reportes.OcupacionSlots();
            return View(data);
        }
    }
}