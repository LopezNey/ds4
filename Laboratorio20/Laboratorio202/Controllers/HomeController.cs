using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio202.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int n)
        {
            if (n <= 0)
            {
                ViewBag.Error = "N debe ser un número entero positivo.";
                return View();
            }

            int[,] matriz = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i + j == n - 1)
                        matriz[i, j] = 1;
                    else
                        matriz[i, j] = 0;
                }
            }

            ViewBag.N = n;
            ViewBag.Matriz = matriz;

            return View();
        }
    }
}