using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DBUtility;
namespace DAL
{
    public class UserMessage
    {

        /// <summary>
        /// 数据库访问UserMeassage
        /// </summary>
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        #region UserMeassage 成员
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Exists(int ID)
        {
            string strSql = "select count(*) from UserMeassage where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 判断收件人是否存在
        /// </summary>
        /// <param name="ToUser"></param>
        /// <returns></returns>
        public bool Exists(string ToUser)
        {
            string strlSql = "select count(*) from UserMeassage where ToUser='" + ToUser + "' ";
            return DBHelperSQL.GetResult(strlSql).ToString().Trim() != "0" ? true : false;
        }

        public static bool Add(Model.UserMessage model)
        {
            string strSql = "insert into UserMessage(level,Title, Content, FromUser, ToUser,SentTime, IsRead, Remark) values(@level,@Title, @Content, @FromUser, @ToUser,@SentTime, @IsRead, @Remark)";
            SqlParameter level = new SqlParameter("level", SqlDbType.Int); level.Value = model.level;
            SqlParameter Title = new SqlParameter("Title", SqlDbType.VarChar); Title.Value = model.Title;
            SqlParameter Content = new SqlParameter("Content", SqlDbType.NVarChar); Content.Value = model.Content;
            SqlParameter FromUser = new SqlParameter("FromUser", SqlDbType.VarChar); FromUser.Value = model.FromUser;
            SqlParameter ToUser = new SqlParameter("ToUser", SqlDbType.VarChar); ToUser.Value = model.ToUser;
            SqlParameter SentTime = new SqlParameter("SentTime", SqlDbType.DateTime); SentTime.Value = model.SentTime;
            // SqlParameter ReadTime = new SqlParameter("ReadTime", SqlDbType.DateTime); ReadTime.Value = model.ReadTime;
            SqlParameter IsRead = new SqlParameter("IsRead", SqlDbType.Int); IsRead.Value = model.IsRead;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { level, Title, Content, FromUser, ToUser, SentTime, IsRead, Remark }) == 1 ? true : false;

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.UserMessage model)
        {
            string strSql = "update UserMessage set level=@level,Title=@Title, Content=@Content, FromUser=@FromUser,ToUser=@ToUser, SentTime=@SentTime,ReadTime=@ReadTime, IsRead=@IsRead, Remark=@Remark where ID = " + model.ID.ToString();
            SqlParameter level = new SqlParameter("level", SqlDbType.Int); level.Value = model.level;
            SqlParameter Title = new SqlParameter("Title", SqlDbType.VarChar); Title.Value = model.Title;

            SqlParameter Content = new SqlParameter("Content", SqlDbType.NVarChar); Content.Value = model.Content;
            SqlParameter FromUser = new SqlParameter("FromUser", SqlDbType.VarChar); FromUser.Value = model.FromUser;
            SqlParameter ToUser = new SqlParameter("ToUser", SqlDbType.VarChar); ToUser.Value = model.ToUser;
            SqlParameter SentTime = new SqlParameter("SentTime", SqlDbType.DateTime); SentTime.Value = model.SentTime;
            SqlParameter ReadTime = new SqlParameter("ReadTime", SqlDbType.DateTime); ReadTime.Value = model.ReadTime;
            SqlParameter IsRead = new SqlParameter("IsRead", SqlDbType.Int); IsRead.Value = model.IsRead;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { level, Title, Content, FromUser, ToUser, SentTime, IsRead, ReadTime, Remark }) == 1 ? true : false;

        }
        /// <summary>
        /// 删除一条数据(根据ID）
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool Delete(int ID)
        {
            string strSql = "delete from UserMessage where ID = " + ID;
            return DBHelperSQL.GetNums(strSql) == 1 ? true : false;
        }
        /// <summary>
        /// 删除一条数据（根据ToUser）
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Delete(string ToUser)
        {
            string strSql = "delete from UserMessage where ToUser ='" + ToUser + "'";
            return DBHelperSQL.GetNums(strSql) == 1 ? true : false;
        }
        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.UserMessage GetModel(int ID)
        {
            string strSql = "select * from UserMessage where ID = " + ID.ToString();
            Model.UserMessage model = new Model.UserMessage();
            DataSet ds = DBHelperSQL.GetDataSet(strSql);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.level = Convert.ToInt32(ds.Tables[0].Rows[0]["level"]);
                model.Title = Convert.ToString(ds.Tables[0].Rows[0]["Title"]);
                model.Content = Convert.ToString(ds.Tables[0].Rows[0]["Content"]);
                model.FromUser = Convert.ToString(ds.Tables[0].Rows[0]["FromUser"]);
                model.ToUser = Convert.ToString(ds.Tables[0].Rows[0]["ToUser"]);
                model.SentTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["SentTime"]);
                model.IsRead = Convert.ToInt32(ds.Tables[0].Rows[0]["IsRead"]);
                if (ds.Tables[0].Rows[0]["ReadTime"] == null || ds.Tables[0].Rows[0]["ReadTime"].ToString().Trim() == "")
                {
                    model.ReadTime = DateTime.Now;
                }
                else
                {
                    model.ReadTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReadTime"]);
                }
                if (ds.Tables[0].Rows[0]["Remark"] == null || ds.Tables[0].Rows[0]["Remark"].ToString().Trim() == "")
                {
                    model.Remark = "";
                }
                else
                {
                    model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                }

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
        /// <param name="ToUser"></param>
        /// <returns></returns>
        public Model.UserMessage GetModel(string ToUser)
        {
            string strSql = "select * from UserMessage where ToUser = '" + ToUser + "'";
            Model.UserMessage model = new Model.UserMessage();
            DataSet ds = DBHelperSQL.GetDataSet(strSql);
            model.ToUser = ToUser;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.level = Convert.ToInt32(ds.Tables[0].Rows[0]["level"]);
                model.Title = Convert.ToString(ds.Tables[0].Rows[0]["Title"]);
                model.Content = Convert.ToString(ds.Tables[0].Rows[0]["Content"]);
                model.FromUser = Convert.ToString(ds.Tables[0].Rows[0]["FromUser"]);
                model.ToUser = Convert.ToString(ds.Tables[0].Rows[0]["ToUser"]);

                model.IsRead = Convert.ToInt32(ds.Tables[0].Rows[0]["IsRead"]);
                model.SentTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["SentTime"]);
                if (ds.Tables[0].Rows[0]["ReadTime"] == null || ds.Tables[0].Rows[0]["ReadTime"].ToString().Trim() == "")
                {
                    model.ReadTime = DateTime.Now;
                }
                else
                {
                    model.ReadTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReadTime"]);
                }
                if (ds.Tables[0].Rows[0]["Remark"] == null || ds.Tables[0].Rows[0]["Remark"].ToString().Trim() == "")
                {
                    model.Remark = "";
                }
                else
                {
                    model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public System.Data.DataSet GetList(string strWhere)
        {
            string strSql = "select * from UserMessage where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql);
        }

        public static int GetRecordCount(string ToUser, string Content = "")
        {
            string strSql = "select count(*) from UserMessage where ToUser = '" + ToUser + "' and Content like '%" + Content + "%'";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }

        public static int UnreadCount(string ToUser)
        {
            string strSql = "select count(*) from UserMessage where ToUser = '" + ToUser + "' and IsRead=0";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
        /// <summary>
        /// 获得用户邮件信息
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList(int offset, int limit, string ToUser, string Content = "")
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM UserMessage w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM UserMessage where  ToUser = '" + ToUser + "' and Content like '%" + Content + "%' ORDER BY IsRead ASC) w ORDER BY w.IsRead DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.IsRead ASc";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefListNew(int offset, int limit, string sort = "SentTime", string order = "desc", string search = "", string strwhere = "1=1")
        {
            string deorder = order.ToLower() == "desc" ? "asc" : "desc";
            int endRecord = offset + limit;
            string sql = "SELECT * FROM UserMessage w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM UserMessage where Content like '%" + search + "%' and " + strwhere + " ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID ORDER BY w1.@sort @order";
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }

        public static int GetRecordCountNew(string search = "", string strwhere = "1=1")
        {
            string strSql = "select count(*) from UserMessage where Content like '%" + search + "%' and " + strwhere;
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }


        #endregion
    }
}
