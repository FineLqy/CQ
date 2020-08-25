<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StationInfoSet.aspx.cs" Inherits="CORSV2.forms.administrator.information.StationInfoSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">


    <title>基站信息管理</title>



    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="../../../themes/css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
</head>

<body>
   
        <form runat="server" method="post" id="Form">

            <div class="col-sm-6" style="width: 100%">
                <div class="ibox float-e-margins">
                    <div class="ibox-content">
                        <div class="panel-body">
                            <div class="panel-group" id="accordion">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">1</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseOne">站址信息</a>
                                        </h5>
                                    </div>
                                    <div id="collapseOne" class="panel-collapse collapse in">

                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">基站名</label>
                                            <input type="text" id="StationName" readonly="readonly" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">Rinex站名</label>
                                            <input type="text" id="StationOName" readonly="readonly" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">运行情况</label>
                                            <select name="IsOK" id="IsOK" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 20%">
                                                <option>正常</option>
                                                <option>异常</option>
                                            </select>
                                            <input type="text" style="display:none" runat="server" id="stationid" />
                                        </div>
                                        <div class="hr-line-dashed"></div>

                                        <div>
                                            <label style="width: 10%; text-align: center">传输类型</label>
                                            <select name="account" id="TransferType" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 20%">
                                                <option>TCP/IP</option>
                                                <option>Ntrip</option>
                                            </select>

                                            <label style="width: 10%; text-align: center">IP</label>
                                            <input type="text" id="IP" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">

                                            <label style="width: 10%; text-align: center">端口</label>
                                            <input type="text" id="Port" runat="server" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">纬度</label>
                                            <input type="text" name="Lat" id="Lat" runat="server" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">经度</label>
                                            <input type="text" name="Lon" id="Lon" runat="server" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">高度（米）</label>
                                            <input type="text" id="H" name="H" runat="server" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">基站型号</label>
                                            <input type="text" name="StationType" id="StationType" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">备案号</label>
                                            <input type="text" name="CaseNumber" id="CaseNumber" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">建站时间</label>
                                            <input class=" layer-date" id="BuildTime" runat="server" style="width: 20%; height: 32px; vertical-align: top; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px; max-width: none" placeholder="YYYY-MM-DD hh:mm:ss" onclick="laydate({ istime: true, format: 'YYYY-MM-DD hh:mm:ss' })">
                                            <label class="laydate-icon" style="width: 2%; height: 32px; vertical-align: top"></label>

                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">所属站网</label>
                                            <input type="text" name="AffiliatedNetwork" id="AffiliatedNetwork" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">墩标类型</label>
                                            <input type="text" name="PiersType" id="PiersType" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">依托单位</label>
                                            <input type="text" id="RelyUnits" name="RelyUnits" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>

                                        <div>
                                            <label style="width: 10%; text-align: center">所在地区</label>
                                            <input type="text" name="Address" id="Address" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">土层厚度</label>
                                            <input type="text" name="ThicknessOfLayer" id="ThicknessOfLayer" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">交通情况</label>
                                            <input type="text" id="TrafficCondition" name="TrafficCondition" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">选点者信息</label>
                                            <input type="text" name="SitePerson" id="SitePerson" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">建站者信息</label>
                                            <input type="text" name="Builder" id="Builder" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">2</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseTwo">地质地形信息</a>
                                        </h5>
                                    </div>
                                    <div id="collapseTwo" class="panel-collapse collapse in">
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">地类土质</label>
                                            <input type="text" name="SoilType" id="SoilType" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">冻土深度</label>
                                            <input type="text" name="PermafrostDepth" id="PermafrostDepth" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">解冻深度</label>
                                            <input type="text" name="ThawDepth" id="ThawDepth" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>

                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">地下水深度</label>
                                            <input type="text" name="GroundwaterDepth" id="GroundwaterDepth" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">所在图幅</label>
                                            <input type="text" name="BelongsMap" id="BelongsMap" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center; vertical-align: top">基础岩性和地质构造说明</label>
                                            <textarea id="GeologicalStructure" name="GeologicalStructure" style="width: 81%; height: 120px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px" runat="server">
                               
                                            </textarea>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">3</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseThree">其他信息</a>
                                        </h5>
                                    </div>
                                    <div id="collapseThree" class="panel-collapse collapse in">
                                        <div class="hr-line-dashed"></div>
                                        <label style="width: 10%; text-align: center">维护单位</label>
                                        <input type="text" id="MaintenanceUnit" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        <label style="width: 10%; text-align: center">维护人</label>
                                        <input type="text" id="ContactPerson" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        <label style="width: 10%; text-align: center">联系电话</label>
                                        <input type="text" id="ContactTel" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        <div class="hr-line-dashed"></div>
                                        <label style="width: 10%; text-align: center">平面图</label>
                                        <input type="text" id="StationPlan" runat="server" readonly="readonly" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        <input type="button" id="viewPlan" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="查看" />
                                        <input type="button" id="browerPlan" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="浏览" onclick="FilePlan.click()" />
                                        <input type="button" id="uploadPlan" disabled="disabled" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="上传" />
                                        <input id="FilePlan" type="file" runat="server" style="display:none; height:1px;width:1px" accept="image/*" />                   
                                         <label style="width: 5%"></label>
                                        <label style="width: 10%; text-align: center">环视图</label>
                                        <input type="text" id="RingView" runat="server" readonly="readonly" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        <input type="button" id="viewRingView" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="查看" />
                                        <input type="button" id="browerRingView" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="浏览" onclick="FileRingView.click()" />
                                        <input type="button" id="uploadRingView" disabled="disabled" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="上传" />
                                        <input id="FileRingView" type="file" runat="server" style="display:none; height:1px;width:1px" accept="image/*" onchange="RingView.value=this.value;" />                   
                                       
                                        <div class="hr-line-dashed"></div>
                                         <label style="width: 10%; text-align: center">重力墩</label>
                                        <input type="text" id="GravityPier" runat="server" readonly="readonly" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        <input type="button" id="viewGravityPier" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="查看" />
                                        <input type="button" id="browerGravityPier" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="浏览" onclick="FileGravityPier.click()" />
                                        <input type="button" id="uploadGravityPier" disabled="disabled" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="上传" />
                                        <input id="FileGravityPier" type="file" runat="server" style="display:none; height:1px;width:1px" accept="image/*" />                   
                                         <label style="width: 5%"></label>
                                        <label style="width: 10%; text-align: center">水准标志</label>
                                        <input type="text" id="LevelSign" runat="server" readonly="readonly" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        <input type="button" id="viewLevelSign" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="查看" />
                                        <input type="button" id="browerLevelSign" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="浏览" onclick="FileLevelSign.click()" />
                                        <input type="button" id="uploadLevelSign" disabled="disabled" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="上传" />
                                        <input id="FileLevelSign" type="file" runat="server" style="display:none; height:1px;width:1px" accept="image/*" onchange="LevelSign.value=this.value;" />                   
                                       
                                        <div class="hr-line-dashed"></div>
                                         <label style="width: 10%; text-align: center">基站照片</label>
                                        <input type="text" id="StationPhoto" runat="server" readonly="readonly" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        <input type="button" id="viewStationPhoto" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="查看" />
                                        <input type="button" id="browerStationPhoto" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="浏览" onclick="FileStationPhoto.click()" />
                                        <input type="button" id="uploadStationPhoto" disabled="disabled" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="上传" />
                                        <input id="FileStationPhoto" type="file" runat="server" style="display:none; height:1px;width:1px" accept="image/*" />                   
                                         <label style="width: 5%"></label>
                                        <label style="width: 10%; text-align: center">房屋和防雷监测报告</label>
                                        <input type="text" id="LightningReport" runat="server" readonly="readonly" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        <input type="button" id="viewLightningReport" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="查看" />
                                        <input type="button" id="browerLightningReport" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="浏览" onclick="FileLightningReport.click()" />
                                        <input type="button" id="uploadLightningReport" disabled="disabled" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="上传" />
                                        <input id="FileLightningReport" type="file" runat="server" style="display:none; height:1px;width:1px" accept=".pdf" onchange="LightningReport.value=this.value;" />                   
                                       
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center; vertical-align: top">环境说明</label>
                                            <textarea id="EnvironmentalDescription" name="EnvironmentalDescription" style="width: 81%; height: 120px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px" runat="server">
                               
                                            </textarea>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center; vertical-align: top">站点条件信息</label>
                                            <textarea id="SiteConditions" name="SiteConditions" style="width: 81%; height: 120px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px" runat="server">
                               
                                            </textarea>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <button class="btn btn-sm btn-primary" type="button" style="margin-left: 45%;width:8%" id="save">保存</button>
                                        <div class="hr-line-dashed"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


        </form>

    <!-- 全局js -->
    <script src="../../../js/jquery.min.js?v=2.1.4"></script>
    <script src="../../../js/bootstrap.min.js?v=3.3.6"></script>
    <script src="../../../js/jquery.form.js"></script>
    <!-- 自定义js -->
    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/layer/laydate/laydate.js"></script>
    <script>
       
        //$("#browerPlan").click(function () {
        //    var filplan = document.getElementById("FilePlan");
        //    filplan.click();
        //});
        $("#FilePlan").change(function () {
            var Plan = document.getElementById("StationPlan");
            var filplan = document.getElementById("FilePlan");
            if (filplan.files.length > 0) {
                Plan.value = filplan.files[0].name;
            }
            else {
                Plan.value = "";
            }
            var upload = document.getElementById("uploadPlan");
            if (Plan.value != "") {

                upload.disabled = false;
            }
            else { upload.disabled = true; }
        });
        $("#FileRingView").change(function () {
            var RingView = document.getElementById("RingView");
            var filRingView = document.getElementById("FileRingView");
            if (filRingView.files.length > 0) {
                RingView.value = filRingView.files[0].name;
            }
            else {
                RingView.value = "";
            }
            var upload = document.getElementById("uploadRingView");
            if (RingView.value != "") {

                upload.disabled = false;
            }
            else { upload.disabled = true; }
        });
        $("#uploadPlan").click(function () {
            var FilePlan1 = document.getElementById("FilePlan");
            var FilePlan2 = FilePlan1.value;
            var extStart = FilePlan2.lastIndexOf(".");
            var ext = FilePlan2.substring(extStart, FilePlan2.length).toUpperCase();
            if (ext != ".BMP" && ext != ".PNG" && ext != ".GIF" && ext != ".JPG" && ext != ".JPEG") {

                layer.alert('平面图为png,gif,jpeg,jpg格式图片！', {
                    skin: 'layui-layer-lan' //样式类名
                                 , closeBtn: 0
                });
                var Plan = document.getElementById("StationPlan");
                Plan.value = "";
                return false;
            }


            var isIE = /msie/i.test(navigator.userAgent) && !window.opera;
            var fileSize = 0;
            if (isIE && !FilePlan1.files) {
                var filePath = FilePlan1.value;
                var fileSystem = new ActiveXObject("Scripting.FileSystemObject");
                var file = fileSystem.GetFile(filePath);
                fileSize = file.Size;
            } else {
                fileSize = FilePlan1.files[0].size;
            }
            var size = fileSize / 1024;
            if (size > 2000) {
                layer.alert('图片大小不能超过2M！', {
                    skin: 'layui-layer-lan' //样式类名
                                                         , closeBtn: 0
                });
                var Plan = document.getElementById("StationPlan");
                Plan.value = "";
                return false;

            }


            var options = {
                url: "StationInfoSet.aspx?upload=plan",
                success: function (result) {
                    if (result == "1") {
                        layer.alert('上传成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        var upload = document.getElementById("uploadPlan");
                        upload.disabled = true;
                        var Plan = document.getElementById("StationPlan");
                        var filplan = document.getElementById("FilePlan");
                        var viewPlan = document.getElementById("viewPlan");
                        var stname = document.getElementById("StationName");
                        var suffix = filplan.files[0].name.split('.')[filplan.files[0].name.split('.').length - 1];
                        Plan.value = "/upload/PLAN/" + stname.value.trim() + "." + suffix;
                        viewPlan.disabled = false;
                    }
                    else {
                        layer.alert('上传失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                }, error: function () {
                    layer.alert('上传失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            };
            $("#Form").ajaxSubmit(options);
            // $("#Form").ajaxForm(options);
        });
        $("#uploadRingView").click(function () {

            var RingView1 = document.getElementById("FileRingView");
            var RingView2 = RingView1.value;
            var extStart = RingView2.lastIndexOf(".");
            var ext = RingView2.substring(extStart, RingView2.length).toUpperCase();
            if (ext != ".BMP" && ext != ".PNG" && ext != ".GIF" && ext != ".JPG" && ext != ".JPEG") {

                layer.alert('环视图为png,gif,jpeg,jpg格式图片！', {
                    skin: 'layui-layer-lan' //样式类名
                                 , closeBtn: 0
                });
                var RingView = document.getElementById("RingView");
                RingView.value = "";
                return false;
            }


            var isIE = /msie/i.test(navigator.userAgent) && !window.opera;
            var fileSize = 0;
            if (isIE && !RingView1.files) {
                var filePath = RingView1.value;
                var fileSystem = new ActiveXObject("Scripting.FileSystemObject");
                var file = fileSystem.GetFile(filePath);
                fileSize = file.Size;
            } else {
                fileSize = RingView1.files[0].size;
            }
            var size = fileSize / 1024;
            if (size > 2000) {
                layer.alert('图片大小不能超过2M！', {
                    skin: 'layui-layer-lan' //样式类名
                                                         , closeBtn: 0
                });
                var RingView = document.getElementById("RingView");
                RingView.value = "";
                return false;

            }

            var options = {
                url: "StationInfoSet.aspx?upload=ringview",
                success: function (result) {
                    if (result == "1") {
                        layer.alert('上传成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        var RingView = document.getElementById("RingView");
                        var filRingView = document.getElementById("FileRingView");
                        var stname = document.getElementById("StationName");
                        var viewRingView = document.getElementById("viewRingView");
                        var suffix = filRingView.files[0].name.split('.')[filRingView.files[0].name.split('.').length - 1];
                        RingView.value = "/upload/RINGVIEW/" + stname.value.trim() + "." + suffix;
                        viewRingView.disabled = false;

                    }
                    else {
                        layer.alert('上传失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                }, error: function () {
                    layer.alert('上传失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            };
            $("#Form").ajaxSubmit(options);
            // $("#Form").ajaxForm(options);
        });
        $("#viewPlan").click(function () {
            var Plan = document.getElementById("StationPlan");
            parent.layer.open({
                type: 2,
                title: '平面图',
                shadeClose: true,
                shade: 0.8,
                area: ['40%', '60%'],
                content: 'ViewPic.aspx?src=' + Plan.value //iframe的url
            });
        });
        $("#viewRingView").click(function () {
            var RingView = document.getElementById("RingView");
            parent.layer.open({
                type: 2,
                title: '环视图',
                shadeClose: true,
                shade: 0.8,
                area: ['40%', '60%'],
                content: 'ViewPic.aspx?src=' + RingView.value //iframe的url
            });
        });
        function getPath(node) {
            var imgURL = "";
            try{
                var file = null;
                if(node.files && node.files[0] ){
                    file = node.files[0];
                }else if(node.files && node.files.item(0)) {
                    file = node.files.item(0);
                }
                //Firefox 因安全性问题已无法直接通过input[file].value 获取完整的文件路径
                try{
                    //Firefox7.0
                    imgURL =  file.getAsDataURL();
                    //alert("//Firefox7.0"+imgRUL);
                }catch(e){
                    //Firefox8.0以上
                    imgURL = window.URL.createObjectURL(file);
                    //alert("//Firefox8.0以上"+imgRUL);
                }
            }catch(e){      //这里不知道怎么处理了，如果是遨游的话会报这个异常
                //支持html5的浏览器,比如高版本的firefox、chrome、ie10
                if (node.files && node.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        imgURL = e.target.result;
                    };
                    reader.readAsDataURL(node.files[0]);
                }
            }
            return imgURL;
        
        }
        $("#FileGravityPier").change(function () {
            var GravityPier = document.getElementById("GravityPier");
            var filGravityPier = document.getElementById("FileGravityPier");
            if (filGravityPier.files.length > 0) {            
                GravityPier.value = filGravityPier.files[0].name;
            }
            else {
                GravityPier.value = "";
            }
            var upload = document.getElementById("uploadGravityPier");
            if (GravityPier.value != "") {
               
                upload.disabled = false;
            }
            else { upload.disabled = true; }
        });
        $("#FileLevelSign").change(function () {
            var LevelSign = document.getElementById("LevelSign");
            var filLevelSign = document.getElementById("FileLevelSign");
            if (filLevelSign.files.length > 0) {
                LevelSign.value = filLevelSign.files[0].name;
            }
            else {
                LevelSign.value = "";
            }
            var upload = document.getElementById("uploadLevelSign");
            if (LevelSign.value != "") {

                upload.disabled = false;
            }
            else { upload.disabled = true; }
        });
        $("#uploadGravityPier").click(function () {
            var FileGravityPier1 = document.getElementById("FileGravityPier");
            var FileGravityPier2 = FileGravityPier1.value;
            var extStart = FileGravityPier2.lastIndexOf(".");
            var ext = FileGravityPier2.substring(extStart, FileGravityPier2.length).toUpperCase();
            if (ext != ".BMP" && ext != ".PNG" && ext != ".GIF" && ext != ".JPG" && ext != ".JPEG") {

                layer.alert('重力墩为png,gif,jpeg,jpg格式图片！', {
                    skin: 'layui-layer-lan' //样式类名
                                 , closeBtn: 0
                });
                var GravityPier = document.getElementById("StationGravityPier");
                GravityPier.value = "";
                return false;
            }

            
            var isIE = /msie/i.test(navigator.userAgent) && !window.opera;
            var fileSize = 0;
            if (isIE && !FileGravityPier1.files) {
                var filePath = FileGravityPier1.value;
                var fileSystem = new ActiveXObject("Scripting.FileSystemObject");
                var file = fileSystem.GetFile(filePath);
                fileSize = file.Size;
            } else {
                fileSize = FileGravityPier1.files[0].size;
            }
            var size = fileSize / 1024;
            if (size > 2000) {
                layer.alert('图片大小不能超过2M！', {
                    skin: 'layui-layer-lan' //样式类名
                                                         , closeBtn: 0
                });
                var GravityPier = document.getElementById("StationGravityPier");
                GravityPier.value = "";
                return false;

            }


            var options = {
                url: "StationInfoSet.aspx?upload=GravityPier",
                success: function (result) {
                    if (result == "1") {
                        layer.alert('上传成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        var upload = document.getElementById("uploadGravityPier");
                        upload.disabled = true;
                        var GravityPier = document.getElementById("StationGravityPier");
                        var filGravityPier = document.getElementById("FileGravityPier");
                        var viewGravityPier = document.getElementById("viewGravityPier");
                        var stname = document.getElementById("StationName");
                        var suffix = filGravityPier.files[0].name.split('.')[filGravityPier.files[0].name.split('.').length - 1];
                        GravityPier.value = "/upload/GravityPier/" + stname.value.trim() + "." + suffix;
                        viewGravityPier.disabled = false;
                    }
                    else {
                        layer.alert('上传失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                }, error: function () {
                    layer.alert('上传失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            };
            $("#Form").ajaxSubmit(options);
           // $("#Form").ajaxForm(options);
        });
        $("#uploadLevelSign").click(function () {

            var LevelSign1 = document.getElementById("FileLevelSign");
            var LevelSign2 = LevelSign1.value;
            var extStart = LevelSign2.lastIndexOf(".");
            var ext = LevelSign2.substring(extStart, LevelSign2.length).toUpperCase();
            if (ext != ".BMP" && ext != ".PNG" && ext != ".GIF" && ext != ".JPG" && ext != ".JPEG") {

                layer.alert('水准标志为png,gif,jpeg,jpg格式图片！', {
                    skin: 'layui-layer-lan' //样式类名
                                 , closeBtn: 0
                });
                var LevelSign = document.getElementById("LevelSign");
                LevelSign.value = "";
                return false;
            }


            var isIE = /msie/i.test(navigator.userAgent) && !window.opera;
            var fileSize = 0;
            if (isIE && !LevelSign1.files) {
                var filePath = LevelSign1.value;
                var fileSystem = new ActiveXObject("Scripting.FileSystemObject");
                var file = fileSystem.GetFile(filePath);
                fileSize = file.Size;
            } else {
                fileSize = LevelSign1.files[0].size;
            }
            var size = fileSize / 1024;
            if (size > 2000) {
                layer.alert('图片大小不能超过2M！', {
                    skin: 'layui-layer-lan' //样式类名
                                                         , closeBtn: 0
                });
                var LevelSign = document.getElementById("LevelSign");
                LevelSign.value = "";
                return false;

            }

            var options = {
                url: "StationInfoSet.aspx?upload=LevelSign",
                success: function (result) {
                    if (result == "1") {
                        layer.alert('上传成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        var LevelSign = document.getElementById("LevelSign");
                        var filLevelSign = document.getElementById("FileLevelSign");
                        var stname = document.getElementById("StationName");
                        var viewLevelSign = document.getElementById("viewLevelSign");
                        var suffix = filLevelSign.files[0].name.split('.')[filLevelSign.files[0].name.split('.').length - 1];
                        LevelSign.value = "/upload/LevelSign/" + stname.value.trim() + "." + suffix;
                        viewLevelSign.disabled = false;

                    }
                    else {
                        layer.alert('上传失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                }, error: function () {
                    layer.alert('上传失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            };
            $("#Form").ajaxSubmit(options);
            // $("#Form").ajaxForm(options);
        });
        $("#viewGravityPier").click(function () {
            var GravityPier = document.getElementById("GravityPier");
            parent.layer.open({
                type: 2,
                title: '重力墩',
                shadeClose: true,
                shade: 0.8,
                area: ['40%', '60%'],
                content: 'ViewPic.aspx?src=' + GravityPier.value //iframe的url
            });
        });
        $("#viewLevelSign").click(function () {
            var LevelSign = document.getElementById("LevelSign");
            parent.layer.open({
                type: 2,
                title: '水准标志',
                shadeClose: true,
                shade: 0.8,
                area: ['40%', '60%'],
                content: 'ViewPic.aspx?src=' + LevelSign.value //iframe的url
            });
        });

        $("#FileStationPhoto").change(function () {
            var StationPhoto = document.getElementById("StationPhoto");
            var filStationPhoto = document.getElementById("FileStationPhoto");
            if (filStationPhoto.files.length > 0) {
                StationPhoto.value = filStationPhoto.files[0].name;
            }
            else {
                StationPhoto.value = "";
            }
            var upload = document.getElementById("uploadStationPhoto");
            if (StationPhoto.value != "") {

                upload.disabled = false;
            }
            else { upload.disabled = true; }
        });
        $("#FileLightningReport").change(function () {
            var LightningReport = document.getElementById("LightningReport");
            var filLightningReport = document.getElementById("FileLightningReport");
            if (filLightningReport.files.length > 0) {
                LightningReport.value = filLightningReport.files[0].name;
            }
            else {
                LightningReport.value = "";
            }
            var upload = document.getElementById("uploadLightningReport");
            if (LightningReport.value != "") {

                upload.disabled = false;
            }
            else { upload.disabled = true; }
        });
        $("#uploadStationPhoto").click(function () {
            var FileStationPhoto1 = document.getElementById("FileStationPhoto");
            var FileStationPhoto2 = FileStationPhoto1.value;
            var extStart = FileStationPhoto2.lastIndexOf(".");
            var ext = FileStationPhoto2.substring(extStart, FileStationPhoto2.length).toUpperCase();
            if (ext != ".BMP" && ext != ".PNG" && ext != ".GIF" && ext != ".JPG" && ext != ".JPEG") {

                layer.alert('基站照片为png,gif,jpeg,jpg格式图片！', {
                    skin: 'layui-layer-lan' //样式类名
                                 , closeBtn: 0
                });
                var StationPhoto = document.getElementById("StationPhoto");
                StationPhoto.value = "";
                return false;
            }


            var isIE = /msie/i.test(navigator.userAgent) && !window.opera;
            var fileSize = 0;
            if (isIE && !FileStationPhoto1.files) {
                var filePath = FileStationPhoto1.value;
                var fileSystem = new ActiveXObject("Scripting.FileSystemObject");
                var file = fileSystem.GetFile(filePath);
                fileSize = file.Size;
            } else {
                fileSize = FileStationPhoto1.files[0].size;
            }
            var size = fileSize / 1024;
            if (size > 2000) {
                layer.alert('图片大小不能超过2M！', {
                    skin: 'layui-layer-lan' //样式类名
                                                         , closeBtn: 0
                });
                var StationPhoto = document.getElementById("StationStationPhoto");
                StationPhoto.value = "";
                return false;

            }


            var options = {
                url: "StationInfoSet.aspx?upload=StationPhoto",
                success: function (result) {
                    if (result == "1") {
                        layer.alert('上传成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        var upload = document.getElementById("uploadStationPhoto");
                        upload.disabled = true;
                        var StationPhoto = document.getElementById("StationPhoto");
                        var filStationPhoto = document.getElementById("FileStationPhoto");
                        var viewStationPhoto = document.getElementById("viewStationPhoto");
                        var stname = document.getElementById("StationName");
                        var suffix = filStationPhoto.files[0].name.split('.')[filStationPhoto.files[0].name.split('.').length - 1];
                        StationPhoto.value = "/upload/StationPhoto/" + stname.value.trim() + "." + suffix;
                        viewStationPhoto.disabled = false;
                    }
                    else {
                        layer.alert('上传失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                }, error: function () {
                    layer.alert('上传失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            };
            $("#Form").ajaxSubmit(options);
            // $("#Form").ajaxForm(options);
        });
        $("#uploadLightningReport").click(function () {

            var LightningReport1 = document.getElementById("FileLightningReport");
            var LightningReport2 = LightningReport1.value;
            var extStart = LightningReport2.lastIndexOf(".");
            var ext = LightningReport2.substring(extStart, LightningReport2.length).toUpperCase();
            if (ext != ".PDF" ) {

                layer.alert('报告格式为PDF！', {
                    skin: 'layui-layer-lan' //样式类名
                                 , closeBtn: 0
                });
                var LightningReport = document.getElementById("LightningReport");
                LightningReport.value = "";
                return false;
            }


            var isIE = /msie/i.test(navigator.userAgent) && !window.opera;
            var fileSize = 0;
            if (isIE && !LightningReport1.files) {
                var filePath = LightningReport1.value;
                var fileSystem = new ActiveXObject("Scripting.FileSystemObject");
                var file = fileSystem.GetFile(filePath);
                fileSize = file.Size;
            } else {
                fileSize = LightningReport1.files[0].size;
            }
            var size = fileSize / 1024;
            if (size > 10000) {
                layer.alert('文件大小不能超过10M！', {
                    skin: 'layui-layer-lan' //样式类名
                                                         , closeBtn: 0
                });
                var LightningReport = document.getElementById("LightningReport");
                LightningReport.value = "";
                return false;

            }

            var options = {
                url: "StationInfoSet.aspx?upload=LightningReport",
                success: function (result) {
                    if (result == "1") {
                        layer.alert('上传成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        var LightningReport = document.getElementById("LightningReport");
                        var filLightningReport = document.getElementById("FileLightningReport");
                        var stname = document.getElementById("StationName");
                        var viewLightningReport = document.getElementById("viewLightningReport");
                        var suffix = filLightningReport.files[0].name.split('.')[filLightningReport.files[0].name.split('.').length - 1];
                        LightningReport.value = "/upload/LightningReport/" + stname.value.trim() + "." + suffix;
                        viewLightningReport.disabled = false;

                    }
                    else {
                        layer.alert('上传失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                }, error: function () {
                    layer.alert('上传失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            };
            $("#Form").ajaxSubmit(options);
            // $("#Form").ajaxForm(options);
        });
        $("#viewStationPhoto").click(function () {
            var StationPhoto = document.getElementById("StationPhoto");
            parent.layer.open({
                type: 2,
                title: '基站照片',
                shadeClose: true,
                shade: 0.8,
                area: ['40%', '60%'],
                content: 'ViewPic.aspx?src=' + StationPhoto.value //iframe的url
            });
        });
        $("#viewLightningReport").click(function () {
            var LightningReport = document.getElementById("LightningReport");
      
            var a = window.open("../../../" + LightningReport.value, "_blank", "top=200,left=200,height=600,width=800,status=yes,toolbar=1,menubar=no,location=no,scrollbars=yes");
        });
      


        $("#save").click(function () {
            var staname = document.getElementById("StationName");
            if (staname.value.trim() == "") {
                layer.alert('请输入基站名', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            var staoname = document.getElementById("StationOName");
            if (staoname.value.trim() == "") {
                layer.alert('请输入Rinex站名', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (staoname.value.trim().length != 4) {
                layer.alert('请输入正确的4位Rinex站名', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            var ip = document.getElementById("IP");
            if (ip.value.trim() != "") {
                var re = /^(\d+)\.(\d+)\.(\d+)\.(\d+)$/;//正则表达式   
                if (re.test(ip.value)) {
                    if (RegExp.$1 < 256 && RegExp.$2 < 256 && RegExp.$3 < 256 && RegExp.$4 < 256)
                    { }
                    else {
                        layer.alert('IP地址格式错误', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                }
                else {
                    layer.alert('IP地址格式错误', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            }
            var port = document.getElementById("Port");
            if (port.value == "") {
                layer.alert('请输入端口', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            var lat = document.getElementById("Lat");
            if (lat.value == "") {
                layer.alert('请输入纬度', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (isNaN(lat.value)) {
                layer.alert('纬度格式输入错误', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            var lon = document.getElementById("Lon");
            if (lon.value == "") {
                layer.alert('请输入经度', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (isNaN(lon.value)) {
                layer.alert('经度格式输入错误', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }

            var h = document.getElementById("H");
            if (h.value == "") {
                layer.alert('请输入高度', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (isNaN(h.value)) {
                layer.alert('高度格式输入错误', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
           
            $.ajax({
                type: "POST",
                url: "?action=save",
                data: $("Form").serialize(),
                asnyc: true,
                success: function (result) {
                    if (result == "1") {
                        layer.alert('保存成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
                        
                        parent.$("#refreshsta").click();
                        //parent.layer.close(index);
                    }
                    else {
                        layer.alert('保存失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                    }
                },
                error: function () {
                    layer.alert('保存失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                }
            })
        })
    </script>
</body>
</html>
