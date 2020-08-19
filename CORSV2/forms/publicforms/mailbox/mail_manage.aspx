﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mail_manage.aspx.cs" Inherits="CORSV2.forms.publicforms.mailbox.mail_manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>CORS用户管理</title>

    <link rel="shortcut icon" href="../../favicon.ico" />
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
    <div class="wrapper wrapper-content  animated fadeInRight" style="padding-top: 0px;">
        <div class="row" style="padding-left: 0px; padding-right: 0px;">
            <div class="col-sm-8" style="padding-left:0px;padding-right:0px;width: 100%;">
                <div class="ibox">
                        <div class="ibox-title">
                            <h5>邮件管理</h5>
                        </div>

                        <div class="ibox-content">
                            <div class="newstable" style="margin-top: 1%">

                                <div class="bars pull-left">

                                    <div class="btn-group hidden-xs" id="toolbar" role="group" style="height: 34px;">
                                        <select id="cityType" class="btn btn-outline btn-default" runat="server" onchange="changedata();" style="height: inherit;">
                                            <option value="全部" selected="selected">全部区域</option>
                                        </select>
                                        <select id="dataType" class="btn btn-outline btn-default" onchange="changedata();" style="height: inherit;">
                                            <option value="0" selected="selected">全部用户</option>
                                            <option value="1">企业用户</option>
                                            <option value="2">个人用户</option>
                                        </select>
                                        <button type="button" id="refreshcors" class="btn btn-outline btn-default" title="刷新单位列表" style="height: inherit;">
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
                        field: 'UserName',
                        title: '发件人',
                        sortable: true

                    }, {
                        field: 'reLogTime',
                        title: '消息时间',
                        sortable: true
                    }, {
                        field: 'Remark',
                        title: '消息主题'
                    }, {
                        field: 'readSymbol',
                        title: '邮件状态',
                        sortable: true

                    }
                ],
            });
            $(".search input").attr("placeholder", "用户名");
        }
        function changedata() {
            table.bootstrapTable('refresh', {
                url: "?action=GetData&dataType=" + $("#dataType").val() + "&cityType=" + $("#cityType").val(),
                silent: true
            });

        };
        //function identifyHaveRead(id) {
        //    parent.layer.open({
        //        type: 2,
        //        title: '资质信息',
        //        shadeClose: true,
        //        shade: false,
        //        maxmin: true, //开启最大化最小化按钮
        //        area: ['1150px', '650px'],
        //        content: '/forms/administrator/users/qualification_certify_show.aspx?id=' + id
        //    });
        //}
        function identifyHaveRead(id) {
            $.get('mail_manage.aspx?sysLogId=' + id, { "status": "identifyHaveRead" }, function () {
                layer.msg('消息已读', { icon: 1 });
  
                table.bootstrapTable('refresh');
            });
           
        }

        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID
            });
        }

        $("#download").click(function () {
            window.location.href = "mail_manage.aspx?action=DownloadAll";

            $("#download").blur();
        });
        $("#refreshcors").click(function () {
            table.bootstrapTable('refresh');

        });

        $("#deletecors").click(function () {
            var ids = getIdSelections();
            if (ids.length == 0) {
                parent.layer.msg('请先选择要删除的邮件');
                return false;
            }
            layer.alert('您确定要删除这个邮件吗', {
                skin: 'layui-layer-lan' //样式类名
                , btn: ['确定', '取消'], title: '删除'
            }, function () {

                $.ajax({
                    url: "mail_manage.aspx",
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
        });
    </script>
</body>

</html>