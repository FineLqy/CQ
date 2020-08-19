using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class SourceMap
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from SourceMap where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        public static bool Exists(string Source, int PrecedenceLevel)
        {
            string strSql = "select count(*) from SourceMap where Source='" + Source + "' and PrecedenceLevel='" + PrecedenceLevel.ToString() + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        /// <summary>
        /// 是否存在该
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(string Source, string ServiceName, string MapSource)
        {
            string strSql = "select count(*) from SourceMap where Source='" + Source + "' and ServiceName='" + ServiceName + "' and MapSource='" + MapSource + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }


        public static bool Add(Model.SourceMap model)
        {
            string strSql = "insert into SourceMap( Source,SourceType,ServiceName,ServiceIP,ServicePort,MapSource,PrecedenceLevel,AllowMaxNum) values( @Source,@SourceType,@ServiceName,@ServiceIP,@ServicePort,@MapSource,@PrecedenceLevel,@AllowMaxNum)";
            SqlParameter Source = new SqlParameter("Source", SqlDbType.VarChar); Source.Value = model.Source;
            SqlParameter SourceType = new SqlParameter("SourceType", SqlDbType.NVarChar); SourceType.Value = model.SourceType;
            SqlParameter ServiceName = new SqlParameter("ServiceName", SqlDbType.NVarChar); ServiceName.Value = model.ServiceName;
            SqlParameter ServiceIP = new SqlParameter("ServiceIP", SqlDbType.NVarChar); ServiceIP.Value = model.ServiceIP;
            SqlParameter ServicePort = new SqlParameter("ServicePort", SqlDbType.NVarChar); ServicePort.Value = model.ServicePort;
            SqlParameter MapSource = new SqlParameter("MapSource", SqlDbType.NVarChar); MapSource.Value = model.MapSource;
            SqlParameter PrecedenceLevel = new SqlParameter("PrecedenceLevel", SqlDbType.Int); PrecedenceLevel.Value = model.PrecedenceLevel;
            SqlParameter AllowMaxNum = new SqlParameter("AllowMaxNum", SqlDbType.Int); AllowMaxNum.Value = model.AllowMaxNum;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { Source, SourceType, ServiceName, ServiceIP, ServicePort, MapSource, PrecedenceLevel, AllowMaxNum }, connectionString) == 1 ? true : false;

        }

        public static bool Update(Model.SourceMap model)
        {
            string strSql = "update SourceMap set Source=@Source,SourceType=@SourceType,ServiceName=@ServiceName,ServiceIP=@ServiceIP,ServicePort=@ServicePort,MapSource=@MapSource,PrecedenceLevel=@PrecedenceLevel,AllowMaxNum=@AllowMaxNum where ID = " + model.ID.ToString();
            SqlParameter Source = new SqlParameter("Source", SqlDbType.VarChar); Source.Value = model.Source;
            SqlParameter SourceType = new SqlParameter("SourceType", SqlDbType.NVarChar); SourceType.Value = model.SourceType;
            SqlParameter ServiceName = new SqlParameter("ServiceName", SqlDbType.NVarChar); ServiceName.Value = model.ServiceName;
            SqlParameter ServiceIP = new SqlParameter("ServiceIP", SqlDbType.NVarChar); ServiceIP.Value = model.ServiceIP;
            SqlParameter ServicePort = new SqlParameter("ServicePort", SqlDbType.NVarChar); ServicePort.Value = model.ServicePort;
            SqlParameter MapSource = new SqlParameter("MapSource", SqlDbType.NVarChar); MapSource.Value = model.MapSource;
            SqlParameter PrecedenceLevel = new SqlParameter("PrecedenceLevel", SqlDbType.Int); PrecedenceLevel.Value = model.PrecedenceLevel;
            SqlParameter AllowMaxNum = new SqlParameter("AllowMaxNum", SqlDbType.Int); AllowMaxNum.Value = model.AllowMaxNum;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { Source, SourceType, ServiceName, ServiceIP, ServicePort, MapSource, PrecedenceLevel, AllowMaxNum }, connectionString) == 1 ? true : false;

        }

        public static Model.SourceMap GetModel(int ID)
        {
            string strSql = "select * from SourceMap where ID = '" + ID.ToString() + "'";
            Model.SourceMap model = new Model.SourceMap();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Source = Convert.ToString(ds.Tables[0].Rows[0]["Source"]);
                model.SourceType = Convert.ToString(ds.Tables[0].Rows[0]["SourceType"]);
                model.ServiceName = Convert.ToString(ds.Tables[0].Rows[0]["ServiceName"]);
                model.ServiceIP = Convert.ToString(ds.Tables[0].Rows[0]["ServiceIP"]);
                model.ServicePort = Convert.ToString(ds.Tables[0].Rows[0]["ServicePort"]);
                model.MapSource = Convert.ToString(ds.Tables[0].Rows[0]["MapSource"]);
                model.PrecedenceLevel = Convert.ToInt32(ds.Tables[0].Rows[0]["PrecedenceLevel"]);
                if (ds.Tables[0].Rows[0]["AllowMaxNum"].ToString().Trim() == "")
                {
                    model.AllowMaxNum = 0;
                }
                else
                {
                    model.AllowMaxNum = Convert.ToInt32(ds.Tables[0].Rows[0]["AllowMaxNum"]);
                }
                return model;
            }
            else
            {
                return null;
            }

        }

        public static bool Delete(int ID)
        {
            string strSql = "delete from SourceMap where ID ='" + ID.ToString() + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from SourceMap where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
        public static DataSet GetList()
        {
            string strSql = "select * from SourceMap";
       
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }


    }
}
