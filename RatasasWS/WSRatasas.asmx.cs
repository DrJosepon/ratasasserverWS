using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Newtonsoft.Json;
//using System.Web.Script.Serialization;  


namespace RatasasWS
{
    /// <summary>
    /// Descripción breve de WSRatasas
    /// </summary>
    [WebService(Namespace = "RatasasWS")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class WSRatasas : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(XmlSerializeString = false, ResponseFormat = ResponseFormat.Json)]
        public string getEntidades(string reg)
        {
            string region;
            DataSet set;
            SqlDataAdapter adap;
            region = reg;
            set = new DataSet();
            SqlConnection sql = new clsConexion().getConnection();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand("USP_S_LISTARBANCO", sql);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idreg", reg);
                adap = new SqlDataAdapter(command);
                adap.Fill(set);
                sql.Close();
            }
            catch (Exception ex)
            {
            }
            return JsonConvert.SerializeObject(set, Formatting.Indented);
        }


        [WebMethod]
        [ScriptMethod(XmlSerializeString = false, ResponseFormat = ResponseFormat.Json)]
        public string getSucursales(string identi)
        {
            string ident;
            DataSet set;
            SqlDataAdapter adap;
            ident = identi;
            set = new DataSet();
            SqlConnection sql = new clsConexion().getConnection();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand("USP_S_SUCURSALES", sql);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idban", ident);
                adap = new SqlDataAdapter(command);
                adap.Fill(set);
                sql.Close();
            }
            catch (Exception ex)
            {
            }
            return JsonConvert.SerializeObject(set, Formatting.Indented);
        }


        [WebMethod]
        [ScriptMethod(XmlSerializeString = false, ResponseFormat = ResponseFormat.Json)]
        public string getNombres(string user, string pass)
        {
            string usu, pas;
            DataSet set;
            SqlDataAdapter adap;
            usu = user;
            pas = pass;
            set = new DataSet();
            SqlConnection sql = new clsConexion().getConnection();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand("USP_Usuario_Login", sql);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@codigousu", usu);
                command.Parameters.AddWithValue("@claveusu", pas);
                adap = new SqlDataAdapter(command);
                adap.Fill(set);
                sql.Close();
            }
            catch (Exception ex)
            {
            }
            return JsonConvert.SerializeObject(set, Formatting.Indented);
        }


        [WebMethod]
        [ScriptMethod(XmlSerializeString = false, ResponseFormat = ResponseFormat.Json)]
        public string getTasas(string reg)
        {
            string usu;
            DataSet set;
            SqlDataAdapter adap;
            usu = reg;
            set = new DataSet();
            SqlConnection sql = new clsConexion().getConnection();
            try
            {
                sql.Open();
                SqlCommand command = new SqlCommand("USP_S_TASAS", sql);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idban", usu);
                adap = new SqlDataAdapter(command);
                adap.Fill(set);
                sql.Close();
            }
            catch (Exception ex)
            {
            }
            return JsonConvert.SerializeObject(set, Formatting.Indented);
        }
    }
}
