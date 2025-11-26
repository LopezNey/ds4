using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio192.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string resultado = "";
            string url = "https://localhost:44380/api/values";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader != null)
                    {
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            resultado = objReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                resultado = "Error en la llamada al API: " + ex.Message;
            }

            ViewBag.Resultado = resultado;
            return View();
        }

    }
}