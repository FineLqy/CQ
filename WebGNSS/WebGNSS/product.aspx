<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="WebGNSS.product" %>


<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>技术指导</title>
<link rel="stylesheet" type="text/css" href="css/reset.css" />
<link rel="stylesheet" type="text/css" href="css/style.css" />
<link rel="stylesheet" type="text/css" href="css/animation.css" /> 
</head>
<body>
	<!--头部 Start!-->
	<div id="hd" >
		<a  class="hd-logo" style="margin-left:150px" >
			<img src="picture/20190716112802.png"   >
		</a>
       
		<ul id="nav" style="margin-left:650px"  class="clearfix" >

			<li ><a href="Index.aspx" >首页</a></li>
			<li><a href="about.aspx" >关于我们</a></li>
			<li class="on"><a href="product.aspx" >技术指导</a></li>
			<li><a href="solution.aspx"  >解决方案</a></li>
			<li><a href="news.aspx"  >新闻公告</a></li>
			<li><a href="contact.aspx" >联络我们</a></li> 
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
	<%--	<div class="text">
			<div class="big">
				<strong class="move-left">负衡据鼎</strong>
				<span class="move-right">传承国企业精神</span>
			</div>
			<div class="small move-down">-----</div>
		</div>--%>
	</div>
	<!--banner End!-->

	<!--main Start!-->
	<div id="main" class="bg-gray">
		<div class="program wp">
		
			<div class="program-inner">
			
				<div class="program-detial">
					<!-- 一级技术 -->
					<div class="tab-con">
						<div class="top-box">
							<h3>1.常见问题分析</h3>
							<h5>影响信号稳定性、定位精度的因素主要来自以下几方面：</h5>
							<p>
                                （1）通信网络因素，最常见的因素。<br />
                                如手机欠费、卡流量不足或过期、当地通信运营商服务中断、
                                作业地点移动网络信号死角等，可通过查看移动运营商网络信号、换其他运营商sim卡等方式测试，
                                亦可使用WIFI或者手机热点为作业设备提供网络信号的方式进行作业。<br />
                                （2）观测环境因素，较常见因素。<br />
                                作业环境如受遮挡、电离层跃变、地形地貌、多路径效应、电磁干扰等影响，RTK算法无法有效建立误差模型，致使无法获得固定解。一般可通过从手簿中查看观测卫星的数量、各颗卫星的信噪比SNR值来判断卫星数据的质量。
                                （3）账号因素，较常见因素。<br />
                                如账号过期，管理员可在CQGNSS平台上查询账号有效期。<br />
                                （4）基准站因素。<br />
                                比如周边基准站大面积突发故障等。请注意，单个站点不通畅不会影响使用效果。<br />
                                （5）仪器设备因素。<br />
                                比如仪器设置不当、仪器设备故障、设备注册码过期等原因，请联系设备仪器销售商售后。<br />
                                （6）其他因素。<br />
                                比如人为操作等问题。
                                上述因素可通过替换法或调整观测时间予以确认和解决。
                                注意：网络RTK技术是仍处于不断发展和进步中，下午较上午效果略差是各省CORS面临的普遍问题。
							</p><br />
                            <div class="img">
                           <h3> 2.基准站实时状态</h3><br />
							<%--<img src="picture/solution-bg.png">--%>
						</div>
                            <h3>3.平台使用说明</h3><br />
                              <div class="img">
                           <h3> 4.服务连接及仪器配置</h3><br />
                                  <p> 网络RTK手簿配置<br />
                                    服务IP：①cqcors.cqdlzx.com<br />
                                            ②222.177.24.8<br />
                                    服务端口：10051</p><br />
							<img src="picture/RT.png">
						</div>
                           
                             
						</div>
						
						
					</div>

				
				
				
				</div>
		
			</div>
		</div>
		<div class="line2"></div>
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
<script type="text/javascript" src="js/jquery.min.js" ></script>
<script type="text/javascript" src="js/index.js" ></script>
<script type="text/javascript">
$(function(){

	//内容切换
	var tabNum = 0;
	var menu = $('.pub-menu a');
	var con = $('.tab-con');
	function tabInt(){
		menu.eq(tabNum).addClass('on').siblings().removeClass('on');
		con.eq(tabNum).show().siblings().hide();
	}
	tabInt();
	menu.on('click',function(){
		tabNum = $(this).index();
		$('.dynamic').hide();
		tabInt()
	});

	$('.dynamic-btn').on('click',function(){
		con.hide();
		$('.dynamic').show();
	});

});
</script>
</html>
