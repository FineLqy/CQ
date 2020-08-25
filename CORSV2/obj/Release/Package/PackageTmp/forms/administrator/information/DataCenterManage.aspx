<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataCenterManage.aspx.cs" Inherits="CORSV2.forms.administrator.information.DataCenterManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>数据中心设备管理</title>

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
                                    <button type="button" data-toggle="modal" data-target="#myModal4" data-placement="top" title="添加设备" class="btn btn-outline btn-default">
                                        <i class="fa fa-plus"></i>添加设备 
                                    </button>

                                    <button type="button" id="refreshsta" class="btn btn-outline btn-default" title="刷新设备列表">
                                        <i class="fa fa-refresh"></i>刷新
                                    </button>
                                    <button type="button" id="deletesta" class="btn btn-outline btn-default" data-toggle="tooltip" data-placement="top" title="删除">
                                        <i class="fa fa-trash-o"></i>删除
                                    </button>
                                    <form method="post" id="Form">
                                        <div class="modal inmodal" id="myModal4" tabindex="-1" role="dialog" aria-hidden="true">
                                            <div class="modal-dialog">
                                                <div class="modal-content animated fadeIn">
                                                    <div class="modal-header">
                                                        <h4 class="modal-title">添加设备</h4>
                                                    </div>
                                                    <div class="modal-body" style="background-color:#ffffff">

                                                        <label style="width: 15%; text-align: left; font-size: 15px;">设备类型</label>
                                                        <input type="text" id="DeviceType" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">型号</label>
                                                        <input type="text" id="dType" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">序列号</label>
                                                        <input type="text" id="SerialNumber" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">IP</label>
                                                        <input type="text" id="IP" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">端口</label>
                                                        <input type="text" id="Port" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px; vertical-align: top;">业务用途</label>
                                                        <textarea id="Business" name="Business" style="width: 78%; height: 60px; font-size: 12px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px" runat="server" />
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-white" data-dismiss="modal">关闭</button>
                                                        <button type="button" id="addequip" class="btn btn-success">添加</button>
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
       

        $("#addequip").click(function () {

            var DeviceType = document.getElementById("DeviceType");
            var dType = document.getElementById("dType");
            var SerialNumber = document.getElementById("SerialNumber");
            var ip = document.getElementById("IP");
            var Business=document.getElementById("Business");
            var port = document.getElementById("Port");
            var condata={DeviceType:DeviceType.value}
            var jsonStr="{\"DeviceType\":\""+DeviceType.value+"\",\"dType\":\""+dType.value+"\",\"SerialNumber\":\""+SerialNumber.value+"\",\"IP\":\""+ip.value+"\",\"Port\":\""+port.value+"\",\"Business\":\""+Business.value+"\"}"
            if (DeviceType.value == "") {
                layer.alert('请输入设备类型', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (dType.value == "") {
                layer.alert('请输入型号', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (SerialNumber.value == "") {
                layer.alert('请输入序列号', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
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

          
            if (port.value == "") {
                layer.alert('请输入端口', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }


            $.ajax({
                url: "",
                type: "post",
                data: {
                    action: "AddEquip",
                    equip:jsonStr
                }, success: function (result) {
                    if (result == "1") {
                        layer.alert('添加成功', {
                            skin: 'layui-layer-lan' //样式类名
                            , closeBtn: 0
                        });
                        table.bootstrapTable('refresh');
                    }
                    else if (result == "0") {
                        layer.alert('该设备已存在', {
                            skin: 'layui-layer-lan' //样式类名
                            , closeBtn: 0
                        });
                        return false;
                    }
                    else {
                        layer.alert('添加失败', {
                            skin: 'layui-layer-lan' //样式类名
                           , closeBtn: 0
                        });
                        return false;
                    }
                }, error: function () {
                    layer.alert('添加失败', {
                        skin: 'layui-layer-lan' //样式类名
                           , closeBtn: 0
                    });
                    return false;
                }
            })
        });
      
        function initialTable() {
            table.bootstrapTable({
                columns: [
                    {
                        field: 'state',
                        checkbox: true,
                    },
                    {
                        field: 'DeviceType',
                        title: '设备类型'
                    }, {
                        field: 'Type',
                        title: '型号',

                    }, {
                        field: 'SerialNumber',
                        title: '序列号',

                    }, {
                        field: 'IP',
                        title: 'IP地址'
                    }, {
                        field: 'Port',
                        title: '端口'
                    }, {
                        field: 'Business',
                        title: '业务用途'

                    }, {
                        field: 'button',
                        title: '设备信息'

                    }],
            });
        }
        
        function viewDevice(SerialNumber) {
            layer.open({
                type: 2,
                title: '设备信息设置',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['1150px', '650px'],
                content: 'DataCenterEquip.aspx?Serial=' + SerialNumber

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
                        action: "DeleteEquips",
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
            $(".search input").attr("placeholder", "搜索设备类型");
        });
    </script>
</body>

</html>
