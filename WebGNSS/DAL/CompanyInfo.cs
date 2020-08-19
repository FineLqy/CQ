using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class CompanyInfo
   {

        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;

        /// <summary>
        /// 是否存在该ID主键
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Exists(int ID)
        {
            string strSql = "select count(*) from CompanyInfo where ID=" + ID.ToString();
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 单位是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool Exists(string Company)
        {
            string strSql = "select count(*) from CompanyInfo where Company='" + Company + "'";
            return DBHelperSQL.GetResult(strSql, connectionString).ToString().Trim() == "1" ? true : false;
        }
        /// <summary>
        /// 增加一个单位信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Model.CompanyInfo model)
        {
            string strSql = "insert into CompanyInfo(Company,Address,CompanyTel,Industry,OrganizationCode,BusinessLicense,SurveyingQualification,SurveyingNumber,SurveyingFile,LegalPerson,LegalIDCardNumber,LegalIDCardFile,PowerOfAttorney,Contact,ContactIDCardNumer,ContactIDCardFile,CertificationTime,BelongArea) values(@Company,@Address,@CompanyTel,@Industry,@OrganizationCode,@BusinessLicense,@SurveyingQualification,@SurveyingNumber,@SurveyingFile,@LegalPerson,@LegalIDCardNumber,@LegalIDCardFile,@PowerOfAttorney,@Contact,@ContactIDCardNumer,@ContactIDCardFile,@CertificationTime,@BelongArea)";
            SqlParameter Company = new SqlParameter("Company", SqlDbType.NVarChar); Company.Value = model.Company;
            SqlParameter Address = new SqlParameter("Address", SqlDbType.NVarChar); Address.Value = model.Address;
            SqlParameter CompanyTel = new SqlParameter("CompanyTel", SqlDbType.NVarChar); CompanyTel.Value = model.CompanyTel;
            SqlParameter Industry = new SqlParameter("Industry", SqlDbType.NVarChar); Industry.Value = model.Industry;
            SqlParameter OrganizationCode = new SqlParameter("OrganizationCode", SqlDbType.NVarChar); OrganizationCode.Value = model.OrganizationCode;
            SqlParameter BusinessLicense = new SqlParameter("BusinessLicense", SqlDbType.NVarChar); BusinessLicense.Value = model.BusinessLicense;
            SqlParameter SurveyingQualification = new SqlParameter("SurveyingQualification", SqlDbType.NVarChar); SurveyingQualification.Value = model.SurveyingQualification;
            SqlParameter SurveyingNumber = new SqlParameter("SurveyingNumber", SqlDbType.NVarChar); SurveyingNumber.Value = model.SurveyingNumber;
            SqlParameter SurveyingFile = new SqlParameter("SurveyingFile", SqlDbType.NVarChar); SurveyingFile.Value = model.SurveyingFile;
            SqlParameter LegalPerson = new SqlParameter("LegalPerson", SqlDbType.NVarChar); LegalPerson.Value = model.LegalPerson;
            SqlParameter LegalIDCardNumber = new SqlParameter("LegalIDCardNumber", SqlDbType.NVarChar); LegalIDCardNumber.Value = model.LegalIDCardNumber;
            SqlParameter LegalIDCardFile = new SqlParameter("LegalIDCardFile", SqlDbType.NVarChar); LegalIDCardFile.Value = model.LegalIDCardFile;
            SqlParameter PowerOfAttorney = new SqlParameter("PowerOfAttorney", SqlDbType.NVarChar); PowerOfAttorney.Value = model.PowerOfAttorney;
            SqlParameter Contact = new SqlParameter("Contact", SqlDbType.NVarChar); Contact.Value = model.Contact;
            SqlParameter ContactIDCardNumer = new SqlParameter("ContactIDCardNumer", SqlDbType.NVarChar); ContactIDCardNumer.Value = model.ContactIDCardNumer;
            SqlParameter ContactIDCardFile = new SqlParameter("ContactIDCardFile", SqlDbType.NVarChar); ContactIDCardFile.Value = model.ContactIDCardFile;
            SqlParameter CertificationTime = new SqlParameter("CertificationTime", SqlDbType.DateTime); CertificationTime.Value = model.CertificationTime;
            SqlParameter BelongArea = new SqlParameter("BelongArea", SqlDbType.NVarChar); BelongArea.Value = model.BelongArea;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { Company, Address, CompanyTel, Industry, OrganizationCode, BusinessLicense, SurveyingQualification, SurveyingNumber, SurveyingFile, LegalPerson, LegalIDCardNumber, LegalIDCardFile, PowerOfAttorney, Contact, ContactIDCardNumer, ContactIDCardFile, CertificationTime, BelongArea }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 更新一条数据,根据ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Model.CompanyInfo model)
        {
            string strSql = "update CompanyInfo set Company=@Company, Address=@Address, CompanyTel=@CompanyTel, Industry=@Industry, OrganizationCode=@OrganizationCode, BusinessLicense=@BusinessLicense, SurveyingQualification=@SurveyingQualification, SurveyingNumber=@SurveyingNumber, SurveyingFile=@SurveyingFile, LegalPerson=@LegalPerson, LegalIDCardNumber=@LegalIDCardNumber, LegalIDCardFile=@LegalIDCardFile, PowerOfAttorney=@PowerOfAttorney, Contact=@Contact, ContactIDCardNumer=@ContactIDCardNumer, ContactIDCardFile=@ContactIDCardFile, CertificationTime=@CertificationTime, BelongArea=@BelongArea  where ID = " + model.ID.ToString();
            SqlParameter Company = new SqlParameter("Company", SqlDbType.NVarChar); Company.Value = model.Company;
            SqlParameter Address = new SqlParameter("Address", SqlDbType.NVarChar); Address.Value = model.Address;
            SqlParameter CompanyTel = new SqlParameter("CompanyTel", SqlDbType.NVarChar); CompanyTel.Value = model.CompanyTel;
            SqlParameter Industry = new SqlParameter("Industry", SqlDbType.NVarChar); Industry.Value = model.Industry;
            SqlParameter OrganizationCode = new SqlParameter("OrganizationCode", SqlDbType.NVarChar); OrganizationCode.Value = model.OrganizationCode;
            SqlParameter BusinessLicense = new SqlParameter("BusinessLicense", SqlDbType.NVarChar); BusinessLicense.Value = model.BusinessLicense;
            SqlParameter SurveyingQualification = new SqlParameter("SurveyingQualification", SqlDbType.NVarChar); SurveyingQualification.Value = model.SurveyingQualification;
            SqlParameter SurveyingNumber = new SqlParameter("SurveyingNumber", SqlDbType.NVarChar); SurveyingNumber.Value = model.SurveyingNumber;
            SqlParameter SurveyingFile = new SqlParameter("SurveyingFile", SqlDbType.NVarChar); SurveyingFile.Value = model.SurveyingFile;
            SqlParameter LegalPerson = new SqlParameter("LegalPerson", SqlDbType.NVarChar); LegalPerson.Value = model.LegalPerson;
            SqlParameter LegalIDCardNumber = new SqlParameter("LegalIDCardNumber", SqlDbType.NVarChar); LegalIDCardNumber.Value = model.LegalIDCardNumber;
            SqlParameter LegalIDCardFile = new SqlParameter("LegalIDCardFile", SqlDbType.NVarChar); LegalIDCardFile.Value = model.LegalIDCardFile;
            SqlParameter PowerOfAttorney = new SqlParameter("PowerOfAttorney", SqlDbType.NVarChar); PowerOfAttorney.Value = model.PowerOfAttorney;
            SqlParameter Contact = new SqlParameter("Contact", SqlDbType.NVarChar); Contact.Value = model.Contact;
            SqlParameter ContactIDCardNumer = new SqlParameter("ContactIDCardNumer", SqlDbType.NVarChar); ContactIDCardNumer.Value = model.ContactIDCardNumer;
            SqlParameter ContactIDCardFile = new SqlParameter("ContactIDCardFile", SqlDbType.NVarChar); ContactIDCardFile.Value = model.ContactIDCardFile;
            SqlParameter CertificationTime = new SqlParameter("CertificationTime", SqlDbType.DateTime); CertificationTime.Value = model.CertificationTime;
            SqlParameter BelongArea = new SqlParameter("BelongArea", SqlDbType.NVarChar); BelongArea.Value = model.BelongArea;
            return DBHelperSQL.GetNums(strSql, new SqlParameter[] { Company, Address, CompanyTel, Industry, OrganizationCode, BusinessLicense, SurveyingQualification, SurveyingNumber, SurveyingFile, LegalPerson, LegalIDCardNumber, LegalIDCardFile, PowerOfAttorney, Contact, ContactIDCardNumer, ContactIDCardFile, CertificationTime, BelongArea }, connectionString) == 1 ? true : false;
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static Model.CompanyInfo GetModel(string Company)
        {
            string strSql = "select * from CompanyInfo where Company = '" + Company + "'";
            Model.CompanyInfo model = new Model.CompanyInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.Company = Company;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.Address = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                model.BelongArea = Convert.ToString(ds.Tables[0].Rows[0]["BelongArea"]);
                model.BusinessLicense = Convert.ToString(ds.Tables[0].Rows[0]["BusinessLicense"]);
                model.CertificationTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["CertificationTime"]);
                model.CompanyTel = Convert.ToString(ds.Tables[0].Rows[0]["CompanyTel"]);
                model.Contact = Convert.ToString(ds.Tables[0].Rows[0]["Contact"]);
                model.ContactIDCardFile = Convert.ToString(ds.Tables[0].Rows[0]["ContactIDCardFile"]);
                model.ContactIDCardNumer = Convert.ToString(ds.Tables[0].Rows[0]["ContactIDCardNumer"]);
                model.Industry = Convert.ToString(ds.Tables[0].Rows[0]["Industry"]);
                model.LegalIDCardFile = Convert.ToString(ds.Tables[0].Rows[0]["LegalIDCardFile"]);
                model.LegalIDCardNumber = Convert.ToString(ds.Tables[0].Rows[0]["LegalIDCardNumber"]);
                model.LegalPerson = Convert.ToString(ds.Tables[0].Rows[0]["LegalPerson"]);
                model.OrganizationCode = Convert.ToString(ds.Tables[0].Rows[0]["OrganizationCode"]);
                model.PowerOfAttorney = Convert.ToString(ds.Tables[0].Rows[0]["PowerOfAttorney"]);
                model.SurveyingFile = Convert.ToString(ds.Tables[0].Rows[0]["SurveyingFile"]);
                model.SurveyingNumber = Convert.ToString(ds.Tables[0].Rows[0]["SurveyingNumber"]);
                model.SurveyingQualification = Convert.ToString(ds.Tables[0].Rows[0]["SurveyingQualification"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        public static Model.CompanyInfo GetModel(int ID)
        {
            string strSql = "select * from CompanyInfo where ID = '" + ID + "'";
            Model.CompanyInfo model = new Model.CompanyInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Company = Convert.ToString(ds.Tables[0].Rows[0]["Company"]);
                model.Address = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                model.BelongArea = Convert.ToString(ds.Tables[0].Rows[0]["BelongArea"]);
                model.BusinessLicense = Convert.ToString(ds.Tables[0].Rows[0]["BusinessLicense"]);
                model.CertificationTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["CertificationTime"]);
                model.CompanyTel = Convert.ToString(ds.Tables[0].Rows[0]["CompanyTel"]);
                model.Contact = Convert.ToString(ds.Tables[0].Rows[0]["Contact"]);
                model.ContactIDCardFile = Convert.ToString(ds.Tables[0].Rows[0]["ContactIDCardFile"]);
                model.ContactIDCardNumer = Convert.ToString(ds.Tables[0].Rows[0]["ContactIDCardNumer"]);
                model.Industry = Convert.ToString(ds.Tables[0].Rows[0]["Industry"]);
                model.LegalIDCardFile = Convert.ToString(ds.Tables[0].Rows[0]["LegalIDCardFile"]);
                model.LegalIDCardNumber = Convert.ToString(ds.Tables[0].Rows[0]["LegalIDCardNumber"]);
                model.LegalPerson = Convert.ToString(ds.Tables[0].Rows[0]["LegalPerson"]);
                model.OrganizationCode = Convert.ToString(ds.Tables[0].Rows[0]["OrganizationCode"]);
                model.PowerOfAttorney = Convert.ToString(ds.Tables[0].Rows[0]["PowerOfAttorney"]);
                model.SurveyingFile = Convert.ToString(ds.Tables[0].Rows[0]["SurveyingFile"]);
                model.SurveyingNumber = Convert.ToString(ds.Tables[0].Rows[0]["SurveyingNumber"]);
                model.SurveyingQualification = Convert.ToString(ds.Tables[0].Rows[0]["SurveyingQualification"]);
                return model;
            }
            else
            {
                return null;
            }
        }
        public static Model.CompanyInfo GetModel()
        {
            string strSql = "select top 1 * from CompanyInfo order by ID desc";
            Model.CompanyInfo model = new Model.CompanyInfo();
            DataSet ds = DBHelperSQL.GetDataSet(strSql, connectionString);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                model.Company = Convert.ToString(ds.Tables[0].Rows[0]["Company"]);
                model.Address = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                model.BelongArea = Convert.ToString(ds.Tables[0].Rows[0]["BelongArea"]);
                model.BusinessLicense = Convert.ToString(ds.Tables[0].Rows[0]["BusinessLicense"]);
                model.CertificationTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["CertificationTime"]);
                model.CompanyTel = Convert.ToString(ds.Tables[0].Rows[0]["CompanyTel"]);
                model.Contact = Convert.ToString(ds.Tables[0].Rows[0]["Contact"]);
                model.ContactIDCardFile = Convert.ToString(ds.Tables[0].Rows[0]["ContactIDCardFile"]);
                model.ContactIDCardNumer = Convert.ToString(ds.Tables[0].Rows[0]["ContactIDCardNumer"]);
                model.Industry = Convert.ToString(ds.Tables[0].Rows[0]["Industry"]);
                model.LegalIDCardFile = Convert.ToString(ds.Tables[0].Rows[0]["LegalIDCardFile"]);
                model.LegalIDCardNumber = Convert.ToString(ds.Tables[0].Rows[0]["LegalIDCardNumber"]);
                model.LegalPerson = Convert.ToString(ds.Tables[0].Rows[0]["LegalPerson"]);
                model.OrganizationCode = Convert.ToString(ds.Tables[0].Rows[0]["OrganizationCode"]);
                model.PowerOfAttorney = Convert.ToString(ds.Tables[0].Rows[0]["PowerOfAttorney"]);
                model.SurveyingFile = Convert.ToString(ds.Tables[0].Rows[0]["SurveyingFile"]);
                model.SurveyingNumber = Convert.ToString(ds.Tables[0].Rows[0]["SurveyingNumber"]);
                model.SurveyingQualification = Convert.ToString(ds.Tables[0].Rows[0]["SurveyingQualification"]);
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
        public static bool Delete(string Company)
        {
            string strSql = "delete from CompanyInfo where Company ='" + Company + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }
        public static bool Delete(int ID)
        {
            string strSql = "delete from CompanyInfo where ID ='" + ID + "'";
            return DBHelperSQL.GetNums(strSql, connectionString) == 1 ? true : false;
        }

        public static DataSet GetList(string strWhere)
        {
            string strSql = "select * from CompanyInfo where ";
            if (strWhere.Trim() != "")
                strSql += strWhere;
            return DBHelperSQL.GetDataSet(strSql, connectionString);
        }

        public static int GetRecordCount(string search = "")
        {
            string strSql = "select count(*) from CompanyInfo where Company like '%" + search + "%'";
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
            string sql = "SELECT * FROM CompanyInfo w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM CompanyInfo where Company like '%" + search + "%' ORDER BY ID ASC) w ORDER BY w.ID DESC) w2 WHERE w1.ID = w2.ID ORDER BY w1.ID ASC";
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
            string sql = "SELECT * FROM CompanyInfo w1,( SELECT TOP " + limit + " w.ID FROM( SELECT TOP  " + endRecord + "* FROM CompanyInfo where Company like '%" + search + "%' ORDER BY @sort @order) w ORDER BY w.@sort @deorder) w2 WHERE w1.ID = w2.ID ORDER BY w1.@sort @order";
            sql = sql.Replace("@sort", sort);
            sql = sql.Replace("@order", order);
            sql = sql.Replace("@deorder", deorder);
            return DBHelperSQL.GetDataSet(sql, connectionString);
        }

    }
}
