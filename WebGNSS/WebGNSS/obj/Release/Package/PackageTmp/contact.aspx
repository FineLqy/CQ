<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="WebGNSS.contact" %>


<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>联络我们</title>
<link rel="stylesheet" type="text/css" href="css/reset.css" />
<link rel="stylesheet" type="text/css" href="css/style.css" />
<link rel="stylesheet" type="text/css" href="css/animation.css" /> 

    <style type="text/css">
        .BMap_cpyCtrl {
            display: none;
        }
        .anchorBL {
            display: none;
        }
       .td1 {
        
           width:400px;
     
     
             }
        td {
           font-weight:bold;
            color:#6c8ac6;
            right:-10px;
            font-size:16px;
        
            
        }
       
    </style>
</head>
<body>
	<!--头部 Start!-->
	<div id="hd" >
		<a  class="hd-logo" style="margin-left:150px" >
			<img src="picture/20190716112802.png"   >
		</a>
       
		<ul id="nav" style="margin-left:650px"  class="clearfix" >

			<li ><a href="index.aspx" >首页</a></li>
			<li><a href="about.aspx" >关于我们</a></li>
			<li><a href="product.aspx" >技术指导</a></li>
			<li><a href="solution.aspx"  >解决方案</a></li>
			<li><a href="news.aspx"  >新闻公告</a></li>
			<li class="on"><a href="contact.aspx" >联络我们</a></li> 
		</ul>
		<div class="hd-bar"  style="margin-top:25px; margin-right:150px">
            <a  href="#" style="font-size: 16px; color:#5f85d1">登录</a><span >|</span>
            <a href="#" style="font-size: 16px;color:#5f85d1">注册</a>
			<div class="top-search" >
				
         
			</div>
			
		</div>
	</div>
	<!--头部 End!-->

	<!--banner Start!-->
	<div class="page-banner" style="background: url(images/banner1.jpg) no-repeat center 0;">
		<div class="text">
			<%--<div class="big">
				<strong class="move-left">负衡据鼎</strong>
				<span class="move-right">传承国企业精神</span>
			</div>--%>
			<div class="small move-down">------</div>
		</div>
	</div>
	<!--banner End!-->

	<!--main Start!-->
	<div id="main" class="bg-gray">
		<div class="contact wp">
			<div class="contact-wp">
				<div class="top-inner clearfix" style="width:100%;height:800px;">
                    <div id="map1" style="width:100%; height:85%;">

                       
                    </div>
                    
                        <table style="width:100%;height:15%; margin-top:20px;background-color:antiquewhite">
                            <tr >
                              <td class="td1">&nbsp;&nbsp;联系地址:重庆市渝北区冉家坝规划测绘创新基地 </td>
                                <td>传真:+86-22-12345600</td>
                                <td rowspan="2"> <img src="images/qrcode.png"/></td>
                               
                            </tr>
                            <tr>
                                <td class="td1">&nbsp;&nbsp;联系电话</td>
                                <td>手机：</td>
                                  
                              
                                
                           </tr>
                            </table>
                  
               
                  
                    <span style="float:right;margin-top:-40px;font-size:15px;color:#0f46b2; right:-10px">扫一扫,即可关注我们</span>
                 
                          
                       
                 
					
						
					</div>
				</div>
                    </div>
				<div class="company">
				
					
				</div>
			</div>
		
		
	<!--main End!-->

	<!--底部 Start!-->
	<div id="ft">
		
		<div class="copyright wp">
			<div class="inner-wp">
				<div class="partner clearfix">
					<span>友情链接：</span><br />
					
				</div>
				<p> <b>COPYRIGHT @ 2019<span><b>重庆市地理信息中心</b></span>All  Rights <a href="#" title="17sucai">Reserved</a>. 渝ICP备17077179号  技术支持：领城</b></p>
			</div>
		</div>
	</div>
	<!--底部 End!-->
</body>
        <script type="text/javascript" src="http://api.map.baidu.com/api?v=3.0&ak=CKeZG8pGDGrA4VUvVRpHIQSHnIK9l32l"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/library/Heatmap/2.0/src/Heatmap_min.js"></script>

    <script type="text/javascript" src="http://developer.baidu.com/map/custom/stylelist.js"></script>

    
<script  type="text/javascript">
	
    var map1 = new BMap.Map("map1");  // 创建地图实例  
    var point1 = new BMap.Point(106.504314, 29.601122);  // 创建点坐标  
	map1.centerAndZoom(point1, 17);  // 初始化地图，设置中心点坐标和地图级别
	map1.enableScrollWheelZoom(true);
	var marker1 = new BMap.Marker(point1);
	map1.addOverlay(marker1); 
	marker1.setAnimation(BMAP_ANIMATION_BOUNCE);
	//map1.setMapStyle({ style: 'grayscale' });
	map1.setMapStyle({ style: 'hardedge' });

	
	map1.disableDragging();     //禁止拖拽
	setTimeout(function () {
	    map1.enableDragging();   //两秒后开启拖拽
	    //map.enableInertialDragging();   //两秒后开启惯性拖拽
	}, 2000);
	map1.disableScrollWheelZoom();//禁止缩放
	map1.disableDoubleClickZoom()//禁止双击放大


</script>
</html>
