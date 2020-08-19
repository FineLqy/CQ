<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsManage.aspx.cs" Inherits="CORSV2.forms.administrator.system.NewsManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新闻管理</title>
    <link rel="shortcut icon" href="../../favicon.ico" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/style.css?v=4.4.0" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/login.css" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content  animated fadeInRight" style="padding-top: 0px;">
        <div class="row" style="padding-left: 0px; padding-right: 0px;">
            <div class="col-sm-8" style="padding-left: 0px; padding-right: 0px; width: 100%;">
                <div class="ibox">
                    <div class="ibox-content">

                        <div class="bars pull-left">
                            <div class="btn-group hidden-xs" id="toolbar" role="group">
                                <button type="button" id="addnews" class="btn btn-outline btn-default">
                                    <i class="glyphicon glyphicon-plus" aria-hidden="true"></i>添加
                                </button>
                                 <button type="button" id="refreshnews" class="btn btn-outline btn-default" title="刷新新闻列表">
                                     <i class="fa fa-refresh"></i>刷新
                                 </button>
                                <button type="button" id="deletenews" class="btn btn-outline btn-default">
                                    <i class="glyphicon glyphicon-trash" aria-hidden="true"></i>删除
                                </button>
                            </div>
                        </div>

                        <table
                            id="table"
                            data-toolbar="#toolbar"
                            data-search="true"
                            data-search-text="搜索新闻"
                            data-show-refresh="true"
                            data-show-toggle="true"
                            data-show-columns="true"
                            data-show-export="false"
                            data-detail-view="false"
                            data-striped="true"
                            data-minimum-count-columns="1"
                            data-show-pagination-switch="false"
                            data-pagination="true"
                            data-page-size="10"
                            data-id-field="ID"
                            data-unique-id="ID"
                            data-page-list="[10, 25, 50, 100]"
                            data-show-footer="false"
                            data-side-pagination="server"
                            data-url="NewsManage.aspx?action=GetData"
                            data-smart-display="false">
                        </table>
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
                    },
                    {
                        field: 'ID',
                        title: 'ID'
                    }, {
                        field: 'Title',
                        title: '标题'
                    }, {
                        field: 'Author',
                        title: '作者'
                    }, {
                        field: 'deTime',
                        title: '时间'
                    }],
            });
        }

        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID
            });
        }

        $("#addnews").click(function () {
            layer.open({
                type: 2,
                title: '添加新闻',
                shadeClose: true,
                shade: 0.8,
                //maxmin:true,
                area: ['60%', '90%'],
                content: 'AddNews.aspx' //iframe的url
            });
            $("#addnews").blur();
        });
        $("#refreshnews").click(function () {
            initialTable();
            $("#refreshnews").blur();
        });

        $("#deletenews").click(function () {
            var ids = getIdSelections();
            table.bootstrapTable('remove', {
                field: 'ID',
                values: ids
            });
            $.ajax({
                url: "",
                type: "post",
                data: {
                    action: "DeleteNews",
                    id: ids,
                },
                success: function () { }
            });
            $("#deletenews").blur();
        });
        $(document).ready(function () {
            initialTable();
        });
    </script>
</body>

</html>
