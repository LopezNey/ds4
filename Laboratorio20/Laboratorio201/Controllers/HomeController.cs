using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio201.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int numero)
        {
            var tabla = new List<string>();

            for (int i = 1; i <= 25; i++)
            {
                tabla.Add($"{numero} x {i} = {numero * i}");
            }

            ViewBag.Numero = numero;
            ViewBag.Tabla = tabla;

            return View();
        }
    }
}