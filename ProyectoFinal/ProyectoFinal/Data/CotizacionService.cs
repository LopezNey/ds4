using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Data
{
    public class CotizacionService : Db
    {
        public decimal? Cotizar(int destinoId, string tipoVehiculo)
        {
            using (var cn = GetConnection())
            using (var cmd = new SqlCommand("sp_Cotizar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DestinoId", destinoId);
                cmd.Parameters.AddWithValue("@TipoVehiculo", tipoVehiculo);

                cn.Open();
                object result = cmd.ExecuteScalar();

                if (result == null || result == System.DBNull.Value)
                    return null;

                return (decimal)result;
            }
        }
    }
}