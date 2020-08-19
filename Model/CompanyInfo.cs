using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CompanyInfo
    {
        public CompanyInfo()
        {
            Company = "";
            Address = "";
            CompanyTel = "";
            Industry = "";
            OrganizationCode = "";
            BusinessLicense = "";
            SurveyingQualification = "";
            SurveyingNumber = "";
            SurveyingFile = "";
            LegalPerson = "";
            LegalIDCardNumber = "";
            LegalIDCardFile = "";
            PowerOfAttorney = "";
            Contact = "";
            ContactIDCardNumer = "";
            ContactIDCardFile = "";
            CertificationTime = DateTime.Now;
            BelongArea = "";
            ServiceAgreementFile = "";
            Balance = 0;
        }
        public int ID { set; get; }
        /// <summary>
        /// 单位名
        /// </summary>
        public string Company { set; get; }
        /// <summary>
        /// 单位地址
        /// </summary>
        public string Address { set; get; }
        /// <summary>
        /// 单位电话
        /// </summary>
        public string CompanyTel { set; get; }
        /// <summary>
        /// 行业 1为测绘资质单位 2为政府机构  3为仪器公司  4为高校/科研院所  5为其他非测绘资质执证单位
        /// </summary>
        public string Industry { set; get; }
        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string OrganizationCode { set; get; }
        /// <summary>
        /// 营业执照
        /// </summary>
        public string BusinessLicense { set; get; }
        /// <summary>
        /// 测绘资质等级
        /// </summary>
        public string SurveyingQualification { set; get; }
        /// <summary>
        /// 测绘资质编号
        /// </summary>
        public string SurveyingNumber { set; get; }
        /// <summary>
        /// 测绘资质文件
        /// </summary>
        public string SurveyingFile { set; get; }
        /// <summary>
        /// 法人名称
        /// </summary>
        public string LegalPerson { set; get; }
        /// <summary>
        /// 法人身份证号
        /// </summary>
        public string LegalIDCardNumber { set; get; }
        /// <summary>
        /// 法人身份证复印件
        /// </summary>
        public string LegalIDCardFile { set; get; }


        /// <summary>
        /// 授权委托书
        /// </summary>
        public string PowerOfAttorney { set; get; }
        /// <summary>
        /// 经办人姓名
        /// </summary>
        public string Contact { set; get; }
        /// <summary>
        /// 经办人身份证号
        /// </summary>
        public string ContactIDCardNumer { set; get; }
        /// <summary>
        /// 经办人
        /// </summary>
        public string ContactIDCardFile { set; get; }
        /// <summary>
        /// 认证时间
        /// </summary>
        public DateTime CertificationTime { set; get; }
       /// <summary>
       /// 单位属地
       /// </summary>
        public string BelongArea { set; get; }
        /// <summary>
        /// 服务协议
        /// </summary>
        public string ServiceAgreementFile { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public float Balance { get; set; }
    }
    
}
