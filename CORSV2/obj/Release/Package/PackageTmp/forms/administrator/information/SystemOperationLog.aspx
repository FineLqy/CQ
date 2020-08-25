<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemOperationLog.aspx.cs" Inherits="CORSV2.forms.administrator.information.SystemOperationLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>系统日志</title>
    <link rel="shortcut icon" href="../../favicon.ico" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
    <link href="../../../themes/css/bootstrap.min.3.2.0.css" type="text/css" rel="stylesheet" />
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="ibox float-e-margins">

            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    系统日志
                </div>
                <div class="ibox-content">
                    <div class="bars pull-left">
                        <div id="toolbar">
                            <select id="dataType" class="form-control" onchange="changedata();">
                                <option value="0" selected="selected">管理员操作日志</option>
                                <option value="3">发布七参数变更日志</option>
                                <option value="2">基站状态变更日志</option>
                                
                            </select>
                        </div>
                    </div>
                    <div class="boottable">
                        <table id="table"
                            data-toolbar="#toolbar"
                            data-search="false"
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
                            data-url="SystemOperationLog.aspx?action=GetData&dataType=0"
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
                        field: 'ID',
                        title: 'ID'
                    }, {
                        field: 'deTime',
                        title: '时间',
                        align: 'center',
                        valign: 'middle',
                        sortable: true,

                    }, {
                        field: 'UserName',
                        title: '操作人',
                        align: 'center',
                        valign: 'middle',
                        sortable: true,
                    }, {
                        field: 'Remark',
                        title: '事件',
                        align: 'center',
                        valign: 'middle',

                    }],
                onLoadError: function (data) {
                    $('#table').bootstrapTable('removeAll');
                },
            });
        }
        //
        function changedata() {
            $('#table').bootstrapTable('refresh', {
                url: "SystemOperationLog.aspx?action=GetData&dataType=" + $("#dataType").val(),
                silent: true
            });

        };

        var load = false;
        $(document).ready(function () {
            if (!load) {
                load = true;
                initialTable();
            }

        });
    </script>
</body>
</html>
