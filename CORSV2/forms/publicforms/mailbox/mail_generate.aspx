<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mail_generate.aspx.cs" Inherits="CORSV2.forms.publicforms.mailbox.mail_generate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>消息播发</title>
    <link rel="shortcut icon" href="../../favicon.ico" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/animate.css" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/style.css?v=4.4.0" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/login.css" />
    
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/News.css" rel="stylesheet" />

    <link href="../../../themes/css/plugins/summernote/summernote-bs3.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/summernote/summernote.css" rel="stylesheet" />
    <style>
        .message-label {
    font-size: 18px;
}
    </style>
</head>
<body>
    <div class="Container" style="margin-top: 0px; padding-top: 0px">
        <div class="Content" style="width: 100%; margin-top: 0px; padding-top: 0px">
          
            <div class="titlegroup" style="width: 100%;margin-top:30px">
                <label class="message-label">信息标题：</label>
                <input type="text" id="title" class="title" style="width: 70%;height:40px;font-size: 22px;" />
                 <select id="level" style="height: 40px; font-size: 22px; padding: 0; margin: 0; border: 0px;  border-radius: 0px;width:18%">
                    <option>普通消息
                    </option>
                    <option>警告消息
                    </option>
                    <option>错误消息
                    </option>
                </select>
            </div>
            <div class="titlegroup" style="width: 100%;margin-top:20px">
<%--                <label class="message-label">接收账号：</label>
               <input type="text" id="receiver" class="title" style="width: 30%;height:40px;font-size: 22px;" />
                <label class="message-label">系统单位：</label>
                <label style="padding-left:3%;"> &nbsp</label>
                <select id="company" onchange="companychange()" runat="server" style="height: 40px; font-size: 22px; padding: 0; margin: 0; border: 0px; border-radius: 0px;width:20%">
                </select>--%>
                <label style="padding-left:6%;"> &nbsp</label>
                 <select id="username" runat="server" style="height: 40px; font-size: 22px; padding: 0; margin: 0; border: 0px; border-radius: 0px;width:20%">
                    <option>全部用户</option>
                </select>
               
            </div>

            <div class="editor" style="margin-top:20px">
                <div class="summernote">
                </div>
            </div>
            <div class="mail-body text-right tooltip-demo">
                <button class="btn btn-success btn-lg" id="submit" type="button">发送</button>
                <a href="mail_generate.aspx" class="btn btn-white btn-lg" data-toggle="tooltip" data-placement="top" title="Discard email"><i class="fa fa-times"></i>放弃</a>
            </div>

        </div>
    </div>
</body>

<script src="../../../js/jquery.min.js"></script>

<script src="../../../js/bootstrap.min.js"></script>
<script src="../../../js/plugins/summernote/summernote.min.js"></script>
<script src="../../../js/plugins/summernote/summernote-zh-CN.js"></script>
            <script src="../../../js/plugins/layer/layer.js"></script>

<script>

    //var use = "";
    //function companychange() {
    //    receiver.value = "";
    //    var comp = company.value;
    //    username.options.length = 0;
    //    username.add(new Option("全部用户"));
    //    $.post("Message.aspx?action=search_" + comp, function (result) {
    //        use = result;
    //        var users = new Array();
    //        users = result.split(";");
    //        for (var i = 0; i < users.length - 1; i++) {
    //            username.add(new Option(users[i]));
    //        }
    //    })
    //}
    //function userchange() {

    //    if (username.value == "全部用户") {
    //        receiver.value = use;
    //    }
    //    else {
    //        receiver.value = username.value;
    //    }
    //}

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
            //当点击跳转链接后，回到页面顶部位置
            $(".fa-arrow-up").click(function () {
                $('body,html').animate({
                    scrollTop: 0
                },
                1000);
                return false;
            });


        });
    });
    $(window).resize(function () {
        var left = $(".Content").offset().left;
        var width = $(".Content").width();
        $(".social-icon").css("left", left + width + 30);
    });

    $("#submit").on('click', function () {
        var t = document.getElementById("title");
        if (t.value.trim() == "") {
            layer.alert('标题不能为空', {
                skin: 'layui-layer-lan' //样式类名
                                  , closeBtn: 0
            });
            return false;
        }
        //var u = document.getElementById("receiver");
        //if (u.value.trim() == "") {
        //    layer.alert('用户名不能为空', {
        //        skin: 'layui-layer-lan' //样式类名
        //                       , closeBtn: 0
        //    });
        //    return false;
        //}
        var title = $("#title").val();//标题
        var l = document.getElementById("level");
        var level = l.selectedIndex;
        var rec = $("#username").val();
        var detail = $(".note-editable").html();
        var a = removeHtmlTab(detail);

        var data = {
            PostBack: 'true',
            Title: title,
            Level: level,
            Rec: rec,
            Details: a
        };
        $.ajax({
            url: './mail_generate.aspx',
            type: 'POST',//这里你写错了，jquery应该是type:'POST'
            data: data,
            success: function (result) {
                if (result == "1") {
                    layer.msg('成功发送邮件', { icon: 1, time: 500 },
                        function () {
                            window.location.href = "mail_generate.aspx";
                        })
                }
                else {
                    if (result == "2") {
                        layer.alert('用户不存在', {
                            skin: 'layui-layer-lan' //样式类名
                                   , closeBtn: 0
                        });
                        return false
                    }
                    else {
                        layer.alert('发送失败', {
                            skin: 'layui-layer-lan' //样式类名
                                   , closeBtn: 0
                        });
                        return false
                    }
                }
            }
        });

    });

    function removeHtmlTab(tab) {
        return tab.replace(/<[^<>]+?>/g, '');//删除所有HTML标签
    }
    function html2Escape(sHtml) {
        return sHtml.replace(/[<>&"]/g, function (c) { return { '<': '&lt;', '>': '&gt;', '&': '&amp;', '"': '&quot;' }[c]; });
    }
</script>
</html>
