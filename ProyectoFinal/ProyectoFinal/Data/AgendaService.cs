using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Data
{
    public class AgendaService : Db
    {
        public List<Slot> ObtenerSlotsLibres(DateTime fecha)
        {
            var lista = new List<Slot>();

            using (var cn = GetConnection())
            using (var cmd = new SqlCommand("sp_SlotsLibresPorFecha", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha", fecha.Date);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Slot
                        {
                            Id = (int)dr["Id"],
                            Fecha = (DateTime)dr["Fecha"],
                            Hora = (TimeSpan)dr["Hora"],
                            Estado = "LIBRE"
                        });
                    }
                }
            }

            return lista;
        }

        public int CrearReserva(Reserva reserva)
        {
            using (var cn = GetConnection())
            using (var cmd = new SqlCommand("sp_CrearReserva", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NombreCliente", reserva.NombreCliente);
                cmd.Parameters.AddWithValue("@Telefono", reserva.Telefono);
                cmd.Parameters.AddWithValue("@Email", (object)reserva.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@VehiculoId", reserva.VehiculoId);
                cmd.Parameters.AddWithValue("@DestinoId", reserva.DestinoId);
                cmd.Parameters.AddWithValue("@Fecha", reserva.Fecha.Date);
                cmd.Parameters.AddWithValue("@Hora", reserva.Hora);
                cmd.Parameters.AddWithValue("@Pasajeros", reserva.Pasajeros);
                cmd.Parameters.AddWithValue("@PrecioEstimado", reserva.PrecioEstimado);

                cn.Open();
                object result = cmd.ExecuteScalar(); // ReservaId
                return Convert.ToInt32(result);
            }
        }
    }
}