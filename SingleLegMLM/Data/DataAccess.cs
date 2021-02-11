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

    public static class CommonMethod
    {
        public static List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row => {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                        catch (Exception ex) {
                            
                        }
                    }
                }
                return objT;
            }).ToList();
        }
    }
    //Example
    //public List<Student> GetStudentList()
    //{
    //    Datatable ResultDT = new DataTable();
    //    ResultDT = _DataBAL.GetData(); // Call BusinessLogic to fill DataTable, Here your ResultDT will get the result in which you will be having single or multiple rows with columns "StudentId,RoleNumber and Name"  
    //    List<Student> Studentlist = new List<Student>();
    //    Studentlist = CommonMethod.ConvertToList<Student>(ResultDT);
    //    return Studentlist;
    //}
    public class DataAccess: ConnectionDb, IDisposable
    {
       private int timeout = 45;
       //private string constr = "";
       public DataAccess(string constr, int ConnectTimeout=30)
           : base(constr)
       {
           try
           {
               timeout = ConnectTimeout;
           }
           catch (Exception exc)
           {
               CloseConnection();
           }
       }

       public SqlTransaction GetTrans() 
       {
            SqlTransaction trans = con.BeginTransaction();
           return trans;
       }
       public void ExecuteQuery(string Command)
       {
           try
           {
               OpenConnection();
               SqlCommand cmd = con.CreateCommand();
               cmd.CommandText = Command;
               cmd.CommandTimeout = timeout;
               cmd.ExecuteNonQuery();
               cmd.Dispose();
               cmd = null;
           }
           catch (Exception exc)
           {
               CloseConnection();
               //CreateLog(exc, Command, "DataClass.ExecuteQuery");
           }
           //CloseConnection();
       }

       public void ExecuteQuery(string Command, SqlTransaction trans, CommandType cmdtype)
       {
           try
           {
               if (trans.Connection != null)
               {
                   OpenConnection();
                    SqlCommand cmd = con.CreateCommand();
                   cmd.CommandType = cmdtype;
                   cmd.CommandText = Command;
                   cmd.CommandTimeout = timeout;
                   cmd.Transaction = trans;
                   cmd.ExecuteNonQuery();
                   cmd.Dispose();
                   cmd = null;
               }
               else
               {
                   // throw new Exception {  }
               }
           }
           catch (Exception exc)
           {
               trans.Rollback();
               CloseConnection();
           }
           //CloseConnection();
       }

       public void ExecuteQuery(string Command,IList<IDbDataParameter> Params, CommandType cmdtype)
       {
           try
           {
               OpenConnection();
                SqlCommand cmd = con.CreateCommand();
               cmd.CommandText = Command;
               cmd.CommandTimeout = timeout;
               cmd.CommandType = cmdtype;

                foreach (IDbDataParameter prm in Params)
               {
                   cmd.Parameters.Add(prm);
               }
               cmd.ExecuteNonQuery();
               cmd.Dispose();
               cmd = null;
           }
           catch (Exception exc)
           {
               CloseConnection();
               //CreateLog(exc, Command, "DataClass.ExecuteQuery");
           }
           //CloseConnection();
       }
        public string ExecuteQuerySP(string Command, IList<IDbDataParameter> Params, CommandType cmdtype)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = Command;
                cmd.CommandTimeout = timeout;
                cmd.CommandType = cmdtype;

                foreach (IDbDataParameter prm in Params)
                {
                    cmd.Parameters.Add(prm);
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
                return cmd.Parameters["@OUTMemberID"].Value.ToString();
            }
            catch (Exception exc)
            {
                CloseConnection();
                //CreateLog(exc, Command, "DataClass.ExecuteQuery");
            }
            //CloseConnection();
            return "";
        }

        public void ExecuteQuery(string Command, IList<IDbDataParameter> Params, SqlTransaction trans,CommandType cmdtype)
       {
           try
           {
               if (trans.Connection != null)
               {
                   OpenConnection();
                   SqlCommand cmd = con.CreateCommand();
                   cmd.CommandType = cmdtype;
                   cmd.CommandText = Command;
                   cmd.CommandTimeout = timeout;
                   cmd.Transaction = trans;

                   foreach (IDbDataParameter prm in Params)
                   {
                       cmd.Parameters.Add(prm);
                   }
                   cmd.ExecuteNonQuery();
                   cmd.Dispose();
                   cmd = null;
               }
           }
           catch (Exception exc)
           {
               trans.Rollback();
               CloseConnection();
               //CreateLog(exc, Command, "DataClass.ExecuteQuery");
           }
           //CloseConnection();
       }

       public DataSet GetDataSet(string Command)
       {
           
           DataSet getds = new DataSet();
           try
           {
               SqlDataAdapter adap = new SqlDataAdapter();
               adap.SelectCommand = con.CreateCommand();
               adap.SelectCommand.CommandText = Command;
               adap.SelectCommand.CommandTimeout = timeout;
               adap.Fill(getds);
               adap = null;
           }
           catch (Exception exc)
           {
               CloseConnection();
           }
           //CloseConnection();
           return getds;
       }

       public DataSet GetDataSet(string Command, SqlTransaction trans)
       {

           DataSet getds = new DataSet();
           try
               {
               SqlDataAdapter adap = new SqlDataAdapter();
               adap.SelectCommand = con.CreateCommand();
               adap.SelectCommand.CommandText = Command;
               adap.SelectCommand.Transaction = trans;
               adap.SelectCommand.CommandTimeout = timeout;
               adap.Fill(getds);
               adap = null;
               }
           catch (Exception exc)
               {
               CloseConnection();
               }
           //CloseConnection();
           return getds;
       }


       public DataSet GetDataSet(string Command, IList<IDbDataParameter> Params, CommandType cmdtype)
       {
           DataSet getds = new DataSet();
           try
           {
               SqlDataAdapter adap = new SqlDataAdapter();
               adap.SelectCommand = con.CreateCommand();
               adap.SelectCommand.CommandText = Command;
               adap.SelectCommand.CommandType = cmdtype;
               adap.SelectCommand.CommandTimeout = timeout;
               foreach (IDbDataParameter prm in Params)
               {
                   adap.SelectCommand.Parameters.Add(prm);
               }
               adap.Fill(getds);
               adap = null;
           }
           catch (Exception exc)
           {
               CloseConnection();
           }
           CloseConnection();
           return getds;
       }

       public IDataReader GetDataReader(string Command)
       {
           IDataReader getdr;
           try
           {
               OpenConnection();
               SqlCommand cmd = con.CreateCommand();
               cmd.CommandText = Command;
               cmd.CommandTimeout = timeout;
               getdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           }
           catch (Exception exc)
           {
                getdr = null;
                CloseConnection();
           }
           return getdr;
       }
       public DataTable GetDataTable(string Command)
       {
           DataSet getds = new DataSet();
           try
           {

               SqlDataAdapter adap = new SqlDataAdapter();
               adap.SelectCommand = con.CreateCommand();
               adap.SelectCommand.CommandText = Command;
               adap.Fill(getds);
               adap = null;
               return getds.Tables[0];
           }
           catch (Exception exc)
           {
               return null;
           }
           
       }
       public Boolean CheckDataExistance(string Command)
       {
           Boolean check_existance = false;
           try
           {
               OpenConnection();
               SqlCommand cmd = con.CreateCommand();
               cmd.CommandText = Command;
               cmd.CommandTimeout = timeout;
               check_existance = Convert.ToBoolean(cmd.ExecuteScalar());
               cmd.Dispose();
               cmd = null;
               CloseConnection();
           }
           catch (Exception exc)
           {
           }
           return check_existance;
       }
       public string GetSingleValue(string Command, SqlTransaction trns)
       {
           string strval = "";
           try
           {
               if (trns.Connection != null)
               {
                   OpenConnection();
                   SqlCommand sqlcmd = con.CreateCommand();
                   sqlcmd.CommandText = Command;
                   sqlcmd.Transaction = trns;
                   sqlcmd.CommandTimeout = timeout;
                   strval = Convert.ToString(sqlcmd.ExecuteScalar());
                   sqlcmd.Dispose();
                   sqlcmd = null;
               }
           }
           catch (Exception exc)
           {
            
           }
          // CloseConnection();
           return strval;
       }
       public string GetValue(string Command)
       {
           string strval = "";
           try
           {
               OpenConnection();
               //trns = con.BeginTransaction("getno");
               SqlCommand sqlcmd = con.CreateCommand();
               sqlcmd.CommandText = Command;
               sqlcmd.CommandTimeout = timeout;
               strval = Convert.ToString(sqlcmd.ExecuteScalar());
               sqlcmd.Dispose();
               CloseConnection();
           }
           catch (Exception exc)
           {
            
           }
           return strval;
       }


       public void Dispose()
       {
           CloseConnection();
       }
    }
}
