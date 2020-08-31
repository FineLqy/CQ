using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ContractApplication
    {

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from ContractApplication where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
  
        /// <summary>
        /// 增加一个单位信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.ContractApplication model)
        {
            string strSql = "insert into ContractApplication(ID,UserName,Contacts,Phone,Address,Price,ContractFile,Type,ApplicationTime,Remark) values(@ID,@UserName,@Contacts,@Phone,@Address,@Price,@ContractFile,@Type,@ApplicationTime,@Remark)";

            SqlParameter ID = new SqlParameter("ID", SqlDbType.NVarChar); ID.Value = model.ID;
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter Contacts = new SqlParameter("Contacts", SqlDbType.NVarChar); Contacts.Value = model.Contacts;
            SqlParameter Phone = new SqlParameter("Phone", SqlDbType.NVarChar); Phone.Value = model.Phone;
            SqlParameter Address = new SqlParameter("Address", SqlDbType.NVarChar); Address.Value = model.Address;
            SqlParameter Price = new SqlParameter("Price", SqlDbType.NVarChar); Price.Value = model.Price;
            SqlParameter ContractFile = new SqlParameter("ContractFile", SqlDbType.NVarChar); ContractFile.Value = model.ContractFile;
            SqlParameter Type = new SqlParameter("Type", SqlDbType.NVarChar); Type.Value = model.Type;
            SqlParameter ApplicationTime = new SqlParameter("ApplicationTime", SqlDbType.NVarChar); ApplicationTime.Value = model.ApplicationTime;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;
            




            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { ID,UserName, Contacts, Phone, Address, Price, ContractFile, Type, ApplicationTime, Remark }, connectionString) == 1 ? true : false;
        }

    

        public static bool Update1(Model.ContractApplication model)
        {

            string strSql = "update ContractApplication set UserName=@UserName, Contacts=@Contacts, Phone=@Phone, Address=@Address, ContractFile=@ContractFile,Type=@Type,Price=@Price,ApplicationTime=@ApplicationTime,Remark=@Remark where ID = '" + model.ID.Trim().ToString() + "'";
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName; 
            SqlParameter Contacts = new SqlParameter("Contacts", SqlDbType.NVarChar); Contacts.Value = model.Contacts;
            SqlParameter Phone = new SqlParameter("Phone", SqlDbType.NVarChar); Phone.Value = model.Phone;
            SqlParameter Address = new SqlParameter("Address", SqlDbType.NVarChar); Address.Value = model.Address;
            SqlParameter ContractFile = new SqlParameter("ContractFile", SqlDbType.NVarChar); ContractFile.Value = model.ContractFile;
            SqlParameter Type = new SqlParameter("Type", SqlDbType.NVarChar); Type.Value = model.Type;
            SqlParameter Price = new SqlParameter("Price", SqlDbType.NVarChar); Price.Value = model.Price;
            SqlParameter ApplicationTime = new SqlParameter("ApplicationTime", SqlDbType.NVarChar); ApplicationTime.Value = model.ApplicationTime;
            SqlParameter Remark = new SqlParameter("Remark", SqlDbType.NVarChar); Remark.Value = model.Remark;

            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, Contacts, Phone, Address, ContractFile, Type,Price, ApplicationTime, Remark }, connectionString) == 1 ? true : false;

        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.ContractApplication GetModel(string id)
        {
            string strSql = "select * from ContractApplication where ID='"+id+"' ";
            Model.ContractApplication model = new Model.ContractApplication();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
         
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToString(ds.Tables[0].Rows[0]["ID"]);
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                model.Contacts = Convert.ToString(ds.Tables[0].Rows[0]["Contacts"]);
                model.Phone = Convert.ToString(ds.Tables[0].Rows[0]["Phone"]);
                model.Address = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                model.ContractFile = Convert.ToString(ds.Tables[0].Rows[0]["ContractFile"]);
                model.Type = Convert.ToString(ds.Tables[0].Rows[0]["Type"]); 
                model.Price = Convert.ToString(ds.Tables[0].Rows[0]["Price"]);
                model.ApplicationTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["ApplicationTime"]);
                model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);



                return model;
            }
            else
            {
                return null;
            }
        }

      


        public static bool Delete(int ID)
        {
            string strSql = "delete from ContractApplication where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(string  ID)
        {
            string strSql = "delete from ContractApplication where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from ContractApplication where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }
        public static DataSet GetListByDistinctUserName(string strWhere)
        {
            string strSql = "select distinct UserName from ContractApplication where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }


        public static int GetRecordCount(string search = "")
        {
            string strSql = "select count(*) from ContractApplication where ID like '%" + search + "%'";
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
            string sql = "SELECT * FROM ContractApplication w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM ContractApplication where ID like '%" + search + "%' ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList1(int offset, int limit, string sort = "CertificationTime", string order = "desc", string search = "")
        {
            string deorder = order.ToLower() == "desc" ? "asc" : "desc";
            int endRecord = offset + limit;
            string sql = "SELECT * FROM ContractApplication w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM ContractApplication where UserName like '%" + search + "%' ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID ORDER BY w1.@sort @order";
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }

    }
}
