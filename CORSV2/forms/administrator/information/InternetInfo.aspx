<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternetInfo.aspx.cs" Inherits="CORSV2.forms.administrator.information.InternetInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>网络信息管理</title>

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
                                    <button type="button" data-toggle="modal" data-target="#myModal4" data-placement="top" title="添加网络" class="btn btn-outline btn-default">
                                        <i class="fa fa-plus"></i>添加网络 
                                    </button>
                                    <button type="button" id="refreshnet" class="btn btn-outline btn-default" title="刷新网络列表">
                                        <i class="fa fa-refresh"></i>刷新
                                    </button>
                                    <button type="button" id="deletenet" class="btn btn-outline btn-default" data-toggle="tooltip" data-placement="top" title="删除">
                                        <i class="fa fa-trash-o"></i>删除
                                    </button>
                                    <form method="post" id="Form">
                                        <div class="modal inmodal" id="myModal4" tabindex="-1" role="dialog" aria-hidden="true">
                                            <div class="modal-dialog">
                                                <div class="modal-content animated fadeIn">
                                                    <div class="modal-header">
                                                        <h4 class="modal-title">添加网络</h4>
                                                    </div>
                                                    <div class="modal-body" style="background-color:#ffffff">
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">网络类型</label>
                                                        <input type="text" id="nType" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">数据专线起端点</label>
                                                        <input type="text" id="DataLineStartP" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">数据专线止端点</label>
                                                        <input type="text" id="DataLineEndP" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">加密技术</label>
                                                        <input type="text" id="EncryptionTechnology" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">带宽</label>
                                                        <input type="text" id="BandWidth" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">专线运营商</label>
                                                        <input type="text" id="GreenOperator" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">技术支持人员</label>
                                                        <input type="text" id="TechnicalSupportStaff" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                           </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-white" data-dismiss="modal" id="close">关闭</button>
                                                        <button type="button" id="addInternet" class="btn btn-success">添加</button>
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
        $("#close").click(function () {
            var nType = document.getElementById("nType");
            var DataLineStartP = document.getElementById("DataLineStartP");
            var DataLineEndP = document.getElementById("DataLineEndP");
            var EncryptionTechnology = document.getElementById("EncryptionTechnology");
            var BandWidth = document.getElementById("BandWidth");
            var GreenOperator = document.getElementById("GreenOperator");
            var TechnicalSupportStaff = document.getElementById("TechnicalSupportStaff");
            nType.value = "";
            DataLineStartP.value = "";
            DataLineEndP.value = "";
            EncryptionTechnology.value = "";
            BandWidth.value = "";
            GreenOperator.value = "";
            TechnicalSupportStaff.value = "";
        });

        $("#addInternet").click(function () {

            var nType = document.getElementById("nType");
            var DataLineStartP = document.getElementById("DataLineStartP");
            var DataLineEndP = document.getElementById("DataLineEndP");
            var EncryptionTechnology = document.getElementById("EncryptionTechnology");
            var BandWidth = document.getElementById("BandWidth");
            var GreenOperator = document.getElementById("GreenOperator");
            var TechnicalSupportStaff = document.getElementById("TechnicalSupportStaff");

            var jsonStr = "{\"nType\":\"" + nType.value + "\",\"DataLineStartP\":\"" + DataLineStartP.value + "\",\"DataLineEndP\":\"" + DataLineEndP.value + "\",\"EncryptionTechnology\":\"" + EncryptionTechnology.value + "\",\"BandWidth\":\"" + BandWidth.value + "\",\"GreenOperator\":\"" + GreenOperator.value + "\",\"TechnicalSupportStaff\":\"" + TechnicalSupportStaff.value + "\"}"
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

            $.ajax({
                url: "",
                type: "post",
                data: {
                    action: "AddInternet",
                    internet:jsonStr
                }, success: function (result) {
                    if (result == "1") {
                        layer.alert('添加成功', {
                            skin: 'layui-layer-lan' //样式类名
                            , closeBtn: 0
                        });
                        table.bootstrapTable('refresh');
                        nType.value = "";
                        DataLineStartP.value = "";
                        DataLineEndP.value = "";
                        EncryptionTechnology.value = "";
                        BandWidth.value = "";
                        GreenOperator.value = "";
                        TechnicalSupportStaff.value = "";
                    }
                    else if (result == "0") {
                        layer.alert('该网络已存在', {
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
                        field: 'Type',
                        title: '网络类型'
                    }, {
                        field: 'DataLineStartP',
                        title: '数据专线起端点',

                    }, {
                        field: 'DataLineEndP',
                        title: '数据专线止端点',

                    }, {
                        field: 'BandWidth',
                        title: '带宽'
                    }, {
                        field: 'GreenOperator',
                        title: '专线运营商'
                    }, {
                        field: 'TechnicalSupportStaff',
                        title: '技术支持人员'

                    }, {
                        field: 'button',
                        title: '网络信息'

                    }],
            });
        }
        
        function viewInternet(ids) {
            layer.open({
                type: 2,
                title: '网络信息设置',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['1150px', '650px'],
                content: 'InternetSet.aspx?ID=' + ids

            });
        }
    
        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID
            });
        }


        $("#refreshnet").click(function () {
            table.bootstrapTable('refresh');

        });

        $("#deletenet").click(function () {
            var ids = getIdSelections();
            if (ids.length == 0) {
                parent.layer.msg('请先选择要删除的网络');
                return false;
            }
            layer.alert('您确定要删除这个网络吗', {
                skin: 'layui-layer-lan' //样式类名
                , btn: ['确定', '取消'], title: '删除'
            }, function () {


               
                $.ajax({
                    url: "",
                    type: "post",
                    data: {
                        action: "DeleteInternet",
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
                        $("#deletenet").blur();


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
            $(".search input").attr("placeholder", "搜索网络类型");
        });
    </script>
</body>

</html>
