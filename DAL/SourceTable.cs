using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class SourceTable
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from SourceTable where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        public static bool Exists(string Source)
        {
            string strSql = "select count(*) from SourceTable where Source='" + Source+"'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        public static bool Add(Model.SourceTable model)
        {
            string strSql = "insert into SourceTable(Source,SourceType) values(@Source,@SourceType)";
            SqlParameter Source = new SqlParameter("Source", SqlDbType.VarChar); Source.Value = model.Source;
            SqlParameter SourceType = new SqlParameter("SourceType", SqlDbType.NVarChar); SourceType.Value = model.SourceType;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { Source,SourceType }, connectionString) == 1 ? true : false;
        }

        public static bool Update(Model.SourceTable model)
        {
            string strSql = "update SourceTable set Source=@Source,SourceType=@SourceType where ID = " + model.ID.ToString();
            SqlParameter Source = new SqlParameter("Source", SqlDbType.VarChar); Source.Value = model.Source;
            SqlParameter SourceType = new SqlParameter("SourceType", SqlDbType.NVarChar); SourceType.Value = model.SourceType;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { Source, SourceType }, connectionString) == 1 ? true : false;

        }

        public static bool Delete(string Source)
        {
            string strSql = "delete from SourceTable where Source ='" + Source + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static bool Delete(int ID)
        {
            string strSql = "delete from SourceTable where ID =" + ID.ToString();
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from SourceTable where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
        public static DataSet GetList()
        {
            string strSql = "select * from SourceTable";
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static Model.SourceTable GetModel(int ID)
        {
            string strSql = "select * from SourceTable where ID = '" + ID.ToString() + "'";
            Model.SourceTable model = new Model.SourceTable();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Source = Convert.ToString(ds.Tables[0].Rows[0]["Source"]);
                model.SourceType = Convert.ToString(ds.Tables[0].Rows[0]["SourceType"]);
                return model;
            }
            else
            {
                return null;
            }

        }
        public static Model.SourceTable GetModel(string Source)
        {
            string strSql = "select * from SourceTable where Source = '" + Source + "'";
            Model.SourceTable model = new Model.SourceTable();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.Source = Source;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.SourceType = Convert.ToString(ds.Tables[0].Rows[0]["SourceType"]);
                return model;
            }
            else
            {
                return null;
            }

        }
        
       
        public static DataSet GetBriefList(int offset, int limit)
        {
            int endRecord = offset + limit;
            string sql = "SELECT w1.ID,w1.Source,w1.SourceType FROM SourceTable w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + " ID,Source,SourceType FROM SourceTable ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        public static int GetRecordCount()
        {
            string strSql = "select count(*) from SourceTable";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }

    }
}
