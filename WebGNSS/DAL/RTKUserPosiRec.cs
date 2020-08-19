using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class RTKUserPosiRec
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        public static bool Delete(string UserName)
        {
            string strSql = "delete from RTKUserPosiRec where UserName ='" + UserName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Add(Model.RTKUserPosiRec model)
        {
            string strSql = "insert into RTKUserPosiRec(UserName, Time, Lon,Lat) values(@UserName, @Time, @Lon,@Lat)";
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter Time = new SqlParameter("Time", SqlDbType.DateTime); Time.Value = model.Time;
            SqlParameter Lon = new SqlParameter("Lon", SqlDbType.Float); Lon.Value = model.Lon;
            SqlParameter Lat = new SqlParameter("Lat", SqlDbType.Float); Lat.Value = model.Lat;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, Time, Lon, Lat }, connectionString) == 1 ? true : false;
        }
        public static DataSet GetList1(string strWhere)
        {
            string strSql = "select Top 3000* from RTKUserPosiRec where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            DataSet dd = DBHelperSQL.GetDataSet(strSql, connectionString);
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
    }
}
