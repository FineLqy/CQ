<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="WebGNSS.news" %>


<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>新闻公告</title>
<link rel="stylesheet" type="text/css" href="css/reset.css" />
<link rel="stylesheet" type="text/css" href="css/style.css" />
<link rel="stylesheet" type="text/css" href="css/animation.css" /> 

    <link href="css/styleNews.css" rel="stylesheet" type="text/css" />
    <script src="laypage/laypage.js"></script>
</head>
<body>
	<!--头部 Start!-->
	<div id="hd" >
		<a  class="hd-logo" style="margin-left:150px" >
			<img src="picture/20190716112802.png"   >
		</a>
       
		<ul id="nav" style="margin-left:650px"  class="clearfix" >

			<li><a href="Index.aspx" >首页</a></li>
			<li><a href="about.aspx" >关于我们</a></li>
			<li><a href="product.aspx" >技术指导</a></li>
			<li><a href="solution.aspx"  >解决方案</a></li>
			<li  class="on"><a href="news.aspx"  >新闻公告</a></li>
			<li><a href="contact.aspx" >联络我们</a></li> 
		</ul>
		<div class="hd-bar"  style="margin-top:25px; margin-right:150px">
            <a  href="../publicforms/login/login.aspx" style="font-size: 16px; color:#5f85d1">登录</a><span >|</span>
            <a href="../publicforms/register/register.aspx" style="font-size: 16px;color:#5f85d1">注册</a>
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
			<div class="small move-down">-----</div>
		</div>
	</div>
	<!--banner End!-->

	<!--main Start!-->
	<div id="main" class="bg-gray">
		<div class="news wp">
			<div class="top-bar clearfix" >
				<div class="news-menu">
					<a href="javascript:;" class="on">新闻公告</a>
				
				</div>
				<div class="crumbs">你现在的位置 》
					<a href="index.aspx">首页 》</a>
					
					<span>新闻公告</span>
				</div>
			</div>
			<div class="tab-container">
				<div class="tab-con">
					<div class="news-wp" style="height:750px;  background: #f9f9fc;"  >
						<div class="box_news" style="height:750px">
	<div class="inbanner" ">
				<div class="weizhi"   >
			
                    <div class="binr"  >
                        <div class="newslistin"   >
                            
                            
                            <div class="ntinm" style="width:1000px"  >
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <ul style="font-size:16px">

                                    <li "><span><%#Eval("Time") %></span><a href="#" title='<%#Eval("Title") %>'>> <%#Eval("Title") %></a></li>
                                   
                                </ul>
                                <div class="c">
                                </div>
                               
                                    </ItemTemplate>
                                </asp:Repeater>
                                 <div class="pageNavi">
                                    <div class="wp-pagenavi">
                                        <a title="Total record">&nbsp;<b>465</b> </a>&nbsp;&nbsp;&nbsp;<b>1</b>&nbsp;<a href="/html/xwzx/index_2.html">2</a>&nbsp;<a href="/html/xwzx/index_3.html">3</a>&nbsp;<a href="/html/xwzx/index_4.html">4</a>&nbsp;<a href="/html/xwzx/index_5.html">5</a>&nbsp;<a href="/html/xwzx/index_6.html">6</a>&nbsp;<a href="/html/xwzx/index_7.html">7</a>&nbsp;<a href="/html/xwzx/index_8.html">8</a>&nbsp;<a href="/html/xwzx/index_9.html">9</a>&nbsp;<a href="/html/xwzx/index_10.html">10</a>&nbsp;<a href="/html/xwzx/index_2.html">下一页</a>&nbsp;<a href="/html/xwzx/index_31.html">尾页</a></div>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                   
                </div>
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
    $(function () {
        //内容切换
        var tabNum = 0;
        var menu = $('.news-menu a');
        var con = $('.tab-con');
        function tabInt() {
            menu.eq(tabNum).addClass('on').siblings().removeClass('on');
            con.eq(tabNum).show().siblings().hide();
            con.find('.scale').removeClass('scale-in');
            con.eq(tabNum).find('.scale').addClass('scale-in');
        }
        tabInt();
        menu.on('click', function () {
            tabNum = $(this).index();
            tabInt()
        });
    });
</script>
</html>
