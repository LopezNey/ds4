using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Data
{
    public class ReporteService : Db
    {
        public List<ReporteTopDestinosItem> TopDestinos()
        {
            var lista = new List<ReporteTopDestinosItem>();

            using (var cn = GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT TOP 5 d.Nombre AS Destino, COUNT(*) AS Total " +
                "FROM Reservas r JOIN Destinos d ON d.Id = r.DestinoId " +
                "GROUP BY d.Nombre ORDER BY Total DESC", cn))
            {
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ReporteTopDestinosItem
                        {
                            Destino = dr["Destino"].ToString(),
                            Total = (int)dr["Total"]
                        });
                    }
                }
            }

            return lista;
        }

        public List<ReporteIngresosItem> IngresosPorMes()
        {
            var lista = new List<ReporteIngresosItem>();

            using (var cn = GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT YEAR(CreadoEn) AS Anio, MONTH(CreadoEn) AS Mes, SUM(PrecioEstimado) AS Total " +
                "FROM Reservas GROUP BY YEAR(CreadoEn), MONTH(CreadoEn) ORDER BY Anio, Mes", cn))
            {
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ReporteIngresosItem
                        {
                            Anio = (int)dr["Anio"],
                            Mes = (int)dr["Mes"],
                            Total = (decimal)dr["Total"]
                        });
                    }
                }
            }

            return lista;
        }

        public List<ReporteOcupacionItem> OcupacionSlots()
        {
            var lista = new List<ReporteOcupacionItem>();

            using (var cn = GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT Estado, COUNT(*) AS Total FROM Slots GROUP BY Estado", cn))
            {
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ReporteOcupacionItem
                        {
                            Estado = dr["Estado"].ToString(),
                            Total = (int)dr["Total"]
                        });
                    }
                }
            }

            return lista;
        }
    }
}