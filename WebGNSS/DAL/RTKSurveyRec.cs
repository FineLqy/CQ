using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class RTKSurveyRec
    {

        #region IRTKSurveyRec 成员
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        public bool Add(Model.RTKSurveyRec model)
        {
            string strSql = "insert into RTKSurveyRec(UserName,Company, StartTime, OnlineSpan,FixedSpan,Cost,Remark) values(@UserName, @StartTime, @OnlineSpan,@FixedSpan,@Cost,@Remark)";
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter Company = new SqlParameter("Company", SqlDbType.NVarChar); Company.Value = model.Company;
            SqlParameter StartTime = new SqlParameter("StartTime", SqlDbType.DateTime); StartTime.Value = model.StartTime;
            SqlParameter OnlineSpan = new SqlParameter("OnlineSpan", SqlDbType.Float); OnlineSpan.Value = model.OnlineSpan;
            SqlParameter FixedSpan = new SqlParameter("FixedSpan", SqlDbType.Float); FixedSpan.Value = model.FixedSpan;
            SqlParameter Cost = new SqlParameter("Cost", SqlDbType.Float); Cost.Value = model.Cost;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName,Company, StartTime, OnlineSpan,FixedSpan, Cost, Remark }, connectionString) == 1 ? true : false;
        }

        public bool Update(Model.RTKSurveyRec model)
        {
            string strSql = "update RTKSurveyRec set UserName=@UserName,Company=@Company,StartTime=@StartTime,OnlineSpan=@OnlineSpan,FixedSpan=@FixedSpan,Cost=@Cost,Remark=@Remark where ID=" + model.ID.ToString();
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter Company = new SqlParameter("Company", SqlDbType.NVarChar); Company.Value = model.Company;
            SqlParameter StartTime = new SqlParameter("StartTime", SqlDbType.DateTime); StartTime.Value = model.StartTime;
            SqlParameter OnlineSpan = new SqlParameter("OnlineSpan", SqlDbType.Float); OnlineSpan.Value = model.OnlineSpan;
            SqlParameter FixedSpan = new SqlParameter("FixedSpan", SqlDbType.Float); FixedSpan.Value = model.FixedSpan;
            SqlParameter Cost = new SqlParameter("Cost", SqlDbType.Float); Cost.Value = model.Cost;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, Company, StartTime, OnlineSpan,FixedSpan, Cost, Remark }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.RTKSurveyRec GetModel(int ID)
        {
            string strSql = "select * from RTKSurveyRec where ID = " + ID.ToString();
            Model.RTKSurveyRec model = new Model.RTKSurveyRec();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                model.Company = Convert.ToString(ds.Tables[0].Rows[0]["Company"]);
                model.StartTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartTime"]);
                model.OnlineSpan = Convert.ToDouble(ds.Tables[0].Rows[0]["OnlineSpan"]);
                model.FixedSpan = Convert.ToDouble(ds.Tables[0].Rows[0]["FixedSpan"]);
                model.Cost = Convert.ToDouble(ds.Tables[0].Rows[0]["Cost"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                return model;
            }
            else
            {
                return null;
            }
        }


        public bool Delete(int ID)
        {
            string strSql = "delete from RTKSurveyRec where ID = " + ID;
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static System.Data.DataSet GetList(string strWhere)
        {
            string strSql = "select * from RTKSurveyRec where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
                public static System.Data.DataSet GetCompany(string strWhere)
        {
            string strSql = "select distinct(Company) from RTKSurveyRec where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        /// <summary>
        /// 获得用户作业列表
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <param name="limit">用户名</param>
        /// <returns></returns>
        public static DataSet GetBriefList(int offset, int limit,string UserName)
        {
            int endRecord = offset + limit;
            string sql = "SELECT w1.ID,w1.UserName,w1.Company,w1.StartTime,w1.OnlineSpan,w1.FixedSpan,w1.Cost,w1.Remark FROM RTKSurveyRec w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + " ID,UserName,Company,StartTime,OnlineSpan,FixedSpan,Cost,Remark FROM RTKSurveyRec where UserName='"+UserName+"' ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        public static int GetRecordCount()
        {
            string strSql = "select count(*) from RTKSurveyRec";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
        /// <summary>
        /// 获得用户作业列表
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList(int offset, int limit)
        {
            int endRecord = offset + limit;
            string sql = "SELECT w1.ID,w1.UserName,w1.Company,w1.StartTime,w1.OnlineSpan,w1.FixedSpan,w1.Cost,w1.Remark FROM RTKSurveyRec w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + " ID,UserName,Company,StartTime,OnlineSpan,FixedSpan,Cost,Remark FROM RTKSurveyRec ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        //cors用户
        public static int GetRecordCount(string UserName, int i, string search = "")
        {
            string strSql = "select count(*) from RTKSurveyRec where UserName='"+UserName+"' and "+search;
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
        public static DataSet GetBriefList(int offset, int limit, string UserName,int i,string search="")
        {
            int endRecord = offset + limit;
            string sql = "SELECT w1.ID,w1.UserName,w1.Company,w1.StartTime,w1.OnlineSpan,w1.FixedSpan,w1.Cost,w1.Remark FROM RTKSurveyRec w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + " ID,UserName,Company,StartTime,OnlineSpan,FixedSpan,Cost,Remark FROM RTKSurveyRec where UserName='" + UserName + "' and "+search+" ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        //单位管理员
        public static int GetRecordCount(string Company,bool i,string search="")
        {
            string strSql = "select count(*) from RTKSurveyRec where Company='" + Company + "' and " + search;
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }

        /// <summary>
        /// 获得用户作业列表
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <param name="limit">单位名</param>
        /// <param name="limit">区分</param>
        /// <returns></returns>
        public static DataSet GetBriefList(int offset, int limit, string Company,bool i,string search)
        {
            int endRecord = offset + limit;
            string sql = "SELECT w1.ID,w1.UserName,w1.Company,w1.StartTime,w1.OnlineSpan,w1.FixedSpan,w1.Cost,w1.Remark FROM RTKSurveyRec w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + " ID,UserName,Company,StartTime,OnlineSpan,FixedSpan,Cost,Remark FROM RTKSurveyRec where Company='" + Company + "' and " + search + " ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }


        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetListByPage(int offset, int limit, string sort = "StartTime", string order = "desc", string search = "")
        {
            string deorder = order.ToLower() == "desc" ? "asc" : "desc";
            int endRecord = offset + limit;
            string sql = "SELECT * FROM RTKSurveyRec w1,( SELECT TOP @limit w.ID FROM( SELECT TOP  @endRecord * FROM RTKSurveyRec where @search ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID  ORDER BY w1.@sort @order";
            sql = sql.Replace("@limit", limit.ToString());
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@endRecord", endRecord.ToString());
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            sql = sql.Replace("@search", search);
            DataSet ds = DBHelperSQL.GetDataSet(sql, connectionString);
            return ds;
        }


        public static int GetRecordCount(string search = "",string type ="")
        {
            string strSql = "select count(*) from RTKSurveyRec where @search";
            strSql = strSql.Replace("@search", search);
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
        #endregion
    }
}
