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
    /// 数据库访问类WorkingArea
    /// </summary>
    public class WorkingArea 
    {
        #region IWorkingArea 成员
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from WorkingArea where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public static bool Exists(string AreaName)
        {
            string strSql = "select count(*) from WorkingArea where AreaName='" + AreaName.ToString() + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        public static bool Add(Model.WorkingArea model)
        {
            string strSql = "insert into WorkingArea(AreaName, AreaString) values(@AreaName, @AreaString)";
            SqlParameter AreaName = new SqlParameter("AreaName", SqlDbType.NVarChar); AreaName.Value = model.AreaName;
            SqlParameter AreaString = new SqlParameter("AreaString", SqlDbType.VarChar); AreaString.Value = model.AreaString;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { AreaName, AreaString }, connectionString) == 1 ? true : false;
        }

        public static bool Update(Model.WorkingArea model)
        {
            string strSql = "update WorkingArea set AreaName=@AreaName, AreaString=@AreaString where ID = " + model.ID.ToString();
            SqlParameter AreaName = new SqlParameter("AreaName", SqlDbType.NVarChar); AreaName.Value = model.AreaName;
            SqlParameter AreaString = new SqlParameter("AreaString", SqlDbType.VarChar); AreaString.Value = model.AreaString;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { AreaName, AreaString }, connectionString) == 1 ? true : false;
        }

        public static bool Delete(int ID)
        {
            string strSql = "delete from WorkingArea where ID = " + ID;
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static  Model.WorkingArea GetModel(string AreaName)
        {
            string strSql = "select * from WorkingArea where AreaName = '" + AreaName+"'";
            Model.WorkingArea model = new Model.WorkingArea();
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

        public static Model.WorkingArea GetModel(int ID)
        {
            string strSql = "select * from WorkingArea where ID = " + ID.ToString();
            Model.WorkingArea model = new Model.WorkingArea();
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
            string strSql = "select * from WorkingArea where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        #endregion
    }
}
