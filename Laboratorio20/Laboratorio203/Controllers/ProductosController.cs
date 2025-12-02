using Laboratorio203.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio203.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        private string connectionString =
            ConfigurationManager.ConnectionStrings["ProductosDb"].ConnectionString;

        // GET: Productos
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Laptop());
        }

        [HttpPost]
        public ActionResult Index(string accion, Laptop modelo)
        {
            try
            {
                switch (accion)
                {
                    case "Buscar":
                        if (modelo.Id <= 0)
                        {
                            ViewBag.Error = "Ingrese un Id válido para buscar.";
                        }
                        else
                        {
                            var encontrado = ObtenerLaptopPorId(modelo.Id);
                            if (encontrado == null)
                            {
                                ViewBag.Mensaje = "Registro no encontrado.";
                                modelo = new Laptop { Id = modelo.Id };
                            }
                            else
                            {
                                modelo = encontrado;
                                ViewBag.Mensaje = "Registro encontrado, puede modificar y guardar.";
                            }
                        }
                        break;

                    case "Nuevo":
                        modelo = new Laptop();
                        ViewBag.Mensaje = "Ingrese los datos y presione Guardar para insertar.";
                        break;

                    case "Guardar":
                        if (!ModelState.IsValid)
                        {
                            ViewBag.Error = "Complete todos los campos.";
                            break;
                        }

                        if (modelo.Id == 0)
                        {
                            InsertarLaptop(modelo);
                            ViewBag.Mensaje = "Registro insertado correctamente.";
                        }
                        else
                        {
                            ActualizarLaptop(modelo);
                            ViewBag.Mensaje = "Registro actualizado correctamente.";
                        }
                        break;

                    case "Eliminar":
                        if (modelo.Id <= 0)
                        {
                            ViewBag.Error = "Ingrese un Id válido para eliminar.";
                        }
                        else
                        {
                            EliminarLaptop(modelo.Id);
                            ViewBag.Mensaje = "Registro eliminado correctamente.";
                            modelo = new Laptop();
                        }
                        break;

                    case "Cancelar":
                        modelo = new Laptop();
                        ViewBag.Mensaje = "Operación cancelada.";
                        break;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
            }

            return View(modelo);
        }

        private Laptop ObtenerLaptopPorId(int id)
        {
            Laptop lap = null;

            using (var con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
                "SELECT ID, NOMBRE, PRECIO, STOCK FROM LAPTOPS WHERE ID = @ID", con))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lap = new Laptop
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            Nombre = reader["NOMBRE"].ToString(),
                            Precio = Convert.ToDecimal(reader["PRECIO"]),
                            Stock = Convert.ToInt32(reader["STOCK"])
                        };
                    }
                }
            }

            return lap;
        }

        private void InsertarLaptop(Laptop laptop)
        {
            using (var con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
                "INSERT INTO LAPTOPS (NOMBRE, PRECIO, STOCK) VALUES (@NOMBRE, @PRECIO, @STOCK)", con))
            {
                cmd.Parameters.AddWithValue("@NOMBRE", laptop.Nombre);
                cmd.Parameters.AddWithValue("@PRECIO", laptop.Precio);
                cmd.Parameters.AddWithValue("@STOCK", laptop.Stock);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void ActualizarLaptop(Laptop laptop)
        {
            using (var con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
                "UPDATE LAPTOPS SET NOMBRE = @NOMBRE, PRECIO = @PRECIO, STOCK = @STOCK WHERE ID = @ID", con))
            {
                cmd.Parameters.AddWithValue("@NOMBRE", laptop.Nombre);
                cmd.Parameters.AddWithValue("@PRECIO", laptop.Precio);
                cmd.Parameters.AddWithValue("@STOCK", laptop.Stock);
                cmd.Parameters.AddWithValue("@ID", laptop.Id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void EliminarLaptop(int id)
        {
            using (var con = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
                "DELETE FROM LAPTOPS WHERE ID = @ID", con))
            {
                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}