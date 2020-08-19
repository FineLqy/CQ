<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResourceDownload.aspx.cs" Inherits="CORSV2.forms.publicforms.download.ResourceDownload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>资源下载</title>
    <link rel="shortcut icon" href="../../favicon.ico" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/animate.css" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/style.css?v=4.4.0" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/sgg.css" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/login.css" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/News.css" rel="stylesheet" />
    <link href="../../../themes/css/style.wyy.1.css" rel="stylesheet" />
    <style>
        .sgg-ul >li >a{
            font-size:1.3em !important;
        }
    </style>
</head>
    
<body class="gray-bg top-navigation">
  <div class="Container" style="padding-top: 00px;min-height:400px;border-radius:0px">
        <div class="Content" style="width:100%;height:759px;min-height:400px;border-radius:0px">
            <div class="ContentHead">
                <h1>资源下载</h1>
            </div>
            <div style="margin-top: 30px; margin-left: 5%;">
                <ul class="sgg-ul">
                  <%--  <li><a style="font-size: x-large" id="NN_APP">“南宁市北斗位置综合服务系统”APP客户端</a></li>--%>
                    <%=linkstr %>
                </ul>

            </div>
        </div>

    </div>
        <script src="../../../js/md5.js"></script>
    <script src="../../../js/jquery.min.js"></script>
    <script src="../../../js/bootstrap.min.js"></script>
    <script src="../../../js/navbar/navbar.wyy.1.js"></script>
    <script src="../../../js/plugins/layer/layer.min.js"></script>
     <script src="../../../js/qrcode/qrcode.min.js"></script>
    <script src="../../../js/sgg.js"></script>
    <script>

        $(function () {
            $(".panel-title").click(function (e) {
                /*切换折叠指示图标*/
                $(this).find("span").toggleClass("glyphicon-chevron-down");
                $(this).find("span").toggleClass("glyphicon-chevron-up");
            });
            $(".panel-body li").click(function (e) {
                $(this).find("a").click();
            });
            $(".NavActive").removeClass("NavActive");
            $("#Download").parent().addClass("NavActive");
            $("#app").on('click', appclik);


        });
    </script>
</body>
</html>
