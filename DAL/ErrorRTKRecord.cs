using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class ErrorRTKRecord
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        public static int GetRecordCount(string UserName = "")
        {
            string strSql = "select count(*) from ErrorRTKRecord where UserName like '%" + UserName + "%'";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
        public static DataSet GetBriefList(int offset, int limit, string search = "", string strwhere = "")
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM ErrorRTKRecord w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM ErrorRTKRecord where UserName like '%" + search + "%' and " + strwhere + "  ORDER BY ID DESC) w ORDER BY w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID DESC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        public static Model.ErrorRTKRecord GetModel(int ID)
        {
            string strSql = "select * from ErrorRTKRecord where ID = '" + ID + "'";
            Model.ErrorRTKRecord model = new Model.ErrorRTKRecord();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                model.Company = Convert.ToString(ds.Tables[0].Rows[0]["Company"]);
                model.ErrorTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["ErrorTime"]);
                model.ErrorType = Convert.ToInt32(ds.Tables[0].Rows[0]["ErrorType"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
              
           
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
