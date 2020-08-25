<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EquipSetInfo.aspx.cs" Inherits="CORSV2.forms.administrator.information.EquipSetInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>基站设备信息管理</title>
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
                                            <span class="label label-info">1</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseOne">基本信息</a>
                                        </h5>
                                    </div>
                                    <div id="collapseOne" class="panel-collapse collapse in">
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

                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">2</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseTwo">配置信息</a>
                                        </h5>
                                    </div>
                                    <div id="collapseTwo" class="panel-collapse collapse in">
                                        <div class="hr-line-dashed"></div>

                                        <div>
                                            <input type="text" id="IDS" runat="server" style="display:none"/>
                                            <label style="width: 10%; text-align: center">站点名</label>
                                            <input type="text" id="StationName" runat="server" readonly="readonly" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">

                                            <label style="width: 10%; text-align: center">设备登录名</label>
                                            <input type="text" id="LoginName" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">登录密码</label>
                                            <input type="text" id="Password" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">天线高</label>
                                            <input type="text" id="AntennaH" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">天线高量取方式</label>
                                            <input type="text" id="AntennaHM" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">天线高量取位置</label>
                                            <input type="text" id="AntennaHML" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">卫星系统</label>
                                            <input type="text" id="SatelliteSystem" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">IP</label>
                                            <input type="text" id="IP" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">端口</label>
                                            <input type="text" id="Port" runat="server" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">子网掩码</label>
                                            <input type="text" id="SubnetMask" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">网关</label>
                                            <input type="text" id="Gateway" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">波特率</label>
                                            <input type="text" id="BaudRate" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center; vertical-align: top">数据流转发配置</label>
                                            <textarea id="DataConfiguration" name="DataConfiguration" style="width: 81%; height: 80px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px" runat="server">
                               
                                            </textarea>

                                        </div>
                                        <div class="hr-line-dashed"></div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">3</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseThree">维护信息</a>
                                        </h5>
                                    </div>
                                    <div id="collapseThree" class="panel-collapse collapse in">
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">设备维护人员</label>
                                            <input type="text" id="MaintenancePerson" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">设备维护时间</label>
                                            <input class=" layer-date" id="MaintenanceTime" runat="server" style="width: 20%; height: 32px; vertical-align: top; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px; max-width: none" placeholder="YYYY-MM-DD hh:mm:ss" onclick="laydate({ istime: true, format: 'YYYY-MM-DD hh:mm:ss' })">
                                            <label class="laydate-icon" style="width: 2%; height: 32px; vertical-align: top"></label>

                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center; vertical-align: top">设备维护内容</label>
                                            <textarea id="MaintenanceContent" name="MaintenanceContent" style="width: 81%; height: 120px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px" runat="server">
                               
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
    <!-- 自定义js -->
    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/layer/laydate/laydate.js"></script>
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
                        field: 'Models',
                        title: '型号',

                    }, {
                        field: 'SerialNumber',
                        title: '序列号',

                    }, {
                        field: 'dInstallationDate',
                        title: '安装时间'
                    }],
            });
        }
        $("#save").click(function () {

            var ip = document.getElementById("IP");
            if (ip.value == "") {
                layer.alert('请输入IP地址', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
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
        });
        $("#addequip").click(function () {
            var IDS = document.getElementById("IDS");
            layer.open({
                type: 2,
                title: '添加设备',
                shadeClose: true,
                shade: 0.8,
                //maxmin:true,
                area: ['40%', '90%'],
                content: 'StationEquipAdd.aspx?ID=' + IDS.value  //iframe的url
            });
        });

        $("#refreshequip").click(function () {
            table.bootstrapTable('refresh');

        });
        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID
            });
        }

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
        $(document).ready(function () {
            initialTable();
            $(".search input").attr("placeholder", "搜索设备类型");
        });
    </script>
</body>
</html>
