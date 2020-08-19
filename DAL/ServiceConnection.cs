using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class ServiceConnection
    {

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from ServiceConnection where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        /// <summary>
        /// 是否存在该服务端名称
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(string ServiceName)
        {
            string strSql = "select count(*) from ServiceConnection where ServiceName='" + ServiceName+"'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        public static bool Add(Model.ServiceConnection model)
        {
            string strSql = "insert into ServiceConnection( ServiceName,ServiceIP,ServicePort,SourceTable) values( @ServiceName, @ServiceIP,@ServicePort,@SourceTable)";
            SqlParameter ServiceName = new SqlParameter("ServiceName", SqlDbType.NVarChar); ServiceName.Value = model.ServiceName;
            SqlParameter ServiceIP = new SqlParameter("ServiceIP", SqlDbType.NVarChar); ServiceIP.Value = model.ServiceIP;
            SqlParameter ServicePort = new SqlParameter("ServicePort", SqlDbType.NVarChar); ServicePort.Value = model.ServicePort;
            SqlParameter SourceTable = new SqlParameter("SourceTable", SqlDbType.NVarChar); SourceTable.Value = model.SourceTable;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { ServiceName, ServiceIP, ServicePort, SourceTable }, connectionString) == 1 ? true : false;

        }

        public static bool Update(Model.ServiceConnection model)
        {
            string strSql = "update ServiceConnection set ServiceName=@ServiceName,ServiceIP=@ServiceIP,ServicePort=@ServicePort,SourceTable=@SourceTable where ID = " + model.ID.ToString();
            SqlParameter ServiceName = new SqlParameter("ServiceName", SqlDbType.NVarChar); ServiceName.Value = model.ServiceName;
            SqlParameter ServiceIP = new SqlParameter("ServiceIP", SqlDbType.NVarChar); ServiceIP.Value = model.ServiceIP;
            SqlParameter ServicePort = new SqlParameter("ServicePort", SqlDbType.NVarChar); ServicePort.Value = model.ServicePort;
            SqlParameter SourceTable = new SqlParameter("SourceTable", SqlDbType.NVarChar); SourceTable.Value = model.SourceTable;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { ServiceName, ServiceIP, ServicePort, SourceTable }, connectionString) == 1 ? true : false;

        }

        public static Model.ServiceConnection GetModel(string ServiceName)
        {
            string strSql = "select * from ServiceConnection where ServiceName = '" + ServiceName + "'";
            Model.ServiceConnection model = new Model.ServiceConnection();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ServiceName = ServiceName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.ServiceIP = Convert.ToString(ds.Tables[0].Rows[0]["ServiceIP"]);
                model.ServicePort = Convert.ToString(ds.Tables[0].Rows[0]["ServicePort"]);
                model.SourceTable = Convert.ToString(ds.Tables[0].Rows[0]["SourceTable"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        public static Model.ServiceConnection GetModel(int ID)
        {
            string strSql = "select * from ServiceConnection where ID = '" + ID.ToString() + "'";
            Model.ServiceConnection model = new Model.ServiceConnection();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ServiceName = Convert.ToString(ds.Tables[0].Rows[0]["ServiceName"]);
                model.ServiceIP = Convert.ToString(ds.Tables[0].Rows[0]["ServiceIP"]);
                model.ServicePort = Convert.ToString(ds.Tables[0].Rows[0]["ServicePort"]);
                model.SourceTable = Convert.ToString(ds.Tables[0].Rows[0]["SourceTable"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        public static bool Delete(string ServiceName)
        {
            string strSql = "delete from ServiceConnection where ServiceName ='" + ServiceName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static bool Delete(int ID)
        {
            string strSql = "delete from ServiceConnection where ID ='" + ID.ToString() + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from ServiceConnection where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
        public static DataSet GetList()
        {
            string strSql = "select * from ServiceConnection";
           
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static DataSet GetBriefList(int offset, int limit)
        {
            int endRecord = offset + limit;
            string sql = "SELECT w1.ID,w1.ServiceName,w1.ServiceIP,w1.ServicePort,w1.SourceTable FROM ServiceConnection w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + " ID,ServiceName,ServiceIP,ServicePort,SourceTable FROM ServiceConnection ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        public static int GetRecordCount()
        {
            string strSql = "select count(*) from ServiceConnection";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
    }
}
