using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CORSV2.forms.administrator.system
{
    public partial class BroadcastManage : System.Web.UI.Page
    {
        public string Info = "";
        public string Info1 = "";
        public string result = "";
        public string username = "";

        private bool GetworkData()
        {
            int offset = 0;
            int limit = 10;
            if (Request["offset"] != null)
            {
                offset = Convert.ToInt32(Request["offset"]);
                limit = Convert.ToInt32(Request["limit"]);
            }
            int totalCount = DAL.SourceTable.GetRecordCount();
            if (offset + limit > totalCount)
            {
                limit = totalCount - offset;
            }
            DataSet ds = DAL.SourceTable.GetBriefList(offset, limit);


            if (ds.Tables[0].Rows.Count > 0)
            {
                string jsonNews = CORSV2.cs.JSONHelper.DataTableToJSON(ds.Tables[0]);
                result = "{\"total\":" + totalCount.ToString() + ",\"rows\":" + jsonNews + "}";
                Response.ContentType = "application/Json";
                Response.Write(result);
                Response.End();
                return true;
            }
            else
            {
                return false;
            }
        }
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
            string method = "";
            string para = "";
            if (Request["action"] != null)
            {
                string[] method_para = Request["action"].Split('_');
                method = method_para[0];
                for (int i = 1; i < method_para.Length - 1; i++)
                {
                    para += (method_para[i] + '_');
                }
                para += method_para[method_para.Length - 1];
            }
            if (!IsPostBack)
            {
                DataSet data = DAL.ServiceConnection.GetList();
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    string ID = data.Tables[0].Rows[i]["ID"].ToString();
                    string ServiceName = data.Tables[0].Rows[i]["ServiceName"].ToString();
                    string ServiceIP = data.Tables[0].Rows[i]["ServiceIP"].ToString();
                    string ServicePort = data.Tables[0].Rows[i]["ServicePort"].ToString();
                    string SourceTable = data.Tables[0].Rows[i]["SourceTable"].ToString();
                    Info += ID + "," + ServiceName + "," + ServiceIP + "," + ServicePort + "," + SourceTable + "_;";

                    string[] sourcemap = SourceTable.Split(';');
                    for (int j = 0; j < sourcemap.Length - 1; j++)
                    {
                        mapsource.Items.Add(ServiceName + ":" + sourcemap[j]);
                    }

                }
            }

            if (Request["action"] != null && Request["action"] == "GetData")
            {
                if (!GetworkData())
                {
                    Response.Write("0");

                }
            }

            #region  查询源列表管理
            if (method == "cxylbxx")
            {
                Model.SourceTable st = DAL.SourceTable.GetModel(int.Parse(para));
                DataSet data = DAL.SourceMap.GetList("Source='" + st.Source + "'");
                List<string> ID = new List<string>();
                List<string> Mapsource = new List<string>();
                List<string> level = new List<string>();
                List<string> allownum = new List<string>();
                List<string> servicename = new List<string>();
                string source = st.Source;
                string sourcetype = st.SourceType;
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    ID.Add(data.Tables[0].Rows[i]["ID"].ToString());
                    Mapsource.Add(data.Tables[0].Rows[i]["MapSource"].ToString());
                    level.Add(data.Tables[0].Rows[i]["PrecedenceLevel"].ToString());
                    allownum.Add(data.Tables[0].Rows[i]["AllowMaxNum"].ToString());
                    servicename.Add(data.Tables[0].Rows[i]["ServiceName"].ToString());
                }

                string sorlist = "";
                for (int i = 0; i < Mapsource.Count; i++)
                {
                    sorlist += (servicename[i] + ":" + Mapsource[i] + ":" + level[i] + ":" + allownum[i] + ";");
                }

                string result = "";
                result = source + "-!" + sourcetype + "-!" + sorlist;
                Response.Clear();
                Response.Write(result);
                Response.End();
            }
            #endregion
            #region 删除源列表
            if (method == "delesource")
            {
                try
                {
                    int[] ids;

                    string[] temp = para.Split(',');
                    ids = new int[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                    {
                        ids[i] = Convert.ToInt32(temp[i]);
                    }
                    for (int j = 0; j < ids.Length; j++)
                    {
                        Model.SourceTable st = DAL.SourceTable.GetModel(ids[j]);
                        DAL.SourceTable.Delete(ids[j]);
                        DataSet data = DAL.SourceMap.GetList("Source = '" + st.Source + "'");
                        List<int> ID = new List<int>();
                        for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                        {
                            ID.Add(int.Parse(data.Tables[0].Rows[i]["ID"].ToString()));
                        }
                        for (int k = 0; k < ID.Count; k++)
                        {
                            DAL.SourceMap.Delete(ID[k]);
                        }
                        string SourceText = st.Source;


                        //将存在该源的用户中的源删掉
                        DataSet ds = DAL.RTKUserPurview.GetList("1=1");

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Model.RTKUserPurview modelRTKUserPurview = DAL.RTKUserPurview.GetModel(ds.Tables[0].Rows[i]["UserName"].ToString());
                            string[] Sources = modelRTKUserPurview.SourceTable.Split(';');
                            string NewSources = "";
                            bool IsHas = false;
                            foreach (string SourceIn in Sources)
                            {
                                if (SourceIn.Trim() != "")
                                {
                                    if (SourceIn == SourceText)
                                    {
                                        IsHas = true;
                                    }
                                    else
                                    {
                                        NewSources = NewSources + SourceIn + ";";
                                    }
                                }
                            }

                            if (IsHas)
                            {
                                modelRTKUserPurview.SourceTable = NewSources;
                                DAL.RTKUserPurview.Update(modelRTKUserPurview);
                            }

                        }


                        //需要把源映射表中的信息也删除
                        ds = DAL.SourceMap.GetList("Source='" + SourceText + "'");
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DAL.SourceMap.Delete(Convert.ToInt32(ds.Tables[0].Rows[i]["ID"]));
                        }


                        ////需要把单位权限的信息也删除
                        //ds = DAL.CompanyPurview.GetList("1=1");
                        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        //{
                        //    Model.CompanyPurview mCompanyPurview = DAL.CompanyPurview.GetModel(ds.Tables[0].Rows[i]["Company"].ToString());
                        //    string[] Sources = mCompanyPurview.SourceTable.Split(';');
                        //    string NewSources = "";
                        //    bool IsHas = false;
                        //    foreach (string SourceIn in Sources)
                        //    {
                        //        if (SourceIn.Trim() != "")
                        //        {
                        //            if (SourceIn == SourceText)
                        //            {
                        //                IsHas = true;
                        //            }
                        //            else
                        //            {
                        //                NewSources = NewSources + SourceIn + ";";
                        //            }
                        //        }
                        //    }
                        //    if (IsHas)
                        //    {
                        //        mCompanyPurview.SourceTable = NewSources;
                        //        DAL.CompanyPurview.Update(mCompanyPurview);
                        //    }
                        //}


                        //添加系统日志
                        Model.SysLog msyslog = new Model.SysLog();
                        msyslog.UserName = Convert.ToString(Session["UserName"]);
                        msyslog.LogTime = DateTime.Now;
                        msyslog.LogType = 0;
                        msyslog.Remark = "管理员删除了源" + SourceText;
                        DAL.SysLog.Add(msyslog);
                    }

                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                catch (Exception)
                {


                }

            }
            #endregion

            #region 添加源
            if (method == "addsource")
            {
                string[] paras = para.Split(',');
                DataSet data = DAL.SourceTable.GetList("Source='" + paras[0].ToString().Trim() + "'");
                if (data.Tables[0].Rows.Count > 0)
                {
                    Response.Clear();
                    Response.Write("0");
                    Response.End();
                }
                else
                {
                    try
                    {
                        Model.SourceTable st = new Model.SourceTable();
                        st.Source = paras[0];
                        st.SourceType = paras[1];
                        DAL.SourceTable.Add(st);
                        //Model.SysLog mSysLog = new Model.SysLog();
                        //mSysLog.LogTime = DateTime.Now;
                        //mSysLog.LogType = 0;
                        //mSysLog.UserName = Session["UserName"].ToString();
                        //mSysLog.Remark = "管理员添加源：" + paras[0];
                        //DAL.SysLog bllSysLog = new DAL.SysLog(); bllSysLog.Add(mSysLog);
                        Response.Clear();
                        Response.Write("1");
                        Response.End();
                    }
                    catch (Exception)
                    {


                    }
                }
            }
            #endregion

            #region 修改源
            if (method == "savesource")
            {
                string[] paras = para.Split(',');
                Model.SourceTable st = DAL.SourceTable.GetModel(int.Parse(paras[0]));

                string sourcttext = st.Source;
                if (DAL.SourceTable.Exists(paras[2]))//已经存在了
                {
                    if (DAL.SourceTable.GetModel(paras[2]).ID != int.Parse(paras[0]))
                    {
                        Response.Clear();
                        Response.Write("-2");
                        Response.End();
                    }
                }
                try
                {
                    st.Source = paras[2];
                    st.SourceType = paras[3];
                    
                    DAL.SourceTable.Update(st);
                    ////修改源后需要把所有用户的源信息进行修改
                    //DataSet ds = DAL.RTKUserPurview.GetList("1=1");
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    Model.RTKUserPurview mRTKUP = DAL.RTKUserPurview.GetModel(ds.Tables[0].Rows[i]["UserName"].ToString());
                    //    string[] Sources = mRTKUP.SourceTable.Split(';');
                    //    string NewSources = "";
                    //    bool IsHas = false;
                    //    foreach (string SourceIn in Sources)
                    //    {
                    //        if (SourceIn.Trim() != "")
                    //        {
                    //            if (SourceIn == sourcttext)
                    //            {
                    //                IsHas = true;
                    //                NewSources = NewSources + st.Source + ";";
                    //            }
                    //            else
                    //            {
                    //                NewSources = NewSources + SourceIn + ";";
                    //            }
                    //        }
                    //    }
                    //    if (IsHas)
                    //    {
                    //        mRTKUP.SourceTable = NewSources;
                    //        DAL.RTKUserPurview.Update(mRTKUP);
                    //    }
                    //    //if (mRTKUP.SourceTable.Contains(SelectedSource))
                    //    //{
                    //    //    mRTKUP.SourceTable.Replace(SelectedSource, mst.Source);
                    //    //    DAL.RTKUserPurview.Update(mRTKUP);
                    //    //}
                    //}
                    ////需要把源映射表中的信息也修改
                    //ds = DAL.SourceMap.GetList("Source='" + sourcttext + "'");
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    Model.SourceMap msm = DAL.SourceMap.GetModel(Convert.ToInt32(ds.Tables[0].Rows[i]["ID"]));
                    //    msm.Source = st.Source;
                    //    msm.SourceType = st.SourceType;
                    //    DAL.SourceMap.Update(msm);
                    //}
                    ////需要把单位权限的信息全部更新
                    //ds = DAL.CompanyPurview.GetList("1=1");
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    Model.CompanyPurview mCompanyPurview = DAL.CompanyPurview.GetModel(ds.Tables[0].Rows[i]["Company"].ToString());
                    //    string[] Sources = mCompanyPurview.SourceTable.Split(';');
                    //    string NewSources = "";
                    //    bool IsHas = false;
                    //    foreach (string SourceIn in Sources)
                    //    {
                    //        if (SourceIn.Trim() != "")
                    //        {
                    //            if (SourceIn == sourcttext)
                    //            {
                    //                IsHas = true;
                    //                NewSources = NewSources + st.Source + ";";
                    //            }
                    //            else
                    //            {
                    //                NewSources = NewSources + SourceIn + ";";
                    //            }
                    //        }
                    //    }
                    //    if (IsHas)
                    //    {
                    //        mCompanyPurview.SourceTable = NewSources;
                    //        DAL.CompanyPurview.Update(mCompanyPurview);
                    //    }
                    //}

                    if (paras[4] == "" || paras[4] == null)
                    {
                        DataSet data = DAL.SourceMap.GetList("Source='" + sourcttext + "'");
                        List<int> ID = new List<int>();
                        for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                        {
                            ID.Add(int.Parse(data.Tables[0].Rows[i]["ID"].ToString()));
                        }
                        for (int k = 0; k < ID.Count; k++)
                        {
                            Model.SourceMap aaa = DAL.SourceMap.GetModel(ID[k]);
                            DAL.SourceMap.Delete(ID[k]);
                            //Model.SysLog mSysLog = new Model.SysLog();
                            //mSysLog.LogTime = DateTime.Now;
                            //mSysLog.LogType = 0;
                            //mSysLog.UserName = Session["UserName"].ToString();
                            //mSysLog.Remark = "管理员删除了源：" + aaa.Source;
                            //DAL.SysLog bllSysLog = new DAL.SysLog(); bllSysLog.Add(mSysLog);
                        }

                    }
                    else
                    {
                        DataSet data = DAL.SourceMap.GetList("Source='" + sourcttext + "'");
                        List<int> ID = new List<int>();
                        for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                        {
                            ID.Add(int.Parse(data.Tables[0].Rows[i]["ID"].ToString()));
                        }
                        for (int k = 0; k < ID.Count; k++)
                        {
                            DAL.SourceMap.Delete(ID[k]);
                        }
                        string[] map = paras[4].Split(';');
                        for (int j = 0; j < map.Length - 1; j++)
                        {
                            string[] ll = map[j].Split(':');
                            Model.ServiceConnection sc = DAL.ServiceConnection.GetModel(ll[0]);
                            Model.SourceMap sm = new Model.SourceMap();
                            sm.Source = st.Source;
                            sm.SourceType = st.SourceType;
                            sm.ServiceIP = sc.ServiceIP;
                            sm.ServicePort = sc.ServicePort;
                            sm.ServiceName = sc.ServiceName;
                            sm.MapSource = ll[1];
                            sm.PrecedenceLevel = int.Parse(ll[2]);
                            sm.AllowMaxNum = int.Parse(ll[3]);
                            DAL.SourceMap.Add(sm);
                        }

                    }

                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                catch (Exception)
                {


                }
               
            }
            #endregion



            #region 加载服务列表
            if (method == "loadservice")
            {
                Model.ServiceConnection sc = DAL.ServiceConnection.GetModel(int.Parse(para));
                string res = "";
                res = sc.ServiceName + "_;" + sc.ServiceIP + "_;" + sc.ServicePort + "_;" + sc.SourceTable;
                Response.Clear();
                Response.Write(res);
                Response.End();
            }
            #endregion

            #region 删除服务列表
            if (method == "deleservice")
            {
                try
                {
                    string[] ids = para.Split(',');
                    for (int i = 0; i < ids.Length - 1; i++)
                    {
                        Model.ServiceConnection nnn = DAL.ServiceConnection.GetModel(int.Parse(ids[i]));
                        DAL.ServiceConnection.Delete(int.Parse(ids[i]));
                        DataSet ds = DAL.SourceMap.GetList("ServiceName='" + nnn.ServiceName + "'");
                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            DAL.SourceMap.Delete(Convert.ToInt32(ds.Tables[0].Rows[j]["ID"]));
                        }
                        //Model.SysLog mSysLog = new Model.SysLog();
                        //mSysLog.LogTime = DateTime.Now;
                        //mSysLog.LogType = 0;
                        //mSysLog.UserName = Session["UserName"].ToString();
                        //mSysLog.Remark = "管理员删除了服务及相关源：" + nnn.ServiceName;
                        //DAL.SysLog bllSysLog = new DAL.SysLog(); bllSysLog.Add(mSysLog);
                    }
                    Response.Clear();
                    Response.Write("1");
                    Response.End();

                }
                catch (Exception)
                {


                }

            }
            #endregion

            #region 添加服务
            if (method == "addservice")
            {
                string result = "false";
                string[] paras = para.Split(',');
                DataSet data = DAL.SourceTable.GetList("Source='" + paras[0].ToString().Trim() + "'");
                if (data.Tables[0].Rows.Count > 0)
                {
                    Response.Clear();
                    Response.Write("0");
                    Response.End();
                }
                else
                {
                    try
                    {
                        Model.ServiceConnection sc = new Model.ServiceConnection();
                        sc.ServiceName = paras[0];
                        sc.ServiceIP = paras[1];
                        sc.ServicePort = paras[2];
                        NTRIPClient ntripcs = new NTRIPClient(new System.Net.IPEndPoint(System.Net.IPAddress.Parse(sc.ServiceIP), int.Parse(sc.ServicePort)), "", "");
                        SourceTable table = ntripcs.GetSourceTable();
                        sc.SourceTable = "";
                        for (int i = 0; i < table.DataStreams.Count; i++)
                        {
                            sc.SourceTable = sc.SourceTable + table.DataStreams[i].MountPoint + ";";
                        }
                        DAL.ServiceConnection.Add(sc);
                        Model.ServiceConnection msc = DAL.ServiceConnection.GetModel(sc.ServiceName);
                        result = msc.ID.ToString();
                        Response.Clear();
                        Response.Write(result);
                        Response.End();
                        //Model.SysLog mSysLog = new Model.SysLog();
                        //mSysLog.LogTime = DateTime.Now;
                        //mSysLog.LogType = 0;
                        //mSysLog.UserName = Session["UserName"].ToString();
                        //mSysLog.Remark = "管理员添加服务：" + paras[0] ;
                        //DAL.SysLog bllSysLog = new DAL.SysLog(); bllSysLog.Add(mSysLog);

                    }
                    catch (Exception)
                    {


                    }
                }
            }
            #endregion

            #region 修改服务
            if (method == "saveservice")
            {
                //try
                //{
                string[] paras = para.Split(',');
                Model.ServiceConnection sc = DAL.ServiceConnection.GetModel(paras[1]);
                string servicename = sc.ServiceName;
                sc.ServiceName = paras[1];
                sc.ServiceIP = paras[2];
                sc.ServicePort = paras[3];
                if (paras[4] == "")
                {
                    NTRIPClient ntripcs = new NTRIPClient(new System.Net.IPEndPoint(System.Net.IPAddress.Parse(sc.ServiceIP), int.Parse(sc.ServicePort)), "", "");
                    SourceTable table = ntripcs.GetSourceTable();
                    sc.SourceTable = "";
                    for (int i = 0; i < table.DataStreams.Count; i++)
                    {
                        sc.SourceTable = sc.SourceTable + table.DataStreams[i].MountPoint + ";";
                    }
                }
                else
                {
                    sc.SourceTable = paras[4];
                }
                DAL.ServiceConnection.Update(sc);
                if (sc.SourceTable == servicename)
                {
                    DataSet ds = DAL.SourceMap.GetList("ServiceName='" + servicename + "'");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Model.SourceMap msm = DAL.SourceMap.GetModel(Convert.ToInt32(ds.Tables[0].Rows[i]["ID"]));
                        msm.ServiceName = sc.ServiceName;
                        msm.ServiceIP = sc.ServiceIP;
                        msm.ServicePort = sc.ServicePort;
                        DAL.SourceMap.Update(msm);
                    }

                }
                else//如果源列表发生变化，则删除所有相关映射
                {
                    DataSet ds = DAL.SourceMap.GetList("ServiceName='" + sc.ServiceName + "'");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Model.SourceMap msm = DAL.SourceMap.GetModel(Convert.ToInt32(ds.Tables[0].Rows[i]["ID"]));
                        DAL.SourceMap.Delete(msm.ID);
                    }

                }
                Response.Clear();
                Response.Write("1");
                Response.End();
                //}
                //catch (Exception)
                //{

                //}

            }
            #endregion

            #region 更新服务
            if (method == "gxylb")
            {
                string result = "0";
                string[] paras = para.Split(',');
                string ip = paras[0];
                string port = paras[1];
                try
                {
                    NTRIPClient ntripcs = new NTRIPClient(new System.Net.IPEndPoint(System.Net.IPAddress.Parse(ip), int.Parse(port)), "", "");
                    SourceTable table = ntripcs.GetSourceTable();
                    string sourceTable = "";
                    for (int i = 0; i < table.DataStreams.Count; i++)
                    {
                        sourceTable = sourceTable + table.DataStreams[i].MountPoint + ";";
                    }
                    result = "1";
                    Response.Clear();
                    Response.Write(result + "_;" + sourceTable);
                    Response.End();
                }
                catch (Exception)
                {


                }

            }
            #endregion

        }
    }
}