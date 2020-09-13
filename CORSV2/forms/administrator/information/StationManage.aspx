<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StationManage.aspx.cs" Inherits="CORSV2.forms.administrator.information.StationManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>基站信息管理</title>

    <link rel="shortcut icon" href="../../favicon.ico" />
    
    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content  animated fadeInRight" style="padding-top:0px;">
        <div class="row" style="padding-left:0px;padding-right:0px;">
            <div class="col-sm-8" style="padding-left:0px;padding-right:0px;width: 100%;" >
                <div class="ibox">
                    <div class="ibox-content">
                        <div class="newstable" style="margin-top: 1%">

                            <div class="bars pull-left">
                                <div class="btn-group hidden-xs" id="toolbar" role="group">
                                    <button type="button" data-toggle="modal" data-target="#myModal4" data-placement="top" title="添加基站" class="btn btn-outline btn-default">
                                        <i class="fa fa-plus"></i>添加基站 
                                    </button>

                                    <button type="button" id="refreshsta" class="btn btn-outline btn-default" title="刷新基站列表">
                                        <i class="fa fa-refresh"></i>刷新
                                    </button>
                                    <button type="button" class="btn btn-outline btn-default" title="查看地图" onclick="showmap()">
                                        <i class="fa fa-eye"></i>查看地图
                                    </button>
                                    <button type="button" id="deletesta" class="btn btn-outline btn-default" data-toggle="tooltip" data-placement="top" title="删除">
                                        <i class="fa fa-trash-o"></i>删除
                                    </button>
                                    <button type="button" class="btn btn-outline btn-default" title="故障统计" onclick="showErrorData()">
                                        <i class="fa fa-bar-chart"></i>故障统计
                                    </button>
                                    <form method="post" id="Form">
                                        <div class="modal inmodal" id="myModal4" tabindex="-1" role="dialog" aria-hidden="true">
                                            <div class="modal-dialog">
                                                <div class="modal-content animated fadeIn">
                                                    <div class="modal-header">
                                                        <h4 class="modal-title">添加基站</h4>
                                                    </div>
                                                    <div class="modal-body" style="background-color:#ffffff">

                                                        <label style="width: 15%; text-align: left; font-size: 15px;">基站名</label>
                                                        <input type="text" id="staName" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">Rinex站名</label>
                                                        <input type="text" id="staoName" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">传输类型</label>
                                                        <select name="account" id="TransferType" style="width: 20px; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 78%">
                                                            <option>TCP/IP</option>
                                                            <option>Ntrip</option>
                                                        </select>
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">IP</label>
                                                        <input type="text" id="IP" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">端口</label>
                                                        <input type="text" id="Port" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">纬度(dms)</label>
                                                        <input type="text" id="Lat" style="width: 15%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">经度(dms)</label>
                                                        <input type="text" id="Lon" style="width: 15%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">高度(米)</label>
                                                        <input type="text" id="H" style="width: 15%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px; vertical-align: top;">备注</label>
                                                        <textarea id="Remark" name="Remark" style="width: 78%; height: 60px; font-size: 12px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px" runat="server" />
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-white" data-dismiss="modal">关闭</button>
                                                        <button type="button" onclick="addstation()" class="btn btn-success">添加</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </form>
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
        </div>
    </div>

    <script src="../../../js/jquery.min.js"></script>
    <script src="../../../js/bootstrap.min.js"></script>

    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script>
        
        var table = $("#table");
        function showmap() {
            parent.layer.open({
                type: 2,
                title: '基站分布',
                shadeClose: true,
                shade: false,
                maxmin: false, //开启最大化最小化按钮
                area: ['1000px', '700px'],
                content: ['/forms/publicforms/map/QueryTDT.aspx', 'no']
            });
        }
  


              function showErrorData() {
           layer.open({
                type: 2,
                title: '故障统计',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['700px', '600px'],
                content: ['FaultStatistics.aspx','no'] 

            });
        }
        //添加基站
        function addstation() {

            var staname = document.getElementById("staName");
            if (staname.value.trim() == "") {
                layer.alert('请输入基站名', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            var staoname = document.getElementById("staoName");
            if (staoname.value.trim() == "") {
                layer.alert('请输入Rinex站名', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }



            var ip = document.getElementById("IP");
            if (ip.value == "") {
                layer.alert('请输入IP地址', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (ip.value != null) {
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
            var trasnstype = document.getElementById("TransferType");
            var remark = document.getElementById("Remark");
            if (staoname.value.trim().length != 4) {
                layer.alert('请输入正确的4位Rinex站名', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            else {

                $.ajax({
                    url: "StationManage.aspx?action=add",
                    data: {
                        StationName: staname.value.trim(),
                        StationOName: staoname.value.trim(),
                        TransType: trasnstype.value.trim(),
                        Ip: ip.value.trim(),
                        Port: port.value.trim(),
                        Lat: lat.value.trim(),
                        Lon: lon.value.trim(),
                        H: h.value.trim(),
                        Remark: remark.value
                    },
                    type: "POST",
                    success: function (result) {
                        if (result == "0") {

                            layer.alert('基站已存在', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            return false;
                        }
                        else {
                            if (result == "1") {
                                layer.alert('添加成功', {
                                    skin: 'layui-layer-lan', //样式类名,
                                });
                                table.bootstrapTable('refresh');
                            }
                            else {
                                layer.alert('添加失败', {
                                    skin: 'layui-layer-lan', //样式类名,
                                });
                                return false;
                            }
                        }
                    }
                });

               
            }

        }

        function initialTable() {
            table.bootstrapTable({
                columns: [
                    {
                        field: 'state',
                        checkbox: true,
                    },
                    {
                        field: 'StationName',
                        title: '基站名'
                    }, {
                        field: 'StationOName',
                        title: 'Rinex站名',

                    }, {
                        field: 'TransferType',
                        title: '传输类型',

                    }, {
                        field: 'IP',
                        title: 'IP地址'
                    }, {
                        field: 'Port',
                        title: '端口'
                    }, {
                        field: 'Lat',
                        title: '纬度'
                    }, {
                        field: 'Lon',
                        title: '经度'

                    }, {
                        field: 'H',
                        title: '高度'
                    }, {
                        field: 'deIsOK',
                        title: '是否正常',


                    }
                    , {
                        field: 'OperatingState',
                        title: '运行状态'

                    }, {
                        field: 'button',
                        title: '基站信息'

                    }, {
                        field: 'buttonequip',
                        title: '设备信息'

                    }, {
                        field: 'SiteMonitoring',
                        title: '站点监视'

                    }],
            });
        }
        function viewSite(stationoname) {
            layer.open({
                type: 2,
                title: '基站监视',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['1150px', '650px'],
                content: 'SiteMonitoring.aspx?stationoname=' + stationoname

            });
        }
        function viewDevice(stationoname) {
           layer.open({
                type: 2,
                title: '基站设备信息设置',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['1150px', '650px'],
                content: 'EquipSetInfo.aspx?stationoname=' + stationoname

            });
        }
        function view(id) {
            //parent.layer.open({
            //    type: 2,
            //    title: '基站基本信息设置',
            //    shadeClose: true,
            //    shade: false,
            //    maxmin: true, //开启最大化最小化按钮
            //    area: ['1150px', '650px'],
            //    content: 'xtgl/StationInfoSet.aspx?id=' + id

            //});
            layer.open({
                type: 2,
                title: '基站基本信息设置',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['1150px', '600px'],
                content: 'StationInfoSet.aspx?id=' + id

            });
        }
        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID
            });
        }


        $("#refreshsta").click(function () {
            table.bootstrapTable('refresh');

        });

        $("#deletesta").click(function () {
            var ids = getIdSelections();
            if (ids.length == 0) {
                parent.layer.msg('请先选择要删除的基站');
                return false;
            }
            layer.alert('您确定要删除这个基站吗', {
                skin: 'layui-layer-lan' //样式类名
                , btn: ['确定', '取消'], title: '删除'
            }, function () {


               
                $.ajax({
                    url: "",
                    type: "post",
                    data: {
                        action: "DeleteStas",
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
                        $("#deletesta").blur();


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
            $(".search input").attr("placeholder", "搜索基站名或Rinex站名");
        });
    </script>



</body>

</html>
