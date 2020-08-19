<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ephemeris.aspx.cs" Inherits="CORSV2.forms.administrator.system.Ephemeris" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>星历数据</title>
    <link rel="shortcut icon" href="../../favicon.ico" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet" />
    <link href="../../../js/plugins/boostrap-datetimepicker/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../js/plugins/boostrap-datetimepicker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
<style>
    .link{
        padding-top: 5px;
    display: block;
    text-decoration: underline;
    padding-left:0px !important;
    }
</style>
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content  animated fadeInRight" style="padding-top:0px;">
        <div class="row" style="padding-left:0px;padding-right:0px;">
            <div class="col-sm-8" style="padding-left:0px;padding-right:0px;width: 100%;" >
                <div class="ibox">
                <div class="ibox-content" style="height:400px;min-height:400px;">

                    <div class="col-lg-2 col-sm-2">
                        <div id="date"></div>
                    </div>
                    <div class="form-horizontal col-lg-10 col-sm-10" id="gpsdata">
                        <div class="form-group">
                            <label class="control-label col-lg-2">日期</label>
                            <input type="text" id="mirror_field" value="" readonly />
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2">年积日</label>
                            <input type="text" id="doy" value="" readonly />
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2">GPS周</label>
                            <input type="text" id="gw" value="" readonly />
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2">GPS周 星期记数</label>
                            <input type="text" id="dw" value="" readonly />
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2">精密星历</label>
                            <a href="#" id="sp3" class="col-lg-10 link" target="_blank"></a>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2">快速星历</label>
                            <a href="#" id="fephe" class="col-lg-10 link" target="_blank"> </a>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-lg-2">超快速星历</label>
                            <div class="col-lg-10" style="padding-left:0px;">
                                 <a href="#" id="sf00" class="link" target="_blank"></a>
                            <a href="#" id="sf06" class="link" target="_blank"></a>
                            <a href="#" id="sf12" class="link" target="_blank"></a>
                            <a href="#" id="sf18" class="link" target="_blank"></a>
                            </div>
                           

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </div>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=7bGCq1WUPVv5H4LDIpH7u12v"></script>
    <script src="../../../js/jquery.min.js"></script>
    <script src="../../../js/bootstrap.min.3.2.0.js"></script>
    <%--<script src="../../../js/plugins/boostrap-datetimepicker/jquery/jquery-1.8.3.min.js" charset="UTF-8"></script>
    <script src="../../../js/plugins/boostrap-datetimepicker/bootstrap/js/bootstrap.min.js"></script>--%>

    <script src="../../../js/plugins/boostrap-datetimepicker/js/bootstrap-datetimepicker.min.js" charset="UTF-8"></script>
    <script src="../../../js/plugins/boostrap-datetimepicker/js/locales/bootstrap-datetimepicker.zh-CN.js" charset="UTF-8"></script>
    <script>

        var squeryPara = new Array();
        squeryPara["date"] = "";
        squeryPara["station"] = "";
        var today = new Date();
        var option = {
            language: 'zh-CN',
            format: 'yyyy-mm-dd',
            todayBtn: true,
            minView: 2,
            endDate: today.toLocaleDateString(),
            todayHighlight: true,
            linkField: "mirror_field",
            linkFormat: "yyyy-mm-dd"
        };
        $('#date').datetimepicker(option).on('changeDate', function (ev) {
            $.ajax({
                url: "?action=GetGPSDate&date=" + $("#mirror_field").val(),
                type: "get",
                success: function (data) {
                    ShowAllDownload(data);
                }

            });
        });
        function ShowAllDownload(data) {
            var pp = data.split(';');
            var gw = pp[1];
            var dw = pp[2];
            var doy = pp[3];
            $("#doy").val(doy);
            $("#gw").val(gw);
            $("#dw").val(gw + dw);
            $("#sp3").attr("href", "ftp://cddis.gsfc.nasa.gov/pub/gps/products/" + gw + "/igs" + gw + gw + ".sp3.Z");
            $("#sp3").text("igs" + gw + dw + ".sp3.Z");
            $("#fephe").attr("href", "ftp://cddis.gsfc.nasa.gov/pub/gps/products/" + gw + "/igr" + gw + dw + ".sp3.Z");
            $("#fephe").text("igr" + gw + dw + ".sp3.Z");
            $("#sf00").attr("href", "ftp://cddis.gsfc.nasa.gov/pub/gps/products/" + gw + "/igu" + gw + dw + "_00.sp3.Z");
            $("#sf00").text("igu" + gw + dw + "_00.sp3.Z");
            $("#sf06").attr("href", "ftp://cddis.gsfc.nasa.gov/pub/gps/products/" + gw + "/igu" + gw + dw + "_06.sp3.Z");
            $("#sf06").text("igu" + gw + dw + "_06.sp3.Z");
            $("#sf12").attr("href", "ftp://cddis.gsfc.nasa.gov/pub/gps/products/" + gw + "/igu" + gw + dw + "_12.sp3.Z");
            $("#sf12").text("igu" + gw + dw + "_12.sp3.Z");
            $("#sf18").attr("href", "ftp://cddis.gsfc.nasa.gov/pub/gps/products/" + gw + "/igu" + gw + dw + "_18.sp3.Z");
            $("#sf18").text("igu" + gw + dw + "_18.sp3.Z");
            $("#gpsdata").show();
        }

        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.StationOName;
            });
        }
        $("#download").click(function () {
            var ids = getIdSelections().join(",");
            if (ids.length < 1) {
                alert("请选择基站");
                $("#download").blur();
                return;
            }
            window.location.href = "?action=DownloadAll&date=" + squeryPara["date"] + "&station=" + ids;
            $("#download").blur();
        });

        Date.prototype.Format = function (fmt) { //author: meizz 
            var o = {
                "M+": this.getMonth() + 1, //月份 
                "d+": this.getDate(), //日 
                "h+": this.getHours(), //小时 
                "m+": this.getMinutes(), //分 
                "s+": this.getSeconds(), //秒 
                "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
                "S": this.getMilliseconds() //毫秒 
            };
            if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
            for (var k in o)
                if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
            return fmt;
        }

        $(document).ready(function () {
            var today = new Date().Format("yyyy-MM-dd");
            $("#mirror_field").val(today);
            $.ajax({
                url: "?action=GetGPSDate&date=" + $("#mirror_field").val(),
                type: "get",
                success: function (data) {
                    ShowAllDownload(data);
                }

            });
        });
    </script>
</body>
</html>

