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
    public class StationEquip
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from StationEquip where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        /// <summary>
        /// 设备名
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string MachineName)
        {
            string strSql = "select count(*) from StationEquip where MachineName='" + MachineName + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个设备
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.StationEquip model)
        {
            string strSql = "insert into StationEquip(MachineName,Models,InstallationDate,SerialNumber) values(@MachineName,@Models,@InstallationDate,@SerialNumber)";
            SqlParameter Models = new SqlParameter("Models", SqlDbType.NVarChar); Models.Value = model.Models;
            SqlParameter MachineName = new SqlParameter("MachineName", SqlDbType.NVarChar); MachineName.Value = model.MachineName;
            SqlParameter InstallationDate = new SqlParameter("InstallationDate", SqlDbType.DateTime); InstallationDate.Value = model.InstallationDate;
            SqlParameter SerialNumber = new SqlParameter("SerialNumber", SqlDbType.NVarChar); SerialNumber.Value = model.SerialNumber;
         
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { MachineName, Models, InstallationDate, SerialNumber }, connectionString) == 1 ? true : false;
        }
        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.StationEquip model)
        {
            string strSql = "update StationEquip set MachineName=@MachineName, Models=@Models, InstallationDate=@InstallationDate, SerialNumber=@SerialNumber where ID = " + model.ID.ToString();
            SqlParameter Models = new SqlParameter("Models", SqlDbType.NVarChar); Models.Value = model.Models;
            SqlParameter MachineName = new SqlParameter("MachineName", SqlDbType.NVarChar); MachineName.Value = model.MachineName;
            SqlParameter InstallationDate = new SqlParameter("InstallationDate", SqlDbType.DateTime); InstallationDate.Value = model.InstallationDate;
            SqlParameter SerialNumber = new SqlParameter("SerialNumber", SqlDbType.NVarChar); SerialNumber.Value = model.SerialNumber;

            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { MachineName, Models, InstallationDate, SerialNumber }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象根据设备名
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.StationEquip GetModel(string MachineName)
        {
            string strSql = "select * from StationEquip where MachineName = '" + MachineName + "'";
            Model.StationEquip model = new Model.StationEquip();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.MachineName = MachineName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                //model.MachineName = Convert.ToString(ds.Tables[0].Rows[0]["MachineName"]);
                model.SerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["SerialNumber"]);
                model.InstallationDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["InstallationDate"]);
                model.Models = Convert.ToString(ds.Tables[0].Rows[0]["Models"]);
              
                return model;
            }
            else
            {
                return null;
            }
        }
        public static Model.StationEquip GetModel(int ID)
        {
            string strSql = "select * from StationEquip where ID = '" + ID + "'";
            Model.StationEquip model = new Model.StationEquip();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                //model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.MachineName = Convert.ToString(ds.Tables[0].Rows[0]["MachineName"]);
                model.SerialNumber = Convert.ToString(ds.Tables[0].Rows[0]["SerialNumber"]);
                model.InstallationDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["InstallationDate"]);
                model.Models = Convert.ToString(ds.Tables[0].Rows[0]["Models"]);
              


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
        public static bool Delete(string MachineName)
        {
            string strSql = "delete from StationEquip where MachineName ='" + MachineName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int id)
        {
            string strSql = "delete from StationEquip where ID ='" + id + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from StationEquip where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
        //public static DataSet GetBriefList(int offset, int limit, string MachineName = "")
        //{
        //    int endRecord = offset + limit;
        //    string sql = "SELECT * FROM InternetInfoEquip w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM InternetInfoEquip where MachineName like '%" + MachineName + "%' ORDER BY ID DESC) w ORDER BY w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID DESC";
        //    return DBHelperSQL.GetDataSet(sql, connectionString);
        //}
        //public static int GetRecordCount(string MachineName = "")
        //{
        //    string strSql = "select count(*) from InternetInfoEquip where MachineName like '%" + MachineName + "%'";
        //    return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        //}



        public static DataSet GetBriefList(int offset, int limit, string where = "1=1")
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM StationEquip w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM StationEquip where " + where + " ORDER BY ID DESC) w ORDER BY w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID DESC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        public static int GetRecordCount(string where = "1=1")
        {
            string strSql = "select count(*) from StationEquip where " + where;
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
    }
}
