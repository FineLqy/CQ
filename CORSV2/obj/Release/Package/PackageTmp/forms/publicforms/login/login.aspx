<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CORSV2.forms.publicforms.login.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <title>卫星导航定位基准服务平台 - 登录</title>
    <link rel="shortcut icon" href="../../../themes/images/favicon.ico" />
    <link href="../../../themes/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/animate.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css" rel="stylesheet" />
    <link href="../../../themes/css/login.css" rel="stylesheet" />
    <link href="../../../themes/css/admin.css" rel="stylesheet" />
    <link href="../../../themes/css/layui.css" rel="stylesheet" />
    <link href="../../../themes/css/login_1.css" rel="stylesheet" />

<%--  登录seession时间过期？--%>
        <script>
        if (window.top !== window.self) {
            window.top.location = window.location;
        }
    </script>
</head>

<body class="signin">

    <div class="layadmin-user-login layadmin-user-display-show" id="LAY-user-login" style="display: none;">

        <div class="layadmin-user-login-main">
            <div class="layadmin-user-login-box layadmin-user-login-header">
                <h2>卫星导航定位基准服务系统</h2>
                <p></p>
            </div>
            <div class="layadmin-user-login-box layadmin-user-login-body layui-form">
                <div class="layui-form-item">
                    <%--                    <label class="layadmin-user-login-icon layui-icon layui-icon-username" for="LAY-user-login-username"></label>--%>
                    <input type="text" class="form-control " id="UserName" placeholder="用户名" />
                </div>
                <div class="layui-form-item">
                    <%--                    <label class="layadmin-user-login-icon layui-icon layui-icon-password" for="LAY-user-login-password"></label>--%>
                    <input type="password" class="form-control " id="PassWord" placeholder="密码" />
                </div>
                <div class="layui-form-item">
                    <div class="layui-row">
                        <div class="layui-col-xs7">
                            <input type="text" id="code" class="layui-input form-control uname" name="code" placeholder="请输入验证码 " autocomplete="off"  onkeydown="KeyDown()"  />
                        </div>
                        <div class="layui-col-xs5">
                            <div style="margin-left: 10px;">
                                <img id="verifyCode" src="?action=getcode" class="layadmin-user-login-codeimg" />
                                <%--                            <a id="refreshCode" class="fr code">刷新</a>--%>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="layui-form-item">
                    <button class="layui-btn layui-btn-fluid" type="button" id="buttonlogin">登录</button>
                </div>
                <div class="layui-form-item">
                    <strong><span style="color:black;">还没有账号？</span> <a href="../Register/Register.aspx" style="color: blue;">立即申请注册&raquo;</a>
                        &raquo;<a href="FindPassWord.aspx" style="color: #225592;">&nbsp&nbsp &nbsp  忘记密码？&raquo;</a></strong>
                </div>
  <%--                <div class="layui-form-item">、
                    <strong><span style="color:black;">忘记密码？</span> <a href="../Register/Register.aspx" style="color: blue;">立即申请注册&raquo;</a></strong>
                </div>--%>


            </div>
        </div>
    </div>


    <div class="layui-trans layadmin-user-login-footer">

        <%--        <p>© 2018 <a href="http://www.layui.com/" target="_blank">layui.com</a></p>
        <p>
            <span><a href="http://www.layui.com/admin/#get" target="_blank">获取授权</a></span>
            <span><a href="http://www.layui.com/admin/pro/" target="_blank">在线演示</a></span>
            <span><a href="http://www.layui.com/admin/" target="_blank">前往官网</a></span>
        </p>--%>
    </div>

    <!--<div class="ladmin-user-login-theme">
      <script type="text/html" template>
        <ul>
          <li data-theme=""><img src="{{ layui.setter.base }}style/res/bg-none.jpg"></li>
          <li data-theme="#03152A" style="background-color: #03152A;"></li>
          <li data-theme="#2E241B" style="background-color: #2E241B;"></li>
          <li data-theme="#50314F" style="background-color: #50314F;"></li>
          <li data-theme="#344058" style="background-color: #344058;"></li>
          <li data-theme="#20222A" style="background-color: #20222A;"></li>
        </ul>
      </script>
    </div>-->

</body>
<script src="../../../js/jquery.min.js"></script>
<script src="../../../js/md5.js"></script>
<script src="../../../js/bootstrap.min.js?v=3.3.6"></script>
<script src="../../../js/plugins/layer/layer.min.js"></script>

<script type="text/javascript">

    //前端密码加密
    function getEncryption(password, uin, vcode, isMd5) {
        var str1 = isMd5 ? password : hex_md5(password);
        var str2 = hex_md5(str1 + uin);
        var str3 = hex_md5(str2 + vcode.toUpperCase());
        return str3
    }
    //刷新验证码
    $("#verifyCode").click(function () {
        refreshVerifyCode(); //刷新验证码
    });
    $("#refreshCode").click(function () {
        refreshVerifyCode(); //刷新验证码
    });

    refreshVerifyCode();
    //刷新验证码
    function refreshVerifyCode() {
        $("#verifyCode").attr("src", "?action=getcode&t=" + new Date().valueOf());
    }
        function KeyDown() {
        if (event.keyCode == 13) {
            event.returnValue = false;
            event.cancel = true;
            $("#buttonlogin").click()
        }
    }
    $("#buttonlogin").click(function () {
        //var password = $("#PassWord").val();
        var username = $("#UserName").val();
        var VerifyCode = $("#code").val();
        password = getEncryption($("#PassWord").val(), $("#UserName").val(), $("#code").val(), true);
        //password = hex_md5($("#PassWord").val());
        if ($("#UserName").val().trim() == "") {
            layer.tips('请输入用户名', '#UserName', {
                tips: [3, '#a94442']
            });
            $("#UserName").focus();
            return;
        }
        else {
            if ($("#PassWord").val().trim() == "") {
                layer.tips('请输入密码', '#PassWord', {
                    tips: [3, '#a94442']
                });
                $("#PassWord").focus();
                return;
            }
            else if ($("#code").val() == "") {
                layer.tips('请输入验证码', '#code', {
                    tips: [3, '#a94442']
                });
                $("#code").focus();
                return;
            }
            else {
                // verify password
                $.ajax({
                    url: "?action=login",
                    data: {
                        UserName: username,
                        PassWord: password,
                        VerifyCode: VerifyCode
                    },
                    type: "POST",
                    success: function (result) {
                        //if (result == "1") {
                        //    window.location.href = "../../cors_user.aspx";
                        //}
                        //if (result == "3") {
                        //    window.location.href = "../../cors_admin.aspx";
                        //}
                        if (result == "0") //failed! username is not exist 
                        {

                            layer.msg('用户名或密码错误！', function () {
                                //关闭后的操作
                            });
                            return false;
                        }
                        if (result == "-1") //failed! username is not exist 
                        {

                            layer.msg('验证码错误！', function () {
                                //关闭后的操作
                            });
                            return;
                        }
                        if (result == "-2") //failed! username is not exist 
                        {

                            layer.msg('用户不存在！', function () {
                                //关闭后的操作
                            });
                            return;
                        }
                        if (result == "-3") //failed! username is not exist 
                        {

                            layer.msg('登录过于频繁，请于半小时后登录！', function () {
                                //关闭后的操作
                            });
                            return;
                        }
                        else {
                            $("body").html(result);
                        }
                    }
                });
            }
        }
    })
</script>
</html>
