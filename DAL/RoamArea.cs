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
    /// 数据库访问类RoamArea
    /// </summary>
    public class RoamArea
    {
        #region IRoamArea 成员
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from RoamArea where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(string AreaName)
        {
            string strSql = "select count(*) from RoamArea where AreaName='" + AreaName.ToString() + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        public static bool Add(Model.RoamArea model)
        {
            string strSql = "insert into RoamArea(AreaName, AreaString) values(@AreaName, @AreaString)";
            SqlParameter AreaName = new SqlParameter("AreaName", SqlDbType.NVarChar); AreaName.Value = model.AreaName;
            SqlParameter AreaString = new SqlParameter("AreaString", SqlDbType.VarChar); AreaString.Value = model.AreaString;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { AreaName, AreaString }, connectionString) == 1 ? true : false;
        }

        public static bool Update(Model.RoamArea model)
        {
            string strSql = "update RoamArea set AreaName=@AreaName, AreaString=@AreaString where ID = " + model.ID.ToString();
            SqlParameter AreaName = new SqlParameter("AreaName", SqlDbType.NVarChar); AreaName.Value = model.AreaName;
            SqlParameter AreaString = new SqlParameter("AreaString", SqlDbType.VarChar); AreaString.Value = model.AreaString;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { AreaName, AreaString }, connectionString) == 1 ? true : false;
        }

        public static bool Delete(int ID)
        {
            string strSql = "delete from RoamArea where ID = " + ID;
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(string AreaName)
        {
            string strSql = "delete from RoamingAreaManagement where AreaName ='" + AreaName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static  Model.RoamArea GetModel(string AreaName)
        {
            string strSql = "select * from RoamArea where AreaName = '" + AreaName+"'";
            Model.RoamArea model = new Model.RoamArea();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.AreaName = AreaName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.AreaString = Convert.ToString(ds.Tables[0].Rows[0]["AreaString"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        public static Model.RoamArea GetModel(int ID)
        {
            string strSql = "select * from RoamArea where ID = " + ID.ToString();
            Model.RoamArea model = new Model.RoamArea();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.AreaName = Convert.ToString(ds.Tables[0].Rows[0]["AreaName"]);
                model.AreaString = Convert.ToString(ds.Tables[0].Rows[0]["AreaString"]);
                return model;
            }
            else
            {
                return null;
            }
        }
        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from RoamArea where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        #endregion
    }
}
