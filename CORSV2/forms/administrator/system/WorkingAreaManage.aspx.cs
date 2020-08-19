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
    public partial class WorkingAreaManage : System.Web.UI.Page
    {
        int flag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/publicforms/login/login.aspx\";</script>");
                Response.End();
            }
            if (Session["UserType"] == null || (Convert.ToInt32(Session["UserType"]) != 2 && Convert.ToInt32(Session["UserType"]) != 3))
            {
                Response.Write("<script>alert(\"登录账户类型有误\");location.href = location.origin+\"/forms/publicforms/login/login.aspx\";</script>");
                Response.End();
            }
            if (Request["action"] != null)
            {
                switch (Request["action"])
                {
                    case "GetData":
                        GetData();
                        break;
                    case "AddData":
                        Response.ContentType = "text/plain";
                        Response.Write(AddData());
                        Response.End();
                        break;
                    case "Delete":
                        DeleteById();
                        break;
                    case "Update":
                        UpdateData();
                        if (flag == -1)
                        {
                            Response.ContentType = "text/plain";
                            Response.Write("-1");
                            Response.End();
                        }
                        break;
                    case "Download":
                        string ff=Convert.ToString(Request["id"]);
                        Download(Convert.ToInt32(Request["id"]));
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void GetData()
        {
            DataSet ds = DAL.WorkingArea.GetList("1=1");
            string jsonArea = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
            //int total = ds.Tables[0].Rows.Count;
            //string response = "{\"total\":@total,\"rows\":@rows}";
            //response = response.Replace("@total", total.ToString());
            //response = response.Replace("@rows", jsonArea);
            Response.ContentType = "application/Json";
            Response.Write(jsonArea);
            Response.End();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        private void DeleteById()
        {
            int id;
            string a = Request["id[]"];
            string[] temp = a.Split(',');
            for (int j = 0; j < temp.Length; j++)
            {
                id = Convert.ToInt32(temp[j]);
                DAL.WorkingArea.Delete(id);
                Model.WorkingArea wa = DAL.WorkingArea.GetModel(id);
                string areaName = wa.AreaName;
                DataSet ds = DAL.RTKUserPurview.GetList("1=1");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Model.RTKUserPurview mRTKUserPurview = DAL.RTKUserPurview.GetModel(ds.Tables[0].Rows[i]["UserName"].ToString());
                    string AreaIDs = "";
                    foreach (string Uid in mRTKUserPurview.AreaID.Split(';'))
                    {
                        if (Uid.Trim() != "")
                        {
                            if (Uid == areaName)
                            {

                            }
                            else
                            {
                                AreaIDs += Uid + ";";
                            }
                        }
                    }
                    mRTKUserPurview.AreaID = AreaIDs;
                    DAL.RTKUserPurview.Update(mRTKUserPurview);
                }

                //DataSet ComUser = DAL.CompanyPurview.GetList("1=1");
                //for (int i = 0; i < ComUser.Tables[0].Rows.Count; i++)
                //{
                //    Model.CompanyPurview mCompanyPurview = DAL.CompanyPurview.GetModel(ComUser.Tables[0].Rows[i]["UserName"].ToString());
                //    string AreaIDs = "";
                //    foreach (string Uid in mCompanyPurview.AreaID.Split(';'))
                //    {
                //        if (Uid.Trim() != "")
                //        {
                //            if (Uid == areaName)
                //            {

                //            }
                //            else
                //            {
                //                AreaIDs += Uid + ";";
                //            }
                //        }
                //    }
                //    mCompanyPurview.AreaID = AreaIDs;
                //    DAL.CompanyPurview.Update(mCompanyPurview);
                //}
            }
        }

        /// <summary>
        /// 下载数据
        /// </summary>
        /// <param name="id">需要下载的ID</param>
        private void Download(int id)
        {
            Model.WorkingArea modelwa = DAL.WorkingArea.GetModel(id);
            string savepath = Server.MapPath("~/upload/WorkingArea/");
            string filePath = savepath + modelwa.AreaName + ".txt";
            string fileName = "WorkingArea_" + modelwa.AreaName + ".txt";
            StreamWriter sw = new StreamWriter(filePath, false);
            string[] strs = modelwa.AreaString.Split(',');
            for (int i = 0; i < (strs.Length) / 2; i++)
            {
                sw.WriteLine(strs[2 * i] + "," + strs[2 * i + 1]);
            }
            sw.Close();

            //提交结果给用户
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.AddHeader("Content-Transfer-Encoding", "binary");
                //Response.ContentType = "text/plain";
                Response.ContentType = "application/octet-stream";
                Response.ContentEncoding = System.Text.Encoding.Default;
                Response.WriteFile(fileInfo.FullName);
                Response.Flush();
                // Response.End();
            }
            catch (Exception er)
            {
                string text = er.Message;
                throw new Exception("处理过程中发生了错误！");
            }
        }


        private int AddData()
        {

            string savepath = Server.MapPath("~/upload/WorkingArea/");
            string filename = Request.Files[0].FileName;
            try
            {
                Request.Files[0].SaveAs(savepath + filename);
            }
            catch
            {
                return -1;
            }
            StreamReader sr = new StreamReader(savepath + filename);
            try
            {

                string data = "";
                string linedata = sr.ReadLine();
                while (linedata != null && linedata.Trim() != "")
                {
                    string[] dds = linedata.Split(',');
                    if (data != "")
                    {
                        data = data + "," + dds[0].Trim() + "," + dds[1].Trim();
                    }
                    else
                    {
                        data = data + dds[0].Trim() + "," + dds[1].Trim();
                    }
                    linedata = sr.ReadLine();
                }
                Model.WorkingArea mwa = new Model.WorkingArea();
                mwa.AreaName = Request["area"];
                mwa.AreaString = data;
                if (DAL.WorkingArea.Exists(mwa.AreaName))
                    return -2;//已经存在改名称
                DAL.WorkingArea dalwa = new DAL.WorkingArea();
                DAL.WorkingArea.Add(mwa);
                sr.Close();
                File.Delete(savepath + filename);
                return 0;
            }
            catch (Exception er)
            {

                sr.Close(); File.Delete(savepath + filename);
                return 1;//格式添加错误

            }
        }

        private void UpdateData()
        {
            DAL.WorkingArea dalwa = new DAL.WorkingArea();
            int id = Convert.ToInt32(Request["ID"].ToString());
            DAL.WorkingArea dw = new DAL.WorkingArea();
            Model.WorkingArea mwa = DAL.WorkingArea.GetModel(id);
            mwa.AreaName = Request["AreaName"].Trim();
            flag = 1;
            string[] area = Request["AreaString"].ToString().Split(',');
            foreach (string a in area)
            {
                try { Convert.ToDouble(a); }
                catch { flag = -1; return; }
            }
            mwa.AreaString = Request["AreaString"].Trim();
            DAL.WorkingArea.Update(mwa);
            Response.ContentType = "text/plain";
            Response.Write("0");
            Response.End();
        }
    }
}