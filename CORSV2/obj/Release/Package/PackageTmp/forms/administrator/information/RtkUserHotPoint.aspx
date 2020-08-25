<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RtkUserHotPoint.aspx.cs" Inherits="CORSV2.forms.administrator.information.RtkUserHotPoint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <meta name="renderer" content="webkit|ie-comp|ie-stand">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">

    <link href="../../../themes/css/plugins/iCheck/custom.css" rel="stylesheet">

    <link href="../../../themes/css/plugins/fullcalendar/fullcalendar.css" rel="stylesheet">
    <link href="../../../themes/css/plugins/fullcalendar/fullcalendar.print.css" rel="stylesheet">
      <style>
        .form-control,
        .single-line {
            background-color: #FFFFFF;
            background-image: none;
            border: 1px solid #e5e6e7;
            border-radius: 1px;
            color: inherit;
            display: inline;
            padding: 6px 12px;
            -webkit-transition: border-color 0.15s ease-in-out 0s, box-shadow 0.15s ease-in-out 0s;
            transition: border-color 0.15s ease-in-out 0s, box-shadow 0.15s ease-in-out 0s;
            width: 60%;
            font-size: 14px;
        }

            .form-control:focus,
            .single-line:focus {
                border-color: #1c84c6 !important;
            }
    </style>
    <style type="text/css">
        #allmap {
            width: 100%;
            height: 500px;
            margin: 0;
            font-family: "微软雅黑";
            background-color: #fff;
            color: #101010;
        }
    </style>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=CKeZG8pGDGrA4VUvVRpHIQSHnIK9l32l"></script>
    <title>热点图</title>
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content">
        <div class="row animated fadeInDown">
            <div class="col-sm-3" style="width:300px">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>时间选择</h5>

                    </div>
                    <div class="ibox-content">
                        <form runat="server">
                            <div class="form-group">
                                <label >开始：</label>

                                <input id="sd" runat="server" class="form-control layer-date"  placeholder="YYYY-MM-DD hh:mm:ss" onclick="laydate({ istime: true, format: 'YYYY-MM-DD hh:mm:ss' })">
                                <label class="laydate-icon"></label>

                            </div>
                            <div class="form-group">
                                <label>结束：</label>

                                <input id="ed" runat="server" class="form-control layer-date"  placeholder="YYYY-MM-DD hh:mm:ss" onclick="laydate({ istime: true, format: 'YYYY-MM-DD hh:mm:ss' })">
                                <label class="laydate-icon"></label>

                            </div>

                            <div style="padding-left:100px">
                                <asp:Button ID="Button1" runat="server" Text="确定" CssClass="btn btn-success"  OnClick="Button1_Click1" />
                            </div>
                        </form>

                    </div>
                </div>
                <div class="ibox float-e-margins">
                    <div class="ibox-content">
                        <h2>热点现象</h2>
                        这是一个用于分析一段时间内的用户作业分布，用于城市建设与测绘关系的大数据分析
                       
                        <p>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-sm-9" style="width:76%;padding-right:4px">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>地图显示</h5>

                    </div>
                    <div class="ibox-content">
                        <div id="allmap"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!-- 全局js -->
    <script src="../../../js/jquery.min.js?v=2.1.4"></script>
    <script src="../../../js/bootstrap.min.js?v=3.3.6"></script>



    <!-- 自定义js -->
    <script src="../../../js/content.js?v=1.0.0"></script>


    <script src="../../../js/jquery-ui.custom.min.js"></script>

    <!-- iCheck -->
    <script src="../../../js/plugins/iCheck/icheck.min.js"></script>

    <!-- Full Calendar -->
    <script src="../../../js/plugins/fullcalendar/fullcalendar.min.js"></script>

</body>

<!-- 全局js -->

<script src="../../../js/jquery.min.js?v=2.1.4"></script>
<script src="../../../js/bootstrap.min.js?v=3.3.6"></script>



<!-- 自定义js -->
<script src="../../../js/content.js?v=1.0.0"></script>


<!-- layerDate plugin javascript -->
<script src="../../../js/plugins/layer/laydate/laydate.js"></script>
<script>
    //外部js调用
    laydate({
        elem: '#hello', //目标元素。由于laydate.js封装了一个轻量级的选择器引擎，因此elem还允许你传入class、tag但必须按照这种方式 '#id .class'
        event: 'focus' //响应事件。如果没有传入event，则按照默认的click
    });

    //日期范围限制
    var start = {
        elem: '#start',
        format: 'YYYY/MM/DD hh:mm:ss',
        min: laydate.now(), //设定最小日期为当前日期
        max: '2099-06-16 23:59:59', //最大日期
        istime: true,
        istoday: false,
        choose: function (datas) {
            end.min = datas; //开始日选好后，重置结束日的最小日期
            end.start = datas //将结束日的初始值设定为开始日
        }
    };
    var end = {
        elem: '#end',
        format: 'YYYY/MM/DD hh:mm:ss',
        min: laydate.now(),
        max: '2099-06-16 23:59:59',
        istime: true,
        istoday: false,
        choose: function (datas) {
            start.max = datas; //结束日选好后，重置开始日的最大日期
        }
    };
    laydate(start);
    laydate(end);
    </script>

<script type="text/javascript">
    // 百度地图API功能  
    var map = new BMap.Map("allmap", { minZoom: 7 });// 创建Map实例 最小级别7
    map.centerAndZoom(new BMap.Point(106.33, 29.35), 11);  // 初始化地图,设置中心点坐标和地图级别
    map.addControl(new BMap.MapTypeControl());   //添加地图类型控件
    map.setCurrentCity("重庆");          // 设置地图显示的城市 此项是必须设置的
    map.enableScrollWheelZoom(true);     //开启鼠标滚轮缩放
    var hotpointlat = '<%=hotpointlat%>';
    var hotpointlats = new Array();
    hotpointlats = hotpointlat.split(',');
    var hotpointlon = '<%=hotpointlon%>';
    var hotpointlons = new Array();
    hotpointlons = hotpointlon.split(',');
    if (document.createElement('canvas').getContext) {  // 判断当前浏览器是否支持绘制海量点
        var points = [];  // 添加海量点数据
        for (var i = 0; i < hotpointlats.length; i++) {
            points.push(new BMap.Point(hotpointlons[i], hotpointlats[i]));
        }
        var options = {
            size: BMAP_POINT_SIZE_SMALL,
            shape: BMAP_POINT_SHAPE_STAR,
            color: '#d340c3'
        }
        var pointCollection = new BMap.PointCollection(points, options);  // 初始化PointCollection
        //pointCollection.addEventListener('click', function (e) {
        //    alert('单击点的坐标为：' + e.point.lng + ',' + e.point.lat);  // 监听点击事件
        //});
        map.addOverlay(pointCollection);  // 添加Overlay
    } else {
        alert('请在chrome、safari、IE8+以上浏览器查看');
    }
</script>
