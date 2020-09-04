<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataQualityAnalysis.aspx.cs" Inherits="CORSV2.forms.administrator.information.DataQualityAnalysis" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>基站数据质量分析</title>

    <link rel="shortcut icon" href="../../favicon.ico" />

    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">

    <script src="../../../js/jquery.min.js"></script>
    <script src="http://webapi.amap.com/maps?v=1.4.14&amp;key=b74b8fd91eb7e6bc323fc3387c02b261&amp;plugin=Map3D,AMap.Autocomplete,AMap.PlaceSearch,AMap.MarkerClusterer,AMap.DistrictSearch,AMap.CustomLayer,AMap.Heatmap"></script>
    <script src="../../../js/echarts-gl.min.js"></script>
    <script src="../../../js/echarts.min.js"></script>
    <script src="../../../js/echarts.js"></script>
    <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/echarts-all-3.js"></script>

    <style type="text/css">
        #warp {
            height: 980px;
            width: 95%;
            border: 1px solid #e0dede;
            overflow: hidden;
            margin: 10px 0 0 10px;
            float: left;
            position: relative;
        }

        #box {
            height: 100%;
            overflow-x: hidden;
            overflow-y: auto;
            padding: 10px;
        }

        p {
            height: 30px;
            border: 1px solid #eee;
            margin: 0;
            padding: 0;
        }

        #scrollBar {
            height: 100%;
            width: 5px;
            position: absolute;
            right: 0;
            top: 0;
            border-radius: 5px;
            background-color: #939393;
            opacity: 0.7;
            cursor: pointer;
        }

            #scrollBar:hover {
                background-color: #000000;
            }
    </style>
    <script src="../../publicforms/map/setBar.js"></script>

    <script>
        $(function () {

            setSrollBar()
        })
    </script>
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content  animated fadeInRight" style="padding-top: 0px; width: 75%; float: left">
        <div class="row" style="padding-left: 0px; padding-right: 0px;">
            <div class="col-sm-8" style="padding-left: 0px; padding-right: 0px; width: 100%;">
                <div class="ibox">
                    <div class="ibox-content">
                        <div class="newstable" style="margin-top: 1%">



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
                                data-page-size="25"
                                data-id-field="ID"
                                data-unique-id="ID"
                                data-page-list="[25, 50, 100]"
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




    <div style="width: 24%; height: 980px; float: left; margin-top: 20px">
        <span>统计信息:</span>
        <button type="button" id="week" class="btn btn-outline btn-default" title="本周">
            <i></i>本周
        </button>
        <button type="button" id="month" class="btn btn-outline btn-default" title="本月">
            <i></i>本月
        </button>
        <button type="button" id="year" class="btn btn-outline btn-default" title="今年">
            <i></i>今年
        </button>
        <button type="button" id="SinceOperation" class="btn btn-outline btn-default" title="运行以来">
            <i></i>运行以来
        </button>
        <div id='warp'>
            <div id="box">

                <div id="d1" style="width: 100%; height: 25%; border-bottom: 1px solid #e0dede">多路径误差MP1</div>
                <div id="d2" style="width: 100%; height: 25%; position: relative; border-bottom: 1px solid #e0dede">多路径误差MP2</div>
                <div id="d3" style="width: 100%; height: 25%; border-bottom: 1px solid #e0dede">周跳比的倒数</div>
                <div id="d4" style="width: 100%; height: 25%; border-bottom: 1px solid #e0dede">L1信噪比</div>
                <div id="d5" style="width: 100%; height: 25%; border-bottom: 1px solid #e0dede">L2信噪比</div>
                <div id="d6" style="width: 100%; height: 25%; border-bottom: 1px solid #e0dede">数据完整率</div>
            </div>
        </div>
    </div>

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
                        field: 'StationName',
                        title: '基站名'
                    }, {
                        field: 'StationOName',
                        title: 'Rinex站名',

                    }, {
                        field: 'TransferType',
                        title: '传输类型',

                    }, {
                        field: 'IP',
                        title: 'IP地址'
                    }, {
                        field: 'Port',
                        title: '端口'
                    }, {
                        field: 'Lat',
                        title: '纬度'
                    }, {
                        field: 'Lon',
                        title: '经度'

                    }, {
                        field: 'H',
                        title: '高度'
                    }, {
                        field: 'deIsOK',
                        title: '是否正常',


                    }, {
                        field: 'SatNum',
                        title: '卫星数',


                    }
                ],
            });
        }



        $("#refreshsta").click(function () {
            table.bootstrapTable('refresh');

        });

        $(document).ready(function () {
            initialTable();
            $(".search input").attr("placeholder", "搜索基站名或Rinex站名");
        });
    </script>



    <script>
        var Index1 = echarts.init(document.getElementById('d1'));
        var Index2 = echarts.init(document.getElementById('d2'));
        var Index3 = echarts.init(document.getElementById('d3'))
        var Index4 = echarts.init(document.getElementById('d4'));
        var Index5 = echarts.init(document.getElementById('d5'));
        var Index6 = echarts.init(document.getElementById('d6'))
        var XData = new Array();
        var CMp1 = new Array();
        var EMp1 = new Array();
        var GMp1 = new Array();
        var RMp1 = new Array();
        var CMp2 = new Array();
        var EMp2 = new Array();
        var GMp2 = new Array();
        var RMp2 = new Array();
        var CSlps = new Array();
        var ESlps = new Array();
        var GSlps = new Array();
        var RSlps = new Array();
        var CSN1 = new Array();
        var ESN1 = new Array();
        var GSN1 = new Array();
        var RSN1 = new Array();
        var CSN2 = new Array();
        var ESN2 = new Array();
        var GSN2 = new Array();
        var RSN2 = new Array();
        var CDIR = new Array()
        var EDIR = new Array()
        var GDIR = new Array()
        var RDIR = new Array()
        //查询本周数据
        $("#week").click(function () {
            document.getElementById("week").style.background = "#F3BA0E";
            document.getElementById("month").style.background = "";
             document.getElementById("year").style.background = "";
            var data1 = getStartDayOfWeek();
            var data2 = getEndDayOfWeek();

            $.ajax({
                url: "DataQualityAnalysis.aspx?action=GetData1",

                dataType: "json",
                data: {
                    data1: data1,
                    

                },
                type: "POST",
                success: function (data) {
                    console.log(data);

                    $('#table').on('click-row.bs.table', function (e, row, $element) {
                        console.log(row.StationOName);
                        for (var i in data) {

                            var dataLen = 0;
                            for (var k in data[i]) {
                                dataLen++;
                            }
                            console.info(dataLen);
                            for (var j in data[i]) {


                                var num = j.substring(0, 10);

                                if (XData.length < dataLen) {
                                    XData.push(num);
                                }

                                for (var k in data[i][j]) {

                                    if (k == row.StationOName) {

                                        for (var p in data[i][j][k]) {
                                            //console.log(data[i][j][k][p])
                                            console.log(p)
                                            if (p == "C") {

                                                CMp1.push(data[i][j][k][p].Mp1);
                                                CMp2.push(data[i][j][k][p].Mp2);
                                                CSlps.push(data[i][j][k][p].Slps);
                                                CSN1.push(data[i][j][k][p].SN1);
                                                CSN2.push(data[i][j][k][p].SN2);
                                                CDIR.push(data[i][j][k][p].DIR)
                                            }
                                            if (p == "E") {

                                                EMp1.push(data[i][j][k][p].Mp1);
                                                EMp2.push(data[i][j][k][p].Mp2);
                                                ESlps.push(data[i][j][k][p].Slps);
                                                ESN1.push(data[i][j][k][p].SN1);
                                                ESN2.push(data[i][j][k][p].SN2);
                                                EDIR.push(data[i][j][k][p].DIR)
                                            }
                                            if (p == "G") {

                                                GMp1.push(data[i][j][k][p].Mp1);
                                                GMp2.push(data[i][j][k][p].Mp2);
                                                GSlps.push(data[i][j][k][p].Slps);
                                                GSN1.push(data[i][j][k][p].SN1);
                                                GSN2.push(data[i][j][k][p].SN2);
                                                GDIR.push(data[i][j][k][p].DIR)
                                            }
                                            if (p == "R") {

                                                RMp1.push(data[i][j][k][p].Mp1);
                                                RMp2.push(data[i][j][k][p].Mp2);
                                                RSlps.push(data[i][j][k][p].Slps);
                                                RSN1.push(data[i][j][k][p].SN1);
                                                RSN2.push(data[i][j][k][p].SN2);
                                                RDIR.push(data[i][j][k][p].DIR)
                                            }
                                        }

                                    }



                                }
                            }

                            console.log(CDIR);


                        }

                        //---------------------MP1-----------------------------



                        Index1.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option1 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: '多路径误差MP1',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CMp1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GMp1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: EMp1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RMp1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index1.hideLoading();  //提示关闭
                            Index1.setOption(option1);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }



                        //------------------------MP2---------------------
                        Index2.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option2 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: '多路径误差MP2',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CMp2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GMp2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: EMp2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RMp2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index2.hideLoading();  //提示关闭
                            Index2.setOption(option2);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }

                        //------------------------周跳比的倒数---------------------
                        Index3.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option3 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: '周跳比的倒数',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CSlps,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GSlps,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: ESlps,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RSlps,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index3.hideLoading();  //提示关闭
                            Index3.setOption(option3);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }

                        //------------------------L1信噪比-------------------
                        Index4.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option4 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: 'L1信噪比',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CSN1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GSN1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: ESN1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RSN1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index4.hideLoading();  //提示关闭
                            Index4.setOption(option4);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }

                        //------------------------L2信噪比-------------------
                        Index5.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option5 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: 'L2信噪比',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CSN2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GSN2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: ESN2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RSN2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index5.hideLoading();  //提示关闭
                            Index5.setOption(option5);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }


                        //------------------------数据完整率-------------------
                        Index6.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option6 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: '数据完整率',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CDIR,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GDIR,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: EDIR,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RDIR,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index6.hideLoading();  //提示关闭
                            Index6.setOption(option6);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }
                    });

                }
            });


        });

        //查询本月数据
        $("#month").click(function () {

            document.getElementById("month").style.background = "#F3BA0E";
            document.getElementById("week").style.background = "";
             document.getElementById("year").style.background = "";
            var data = getStartDayOfMonth();
            $.ajax({
                url: "DataQualityAnalysis.aspx?action=GetData2",

                dataType: "json",
                data: {
                    data1: data,
                  

                },
                type: "POST",
                success: function (data) {
                    console.log(data);

                    $('#table').on('click-row.bs.table', function (e, row, $element) {
                        console.log(row.StationOName);
                        for (var i in data) {

                            var dataLen = 0;
                            for (var k in data[i]) {
                                dataLen++;
                            }
                            console.info(dataLen);
                            for (var j in data[i]) {


                                var num = j.substring(0, 10);

                                if (XData.length < dataLen) {
                                    XData.push(num);
                                }

                                for (var k in data[i][j]) {

                                    if (k == row.StationOName) {

                                        for (var p in data[i][j][k]) {
                                            //console.log(data[i][j][k][p])
                                            console.log(p)
                                            if (p == "C") {

                                                CMp1.push(data[i][j][k][p].Mp1);
                                                CMp2.push(data[i][j][k][p].Mp2);
                                                CSlps.push(data[i][j][k][p].Slps);
                                                CSN1.push(data[i][j][k][p].SN1);
                                                CSN2.push(data[i][j][k][p].SN2);
                                                CDIR.push(data[i][j][k][p].DIR)
                                            }
                                            if (p == "E") {

                                                EMp1.push(data[i][j][k][p].Mp1);
                                                EMp2.push(data[i][j][k][p].Mp2);
                                                ESlps.push(data[i][j][k][p].Slps);
                                                ESN1.push(data[i][j][k][p].SN1);
                                                ESN2.push(data[i][j][k][p].SN2);
                                                EDIR.push(data[i][j][k][p].DIR)
                                            }
                                            if (p == "G") {

                                                GMp1.push(data[i][j][k][p].Mp1);
                                                GMp2.push(data[i][j][k][p].Mp2);
                                                GSlps.push(data[i][j][k][p].Slps);
                                                GSN1.push(data[i][j][k][p].SN1);
                                                GSN2.push(data[i][j][k][p].SN2);
                                                GDIR.push(data[i][j][k][p].DIR)
                                            }
                                            if (p == "R") {

                                                RMp1.push(data[i][j][k][p].Mp1);
                                                RMp2.push(data[i][j][k][p].Mp2);
                                                RSlps.push(data[i][j][k][p].Slps);
                                                RSN1.push(data[i][j][k][p].SN1);
                                                RSN2.push(data[i][j][k][p].SN2);
                                                RDIR.push(data[i][j][k][p].DIR)
                                            }
                                        }

                                    }



                                }
                            }

                            console.log(CSlps);


                        }

                        //---------------------MP1-----------------------------



                        Index1.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option1 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: '多路径误差MP1',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CMp1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GMp1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: EMp1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RMp1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index1.hideLoading();  //提示关闭
                            Index1.setOption(option1);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }



                        //------------------------MP2---------------------
                        Index2.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option2 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: '多路径误差MP2',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CMp2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GMp2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: EMp2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RMp2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index2.hideLoading();  //提示关闭
                            Index2.setOption(option2);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }

                        //------------------------周跳比的倒数---------------------
                        Index3.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option3 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: '周跳比的倒数',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CSlps,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GSlps,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: ESlps,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RSlps,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index3.hideLoading();  //提示关闭
                            Index3.setOption(option3);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }

                        //------------------------L1信噪比-------------------
                        Index4.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option4 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: 'L1信噪比',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CSN1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GSN1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: ESN1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RSN1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index4.hideLoading();  //提示关闭
                            Index4.setOption(option4);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }

                        //------------------------L2信噪比-------------------
                        Index5.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option5 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: 'L2信噪比',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CSN2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GSN2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: ESN2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RSN2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index5.hideLoading();  //提示关闭
                            Index5.setOption(option5);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }


                        //------------------------数据完整率-------------------
                        Index6.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option6 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: '数据完整率',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CDIR,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GDIR,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: EDIR,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RDIR,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index6.hideLoading();  //提示关闭
                            Index6.setOption(option6);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }
                    });

                }
            });


        });

        //查询今年数据
        $("#year").click(function () {
         var currentYear=now.getFullYear();//获得当前年份4位年

            var data= currentYear+"/1/1 0:00:00";

         document.getElementById("year").style.background = "#F3BA0E";
          document.getElementById("month").style.background = "";
            document.getElementById("week").style.background = "";
            var data = data
            $.ajax({
                url: "DataQualityAnalysis.aspx?action=GetData3",

                dataType: "json",
                data: {
                    data1: data,
                  

                },
                type: "POST",
                success: function (data) {
                    console.log(data);

                    $('#table').on('click-row.bs.table', function (e, row, $element) {
                        console.log(row.StationOName);
                        for (var i in data) {

                            var dataLen = 0;
                            for (var k in data[i]) {
                                dataLen++;
                            }
                            console.info(dataLen);
                            for (var j in data[i]) {


                                var num = j.substring(0, 10);

                                if (XData.length < dataLen) {
                                    XData.push(num);
                                }

                                for (var k in data[i][j]) {

                                    if (k == row.StationOName) {

                                        for (var p in data[i][j][k]) {
                                            //console.log(data[i][j][k][p])
                                            console.log(p)
                                            if (p == "C") {

                                                CMp1.push(data[i][j][k][p].Mp1);
                                                CMp2.push(data[i][j][k][p].Mp2);
                                                CSlps.push(data[i][j][k][p].Slps);
                                                CSN1.push(data[i][j][k][p].SN1);
                                                CSN2.push(data[i][j][k][p].SN2);
                                                CDIR.push(data[i][j][k][p].DIR)
                                            }
                                            if (p == "E") {

                                                EMp1.push(data[i][j][k][p].Mp1);
                                                EMp2.push(data[i][j][k][p].Mp2);
                                                ESlps.push(data[i][j][k][p].Slps);
                                                ESN1.push(data[i][j][k][p].SN1);
                                                ESN2.push(data[i][j][k][p].SN2);
                                                EDIR.push(data[i][j][k][p].DIR)
                                            }
                                            if (p == "G") {

                                                GMp1.push(data[i][j][k][p].Mp1);
                                                GMp2.push(data[i][j][k][p].Mp2);
                                                GSlps.push(data[i][j][k][p].Slps);
                                                GSN1.push(data[i][j][k][p].SN1);
                                                GSN2.push(data[i][j][k][p].SN2);
                                                GDIR.push(data[i][j][k][p].DIR)
                                            }
                                            if (p == "R") {

                                                RMp1.push(data[i][j][k][p].Mp1);
                                                RMp2.push(data[i][j][k][p].Mp2);
                                                RSlps.push(data[i][j][k][p].Slps);
                                                RSN1.push(data[i][j][k][p].SN1);
                                                RSN2.push(data[i][j][k][p].SN2);
                                                RDIR.push(data[i][j][k][p].DIR)
                                            }
                                        }

                                    }



                                }
                            }

                            console.log(RDIR);


                        }

                        //---------------------MP1-----------------------------



                        Index1.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option1 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: '多路径误差MP1',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CMp1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GMp1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: EMp1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RMp1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index1.hideLoading();  //提示关闭
                            Index1.setOption(option1);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }



                        //------------------------MP2---------------------
                        Index2.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option2 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: '多路径误差MP2',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CMp2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GMp2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: EMp2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RMp2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index2.hideLoading();  //提示关闭
                            Index2.setOption(option2);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }

                        //------------------------周跳比的倒数---------------------
                        Index3.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option3 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: '周跳比的倒数',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CSlps,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GSlps,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: ESlps,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RSlps,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index3.hideLoading();  //提示关闭
                            Index3.setOption(option3);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }

                        //------------------------L1信噪比-------------------
                        Index4.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option4 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: 'L1信噪比',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CSN1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GSN1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: ESN1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RSN1,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index4.hideLoading();  //提示关闭
                            Index4.setOption(option4);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }

                        //------------------------L2信噪比-------------------
                        Index5.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option5 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: 'L2信噪比',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CSN2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GSN2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: ESN2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RSN2,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index5.hideLoading();  //提示关闭
                            Index5.setOption(option5);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }


                        //------------------------数据完整率-------------------
                        Index6.showLoading({
                            text: '正在加载数据....'
                        });
                        var zoomstart = 0;
                        var zoomend = 100;

                        var restart = setInterval(function () {
                            var areaList1 = XData;


                            option6 = {
                                backgroundColor: '',//背景颜色透明
                                title: {
                                    text: '数据完整率',
                                    x: 'center'
                                },
                                grid: {
                                    backgroundColor: '#fff',
                                    top: "30",
                                    bottom: "15%",
                                    right: "10%",
                                    left: "12%",
                                },
                                legend: {
                                    show: true, // 是否显示图列
                                    left: 'center',
                                    top: 'bottom',
                                    textStyle: {
                                        color: '#000000',
                                        fontSize: 10
                                    },

                                },
                                tooltip: {
                                    trigger: 'axis',
                                },

                                xAxis: [{

                                    type: 'category',
                                    onZero: true,
                                    position: 'bottom',
                                    axisLine: {
                                        show: true,
                                        lineStyle: {
                                            color: "#cfd4d8",
                                            width: "2"
                                        }
                                    },
                                    axisLabel: {
                                        show: true,
                                        textStyle: {
                                            color: '#000000',
                                            fontSize: 10
                                        },
                                        interval: 0,
                                        rotate: 25, //横坐标标签斜置
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    data: areaList1
                                }],
                                dataZoom: [{
                                    type: 'slider',
                                    show: false,
                                    start: zoomStart(),
                                    end: zoomEnd(areaList1.length), //默认显示条柱数

                                }],
                                yAxis: [{

                                    type: 'value',



                                    axisLabel: {
                                        show: true,


                                        color: '#000000',
                                    },
                                    axisLine: {
                                        show: true,
                                        lineStyle: {

                                            width: "2"
                                        }
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: false,
                                        lineStyle: {

                                            width: 1,
                                            type: 'dashed'
                                        }
                                    },
                                    nameTextStyle: {
                                        color: '#7e878e',
                                    },

                                }],
                                series: [

                                    {
                                        name: 'BDS',
                                        type: 'bar',
                                        barWidth: 7,

                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: CDIR,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#82CBF9' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#064AF7' // 100% 处的颜色
                                                }], false)

                                            }
                                        },
                                    },
                                    {
                                        name: 'GPS',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: GDIR,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#F8A974' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F66E12' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GLO',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: EDIR,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#DEDEDE' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#929292' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    },
                                    {
                                        name: 'GAL',
                                        type: 'bar',
                                        barWidth: 7,
                                        label: {
                                            normal: {
                                                show: false,
                                                position: 'top',


                                            }
                                        },
                                        data: RDIR,
                                        itemStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                                                    offset: 0,
                                                    color: '#FBDB7B' // 0% 处的颜色
                                                }, {
                                                    offset: 1,
                                                    color: '#F2B601' // 100% 处的颜色
                                                }], false)
                                            }
                                        },
                                    }
                                ]
                            };
                            Index6.hideLoading();  //提示关闭
                            Index6.setOption(option6);
                        }, 3000);
                        //dataZoom的自动播放
                        function zoomStart() {
                            if (zoomend >= 100)
                                zoomstart = 0;
                            else {
                                zoomstart += 20;
                            }
                            return zoomstart;
                        }

                        function zoomEnd(length) {
                            var displayNum = 5; //根据屏幕分辨率，定默认显示条柱数

                            if (length > displayNum && zoomstart === 0) {
                                zoomend = (displayNum / length) * 100;
                            } else if (length > displayNum) {
                                zoomend += 20;
                            } else {
                                zoomend = 100;
                                clearInterval(restart);
                            }
                            return zoomend;
                        }
                    });

                }
            });


        });
        //查询所有数据
        $("#SinceOperation").click(function () {
            alert($("#text2").val());

        });


        var now = new Date(); // 当前日期
        var nowDayOfWeek = now.getDay(); // 今天本周的第几天
        var nowDay = now.getDate(); // 当前日
        var nowMonth = now.getMonth(); // 当前月
        var nowYear = now.getYear(); // 当前年
        nowYear += (nowYear < 2000) ? 1900 : 0;
        /**
    * 获得当前日期
    * 
    * @returns
    */
        function getNowDay() {
            return this.formatDate(new Date());
        }
        /**
         * 获得本周的开始时间
         * 
         * @returns
         */
        function getStartDayOfWeek() {
            var day = nowDayOfWeek || 7;
            return this.formatDate(new Date(now.getFullYear(), nowMonth, nowDay + 1 - day));
        }
        /**
         * 获得本周的结束时间
         * 
         * @returns
         */
        function getEndDayOfWeek() {
            var day = nowDayOfWeek || 7;
            return this.formatDate(new Date(now.getFullYear(), nowMonth, nowDay + 7 - day));
        }
        /**
         * 获得本月的开始时间
         * 
         * @returns
         */
        function getStartDayOfMonth() {
            var monthStartDate = new Date(nowYear, nowMonth, 1);
            return this.formatDate(monthStartDate);
        }
        /**
         * 获得本月的结束时间
         * 
         * @returns
         */
        function getEndDayOfMonth() {
            var monthEndDate = new Date(nowYear, nowMonth, this.getMonthDays());
            return this.formatDate(monthEndDate);
        }
        /**
         * 获得本月天数
         * 
         * @returns
         */
        function getMonthDays() {
            var monthStartDate = new Date(nowYear, nowMonth, 1);
            var monthEndDate = new Date(nowYear, nowMonth + 1, 1);
            var days = (monthEndDate - monthStartDate) / (1000 * 60 * 60 * 24);
            return days;
        }
        /**
         * @param 日期格式化
         * @returns {String}
         */
        function formatDate(date) {
            var myyear = date.getFullYear();
            var mymonth = date.getMonth() + 1;
            var myweekday = date.getDate();

            if (mymonth < 10) {
                mymonth = "0" + mymonth;
            }
            if (myweekday < 10) {
                myweekday = "0" + myweekday;
            }
            return (myyear + "-" + mymonth + "-" + myweekday);
        }
    </script>
</body>

</html>
