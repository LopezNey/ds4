using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Data
{
    public class Db
    {
        protected SqlConnection GetConnection()
        {
            string cn = ConfigurationManager
                .ConnectionStrings["TurismoDB"]
                .ConnectionString;

            return new SqlConnection(cn);
        }
    }
}