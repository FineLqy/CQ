<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="solution.aspx.cs" Inherits="WebGNSS.solution" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
	<style type="text/css">
		.clearfix:after {
			content: "\20";
			height: 0;
			visibility: hidden;
			display: block;
			clear: both;
			font-size: 0;
			line-height: 0;
		}
		.clearfix {
			zoom: 1;
		}
		.pub_err_pages {
			background-color: #f5f8fa;
		}
		.pub_err_pages .pub_err_con {
			width: 520px;
			padding-left: 310px;
			margin: 150px auto;
			font-size: 14px;
		}
		.pub_warnimg_pic {
			width: 238px;
			height: 210px;
			float: left;
			margin-left: -310px;
			background: url(../../Content/images/err_warn.png) no-repeat;
		}
		.pub_err_pages a {
			text-decoration: none;
		}
		.pub_err_pages a:hover {
			text-decoration: underline;
		}
		.pub_err_con h1 {
			width: 470px;
			height: 22px;
			line-height: 22px;
			font-size: 28px;
			overflow: hidden;
			text-indent: -999px;
			background: url(../../Content/images/err_info.png) no-repeat left -22px;
		}
		.pub_err_con .pub_500 {
			background-position: 0 -22px;
		}
		.pub_err_operate {
			border-top: 1px dashed #c4c6c8;
			margin-top: 40px;
			padding-top: 40px;
		}
		.pub_err_operate strong {
			font-size: 14px;
		}
		.pub_err_operate a {
			color: #005de8;
		}
		.pub_err_pages .pub_footer {
			padding-bottom: 10px;
			font-size: 12px;
			text-align: center;
		}
		.pub_err_pages .footer_nav {
			width: 960px;
			margin: 0 auto;
			border-top: 1px solid #d1d5d8;
			padding: 25px 0 10px;
		}
		.pub_err_pages .footer_nav, .pub_err_pages .footer_nav a {
			color: #666666;
		}
		.pub_err_pages .footer_nav a {
			margin: 0 5px;
		}
		.pub_err_pages .copyright, .pub_err_pages .copyright a {
			color: #757575;
			font-family: tahoma;
		}
		.errText 
		{
			color: #F00;
		}
	</style>
</head>
<body class="pub_err_pages">
	<div class="pub_err_con">
		<img src="images/20190725173506.png" class="pub_warnimg_pic" alt="500提示" />
		<h1 class="pub_500">
			<span>Error 500</span>
			很抱歉，您要访问的页面出现内部错误</h1>

		<p>有可能我们的页面正在升级或者维护</p>

		<div class="pub_err_operate">
			<strong>您可以尝试以下操作：</strong>
		
			<p><a href="Index.aspx">&lt;&lt; 返回首页</a></p>
		</div>
	</div>
</body>
</html>