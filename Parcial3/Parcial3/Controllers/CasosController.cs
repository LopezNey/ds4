using Parcial3.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parcial3.Controllers
{
    public class CasosController : Controller
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // GET: Casos
        public ActionResult Index()
        {
            List<Caso> lista = new List<Caso>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT CasoId, Cliente, Abogado, Titulo, Descripcion, FechaInicio, FechaVencimiento, Estado FROM NL_Casos";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Caso
                    {
                        CasoId = (int)dr["CasoId"],
                        Cliente = dr["Cliente"].ToString(),
                        Abogado = dr["Abogado"].ToString(),
                        Titulo = dr["Titulo"].ToString(),
                        Descripcion = dr["Descripcion"].ToString(),
                        FechaInicio = Convert.ToDateTime(dr["FechaInicio"]),
                        FechaVencimiento = dr["FechaVencimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FechaVencimiento"]),
                        Estado = dr["Estado"].ToString()
                    });
                }
            }

            return View(lista);
        }

        // GET: Casos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Casos/Create
        [HttpPost]
        public ActionResult Create(Caso caso)
        {
            if (!ModelState.IsValid)
            {
                return View(caso);
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO NL_Casos
                               (Cliente, Abogado, Titulo, Descripcion, FechaInicio, FechaVencimiento, Estado)
                               VALUES (@Cliente, @Abogado, @Titulo, @Descripcion, @FechaInicio, @FechaVencimiento, @Estado)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Cliente", caso.Cliente);
                cmd.Parameters.AddWithValue("@Abogado", caso.Abogado);
                cmd.Parameters.AddWithValue("@Titulo", caso.Titulo);
                cmd.Parameters.AddWithValue("@Descripcion", (object)caso.Descripcion ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@FechaInicio", caso.FechaInicio);

                if (caso.FechaVencimiento.HasValue)
                    cmd.Parameters.AddWithValue("@FechaVencimiento", caso.FechaVencimiento.Value);
                else
                    cmd.Parameters.AddWithValue("@FechaVencimiento", DBNull.Value);

                cmd.Parameters.AddWithValue("@Estado", caso.Estado);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }
    }
}
