using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
using Model;

namespace DAL
{
    /// <summary>
    /// 数据库操作类News，对新闻表News进行操作
    /// </summary>
    public class News
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from News where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 添加一条新闻到数据库中
        /// </summary>
        /// <returns></returns>
        public static bool Add(Model.News news)
        {
            string strSql = "insert into News(Title,Time,Author,Pageview,Details) values(@Title,@Time,@Author,@Pageview,@Details)";
            SqlParameter Title = new SqlParameter("@Title", SqlDbType.NVarChar, 500); Title.Value = news.Title;
            SqlParameter Time = new SqlParameter("@Time", SqlDbType.DateTime);
            Time.Value = news.Time;
            SqlParameter Author = new SqlParameter("@Author", SqlDbType.NVarChar, 50); Author.Value = news.Author;
            SqlParameter Pageview = new SqlParameter("@Pageview", SqlDbType.Int);
            Pageview.Value = news.Pageview;
            SqlParameter Details = new SqlParameter("@Details", SqlDbType.NVarChar);
            Details.Value = news.Details;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { Title, Time, Author, Pageview, Details }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.News GetModel(int ID)
        {
            string strSql = "select * from News where ID = " + ID.ToString();
            Model.News model = new Model.News();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Title = Convert.ToString(ds.Tables[0].Rows[0]["Title"]);
                model.Author = Convert.ToString(ds.Tables[0].Rows[0]["Author"]);
                model.Time = (DateTime)ds.Tables[0].Rows[0]["Time"];
                model.Details = Convert.ToString(ds.Tables[0].Rows[0]["Details"]);
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
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Delete(int ID)
        {
            string strSql = "delete from News where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 获得新闻列表
        /// </summary>
        /// <returns></returns>
        public static DataSet ListTop3()
        {
            string strSql = "select  top 3* from News  ";
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        /// <summary>
        /// 删除多条数据（根据ID）
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static bool DeleteByIDs(int[] ids)
        {
            string delstr = "";
            for (int i = 0; i < ids.Length - 1; i++)
            {
                delstr += "(ID='" + ids[i] + "')or";
            }
            delstr += "(ID='" + ids[ids.Length - 1] + "')";
            string strSql = "delete from News where " + delstr;
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }


        public static int GetRecordCount()
        {
            string strSql = "select count(*) from News";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }


        /// <summary>
        /// 获得新闻列表
        /// </summary>
        /// <returns></returns>
        public static DataSet GetList()
        {
            string strSql = "select * from News  ";
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
        /// <summary>
        /// 获得新闻列表
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList(int offset, int limit)
        {
            int endRecord = offset + limit;
            string sql = "SELECT w1.ID,w1.Title,w1.Time,w1.Pageview,w1.Author FROM News w1,( SELECT TOP "+limit+" w.ID FROM( SELECT TOP  "+endRecord+" ID,Title,Time,Pageview,Author FROM News ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            //SqlParameter Limit = new SqlParameter("@limit", SqlDbType.NVarChar, 500); Limit.Value = limit;
            //SqlParameter EndRecord = new SqlParameter("@endRecord", SqlDbType.DateTime);
            //EndRecord.Value = endRecord;
            //return DBHelperSQL.GetDataSet(sql, new SqlParameter[] { Limit, EndRecord });
            return DBHelperSQL.GetDataSet(sql,connectionString);
        }

    }
}
