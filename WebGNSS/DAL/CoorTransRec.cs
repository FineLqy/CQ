using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
   public  class CoorTransRec
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from CoorTransRec where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        /// <summary>
        /// 是否存在用户UserName
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string UserName)
        {
            string strSql = "select count(*) from CoorTransRec where UserName='" + UserName + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        /// <summary>
        /// 增加一个项纪录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.CoorTransRec model)
        {
            string strSql = "insert into CoorTransRec(UserName, Company, Type, Time, Result, Remark, ProjectName, Amount, Cost,ResultPath) values(@UserName, @Company, @Type, @Time,@Result,@Remark,@ProjectName, @Amount, @Cost,@ResultPath)";
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter Company = new SqlParameter("Company", SqlDbType.NVarChar); Company.Value = model.Company;
            SqlParameter Type = new SqlParameter("Type", SqlDbType.NVarChar); Type.Value = model.Type;
            SqlParameter Time = new SqlParameter("Time", SqlDbType.DateTime); Time.Value = model.Time;
            SqlParameter Result = new SqlParameter("Result", SqlDbType.NVarChar); Result.Value = model.Result;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;
            SqlParameter ProjectName = new SqlParameter("ProjectName", SqlDbType.NVarChar); ProjectName.Value = model.ProjectName;
            SqlParameter Amount = new SqlParameter("Amount", SqlDbType.Float); Amount.Value = model.Amount;
            SqlParameter Cost = new SqlParameter("Cost", SqlDbType.Float); Cost.Value = model.Cost;
            SqlParameter ResultPath = new SqlParameter("ResultPath", SqlDbType.NVarChar); ResultPath.Value = model.ResultPath;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, Company, Type, Time, Result, Remark, ProjectName, Amount, Cost, ResultPath }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.CoorTransRec model)
        {
            string strSql = "update CoorTransRec set UserName=@UserName, Company=@Company, Type=@Type, Time=@Time,Result=@Result,Remark=@Remark,ProjectName=@ProjectName,Cost=@Cost,Amount=@Amount,ResultPath=@ResultPath where ID = " + model.ID.ToString();
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter Company = new SqlParameter("Company", SqlDbType.NVarChar); Company.Value = model.Company;
            SqlParameter Type = new SqlParameter("Type", SqlDbType.NVarChar); Type.Value = model.Type;
            SqlParameter Time = new SqlParameter("Time", SqlDbType.DateTime); Time.Value = model.Time;
            SqlParameter Result = new SqlParameter("Result", SqlDbType.NVarChar); Result.Value = model.Result;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;
            SqlParameter ProjectName = new SqlParameter("ProjectName", SqlDbType.NVarChar); ProjectName.Value = model.ProjectName;
            SqlParameter ResultPath = new SqlParameter("ResultPath", SqlDbType.NVarChar); ResultPath.Value = model.ResultPath;
            SqlParameter Amount = new SqlParameter("Amount", SqlDbType.Float); Amount.Value = model.Amount;
            SqlParameter Cost = new SqlParameter("Cost", SqlDbType.Float); Cost.Value = model.Cost;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, Company, Type, Time, Result, Remark, ProjectName, Amount, Cost, ResultPath }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 删除一条数据（根据ID）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Delete(int ID)
        {
            string strSql = "delete from CoorTransRec where ID =" + ID.ToString();
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 删除多条数据（根据ID）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Delete(string UserName)
        {
            string strSql = "delete from CoorTransRec where UserName ='" + UserName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) >= 0 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.CoorTransRec GetModel(int ID)
        {
            string strSql = "select * from CoorTransRec where ID = " + ID.ToString();
            Model.CoorTransRec model = new Model.CoorTransRec();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                model.Company = Convert.ToString(ds.Tables[0].Rows[0]["Company"]);              
                model.Type = Convert.ToString(ds.Tables[0].Rows[0]["Type"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                model.Result = Convert.ToString(ds.Tables[0].Rows[0]["Result"]);
                model.Time = Convert.ToDateTime(ds.Tables[0].Rows[0]["Time"]);
                model.ProjectName = Convert.ToString(ds.Tables[0].Rows[0]["ProjectName"]);
                model.Amount = Convert.ToDouble(ds.Tables[0].Rows[0]["Amount"]);
                model.Cost = Convert.ToDouble(ds.Tables[0].Rows[0]["Cost"]);
                model.ResultPath = Convert.ToString(ds.Tables[0].Rows[0]["ResultPath"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from CoorTransRec where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }


        /// <summary>
        /// 获得用户坐标转换列表
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <param name="limit">用户名</param>
        /// <returns></returns>
        public static DataSet GetBriefList(int offset, int limit, string UserName)
        {
            int endRecord = offset + limit;
            string sql = "SELECT w1.ID,w1.UserName,w1.Type,w1.Time,w1.Result,w1.Remark FROM CoorTransRec w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + " ID,UserName,Type,Time,Result,Remark FROM CoorTransRec where UserName='" + UserName + "' ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        public static int GetRecordCount()
        {
            string strSql = "select count(*) from CoorTransRec";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
        /// <summary>
        /// 获得用户坐标转换列表
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList(int offset, int limit)
        {
            int endRecord = offset + limit;
            string sql = "SELECT w1.ID,w1.UserName,w1.Type,w1.Time,w1.Result,w1.Remark FROM CoorTransRec w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + " ID,UserName,Type,Time,Result,Remark FROM CoorTransRec ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }



        public static int GetRecordCount(string UserName)
        {
            string strSql = "select count(*) from CoorTransRec where UserName='" + UserName + "'";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }

        public static int GetRecordCount(string Company, int i, string search)
        {
            string strSql = "select count(*) from CoorTransRec where Company='" + Company + "'and "+search;
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }

        /// <summary>
        /// 获得用户坐标转换列表
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <param name="limit">单位名</param>
        /// <param name="limit">区分</param>
        /// <returns></returns>
        public static DataSet GetBriefList(int offset, int limit, string Company, int i,string search)
        {
            int endRecord = offset + limit;
            string sql = "SELECT w1.ID,w1.UserName,w1.Type,w1.Time,w1.Result,w1.Remark FROM CoorTransRec w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + " ID,UserName,Type,Time,Result,Remark FROM CoorTransRec where Company='" + Company + "' and "+search+" ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }

        public static DataSet GetBriefList(int offset, int limit, string UserName,string Remark)
        {
            int endRecord = offset + limit;
            string sql = "SELECT w1.ID,w1.UserName,w1.Type,w1.Time,w1.Result,w1.Remark,w1.ProjectName,w1.Amount,w1.Cost,w1.ResultPath FROM CoorTransRec w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + " ID,UserName,Type,Time,Result,Remark,ProjectName,Amount,Cost,ResultPath FROM CoorTransRec where UserName='" + UserName + "' and Remark like '%" + Remark + "%' ORDER BY ID DESC) w ORDER BY w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID DESC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        public static int GetRecordCount(string UserName,string Remark)
        {
            string strSql = "select count(*) from CoorTransRec where UserName='" + UserName + "' and Remark like'%"+Remark+"%'";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }

        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetListByPage(int offset, int limit, string sort = "Time", string order = "desc", string search = "")
        {
            string deorder = order.ToLower() == "desc" ? "asc" : "desc";
            int endRecord = offset + limit;
            string sql = "SELECT * FROM CoorTransRec w1,( SELECT TOP @limit w.ID FROM( SELECT TOP  @endRecord * FROM CoorTransRec where UserName like '%@search%' ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID  ORDER BY w1.@sort @order";
            sql = sql.Replace("@limit", limit.ToString());
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@endRecord", endRecord.ToString());
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            sql = sql.Replace("@search", search);
            DataSet ds = DBHelperSQL.GetDataSet(sql, connectionString);
            return ds;
        }


        public static int GetRecordCountBySearch(string search = "")
        {
            string strSql = "select count(*) from CoorTransRec where UserName like '%@search%'";
            strSql = strSql.Replace("@search", search);
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }


        public static DataSet GetBriefList(int offset, int limit,string UserName,bool b,string search="")
        {
            int endRecord = offset + limit;
            string sql = "SELECT w1.ID,w1.UserName,w1.Type,w1.Time,w1.Result,w1.Remark,w1.ProjectName,w1.Amount,w1.Cost FROM CoorTransRec w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + " ID,UserName,Type,Time,Result,Remark,ProjectName,Amount,Cost FROM CoorTransRec where UserName='" + UserName + "' and " + search + " ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }



        public static int GetRecordCount(string UserName,bool b,string search="")
        {
            string strSql = "select count(*) from CoorTransRec where UserName='" + UserName + "' and "+search;
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }



        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetListByPage(int offset, int limit, string sort = "Time", string order = "desc", string search = "", string dType = "")
        {
            string deorder = order.ToLower() == "desc" ? "asc" : "desc";
            int endRecord = offset + limit;
            string sql = "SELECT * FROM CoorTransRec w1,( SELECT TOP @limit w.ID FROM( SELECT TOP  @endRecord * FROM CoorTransRec where UserName like '%@search%' and Remark like '%@Type%' ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID  ORDER BY w1.@sort @order";
            sql = sql.Replace("@limit", limit.ToString());
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@endRecord", endRecord.ToString());
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            sql = sql.Replace("@search", search);
            sql = sql.Replace("@Type", dType);
            DataSet ds = DBHelperSQL.GetDataSet(sql, connectionString);
            return ds;
        }


        public static int GetRecordCountBySearch(string search = "",string dType="")
        {
            string strSql = "select count(*) from CoorTransRec where UserName like '%@search%' and Remark like '%@Type%'";
            strSql = strSql.Replace("@search", search);
            strSql = strSql.Replace("@Type", dType);
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }

    }
}
