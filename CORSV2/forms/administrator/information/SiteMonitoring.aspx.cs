using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CORSV2.forms.administrator.information
{
    public partial class SiteMonitoring : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert(\"请登录\");location.href = location.origin+\"/forms/Index.aspx\";</script>");
                Response.End();
            }
            if (Session["UserType"] == null || (Convert.ToInt32(Session["UserType"]) != 2 && Convert.ToInt32(Session["UserType"]) != 3))
            {
                Response.Write("<script>alert(\"登录账户类型有误\");location.href = location.origin+\"/forms/Index.aspx\";</script>");
                Response.End();
            }
            if (!IsPostBack)
            {
                string stoname = Request["StationOName"].ToString();
                Model.SiteMonitoring ms = DAL.SiteMonitoring.GetModel(stoname);
                StationOName.Value = ms.StationOName;
                SatelliteType.Value = ms.SatelliteType;
                Numbering.Value = ms.Numbering;
                Track.Value = ms.Track;
                Quantity.Value = ms.Quantity;
                Angle.Value = ms.Angle;
                Time.Value = ms.Time.ToString();
                Ratio.Value = ms.Ratio;
                if (ms.StorageEable == 1)
                {
                    StorageEable.SelectedIndex = 0;
                }
                else
                {
                    StorageEable.SelectedIndex = 1;
                }
                DesignCapacity.Value = ms.DesignCapacity;
                UsedstorageSpace.Value = ms.UsedstorageSpace;
                AvailablestorageSpace.Value = ms.AvailablestorageSpace;
                if (ms.AvailablestorageSpace != "" && (ms.DesignCapacity) != "")
                { AvailablestorageSpaceRate.Value = (double.Parse(ms.AvailablestorageSpace) / double.Parse(ms.DesignCapacity) * 100).ToString() + "%"; }
                ReceiverTemperature.Value = ms.ReceiverTemperature;
                ReceiverVoltage.Value = ms.ReceiverVoltage;
                ReceiverElectricity.Value = ms.ReceiverElectricity;
                ReceiverCPU.Value = ms.ReceiverCPU;
                WeatherTemperature.Value = ms.WeatherTemperature;
                WeatherVoltage.Value = ms.WeatherVoltage;
                WeatherElectricity.Value = ms.WeatherElectricity;
                WeatherCPU.Value = ms.WeatherCPU;
                UPSTemperature.Value = ms.UPSTemperature;
                UPSVoltage.Value = ms.UPSVoltage;
                UPSElectricity.Value = ms.UPSElectricity;
                UPSCPU.Value = ms.UPSCPU;
            }
            if (Request["action"] == "save")
            {
                Model.SiteMonitoring ms = DAL.SiteMonitoring.GetModel(Request.Form["StationOName"].ToString().Trim());
                ms.Numbering = Request.Form["Numbering"].ToString();
                ms.Track = Request.Form["Track"].ToString();
                ms.Quantity = Request.Form["Quantity"].ToString();
                ms.Angle = Request.Form["Angle"].ToString();
                ms.Time = DateTime.Parse(Request.Form["Time"].ToString());
                ms.Ratio = Request.Form["Ratio"].ToString();
                if (Request.Form["StorageEable"].ToString() == "可用")
                {
                    ms.StorageEable = 1;
                }
                else
                {
                    ms.StorageEable = 1;
                }
                ms.DesignCapacity = Request.Form["DesignCapacity"].ToString();
                ms.UsedstorageSpace = Request.Form["UsedstorageSpace"].ToString();
                ms.AvailablestorageSpace = Request.Form["AvailablestorageSpace"].ToString();
                ms.ReceiverTemperature = Request.Form["ReceiverTemperature"].ToString();
                ms.ReceiverVoltage = Request.Form["ReceiverVoltage"].ToString();
                ms.ReceiverElectricity = Request.Form["ReceiverElectricity"].ToString();
                ms.ReceiverCPU = Request.Form["ReceiverCPU"].ToString();
                ms.WeatherTemperature = Request.Form["WeatherTemperature"].ToString();
                ms.WeatherVoltage = Request.Form["WeatherVoltage"].ToString();
                ms.WeatherElectricity = Request.Form["WeatherElectricity"].ToString();
                ms.WeatherCPU = Request.Form["WeatherCPU"].ToString();
                ms.UPSTemperature = Request.Form["UPSTemperature"].ToString();
                ms.UPSVoltage = Request.Form["UPSVoltage"].ToString();
                ms.UPSElectricity = Request.Form["UPSElectricity"].ToString();
                ms.UPSCPU = Request.Form["UPSCPU"].ToString();

                bool result = DAL.SiteMonitoring.Update(ms);

                if (result)
                {
                    Response.Clear();
                    Response.Write("1");
                    Response.End();
                }
                else
                {
                    Response.Clear();
                    Response.Write("0");
                    Response.End();
                }
            }

        }
    }
}