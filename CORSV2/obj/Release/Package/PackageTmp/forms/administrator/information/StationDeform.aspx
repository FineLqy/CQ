<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StationDeform.aspx.cs" Inherits="CORSV2.forms.administrator.information.StationDeform" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>基站变形监测信息</title>
    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
    <link href="../../../themes/css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="../../../themes/css/plugins/fullcalendar/fullcalendar.css" rel="stylesheet">
    <link href="../../../themes/css/plugins/fullcalendar/fullcalendar.print.css" rel="stylesheet">
</head>
<body class="gray-bg">
    <form runat="server">
        <div class="wrapper wrapper-content">
            <div class="row">
                <div class="col-sm-12">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>基站变形曲线</h5>
                        </div>
                        <div class="ibox-content">
                            <div class="row">
                                <div class="form-group">
                                    <div class="form-group">
                                        <select class="form-control col-sm-1 left" style="width: 8%; margin-left: 1%" id="station" runat="server">
                                        </select>
                                        <label class="control-label col-sm-1" style="margin-top: 9px; width: 4%">站</label>
                                        <select class="form-control col-sm-1 left" style="width: 8%;" id="year" runat="server">
                                        </select>
                                        <label class="control-label col-sm-1" style="margin-top: 9px; width: 5%">年</label>
                                        <select class="form-control col-sm-1 left" style="width: 6%" id="month" runat="server">
                                            <option>1
                                            </option>
                                            <option>2
                                            </option>
                                            <option>3
                                            </option>
                                            <option>4
                                            </option>
                                            <option>5
                                            </option>
                                            <option>6
                                            </option>
                                            <option>7
                                            </option>
                                            <option>8
                                            </option>
                                            <option>9
                                            </option>
                                            <option>10
                                            </option>
                                            <option>11
                                            </option>
                                            <option>12
                                            </option>
                                        </select>
                                        <label class="control-label col-sm-1" style="margin-top: 9px; width: 6%">月</label>
                                    </div>
                                    <div class="col-sm-9" style="width: 100%">
                                        <div id="chart" style="width: 100%; height: 400px;">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>基站状态</h5>
                        </div>
                        <div class="ibox-content">
                            <div class="row">
                                <div class="col-sm-9" style="width: 100%">
                                    <div class="flot-chart">
                                        <table id="table"
                                            data-search="false"
                                            data-search-text=""
                                            data-show-refresh="false"
                                            data-show-toggle="false"
                                            data-show-columns="false"
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
                                            data-url="../../functions/jztable.aspx?action=GetData1"
                                            data-smart-display="false">
                                            <thead>
                                                <tr>
                                                    <th data-field="StationName">基站名</th>
                                                    <th data-field="NS">南北方向(mm)</th>
                                                    <th data-field="EW">东西方向(mm)</th>
                                                    <th data-field="UD">垂直方向(mm)</th>
                                                    <th data-field="Lon">经度</th>
                                                    <th data-field="Lat">维度</th>
                                                    <th data-field="OperatingState">状态</th>
                                                    <th data-field="button">查看</th>
                                                </tr>
                                            </thead>

                                        </table>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="../../../js/jquery.min.js?v=2.1.4"></script>
    <script src="../../../js/echarts.js"></script>
    <script src="../../../js/bootstrap.min.js?v=3.3.6"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script>
        function loaddata() {
            $.ajax({
                url: "?action=load&year=" + $("#year").val() + "&month=" + $("#month").val() + "&station=" + $("#station").val(),
                type: "GET",
                success: function (result) {
                    if (result == "200")
                    {
                        return;
                    }
                    var a = result.split(';');
                    var data = a[0].split(',');
                    var data1 = a[1].split(',');
                    var data2 = a[2].split(',');
                    var data3 = a[3].split(',');
                    var myChart = echarts.init(document.getElementById('chart'));
                    var yMax = 60;
                    var dataShadow = [];

                    for (var i = 0; i < data.length; i++) {
                        dataShadow.push(yMax);
                    }

                    option = {

                        tooltip: {
                            trigger: 'axis'
                        },
                        legend: {
                            data: ['东西方向', '南北方向', '垂直方向']
                        },
                        toolbox: {
                            show: true,
                            feature: {
                                dataZoom: {
                                    yAxisIndex: 'none'
                                },
                                dataView: { readOnly: false },
                                magicType: { type: ['line', 'bar'] },
                                restore: {},
                                saveAsImage: {}
                            }
                        },
                        xAxis: {
                            type: 'category',
                            boundaryGap: false,
                            data: data
                        },
                        yAxis: {
                            type: 'value',
                            axisLabel: {
                                formatter: '{value} mm'
                            }
                        },
                        series: [
                            {
                                name: '东西方向',
                                type: 'line',
                                data: data1,
                                markPoint: {
                                    data: [
                                        { type: 'max', name: '最大值' },
                                        { type: 'min', name: '最小值' }
                                    ]
                                }
                            },
                           {
                               name: '南北方向',
                               type: 'line',
                               data: data2,
                               markPoint: {
                                   data: [
                                       { type: 'max', name: '最大值' },
                                       { type: 'min', name: '最小值' }
                                   ]
                               }
                           },
                           {
                               name: '垂直方向',
                               type: 'line',
                               data: data3,
                               markPoint: {
                                   data: [
                                       { type: 'max', name: '最大值' },
                                       { type: 'min', name: '最小值' }
                                   ]
                               }
                           }
                        ]
                    };
                    myChart.setOption(option);

                }
            });
        }
        function view(id) {
            parent.layer.open({
                type: 2,
                title: '基站基本信息设置',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['1150px', '650px'],
                content: 'xtgl/jzxxset.aspx?id=' + id
            });

        }
        $("#year").on('change', loaddata);
        $("#month").on('change', loaddata);
        $("#station").on('change', loaddata);
        $(document).ready(function () {
            var table = $("#table");
            table.bootstrapTable();
            loaddata();
        });
    </script>

</body>

</html>
