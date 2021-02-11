using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLegMLM.Data
{
    public abstract class ConnectionDb
    { 
        protected SqlConnection con =null;
        public ConnectionDb( string constr)
        {
            try
            {
                if (con == null)
                {
                    con = new SqlConnection();
                    con.ConnectionString = constr;
                }
                string strCon = constr;
                OpenConnection();
            }
            catch (Exception ex)
            {
                //CreateLog(ex, "conection", "Connection Db");
                //System.Web.HttpContext.Current.Response.Redirect("~/index.aspx?err=" + ex.Message.Replace("\n", "").Replace("\r", ""));
                //throw new System.Exception("Server Connection has been expired, Please Login Again!");
            }

        }

        public void OpenConnection() 
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (System.Exception exd)
            {
                //System.Web.HttpContext.Current.Response.Redirect("~/index.aspx?err=Opening Connection Error:" + exd.Message);
                throw new System.Exception("Connection Problem : " + exd.Message);
            }
        }
        public void CloseConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }


    }
}
