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
    public class SoftWare
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from SoftWare where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        /// <summary>
        /// 设备类型
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string SoftWareType)
        {
            string strSql = "select count(*) from SoftWare where SoftWareType='" + SoftWareType + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
      
        /// <summary>
        /// 增加一个设备
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.SoftWare model)
        {
            string strSql = "insert into SoftWare(SoftWareName,SoftWareType, Type, Config, Maintenance,Num,IP,Time,IsShow) values(@SoftWareName,@SoftWareType, @Type, @Config, @Maintenance,@Num,@IP,@Time,@IsShow)";
            SqlParameter SoftWareType = new SqlParameter("SoftWareType", SqlDbType.NVarChar); SoftWareType.Value = model.SoftWareType;
            SqlParameter Type = new SqlParameter("Type", SqlDbType.NVarChar); Type.Value = model.Type;
            SqlParameter Config = new SqlParameter("Config", SqlDbType.NVarChar); Config.Value = model.Config;
            SqlParameter Maintenance = new SqlParameter("Maintenance", SqlDbType.NVarChar); Maintenance.Value = model.Maintenance;
            SqlParameter SoftWareName = new SqlParameter("SoftWareName", SqlDbType.NVarChar); SoftWareName.Value = model.SoftWareName;
            SqlParameter Num = new SqlParameter("Num", SqlDbType.NVarChar); Num.Value = model.Num;
            SqlParameter IP = new SqlParameter("IP", SqlDbType.NVarChar); IP.Value = model.IP;
            SqlParameter Time = new SqlParameter("Time", SqlDbType.DateTime); Time.Value = model.Time;
             SqlParameter IsShow = new SqlParameter("IsShow", SqlDbType.NVarChar); IsShow.Value = model.IsShow;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { SoftWareName, SoftWareType, Type, Config, Maintenance, Num, IP, Time,IsShow}, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.SoftWare model)
        {
            string strSql = "update SoftWare set IsShow=@IsShow, SoftWareName=@SoftWareName, SoftWareType=@SoftWareType, Type=@Type, Config=@Config, Maintenance=@Maintenance, Num=@Num, IP=@IP, Time=@Time   where ID = " + model.ID.ToString();
            SqlParameter SoftWareType = new SqlParameter("SoftWareType", SqlDbType.NVarChar); SoftWareType.Value = model.SoftWareType;
            SqlParameter Type = new SqlParameter("Type", SqlDbType.NVarChar); Type.Value = model.Type;
            SqlParameter Config = new SqlParameter("Config", SqlDbType.NVarChar); Config.Value = model.Config;
            SqlParameter Maintenance = new SqlParameter("Maintenance", SqlDbType.NVarChar); Maintenance.Value = model.Maintenance;
            SqlParameter SoftWareName = new SqlParameter("SoftWareName", SqlDbType.NVarChar); SoftWareName.Value = model.SoftWareName;
            SqlParameter Num = new SqlParameter("Num", SqlDbType.NVarChar); Num.Value = model.Num;
            SqlParameter IP = new SqlParameter("IP", SqlDbType.NVarChar); IP.Value = model.IP;
            SqlParameter Time = new SqlParameter("Time", SqlDbType.DateTime); Time.Value = model.Time;
            SqlParameter IsShow = new SqlParameter("IsShow", SqlDbType.NVarChar); IsShow.Value = model.IsShow;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { SoftWareName, SoftWareType, Type, Config, Maintenance, Num, IP, Time, IsShow }, connectionString) == 1 ? true : false;
        }


        public static Model.SoftWare GetModel(int ID)
        {
            string strSql = "select * from SoftWare where ID = '" + ID + "'";
            Model.SoftWare model = new Model.SoftWare();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.SoftWareName = Convert.ToString(ds.Tables[0].Rows[0]["SoftWareName"]);
                model.SoftWareType = Convert.ToString(ds.Tables[0].Rows[0]["SoftWareType"]);
                model.Type = Convert.ToString(ds.Tables[0].Rows[0]["Type"]);
                model.Config = Convert.ToString(ds.Tables[0].Rows[0]["Config"]);
                model.Maintenance = Convert.ToString(ds.Tables[0].Rows[0]["Maintenance"]);
                model.Num = Convert.ToString(ds.Tables[0].Rows[0]["Num"]);
                model.IP = Convert.ToString(ds.Tables[0].Rows[0]["IP"]);
                model.IsShow = Convert.ToString(ds.Tables[0].Rows[0]["IsShow"]);
                model.Time = Convert.ToDateTime(ds.Tables[0].Rows[0]["Time"]);
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 删除一条数据（根据SerialNumber）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Delete(int ID)
        {
            string strSql = "delete from SoftWare where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from SoftWare where IsShow ='1' and ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
        public static DataSet GetBriefList(int offset, int limit, string SoftWareName = "")
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM SoftWare w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM SoftWare where IsShow ='1' and SoftWareName like '%" + SoftWareName + "%' ORDER BY ID DESC) w ORDER BY w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID DESC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        public static int GetRecordCount(string SoftWareName = "")
        {
            string strSql = "select count(*) from SoftWare where IsShow ='1' and SoftWareName like '%" + SoftWareName + "%'";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
    }
}
