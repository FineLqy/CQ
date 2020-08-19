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
    public class ResourcesDownload
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;


        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from ResourcesDownload where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(string ResourceName)
        {
            string strSql = "select count(*) from ResourcesDownload where ResourceName='" + ResourceName+"'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 添加一条新闻到数据库中
        /// </summary>
        /// <returns></returns>
        public static bool Add(Model.ResourcesDownload rd)
        {
            string strSql = "insert into ResourcesDownload(ResourceName,ResourcePath,DownloadTimes,UploadUser,UploadTime,IsDeleted,Remark) values(@ResourceName,@ResourcePath,@DownloadTimes,@UploadUser,@UploadTime,@IsDeleted,@Remark)";
            SqlParameter ResourceName = new SqlParameter("@ResourceName", SqlDbType.NVarChar, 50); ResourceName.Value = rd.ResourceName;
            SqlParameter ResourcePath = new SqlParameter("@ResourcePath", SqlDbType.NVarChar, 500);
            ResourcePath.Value = rd.ResourcePath;
            SqlParameter DownloadTimes = new SqlParameter("@DownloadTimes", SqlDbType.Int); DownloadTimes.Value = rd.DownloadTimes;
            SqlParameter UploadUser = new SqlParameter("@UploadUser", SqlDbType.VarChar,50);
            UploadUser.Value = rd.UploadUser;
            SqlParameter UploadTime = new SqlParameter("@UploadTime", SqlDbType.DateTime);
            UploadTime.Value = rd.UploadTime;
            SqlParameter IsDeleted = new SqlParameter("@IsDeleted", SqlDbType.Bit);
            IsDeleted.Value = rd.IsDeleted;
            SqlParameter Remark = new SqlParameter("@Remark", SqlDbType.NVarChar,500);
            Remark.Value = rd.Remark;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { ResourceName, ResourcePath, DownloadTimes, UploadUser, UploadTime, IsDeleted, Remark }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.ResourcesDownload GetModel(int ID)
        {
            string strSql = "select * from ResourcesDownload where ID = " + ID.ToString();
            Model.ResourcesDownload model = new Model.ResourcesDownload();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ResourceName = Convert.ToString(ds.Tables[0].Rows[0]["ResourceName"]);
                model.ResourcePath = Convert.ToString(ds.Tables[0].Rows[0]["ResourcePath"]);
                model.DownloadTimes = Convert.ToInt32(ds.Tables[0].Rows[0]["DownloadTimes"]);
                model.UploadUser = Convert.ToString(ds.Tables[0].Rows[0]["UploadUser"]);
                model.UploadTime = (DateTime)ds.Tables[0].Rows[0]["UploadTime"];
                model.IsDeleted = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsDeleted"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
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
            string strSql = "delete from ResourcesDownload where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
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
            string strSql = "delete from ResourcesDownload where " + delstr;
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }


        public static int GetRecordCount()
        {
            string strSql = "select count(*) from ResourcesDownload";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
        public static bool Update(Model.ResourcesDownload model)
        {
            string strSql = "update ResourcesDownload set ResourceName=@ResourceName where ID = " + model.ID.ToString();
            SqlParameter ResourceName = new SqlParameter("ResourceName", SqlDbType.NVarChar); ResourceName.Value = model.ResourceName;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { ResourceName }, connectionString) == 1 ? true : false;
        }

        
        public static DataSet GetList(string strWhere)
        {
            string strSql = "select ID,ResourceName,UploadUser,Remark from ResourcesDownload where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static DataSet GetFullList(string strWhere)
        {
            string strSql = "select * from ResourcesDownload where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

    }
}
