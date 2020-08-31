<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Amap.aspx.cs" Inherits="CORSV2.forms.publicforms.map.Amap" %>

<!DOCTYPE html>
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
	<style type="text/css">
		body, html {width: 100%;height: 100%;margin:0;font-family:"华文行楷";}
		#allmap{width:84%;height:100%; float:right}
		p{margin-left:5px; font-size:14px;}
	</style>

    <!-- 自定义js -->
   <script src="../../../js/jquery-1.9.1.min.js"></script>
         <script type="text/javascript" src="http://api.map.baidu.com/api?v=3.0&ak=NTc0AWQ4t3xXGbO93gGyUiamjzduxI31"></script>
	<script type="text/javascript" src="//api.map.baidu.com/library/TextIconOverlay/1.2/src/TextIconOverlay_min.js"></script>
	<script type="text/javascript" src="//api.map.baidu.com/library/MarkerClusterer/1.2/src/MarkerClusterer_min.js"></script>
    <link href="../../../themes/css/layui.css" rel="stylesheet" />
       <link href="../../../themes/css/bootstrap.min.css" rel="stylesheet" />
    
    <script src="../../../js/layui.js"></script>
   
    <link href="../../../themes/css/layui.css" rel="stylesheet" />
   
    <script src="../../../js/element.js"></script>
	<title>实时监控</title>
    <style>
      ul {
     
       
        line-height: 30px;
       
        font-size: 18px;
        text-align:center;
       
       
        list-style: none;
    }
    ul :hover {
        cursor: pointer;
        background-color: #e0dede;
    }
        li {
   
            display: block;
            border-bottom:1px solid #f4f1f1
        }

        
    </style>

    <style type="text/css">
			#warp{
	height: 370px;
	width: 90%;
	border: 2px solid #e0dede;
	overflow: hidden;
	margin: 10px 0 0 10px;
	position: relative;
			}
			  #box{
			  	height: 100%;
			  	overflow-x: hidden;  
                overflow-y: auto;
                margin-right: -17px;
                padding: 10px;
               
			  }
			p{
				height: 30px;
				border: 1px solid #eee;
				margin: 0;
				padding: 0;
			}
			#scrollBar{
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
			#scrollBar:hover{
	background-color: #000000;
}
		</style>
    <script src="setBar.js"></script>
    
<script>
			$(function(){
				
				setSrollBar()
			})
		</script>
    
    <style>
        #ul1 li {
            border-bottom:1px solid #e0dede;
        }
    </style>
</head>
<body>
    <div style="width:16%;height:100%;float:left" >
        <input type="text" style="width:150px;height:25px;margin: 10px 10px 0 10px;border:1px solid #d5d4d4"  /> 
        <button id="btnSelect" class="btn btn-success">查询</button>
      
           <ul id="text">
               <li class="text">渝中区</li>
               <li class="text">江北区</li>
               <li class="text">南岸区</li>
               <li class="text">九龙坡区</li>
               <li class="text">沙坪坝区</li>
               <li class="text">大渡口区</li>
               <li class="text">北碚区</li>
               <li class="text">渝北区</li>
               <li class="text">巴南区</li>
           </ul>
         

          <div id='warp'>
       <div id="box">
          <div class="layui-tab" style="width:70%" >
  <ul class="layui-tab-title"style="width:50%">
    <li id="online" class="layui-this">在线用户</li>
    <li id="offline">离线用户</li>
    
  </ul>
  <div class="layui-tab-content">
    <div id="on-line" class="layui-tab-item layui-show">
         <ul id="ul1" >
          
         </ul>
    </div>
    <div id="off-line" class="layui-tab-item">
         <ul id="ul2">
          
         </ul>
    </div>
    
  </div>
</div>
           </div>
            <div id="scrollBar" onselectstart="return false"></div>
            </div>
    </div>
    
  
	<div id="allmap" style="float:left"></div>
	
</body>
</html>


<script>
$('li').click(function(){
 
    if ($(this).text()=='渝中区') {
        var map = new BMap.Map("allmap");
	map.centerAndZoom(new BMap.Point(106.557117,29.570086), 15);
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
                    if (res.dt1[i].IsOnline==1) {
                        console.log(res.dt1[i].Lon);
                        pt = new BMap.Point(res.dt1[i].Lon, res.dt1[i].Lat);

                        markers.push(new BMap.Marker(pt));
                        console.log(markers);
                        var markerClusterer = new BMapLib.MarkerClusterer(map, { markers: markers });
                        var opts = {
	  position : pt,    // 指定文本标注所在的地理位置
	  offset   : new BMap.Size(-18, -5)    //设置文本偏移量
	}
	var label = new BMap.Label(res.dt1[i].UserName, opts);  // 创建文本标注对象
                        label.setStyle({
        border: "none",
		color : 'black',
		fontSize : '12px',
		height : '20px',
		lineHeight : '20px',
		fontFamily: '微软雅黑'
	});
	map.addOverlay(label);  
                    }
                }
                //最简单的用法，生成一个marker数组，然后调用markerClusterer类即可。
              
            }
        });
    })

    }
        if ($(this).text()=='江北区') {
        var map = new BMap.Map("allmap");
	map.centerAndZoom(new BMap.Point(106.580158,29.612137), 15);
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
                    if (res.dt1[i].IsOnline==1) {
                        console.log(res.dt1[i].Lon);
                        pt = new BMap.Point(res.dt1[i].Lon, res.dt1[i].Lat);

                        markers.push(new BMap.Marker(pt));
                        console.log(markers);
                        var markerClusterer = new BMapLib.MarkerClusterer(map, { markers: markers });
                        var opts = {
	  position : pt,    // 指定文本标注所在的地理位置
	  offset   : new BMap.Size(-18, -5)    //设置文本偏移量
	}
	var label = new BMap.Label(res.dt1[i].UserName, opts);  // 创建文本标注对象
                        label.setStyle({
        border: "none",
		color : 'black',
		fontSize : '12px',
		height : '20px',
		lineHeight : '20px',
		fontFamily: '微软雅黑'
	});
	map.addOverlay(label);  
                    }
                }
                //最简单的用法，生成一个marker数组，然后调用markerClusterer类即可。
              
            }
        });
    })
    }
        if ($(this).text()=='南岸区') {
        var map = new BMap.Map("allmap");
	map.centerAndZoom(new BMap.Point(106.65098,29.507155), 15);
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
                    if (res.dt1[i].IsOnline==1) {
                        console.log(res.dt1[i].Lon);
                        pt = new BMap.Point(res.dt1[i].Lon, res.dt1[i].Lat);

                        markers.push(new BMap.Marker(pt));
                        console.log(markers);
                        var markerClusterer = new BMapLib.MarkerClusterer(map, { markers: markers });
                        var opts = {
	  position : pt,    // 指定文本标注所在的地理位置
	  offset   : new BMap.Size(-18, -5)    //设置文本偏移量
	}
	var label = new BMap.Label(res.dt1[i].UserName, opts);  // 创建文本标注对象
                        label.setStyle({
        border: "none",
		color : 'black',
		fontSize : '12px',
		height : '20px',
		lineHeight : '20px',
		fontFamily: '微软雅黑'
	});
	map.addOverlay(label);  
                    }
                }
                //最简单的用法，生成一个marker数组，然后调用markerClusterer类即可。
              
            }
        });
    })
    }
        if ($(this).text()=='九龙坡区') {
        var map = new BMap.Map("allmap");
	map.centerAndZoom(new BMap.Point(106.517209,29.507962), 15);
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
                    if (res.dt1[i].IsOnline==1) {
                        console.log(res.dt1[i].Lon);
                        pt = new BMap.Point(res.dt1[i].Lon, res.dt1[i].Lat);

                        markers.push(new BMap.Marker(pt));
                        console.log(markers);
                        var markerClusterer = new BMapLib.MarkerClusterer(map, { markers: markers });
                        var opts = {
	  position : pt,    // 指定文本标注所在的地理位置
	  offset   : new BMap.Size(-18, -5)    //设置文本偏移量
	}
	var label = new BMap.Label(res.dt1[i].UserName, opts);  // 创建文本标注对象
                        label.setStyle({
        border: "none",
		color : 'black',
		fontSize : '12px',
		height : '20px',
		lineHeight : '20px',
		fontFamily: '微软雅黑'
	});
	map.addOverlay(label);  
                    }
                }
                //最简单的用法，生成一个marker数组，然后调用markerClusterer类即可。
              
            }
        });
    })
    }
        if ($(this).text()=='沙坪坝区') {
        var map = new BMap.Map("allmap");
	map.centerAndZoom(new BMap.Point(106.463369,29.54724), 15);
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
                    if (res.dt1[i].IsOnline==1) {
                        console.log(res.dt1[i].Lon);
                        pt = new BMap.Point(res.dt1[i].Lon, res.dt1[i].Lat);

                        markers.push(new BMap.Marker(pt));
                        console.log(markers);
                        var markerClusterer = new BMapLib.MarkerClusterer(map, { markers: markers });
                        var opts = {
	  position : pt,    // 指定文本标注所在的地理位置
	  offset   : new BMap.Size(-18, -5)    //设置文本偏移量
	}
	var label = new BMap.Label(res.dt1[i].UserName, opts);  // 创建文本标注对象
                        label.setStyle({
        border: "none",
		color : 'black',
		fontSize : '12px',
		height : '20px',
		lineHeight : '20px',
		fontFamily: '微软雅黑'
	});
	map.addOverlay(label);  
                    }
                }
                //最简单的用法，生成一个marker数组，然后调用markerClusterer类即可。
              
            }
        });
    })
    }
        if ($(this).text()=='大渡口区') {
        var map = new BMap.Map("allmap");
	map.centerAndZoom(new BMap.Point(106.488922,29.490543), 15);
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
                    if (res.dt1[i].IsOnline==1) {
                        console.log(res.dt1[i].Lon);
                        pt = new BMap.Point(res.dt1[i].Lon, res.dt1[i].Lat);

                        markers.push(new BMap.Marker(pt));
                        console.log(markers);
                        var markerClusterer = new BMapLib.MarkerClusterer(map, { markers: markers });
                        var opts = {
	  position : pt,    // 指定文本标注所在的地理位置
	  offset   : new BMap.Size(-18, -5)    //设置文本偏移量
	}
	var label = new BMap.Label(res.dt1[i].UserName, opts);  // 创建文本标注对象
                        label.setStyle({
        border: "none",
		color : 'black',
		fontSize : '12px',
		height : '20px',
		lineHeight : '20px',
		fontFamily: '微软雅黑'
	});
	map.addOverlay(label);  
                    }
                }
                //最简单的用法，生成一个marker数组，然后调用markerClusterer类即可。
              
            }
        });
    })
    }
        if ($(this).text()=='北碚区') {
        var map = new BMap.Map("allmap");
	map.centerAndZoom(new BMap.Point(106.402055,29.810925), 15);
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
                    if (res.dt1[i].IsOnline==1) {
                        console.log(res.dt1[i].Lon);
                        pt = new BMap.Point(res.dt1[i].Lon, res.dt1[i].Lat);

                        markers.push(new BMap.Marker(pt));
                        console.log(markers);
                        var markerClusterer = new BMapLib.MarkerClusterer(map, { markers: markers });
                        var opts = {
	  position : pt,    // 指定文本标注所在的地理位置
	  offset   : new BMap.Size(-18, -5)    //设置文本偏移量
	}
	var label = new BMap.Label(res.dt1[i].UserName, opts);  // 创建文本标注对象
                        label.setStyle({
        border: "none",
		color : 'black',
		fontSize : '12px',
		height : '20px',
		lineHeight : '20px',
		fontFamily: '微软雅黑'
	});
	map.addOverlay(label);  
                    }
                }
                //最简单的用法，生成一个marker数组，然后调用markerClusterer类即可。
              
            }
        });
    })
    }
        if ($(this).text()=='渝北区') {
        var map = new BMap.Map("allmap");
	map.centerAndZoom(new BMap.Point(106.637632,29.723744), 15);
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
                    console.log(res.dt1[i].IsOnline)
                    if (res.dt1[i].IsOnline==0) {
                        console.log(res.dt1[i].Lon);
                        pt = new BMap.Point(res.dt1[i].Lon, res.dt1[i].Lat);

                        markers.push(new BMap.Marker(pt));
                        console.log(markers);
                        var markerClusterer = new BMapLib.MarkerClusterer(map, { markers: markers });
                        var opts = {
	  position : pt,    // 指定文本标注所在的地理位置
	  offset   : new BMap.Size(-18, -5)    //设置文本偏移量
	}
	var label = new BMap.Label(res.dt1[i].UserName, opts);  // 创建文本标注对象
                        label.setStyle({
        border: "none",
		color : 'black',
		fontSize : '12px',
		height : '20px',
		lineHeight : '20px',
		fontFamily: '微软雅黑'
	});
	map.addOverlay(label);  
                    }
                }
                //最简单的用法，生成一个marker数组，然后调用markerClusterer类即可。
              
            }
        });
    })
    }
        if ($(this).text()=='巴南区') {
        var map = new BMap.Map("allmap");
	map.centerAndZoom(new BMap.Point(106.546952,29.407837), 15);
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
                    if (res.dt1[i].IsOnline==1) {
                        console.log(res.dt1[i].Lon);
                        pt = new BMap.Point(res.dt1[i].Lon, res.dt1[i].Lat);

                        markers.push(new BMap.Marker(pt));
                        console.log(markers);
                        var markerClusterer = new BMapLib.MarkerClusterer(map, { markers: markers });
                        var opts = {
	  position : pt,    // 指定文本标注所在的地理位置
	  offset   : new BMap.Size(-18, -5)    //设置文本偏移量
	}
	var label = new BMap.Label(res.dt1[i].UserName, opts);  // 创建文本标注对象
                        label.setStyle({
        border: "none",
		color : 'black',
		fontSize : '12px',
		height : '20px',
		lineHeight : '20px',
		fontFamily: '微软雅黑'
	});
	map.addOverlay(label);  
                    }
                }
                //最简单的用法，生成一个marker数组，然后调用markerClusterer类即可。
              
            }
        });
    })
    }
   
});
</script>
<script type="text/javascript">
	// 百度地图API功能
	var map = new BMap.Map("allmap");
	map.centerAndZoom(new BMap.Point(106.55774,29.566473), 15);
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
                    if (res.dt1[i].IsOnline == 1) {
                        $("#ul1").append((res.dt1[i].UserName+"<div></div>"));
                        pt = new BMap.Point(res.dt1[i].Lon, res.dt1[i].Lat);

                        markers.push(new BMap.Marker(pt));
                        console.log(markers);
                        var markerClusterer = new BMapLib.MarkerClusterer(map, { markers: markers });

                        	var opts = {
	  position : pt,    // 指定文本标注所在的地理位置
	  offset   : new BMap.Size(-18, -5)    //设置文本偏移量
	}
	var label = new BMap.Label(res.dt1[i].UserName, opts);  // 创建文本标注对象
                        label.setStyle({
        border: "none",
		color : 'black',
		fontSize : '12px',
		height : '20px',
		lineHeight : '20px',
		fontFamily: '微软雅黑'
	});
	map.addOverlay(label);  
                      
                    }
                    else {
            $("#ul2").append((res.dt1[i].UserName+"<div></div>"));
                    }
                }
                //最简单的用法，生成一个marker数组，然后调用markerClusterer类即可。
              
            }
        });
    })
    


</script>


<script>
layui.use('element', function(){
  var $ = layui.jquery
  ,element = layui.element; //Tab的切换功能，切换事件监听等，需要依赖element模块
  

  
});
</script>