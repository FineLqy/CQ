<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FaultStatistics.aspx.cs" Inherits="CORSV2.forms.administrator.information.FaultStatistics" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>基站故障统计</title>

    <link rel="shortcut icon" href="../../favicon.ico" />

    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">

    <script src="../../../js/jquery.min.js"></script>
    <style type="text/css">
        #warp {
            height: 640px;
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
    <style>
        ul,li{ padding:0;margin:0;list-style:none;

        }
       li{
float:left;
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
    <div style="width: 100%; height: 100%; float: left;">
        <span>统计信息:</span>





        <ul class="priceList" style="margin-top: 16px;">
            <li>
                <button type="button" id="week" class="btn btn-outline btn-default" title="本周">
                    <i></i>本周
                </button>
            </li>
            <li>
                <button type="button" id="month" class="btn btn-outline btn-default" title="本月">
                    <i></i>本月
                </button>
            </li>
            <li>
                <button type="button" id="year" class="btn btn-outline btn-default" title="今年">
                    <i></i>今年
                </button>
            </li>
            <li>
                <button type="button" id="SinceOperation" class="btn btn-outline btn-default" title="运行以来">
                    <i></i>运行以来
                </button>
            </li>
        </ul>
        <div id='warp'>
            <div id="box">

                <div id="d1" style="width: 90%; height: 35%; border-bottom: 1px solid #e0dede"></div>
                <div id="d2" style="width: 90%; height: 35%; border-bottom: 1px solid #e0dede"></div>

            </div>
        </div>
    </div>







    <script src="../../../js/bootstrap.min.js"></script>

    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script src="http://webapi.amap.com/maps?v=1.4.14&amp;key=b74b8fd91eb7e6bc323fc3387c02b261&amp;plugin=Map3D,AMap.Autocomplete,AMap.PlaceSearch,AMap.MarkerClusterer,AMap.DistrictSearch,AMap.CustomLayer,AMap.Heatmap"></script>
    <script src="../../../js/echarts-gl.min.js"></script>
    <script src="../../../js/echarts.min.js"></script>
    <script src="../../../js/echarts.js"></script>
    <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/echarts-all-3.js"></script>

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
         $(function () {
                    var v1 = [];
                    var Rname = '123';
                    $.ajax({
                        url: "FaultStatistics.aspx/lodaa1",
                        contentType: "application/json; charset=utf-8",
                        data: "{t:'" + Rname + "'}",
                        type: "Post",
                        dataType: "json",
                        success: function (data) {
                            var res = JSON.parse(data.d);
                            console.log(data)
                            console.log(res.dt1);
                            var da = new Array();
                            var Num = [];
                            for (var i in res.dt1) {
                                console.log(res.dt1[i].Num)
                                da.push(res.dt1[i].StationOName)
                                var op1 = echarts.init(document.getElementById('d1'));
                                var datacolor = da;
                                Num.push(res.dt1[i].Num)

                                option = {
                                    title: {
                                        text: '站点故障频率排行',

                                    },
                                    tooltip: {
                                        trigger: 'axis',
                                        axisPointer: {
                                            type: 'shadow'
                                        }
                                    },

                                    grid: {
                                        left: '15%',

                                    },
                                    // visualMap: {
                                    //     orient: 'horizontal',
                                    //     left: 'center',
                                    //     min: 10,
                                    //     max: 200000,
                                    //     text: ['High', 'Low'],
                                    //     // Map the score column to color
                                    //     dimension: 0,
                                    //     inRange: {
                                    //         color: ['#D7DA8B', '#E15457']
                                    //     }
                                    // },
                                    xAxis: {
                                        type: 'value',
                                        boundaryGap: [0, 0.01]
                                    },
                                    yAxis: {
                                        type: 'category',
                                        data: datacolor
                                    },
                                    series: [
                                        {

                                            type: 'bar',
                                            data: Num
                                        }
                                    ]
                                };

                                op1.setOption(option);

                            }





                        }
                    })
                });
                $(function () {
                    var v1 = [];
                    var Rname = '123';
                    $.ajax({
                        url: "FaultStatistics.aspx/lodaa2",
                        contentType: "application/json; charset=utf-8",
                        data: "{t:'" + Rname + "'}",
                        type: "Post",
                        dataType: "json",
                        success: function (data) {
                            var res = JSON.parse(data.d);
                            console.log(data)
                            console.log(res.dt2);
                            var da = new Array();
                            var Num = [];
                            for (var i in res.dt2) {
                                console.log(res.dt2[i].Num)
                                da.push(res.dt2[i].Datayear)
                                var op2 = echarts.init(document.getElementById('d2'));
                                var datacolor = da;
                                Num.push(res.dt2[i].Num)

                                let pointStyle = {
                                    borderColor: '#ea6f21',
                                    color: '#fff',
                                    borderWidth: 2,
                                }
                                let labelStyle = {
                                    show: true,
                                    position: 'top',
                                    lineHeight: 20,
                                    borderRadius: 5,
                                    backgroundColor: 'rgba(255,255,255,.9)',
                                    borderColor: '#ccc',
                                    borderWidth: '1',
                                    padding: [5, 15, 4],
                                    color: '#000000',
                                    fontSize: 14,
                                    fontWeight: 'normal',
                                }
                                let total = Num
                                let seriesData = []
                                total = total.sort(function (a, b) {
                                    return a - b
                                })
                                total.forEach((item, index) => {
                                    let ob = {
                                        value: item,
                                        itemStyle: pointStyle,
                                        label: labelStyle,
                                    }
                                    if (index === total.length - 1) {
                                        ob.itemStyle = {
                                            borderColor: '#ea6f21',
                                            color: '#ea6f21',
                                            borderWidth: 3,
                                        }
                                        ob.label = {
                                            show: true,
                                            position: 'top',
                                            lineHeight: 20,
                                            backgroundColor: '#ea6f21',
                                            borderRadius: 5,
                                            borderColor: '#ea6f21',
                                            borderWidth: '1',
                                            padding: [5, 15, 4],
                                            color: '#fff',
                                            fontSize: 14,
                                            fontWeight: 'normal',
                                        }
                                    }
                                    seriesData.push(ob)
                                })

                                option = {
                                    title: {
                                        text: '站点故障总数',
                                        left: 'left',
                                    },
                                    grid: {
                                        top: '15%',
                                        left: '15%',
                                        right: '8%',
                                        bottom: '15%',
                                    },
                                    xAxis: [{
                                        type: 'category',
                                        axisTick: {
                                            show: false,
                                        },

                                        splitLine: {
                                            show: true,
                                            lineStyle: {
                                                type: 'dashed',
                                            },
                                        },
                                        data: da,
                                    },],

                                    yAxis: [{
                                        type: 'value',
                                        min: 0,
                                        max: 100,
                                        splitNumber: 3,
                                        axisLine: {
                                            show: true,
                                        },
                                        axisTick: {
                                            show: false,
                                        },
                                        splitLine: {
                                            show: true,
                                            lineStyle: {
                                                type: 'dashed',
                                            },
                                        },
                                    },],
                                    series: [{
                                        type: 'line',
                                        showAllSymbol: true,
                                        symbol: 'circle',
                                        symbolSize: 10,
                                        lineStyle: {
                                            normal: {
                                                color: '#ea6f21',
                                                width: 5,
                                            },
                                        },
                                        tooltip: {
                                            show: true,
                                        },
                                        areaStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(
                                                    0,
                                                    0,
                                                    0,
                                                    1,
                                                    [{
                                                        offset: 0,
                                                        color: 'rgba(236, 169, 44, 1)',
                                                    },
                                                    {
                                                        offset: 1,
                                                        color: 'rgba(236, 169, 44,0)',
                                                    },
                                                    ],
                                                    true
                                                ),
                                            },
                                        },
                                        data: seriesData,
                                        markLine: {
                                            symbol: ['none', 'none'], //去掉箭头
                                            itemStyle: {
                                                normal: {
                                                    lineStyle: {
                                                        type: 'dashed',
                                                        color: '#ccc',
                                                        width: 2
                                                    }
                                                },
                                            },

                                        },   itemStyle : { normal: {label : {show: true}}}
                                    },],
                                };

                                op2.setOption(option);

                            }





                        }
                    })
                });
    </script>


    <script>
        $('.priceList').on('click', function (e) {
            var target = $(event.target); //此处就是可以查看是那个点击的jQ对象
            if (target.text().trim() == "本周") {
                    document.getElementById("SinceOperation").style.background = "";
                 document.getElementById("week").style.background = "#F3BA0E";
            document.getElementById("month").style.background = "";
             document.getElementById("year").style.background = "";
                var data1 = getStartDayOfWeek();
                $.ajax({
                    url: "FaultStatistics.aspx?action=GetData1",

                    dataType: "json",
                    data: {
                        data1: data1,


                    },
                    type: "POST",
                    success: function (data) {
                        console.log(data);
                        var res = data;
                        console.log(data)
                        console.log(res.dt1);
                        var da = new Array();
                        var Num = [];
                        for (var i in res.dt1) {
                            console.log(res.dt1[i].Num)
                            da.push(res.dt1[i].StationOName)
                            var week1 = echarts.init(document.getElementById('d1'));
                            var datacolor = da;
                            Num.push(res.dt1[i].Num)

                            option1 = {
                                title: {
                                    text: '站点故障频率排行',

                                },
                                tooltip: {
                                    trigger: 'axis',
                                    axisPointer: {
                                        type: 'shadow'
                                    }
                                },

                                grid: {
                                    left: '15%',

                                },
                                xAxis: {
                                    type: 'value',
                                    boundaryGap: [0, 0.01]
                                },
                                yAxis: {
                                    type: 'category',
                                    data: datacolor
                                },
                                series: [
                                    {

                                        type: 'bar',
                                        data: Num
                                    }
                                ]
                            };

                            week1.setOption(option1);

                        }
                        //故障总数
                        var res = data;
                        console.log(data)
                        console.log(res.dt2);
                        var da = new Array();
                        var Num = [];
                        for (var i in res.dt2) {
                            console.log(res.dt2[i].Num)
                            da.push(res.dt2[i].Datayear)
                            var op2 = echarts.init(document.getElementById('d2'));
                            var datacolor = da;
                            Num.push(res.dt2[i].Num)

                            let pointStyle = {
                                borderColor: '#ea6f21',
                                color: '#fff',
                                borderWidth: 2,
                            }
                            let labelStyle = {
                                show: true,
                                position: 'top',
                                lineHeight: 20,
                                borderRadius: 5,
                                backgroundColor: 'rgba(255,255,255,.9)',
                                borderColor: '#ccc',
                                borderWidth: '1',
                                padding: [5, 15, 4],
                                color: '#000000',
                                fontSize: 14,
                                fontWeight: 'normal',
                            }
                            let total = Num
                            let seriesData = []
                            total = total.sort(function (a, b) {
                                return a - b
                            })
                            total.forEach((item, index) => {
                                let ob = {
                                    value: item,
                                    itemStyle: pointStyle,
                                    label: labelStyle,
                                }
                                if (index === total.length - 1) {
                                    ob.itemStyle = {
                                        borderColor: '#ea6f21',
                                        color: '#ea6f21',
                                        borderWidth: 3,
                                    }
                                    ob.label = {
                                        show: true,
                                        position: 'top',
                                        lineHeight: 20,
                                        backgroundColor: '#ea6f21',
                                        borderRadius: 5,
                                        borderColor: '#ea6f21',
                                        borderWidth: '1',
                                        padding: [5, 15, 4],
                                        color: '#fff',
                                        fontSize: 14,
                                        fontWeight: 'normal',
                                    }
                                }
                                seriesData.push(ob)
                            })

                            option = {
                                title: {
                                    text: '站点故障总数',
                                    left: 'left',
                                },
                                grid: {
                                    top: '15%',
                                    left: '15%',
                                    right: '8%',
                                    bottom: '15%',
                                },
                                xAxis: [{
                                    type: 'category',
                                    axisTick: {
                                        show: false,
                                    },

                                    splitLine: {
                                        show: true,
                                        lineStyle: {
                                            type: 'dashed',
                                        },
                                    },
                                    data: da,
                                },],

                                yAxis: [{
                                    type: 'value',
                                    min: 0,
                                    max: 100,
                                    splitNumber: 3,
                                    axisLine: {
                                        show: false,
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: true,
                                        lineStyle: {
                                            type: 'dashed',
                                        },
                                    },
                                },],
                                series: [{
                                    type: 'line',
                                    showAllSymbol: true,
                                    symbol: 'circle',
                                    symbolSize: 10,
                                    lineStyle: {
                                        normal: {
                                            color: '#ea6f21',
                                            width: 5,
                                        },
                                    },
                                    tooltip: {
                                        show: false,
                                    },
                                    areaStyle: {
                                        normal: {
                                            color: new echarts.graphic.LinearGradient(
                                                0,
                                                0,
                                                0,
                                                1,
                                                [{
                                                    offset: 0,
                                                    color: 'rgba(236, 169, 44, 1)',
                                                },
                                                {
                                                    offset: 1,
                                                    color: 'rgba(236, 169, 44,0)',
                                                },
                                                ],
                                                false
                                            ),
                                        },
                                    },
                                    data: seriesData,
                                    markLine: {
                                        symbol: ['none', 'none'], //去掉箭头
                                        itemStyle: {
                                            normal: {
                                                lineStyle: {
                                                    type: 'dashed',
                                                    color: '#ccc',
                                                    width: 2
                                                }
                                            },
                                        },

                                    },itemStyle : { normal: {label : {show: true}}}
                                },],
                            };

                            op2.setOption(option);

                        }
                    }
                })
            }
            if (target.text().trim() == "本月") {
                        document.getElementById("SinceOperation").style.background = "";
                 document.getElementById("week").style.background = "";
            document.getElementById("month").style.background = "#F3BA0E";
             document.getElementById("year").style.background = "";
                var data1 = getStartDayOfMonth();
                $.ajax({
                    url: "FaultStatistics.aspx?action=GetData1",

                    dataType: "json",
                    data: {
                        data1: data1,


                    },
                    type: "POST",
                    success: function (data) {
                        console.log(data);
                        var res = data;
                        console.log(data)
                        console.log(res.dt1);
                        var da = new Array();
                        var Num = [];
                        for (var i in res.dt1) {
                            console.log(res.dt1[i].Num)
                            da.push(res.dt1[i].StationOName)
                            var week1 = echarts.init(document.getElementById('d1'));
                            var datacolor = da;
                            Num.push(res.dt1[i].Num)

                            option1 = {
                                title: {
                                    text: '站点故障频率排行',

                                },
                                tooltip: {
                                    trigger: 'axis',
                                    axisPointer: {
                                        type: 'shadow'
                                    }
                                },

                                grid: {
                                    left: '15%',

                                },
                                xAxis: {
                                    type: 'value',
                                    boundaryGap: [0, 0.01]
                                },
                                yAxis: {
                                    type: 'category',
                                    data: datacolor
                                },
                                series: [
                                    {

                                        type: 'bar',
                                        data: Num
                                    }
                                ]
                            };

                            week1.setOption(option1);

                        }
                        //故障总数
                        var res = data;
                        console.log(data)
                        console.log(res.dt2);
                        var da = new Array();
                        var Num = [];
                        for (var i in res.dt2) {
                            console.log(res.dt2[i].Num)
                            da.push(res.dt2[i].Datayear)
                            var op2 = echarts.init(document.getElementById('d2'));
                            var datacolor = da;
                            Num.push(res.dt2[i].Num)

                            let pointStyle = {
                                borderColor: '#ea6f21',
                                color: '#fff',
                                borderWidth: 2,
                            }
                            let labelStyle = {
                                show: true,
                                position: 'top',
                                lineHeight: 20,
                                borderRadius: 5,
                                backgroundColor: 'rgba(255,255,255,.9)',
                                borderColor: '#ccc',
                                borderWidth: '1',
                                padding: [5, 15, 4],
                                color: '#000000',
                                fontSize: 14,
                                fontWeight: 'normal',
                            }
                            let total = Num
                            let seriesData = []
                            total = total.sort(function (a, b) {
                                return a - b
                            })
                            total.forEach((item, index) => {
                                let ob = {
                                    value: item,
                                    itemStyle: pointStyle,
                                    label: labelStyle,
                                }
                                if (index === total.length - 1) {
                                    ob.itemStyle = {
                                        borderColor: '#ea6f21',
                                        color: '#ea6f21',
                                        borderWidth: 3,
                                    }
                                    ob.label = {
                                        show: true,
                                        position: 'top',
                                        lineHeight: 20,
                                        backgroundColor: '#ea6f21',
                                        borderRadius: 5,
                                        borderColor: '#ea6f21',
                                        borderWidth: '1',
                                        padding: [5, 15, 4],
                                        color: '#fff',
                                        fontSize: 14,
                                        fontWeight: 'normal',
                                    }
                                }
                                seriesData.push(ob)
                            })

                            option = {
                                title: {
                                    text: '站点故障总数',
                                    left: 'left',
                                },
                                grid: {
                                    top: '15%',
                                    left: '15%',
                                    right: '8%',
                                    bottom: '15%',
                                },
                                xAxis: [{
                                    type: 'category',
                                    axisTick: {
                                        show: false,
                                    },

                                    splitLine: {
                                        show: true,
                                        lineStyle: {
                                            type: 'dashed',
                                        },
                                    },
                                    data: da,
                                },],

                                yAxis: [{
                                    type: 'value',
                                    min: 0,
                                    max: 100,
                                    splitNumber: 3,
                                    axisLine: {
                                        show: false,
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: true,
                                        lineStyle: {
                                            type: 'dashed',
                                        },
                                    },
                                },],
                                series: [{
                                    type: 'line',
                                    showAllSymbol: true,
                                    symbol: 'circle',
                                    symbolSize: 10,
                                    lineStyle: {
                                        normal: {
                                            color: '#ea6f21',
                                            width: 5,
                                        },
                                    },
                                    tooltip: {
                                        show: false,
                                    },
                                    areaStyle: {
                                        normal: {
                                            color: new echarts.graphic.LinearGradient(
                                                0,
                                                0,
                                                0,
                                                1,
                                                [{
                                                    offset: 0,
                                                    color: 'rgba(236, 169, 44, 1)',
                                                },
                                                {
                                                    offset: 1,
                                                    color: 'rgba(236, 169, 44,0)',
                                                },
                                                ],
                                                false
                                            ),
                                        },
                                    },
                                    data: seriesData,
                                    markLine: {
                                        symbol: ['none', 'none'], //去掉箭头
                                        itemStyle: {
                                            normal: {
                                                lineStyle: {
                                                    type: 'dashed',
                                                    color: '#ccc',
                                                    width: 2
                                                }
                                            },
                                        },

                                    },itemStyle : { normal: {label : {show: true}}}
                                },],
                            };

                            op2.setOption(option);

                        }
                    }
                })
            }
            if (target.text().trim() == "今年") {
                
                 document.getElementById("SinceOperation").style.background = "";
                 document.getElementById("week").style.background = "";
            document.getElementById("month").style.background = "";
             document.getElementById("year").style.background = "#F3BA0E";
                var currentYear = now.getFullYear();//获得当前年份4位年

                var data1 = currentYear + "-1-1 0:00:00";
                $.ajax({
                    url: "FaultStatistics.aspx?action=GetData1",

                    dataType: "json",
                    data: {
                        data1: data1,


                    },
                    type: "POST",
                    success: function (data) {
                        console.log(data);
                        var res = data;
                        console.log(data)
                        console.log(res.dt1);
                        var da = new Array();
                        var Num = [];
                        for (var i in res.dt1) {
                            console.log(res.dt1[i].Num)
                            da.push(res.dt1[i].StationOName)
                            var week1 = echarts.init(document.getElementById('d1'));
                            var datacolor = da;
                            Num.push(res.dt1[i].Num)

                            option1 = {
                                title: {
                                    text: '站点故障频率排行',

                                },
                                tooltip: {
                                    trigger: 'axis',
                                    axisPointer: {
                                        type: 'shadow'
                                    }
                                },

                                grid: {
                                    left: '15%',

                                },
                                xAxis: {
                                    type: 'value',
                                    boundaryGap: [0, 0.01]
                                },
                                yAxis: {
                                    type: 'category',
                                    data: datacolor
                                },
                                series: [
                                    {

                                        type: 'bar',
                                        data: Num
                                    }
                                ]
                            };

                            week1.setOption(option1);

                        }
                        //故障总数
                        var res = data;
                        console.log(data)
                        console.log(res.dt2);
                        var da = new Array();
                        var Num = [];
                        for (var i in res.dt2) {
                            console.log(res.dt2[i].Num)
                            da.push(res.dt2[i].Datayear)
                            var op2 = echarts.init(document.getElementById('d2'));
                            var datacolor = da;
                            Num.push(res.dt2[i].Num)

                            let pointStyle = {
                                borderColor: '#ea6f21',
                                color: '#fff',
                                borderWidth: 2,
                            }
                            let labelStyle = {
                                show: true,
                                position: 'top',
                                lineHeight: 20,
                                borderRadius: 5,
                                backgroundColor: 'rgba(255,255,255,.9)',
                                borderColor: '#ccc',
                                borderWidth: '1',
                                padding: [5, 15, 4],
                                color: '#000000',
                                fontSize: 14,
                                fontWeight: 'normal',
                            }
                            let total = Num
                            let seriesData = []
                            total = total.sort(function (a, b) {
                                return a - b
                            })
                            total.forEach((item, index) => {
                                let ob = {
                                    value: item,
                                    itemStyle: pointStyle,
                                    label: labelStyle,
                                }
                                if (index === total.length - 1) {
                                    ob.itemStyle = {
                                        borderColor: '#ea6f21',
                                        color: '#ea6f21',
                                        borderWidth: 3,
                                    }
                                    ob.label = {
                                        show: true,
                                        position: 'top',
                                        lineHeight: 20,
                                        backgroundColor: '#ea6f21',
                                        borderRadius: 5,
                                        borderColor: '#ea6f21',
                                        borderWidth: '1',
                                        padding: [5, 15, 4],
                                        color: '#fff',
                                        fontSize: 14,
                                        fontWeight: 'normal',
                                    }
                                }
                                seriesData.push(ob)
                            })

                            option = {
                                title: {
                                    text: '站点故障总数',
                                    left: 'left',
                                },
                                grid: {
                                    top: '15%',
                                    left: '15%',
                                    right: '8%',
                                    bottom: '15%',
                                },
                                xAxis: [{
                                    type: 'category',
                                    axisTick: {
                                        show: false,
                                    },

                                    splitLine: {
                                        show: true,
                                        lineStyle: {
                                            type: 'dashed',
                                        },
                                    },
                                    data: da,
                                },],

                                yAxis: [{
                                    type: 'value',
                                    min: 0,
                                    max: 100,
                                    splitNumber: 3,
                                    axisLine: {
                                        show: false,
                                    },
                                    axisTick: {
                                        show: false,
                                    },
                                    splitLine: {
                                        show: true,
                                        lineStyle: {
                                            type: 'dashed',
                                        },
                                    },
                                },],
                                series: [{
                                    type: 'line',
                                    showAllSymbol: true,
                                    symbol: 'circle',
                                    symbolSize: 10,
                                    lineStyle: {
                                        normal: {
                                            color: '#ea6f21',
                                            width: 5,
                                        },
                                    },
                                    tooltip: {
                                        show: false,
                                    },
                                    areaStyle: {
                                        normal: {
                                            color: new echarts.graphic.LinearGradient(
                                                0,
                                                0,
                                                0,
                                                1,
                                                [{
                                                    offset: 0,
                                                    color: 'rgba(236, 169, 44, 1)',
                                                },
                                                {
                                                    offset: 1,
                                                    color: 'rgba(236, 169, 44,0)',
                                                },
                                                ],
                                                false
                                            ),
                                        },
                                    },
                                    data: seriesData,
                                    markLine: {
                                        symbol: ['none', 'none'], //去掉箭头
                                        itemStyle: {
                                            normal: {
                                                lineStyle: {
                                                    type: 'dashed',
                                                    color: '#ccc',
                                                    width: 2
                                                }
                                            },
                                        },

                                    },itemStyle : { normal: {label : {show: true}}}
                                },],
                            };

                            op2.setOption(option);

                        }
                    }
                })
            }
            if (target.text().trim() == "运行以来") {
         
                 document.getElementById("SinceOperation").style.background = "#F3BA0E";
                 document.getElementById("week").style.background = "";
            document.getElementById("month").style.background = "";
             document.getElementById("year").style.background = "";
                $(function () {
                    var v1 = [];
                    var Rname = '123';
                    $.ajax({
                        url: "FaultStatistics.aspx/lodaa1",
                        contentType: "application/json; charset=utf-8",
                        data: "{t:'" + Rname + "'}",
                        type: "Post",
                        dataType: "json",
                        success: function (data) {
                            var res = JSON.parse(data.d);
                            console.log(data)
                            console.log(res.dt1);
                            var da = new Array();
                            var Num = [];
                            for (var i in res.dt1) {
                                console.log(res.dt1[i].Num)
                                da.push(res.dt1[i].StationOName)
                                var op1 = echarts.init(document.getElementById('d1'));
                                var datacolor = da;
                                Num.push(res.dt1[i].Num)

                                option = {
                                    title: {
                                        text: '站点故障频率排行',

                                    },
                                    tooltip: {
                                        trigger: 'axis',
                                        axisPointer: {
                                            type: 'shadow'
                                        }
                                    },

                                    grid: {
                                        left: '15%',

                                    },
                                    // visualMap: {
                                    //     orient: 'horizontal',
                                    //     left: 'center',
                                    //     min: 10,
                                    //     max: 200000,
                                    //     text: ['High', 'Low'],
                                    //     // Map the score column to color
                                    //     dimension: 0,
                                    //     inRange: {
                                    //         color: ['#D7DA8B', '#E15457']
                                    //     }
                                    // },
                                    xAxis: {
                                        type: 'value',
                                        boundaryGap: [0, 0.01]
                                    },
                                    yAxis: {
                                        type: 'category',
                                        data: datacolor
                                    },
                                    series: [
                                        {

                                            type: 'bar',
                                            data: Num
                                        }
                                    ]
                                };

                                op1.setOption(option);

                            }





                        }
                    })
                });
                $(function () {
                    var v1 = [];
                    var Rname = '123';
                    $.ajax({
                        url: "FaultStatistics.aspx/lodaa2",
                        contentType: "application/json; charset=utf-8",
                        data: "{t:'" + Rname + "'}",
                        type: "Post",
                        dataType: "json",
                        success: function (data) {
                            var res = JSON.parse(data.d);
                            console.log(data)
                            console.log(res.dt2);
                            var da = new Array();
                            var Num = [];
                            for (var i in res.dt2) {
                                console.log(res.dt2[i].Num)
                                da.push(res.dt2[i].Datayear)
                                var op2 = echarts.init(document.getElementById('d2'));
                                var datacolor = da;
                                Num.push(res.dt2[i].Num)

                                let pointStyle = {
                                    borderColor: '#ea6f21',
                                    color: '#fff',
                                    borderWidth: 2,
                                }
                                let labelStyle = {
                                    show: true,
                                    position: 'top',
                                    lineHeight: 20,
                                    borderRadius: 5,
                                    backgroundColor: 'rgba(255,255,255,.9)',
                                    borderColor: '#ccc',
                                    borderWidth: '1',
                                    padding: [5, 15, 4],
                                    color: '#000000',
                                    fontSize: 14,
                                    fontWeight: 'normal',
                                }
                                let total = Num
                                let seriesData = []
                                total = total.sort(function (a, b) {
                                    return a - b
                                })
                                total.forEach((item, index) => {
                                    let ob = {
                                        value: item,
                                        itemStyle: pointStyle,
                                        label: labelStyle,
                                    }
                                    if (index === total.length - 1) {
                                        ob.itemStyle = {
                                            borderColor: '#ea6f21',
                                            color: '#ea6f21',
                                            borderWidth: 3,
                                        }
                                        ob.label = {
                                            show: true,
                                            position: 'top',
                                            lineHeight: 20,
                                            backgroundColor: '#ea6f21',
                                            borderRadius: 5,
                                            borderColor: '#ea6f21',
                                            borderWidth: '1',
                                            padding: [5, 15, 4],
                                            color: '#fff',
                                            fontSize: 14,
                                            fontWeight: 'normal',
                                        }
                                    }
                                    seriesData.push(ob)
                                })

                                option = {
                                    title: {
                                        text: '站点故障总数',
                                        left: 'left',
                                    },
                                    grid: {
                                        top: '15%',
                                        left: '15%',
                                        right: '8%',
                                        bottom: '15%',
                                    },
                                    xAxis: [{
                                        type: 'category',
                                        axisTick: {
                                            show: false,
                                        },

                                        splitLine: {
                                            show: true,
                                            lineStyle: {
                                                type: 'dashed',
                                            },
                                        },
                                        data: da,
                                    },],

                                    yAxis: [{
                                        type: 'value',
                                        min: 0,
                                        max: 100,
                                        splitNumber: 3,
                                        axisLine: {
                                            show: false,
                                        },
                                        axisTick: {
                                            show: false,
                                        },
                                        splitLine: {
                                            show: true,
                                            lineStyle: {
                                                type: 'dashed',
                                            },
                                        },
                                    },],
                                    series: [{
                                        type: 'line',
                                        showAllSymbol: true,
                                        symbol: 'circle',
                                        symbolSize: 10,
                                        lineStyle: {
                                            normal: {
                                                color: '#ea6f21',
                                                width: 5,
                                            },
                                        },
                                        tooltip: {
                                            show: false,
                                        },
                                        areaStyle: {
                                            normal: {
                                                color: new echarts.graphic.LinearGradient(
                                                    0,
                                                    0,
                                                    0,
                                                    1,
                                                    [{
                                                        offset: 0,
                                                        color: 'rgba(236, 169, 44, 1)',
                                                    },
                                                    {
                                                        offset: 1,
                                                        color: 'rgba(236, 169, 44,0)',
                                                    },
                                                    ],
                                                    false
                                                ),
                                            },
                                        },
                                        data: seriesData,
                                        markLine: {
                                            symbol: ['none', 'none'], //去掉箭头
                                            itemStyle: {
                                                normal: {
                                                    lineStyle: {
                                                        type: 'dashed',
                                                        color: '#ccc',
                                                        width: 2
                                                    }
                                                },
                                            },

                                        },itemStyle : { normal: {label : {show: true}}}
                                    },],
                                };

                                op2.setOption(option);

                            }





                        }
                    })
                });
            }
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
