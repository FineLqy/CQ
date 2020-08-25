<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternetSet.aspx.cs" Inherits="CORSV2.forms.administrator.information.InternetSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>网络信息管理</title>
    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="../../../themes/css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
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
                                            <span class="label label-info">1</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseOne">数据传输网络</a>
                                        </h5>
                                    </div>
                                    <div id="collapseOne" class="panel-collapse collapse in">

                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">网络类型</label>
                                            <input type="text" id="Type" readonly="readonly" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">数据专线的起端点</label>
                                            <input type="text" id="DataLineStartP" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">数据专线的止端点</label>
                                            <input type="text" id="DataLineEndP" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>

                                        <div>
                                            <label style="width: 10%; text-align: center">加密技术</label>
                                            <input type="text" id="EncryptionTechnology" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">带宽</label>
                                            <input type="text" id="BandWidth" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">专线运营商</label>
                                            <input type="text" id="GreenOperator" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">技术支持人员</label>
                                            <input type="text" id="TechnicalSupportStaff" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <input type="text" id="IDS" style="display: none" runat="server" />

                                        </div>
                                        <div class="hr-line-dashed"></div>

                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">2</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseTwo">数据分发网络</a>
                                        </h5>
                                    </div>
                                    <div id="collapseTwo" class="panel-collapse collapse in">
                                        <div class="hr-line-dashed"></div>

                                        <div>
                                            <label style="width: 10%; text-align: center">数据专线的类型</label>
                                            <input type="text" id="FDataLineType" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">加密技术</label>
                                            <input type="text" id="FEncryptionTechnology" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">带宽</label>
                                            <input type="text" id="FBandWidth" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">运营商</label>
                                            <input type="text" id="FGreenOperator" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">技术支持信息</label>
                                            <input type="text" id="FTechnicalSupportStaff" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>

                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">3</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseThree">网络拓扑</a>
                                        </h5>
                                    </div>
                                    <div id="collapseThree" class="panel-collapse collapse in">
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                           
                                            <label style="width: 10%; text-align: center">基本配置</label>
                                            <input type="text" id="EquipConfig" runat="server" readonly="readonly" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                             <a id ="viewEquipConfig" href="" style="width:4%" class="btn btn-white btn-xs">下载</a>
                                            <input type="button" id="browerEquipConfig" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="浏览" onclick="FileEquipConfig.click()" />
                                            <input type="button" id="uploadEquipConfig" disabled="disabled" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="上传" />
                                            <input id="FileEquipConfig" type="file" runat="server" style="display: none; height: 1px; width: 1px" />
                                            <label style="width: 5%"></label>
                                            <label style="width: 10%; text-align: center">拓扑关系</label>
                                            <input type="text" id="Topological" runat="server" readonly="readonly" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <input type="button" id="viewTopological" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="查看" />
                                            <input type="button" id="browerTopological" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="浏览" onclick="FileTopological.click()" />
                                            <input type="button" id="uploadTopological" disabled="disabled" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="上传" />
                                            <input id="FileTopological" type="file" runat="server" style="display: none; height: 1px; width: 1px" accept="image/*" onchange="Topological.value=this.value;" />
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">路由器配置</label>
                                            <input type="text" id="RouterConfig" runat="server" readonly="readonly" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <a id="viewRouterConfig" href="" runat="server" style="width: 4%;" class="btn btn-xs btn-white">下载</a>                                           
                                            <input type="button" id="browerRouterConfig" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="浏览" onclick="FileRouterConfig.click()" />
                                            <input type="button" id="uploadRouterConfig" disabled="disabled" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="上传" />
                                            <input id="FileRouterConfig" type="file" runat="server" style="display: none; height: 1px; width: 1px" />
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">4</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseFour">数据中心网络</a>
                                        </h5>
                                    </div>
                                    <div id="collapseFour" class="panel-collapse collapse in">
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">服务器IP</label>
                                            <input type="text" id="ServerIP" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">服务器端口</label>
                                            <input type="text" id="ServerPort" runat="server" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">服务器机器名</label>
                                            <input type="text" id="ServerMachineName" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">服务器标识</label>
                                            <input type="text" id="ServerLogo" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">服务器用途</label>
                                            <input type="text" id="ServerUse" runat="server"  style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">服务器备注</label>
                                            <input type="text" id="ServerRemark" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">存储IP</label>
                                            <input type="text" id="StorageIP" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">存储端口</label>
                                            <input type="text" id="StoragePort" runat="server" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">存储机器名</label>
                                            <input type="text" id="StorageMachineName" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                     </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">存储标识</label>
                                            <input type="text" id="StorageLogo" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">存储用途</label>
                                            <input type="text" id="StorageUse" runat="server"  style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">存储备注</label>
                                            <input type="text" id="StorageRemark" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                             <input type="text" id="EquipmentID" runat="server" style="display:none">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">5</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseFive">数据中心网络设备</a>
                                        </h5>
                                    </div>
                                    <div id="collapseFive" class="panel-collapse collapse in">
                                     
                                        <div class="hr-line-dashed"></div>
                                        <div style="padding-left:1%;padding-right:1%">
                                            <div class="newstable" style="margin-top: 1%">

                                                <div class="bars pull-left">
                                                    <div class="btn-group hidden-xs" id="toolbar" role="group">
                                                        <button type="button" id="addequip" title="添加设备" class="btn btn-outline btn-default">
                                                            <i class="fa fa-plus"></i>添加设备 
                                                        </button>

                                                        <button type="button" id="refreshequip" class="btn btn-outline btn-default" title="刷新设备列表">
                                                            <i class="fa fa-refresh"></i>刷新
                                                        </button>
                                                        <button type="button" id="deleteequip" class="btn btn-outline btn-default" data-toggle="tooltip" data-placement="top" title="删除">
                                                            <i class="fa fa-trash-o"></i>删除
                                                        </button>
                                                        
                                                        

                                                    </div>
                                                </div>

                                                <table
                                                    id="table"
                                                    data-toolbar="#toolbar"
                                                    data-search="true"
                                                    data-show-refresh="false"
                                                    data-show-toggle="true"
                                                    data-show-columns="true"
                                                    data-show-export="false"
                                                    data-detail-view="false"
                                                    data-striped="true"
                                                    data-minimum-count-columns="1"
                                                    data-show-pagination-switch="true"
                                                    data-pagination="true"
                                                    data-page-size="10"
                                                    data-id-field="ID"
                                                    data-unique-id="ID"
                                                    data-page-list="[10, 25, 50, 100]"
                                                    data-show-footer="false"
                                                    data-side-pagination="server"
                                                    data-url="?action=GetData"
                                                    data-smart-display="false">
                                                </table>
                                            </div>
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
   <script src="../../../js/jquery.min.js"></script>
    <script src="../../../js/bootstrap.min.js"></script>
   <script src="../../../js/jquery.form.js"></script>
    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script>
        var table = $("#table");
        function initialTable() {
            table.bootstrapTable({
                columns: [
                    {
                        field: 'state',
                        checkbox: true,
                    },
                    {
                        field: 'MachineName',
                        title: '设备名'
                    }, {
                        field: 'IP',
                        title: 'IP',

                    }, {
                        field: 'Port',
                        title: '端口',

                    }, {
                        field: 'EUse',
                        title: '用途'
                    }, {
                        field: 'Logo',
                        title: '标识'
                    }, {
                        field: 'Remark',
                        title: '备注'

                    }, {
                        field: 'button',
                        title: '查看'

                    }],
            });
        }
        $("#FileEquipConfig").change(function () {
            var EquipConfig = document.getElementById("EquipConfig");
            var fileEquipConfig = document.getElementById("FileEquipConfig");
            if (fileEquipConfig.files.length > 0) {
                EquipConfig.value = fileEquipConfig.files[0].name;
            }
            else {
                EquipConfig.value = "";
            }
            var upload = document.getElementById("uploadEquipConfig");
            if (EquipConfig.value != "") {

                upload.disabled = false;
            }
            else { upload.disabled = true; }
        });
        $("#FileRouterConfig").change(function () {
            var RouterConfig = document.getElementById("RouterConfig");
            var fileRouterConfig = document.getElementById("FileRouterConfig");
            if (fileRouterConfig.files.length > 0) {
                RouterConfig.value = fileRouterConfig.files[0].name;
            }
            else {
                RouterConfig.value = "";
            }
            var upload = document.getElementById("uploadRouterConfig");
            if (RouterConfig.value != "") {

                upload.disabled = false;
            }
            else { upload.disabled = true; }
        });
        $("#FileTopological").change(function () {
            var Topological = document.getElementById("Topological");
            var fileTopological = document.getElementById("FileTopological");
            if (fileTopological.files.length > 0) {
                Topological.value = fileTopological.files[0].name;
            }
            else {
                Topological.value = "";
            }
            var upload = document.getElementById("uploadTopological");
            if (Topological.value != "") {

                upload.disabled = false;
            }
            else { upload.disabled = true; }
        });
        function checkdownload() {
            var EquipConfig = document.getElementById("EquipConfig");
            var RouterConfig = document.getElementById("RouterConfig");
            var Topological = document.getElementById("Topological");
            var viewTopological = document.getElementById("viewTopological");
            if (Topological.value != "" && Topological.value != null) {
                viewTopological.disabled = false;
            }
            else {
                viewTopological.disabled = true;
            }
            if (EquipConfig.value != "" && EquipConfig.value != null) {
                $("#viewEquipConfig").attr("href", "../../../"+EquipConfig.value.trim());
                $("#viewEquipConfig").attr("download", "基本配置");
            }
            else {
                $("#viewEquipConfig").enable = false;
            }
            if (RouterConfig.value != "" && RouterConfig.value!=null) {
                $("#viewRouterConfig").attr("href", "../../.."+RouterConfig.value.trim());
                $("#viewRouterConfig").attr("download", "路由器配置");
            }
            else {
                $("#viewRouterConfig").enable = false;              
            }
        }
        $("#viewTopological").click(function () {
            var Topological = document.getElementById("Topological");
            parent.layer.open({
                type: 2,
                title: '拓扑关系',
                shadeClose: true,
                shade: 0.8,
                area: ['60%', '80%'],
                content: 'ViewPic.aspx?src=' + Topological.value //iframe的url
            });
        });
        $("#addequip").click(function () {
            var IDS = document.getElementById("IDS");
            layer.open({
                type: 2,
                title: '添加网络设备',
                shadeClose: true,
                shade: 0.8,
                //maxmin:true,
                area: ['40%', '90%'],
                content: 'InternetEquipAdd.aspx?ID='+IDS.value  //iframe的url
            });
        });
        function view(id) {
            layer.open({
                type: 2,
                title: '网络设备管理',
                shadeClose: true,
                shade: 0.8,
                //maxmin:true,
                area: ['40%', '90%'],
                content: 'Internetequipset.aspx?ID='+id //iframe的url
            });
        }
        $("#uploadEquipConfig").click(function () {
            
            var FileEquipConfig1 = document.getElementById("FileEquipConfig");
            var isIE = /msie/i.test(navigator.userAgent) && !window.opera;


            var fileSize = 0;
            if (isIE && !FileEquipConfig1.files) {
                var filePath = FileEquipConfig1.value;
                var fileSystem = new ActiveXObject("Scripting.FileSystemObject");
                var file = fileSystem.GetFile(filePath);
                fileSize = file.Size;
            } else {
                fileSize = FileEquipConfig1.files[0].size;
            }
            var size = fileSize / 1024;
            if (size > 2000) {
                layer.alert('文件大小不能超过2M！', {
                    skin: 'layui-layer-lan' //样式类名
                                                         , closeBtn: 0
                });
                var Equipvalue = document.getElementById("EquipConfig");
                Equipvalue.value = "";
                return false;
                
            }


            var options = {
                url: "?upload=EquipConfig",
                success: function (result) {
                    if (result == "1") {
                        layer.alert('上传成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        var EquipConfig = document.getElementById("EquipConfig");
                        var FileEquipConfig = document.getElementById("FileEquipConfig");
                        var Type = document.getElementById("Type");
                        var viewEquipConfig = document.getElementById("viewEquipConfig");
                        var suffix = FileEquipConfig.files[0].name.split('.')[FileEquipConfig.files[0].name.split('.').length - 1];
                        EquipConfig.value = "/upload/EquipConfig/" + Type.value.trim() + "." + suffix;
                        viewEquipConfig.disabled = false;

                        $("#viewEquipConfig").attr("href", "../../../" + EquipConfig.value.trim());
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
           
        });



        $("#uploadRouterConfig").click(function () {
            var FileRouterConfig1 = document.getElementById("FileRouterConfig");
            var isIE = /msie/i.test(navigator.userAgent) && !window.opera;


            var fileSize = 0;
            if (isIE && !FileRouterConfig1.files) {
                var filePath = FileRouterConfig1.value;
                var fileSystem = new ActiveXObject("Scripting.FileSystemObject");
                var file = fileSystem.GetFile(filePath);
                fileSize = file.Size;
            } else {
                fileSize = FileRouterConfig1.files[0].size;
            }
            var size = fileSize / 1024;
            if (size > 2000) {
                layer.alert('文件大小不能超过2M！', {
                    skin: 'layui-layer-lan' //样式类名
                                                         , closeBtn: 0
                });
                var Routervalue = document.getElementById("RouterConfig");
                Routervalue.value = "";
                return false;

            }


            var options = {
                url: "?upload=RouterConfig",
                success: function (result) {
                    if (result == "1") {
                        layer.alert('上传成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        var RouterConfig = document.getElementById("RouterConfig");
                        var FileRouterConfig = document.getElementById("FileRouterConfig");
                        var Type = document.getElementById("Type");
                        var viewRouterConfig = document.getElementById("viewRouterConfig");
                        var suffix = FileRouterConfig.files[0].name.split('.')[FileRouterConfig.files[0].name.split('.').length - 1];
                        RouterConfig.value = "/upload/RouterConfig/" + Type.value.trim() + "." + suffix;
                        viewRouterConfig.disabled = false;

                        $("#viewRouterConfig").attr("href", "../../../" + RouterConfig.value.trim());
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

        });

        $("#uploadTopological").click(function () {

            var Topological1 = document.getElementById("FileTopological");
            var Topological2 = Topological1.value;
            var extStart = Topological2.lastIndexOf(".");
            var ext = Topological2.substring(extStart, Topological2.length).toUpperCase();
            if (ext != ".BMP" && ext != ".PNG" && ext != ".GIF" && ext != ".JPG" && ext != ".JPEG") {

                layer.alert('拓扑关系为png,gif,jpeg,jpg格式图片！', {
                    skin: 'layui-layer-lan' //样式类名
                                 , closeBtn: 0
                });
                var Topological = document.getElementById("Topological");
                Topological.value = "";
                return false;
            }


            var isIE = /msie/i.test(navigator.userAgent) && !window.opera;
            var fileSize = 0;
            if (isIE && !Topological1.files) {
                var filePath = Topological1.value;
                var fileSystem = new ActiveXObject("Scripting.FileSystemObject");
                var file = fileSystem.GetFile(filePath);
                fileSize = file.Size;
            } else {
                fileSize = Topological1.files[0].size;
            }
            var size = fileSize / 1024;
            if (size > 2000) {
                layer.alert('图片大小不能超过2M！', {
                    skin: 'layui-layer-lan' //样式类名
                                                         , closeBtn: 0
                });
                var Topological = document.getElementById("Topological");
                Topological.value = "";
                return false;

            }

            var options = {
                url: "?upload=Topological",
                success: function (result) {
                    if (result == "1") {
                        layer.alert('上传成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        var Topological = document.getElementById("Topological");
                        var fileTopological = document.getElementById("FileTopological");
                        var Type = document.getElementById("Type");
                        var viewTopological = document.getElementById("viewTopological");
                        var suffix = fileTopological.files[0].name.split('.')[fileTopological.files[0].name.split('.').length - 1];
                        Topological.value = "/upload/Topological/" + Type.value.trim() + "." + suffix;
                        viewTopological.disabled = false;

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
        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID
            });
        }

        $("#refreshequip").click(function () {
            table.bootstrapTable('refresh');

        });

        $("#deleteequip").click(function () {
            var ids = getIdSelections();
            if (ids.length == 0) {
                parent.layer.msg('请先选择要删除的设备');
                return false;
            }
            layer.alert('您确定要删除这个设备吗', {
                skin: 'layui-layer-lan' //样式类名
                , btn: ['确定', '取消'], title: '删除'
            }, function () {

                $.ajax({
                    url: "",
                    type: "post",
                    data: {
                        action: "DeleteEquip",
                        id: ids,
                    },
                    success: function () {
                        layer.alert('删除成功', {
                            skin: 'layui-layer-lan' //样式类名
                             , closeBtn: 0
                        });
                        table.bootstrapTable('remove', {
                            field: 'ID',
                            values: ids
                        });
                        $("#deleteequip").blur();


                        table.bootstrapTable('refresh');
                    }, error: function () {
                        layer.alert('删除失败', {
                            skin: 'layui-layer-lan' //样式类名
                             , closeBtn: 0
                        });
                        return false;
                    }
                });

            }, function () {

                parent.layer.msg('删除已取消');
            });
        });


        $("#save").click(function () {
            var nType = document.getElementById("Type");
            var DataLineStartP = document.getElementById("DataLineStartP");
            var DataLineEndP = document.getElementById("DataLineEndP");
            var EncryptionTechnology = document.getElementById("EncryptionTechnology");
            var BandWidth = document.getElementById("BandWidth");
            var GreenOperator = document.getElementById("GreenOperator");
            var TechnicalSupportStaff = document.getElementById("TechnicalSupportStaff");
            if (nType.value == "") {
                layer.alert('请输入网络类型', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (DataLineStartP.value == "") {
                layer.alert('请输入数据专线起端点', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (DataLineEndP.value == "") {
                layer.alert('请输入数据专线止端点', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (EncryptionTechnology.value == "") {
                layer.alert('请输入加密技术', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }

            if (BandWidth.value == "") {
                layer.alert('请输入带宽', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (GreenOperator.value == "") {
                layer.alert('请输入专线运营商', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (TechnicalSupportStaff.value == "") {
                layer.alert('请输入技术支持人员', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
           

            var ip = document.getElementById("ServerIP");
            if (ip.value.trim() != "") {
                var re = /^(\d+)\.(\d+)\.(\d+)\.(\d+)$/;//正则表达式   
                if (re.test(ip.value)) {
                    if (RegExp.$1 < 256 && RegExp.$2 < 256 && RegExp.$3 < 256 && RegExp.$4 < 256)
                    { }
                    else {
                        layer.alert('服务器IP地址格式错误', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                }
                else {
                    layer.alert('服务器IP地址格式错误', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
                var port = document.getElementById("ServerPort");
                if (port.value == "") {
                    layer.alert('请输入服务器端口', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            }
            
            var Storageip = document.getElementById("StorageIP");
            if (Storageip.value.trim() != "") {
                var re = /^(\d+)\.(\d+)\.(\d+)\.(\d+)$/;//正则表达式   
                if (re.test(ip.value)) {
                    if (RegExp.$1 < 256 && RegExp.$2 < 256 && RegExp.$3 < 256 && RegExp.$4 < 256)
                    { }
                    else {
                        layer.alert('存储IP地址格式错误', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                }
                else {
                    layer.alert('存储IP地址格式错误', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
                var Storageport = document.getElementById("StoragePort");
                if (Storageport.value == "") {
                    layer.alert('请输入存储端口', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            }


            $.ajax({
                type: "POST",
                url: "?action=save",
                data: $("#Form").serialize(),
                asnyc: true,
                success: function (result) {
                    if (result == "1") {
                        layer.alert('保存成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        parent.$("#refreshsta").click();
                    }
                    else if (result == "2") {
                        layer.alert('网络类型已存在', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                    else {
                        layer.alert('保存失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                },
                error: function () {
                    layer.alert('保存失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            })
        })
        $(document).ready(function () {
            checkdownload();
            initialTable();
            $(".search input").attr("placeholder", "搜索设备类型");
        });



    </script>
</body>
</html>
