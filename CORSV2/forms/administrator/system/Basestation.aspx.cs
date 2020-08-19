using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CORSV2.forms.administrator.system
{
    public partial class Basestation : System.Web.UI.Page
    {
        private string BasePath = "E:\\WHUOBS\\";
        protected void Page_Load(object sender, EventArgs e)
        {
            int type12 = Convert.ToInt32(Session["UserType"]);
            if (Session["UserName"] == null || (Convert.ToInt32(Session["UserType"]) != 3 && Convert.ToInt32(Session["UserType"]) != 2))
            {
                var a = Session["UserType"];
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/Index.aspx\";</script>");
                Response.End();
            }

            if (Request["action"] != null)
            {
                switch (Request["action"].ToString())
                {
                    case "GetData":
                        GetData();
                        break;
                    case "DownloadAll":
                        DownloadData();
                        break;
                    case "HasData":
                        if (HasData())
                        {//有观测数据
                            Response.ContentType = "text/plain";
                            Response.Write(1);
                            Response.End();

                        }
                        else
                        {
                            Response.ContentType = "text/plain";
                            Response.Write(0);
                            Response.End();
                        }
                        break;
                }
            }
        }

        private bool GetData()
        {
            try
            {
                int offset = 0;
                int limit = 15;
                string sort = "ID";
                string order = "DESC";
                string search = "";
                if (Request["search"] != null)
                    search = Request["search"].ToString();
                if (Request["sort"] != null)
                {
                    sort = Request["sort"].ToString();
                    order = Request["order"].ToString();
                }

                if (Request["offset"] != null)
                {
                    offset = Convert.ToInt32(Request["offset"]);
                    limit = Convert.ToInt32(Request["limit"]);
                }

                DataSet ds = DAL.CORSStationInfo.GetListByPage(offset, limit, sort, order, search);
                int total = DAL.CORSStationInfo.GetRecordCount(search);
                string result = "";
                if (total > 0)
                {
                    string jsonNews = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
                    result = "{\"total\":" + total.ToString() + ",\"rows\":" + jsonNews + "}";
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
            catch (Exception e)
            {
                return false;
            }
        }

        private bool HasData()
        {
            DateTime SLTime = Convert.ToDateTime(Request["date"]); //选择时间
            int year = SLTime.Year;
            int doy = SLTime.DayOfYear;
            string[] stationIDS = Request["station"].ToString().Split(',');
            string[] ObsPath = new string[stationIDS.Length];
            int flag = 0;
            for (int i = 0; i < stationIDS.Length; i++)
            {
                string SName = stationIDS[i];
                ObsPath[i] = BasePath + SName + "\\" + year.ToString() + "\\" + doy.ToString(); ;
                if (!Directory.Exists(ObsPath[i]))
                {
                    Directory.CreateDirectory(ObsPath[i]);
                }
                if (flag == 0)
                    if (Directory.GetFiles(ObsPath[i]).Length + Directory.GetDirectories(ObsPath[i]).Length > 0)
                    {
                        flag = 1;
                    }
            }
            if (flag == 0)//没有数据
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void DownloadData()
        {
            try
            {
                DateTime SLTime = Convert.ToDateTime(Request["date"]); //选择时间
                int year = SLTime.Year;
                int doy = SLTime.DayOfYear;
                string[] stationIDS = Request["station"].ToString().Split(',');
                string[] ObsPath = new string[stationIDS.Length];
                int flag = 0;
                for (int i = 0; i < stationIDS.Length; i++)
                {
                    string SName = stationIDS[i];
                    ObsPath[i] = BasePath + SName + "\\" + year.ToString() + "\\" + doy.ToString(); ;
                    if (!Directory.Exists(ObsPath[i]))
                    {
                        Directory.CreateDirectory(ObsPath[i]);
                    }
                    if (flag == 0)
                        if (Directory.GetFiles(ObsPath[i]).Length + Directory.GetDirectories(ObsPath[i]).Length > 0)
                        {
                            flag = 1;
                        }
                }
                if (flag == 0)//没有数据
                {
                    Response.Write("alert(\"没有数据！\");");
                    Response.End();
                }
                string SavePath = Server.MapPath("~/Temp/");
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                string SaveFileName = SavePath + "\\" + DateTime.Now.Ticks.ToString() + ".rar";
                string error = "";
                string AdminName = Convert.ToString(Session["UserName"]);
                if (MyPackage.Pack11(ObsPath, SaveFileName, 5, AdminName, out error))
                {
                    FileInfo fileInfo = new FileInfo(SaveFileName);
                    Response.Clear();
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(Path.GetFileName(SaveFileName), System.Text.Encoding.UTF8));
                    Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                    Response.AddHeader("Content-Transfer-Encoding", "binary");
                    Response.ContentType = "application/octet-stream";
                    Response.ContentEncoding = System.Text.Encoding.Default;
                    Response.WriteFile(fileInfo.FullName);
                    Response.Flush();
                    File.Delete(fileInfo.FullName);
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert(\"下载失败\");</script>");
                    Response.End();
                }

            }
            catch (Exception er)
            {
                Response.Write("<script>alert(\"下载失败:" + er.Message + "\");</script>");
                Response.End();
            }
        }
    }
}