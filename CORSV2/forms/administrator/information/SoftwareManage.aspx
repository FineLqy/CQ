<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoftwareManage.aspx.cs" Inherits="CORSV2.forms.administrator.information.SoftwareManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>软件信息管理</title>

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
                                    <button type="button" data-toggle="modal" data-target="#myModal4" data-placement="top" title="添加软件" class="btn btn-outline btn-default">
                                        <i class="fa fa-plus"></i>添加软件 
                                    </button>

                                    <button type="button" id="refreshsta" class="btn btn-outline btn-default" title="刷新软件列表">
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
                                                        <h4 class="modal-title">添加软件</h4>
                                                    </div>
                                                    <div class="modal-body" style="background-color:#ffffff">
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">软件名</label>
                                                        <input type="text" id="SoftWareName" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                      <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">编号</label>
                                                        <input type="text" id="Num" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                      <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">类型</label>
                                                        <input type="text" id="SoftWareType" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">版本</label>
                                                        <input type="text" id="dType" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">IP</label>
                                                        <input type="text" id="IP" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                      <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">配置</label>
                                                        <input type="text" id="Config" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>                                      
                                                        <label style="width: 15%; text-align: left; font-size: 15px; vertical-align: top;">维护信息</label>
                                                        <textarea id="Maintenance" name="Maintenance" style="width: 78%; height: 60px; font-size: 12px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px" runat="server" />
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-white" data-dismiss="modal">关闭</button>
                                                        <button type="button" id="addsoftware" class="btn btn-success">添加</button>
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
        $("#addsoftware").click(function () {

            var SoftWareType = document.getElementById("SoftWareType");
            var dType = document.getElementById("dType");
            var Config = document.getElementById("Config");
            var Maintenance = document.getElementById("Maintenance");
            var SoftWareName = document.getElementById("SoftWareName");
            var IP = document.getElementById("IP");
            var Num = document.getElementById("Num");
            
            var jsonStr = "{\"SoftWareType\":\"" + SoftWareType.value + "\",\"dType\":\"" + dType.value + "\",\"SoftWareName\":\"" + SoftWareName.value + "\",\"IP\":\"" + IP.value + "\",\"Num\":\"" + Num.value + "\",\"Config\":\"" + Config.value + "\",\"Maintenance\":\"" + Maintenance.value + "\"}"
            if (SoftWareName.value == "") {
                layer.alert('请输入软件名称', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (IP.value == "") {
                layer.alert('请输入IP', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (Num.value == "") {
                layer.alert('请输入软件编号', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (SoftWareType.value == "") {
                layer.alert('请输入软件类型', {
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
            if (Config.value == "") {
                layer.alert('请输入配置信息', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (Maintenance.value == "") {
                layer.alert('请输入维护信息', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
           
            if (IP.value.trim() != "") {
                var re = /^(\d+)\.(\d+)\.(\d+)\.(\d+)$/;//正则表达式   
                if (re.test(IP.value)) {
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
            $.ajax({
                url: "",
                type: "post",
                data: {
                    action: "AddSoftWare",
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
                        layer.alert('该软件已存在', {
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
                        field: 'SoftWareName',
                        title: '软件名称'
                    },
                    {
                        field: 'Num',
                        title: '软件编号'
                    },
                    {
                        field: 'SoftWareType',
                        title: '软件类型'
                    }, {
                        field: 'Type',
                        title: '型号',

                    }
                    , {
                        field: 'IP',
                        title: 'IP',

                    }, {
                        field: 'Config',
                        title: '配置',

                    }, {
                        field: 'Maintenance',
                        title: '维护信息'
                    }, {
                        field: 'dTime',
                        title: '时间'
                    }, {
                        field: 'button',
                        title: '查看'
                    }],
            });
        }
        
        function viewDevice(id) {
            layer.open({
                type: 2,
                title: '软件信息设置',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['1150px', '650px'],
                content: 'SoftWare.aspx?id=' + id

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
                parent.layer.msg('请先选择要删除的软件');
                return false;
            }
            layer.alert('您确定要删除这个软件吗', {
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
            $(".search input").attr("placeholder", "搜索软件类型");
        });
    </script>
</body>

</html>
