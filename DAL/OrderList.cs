using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    
    public class OrderList
    {

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from OrderList where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }

        public static int Getcount()
        {
            string strSql = "select count(*) from OrderList where OrderStatus=1";
            return Convert.ToInt32(DBHelperSQL.GetResult(strSql, connectionString));
        }
        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string OrderNumber)
        {
            string strSql = "select count(*) from OrderList where OrderNumber='" + OrderNumber + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.OrderList model)
        {
            string strSql = "insert into OrderList( UserName, OrderNumber, SubmitTime, OrderStatus, WorkArea, ServerType, CoorTransEnable, HeightTransEnable, SHPTransEnable, DXFTransEnable, PPPserverEnable, ObsQualityEnable, BaseLineEnable, MultiBaseLineEnable, CoorSystemEnable, RoamingServiceArea, RoamingServiceEnable, AccountNum, ServiceDuration, Price, Dealer, DealTime, PayMethod, TransferCertificate, PayTime,RoamID,company,OrderContent,OrdeType,ElevationEnable,IsRenew) values( @UserName, @OrderNumber, @SubmitTime, @OrderStatus, @WorkArea, @ServerType, @CoorTransEnable, @HeightTransEnable, @SHPTransEnable, @DXFTransEnable, @PPPserverEnable, @ObsQualityEnable, @BaseLineEnable, @MultiBaseLineEnable, @CoorSystemEnable, @RoamingServiceArea, @RoamingServiceEnable, @AccountNum, @ServiceDuration, @Price, @Dealer, @DealTime, @PayMethod, @TransferCertificate, @PayTime,@RoamID,@company,@OrderContent,@OrdeType,@ElevationEnable,@IsRenew)";
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter OrderNumber = new SqlParameter("OrderNumber", SqlDbType.NVarChar); OrderNumber.Value = model.OrderNumber;
            SqlParameter SubmitTime = new SqlParameter("SubmitTime", SqlDbType.DateTime); SubmitTime.Value = model.SubmitTime;
            SqlParameter OrderStatus = new SqlParameter("OrderStatus", SqlDbType.Int); OrderStatus.Value = model.OrderStatus;
            SqlParameter WorkArea = new SqlParameter("WorkArea", SqlDbType.NVarChar); WorkArea.Value = model.WorkArea;
            SqlParameter ServerType = new SqlParameter("ServerType", SqlDbType.NVarChar); ServerType.Value = model.ServerType;
            SqlParameter CoorTransEnable = new SqlParameter("CoorTransEnable", SqlDbType.Int); CoorTransEnable.Value = model.CoorTransEnable;
            SqlParameter HeightTransEnable = new SqlParameter("HeightTransEnable", SqlDbType.Int); HeightTransEnable.Value = model.HeightTransEnable;
            SqlParameter SHPTransEnable = new SqlParameter("SHPTransEnable", SqlDbType.Int); SHPTransEnable.Value = model.SHPTransEnable;
            SqlParameter DXFTransEnable = new SqlParameter("DXFTransEnable", SqlDbType.Int); DXFTransEnable.Value = model.DXFTransEnable;
            SqlParameter PPPserverEnable = new SqlParameter("PPPserverEnable", SqlDbType.Int); PPPserverEnable.Value = model.PPPserverEnable;
            SqlParameter ObsQualityEnable = new SqlParameter("ObsQualityEnable", SqlDbType.Int); ObsQualityEnable.Value = model.ObsQualityEnable;
            SqlParameter BaseLineEnable = new SqlParameter("BaseLineEnable", SqlDbType.Int); BaseLineEnable.Value = model.BaseLineEnable;
            SqlParameter MultiBaseLineEnable = new SqlParameter("MultiBaseLineEnable", SqlDbType.Int); MultiBaseLineEnable.Value = model.MultiBaseLineEnable;
            SqlParameter CoorSystemEnable = new SqlParameter("CoorSystemEnable", SqlDbType.Int); CoorSystemEnable.Value = model.CoorSystemEnable;
            SqlParameter RoamingServiceEnable = new SqlParameter("RoamingServiceEnable", SqlDbType.Int); RoamingServiceEnable.Value = model.RoamingServiceEnable;
            SqlParameter RoamingServiceArea = new SqlParameter("RoamingServiceArea", SqlDbType.NVarChar); RoamingServiceArea.Value = model.RoamingServiceArea;
            SqlParameter AccountNum = new SqlParameter("AccountNum", SqlDbType.Int); AccountNum.Value = model.AccountNum;
            SqlParameter ServiceDuration = new SqlParameter("ServiceDuration", SqlDbType.NVarChar); ServiceDuration.Value = model.ServiceDuration;
            SqlParameter Price = new SqlParameter("Price", SqlDbType.NVarChar); Price.Value = model.Price;
            SqlParameter Dealer = new SqlParameter("Dealer", SqlDbType.NVarChar); Dealer.Value = model.Dealer;
            SqlParameter DealTime = new SqlParameter("DealTime", SqlDbType.DateTime); DealTime.Value = model.DealTime;
            SqlParameter PayTime = new SqlParameter("PayTime", SqlDbType.DateTime); PayTime.Value = model.PayTime;
            SqlParameter TransferCertificate = new SqlParameter("TransferCertificate", SqlDbType.NVarChar); TransferCertificate.Value = model.TransferCertificate;
            SqlParameter PayMethod = new SqlParameter("PayMethod", SqlDbType.NVarChar); PayMethod.Value = model.PayMethod;
            SqlParameter RoamID = new SqlParameter("RoamID", SqlDbType.NVarChar); RoamID.Value = model.RoamID;
            SqlParameter company = new SqlParameter("company", SqlDbType.NVarChar); company.Value = model.company;
            SqlParameter OrderContent = new SqlParameter("OrderContent", SqlDbType.NVarChar); OrderContent.Value = model.OrderContent;
            SqlParameter OrdeType = new SqlParameter("OrdeType", SqlDbType.NVarChar); OrdeType.Value = model.OrdeType;
            SqlParameter ElevationEnable = new SqlParameter("ElevationEnable", SqlDbType.NVarChar); ElevationEnable.Value = model.ElevationEnable;
            SqlParameter IsRenew = new SqlParameter("IsRenew", SqlDbType.NVarChar); IsRenew.Value = model.IsRenew;
            


            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, OrderNumber, SubmitTime, OrderStatus, WorkArea, ServerType, CoorTransEnable, HeightTransEnable, SHPTransEnable, DXFTransEnable, PPPserverEnable, ObsQualityEnable, BaseLineEnable, MultiBaseLineEnable, CoorSystemEnable, RoamingServiceArea, RoamingServiceEnable, AccountNum, ServiceDuration, Price, Dealer, DealTime, PayMethod, TransferCertificate, PayTime,RoamID, company, OrderContent, OrdeType, ElevationEnable, IsRenew }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.OrderList model)
        {
            string strSql = "update OrderList set UserName=@UserName, OrderNumber=@OrderNumber, SubmitTime=@SubmitTime, OrderStatus=@OrderStatus, WorkArea=@WorkArea, ServerType=@ServerType, CoorTransEnable=@CoorTransEnable, HeightTransEnable=@HeightTransEnable, SHPTransEnable=@SHPTransEnable, DXFTransEnable=@DXFTransEnable, PPPserverEnable=@PPPserverEnable, ObsQualityEnable=@ObsQualityEnable, BaseLineEnable=@BaseLineEnable, MultiBaseLineEnable=@MultiBaseLineEnable, CoorSystemEnable=@CoorSystemEnable, RoamingServiceArea=@RoamingServiceArea, RoamingServiceEnable=@RoamingServiceEnable, AccountNum=@AccountNum, ServiceDuration=@ServiceDuration, Price=@Price, Dealer=@Dealer, DealTime=@DealTime, PayMethod=@PayMethod, TransferCertificate=@TransferCertificate, PayTime=@PayTime,company=@company where ID = " + model.ID.ToString();
            SqlParameter UserName = new SqlParameter("UserName", SqlDbType.NVarChar); UserName.Value = model.UserName;
            SqlParameter OrderNumber = new SqlParameter("OrderNumber", SqlDbType.NVarChar); OrderNumber.Value = model.OrderNumber;
            SqlParameter SubmitTime = new SqlParameter("SubmitTime", SqlDbType.DateTime); SubmitTime.Value = model.SubmitTime;
            SqlParameter OrderStatus = new SqlParameter("OrderStatus", SqlDbType.Int); OrderStatus.Value = model.OrderStatus;
            SqlParameter WorkArea = new SqlParameter("WorkArea", SqlDbType.NVarChar); WorkArea.Value = model.WorkArea;
            SqlParameter ServerType = new SqlParameter("ServerType", SqlDbType.NVarChar); ServerType.Value = model.ServerType;
            SqlParameter CoorTransEnable = new SqlParameter("CoorTransEnable", SqlDbType.Int); CoorTransEnable.Value = model.CoorTransEnable;
            SqlParameter HeightTransEnable = new SqlParameter("HeightTransEnable", SqlDbType.Int); HeightTransEnable.Value = model.HeightTransEnable;
            SqlParameter SHPTransEnable = new SqlParameter("SHPTransEnable", SqlDbType.Int); SHPTransEnable.Value = model.SHPTransEnable;
            SqlParameter DXFTransEnable = new SqlParameter("DXFTransEnable", SqlDbType.Int); DXFTransEnable.Value = model.DXFTransEnable;
            SqlParameter PPPserverEnable = new SqlParameter("PPPserverEnable", SqlDbType.Int); PPPserverEnable.Value = model.PPPserverEnable;
            SqlParameter ObsQualityEnable = new SqlParameter("ObsQualityEnable", SqlDbType.Int); ObsQualityEnable.Value = model.ObsQualityEnable;
            SqlParameter BaseLineEnable = new SqlParameter("BaseLineEnable", SqlDbType.Int); BaseLineEnable.Value = model.BaseLineEnable;
            SqlParameter MultiBaseLineEnable = new SqlParameter("MultiBaseLineEnable", SqlDbType.Int); MultiBaseLineEnable.Value = model.MultiBaseLineEnable;
            SqlParameter CoorSystemEnable = new SqlParameter("CoorSystemEnable", SqlDbType.Int); CoorSystemEnable.Value = model.CoorSystemEnable;
            SqlParameter RoamingServiceEnable = new SqlParameter("RoamingServiceEnable", SqlDbType.Int); RoamingServiceEnable.Value = model.RoamingServiceEnable;
            SqlParameter RoamingServiceArea = new SqlParameter("RoamingServiceArea", SqlDbType.NVarChar); RoamingServiceArea.Value = model.RoamingServiceArea;
            SqlParameter AccountNum = new SqlParameter("AccountNum", SqlDbType.Int); AccountNum.Value = model.AccountNum;
            SqlParameter ServiceDuration = new SqlParameter("ServiceDuration", SqlDbType.NVarChar); ServiceDuration.Value = model.ServiceDuration;
            SqlParameter Price = new SqlParameter("Price", SqlDbType.NVarChar); Price.Value = model.Price;
            SqlParameter Dealer = new SqlParameter("Dealer", SqlDbType.NVarChar); Dealer.Value = model.Dealer;
            SqlParameter DealTime = new SqlParameter("DealTime", SqlDbType.DateTime); DealTime.Value = model.DealTime;
            SqlParameter PayTime = new SqlParameter("PayTime", SqlDbType.DateTime); PayTime.Value = model.PayTime;
            SqlParameter TransferCertificate = new SqlParameter("TransferCertificate", SqlDbType.NVarChar); TransferCertificate.Value = model.TransferCertificate;
            SqlParameter PayMethod = new SqlParameter("PayMethod", SqlDbType.NVarChar); PayMethod.Value = model.PayMethod;
            SqlParameter company = new SqlParameter("company", SqlDbType.NVarChar); company.Value = model.company;
            
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { UserName, OrderNumber, SubmitTime, OrderStatus, WorkArea, ServerType, CoorTransEnable, HeightTransEnable, SHPTransEnable, DXFTransEnable, PPPserverEnable, ObsQualityEnable, BaseLineEnable, MultiBaseLineEnable, CoorSystemEnable, RoamingServiceArea, RoamingServiceEnable, AccountNum, ServiceDuration, Price, Dealer, DealTime, PayMethod, TransferCertificate, PayTime, company }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.OrderList GetModel(string OrderNumber)
        {
            string strSql = "select * from OrderList where OrderNumber = '" + OrderNumber + "'";
            Model.OrderList model = new Model.OrderList();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.OrderNumber = OrderNumber;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                model.SubmitTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["SubmitTime"]);
                model.OrderStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["OrderStatus"]);
                model.WorkArea = Convert.ToString(ds.Tables[0].Rows[0]["WorkArea"]);
                model.ServerType = Convert.ToString(ds.Tables[0].Rows[0]["ServerType"]);
                model.CoorTransEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["CoorTransEnable"]);
                model.HeightTransEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["HeightTransEnable"]);
                model.SHPTransEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["SHPTransEnable"]);
                model.DXFTransEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["DXFTransEnable"]);
                model.PPPserverEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["PPPserverEnable"]);
                model.ObsQualityEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["ObsQualityEnable"]);
                model.BaseLineEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["BaseLineEnable"]);
                model.MultiBaseLineEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["MultiBaseLineEnable"]);
                model.CoorSystemEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["CoorSystemEnable"]);
                model.RoamingServiceEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["RoamingServiceEnable"]);
                model.RoamingServiceArea = Convert.ToString(ds.Tables[0].Rows[0]["RoamingServiceArea"]);
                model.AccountNum = Convert.ToInt32(ds.Tables[0].Rows[0]["AccountNum"]);
                model.ServiceDuration = Convert.ToString(ds.Tables[0].Rows[0]["ServiceDuration"]);
                model.Price = Convert.ToString(ds.Tables[0].Rows[0]["Price"]);
                model.Dealer = Convert.ToString(ds.Tables[0].Rows[0]["Dealer"]);
                model.DealTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["DealTime"]); 
                model.PayMethod = Convert.ToInt32(ds.Tables[0].Rows[0]["PayMethod"]);
                model.TransferCertificate = Convert.ToString(ds.Tables[0].Rows[0]["TransferCertificate"]);
                model.PayTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["PayTime"]);
                model.company= Convert.ToString(ds.Tables[0].Rows[0]["company"]);
                model.OrderContent = Convert.ToString(ds.Tables[0].Rows[0]["OrderContent"]);
                model.OrdeType = Convert.ToInt32(ds.Tables[0].Rows[0]["OrdeType"]);
                model.ElevationEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["ElevationEnable"]);
                model.IsRenew = Convert.ToString(ds.Tables[0].Rows[0]["IsRenew"]);
                
                return model;
            }
            else
            {
                return null;
            }
        }

        public static Model.OrderList GetModel(int ID)
        {
            string strSql = "select * from OrderList where ID = '" + ID + "'";
            Model.OrderList model = new Model.OrderList();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.OrderNumber = Convert.ToString(ds.Tables[0].Rows[0]["OrderNumber"]);
            
                model.UserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                model.SubmitTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["SubmitTime"]);
                model.OrderStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["OrderStatus"]);
                model.WorkArea = Convert.ToString(ds.Tables[0].Rows[0]["WorkArea"]);
                model.ServerType = Convert.ToString(ds.Tables[0].Rows[0]["ServerType"]);
                model.CoorTransEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["CoorTransEnable"]);
                model.HeightTransEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["HeightTransEnable"]);
                model.SHPTransEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["SHPTransEnable"]);
                model.DXFTransEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["DXFTransEnable"]);
                model.PPPserverEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["PPPserverEnable"]);
                model.ObsQualityEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["ObsQualityEnable"]);
                model.BaseLineEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["BaseLineEnable"]);
                model.MultiBaseLineEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["MultiBaseLineEnable"]);
                model.CoorSystemEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["CoorSystemEnable"]);
                model.RoamingServiceEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["RoamingServiceEnable"]);
                model.RoamingServiceArea = Convert.ToString(ds.Tables[0].Rows[0]["RoamingServiceArea"]);
                model.AccountNum = Convert.ToInt32(ds.Tables[0].Rows[0]["AccountNum"]);
                model.ServiceDuration = Convert.ToString(ds.Tables[0].Rows[0]["ServiceDuration"]);
                model.Price = Convert.ToString(ds.Tables[0].Rows[0]["Price"]);
                model.Dealer = Convert.ToString(ds.Tables[0].Rows[0]["Dealer"]);
                model.DealTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["DealTime"]);
                model.PayMethod = Convert.ToInt32(ds.Tables[0].Rows[0]["PayMethod"]);
                model.TransferCertificate = Convert.ToString(ds.Tables[0].Rows[0]["TransferCertificate"]);
                model.PayTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["PayTime"]);
                model.RoamID= Convert.ToString(ds.Tables[0].Rows[0]["RoamID"]);
                model.company = Convert.ToString(ds.Tables[0].Rows[0]["company"]);
                model.OrderContent = Convert.ToString(ds.Tables[0].Rows[0]["OrderContent"]);
                model.OrdeType = Convert.ToInt32(ds.Tables[0].Rows[0]["OrdeType"]); 
                model.ElevationEnable = Convert.ToInt32(ds.Tables[0].Rows[0]["ElevationEnable"]);
                model.IsRenew = Convert.ToString(ds.Tables[0].Rows[0]["IsRenew"]);
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
            string strSql = "delete from OrderList where OrderNumber ='" + OrderNumber + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int ID)
        {
            string strSql = "delete from OrderList where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from OrderList where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static int GetRecordCount(string search = "",string strwhere="1=1")
        {
            string strSql = "select count(*) from OrderList where OrderNumber like '%" + search +"%' and "+strwhere;
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
            string sql = "SELECT * FROM OrderList w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM OrderList where OrderNumber like '%" + search + "%' ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
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
            string sql = "SELECT * FROM OrderList w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM OrderList where OrderNumber like '%" + search + "%' and "+strwhere+ " and OrderStatus!=0 ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID ORDER BY w1.@sort @order";
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }
        /// <summary>
        /// 得到漫游区域
        /// </summary>
        /// <returns></returns>
        public static DataSet GetRoamArea()
        {
            string sql = "select ID,AreaName from RoamArea ";
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }

    }
}
