using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class RTKPostPurview
    {

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from RTKPostPurview where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string UserName)
        {
            string strSql = "select count(*) from RTKPostPurview where UserName='" + UserName + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.RTKPostPurview model)
        {
            string strSql = "insert into RTKPostPurview( UserName, CoorTransEnable, HeightTransEnable, SHPTransEnable, DXFTransEnable, PPPserverEnable, ObsQualityEnable, BaseLineEnable, MultiBaseLineEnable, StartTime, EndTime) values( @UserName, @CoorTransEnable, @HeightTransEnable, @SHPTransEnable, @DXFTransEnable, @PPPserverEnable, @ObsQualityEnable, @BaseLineEnable, @MultiBaseLineEnable, @StartTime, @EndTime)";
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter CoorTransEnable = new SqlParameter("CoorTransEnable", SqlDbType.Int); CoorTransEnable.Value = model.CoorTransEnable;
            SqlParameter HeightTransEnable = new SqlParameter("HeightTransEnable", SqlDbType.Int); HeightTransEnable.Value = model.HeightTransEnable;
            SqlParameter SHPTransEnable = new SqlParameter("SHPTransEnable", SqlDbType.Int); SHPTransEnable.Value = model.SHPTransEnable;
            SqlParameter DXFTransEnable = new SqlParameter("DXFTransEnable", SqlDbType.Int); DXFTransEnable.Value = model.DXFTransEnable;
            SqlParameter PPPserverEnable = new SqlParameter("PPPserverEnable", SqlDbType.Int); PPPserverEnable.Value = model.PPPserverEnable;
            SqlParameter ObsQualityEnable = new SqlParameter("ObsQualityEnable", SqlDbType.Int); ObsQualityEnable.Value = model.ObsQualityEnable;
            SqlParameter BaseLineEnable = new SqlParameter("BaseLineEnable", SqlDbType.Int); BaseLineEnable.Value = model.BaseLineEnable;
            SqlParameter MultiBaseLineEnable = new SqlParameter("MultiBaseLineEnable", SqlDbType.Int); MultiBaseLineEnable.Value = model.MultiBaseLineEnable;
            SqlParameter StartTime = new SqlParameter("StartTime", SqlDbType.DateTime); StartTime.Value = model.StartTime;
            SqlParameter EndTime = new SqlParameter("EndTime", SqlDbType.DateTime); EndTime.Value = model.EndTime;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, CoorTransEnable, HeightTransEnable, SHPTransEnable, DXFTransEnable, PPPserverEnable, ObsQualityEnable, BaseLineEnable, MultiBaseLineEnable, StartTime, EndTime }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.RTKPostPurview model)
        {
            string strSql = "update RTKPostPurview set UserName=@UserName, CoorTransEnable=@CoorTransEnable, HeightTransEnable=@HeightTransEnable, SHPTransEnable=@SHPTransEnable, DXFTransEnable=@DXFTransEnable, PPPserverEnable=@PPPserverEnable, ObsQualityEnable=@ObsQualityEnable, BaseLineEnable=@BaseLineEnable, MultiBaseLineEnable=@MultiBaseLineEnable, StartTime=@StartTime, EndTime=@EndTime where ID = " + model.ID.ToString();
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter CoorTransEnable = new SqlParameter("CoorTransEnable", SqlDbType.Int); CoorTransEnable.Value = model.CoorTransEnable;
            SqlParameter HeightTransEnable = new SqlParameter("HeightTransEnable", SqlDbType.Int); HeightTransEnable.Value = model.HeightTransEnable;
            SqlParameter SHPTransEnable = new SqlParameter("SHPTransEnable", SqlDbType.Int); SHPTransEnable.Value = model.SHPTransEnable;
            SqlParameter DXFTransEnable = new SqlParameter("DXFTransEnable", SqlDbType.Int); DXFTransEnable.Value = model.DXFTransEnable;
            SqlParameter PPPserverEnable = new SqlParameter("PPPserverEnable", SqlDbType.Int); PPPserverEnable.Value = model.PPPserverEnable;
            SqlParameter ObsQualityEnable = new SqlParameter("ObsQualityEnable", SqlDbType.Int); ObsQualityEnable.Value = model.ObsQualityEnable;
            SqlParameter BaseLineEnable = new SqlParameter("BaseLineEnable", SqlDbType.Int); BaseLineEnable.Value = model.BaseLineEnable;
            SqlParameter MultiBaseLineEnable = new SqlParameter("MultiBaseLineEnable", SqlDbType.Int); MultiBaseLineEnable.Value = model.MultiBaseLineEnable;
            SqlParameter StartTime = new SqlParameter("StartTime", SqlDbType.DateTime); StartTime.Value = model.StartTime;
            SqlParameter EndTime = new SqlParameter("EndTime", SqlDbType.DateTime); EndTime.Value = model.EndTime;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, CoorTransEnable, HeightTransEnable, SHPTransEnable, DXFTransEnable, PPPserverEnable, ObsQualityEnable, BaseLineEnable, MultiBaseLineEnable, StartTime, EndTime}, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.RTKPostPurview GetModel(string UserName)
        {
            string strSql = "select * from RTKPostPurview where UserName = '" + UserName + "'";
            Model.RTKPostPurview model = new Model.RTKPostPurview();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.UserName = UserName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.CoorTransEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["CoorTransEnable"]);
                model.HeightTransEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["HeightTransEnable"]);
                model.SHPTransEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["SHPTransEnable"]);
                model.DXFTransEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["DXFTransEnable"]);
                model.PPPserverEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["PPPserverEnable"]);
                model.ObsQualityEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["ObsQualityEnable"]);
                model.BaseLineEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["BaseLineEnable"]);
                model.MultiBaseLineEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["MultiBaseLineEnable"]);
                model.StartTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartTime"]);
                model.EndTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndTime"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        public static Model.RTKPostPurview GetModel(int ID)
        {
            string strSql = "select * from RTKPostPurview where ID = '" + ID + "'";
            Model.RTKPostPurview model = new Model.RTKPostPurview();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                model.CoorTransEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["CoorTransEnable"]);
                model.HeightTransEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["HeightTransEnable"]);
                model.SHPTransEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["SHPTransEnable"]);
                model.DXFTransEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["DXFTransEnable"]);
                model.PPPserverEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["PPPserverEnable"]);
                model.ObsQualityEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["ObsQualityEnable"]);
                model.BaseLineEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["BaseLineEnable"]);
                model.MultiBaseLineEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["MultiBaseLineEnable"]);
                model.StartTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartTime"]);
                model.EndTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndTime"]);
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
            string strSql = "delete from RTKPostPurview where UserName ='" + UserName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int ID)
        {
            string strSql = "delete from RTKPostPurview where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from RTKPostPurview where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static int GetRecordCount(string search = "")
        {
            string strSql = "select count(*) from RTKPostPurview where UserName like '%" + search + "%'";
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
            string sql = "SELECT * FROM RTKPostPurview w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM RTKPostPurview where UserName like '%" + search + "%' ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
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
            string sql = "SELECT * FROM RTKPostPurview w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM RTKPostPurview where UserName like '%" + search + "%' ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID ORDER BY w1.@sort @order";
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }

    }
}
