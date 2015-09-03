using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RatasasWS
{
    public class clsConexion
    {
        public SqlConnection getConnection()
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = "Server=localhost;Database=RATASAS;User ID=ratas;password=feed;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            return sql;
        }
    }
}