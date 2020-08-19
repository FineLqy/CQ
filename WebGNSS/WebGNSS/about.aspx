<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="WebGNSS.about" %>


<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>关于我们</title>
<link rel="stylesheet" type="text/css" href="css/reset.css" />
<link rel="stylesheet" type="text/css" href="css/swiper.css" />
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

			<li><a href="index.aspx" >首页</a></li>
			<li  class="on"><a href="about.aspx" >关于我们</a></li>
			<li><a href="product.aspx" >技术指导</a></li>
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
		<%--<div class="text">
			<div class="big">
				<strong class="move-left">负衡据鼎</strong>
				<span class="move-right">传承国企业精神</span>
			</div>
			<div class="small move-down">厚德载物，自强不息</div>
		</div>--%>
	</div>
	<!--banner End!-->

	<!--main Start!-->
	<div id="main">
		<div class="about">
			
			<div class="intro clearfix">
				<div class="img scale fr">
					<div class="img-tab">
						<div id="Swiper" class="swiper-container">
				      		<div class="swiper-wrapper">
				        		<div class="swiper-slide">
				        			<img src="picture/timg.jpg">
				        		</div>
				        		<div class="swiper-slide">
				        			<img src="picture/timg.jpg">
				        		</div>
				        		<div class="swiper-slide">
				        			<img src="picture/timg.jpg">
				        		</div>
				      		</div>
				    	</div>
	    				<div class="pagination1"></div>
					</div>
					<h2></h2>
					<h5></h5>
				</div>
				<div class="move-left">
					<h4></h4>
					<h3>单位介绍
					</h3>
					     <p> CQGNSS是原重庆市规划局按照2001年市政府颁布的《数字重庆地理信息系统发展纲要》、
                           《重庆市测绘事业发展暨地理信息基础设施建设第十一个五年专项计划》及市政府批示
                            （渝办[2005]850号文）精神，于2005年启动建设的卫星导航定位基准服务系统。</p>

                    <p>  重庆市地理信息中心作为CQGNSS的建设、运行管理单位，建设完成了由50个基准站组成的覆盖全市的卫星导航定位基准服务系统，
                            系统兼容北斗、GPS、GLONASS等卫星星座，面向全市各行业提供实时厘米级、分米级及事后毫米级定位服务。</p>
                       <p> 此外，与四川、湖南、湖北、贵州、山西等5个毗邻省完成省域接边区域基准站数据交换共享工作，
                            与市地震局、市国土资源和房屋勘测规划院、忠县城乡规划设计院等单位完成市域基准站共享。
                            目前，CQGNSS接入基准站共111个，实现了市内外基准站网高密度、无缝覆盖，搭建了重庆市北斗位置服务管理平台，
                            为自然资源、国土空间规划、交通、市政、电力、环境、林业、水利、航运、气象等行业用户提供更加精准快捷的信息化位置服务。
                             </p>

				</div>
			</div>
			<div class="course">
				<div class="course-tit">
					<div class="wp">
						<h5> </h5>
						<h4>发展历程</h4>
					</div>
				</div>
				<div class="wp">
					<div class="course-con">
						<div class="course-wp">
							<div class="course-item active">
								<div class="year move-left">2010</div>
								<div class="dot"></div>
								<div class="move-right">
									<h4> 从走出国门到服务全球，北斗有望成为中国“走出去”的又一张国家名片</h4>
									<p> “2012年12月，中国政府宣布北斗区域导航系统正式提供服务，北斗由此走出国门，五年来，北斗在老挝、泰国、巴基斯坦等国家相继落地应用，在‘一带一路’建设中的施工测量、机械作业、安全保卫等方面也发挥了作用。</p>
								</div>
							</div>
							<div class="course-item">
								<div class="year move-left">2009</div>
								<div class="dot"></div>
								<div class="move-right">
								<h4> 从走出国门到服务全球，北斗有望成为中国“走出去”的又一张国家名片</h4>
									<p> “2012年12月，中国政府宣布北斗区域导航系统正式提供服务，北斗由此走出国门，五年来，北斗在老挝、泰国、巴基斯坦等国家相继落地应用，在‘一带一路’建设中的施工测量、机械作业、安全保卫等方面也发挥了作用。</p>
								</div>
							</div>
							<div class="course-item">
								<div class="year move-left">2006</div>
								<div class="dot"></div>
								<div class="move-right">
									<h4> 从走出国门到服务全球，北斗有望成为中国“走出去”的又一张国家名片</h4>
									<p> “2012年12月，中国政府宣布北斗区域导航系统正式提供服务，北斗由此走出国门，五年来，北斗在老挝、泰国、巴基斯坦等国家相继落地应用，在‘一带一路’建设中的施工测量、机械作业、安全保卫等方面也发挥了作用。</p>
								</div>
							</div>
							<div class="course-item">
								<div class="year move-left">1999</div>
								<div class="dot"></div>
								<div class="move-right">
									<h4> 从走出国门到服务全球，北斗有望成为中国“走出去”的又一张国家名片</h4>
									<p> “2012年12月，中国政府宣布北斗区域导航系统正式提供服务，北斗由此走出国门，五年来，北斗在老挝、泰国、巴基斯坦等国家相继落地应用，在‘一带一路’建设中的施工测量、机械作业、安全保卫等方面也发挥了作用。</p>
								</div>
							</div>
							<div class="course-item">
								<div class="year move-left">1994</div>
								<div class="dot"></div>
								<div class="move-right">
									<h4> 从走出国门到服务全球，北斗有望成为中国“走出去”的又一张国家名片</h4>
									<p> “2012年12月，中国政府宣布北斗区域导航系统正式提供服务，北斗由此走出国门，五年来，北斗在老挝、泰国、巴基斯坦等国家相继落地应用，在‘一带一路’建设中的施工测量、机械作业、安全保卫等方面也发挥了作用。</p>
								</div>
							</div>
							<div class="course-item">
								<div class="year move-left">1990</div>
								<div class="dot"></div>
								<div class="move-right">
									<h4> 从走出国门到服务全球，北斗有望成为中国“走出去”的又一张国家名片</h4>
									<p> “2012年12月，中国政府宣布北斗区域导航系统正式提供服务，北斗由此走出国门，五年来，北斗在老挝、泰国、巴基斯坦等国家相继落地应用，在‘一带一路’建设中的施工测量、机械作业、安全保卫等方面也发挥了作用。</p>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="line2"></div>
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
<script type="text/javascript" src="js/jquery.min.js" ></script>
<script type="text/javascript" src="js/swiper.js"></script>
<script type="text/javascript" src="js/index.js" ></script>
<script type="text/javascript">
$(function(){

	$('.intro .scale').addClass('scale-in');
	$('.intro .move-left').addClass('left-in');

	$(window).on('scroll',function(){
		var $st = $(this).scrollTop();
		var $ct = $('.course').offset().top;
		var $windowH = $(window).height();

		if($st>($ct-$windowH)){
			$('.course-item').each(function(i,ele){
				setTimeout(function(){
					$(ele).find('.move-left').addClass('left-in-fast');
					$(ele).find('.move-right').addClass('right-in-fast');
				},i*300);
			});
		}
	});

	//公司介绍图片
	var mySwiper = new Swiper('#Swiper',{
    	autoplay: 5000, //间隔时间
    	autoplayDisableOnInteraction: false, //用户操作后，是否禁止自动播放
    	pagination: '.pagination1', //分页器
    	loop: true,	//	是否循环
    	resizeReInit : true,
    	paginationClickable: true, //分页器点击是否切换
    	calculateHeight: true //自适应高度
  	})
});
</script>
</html>