using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
namespace DAL
{
    public class EquipReviceRecord
    {
        public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        /// <summary>
        ///  是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select * from EquipReviceRecord where ID ='" + ID + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 所属模块是否存在
        /// </summary>
        /// <param name="Information"></param>
        /// <returns></returns>
        public static bool Exists(string Information)
        {
            string strSql = "select * from EquipReviceRecord where Information = '" + Information + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 添加一条修改记录信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.EquipReviceRecord model)
        {
            string strSql = "insert into EquipReviceRecord(ReviceTime,RevicePerson,Contents,Information,ReviceID) values(@ReviceTime,@RevicePerson,@Contents,@Information,@ReviceID)";
            SqlParameter ReviceTime = new SqlParameter("ReviceTime", SqlDbType.DateTime); ReviceTime.Value = model.ReviceTime;
            SqlParameter RevicePerson = new SqlParameter("RevicePerson", SqlDbType.NVarChar); RevicePerson.Value = model.RevicePerson;
            SqlParameter Contents = new SqlParameter("Contents", SqlDbType.NVarChar); Contents.Value = model.Contents;
            SqlParameter Information = new SqlParameter("Information", SqlDbType.NVarChar); Information.Value = model.Information;
            SqlParameter ReviceID = new SqlParameter("ReviceID", SqlDbType.NVarChar); ReviceID.Value = model.ReviceID;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { ReviceTime, RevicePerson, Contents, Information, ReviceID }, connectionString) == 1 ? true : false;
        }
        /// <summary>
        /// 更新一条修改记录信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.EquipReviceRecord model)
        {
            string strSql = "update EquipReviceRecord set ReviceTime=@ReviceTime,RevicePerson=@RevicePerson,Contents=@Contents,Information=@Information,ReviceID=@ReviceID where ID ='" + model.ID + "'";
            SqlParameter ReviceTime = new SqlParameter("ReviceTime", SqlDbType.DateTime); ReviceTime.Value = model.ReviceTime;
            SqlParameter RevicePerson = new SqlParameter("RevicePerson", SqlDbType.NVarChar); RevicePerson.Value = model.RevicePerson;
            SqlParameter Contents = new SqlParameter("Contents", SqlDbType.NVarChar); Contents.Value = model.Contents;
            SqlParameter Information = new SqlParameter("Information", SqlDbType.NVarChar); Information.Value = model.Information;
            SqlParameter ReviceID = new SqlParameter("ReviceID", SqlDbType.NVarChar); ReviceID.Value = model.ReviceID;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { ReviceTime, RevicePerson, Contents, Information, ReviceID }, connectionString) == 1 ? true : false;
        }
        /// <summary>
        /// 根据ID获取一条信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Model.EquipReviceRecord GetModel(int ID)
        {
            string strSql = "select * from EquipReviceRecord where ID ='" + ID + "'";
            Model.EquipReviceRecord model = new Model.EquipReviceRecord();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ReviceTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReviceTime"]);
                model.RevicePerson = Convert.ToString(ds.Tables[0].Rows[0]["RevicePerson"]);
                model.Information = Convert.ToString(ds.Tables[0].Rows[0]["Information"]);
                model.Contents = Convert.ToString(ds.Tables[0].Rows[0]["Contents"]);
                model.ReviceID = Convert.ToString(ds.Tables[0].Rows[0]["ReviceID"]);
                return model;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 根据Information获取一条信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static Model.EquipReviceRecord GetModel(string ReviceID)
        {
            string strSql = "select * from EquipReviceRecord where ReviceID ='" + ReviceID + "'";
            Model.EquipReviceRecord model = new Model.EquipReviceRecord();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ReviceID = ReviceID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ReviceTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReviceTime"]);
                model.RevicePerson = Convert.ToString(ds.Tables[0].Rows[0]["RevicePerson"]);
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.Contents = Convert.ToString(ds.Tables[0].Rows[0]["Contents"]);
                model.Information = Convert.ToString(ds.Tables[0].Rows[0]["Information"]);
                return model;
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 根据ID删除记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Delete(int ID)
        {
            string strSql = "delete from EquipReviceRecord where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        
        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from EquipReviceRecord where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
        public static DataSet GetList()
        {
            string strSql = "select * from EquipReviceRecord";

            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static DataSet GetBriefList(int offset, int limit, string sort = "ReviceTime", string order = "desc", string Information = "")
        {
            string deorder = order.ToLower() == "desc" ? "asc" : "desc";
            int endRecord = offset + limit;
            string sql = "SELECT * FROM EquipReviceRecord w1,( SELECT TOP @limit w.ID FROM( SELECT TOP  @endRecord * FROM EquipReviceRecord where Information like '%@search%' ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID  ORDER BY w1.@sort @order";
            sql = sql.Replace("@limit", limit.ToString());
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@endRecord", endRecord.ToString());
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            sql = sql.Replace("@search", Information);
            DataSet ds = DBHelperSQL.GetDataSet(sql, connectionString);
            return ds;
           
          
        }
        public static int GetRecordCount(string Information="")
        {
            string strSql = "select count(*) from EquipReviceRecord where Information like '%"+Information+"%'";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }


    }
}
