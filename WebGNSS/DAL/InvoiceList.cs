using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
   
    public class InvoiceList
    {

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from InvoiceList where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string OrderNumber)
        {
            string strSql = "select count(*) from InvoiceList where OrderNumber='" + OrderNumber + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.InvoiceList model)
        {
            string strSql = "insert into InvoiceList( UserName, OrderNumber, OrderDetail, Price, SubmitTime, DealTime, PayTime, Status, InvoiceInfoIndex, InvoiceType, IssueType, InvoiceFile,ContractFile,ContractStatus,BelongArea) values( @UserName, @OrderNumber, @OrderDetail, @Price, @SubmitTime, @DealTime, @PayTime, @Status, @InvoiceInfoIndex, @InvoiceType, @IssueType, @InvoiceFile,@ContractFile,@ContractStatus,@BelongArea) ";
            SqlParameter OrderNumber = new SqlParameter("OrderNumber", SqlDbType.NVarChar); OrderNumber.Value = model.OrderNumber;
            SqlParameter OrderDetail = new SqlParameter("OrderDetail", SqlDbType.NVarChar); OrderDetail.Value = model.OrderDetail;
            SqlParameter Price = new SqlParameter("Price", SqlDbType.NVarChar); Price.Value = model.Price;
            SqlParameter SubmitTime = new SqlParameter("SubmitTime", SqlDbType.DateTime); SubmitTime.Value = model.SubmitTime;
            SqlParameter DealTime = new SqlParameter("DealTime", SqlDbType.DateTime); DealTime.Value = model.DealTime;
            SqlParameter PayTime = new SqlParameter("PayTime", SqlDbType.DateTime); PayTime.Value = model.PayTime;
            SqlParameter Status = new SqlParameter("Status", SqlDbType.Int); Status.Value = model.Status;
            SqlParameter InvoiceInfoIndex = new SqlParameter("InvoiceInfoIndex", SqlDbType.NVarChar); InvoiceInfoIndex.Value = model.InvoiceInfoIndex;
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter InvoiceType = new SqlParameter("InvoiceType", SqlDbType.Int); InvoiceType.Value = model.InvoiceType;
            SqlParameter IssueType = new SqlParameter("IssueType", SqlDbType.Int); IssueType.Value = model.IssueType;
            SqlParameter InvoiceFile = new SqlParameter("InvoiceFile", SqlDbType.NVarChar); InvoiceFile.Value = model.InvoiceFile;
            SqlParameter ContractFile = new SqlParameter("ContractFile", SqlDbType.NVarChar); ContractFile.Value = model.ContractFile;
            SqlParameter ContractStatus = new SqlParameter("ContractStatus", SqlDbType.Int); ContractStatus.Value = model.ContractStatus;
            SqlParameter BelongArea = new SqlParameter("BelongArea", SqlDbType.NVarChar); BelongArea.Value = model.BelongArea;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, OrderNumber, OrderDetail, Price, SubmitTime, DealTime, PayTime, Status, InvoiceInfoIndex, InvoiceType, IssueType, InvoiceFile, ContractFile, ContractStatus,BelongArea }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.InvoiceList model)
        {
            string strSql = "update InvoiceList set UserName=@UserName, OrderNumber=@OrderNumber, OrderDetail=@OrderDetail, Price=@Price, SubmitTime=@SubmitTime, DealTime=@DealTime, PayTime=@PayTime, Status=@Status, InvoiceInfoIndex=@InvoiceInfoIndex, InvoiceType=@InvoiceType, IssueType=@IssueType, InvoiceFile=@InvoiceFile,ContractFile=@ContractFile,ContractStatus=@ContractStatus,BelongArea=@BelongArea where ID = " + model.ID.ToString();
            SqlParameter OrderNumber = new SqlParameter("OrderNumber", SqlDbType.NVarChar); OrderNumber.Value = model.OrderNumber;
            SqlParameter OrderDetail = new SqlParameter("OrderDetail", SqlDbType.NVarChar); OrderDetail.Value = model.OrderDetail;
            SqlParameter Price = new SqlParameter("Price", SqlDbType.NVarChar); Price.Value = model.Price;
            SqlParameter SubmitTime = new SqlParameter("SubmitTime", SqlDbType.DateTime); SubmitTime.Value = model.SubmitTime;
            SqlParameter DealTime = new SqlParameter("DealTime", SqlDbType.DateTime); DealTime.Value = model.DealTime;
            SqlParameter PayTime = new SqlParameter("PayTime", SqlDbType.DateTime); PayTime.Value = model.PayTime;
            SqlParameter Status = new SqlParameter("Status", SqlDbType.Int); Status.Value = model.Status;
            SqlParameter InvoiceInfoIndex = new SqlParameter("InvoiceInfoIndex", SqlDbType.NVarChar); InvoiceInfoIndex.Value = model.InvoiceInfoIndex;
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter InvoiceType = new SqlParameter("InvoiceType", SqlDbType.Int); InvoiceType.Value = model.InvoiceType;
            SqlParameter IssueType = new SqlParameter("IssueType", SqlDbType.Int); IssueType.Value = model.IssueType;
            SqlParameter InvoiceFile = new SqlParameter("InvoiceFile", SqlDbType.NVarChar); InvoiceFile.Value = model.InvoiceFile;
            SqlParameter ContractFile = new SqlParameter("ContractFile", SqlDbType.NVarChar); ContractFile.Value = model.ContractFile;
            SqlParameter ContractStatus = new SqlParameter("ContractStatus", SqlDbType.Int); ContractStatus.Value = model.ContractStatus;
            SqlParameter BelongArea = new SqlParameter("BelongArea", SqlDbType.NVarChar); BelongArea.Value = model.BelongArea;

            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, OrderNumber, OrderDetail, Price, SubmitTime, DealTime, PayTime, Status, InvoiceInfoIndex, InvoiceType, IssueType, InvoiceFile,ContractFile,ContractStatus,BelongArea }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.InvoiceList GetModel(string OrderNumber)
        {
            string strSql = "select * from InvoiceList where OrderNumber = '" + OrderNumber + "'";
            Model.InvoiceList model = new Model.InvoiceList();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.OrderNumber = OrderNumber;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.OrderDetail = Convert.ToString(ds.Tables[0].Rows[0]["OrderDetail"]);
                model.Price = Convert.ToString(ds.Tables[0].Rows[0]["Price"]);
                model.SubmitTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["SubmitTime"]);
                model.DealTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["DealTime"]);
                model.PayTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["PayTime"]);
                model.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                model.InvoiceInfoIndex = Convert.ToString(ds.Tables[0].Rows[0]["InvoiceInfoIndex"]);
                model.InvoiceType = Convert.ToInt32(ds.Tables[0].Rows[0]["InvoiceType"]);
                model.IssueType = Convert.ToInt32(ds.Tables[0].Rows[0]["IssueType"]);
                model.InvoiceFile = Convert.ToString(ds.Tables[0].Rows[0]["InvoiceFile"]);
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                model.ContractFile = Convert.ToString(ds.Tables[0].Rows[0]["ContractFile"]);
                model.ContractStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["ContractStatus"]);
                model.BelongArea = Convert.ToString(ds.Tables[0].Rows[0]["BelongArea"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        public static Model.InvoiceList GetModel(int ID)
        {
            string strSql = "select * from InvoiceList where ID = '" + ID + "'";
            Model.InvoiceList model = new Model.InvoiceList();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.OrderNumber = Convert.ToString(ds.Tables[0].Rows[0]["OrderNumber"]);
                model.OrderDetail = Convert.ToString(ds.Tables[0].Rows[0]["OrderDetail"]);
                model.Price = Convert.ToString(ds.Tables[0].Rows[0]["Price"]);
                model.SubmitTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["SubmitTime"]);
                model.DealTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["DealTime"]);
                model.PayTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["PayTime"]);
                model.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                model.InvoiceInfoIndex = Convert.ToString(ds.Tables[0].Rows[0]["InvoiceInfoIndex"]);
                model.InvoiceType = Convert.ToInt32(ds.Tables[0].Rows[0]["InvoiceType"]);
                model.IssueType = Convert.ToInt32(ds.Tables[0].Rows[0]["IssueType"]);
                model.InvoiceFile = Convert.ToString(ds.Tables[0].Rows[0]["InvoiceFile"]);
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                model.ContractFile = Convert.ToString(ds.Tables[0].Rows[0]["ContractFile"]);
                model.ContractStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["ContractStatus"]);
                model.BelongArea = Convert.ToString(ds.Tables[0].Rows[0]["BelongArea"]);

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
        public static bool Delete(string OrderNumber)
        {
            string strSql = "delete from InvoiceList where OrderNumber ='" + OrderNumber + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int ID)
        {
            string strSql = "delete from InvoiceList where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from InvoiceList where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static int GetRecordCount(string search = "",string strwhere="1=1")
        {
            string strSql = "select count(*) from InvoiceList where OrderNumber like '%" + search + "%' and " + strwhere;
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
        /// <summary>
        /// ssssssssssssssss
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList(int offset, int limit, string search = "")
        {
            int endRecord = offset + limit;
            string sql = "SELECT * FROM InvoiceList w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM InvoiceList where OrderNumber like '%" + search + "%' ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset">记录开始位置</param>
        /// <param name="limit">每页记录条数</param>
        /// <returns></returns>
        public static DataSet GetBriefList1(int offset, int limit, string sort = "SubmitTime", string order = "desc", string search = "",string strwhere="1=1")
        {
            string deorder = order.ToLower() == "desc" ? "asc" : "desc";
            int endRecord = offset + limit;
            string sql = "SELECT * FROM InvoiceList w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM InvoiceList where OrderNumber like '%" + search + "%' and "+strwhere+" ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID ORDER BY w1.@sort @order";
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }

    }
}
