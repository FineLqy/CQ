<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="CORSV2.forms.administrator.system.AddNews" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>添加新闻</title>
     <link rel="shortcut icon" href="../../favicon.ico" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/animate.css" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/style.css?v=4.4.0" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/login.css" />

    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/News.css" rel="stylesheet" />

    <link href="../../../themes/css/plugins/summernote/summernote-bs3.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/summernote/summernote.css" rel="stylesheet" />
        <link href="../../../themes/css/style.wyy.1.css" rel="stylesheet" />
</head>
<body class="gray-bg" style="background-image:none">
    <div class="Container" style="padding:0px;">
        <div class="Content" style="width:100%;height:100%; border-radius:0px;box-shadow:none">
            <div class="titlegroup">
             <input type="text" placeholder="文章标题" class="title" style="width:80%"/>
            <button class="btn btn-success" id="submit"> 发布新闻</button>
            </div>
            <div class="editor">
                <div class="summernote">
                </div>
            </div>
        </div>
    </div>
</body>
    <script src="../../../js/jquery.min.js"></script>
    <script src="../../../js/bootstrap.min.js"></script>
<script src="../../../js/plugins/summernote/summernote.min.js"></script>
<script src="../../../js/plugins/summernote/summernote-zh-CN.js"></script>
<script src="../../../js/plugins/layer/layer.min.js"></script>
    <script>
        $(document).ready(function () {

            $('.summernote').summernote({
                lang: 'zh-CN'
            });
            var left = $(".Content").offset().left;
            var width = $(".Content").width();
            $(".social-icon").css("left", left + width + 30);


            $(".fa-arrow-up").hide();
            //当滚动条的位置处于距顶部100像素以下时，跳转链接出现，否则消失
            $(function () {
                $(window).scroll(function () {
                    if ($(window).scrollTop() > 100) {
                        $(".fa-arrow-up").fadeIn(800);
                    } else {
                        $(".fa-arrow-up").fadeOut(800);
                    }
                });
            });
        });
        $(window).resize(function () {
            var left = $(".Content").offset().left;
            var width = $(".Content").width();
            $(".social-icon").css("left", left + width + 30);
        });

        $("#submit").on('click', function () {
            var title = $(".title").val();//文章标题
            var detail = $(".note-editable").html();
            var data = {
                PostBack:'true',
                Title: title,
                Details: html2Escape(detail)
            };
            $.ajax({
                url: './AddNews.aspx',
                type: 'POST',//这里你写错了，jquery应该是type:'POST'
                data: data,
                success: function () {
                    layer.alert('添加成功', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    parent.$("#refreshnews").click();
                }
            });

        });


        function html2Escape(sHtml) {
            return sHtml.replace(/[<>&"]/g, function (c) { return { '<': '&lt;', '>': '&gt;', '&': '&amp;', '"': '&quot;' }[c]; });
        }

        $(".NavActive").removeClass("NavActive");
        $("#PTGL").parent().addClass("NavActive");
    </script>
</html>
