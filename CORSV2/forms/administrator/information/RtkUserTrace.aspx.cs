using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Data;
using System.Net;
using System.Text;
using System.Collections;
namespace CORSV2.forms.administrator.information
{
    public partial class RtkUserTrace : System.Web.UI.Page
    {
        public string result = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //非最高级管理员无法查询用户轨迹
            if (Session["UserName"] == null || Session["UserType"] == null || Convert.ToInt32(Session["UserType"]) < 2 || Convert.ToInt32(Session["UserType"]) > 3)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/login/login.aspx\";</script>");
                Response.End();
            }
            if (Request["action"] != null)
            {
                switch (Request["action"].ToString())
                {
                    case "DownloadAll":
                        DownloadAll();
                        break;
                    case "GetJsonCompany":
                        GetJsonCompany();
                        break;
                    case "GetUserAccount":
                        GetUserAccount();
                        break;
                    default:
                        break;
                }
            }
        }

        private bool GetJsonCompany()
        {
            DataSet ds = DAL.RegisterUser.GetUserNameList("1=1 order by ID desc");
            int total = ds.Tables[0].Rows.Count;
            if (total > 0)
            {
                string jsonCompany = cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
                result = "{\"message\":" + total.ToString() + ",\"value\":" + jsonCompany + "}";
                Response.ContentType = "application/Json";
                Response.Write(result);
                Response.End();
                return true;
            }
            else
            {
                result = null;
                Response.ContentType = "application/Json";
                Response.Write(result);
                Response.End();
                return false;
            }
        }
        private bool GetUserAccount()
        {
            DataSet ds = DAL.RTKUserInfo.GetList(" RegisterUserName = '" + Request["UserName"].ToString() + "'");
            DataRow dr = ds.Tables[0].NewRow();
            dr["ID"] = "0";
            dr["UserName"] = "所有用户";
            ds.Tables[0].Rows.Add(dr);
            string jsonArea = cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
            Response.ContentType = "application/Json";
            Response.Write(jsonArea);
            Response.End();
            return true;
        }

        private void DownloadAll()
        {
            DataTable dt = DAL.RTKSurveyRec.GetList("1=1 order by id asc").Tables[0];
            WriteExcelWithNPOI(dt, "xls");
        }

        public void WriteExcelWithNPOI(DataTable dt, String extension)
        {

            IWorkbook workbook;

            if (extension == "xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else if (extension == "xls")
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                throw new Exception("This format is not supported");
            }

            ISheet sheet1 = workbook.CreateSheet("Sheet 1");

            //make a header row
            IRow row1 = sheet1.CreateRow(0);

            for (int j = 0; j < dt.Columns.Count; j++)
            {

                ICell cell = row1.CreateCell(j);
                String columnName = dt.Columns[j].ToString();
                cell.SetCellValue(columnName);
            }

            //loops through data
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = sheet1.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    ICell cell = row.CreateCell(j);
                    String columnName = dt.Columns[j].ToString();
                    cell.SetCellValue(dt.Rows[i][columnName].ToString());
                }
            }

            using (var exportData = new MemoryStream())
            {
                Response.Clear();
                workbook.Write(exportData);
                if (extension == "xlsx") //xlsx file format
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "测量作业记录.xlsx"));
                    Response.BinaryWrite(exportData.ToArray());
                }
                else if (extension == "xls")  //xls file format
                {
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "测量作业记录.xls"));
                    Response.BinaryWrite(exportData.GetBuffer());
                }
                Response.End();
            }
        }

        /*   获得轨迹点函数
        private  void GetTracePt()
        {
            
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BTCORSConnectStr"].ConnectionString;
            string xuqiu = Request.Form["q"].ToString();
            string SelectedUserName = Convert.ToString(Session["RTKZYLS_UserName"]);

            string[] strs = SelectedUserName.Split(';'); string sqlq = "";
            foreach (string username in strs)
            {
                if (username.Trim() != "")
                {
                    sqlq += "UserName='" + username + "' or ";
                }
            }
            sqlq += "UserName='!@#$'";
            string StartTime = Convert.ToString(Request["StartTime"]);
            string EndTime = Convert.ToString(Request["EndTime"]);
            if (SelectedUserName == "")
            {

            }
            else
            {
                string sql = "select * from RTKUserPosiRec where (" + sqlq + ") and (Time>='" + StartTime + "' and Time<='" + EndTime + "') order by Time";
                DataSet ds = DBUtility.DBHelperSQL.GetDataSet(sql, connectionString);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    Response.Write("");
                }
                else
                {
                    ArrayList xal = new ArrayList(); ArrayList yal = new ArrayList(); ArrayList Tal = new ArrayList();
                    ArrayList Sxal = new ArrayList(); ArrayList Syal = new ArrayList(); ArrayList STal = new ArrayList();
                    int ConverIndex = 0;
                    int ConverNum = 0;
                    while (ConverIndex < ds.Tables[0].Rows.Count)
                    {
                        if (ConverNum >= 100)
                        {
                            ConverNum = 0;
                            System.Threading.Thread.Sleep(1);
                        }
                        int Nums = 100;
                        //转换WGS84坐标为百度坐标系坐标
                        string x = ""; string y = ""; string xy = "";
                        Sxal = new ArrayList(); Syal = new ArrayList(); STal = new ArrayList();
                        for (int i = 0; i < Nums; i++)
                        {

                            if (ConverIndex >= ds.Tables[0].Rows.Count)
                            {
                                break;
                            }
                            try
                            {
                                double Lon = Convert.ToDouble(ds.Tables[0].Rows[ConverIndex]["Lon"]);
                                double Lat = Convert.ToDouble(ds.Tables[0].Rows[ConverIndex]["Lat"]);
                                if (Lon < 60 || Lon > 140 || Lat < 10 || Lat > 70)
                                {
                                    ConverIndex = ConverIndex + 1;
                                    ConverNum = ConverNum + 1;
                                    continue;
                                }
                            }
                            catch
                            {
                                ConverIndex = ConverIndex + 1;
                                ConverNum = ConverNum + 1;
                                continue;
                            }
                            if ((ConverIndex == ds.Tables[0].Rows.Count - 1) || i == (Nums - 1))
                            {
                                x = x + ds.Tables[0].Rows[ConverIndex]["Lon"].ToString();
                                y = y + ds.Tables[0].Rows[ConverIndex]["Lat"].ToString();
                                xy = xy + ds.Tables[0].Rows[ConverIndex]["Lon"].ToString() + "," + ds.Tables[0].Rows[ConverIndex]["Lat"].ToString();
                            }
                            else
                            {
                                x = x + ds.Tables[0].Rows[ConverIndex]["Lon"].ToString() + ",";
                                y = y + ds.Tables[0].Rows[ConverIndex]["Lat"].ToString() + ",";
                                xy = xy + ds.Tables[0].Rows[ConverIndex]["Lon"].ToString() + "," + ds.Tables[0].Rows[ConverIndex]["Lat"].ToString() + ";";
                            }
                            STal.Add(ds.Tables[0].Rows[ConverIndex]["UserName"].ToString() + "_" + ds.Tables[0].Rows[ConverIndex]["Time"].ToString());
                            ConverIndex = ConverIndex + 1;
                            ConverNum = ConverNum + 1;

                        }
                        string uri = "http://api.map.baidu.com/ag/coord/convert?from=0&to=4&x=" + x + "&y=" + y + "&mode=1";
                        uri = "http://api.map.baidu.com/geoconv/v1/?coords=" + xy + "&from=1&to=5&ak=7bGCq1WUPVv5H4LDIpH7u12v";
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                        try
                        {
                            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                            {
                                Stream stream = response.GetResponseStream();
                                StreamReader srr = new StreamReader(stream, Encoding.Default);
                                string linedata = srr.ReadLine();
                                JsonData jd = JsonMapper.ToObject(linedata);
                               
                                JsonData jdres = jd["result"];
                                foreach (JsonData jdre in jdres)
                                {
                                    Sxal.Add(jdre["x"].ToString());
                                    Syal.Add(jdre["y"].ToString());
                                }


                            }
                        }
                        catch (Exception er)
                        {
                            Sxal = new ArrayList(); Syal = new ArrayList(); STal = new ArrayList();
                            //xal = new ArrayList();
                            //yal = new ArrayList();
                            //Tal = new ArrayList();
                        }
                        finally
                        {
                            xal.AddRange(Sxal); yal.AddRange(Syal); Tal.AddRange(STal);
                        }

                    }
                    string jieguo = "";

                    if (xal.Count > 0)
                    {
                        for (int i = 0; i < xal.Count; i++)
                        {
                            if (jieguo == "")
                            {
                                jieguo = jieguo + xal[i].ToString() + "?" + yal[i].ToString() + "?" + Tal[i].ToString();
                            }
                            else
                            {
                                jieguo = jieguo + "?" + xal[i].ToString() + "?" + yal[i].ToString() + "?" + Tal[i].ToString();
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (jieguo == "")
                            {
                                jieguo = jieguo + ds.Tables[0].Rows[i]["Lon"].ToString() + "?" + ds.Tables[0].Rows[i]["Lat"].ToString() + "?" + ds.Tables[0].Rows[i]["UserName"].ToString() + "_" + ds.Tables[0].Rows[i]["Time"].ToString();
                            }
                            else
                            {
                                jieguo = jieguo + "?" + ds.Tables[0].Rows[i]["Lon"].ToString() + "?" + ds.Tables[0].Rows[i]["Lat"].ToString() + "?" + ds.Tables[0].Rows[i]["UserName"].ToString() + "_" + ds.Tables[0].Rows[i]["Time"].ToString();
                            }
                        }
                    }
                    Response.Write(jieguo);
                }
            }
        }


        */
    }
}