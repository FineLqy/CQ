using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class StationDownLog
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
        public static int GetRecordCount(string StationOName = "")
        {
            string strSql = "select count(*) from StationDownLog where StationOName like '%" + StationOName + "%'";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
        public static DataSet GetBriefList(int offset, int limit, string search = "", string strwhere = "")
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM StationDownLog w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM StationDownLog where StationOName like '%" + search + "%' and " + strwhere + "  ORDER BY ID DESC) w ORDER BY w.ID ASC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID DESC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        public static Model.StationDownLog GetModel(int ID)
        {
            string strSql = "select * from StationDownLog where ID = '" + ID + "'";
            Model.StationDownLog model = new Model.StationDownLog();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.StationOName = Convert.ToString(ds.Tables[0].Rows[0]["StationOName"]);
                model.DownTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["DownTime"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                model.FaultType = Convert.ToInt32(ds.Tables[0].Rows[0]["FaultType"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        public static DataSet GetNum()
        {

            string sql = "Select top 5  StationOName ,Count(*) 'Num' From StationDownLog    Group By StationOName  Having Count(*) >= 1  ORDER BY Num asc";
            return DBHelperSQL.GetDataSet(sql);
        }
        public static DataSet GetDateNum(string st,string et)
        {

            string sql = "Select top 5  StationOName ,Count(*) 'Num' From StationDownLog where DownTime>='"+st+"' and DownTime<='"+et+"'    Group By StationOName  Having Count(*) >= 1  ORDER BY Num asc";
            return DBHelperSQL.GetDataSet(sql);
        }
        public static DataSet GetCount()
        {

            string sql = "select year(DownTime)'Datayear' ,Count(*) 'Num' from StationDownLog   group by year(DownTime)";
            return DBHelperSQL.GetDataSet(sql);
        }
    }
}
