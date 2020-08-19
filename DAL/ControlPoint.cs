using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;


namespace DAL
{
    public class ControlPoint
    {

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from ControlPoint where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }


        /// <summary>
        /// 点名是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string MarkName)
        {
            string strSql = "select count(*) from ControlPoint where MarkName='" + MarkName + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        /// <summary>
        /// 点号是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string MarkID, int i = 0)
        {
            string strSql = "select count(*) from ControlPoint where MarkID='" + MarkID + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        /// <summary>
        /// 增加一个控制点信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.ControlPoint model)
        {
            string strSql = "insert into ControlPoint(MarkName,MarkID,AccuracyClass,B,L,H,GCgrade,BZ,PointRemark) values(@MarkName,@MarkID,@AccuracyClass,@B,@L,@H,@GCgrade,@BZ,@PointRemark)";
            SqlParameter MarkName = new SqlParameter("MarkName", SqlDbType.NVarChar); MarkName.Value = model.MarkName;
            SqlParameter MarkID = new SqlParameter("MarkID", SqlDbType.NVarChar); MarkID.Value = model.MarkID;
            SqlParameter AccuracyClass = new SqlParameter("AccuracyClass", SqlDbType.NVarChar); AccuracyClass.Value = model.AccuracyClass;
            SqlParameter B = new SqlParameter("B", SqlDbType.Float); B.Value = model.B;
            SqlParameter L = new SqlParameter("L", SqlDbType.Float); L.Value = model.L;
            SqlParameter H = new SqlParameter("H", SqlDbType.Float); H.Value = model.H;

            SqlParameter GCgrade = new SqlParameter("GCgrade", SqlDbType.NVarChar); GCgrade.Value = model.GCgrade;
            SqlParameter BZ = new SqlParameter("BZ", SqlDbType.NVarChar); BZ.Value = model.BZ;
            SqlParameter PointRemark = new SqlParameter("PointRemark", SqlDbType.NVarChar); PointRemark.Value = model.PointRemark;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { MarkName, MarkID, AccuracyClass, B, L, H, GCgrade, BZ, PointRemark }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.ControlPoint model)
        {
            string strSql = "update ControlPoint set MarkName=@MarkName,MarkID=@MarkID,AccuracyClass=@AccuracyClass,B=@B,L=@L,H=@H,GCgrade=@GCgrade,BZ=@BZ,PointRemark=@PointRemark where ID = " + model.ID.ToString();
            SqlParameter MarkName = new SqlParameter("MarkName", SqlDbType.NVarChar); MarkName.Value = model.MarkName;
            SqlParameter MarkID = new SqlParameter("MarkID", SqlDbType.NVarChar); MarkID.Value = model.MarkID;
            SqlParameter AccuracyClass = new SqlParameter("AccuracyClass", SqlDbType.NVarChar); AccuracyClass.Value = model.AccuracyClass;
            SqlParameter B = new SqlParameter("B", SqlDbType.Float); B.Value = model.B;
            SqlParameter L = new SqlParameter("L", SqlDbType.Float); L.Value = model.L;
            SqlParameter H = new SqlParameter("H", SqlDbType.Float); H.Value = model.H;

            SqlParameter GCgrade = new SqlParameter("GCgrade", SqlDbType.NVarChar); GCgrade.Value = model.GCgrade;
            SqlParameter BZ = new SqlParameter("BZ", SqlDbType.NVarChar); BZ.Value = model.BZ;
            SqlParameter PointRemark = new SqlParameter("PointRemark", SqlDbType.NVarChar); PointRemark.Value = model.PointRemark;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { MarkName, MarkID, AccuracyClass, B, L, H, GCgrade, BZ, PointRemark }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.ControlPoint GetModel(string MarkName)
        {
            string strSql = "select * from ControlPoint where MarkName = '" + MarkName + "'";
            Model.ControlPoint model = new Model.ControlPoint();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.MarkName = MarkName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.MarkID = Convert.ToString(ds.Tables[0].Rows[0]["MarkID"]);
                model.AccuracyClass = Convert.ToString(ds.Tables[0].Rows[0]["AccuracyClass"]);
                model.B = Convert.ToDouble(ds.Tables[0].Rows[0]["B"]);
                model.L = Convert.ToDouble(ds.Tables[0].Rows[0]["L"]);
                try
                {
                    model.H = Convert.ToDouble(ds.Tables[0].Rows[0]["H"]);
                }
                catch (Exception)
                {
                    // model.H = 0;
                }

                model.GCgrade = Convert.ToString(ds.Tables[0].Rows[0]["GCgrade"]);
                model.BZ = Convert.ToString(ds.Tables[0].Rows[0]["BZ"]);
                model.PointRemark = Convert.ToString(ds.Tables[0].Rows[0]["PointRemark"]);

                return model;
            }
            else
            {
                return null;
            }
        }

        public static Model.ControlPoint GetModel(int ID)
        {
            string strSql = "select * from ControlPoint where ID = '" + ID + "'";
            Model.ControlPoint model = new Model.ControlPoint();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.MarkName = Convert.ToString(ds.Tables[0].Rows[0]["MarkName"]);
                model.MarkID = Convert.ToString(ds.Tables[0].Rows[0]["MarkID"]);
                model.AccuracyClass = Convert.ToString(ds.Tables[0].Rows[0]["AccuracyClass"]);
                model.B = Convert.ToDouble(ds.Tables[0].Rows[0]["B"]);
                model.L = Convert.ToDouble(ds.Tables[0].Rows[0]["L"]);
                try
                {
                    model.H = Convert.ToDouble(ds.Tables[0].Rows[0]["H"]);
                }
                catch (Exception)
                {
                    //model.H = 0;
                }
                model.GCgrade = Convert.ToString(ds.Tables[0].Rows[0]["GCgrade"]);
                model.BZ = Convert.ToString(ds.Tables[0].Rows[0]["BZ"]);
                model.PointRemark = Convert.ToString(ds.Tables[0].Rows[0]["PointRemark"]);
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
        public static bool Delete(string MarkName)
        {
            string strSql = "delete from ControlPoint where MarkName ='" + MarkName + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int ID)
        {
            string strSql = "delete from ControlPoint where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from ControlPoint where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static int GetRecordCount(string search = "")
        {
            string strSql = "select count(*) from ControlPoint where MarkName like '%" + search + "%'";
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
            string sql = "SELECT * FROM ControlPoint w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM ControlPoint where MarkName like '%" + search + "%' ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList1(int offset, int limit, string sort = "MarkName", string order = "desc", string search = "")
        {
            string deorder = order.ToLower() == "desc" ? "asc" : "desc";
            int endRecord = offset + limit;
            string sql = "SELECT * FROM ControlPoint w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM ControlPoint where MarkName like '%" + search + "%' ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID ORDER BY w1.@sort @order";
            sql = sql.Replace("@sort", sort);

            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);

            return DBHelperSQL.GetDataSet(sql, connectionString);
        }

    }
}
