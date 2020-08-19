using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class SysLog
    {
        #region ISysLog 成员
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        public static bool Add(Model.SysLog model)
        {
            string strSql = "insert into SysLog(LogTime, UserName,Remark,LogType) values(@LogTime,@UserName,@Remark,@LogType)";
            SqlParameter LogTime = new SqlParameter("LogTime", SqlDbType.DateTime); LogTime.Value = model.LogTime;
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;
            SqlParameter LogType = new SqlParameter("LogType", SqlDbType.Int); LogType.Value = model.LogType;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { LogTime, UserName, Remark, LogType }, connectionString) == 1 ? true : false;
        }
        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.SysLog model)
        {
            string strSql = "update SysLog set UserName=@UserName, LogTime=@LogTime, LogType=@LogType, Remark=@Remark where ID = " + model.ID.ToString();
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter LogTime = new SqlParameter("LogTime", SqlDbType.DateTime); LogTime.Value = model.LogTime;
            SqlParameter LogType = new SqlParameter("LogType", SqlDbType.Int); LogType.Value = model.LogType;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;

            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, LogTime, LogType, Remark }, connectionString) == 1 ? true : false;
        }
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.SysLog GetModel(int ID)
        {
            string strSql = "select * from SysLog where ID = '" + ID + "'";
            Model.SysLog model = new Model.SysLog();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                model.LogTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["LogTime"]);
                model.LogType = Convert.ToInt32(ds.Tables[0].Rows[0]["LogType"]);
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                return model;
            }
            else
            {
                return null;
            }
        }
        public static bool Delete(int ID)
        {
            string strSql = "delete from SysLog where ID = " + ID;
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static System.Data.DataSet GetList(string strWhere)
        {
            string strSql = "select * from SysLog where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetListByPage(int offset, int limit, int logType, string sort = "LogTime", string order = "desc")
        {
            string deorder = order.ToLower() == "desc" ? "asc" : "desc";
            int endRecord = offset + limit;
            string sql = "SELECT * FROM SysLog w1,( SELECT TOP @limit w.ID FROM( SELECT TOP  @endRecord * FROM SysLog where LogType = @logType ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID  ORDER BY w1.@sort @order";
            sql = sql.Replace("@limit", limit.ToString());
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@endRecord", endRecord.ToString());
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@logType", logType.ToString());
            sql = sql.Replace("@deorder", deorder);
            //SqlParameter Limit = new SqlParameter("@limit", SqlDbType.NVarChar, 500); Limit.Value = limit;
            //SqlParameter EndRecord = new SqlParameter("@endRecord", SqlDbType.DateTime);
            //EndRecord.Value = endRecord;
            //return DBHelperSQL.GetDataSet(sql, new SqlParameter[] { Limit, EndRecord });
            DataSet ds = DBHelperSQL.GetDataSet(sql, connectionString);
            return ds;


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetListByPage1(int offset, int limit, int logType,string username, string sort = "LogTime", string order = "desc")
        {
            string deorder = order.ToLower() == "desc" ? "asc" : "desc";
            int endRecord = offset + limit;
            string sql = "SELECT * FROM SysLog w1,( SELECT TOP @limit w.ID FROM( SELECT TOP  @endRecord * FROM SysLog where LogType = @logType ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID and UserName like'%"+username+"%'  ORDER BY w1.@sort @order";
            sql = sql.Replace("@limit", limit.ToString());
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@endRecord", endRecord.ToString());
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@logType", logType.ToString());
            sql = sql.Replace("@deorder", deorder);
            //SqlParameter Limit = new SqlParameter("@limit", SqlDbType.NVarChar, 500); Limit.Value = limit;
            //SqlParameter EndRecord = new SqlParameter("@endRecord", SqlDbType.DateTime);
            //EndRecord.Value = endRecord;
            //return DBHelperSQL.GetDataSet(sql, new SqlParameter[] { Limit, EndRecord });
            DataSet ds = DBHelperSQL.GetDataSet(sql, connectionString);
            return ds;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList1(int offset, int limit, string sort = "LogTime", string order = "desc", string search = "", string strwhere = "1=1")
        {
            string deorder = order.ToLower() == "desc" ? "asc" : "desc";
            int endRecord = offset + limit;
            string sql = "SELECT * FROM SysLog w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM SysLog where UserName like '%" + search + "%' and " + strwhere + " ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID ORDER BY w1.@sort @order";
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }

        public static int GetRecordCount(string search = "", string strwhere = "1=1")
        {
            string strSql = "select count(*) from SysLog where UserName like '%" + search + "%' and " + strwhere;
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }


        public static int GetRecordCount()
        {
            string strSql = "select count(*) from SysLog";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
        #endregion
    }
}
