using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
namespace DBUtility
{
    public class DBHelperAccess
    {
       
            /// <summary>
        /// 连接数据库字符串
        /// </summary>
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GPSNETUserConnectStr"].ConnectionString;

        /// <summary>
        /// 存储数据库连接（保护类，只有由它派生的类才能访问）
        /// </summary>
        protected static OleDbConnection Connection= new OleDbConnection(connectionString);

        /// <summary>
        /// 构造函数：数据库的默认连接
        /// </summary>
        public DBHelperAccess()
        {
            string connStr;
            connStr = System.Configuration.ConfigurationManager.ConnectionStrings["GPSNETUserConnectStr"].ConnectionString;
           // connStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"].ToString(); //从web.config配置中读取
            connectionString = connStr;
            //connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + connStr;
           // connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            //
            Connection = new OleDbConnection(connectionString);
        }

        /// <summary>
        /// 构造函数：带有参数的数据库连接
        /// </summary>
        /// <param name="newConnectionString"></param>
        public DBHelperAccess(string newConnectionString)
        {
            //connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Request.PhysicalApplicationPath + newConnectionString;
            connectionString = newConnectionString;
            Connection = new OleDbConnection(connectionString);
        }

        /// <summary>
        /// 获得连接字符串
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }

        /// <summary>
        /// 执行SQL语句没有返回结果，如：执行删除、更新、插入等操作
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns>操作成功标志</returns>
        public static bool ExeSQL(string strSQL)
        {
            bool resultState = false; 

            Connection.Open();
            OleDbTransaction myTrans = Connection.BeginTransaction();
            OleDbCommand command = new OleDbCommand(strSQL, Connection, myTrans); 

            try
            {
                command.ExecuteNonQuery();
                myTrans.Commit();
                resultState = true;
            }
            catch
            {
                myTrans.Rollback();
                resultState = false;
            }
            finally
            {
                Connection.Close();
            }
            return resultState;
        }

        /// <summary>
        /// 执行SQL语句返回结果到DataReader中
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns>dataReader</returns>
        private OleDbDataReader ReturnDataReader(string strSQL)
        {
            Connection.Open();
            OleDbCommand command = new OleDbCommand(strSQL, Connection);
            OleDbDataReader dataReader = command.ExecuteReader();
            Connection.Close(); 

            return dataReader;
        }

        /// <summary>
        /// 执行SQL语句返回结果到DataSet中
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns>DataSet</returns>
        public static DataSet ReturnDataSet(string strSQL)
        {
            Connection.Open();
            DataSet dataSet = new DataSet();
            OleDbDataAdapter OleDbDA = new OleDbDataAdapter(strSQL, Connection);
            OleDbDA.Fill(dataSet, "objDataSet"); 
            Connection.Close();
            return dataSet;
        }

        /// <summary>    
        /// 执行不带参数的SQL语句，返回影响的记录数
        /// </summary>    
        /// <param name="SQLString">SQL语句</param>    
        /// <returns>影响的记录数</returns>    
        public static int ExecuteSqlNonPars(string SQLString)
        {
            DataSet ds = ReturnDataSet(SQLString);
            int n = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return n;
            //using (OleDbConnection connection = new OleDbConnection(connectionString))
            //{
            //    using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
            //    {
            //        try
            //        {
            //            connection.Open();
            //            int rows = cmd.ExecuteNonQuery();
            //            return rows;
            //        }
            //        catch (System.Data.OleDb.OleDbException E)
            //        {
            //            connection.Close();
            //            throw new Exception(E.Message);
            //        }
            //    }
            //}
        } 

        /// <summary>    
        /// 执行SQL语句，返回影响的记录数    
        /// </summary>    
        /// <param name="SQLString">SQL语句</param>    
        /// <returns>影响的记录数</returns>    
        public static int ExecuteSql(string SQLString, params OleDbParameter[] cmdParms)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.OleDb.OleDbException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;    
            if (cmdParms != null)
            {


                foreach (OleDbParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }   




    }
}
