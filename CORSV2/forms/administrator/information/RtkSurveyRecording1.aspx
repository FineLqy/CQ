<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RtkSurveyRecording1.aspx.cs" Inherits="CORSV2.forms.administrator.information.RtkSurveyRecording1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>测量作业记录</title>
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
                    RTK作业记录
                </div>
                <div class="ibox-content">
                    <div class="bars pull-left  form-horizontal">
                        <div class="btn-group hidden-xs  form-group" id="toolbar" role="group">
<%--                            <div class="col-lg-4 col-sm-4">
                                <div class="input-group">
                                    <input type="text" class="form-control" id="company" placeholder="所属单位">
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-white dropdown-toggle" data-toggle="dropdown">
                                            <span class="caret"></span>
                                        </button>
                                        <ul class="dropdown-menu dropdown-menu-right" role="menu">
                                        </ul>
                                    </div>
                                    <!-- /btn-group -->
                                </div>
                            </div>--%>
                            <div class="col-lg-3 col-sm-3">
                                <input placeholder="开始日期" class="form-control  laydate-icon layer-date" id="start" onchange="startTimeQuery();">
                            </div>

                            <div class="col-lg-3 col-sm-3">
                                <input placeholder="结束日期" class="form-control  laydate-icon layer-date " id="end"></div>

                            <div class="col-lg-2 col-sm-2">
                                <button type="button" id="download" class="btn btn-outline btn-default ">
                                    <i class="glyphicon glyphicon-save" aria-hidden="true"></i>导出xls
                                </button>
                            </div>
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
    <script src="../../../js/plugins/suggest/bootstrap-suggest.min.js"></script>
    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/layer/laydate/laydate.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script>
        var table = $("#table");
        var squeryPara = new Array();
        squeryPara["startTime"] = "";
        squeryPara["endTime"] = "";
        squeryPara["company"] = "";
        function initialTable() {
            table.bootstrapTable({
                columns: [
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
                        field: 'deStartTime',
                        title: '开始测量时间',
                        sortable: true
                    }, {
                        field: 'OnlineSpan',
                        title: '测量时长(min)',
                    }, {
                        field: 'FixedSpan',
                        title: '本次固定时间'
                    }, {
                        field: 'Cost',
                        title: '花费(元)',
                    }, {
                        field: 'Remark',
                        title: '备注',
                    }],
                onLoadError: function (data) {
                    $('#table').bootstrapTable('removeAll');
                },
            });
            $(".search input").attr("placeholder", "用户名");
        }

        var start = {
            elem: "#start", format: "YYYY-MM-DD hh:mm:ss", min: "1999-06-16 23:59:59", max: laydate.now(), istime: true, istoday: true, choose: function (datas) {
                end.min = datas; end.start = datas; squeryPara["startTime"] = $("#start").val();
                query();
            }
        };
        var end = {
            elem: "#end", format: "YYYY-MM-DD hh:mm:ss", min: laydate.now(), max: laydate.now(), istime: true, istoday: true, choose: function (datas) {
                start.max = datas; squeryPara["endTime"] = $("#end").val();
                query();
            }
        };
        laydate(start);
        laydate(end);

        function query() {
            $('#table').bootstrapTable('refresh', {
                url: "?action=GetData&startTime=" + squeryPara["startTime"] +
                    "&endTime=" + squeryPara["endTime"] +
                    "&company=" + squeryPara["company"],
                silent: true
            });
        }
        var testBsSuggest = $("#company").bsSuggest({
            url: "?action=GetJsonCompany",
            showBtn: false,
            idField: "userId",
            keyField: "userName"
        })
            .on("onDataRequestSuccess",
            function (e, result) { console.log("onDataRequestSuccess: ", result) })
            .on("onSetSelectValue",
            function (e, keyword) {
                squeryPara["company"] = $("#end").val();
                query();
            })
            .on("onUnsetSelectValue", function (e) { console.log("onUnsetSelectValue") });


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
