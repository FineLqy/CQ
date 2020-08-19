<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RtkSurveyMonitoring.aspx.cs" Inherits="CORSV2.forms.administrator.information.RtkSurveyMonitoring" %>

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
    <link href="../../../themes/css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
    <link href="../../../themes/css/plugins/fullcalendar/fullcalendar.css" rel="stylesheet">
    <link href="../../../themes/css/plugins/fullcalendar/fullcalendar.print.css" rel="stylesheet">

    <style type="text/css">
        #mapDiv {
            width: 100%;
            height: 500px;
            margin: 0;
            font-family: "微软雅黑";
            background-color: #fff;
            color: #101010;
        }

        .label-info {
            font-size: 20px;
            margin-left: 10px;
                display: inline-block;
    padding: 6px 12px;
        }

        .pull-right {
            width: 30%;
        }

        #type {
            width: 40%;
        }
    </style>
    <script src="../../../js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="http://api.tianditu.gov.cn/api?v=3.0&tk=898f3541e6c196c9a634710017691f6d"></script>
    <title>实时监控-天地图</title>
</head>
<body class="gray-bg" onload="onLoad()">
    <div class="wrapper wrapper-content">
        <div class="row animated fadeInDown">
            <div class="col-sm-9" style="width: 100%">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>地图显示</h5>

                    </div>
                    <div class="ibox-content">
                        <div id="mapDiv"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row animated fadeInDown">
            <div class="col-sm-9" style="width: 100%;">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>在线CORS用户列表</h5>

                    </div>
                    <div class="ibox-content">
                        <%-- 工具栏 --%>
                        <div class="bars pull-left">
                            <div class="btn-group hidden-xs" id="toolbar" style="width: 100%" role="group">
                                <button type="button" id="disconnect" class="btn btn-outline btn-default">
                                    <i class="glyphicon glyphicon-remove" aria-hidden="true"></i>断开连接
                                </button>
                                <label class="label label-info" id="Allusercount">总用户数:<%=userCount %></label>
                                <label class="label label-info" id="Allrate">总固定率:<%=rate %></label>
                            </div>
                        </div>
                        <div class="bars pull-right form-horizontal">
                            <div class="form-group">
                                <select class="form-control col-sm-1" id="type" style="width:30%" onchange="GetUR();">
                                    <option value="RTCM31">RTCM3</option>
                                    <option value="test">RTCM2</option>
                                    <option value="121">RTCM2</option>
                                    <option value="123">RTCM2</option>
                                    <option value="12">RTCM2</option>
                                </select>
                                <label class="label label-info" id="usercount">用户数:0</label>
                                <label class="label label-info" id="rate">固定率:0%</label>
                            </div>
                        </div>
                        <table id="table"
                            data-search="false"
                            data-search-text=""
                            data-toolbar="#toolbar"
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
                            data-url="yhzyjc.aspx?action=GetData"
                            data-smart-display="false">
                            <thead>
                                <tr>
                                    <th data-checkbox="true"></th>
                                    <th data-field="UserName">CORS在线账号</th>
                                    <th data-field="Company">单位</th>
                                    <th data-field="Status">状态</th>
                                    <th data-field="OnlineSpan">在线时长</th>
                                    <th data-field="UseStarts">使用卫星数</th>
                                    <th data-field="Source">接入源</th>
                                    <th data-field="LoginTime">登陆时间</th>
                                </tr>
                            </thead>

                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!-- 全局js -->
    <script src="../../../js/jquery.min.js?v=2.1.4"></script>
    <script src="../../../js/bootstrap.min.js?v=3.3.6"></script>

    <script src="../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>


    <script>
        $(document).ready(function () {
            var table = $("#table");
            table.bootstrapTable();
        });
    </script>
</body>

<!-- 全局js -->




</html>
<script type="text/javascript">
    var table = $("#table");
    var map, zoom = 10;
    var data;

    function LoadUsers() {
        $.post(
        "../../functions/GetOnlineUserDt.aspx",
        {
            q: "get"
        },
        function (data) {
            var datas = data.split("<");
            var datass = datas[0].split("?");
            for (var i = 0; i < datass.length; i++) {
                var pL = datass[3 * i];
                var pB = datass[3 * i + 1];

                var fix = datass[3 * i + 2].indexOf("固定");
                var fixed = 1;
                if (fix < 0) {
                    fixed = 0;
                }
                var point = new TLngLat(pL, pB);
                addMark(point, i, fixed);
            }
            function addMark(mypoint, index, fixed) {
                //        mypoint = new TLngLat(111.6648, 40.8234);

                var tempStr = datass[3 * index + 2];
                if (tempStr == null) {
                    return;
                }
                var UserName = tempStr.split(":")[0];
                var icon = new TIcon("http://api.tianditu.com/img/map/marker.png");
                if (fixed == 1) {
                    icon = new TIcon("../../../themes/icon/fixmarker.png")
                }

                var marker = new TMarker(mypoint, { icon: icon });
                map.addOverLay(marker);
                var config = {
                    text: UserName,
                    offset: new TPixel(0, 0),
                    position: mypoint
                };
                var label = new TLabel(config);
                map.addOverLay(label);

                var info_opts = {
                    width: 100,
                    height: 20,
                    title: UserName
                }
                var info_win = new TInfoWindow(mypoint, { opts: info_opts });
                info_win.setLabel(datass[3 * index + 2]);
                markerclk = TEvent.addListener(marker, "click", function (p) { map.addOverLay(info_win) });
            }
        }
        );
    }
    function timer() {
        map.clearOverLays();
        LoadUsers();
        table.bootstrapTable('refresh');
        GetType();
        GetAUR();
        setTimeout('timer()', 15000);
    }
    function onLoad() {
        var controlCss = "TMAP_NAVIGATION_CONTROL_LARGE";
        var map_config = {
            projection: "EPSG:900913"
        };
        var ctl_config = {
            type: controlCss
        };
        ovSize = new TSize(250, 130);
        var ov_config = {
            anchor: "TMAP_ANCHOR_TOP_RIGHT",
            size: ovSize,
            isOpen: true
        };


        pHHHT = new TLngLat(106.33, 29.35);
        map = new TMap("mapDiv", map_config);
        NavCtrl = new TNavigationControl(ctl_config);
        //OVCtrl = new TOverviewMapControl(ov_config); map.addControl(OVCtrl);
        map.enableDoubleClickZoom();

        //        map.addControl(NavCtrl);
        //        var mk = new TMarker(new TLngLat(114.35726516, 30.5316517), {icon:new TIcon("http://api.tianditu.com/img/map/marker.png")});
        //        map.addOverLay(mk)
        map.enableHandleMouseScroll();
        map.centerAndZoom(pHHHT, zoom);

        //创建地图类型控件对象 
        var control = new TMapTypeControl();
        //将地图类型控件添加到地图上 
        map.addControl(control);
        //    map.setMapType(TMAP_SATELLITE_MAP);

        //datas = "114.35726516?30.5316517?你好我是武汉?118?39.2?你好我是唐山";
        //datass = datas.split("?");
        //for (var i = 0; i < datass.length; i++) {
        //    var pL = datass[3 * i];
        //    var pB = datass[3 * i + 1];
        //    var point = new TLngLat(pL, pB);
        //    addMark(point, i);
        //}
        timer();
    }

    function GetUR() {
        $.ajax({
            url: "?action=GetUF",
            type: "post",
            data: $("#type").val(),
            success: function (dt) {
                var data = JSON.parse(dt);
                $("#usercount").text("用户数:" + data["UserCount"]);
                $("#rate").text("固定率:" + data["FixedRate"]);
            }
        });
    }
    function GetAUR() {
        $.ajax({
            url: "?action=GetAF",
            type: "post",
            success: function (dt) {
                var data = new Array();
                data = dt.split('_');
                $("#Allusercount").text("总用户数:" + data[0]);
                $("#Allrate").text("总固定率:" + data[1]);
            }
        });
    }
    GetType();
    function GetType() {
        $.ajax({
            url: "?action=GetType",
            type: "post",
            success: function (dt) {
                var data = JSON.parse(dt);
                $("#type").empty();
                $.each(data, function (i, item) {
                    $("#type").append($("<option></option>")
                    .attr("value", item["Source"])
                    .text(item["SourceType"]));
                });

                GetUR();
            }
        });
    }

    function getIdSelections() {
        return $.map(table.bootstrapTable('getSelections'), function (row) {
            return row.UserName
        });
    }
    $("#disconnect").on('click', function () {
        var users = getIdSelections();
        if (users.length < 1) {
            alert("请选择用户");
            return;
        }
        $.ajax({
            url: "?action=disconnect",
            type: "post",
            data: { users: users },
            success: function (data) {
                alert("已断开连接！");
                table.bootstrapTable('refresh');
            }
        });
        $("#disconnect").blur();
    });
</script>


