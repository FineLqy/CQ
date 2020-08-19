<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebGNSS.Index" %>


<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>首页</title>
<link rel="stylesheet" type="text/css" href="css/reset.css" />
<link rel="stylesheet" type="text/css" href="css/swiper.css" />
<link rel="stylesheet" type="text/css" href="css/style.css" />
<link rel="stylesheet" type="text/css" href="css/animation.css" />
    <style type="text/css">
     
        .submit_btn 
        {
            margin-top:15px;
            
            background-color:#008DCB;
            border:none;
            border-radius:10px;
            box-shadow:0 0 3px #aaa;
            width:98px;
            height:41px;
            line-height:41px;
            color:#fff;
            font-size:18px;
            font-weight:bold;
            cursor:pointer;
            margin-right:20px;
            display:block;
            outline:none;
            text-shadow:0 1px 1px #777;
            float:left;

        }
		.submit_btn:hover {background-color:#d8d8d8;color:#666;text-shadow:1px 1px 1px #fff;}

   
        * {
            margin: 0;
            padding: 0;
        }

        header {
            margin: 20px;
            text-align: center;
        }

        .contain {
            width: 1100px;
            margin: auto auto;
            overflow: hidden;
            margin-top:20px;
            height:70px;
        }

        .single {
            width: 100%;
            height: 100%;
            position: relative;
            font-size: 0;
        }

        .pre {
            position: absolute;
            width: 20px;
            height: 100%;
            background-color: rgba(0, 0, 0, 0.5);
            cursor: pointer;
        }

        .pre:hover {
            background-color: rgba(0, 0, 0, 0.8);
        }

        .pre::before {
            content: "";
            width: 12px;
            height: 12px;
            border: solid #fff;
            border-width: 2px 0 0 2px;
            transform: translate(-50%, -50%) rotate(-45deg);
            position: absolute;
            left: 70%;
            top: 50%;
        }

        .next {
            position: absolute;
            width: 20px;
            height: 100%;
            right: 0px;
            background-color: rgba(0, 0, 0, 0.5);
            cursor: pointer;
        }

        .next:hover {
            background-color: rgba(0, 0, 0, 0.8);
        }

        .next::before {
            content: "";
            width: 12px;
            height: 12px;
            border: solid #fff;
            border-width: 0 2px 2px 0;
            transform: translate(-50%, -50%) rotate(-45deg);
            position: absolute;
            left: 30%;
            top: 50%;
        }

        .single ul {
            list-style: none;
            white-space: nowrap;
            display: inline-block;

        }

        .single ul li {
            margin-left:10px;
            display: inline-block;
        }

        img {
            vertical-align: top;
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

			<li class="on"><a href="index.aspx;" >首页</a></li>
			<li><a href="about.aspx" >关于我们</a></li>
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
	<div id="banner">
        <ul>
            <li>
				<img src="picture/zz.jpg">
    			<div class="text">
					<%--<div class="wp">
						<div class="big">
							<h1 class="move-up">负衡据鼎</h1>
							<h4 class="move-right">传承国企业精神</h4>
						</div>
						<div class="small move-down">厚德载物，自强不息</div>
					</div>--%>
    			</div>
            </li>
            <li>
			<img src="picture/00159.jpg">
    			<div class="text">
					<%--<div class="wp">
						<div class="big">
							<h1 class="move-left">负衡据鼎</h1>
							<h4 class="move-up">传承国企业精神</h4>
						</div>
						<div class="small move-right">厚德载物，自强不息</div>
					</div>--%>
    			</div>
            </li>
            <li>
			<img src="picture/卫星1.jpeg">
    			<div class="text">
				<%--	<div class="wp">
						<div class="big">
							<h1 class="move-up">负衡据鼎</h1>
							<h4 class="move-left">传承国企业精神</h4>
						</div>
						<div class="small move-right">厚德载物，自强不息</div>
					</div>--%>
    			</div>
            </li>
        </ul>
        <div class="circle"></div>
    </div>
	<!--banner End!-->

	<!--main Start!-->
	<div id="main">
		<div class="index-box">
            <div class="inner-box clearfix"  >
          
<div class="contain">
<div class="single">
<div class="pre"></div>
<div class="next"></div>
<ul>
<li>
    <a href="http://www.tianditu.gov.cn/">
<img src="/images/1.png" alt=""/>
        </a>
</li>
<li>
<a href="http://ghzrzyj.cq.gov.cn/plus/list.php?tid=145">
<img src="/images/3.png" alt=""/>
        </a>
</li>
<li>
<a href="http://www.tianditucq.com/#/home">
<img src="/images/6.png" alt=""/>
        </a>
</li>
<li>
<a href="http://bzdt.ch.mnr.gov.cn/">
<img src="/images/7.png" alt=""/>
        </a>
</li>
<li>
<a href="http://www.cqmap.com/bzdt/">
<img src="/images/8.png" alt=""/>
        </a>
</li>

</ul>
</div>
</div>
            </div>
		</div>
		
		<!-- 关于我们 -->
		<div class="item index-about">
			<div class="item-tit">
				<h2> CQGNSS简介</h2>
				<h5></h5>
			</div>
			<div class="item-con wp clearfix">
				<div class="text fl">
					<h3 class="move-up"></h3>
					<div class="move-left">
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
					<a href="#" class="move-right">more</a>
				</div>
				<div class="img scale fr">
					<!-- <img src="picture/iabout.jpg"> -->
					<div id="mySwiper3" class="swiper-container">
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
			</div>
			<div class="line"></div>
		</div>

		<!-- 解决方案 -->
		<div class="item solution">
			<div class="item-tit">
				<h2>应用服务</h2>
				<h5></h5>
			</div>
			<div class="item-con wp clearfix">
				<ul class="clearfix">
					<li class="scale clearfix">
						<div class="icon">
							<img src="picture/图片1.png">
						</div>
						<div class="text">
							<h4>RTK服务</h4>
							<p>重庆市范围内基于载波相位差分的厘米级定位服务</p>
							<p>实时定位精度优于5cm</p>
						</div>
					</li>
					<li class="scale clearfix">
						<div class="icon">
							<img src="picture/图片2.png">
						</div>
						<div class="text">
							<h4>RTD服务</h4>
							<p>重庆市范围内基于伪距差分改正的分米级位置服务接口</p>
							<p>实时定位精度优于1m</p>
						</div>
					</li>
					<li class="scale clearfix">
						<div class="icon">
							<img src="picture/图片3.png">
						</div>
						<div class="text">
							<h4>事后毫米级服务</h4>
							<p>结合GNSS观测数据后处理的高精定位差分算法，可对静态观测数据进行解算，实现毫米级差分定位服务</p>
							<p>定位精度优于1cm</p>
						</div>
					</li>
					<li class="scale clearfix">
						<div class="icon">
							<img src="picture/sico4.png">
						</div>
						<div class="text">
							<h4>三维坐标转换服务</h4>
							<p>重庆市范围内各个坐标系之间在线三维坐标转换服务</p>
							<p>平面优于1cm，高程平地优于2cm，山地丘陵优于4cm</p>
						</div>
					</li>
				</ul>
				<div class="img scale fr">
					<img src="picture/solution-bg.png" class="solution-bg" />
					<div id="mySwiper2" class="swiper-container">
			      		<div class="swiper-wrapper">
			        		<div class="swiper-slide">
			        			<a ><img src="picture/solution.jpg"></a>
			        		</div>
			        		<div class="swiper-slide">
			        			<a><img src="picture/solution.jpg"></a>
			        		</div>
			        		<div class="swiper-slide">
			        			<a ><img src="picture/solution.jpg"></a>
			        		</div>
			      		</div>
			    	</div>
			    	<span class="solution-btn solution-prev">&lt;</span>
		      		<span class="solution-btn solution-next">&gt;</span>
				</div>
			</div>
		</div>

		<!-- 资讯中心 -->
		<div class="item index-news" style="height:340px">
			<div class="new-tit">
				<div class="tit-inner">
					<h2>资讯中心</h2>
					<h5></h5>
				</div>
			</div>
		
			 
                     <asp:Repeater ID="Repeater1" runat="server" >
                         	
                         <ItemTemplate >
                            
                             <div class="wp" >
                            <tr>
                                <td>
             <ul class="clearfix" style="float:left" >
						<li class="scale on" >
							<div class="list-wp clearfix" >
								<div class="date">
									<h2><%#DateTime.Parse(Eval("Time").ToString()).ToString("dd")%></h2>
									<h5><%#DateTime.Parse(Eval("Time").ToString()).ToString("MMM",new System.Globalization.CultureInfo("en-US"))%></h5>
								</div>
								<div class="text">
									<h4><a href="#"><%#Eval("Details") %></a></h4>
									<p style="font-size: 24px;line-height: 36px"><%#Eval("Title") %></p>
									<a href="#" class="more">more<span>&gt;</span></a>
								</div>
							</div>
						</li>
					
					</ul>
                                </td>
                            </tr>
   
                                 
                           
                             	</div>
                         </ItemTemplate>
                     </asp:Repeater>
					
			 
			</div>
	
		
		<!-- 产品展示 -->
		<div class="item product">
			<div class="item-tit">
				<h2>PRODUCTS SHOW</h2>
				<h5>图片展示</h5>
			</div>
			<div class="item-con wp">
				<div class="img-tab">
					<div class = "caroursel poster-main" data-setting = '{
			        "width":1200,
			        "height":272,
			        "posterWidth":480,
			        "posterHeight":272,
			        "scale":0.8,
			        "dealy":"5000",
			        "algin":"middle"
			    }'>
				        <ul class = "poster-list">
				            <li class = "poster-item active"><a>
				            	<img src="picture/t1.jpg">
				            	
				            </a></li>
				            <li class = "poster-item"><a >
				            	<img src="picture/t2.jpg">
				            	
				            </a></li>
				            <li class = "poster-item"><a >
				            	<img src="picture/t3.jpg">
				            	
				            </a></li>
				            <li class = "poster-item"><a >
				            	<img src="picture/t4.jpg">
				            	
				            </a></li>
				            <li class = "poster-item"><a >
				            	<img src="picture/t5.jpg">
				            	
				            </a></li>
				            <li class = "poster-item"><a>
				            	<img src="picture/t6.png">
				            
				            </a></li>
				            <li class = "poster-item"><a >
				            	<img src="picture/product1.jpg">
				            	
				            </a></li>
				        </ul>
			        	<div class = "poster-btn poster-prev-btn"></div>
			        	<div class = "poster-btn poster-next-btn"></div>
	    			</div>
				</div>
			</div>
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
<script type="text/javascript" src="js/jquery.carousel.js"></script>

<script type="text/javascript" src="js/jwplayer.js"></script>
<script type="text/javascript" src="js/jwpsrv.js"></script>
<script type="text/javascript" src="js/index.js" ></script>
<script type="text/javascript" src="js/index-banner.js" ></script>
<script type="text/javascript" src="js/index2.js"></script>

    <script src="http://www.jq22.com/jquery/jquery-1.10.2.js"></script>
<script src="js/mySingleScroll.js"></script>
<script>
        var single;
        $(window).load(function () {
            single = $('.single').mySingleScroll({
                speed: 3500
            });
        });
    </script>

</html>
