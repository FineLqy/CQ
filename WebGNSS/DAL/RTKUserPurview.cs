using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{

    public class RTKUserPurview
    {

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from RTKUserPurview where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string UserName)
        {
            string strSql = "select count(*) from RTKUserPurview where UserName='" + UserName + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.RTKUserPurview model)
        {
            string strSql = "insert into RTKUserPurview( UserName, VRSEnable, StartTime, EndTime, ServerType, SourceTable, AreaID, CoorSystem, ElevationEnable, ElevationMode, RoamingServiceEnable, RoamingServiceArea) values( @UserName, @VRSEnable, @StartTime, @EndTime, @ServerType, @SourceTable, @AreaID, @CoorSystem, @ElevationEnable, @ElevationMode, @RoamingServiceEnable, @RoamingServiceArea )";
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter VRSEnable = new SqlParameter("VRSEnable", SqlDbType.Int); VRSEnable.Value = model.VRSEnable;
            SqlParameter StartTime = new SqlParameter("StartTime", SqlDbType.DateTime); StartTime.Value = model.StartTime;
            SqlParameter EndTime = new SqlParameter("EndTime", SqlDbType.DateTime); EndTime.Value = model.EndTime;
            SqlParameter ServerType = new SqlParameter("ServerType", SqlDbType.NVarChar); ServerType.Value = model.ServerType;
            SqlParameter SourceTable = new SqlParameter("SourceTable", SqlDbType.NVarChar); SourceTable.Value = model.SourceTable;
            SqlParameter AreaID = new SqlParameter("AreaID", SqlDbType.NVarChar); AreaID.Value = model.AreaID;
            SqlParameter CoorSystem = new SqlParameter("CoorSystem", SqlDbType.NVarChar); CoorSystem.Value = model.CoorSystem;
            SqlParameter ElevationEnable = new SqlParameter("ElevationEnable", SqlDbType.Int); ElevationEnable.Value = model.ElevationEnable;
            SqlParameter ElevationMode = new SqlParameter("ElevationMode", SqlDbType.NVarChar); ElevationMode.Value = model.ElevationMode;
            SqlParameter RoamingServiceEnable = new SqlParameter("RoamingServiceEnable", SqlDbType.Int); RoamingServiceEnable.Value = model.RoamingServiceEnable;
            SqlParameter RoamingServiceArea = new SqlParameter("RoamingServiceArea", SqlDbType.NVarChar); RoamingServiceArea.Value = model.RoamingServiceArea;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, VRSEnable, StartTime, EndTime, ServerType, SourceTable, AreaID, CoorSystem, ElevationEnable, ElevationMode, RoamingServiceEnable, RoamingServiceArea }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.RTKUserPurview model)
        {
            string strSql = "update RTKUserPurview set UserName=@UserName, VRSEnable=@VRSEnable, StartTime=@StartTime, EndTime=@EndTime, ServerType=@ServerType, SourceTable=@SourceTable, AreaID=@AreaID, CoorSystem=@CoorSystem, ElevationEnable=@ElevationEnable, ElevationMode=@ElevationMode, RoamingServiceEnable=@RoamingServiceEnable, RoamingServiceArea=@RoamingServiceArea where ID = " + model.ID.ToString();
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter VRSEnable = new SqlParameter("VRSEnable", SqlDbType.Int); VRSEnable.Value = model.VRSEnable;
            SqlParameter StartTime = new SqlParameter("StartTime", SqlDbType.DateTime); StartTime.Value = model.StartTime;
            SqlParameter EndTime = new SqlParameter("EndTime", SqlDbType.DateTime); EndTime.Value = model.EndTime;
            SqlParameter ServerType = new SqlParameter("ServerType", SqlDbType.NVarChar); ServerType.Value = model.ServerType;
            SqlParameter SourceTable = new SqlParameter("SourceTable", SqlDbType.NVarChar); SourceTable.Value = model.SourceTable;
            SqlParameter AreaID = new SqlParameter("AreaID", SqlDbType.NVarChar); AreaID.Value = model.AreaID;
            SqlParameter CoorSystem = new SqlParameter("CoorSystem", SqlDbType.NVarChar); CoorSystem.Value = model.CoorSystem;
            SqlParameter ElevationEnable = new SqlParameter("ElevationEnable", SqlDbType.Int); ElevationEnable.Value = model.ElevationEnable;
            SqlParameter ElevationMode = new SqlParameter("ElevationMode", SqlDbType.NVarChar); ElevationMode.Value = model.ElevationMode;
            SqlParameter RoamingServiceEnable = new SqlParameter("RoamingServiceEnable", SqlDbType.Int); RoamingServiceEnable.Value = model.RoamingServiceEnable;
            SqlParameter RoamingServiceArea = new SqlParameter("RoamingServiceArea", SqlDbType.NVarChar); RoamingServiceArea.Value = model.RoamingServiceArea;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, VRSEnable, StartTime, EndTime, ServerType, SourceTable, AreaID, CoorSystem, ElevationEnable, ElevationMode, RoamingServiceEnable, RoamingServiceArea }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.RTKUserPurview GetModel(string UserName)
        {
            string strSql = "select * from RTKUserPurview where UserName = '" + UserName + "'";
            Model.RTKUserPurview model = new Model.RTKUserPurview();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.UserName = UserName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.VRSEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["VRSEnable"]);
                model.StartTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartTime"]);
                model.EndTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndTime"]);
                model.ServerType = Convert.ToString(ds.Tables[0].Rows[0]["ServerType"]);
                model.SourceTable = Convert.ToString(ds.Tables[0].Rows[0]["SourceTable"]);
                model.AreaID = Convert.ToString(ds.Tables[0].Rows[0]["AreaID"]);
                model.CoorSystem = Convert.ToString(ds.Tables[0].Rows[0]["CoorSystem"]);
                model.ElevationEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["ElevationEnable"]);
                model.ElevationMode = Convert.ToString(ds.Tables[0].Rows[0]["ElevationMode"]);
                model.RoamingServiceEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["RoamingServiceEnable"]);
                model.RoamingServiceArea = Convert.ToString(ds.Tables[0].Rows[0]["RoamingServiceArea"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        public static Model.RTKUserPurview GetModel(int ID)
        {
            string strSql = "select * from RTKUserPurview where ID = '" + ID + "'";
            Model.RTKUserPurview model = new Model.RTKUserPurview();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                model.VRSEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["VRSEnable"]);
                model.StartTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartTime"]);
                model.EndTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndTime"]);
                model.ServerType = Convert.ToString(ds.Tables[0].Rows[0]["ServerType"]);
                model.SourceTable = Convert.ToString(ds.Tables[0].Rows[0]["SourceTable"]);
                model.AreaID = Convert.ToString(ds.Tables[0].Rows[0]["AreaID"]);
                model.CoorSystem = Convert.ToString(ds.Tables[0].Rows[0]["CoorSystem"]);
                model.ElevationEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["ElevationEnable"]);
                model.ElevationMode = Convert.ToString(ds.Tables[0].Rows[0]["ElevationMode"]);
                model.RoamingServiceEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["RoamingServiceEnable"]);
                model.RoamingServiceArea = Convert.ToString(ds.Tables[0].Rows[0]["RoamingServiceArea"]);
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 删除一条数据（根据UserName）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Delete(string UserName)
        {
            string strSql = "delete from RTKUserPurview where UserName ='" + UserName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int ID)
        {
            string strSql = "delete from RTKUserPurview where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from RTKUserPurview where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static int GetRecordCount(string search = "")
        {
            string strSql = "select count(*) from RTKUserPurview where UserName like '%" + search + "%'";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList(int offset, int limit, string search = "")
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM RTKUserPurview w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM RTKUserPurview where UserName like '%" + search + "%' ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList1(int offset, int limit, string sort = "SubmitTime", string order = "desc", string search = "")
        {
            string deorder = order.ToLower() == "desc" ? "asc" : "desc";
            int endRecord = offset + limit;
            string sql = "SELECT * FROM RTKUserPurview w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM RTKUserPurview where UserName like '%" + search + "%' ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID ORDER BY w1.@sort @order";
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }

    }
}
