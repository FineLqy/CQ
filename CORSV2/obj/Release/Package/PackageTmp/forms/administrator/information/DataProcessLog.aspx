<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataProcessLog.aspx.cs" Inherits="CORSV2.forms.administrator.information.DataProcessLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>坐标转换记录</title>
    <link rel="shortcut icon" href="../../favicon.ico" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
    <link href="../../../themes/css/bootstrap.min.3.2.0.css" type="text/css" rel="stylesheet" />
    <%-- <link href="../../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />--%>
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="ibox float-e-margins">
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    坐标转换记录
                </div>
                <div class="ibox-content">
                    <div class="bars pull-left">
                        <div class="btn-group hidden-xs" id="toolbar" role="group">
                            <button type="button" id="download" class="btn btn-outline btn-default">
                                <i class="glyphicon glyphicon-save" aria-hidden="true"></i>导出xls
                            </button>
                        </div>
                    </div>
                    <div class="boottable">
                        <table id="table"
                            data-toolbar="#toolbar"
                            data-search="true"
                            data-search-text=""
                            data-show-refresh="true"
                            data-show-toggle="true"
                            data-show-columns="true"
                            data-show-export="false"
                            data-detail-view="false"
                            data-striped="true"
                            data-minimum-count-columns="1"
                            data-show-pagination-switch="false"
                            data-pagination="true"
                            data-page-size="15"
                            data-id-field="ID"
                            data-unique-id="ID"
                            data-page-list="[15,30,50]"
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

    <script src="../../../js/jquery.min.js"></script>
    <script src="../../../js/bootstrap.min.3.2.0.js"></script>
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
                        field: 'ID',
                        title: 'ID'
                    }, {
                        field: 'UserName',
                        title: '用户名',
                        sortable: true
                    }, {
                        field: 'Company',
                        title: '所属单位',
                        sortable: true
                    }, {
                        field: 'Type',
                        title: '数据处理类型',
                        sortable: true
                    }, {
                        field: 'deTime',
                        title: '数据提交时间',
                        sortable: true
                    }, {
                        field: 'Result',
                        title: '结果'
                    }, {
                        field: 'Remark',
                        title: '备注',
                        sortable: true
                    }],
                onLoadError: function (data) {
                    $('#table').bootstrapTable('removeAll');
                },
            });
            $(".search input").attr("placeholder", "用户名");
        }
        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID;
            });
        }
        $("#download").click(function () {
            window.location.href = "?action=DownloadAll";
            //$.ajax({
            //    url: "?action=DownloadAll",
            //    type: "get",
            //    success: function () { }
            //});
            $("#download").blur();
        });

        var load = false;
        $(document).ready(function () {
            if (!load) {
                initialTable();
            }
        });
    </script>
</body>
</html>
