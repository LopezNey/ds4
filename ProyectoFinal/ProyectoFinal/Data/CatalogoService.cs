using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Data
{
    public class CatalogoService : Db
    {
        public List<Vehiculo> ListarVehiculosActivos()
        {
            var lista = new List<Vehiculo>();

            using (var cn = GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT Id, Nombre, Tipo, Capacidad, Maletas, PrecioBase, FotoUrl, Activo " +
                "FROM Vehiculos WHERE Activo = 1 ORDER BY Tipo, Nombre", cn))
            {
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Vehiculo
                        {
                            Id = (int)dr["Id"],
                            Nombre = dr["Nombre"].ToString(),
                            Tipo = dr["Tipo"].ToString(),
                            Capacidad = (int)dr["Capacidad"],
                            Maletas = (int)dr["Maletas"],
                            PrecioBase = (decimal)dr["PrecioBase"],
                            FotoUrl = dr["FotoUrl"] == System.DBNull.Value ? null : dr["FotoUrl"].ToString(),
                            Activo = (bool)dr["Activo"]
                        });
                    }
                }
            }

            return lista;
        }

        public List<Destino> ListarDestinosActivos()
        {
            var lista = new List<Destino>();

            using (var cn = GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT Id, Nombre, Zona, Descripcion, ImagenUrl, Activo " +
                "FROM Destinos WHERE Activo = 1 ORDER BY Zona, Nombre", cn))
            {
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Destino
                        {
                            Id = (int)dr["Id"],
                            Nombre = dr["Nombre"].ToString(),
                            Zona = dr["Zona"].ToString(),
                            Descripcion = dr["Descripcion"] == System.DBNull.Value ? null : dr["Descripcion"].ToString(),
                            ImagenUrl = dr["ImagenUrl"] == System.DBNull.Value ? null : dr["ImagenUrl"].ToString(),
                            Activo = (bool)dr["Activo"]
                        });
                    }
                }
            }

            return lista;
        }
    }
}