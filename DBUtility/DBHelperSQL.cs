#region Header Comments
/*****************************************************************************/
/* DBHelperSQL.cs                                                            */
/* -------------                                                             */
/* 2010/11/24 -许超钤                                                        */
/*                                                                           */
/* Comments and Notes                                                        */
/* ------------------                                                        */
/*****************************************************************************/
#endregion Header Comments

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
namespace DBUtility
{
    public class DBHelperSQL
    {

        #region **************** 变量、属性、构造函数 ******************

        /// <summary>
        /// 连接字符串变量
        /// </summary>
        private static string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        /// <summary>
        /// DBHelperSQL构造函数
        /// </summary>
        public DBHelperSQL()
        { }

        public DBHelperSQL(string DataBaseName,string UserName,string PassWord)
        { }

        /// <summary>
        /// 连接字符串属性
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        #endregion

        #region ******************* 直接执行SQL语句 ********************

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果(object)
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果(object)</returns>
        public static object GetResult(string SQLString)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, conn);
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    conn.Close();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, DBNull.Value)))
                        return "";
                    else
                        return obj;
                }
                catch (SqlException E)
                {
                    conn.Close();
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int GetNums(string SQLString)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, conn);
                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rows;
                }
                catch (SqlException E)
                {
                    conn.Close();
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>返回SqlDataReader对象</returns>
        public static SqlDataReader GetReader(string SQLString)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(SQLString, conn);
            try
            {
                conn.Open();
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (myReader == null)
                {
                    conn.Close();
                    return null;
                }
                else
                {
                    if (myReader.HasRows == false)
                    {
                        myReader.Close();
                        conn.Close();
                        return null;
                    }
                    return myReader;
                }
            }
            catch (SqlException E)
            {
                throw new Exception(E.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(string SQLString)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter myAdatpter = new SqlDataAdapter(SQLString, conn);
                try
                {
                    conn.Open();
                    myAdatpter.Fill(ds, "ds");
                    conn.Close();
                    return ds;
                }
                catch (SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    myAdatpter.Dispose();
                    conn.Close();
                }
            }
        }

        #endregion

        #region ******************* 执行参数SQL语句 ********************

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果(object)
        /// </summary>
        /// <param name="SQLString">计算查询结果SQL语句</param>
        /// <param name="sqlparam">sql参数</param>
        /// <returns>查询结果(object)</returns>
        public static object GetResult(string SQLString,SqlParameter sqlparam)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, conn);
                try
                {
                    cmd.Parameters.Clear();
                    if (sqlparam != null)
                        cmd.Parameters.Add(sqlparam);
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    conn.Close();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, DBNull.Value)))
                        return "";
                    else
                        return obj;
                }
                catch (SqlException E)
                {
                    conn.Close();
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果(object)
        /// </summary>
        /// <param name="SQLString">计算查询结果SQL语句</param>
        /// <param name="sqlparam">sql参数数组</param>
        /// <returns>查询结果(object)</returns>
        public static object GetResult(string SQLString, SqlParameter[] sqlparams)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, conn);
                try
                {
                    cmd.Parameters.Clear();
                    if (sqlparams != null)
                    {
                        foreach (SqlParameter parm in sqlparams)
                            cmd.Parameters.Add(parm);
                    }
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    conn.Close();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, DBNull.Value)))
                        return "";
                    else
                        return obj;
                }
                catch (SqlException E)
                {
                    conn.Close();
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="sqlparam">sql参数</param>
        /// <returns>影响的记录数</returns>
        public static int GetNums(string SQLString,SqlParameter sqlparam)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, conn);
                try
                {
                    cmd.Parameters.Clear();
                    if (sqlparam != null)
                        cmd.Parameters.Add(sqlparam);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rows;
                }
                catch (SqlException E)
                {
                    conn.Close();
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="sqlparam">sql参数数组</param>
        /// <returns>影响的记录数</returns>
        public static int GetNums(string SQLString, SqlParameter[] sqlparams)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, conn);
                try
                {
                    cmd.Parameters.Clear();
                    if (sqlparams != null)
                    {
                        foreach (SqlParameter parm in sqlparams)
                            cmd.Parameters.Add(parm);
                    }
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rows;
                }
                catch (SqlException E)
                {
                    conn.Close();
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <param name="sqlparam">sql参数</param>
        /// <returns>返回SqlDataReader对象</returns>
        public static SqlDataReader GetReader(string SQLString,SqlParameter sqlparam)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(SQLString, conn);
            try
            {
                cmd.Parameters.Clear();
                if (sqlparam != null)
                    cmd.Parameters.Add(sqlparam);
                conn.Open();
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (myReader == null)
                {
                    conn.Close();
                    return null;
                }
                else
                {
                    if (myReader.HasRows == false)
                    {
                        myReader.Close();
                        conn.Close();
                        return null;
                    }
                    return myReader;
                }
            }
            catch (SqlException E)
            {
                throw new Exception(E.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <param name="sqlparam">sql参数数组</param>
        /// <returns>返回SqlDataReader对象</returns>
        public static SqlDataReader GetReader(string SQLString, SqlParameter[] sqlparams)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(SQLString, conn);
            try
            {
                cmd.Parameters.Clear();
                if (sqlparams != null)
                {
                    foreach (SqlParameter parm in sqlparams)
                        cmd.Parameters.Add(parm);
                }
                conn.Open();
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (myReader == null)
                {
                    conn.Close();
                    return null;
                }
                else
                {
                    if (myReader.HasRows == false)
                    {
                        myReader.Close();
                        conn.Close();
                        return null;
                    }
                    return myReader;
                }
            }
            catch (SqlException E)
            {
                throw new Exception(E.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <param name="SQLString">sql参数</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(string SQLString,SqlParameter sqlparam)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(SQLString,conn);
                cmd.Parameters.Clear();
                if (sqlparam != null)
                    cmd.Parameters.Add(sqlparam);
                SqlDataAdapter myAdatpter = new SqlDataAdapter(cmd);
                try
                {
                    conn.Open();
                    myAdatpter.Fill(ds, "ds");
                    conn.Close();
                    return ds;
                }
                catch (SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    myAdatpter.Dispose();
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <param name="SQLString">sql参数数组</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(string SQLString, SqlParameter[] sqlparams)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(SQLString, conn);
                cmd.Parameters.Clear();
                if (sqlparams != null)
                {
                    foreach (SqlParameter parm in sqlparams)
                        cmd.Parameters.Add(parm);
                }
                SqlDataAdapter myAdatpter = new SqlDataAdapter(cmd);
                try
                {
                    conn.Open();
                    myAdatpter.Fill(ds, "ds");
                    conn.Close();
                    return ds;
                }
                catch (SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    myAdatpter.Dispose();
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static void ExecuteSqlTran(ArrayList SQLStringList)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlTransaction tx = conn.BeginTransaction();
            cmd.Transaction = tx;
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                for (int n = 0; n < SQLStringList.Count; n++)
                {
                    string strsql = SQLStringList[n].ToString();
                    if (strsql.Trim().Length > 1)
                    {
                        cmd.CommandText = strsql;
                        cmd.ExecuteNonQuery();
                    }
                }
                tx.Commit();
            }
            catch (SqlException E)
            {
                tx.Rollback();
                throw new Exception(E.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }
        #endregion

        #region******************* 额外增加功能 ********************
        /// <summary>
        /// 执行一条计算查询结果语句，提供连接字符串，返回查询结果(object)
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果(object)</returns>
        public static object GetResult(string SQLString, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, conn);
                try
                {
                    conn.Open();
                    object obj = cmd.ExecuteScalar();
                    conn.Close();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, DBNull.Value)))
                        return "";
                    else
                        return obj;
                }
                catch (SqlException E)
                {
                    conn.Close();
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，提供连接字符串，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="sqlparam">sql参数数组</param>
        /// <returns>影响的记录数</returns>
        public static int GetNums(string SQLString, SqlParameter[] sqlparams, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, conn);
                try
                {
                    cmd.Parameters.Clear();
                    if (sqlparams != null)
                    {
                        foreach (SqlParameter parm in sqlparams)
                            cmd.Parameters.Add(parm);
                    }
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rows;
                }
                catch (SqlException E)
                {
                    conn.Close();
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
        /// <summary>
        /// 执行查询语句，提供连接字符串，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(string SQLString, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter myAdatpter = new SqlDataAdapter(SQLString, conn);
                try
                {
                    conn.Open();
                    myAdatpter.Fill(ds, "ds");
                    conn.Close();
                    return ds;
                }
                catch (SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    myAdatpter.Dispose();
                    conn.Close();
                }
            }
        }
        /// <summary>
        /// 执行SQL语句，提供连接字符串，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int GetNums(string SQLString, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, conn);
                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    return rows;
                }
                catch (SqlException E)
                {
                    conn.Close();
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        #endregion

    }
}

