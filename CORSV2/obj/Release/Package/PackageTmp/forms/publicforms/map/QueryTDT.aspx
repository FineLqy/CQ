<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryTDT.aspx.cs" Inherits="CORSV2.forms.publicforms.map.QueryTDT" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="content-type" content="text/html; charset=utf-8"/>
    <title>加载天地图</title>
    <script type="text/javascript" src="http://api.tianditu.gov.cn/api?v=4.0&tk=898f3541e6c196c9a634710017691f6d"></script>
    <script src="../../../js/jquery-1.9.1.min.js"></script>
    <style type="text/css">body,html{width:100%;height:100%;margin:0;font-family:"Microsoft YaHei"}#mapDiv{width:100%;height:100%}input,b,p{margin-left:5px;font-size:14px}</style>
    <script>
        var map;
        var zoom = 10;
        function onLoad() {
            map = new T.Map('mapDiv', {
                projection: 'EPSG:4326'
            });
        
            map.centerAndZoom(new T.LngLat(113.65, 34.76), zoom);
            //允许鼠标滚轮缩放地图
            map.enableScrollWheelZoom();
            AddStations();
        
        }


        function AddStations() {
            $.ajax({
                type: "POST",
                url: "?action=loadsta",
                success: function (result) {
                    var obj = eval(result);
                    for (var i = 0; i < obj.length; i++) {
                        addMarker(obj[i].L, obj[i].B, obj[i].IsOK, obj[i].StationName, obj[i].OperatingState)
                    }

                }
            })
        }

        function AddLines() {
            $.ajax({
                type: "POST",
                url: "?action=loaddelaynay",
                success: function (data) {

                    addline(data)
                }
            })
        }

        function addline(result) {

            var obj = eval(result);
            for (var i = 0; i < obj.length; i++) {
                var points = [];
                points.push(new T.LngLat(obj[i].spL, obj[i].spB));
                points.push(new T.LngLat(obj[i].epL, obj[i].epB));
                //创建线对象
                var line = new T.Polyline(points, { color: "blue", weight: 1, opacity: 1 });
                //向地图上添加线
                map.addOverLay(line);
            }

        }
        function addMarker(lon, lat, isbroken, name, OperatingState) {
            var icon;
            if (isbroken == "0") {

                icon = new T.Icon({
                    iconUrl: "../../../themes/icon/broken.png",
                    iconSize: new T.Point(15, 15),

                });

            }
            else {

                icon = new T.Icon({
                    iconUrl: "../../../themes/icon/nomal.png",
                    iconSize: new T.Point(15, 15),

                });

            }

            var marker = new T.Marker(new T.LngLat(lon, lat), { icon: icon });
            //向地图上添加标注
            map.addOverLay(marker);

            var markerInfoWin = new T.InfoWindow("基站名：" + name + "<br/>经度：" + lon + "<br/>纬度：" + lat + "<br/>状态："
             + OperatingState);
              <%if (Session["UserName"] != null && Session["UserName"] != "")
                   {%>
            <%}%>
            <%else
                   {%>
             markerInfoWin = new T.InfoWindow("基站名：" + name );
             <%}%>
            //var markerInfoWin = new T.InfoWindow("基站名：" + name + "<br/>经度：" + lon + "<br/>纬度：" + lat + "<br/>状态："
            //    + OperatingState);
            marker.addEventListener("click", function () {
                marker.openInfoWindow(markerInfoWin);
            });// 将标注添加到地图中
            //注册 click 事件,触发 mouseClickHandler()方法
        }

    </script>
</head>
<body onLoad="onLoad()">
<div id="mapDiv"></div>
</body>
</html>
