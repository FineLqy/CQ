using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace DAL
{
    public class StationNetInfo
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from StationNetInfo where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        /// <summary>
        /// 站网名称
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string NetName)
        {
            string strSql = "select count(*) from StationNetInfo where NetName='" + NetName + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个战网
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.StationNetInfo model)
        {

            string strSql = "insert into StationNetInfo(NetName,BuildTime,Number,DistributionDiagram,IP,Port,SourceNode,NetworkProtocol,ServiceContent,DataFormat,SatelliteSystem) values(@NetName,@BuildTime,@Number,@DistributionDiagram,@IP,@Port,@SourceNode,@NetworkProtocol,@ServiceContent,@DataFormat,@SatelliteSystem)";
            SqlParameter NetName = new SqlParameter("NetName", SqlDbType.NVarChar); NetName.Value = model.NetName;
            SqlParameter BuildTime = new SqlParameter("BuildTime", SqlDbType.DateTime); BuildTime.Value = model.BuildTime;
            SqlParameter Number = new SqlParameter("Number", SqlDbType.NVarChar); Number.Value = model.Number;
            SqlParameter DistributionDiagram = new SqlParameter("DistributionDiagram", SqlDbType.NVarChar); DistributionDiagram.Value = model.DistributionDiagram;
            SqlParameter IP = new SqlParameter("IP", SqlDbType.NVarChar); IP.Value = model.IP;
            SqlParameter Port = new SqlParameter("Port", SqlDbType.NVarChar); Port.Value = model.Port;
            SqlParameter SourceNode = new SqlParameter("SourceNode", SqlDbType.NVarChar); SourceNode.Value = model.SourceNode;
            SqlParameter NetworkProtocol = new SqlParameter("NetworkProtocol", SqlDbType.NVarChar); NetworkProtocol.Value = model.NetworkProtocol;
            SqlParameter ServiceContent = new SqlParameter("ServiceContent", SqlDbType.NVarChar); ServiceContent.Value = model.ServiceContent;
            SqlParameter DataFormat = new SqlParameter("DataFormat", SqlDbType.NVarChar); DataFormat.Value = model.DataFormat;
            SqlParameter SatelliteSystem = new SqlParameter("SatelliteSystem", SqlDbType.NVarChar); SatelliteSystem.Value = model.SatelliteSystem;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { NetName, BuildTime, Number, DistributionDiagram, IP, Port, SourceNode, NetworkProtocol, ServiceContent, DataFormat, SatelliteSystem }, connectionString) == 1 ? true : false;
        }
        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.StationNetInfo model)
        {
            string strSql = "update StationNetInfo set NetName=@NetName, BuildTime=@BuildTime, Number=@Number, DistributionDiagram=@DistributionDiagram, IP=@IP, Port=@Port, SourceNode=@SourceNode, NetworkProtocol=@NetworkProtocol, ServiceContent=@ServiceContent, DataFormat=@DataFormat, SatelliteSystem=@SatelliteSystem where ID = " + model.ID.ToString();
            SqlParameter NetName = new SqlParameter("NetName", SqlDbType.NVarChar); NetName.Value = model.NetName;
            SqlParameter BuildTime = new SqlParameter("BuildTime", SqlDbType.DateTime); BuildTime.Value = model.BuildTime;
            SqlParameter Number = new SqlParameter("Number", SqlDbType.NVarChar); Number.Value = model.Number;
            SqlParameter DistributionDiagram = new SqlParameter("DistributionDiagram", SqlDbType.NVarChar); DistributionDiagram.Value = model.DistributionDiagram;
            SqlParameter IP = new SqlParameter("IP", SqlDbType.NVarChar); IP.Value = model.IP;
            SqlParameter Port = new SqlParameter("Port", SqlDbType.NVarChar); Port.Value = model.Port;
            SqlParameter SourceNode = new SqlParameter("SourceNode", SqlDbType.NVarChar); SourceNode.Value = model.SourceNode;
            SqlParameter NetworkProtocol = new SqlParameter("NetworkProtocol", SqlDbType.NVarChar); NetworkProtocol.Value = model.NetworkProtocol;
            SqlParameter ServiceContent = new SqlParameter("ServiceContent", SqlDbType.NVarChar); ServiceContent.Value = model.ServiceContent;
            SqlParameter DataFormat = new SqlParameter("DataFormat", SqlDbType.NVarChar); DataFormat.Value = model.DataFormat;
            SqlParameter SatelliteSystem = new SqlParameter("SatelliteSystem", SqlDbType.NVarChar); SatelliteSystem.Value = model.SatelliteSystem;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { NetName, BuildTime, Number, DistributionDiagram, IP, Port, SourceNode, NetworkProtocol, ServiceContent, DataFormat, SatelliteSystem }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象根据站网名
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.StationNetInfo GetModel(string NetName)
        {
            string strSql = "select * from StationNetInfo where NetName = '" + NetName + "'";
            Model.StationNetInfo model = new Model.StationNetInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.NetName = NetName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.IP = Convert.ToString(ds.Tables[0].Rows[0]["IP"]);
                model.Port = Convert.ToString(ds.Tables[0].Rows[0]["Port"]);
                model.BuildTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["BuildTime"]);
                model.Number = Convert.ToString(ds.Tables[0].Rows[0]["Number"]);
                model.DistributionDiagram = Convert.ToString(ds.Tables[0].Rows[0]["DistributionDiagram"]);
                model.SourceNode = Convert.ToString(ds.Tables[0].Rows[0]["SourceNode"]);
                model.NetworkProtocol = Convert.ToString(ds.Tables[0].Rows[0]["NetworkProtocol"]);
                model.ServiceContent = Convert.ToString(ds.Tables[0].Rows[0]["ServiceContent"]);
                model.DataFormat = Convert.ToString(ds.Tables[0].Rows[0]["DataFormat"]);
                model.SatelliteSystem = Convert.ToString(ds.Tables[0].Rows[0]["SatelliteSystem"]);
               


                return model;
            }
            else
            {
                return null;
            }
        }
        public static Model.StationNetInfo GetModel(int ID)
        {
            string strSql = "select * from StationNetInfo where ID = '" + ID + "'";
            Model.StationNetInfo model = new Model.StationNetInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.NetName = Convert.ToString(ds.Tables[0].Rows[0]["NetName"]);
                model.IP = Convert.ToString(ds.Tables[0].Rows[0]["IP"]);
                model.Port = Convert.ToString(ds.Tables[0].Rows[0]["Port"]);
                model.BuildTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["BuildTime"]);
                model.Number = Convert.ToString(ds.Tables[0].Rows[0]["Number"]);
                model.DistributionDiagram = Convert.ToString(ds.Tables[0].Rows[0]["DistributionDiagram"]);
                model.SourceNode = Convert.ToString(ds.Tables[0].Rows[0]["SourceNode"]);
                model.NetworkProtocol = Convert.ToString(ds.Tables[0].Rows[0]["NetworkProtocol"]);
                model.ServiceContent = Convert.ToString(ds.Tables[0].Rows[0]["ServiceContent"]);
                model.DataFormat = Convert.ToString(ds.Tables[0].Rows[0]["DataFormat"]);
                model.SatelliteSystem = Convert.ToString(ds.Tables[0].Rows[0]["SatelliteSystem"]);


                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除一条数据（根据MachineName）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Delete(string NetName)
        {
            string strSql = "delete from StationNetInfo where NetName ='" + NetName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int id)
        {
            string strSql = "delete from StationNetInfo where ID ='" + id + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from StationNetInfo where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
        public static DataSet GetBriefList(int offset, int limit, string NetName = "")
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM StationNetInfo w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM StationNetInfo where NetName like '%" + NetName + "%' ORDER BY ID DESC) w ORDER BY w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID DESC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        public static int GetRecordCount(string NetName = "")
        {
            string strSql = "select count(*) from StationNetInfo where NetName like '%" + NetName + "%'";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
    }
}
