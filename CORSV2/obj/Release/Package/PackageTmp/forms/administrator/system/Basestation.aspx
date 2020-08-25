<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Basestation.aspx.cs" Inherits="CORSV2.forms.administrator.system.Basestation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>基站数据</title>
    <link rel="shortcut icon" href="../../favicon.ico" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet" />
    <link href="../../../themes/css/bootstrap.min.3.2.0.css" type="text/css" rel="stylesheet" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/chosen/chosen.css" rel="stylesheet" />
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content  animated fadeInRight" style="padding-top: 0px;">
        <div class="row" style="padding-left: 0px; padding-right: 0px;">
            <div class="col-sm-8" style="padding-left: 0px; padding-right: 0px; width: 100%;">
                <div class="ibox">
                    <div class="ibox-content">
                   <div class="bars pull-left" style="width:68%">
                            <div class=" form-group" role="group">

                                <div class="col-lg-2 col-sm-2">
                                    <input placeholder="请选择日期" class="form-control  laydate-icon layer-date" id="date">
                                </div>

                                <div class="col-lg-2 col-sm-2">
                                    <button type="button" id="download" class="btn btn-outline btn-default ">
                                        <i class="glyphicon glyphicon-save" aria-hidden="true"></i>下载
                                    </button>
                                </div>
                            </div>
                            <div class=" form-group" role="group">

                                <div class="col-lg-2 col-sm-2">
                                    <label id="prompt_info" style="color: red;"></label>
                                </div>
                            </div>
                        </div>

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
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=7bGCq1WUPVv5H4LDIpH7u12v"></script>
    <script src="../../../../js/jquery.min.js"></script>
    <script src="../../../../js/bootstrap.min.3.2.0.js"></script>
    <script src="../../../js/plugins/chosen/chosen.jquery.js"></script>
    <script src="../../../js/plugins/suggest/bootstrap-suggest.min.js"></script>
    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/layer/laydate/laydate.js"></script>
    <script src="../../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="../../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
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
                        field: 'StationName',
                        title: '基站名',
                        sortable: true
                    }, {
                        field: 'StationOName',
                        title: 'Rinex站名',
                        sortable: true
                    }, {
                        field: 'StationType',
                        title: '基站类型',
                        sortable: true
                    }],
                onLoadError: function (data) {
                    $('#table').bootstrapTable('removeAll');
                },
                onCheck: hasData,
                onUncheck: hasData,
            });
            $(".search input").attr("placeholder", "基站名");
        }

        var squeryPara = new Array();
        squeryPara["date"] = "";
        squeryPara["station"] = "";


        var start = {
            elem: "#date", format: "YYYY-MM-DD", min: "1994-01-01", max: laydate.now(), istime: false, istoday: true, choose: function (datas) {
                squeryPara["date"] = $("#date").val();
                hasData();
            }
        };
        laydate(start);
        function hasData() {
            var ids = getIdSelections().join(",");
            if (ids.length < 1) {
                $("#download").attr("disabled", true);
                $("#prompt_info")[0].innerText = "请选择基站";
                return;
            }
            if ($("#date").val() == "") {
                $("#download").attr("disabled", true);
                $("#prompt_info")[0].innerText = "请选择日期";
                return;
            }
            $.ajax({
                url: "?action=HasData&date=" + squeryPara["date"] + "&station=" + ids,
                type: "get",
                success: function (isEmpty) {
                    if (isEmpty == 0) {
                        $("#download").attr("disabled", true);
                        $("#prompt_info")[0].innerText = "无数据！";
                    }
                    else {
                        $("#prompt_info")[0].innerText = "";
                        $("#download").attr("disabled", false);
                    }
                }
            });
        }
        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.StationOName;
            });
        }
        $("#download").click(function () {
            var ids = getIdSelections().join(",");
            if (ids.length < 1) {
                alert("请选择基站");
                $("#download").blur();
                return;
            }
            window.location.href = "?action=DownloadAll&date=" + squeryPara["date"] + "&station=" + ids;
            $("#download").blur();
        });
        $(document).ready(function () {
            initialTable();
            $("#download").attr("disabled", true);
        });
    </script>
</body>
</html>
