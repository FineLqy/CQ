<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage_contract.aspx.cs" Inherits="CORSV2.forms.administrator.contract.manage_contract" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>平台用户合同管理</title>
    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet" />
    <style>
        table, th {
            vertical-align: middle;
            text-align: center;
        }
    </style>
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content  animated fadeInRight">
        <div class="row" style="padding-left:0px;padding-right:0px;">
            <div class="col-sm-8" style="padding-left:0px;padding-right:0px;width: 100%;">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>平台用户合同管理</h5>

                    </div>
                    <div class="ibox-content">
                        <div class="newstable" style="margin-top: 1%">

                            <div class="bars pull-left">
                                <div class="btn-group hidden-xs" id="toolbar" role="group">
                                    <select id="cityType" class="btn btn-outline btn-default" runat="server" onchange="changedata();" style="height:inherit;">
                                        <option value="全部" selected="selected">全部区域</option>
                                        <option value="郑州市">郑州市</option>
                                        <option value="开封市">开封市</option>
                                        <option value="三门峡市">三门峡市</option>
                                        <option value="洛阳市">洛阳市</option>
                                        <option value="焦作市">焦作市</option>
                                        <option value="新乡市">新乡市</option>
                                        <option value="鹤壁市">鹤壁市</option>
                                        <option value="安阳市">安阳市</option>
                                        <option value="濮阳市">濮阳市</option>
                                        <option value="商丘市">商丘市</option>
                                        <option value="许昌市">许昌市</option>
                                        <option value="漯河市">漯河市</option>
                                        <option value="平顶山市">平顶山市</option>
                                        <option value="南阳市">南阳市</option>
                                        <option value="信阳市">信阳市</option>
                                        <option value="周口市">周口市</option>
                                        <option value="驻马店市">驻马店市</option>
                                    </select>
                                    <select id="dataType" class="btn btn-outline btn-default" onchange="changedata();" style="height:inherit;">
                                        <option value="0" selected="selected">全部用户</option>
                                        <option value="1">个人用户</option>
                                        <option value="2">企业用户</option>
                                    </select>
                                    <button type="button" id="refreshcors" class="btn btn-outline btn-default" title="刷新单位列表">
                                        <i class="fa fa-refresh"></i>刷新
                                    </button>
                                    <button type="button" id="deletecors" class="btn btn-outline btn-default" data-toggle="tooltip" data-placement="top" title="删除">
                                        <i class="fa fa-trash-o"></i>删除
                                    </button>
                                    <button type="button" id="download" class="btn btn-outline btn-default" data-toggle="tooltip" data-placement="top" title="导出xls">
                                        <i class="fa fa-download" aria-hidden="true"></i>导出xls
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


        function initialTable() {
            table.bootstrapTable({
                columns: [
                    {
                        field: 'state',
                        checkbox: true,
                    }, {
                        field: 'Invoice',
                        title: '发票抬头',
                     

                    }, {
                        field: 'TaxNum',
                        title: '税号',
                      
                    },
                    {
                        field: 'Price',
                        title: '发票金额',

                    }, {
                        field: 'applyWay',
                        title: '开具方式'
                    },
                    {
                        field: 'ReInvoiceType',
                        title: '发票类型'
                        , sortable: true
                    },
                    //{
                    //    field: 'contractStatus',
                    //    title: '合同状态'
                    //},
                    {
                        field: 'verify',
                        title: '审核'
                         , sortable: true

                    }, {
                        field: 'uploadfile',
                        title: '操作'
                    }
                ],
            });
            $(".search input").attr("placeholder", "订单号");
        }
        function changedata() {
            table.bootstrapTable('refresh', {
                url: "?action=GetData&dataType=" + $("#dataType").val() + "&cityType=" + $("#cityType").val(),
                silent: true
            });

        };
        function verify(id) {
            layer.confirm('请对该合同申请进行审核，通过或者拒绝', {
                btn: ['通过', '拒绝'],
                closeBtn: 0,//按钮
                shadeClose: true, //开启遮罩关闭 
            }, function () {
                //layer.msg('的确很重要', { icon: 1 });
                $.get('/forms/administrator/contract/manage_contract.aspx?verify=' + id, { "status": "OK" }, function () {
                    layer.msg('已通过，请及时上传发票', { icon: 1 });
                    table.bootstrapTable('refresh');
                });
            }, function () {
                $.get('/forms/administrator/contract/manage_contract.aspx?verify=' + id, { "status": "NO" }, function () {
                    layer.msg('已驳回申请', { icon: 1 });
                    table.bootstrapTable('refresh');
                });
            });
        }

        function uploadfile(id) {
            parent.layer.open({
                type: 2,
                title: '用户发票信息',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['1150px', '650px'],
                content: '/forms/administrator/contract/contract_detail_info.aspx?action=transferContractListId&id=' + id,
                end: function () {
                    location.reload();
                }
            });
        }
        function invoice(id) {
            //parent.layer.open({
            //    type: 2,
            //    title: 'CORS用户基本信息设置',
            //    shadeClose: true,
            //    shade: false,
            //    maxmin: true, //开启最大化最小化按钮
            //    area: ['1150px', '650px'],
            //    content: '/forms/user/invoice/confirm_invoice.aspx?invoiceListId=' + id
            //});
            window.location.href = '/forms/user/invoice/confirm_invoice.aspx?invoiceListId=' + id;

        }

        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID
            });
        }

        $("#download").click(function () {
            window.location.href = "?action=DownloadAll";

            $("#download").blur();
        });
        $("#refreshcors").click(function () {
            table.bootstrapTable('refresh');

        });

        $("#deletecors").click(function () {
            var ids = getIdSelections();

            if (ids.length == 0) {
                parent.layer.msg('请先选择要删除的订单');
                return false;
            }
            layer.alert('您确定要删除这个CORS用户吗', {
                skin: 'layui-layer-lan' //样式类名
                , btn: ['确定', '取消'], title: '删除'
            }, function () {

                $.ajax({
                    url: "",
                    type: "post",
                    data: {
                        action: "DeleteCors",
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
                        }); $("#deletecors").blur();

                        table.bootstrapTable('refresh');
                    }, error: function () {
                        layer.alert('删除失败', {
                            skin: 'layui-layer-lan' //样式类名
                                     , closeBtn: 0
                        });
                    }
                });

            }, function () {

                parent.layer.msg('删除已取消');
            });
        });
        $(document).ready(function () {
            initialTable();
            //table.bootstrapTable('refresh');
        });
    </script>
</body>

</html>
