using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class RTKUserStatus
    {
        #region IRTKUserStatus 成员
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        public bool Exists(string UserName)
        {
            string strSql = "select count(*) from RTKUserStatus where UserName='" + UserName + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        public static  bool Add(Model.RTKUserStatus model)
        {
            string strSql = "insert into RTKUserStatus(UserName,Company, IsOnline, StartTime,Lon,Lat,Remark) values(@UserName,@Company,@IsOnline, @StartTime,@Lon,@Lat,@Remark)";
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter Company = new SqlParameter("Company", SqlDbType.NVarChar); Company.Value = model.Company;
            SqlParameter IsOnline = new SqlParameter("IsOnline", SqlDbType.Int); IsOnline.Value = model.IsOnline;
            SqlParameter StartTime = new SqlParameter("StartTime", SqlDbType.DateTime); StartTime.Value = model.StartTime;
            SqlParameter Lon = new SqlParameter("Lon", SqlDbType.Float); Lon.Value = model.Lon;
            SqlParameter Lat = new SqlParameter("Lat", SqlDbType.Float); Lat.Value = model.Lat;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, Company, IsOnline, StartTime, Lon, Lat, Remark }, connectionString) == 1 ? true : false;
        }

        public static DataSet GetMap()
        {
            string strSql = "select*from RTKUserStatus";
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static bool Update(Model.RTKUserStatus model)
        {
            string strSql = "update RTKUserStatus set UserName=@UserName,Company=@Company,IsOnline=@IsOnline, StartTime=@StartTime,Lon=@Lon,Lat=@Lat,Remark=@Remark where ID=" + model.ID.ToString();
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter Company = new SqlParameter("Company", SqlDbType.NVarChar); Company.Value = model.Company;
            SqlParameter IsOnline = new SqlParameter("IsOnline", SqlDbType.Int); IsOnline.Value = model.IsOnline;
            SqlParameter StartTime = new SqlParameter("StartTime", SqlDbType.DateTime); StartTime.Value = model.StartTime;
            SqlParameter Lon = new SqlParameter("Lon", SqlDbType.Float); Lon.Value = model.Lon;
            SqlParameter Lat = new SqlParameter("Lat", SqlDbType.Float); Lat.Value = model.Lat;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, Company, IsOnline, StartTime, Lon, Lat, Remark }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.RTKUserStatus GetModel(int ID)
        {
            string strSql = "select * from RTKUserStatus where ID = " + ID.ToString();
            Model.RTKUserStatus model = new Model.RTKUserStatus();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                model.Company = Convert.ToString(ds.Tables[0].Rows[0]["Company"]);
                model.IsOnline = Convert.ToInt32(ds.Tables[0].Rows[0]["IsOnline"]);
                if (ds.Tables[0].Rows[0]["StartTime"] == null || ds.Tables[0].Rows[0]["StartTime"].ToString().Trim() == "")
                {
                    model.StartTime = DateTime.Now;
                }
                else
                {
                    model.StartTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartTime"]);
                }
                model.Lon = Convert.ToDouble(ds.Tables[0].Rows[0]["Lon"]);
                model.Lat = Convert.ToDouble(ds.Tables[0].Rows[0]["Lat"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.RTKUserStatus GetModel(string UserName)
        {
            string strSql = "select * from RTKUserStatus where UserName = '" + UserName + "'";
            Model.RTKUserStatus model = new Model.RTKUserStatus();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.UserName = UserName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.Company = Convert.ToString(ds.Tables[0].Rows[0]["Company"]);
                model.IsOnline = Convert.ToInt32(ds.Tables[0].Rows[0]["IsOnline"]);
                if (ds.Tables[0].Rows[0]["StartTime"] == null || ds.Tables[0].Rows[0]["StartTime"].ToString().Trim() == "")
                {
                    model.StartTime = DateTime.Now;
                }
                else
                {
                    model.StartTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartTime"]);
                }
                model.Lon = Convert.ToDouble(ds.Tables[0].Rows[0]["Lon"]);
                model.Lat = Convert.ToDouble(ds.Tables[0].Rows[0]["Lat"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        public static bool Delete(string UserName)
        {
            string strSql = "delete from RTKUserStatus where UserName = '" + UserName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static System.Data.DataSet GetList(string strWhere)
        {
            string strSql = "select * from RTKUserStatus where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }


        public static DataSet GetList1(string username)
        {
            string sql = @"select * from RTKUserStatus where UserName in(
                            SELECT r2.UserName
                            FROM[dbo].[RegisterUser]
                                    r1, RTKUserInfo r2
                            WHERE r1.UserName = r2.RegisterUserName
                                AND r2.RegisterUserName ='"+username+"')";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
       

        
    }
}
#endregion