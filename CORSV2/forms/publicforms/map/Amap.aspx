﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Amap.aspx.cs" Inherits="CORSV2.forms.publicforms.map.Amap" %>

<!DOCTYPE html>
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
	<style type="text/css">
		body, html {width: 100%;height: 100%;margin:0;font-family:"微软雅黑";}
		#allmap{width:85%;height:100%; float:right}
		p{margin-left:5px; font-size:14px;}
	</style>

    <!-- 自定义js -->
   <script src="../../../js/jquery-1.9.1.min.js"></script>
         <script type="text/javascript" src="http://api.map.baidu.com/api?v=3.0&ak=NTc0AWQ4t3xXGbO93gGyUiamjzduxI31"></script>
	<script type="text/javascript" src="//api.map.baidu.com/library/TextIconOverlay/1.2/src/TextIconOverlay_min.js"></script>
	<script type="text/javascript" src="//api.map.baidu.com/library/MarkerClusterer/1.2/src/MarkerClusterer_min.js"></script>
	<title>点聚合</title>
    <style>
      ul {
        padding: 10px;
        margin-left:80px;
       
        line-height: 20px;
       
        font-size: 12px;
       
       
        list-style: none;
    }
    ul :hover {
        cursor: pointer;
        background-color: #4c9fff;
    }

        
    </style>
</head>
<body>
    <div style="width:15%;height:100%;float:left" >
          <ul>
             <li>重庆市</li>


          </ul>
    </div>
	<div id="allmap" style="float:left"></div>
	
</body>
</html>

<script type="text/javascript">
	// 百度地图API功能
	var map = new BMap.Map("allmap");
	map.centerAndZoom(new BMap.Point(106.55774,29.566473), 8);
    map.enableScrollWheelZoom();
    $(function () {
        var v1 = [];
        var Rname = '123';
        $.ajax({
            url: "Amap.aspx/lodaa1",
            contentType: "application/json; charset=utf-8",
            data: "{t:'" + Rname + "'}",
            type: "Post",
            dataType: "json",
            success: function (data) {
                var res = JSON.parse(data.d);
                console.log(res.dt1);
                var markers = [];
                var pt = null

                for (var i = 0; i < res.dt1.length; i++) {
                    if (res.dt1[i].Lon != 0 && res.dt1[i].Lat != 0) {
                        console.log(res.dt1[i].Lon);
                        pt = new BMap.Point(res.dt1[i].Lon, res.dt1[i].Lat);

                        markers.push(new BMap.Marker(pt));
                        console.log(markers);
                          var markerClusterer = new BMapLib.MarkerClusterer(map, { markers: markers });
                    }
                }
                //最简单的用法，生成一个marker数组，然后调用markerClusterer类即可。
              
            }
        });
    })
    


</script>