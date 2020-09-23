<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindPassWord.aspx.cs" Inherits="CORSV2.forms.publicforms.login.FindPassWord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" href="../../../themes/images/favicon.ico" />
    <link href="../../../themes/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/animate.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css" rel="stylesheet" />
    <link href="../../../themes/css/login.css" rel="stylesheet" />
    <link href="../../../themes/css/global-new.css" rel="stylesheet" />
    <link href="../../../themes/css/header.css" rel="stylesheet" />
    <link href="../../../themes/css/init.css" rel="stylesheet" />
    <link href="../../../themes/css/page.css" rel="stylesheet" />
    <link href="../../../themes/css/img-sprites-shop.css" rel="stylesheet" />
    <link href="../../../themes/css/slick.css" rel="stylesheet" />
</head>
<body>
    <div class="layout-content reg-container">
        <div class="content-container">
            <h3>重置登录密码</h3>
            <form class="form-horizontal m-t" id="signupForm" method="post" action="">

                <div class="form-group">
                    <label class="col-sm-3 control-label">用户名：</label>
                    <div class="col-sm-8">
                        <input id="UserName" name="UserName" autocomplete="off" placeholder="请输入用户名" class="form-control" />

                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">手机号码：</label>
                    <div class="col-sm-8">
                        <input id="phone1" name="phone1" placeholder="请输入手机号码" autocomplete="off" class="form-control" />

                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">手机验证码：</label>
                    <div class="col-sm-6">
                        <input name="verifyCode" id="verifyCode" maxlength="6" placeholder="请输入验证码" autocomplete="off" class="form-control" value="" />
                    </div>

                    <div class="col-sm-2" style="text-align: center">
                        <input id="getCode" type="button" value="获取验证码" class="btn btn-primary" data-value="1" />
                    </div>

                    <p class="error-msg"></p>
                </div>
                                <div class="form-group">
                    <label class="col-sm-3 control-label">密码：</label>
                    <div class="col-sm-8">
                        <input id="password" name="password" class="form-control" autocomplete="off" type="password" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">确认密码：</label>
                    <div class="col-sm-8">
                        <input id="confirm_password" name="confirm_password" autocomplete="off"  class="form-control" type="password" runat="server" />
                        <span class="help-block m-b-none"><i class="fa fa-info-circle"></i>请再次输入您的密码</span>
                    </div>
                </div>
                <div class="form-group">

                <div class="col-sm-8 col-sm-offset-3">
                    <input  id="event_submit_do_regist" class="btn btn-primary form-control" style="padding-bottom:30px;" type="submit" value="立即重置" name="event_submit_do_regist" />
                </div>
                </div>
                 
            </form>
        </div>
    </div>
    <script src="../../../js/jquery-1.10.2.min.js"></script>
    <script src="../../../js/md5.js"></script>
    <script src="../../../js/jquery.min.js"></script>
    <script src="../../../js/bootstrap.min.js?v=3.3.6"></script>

    <script src="../../../js/plugins/validate/jquery.validate.js"></script>
    <script src="../../../js/plugins/validate/messages_zh.min.js"></script>
    <script src="../../../js/plugins/validate/form-validate-demo.js"></script>

    <script src="../../../js/jquery.form.js"></script>
        <script src="../../../js/plugins/layer/layer.js"></script>

    <script>
      
                $("#getCode").click(function () {
            //修改data-value 以便于提交是判断是获取验证码而不是提交表单
            $("#getCode").attr("data-value", "2");
        });
        $("#event_submit_do_regist").click(function () {
            //修改data-value 以便于提交是判断是获取验证码而不是提交表单
            $("#getCode").attr("data-value", "1");
        });

        var count = 60; //间隔函数，1秒执行
        var InterValObj1; //timer变量，控制时间
        var curCount1;//当前剩余秒数

   
        $("#getCode").click(function () {
            var phone1 = $("#phone1").val();
            var name = $("#UserName").val();
            $.ajax({
                url: "?action=getCode",
                data: {
                    "phone1": phone1,
                    "name":name
                },
                type: "get",
                success: function (result) {
                    if (phone1 == "" || phone1 == null) {
                        layer.msg('手机号不能为空！', { icon: 1 });
                        return false;
                    }
                    if (result == "1") {
                        //window.location.href = "../login/login.aspx";
                        curCount1 = count;
                        //设置button效果，开始计时
                        $("#getCode").attr("disabled", "true");
                        $("#getCode").val(+curCount1 + "秒再获取");
                        InterValObj1 = window.setInterval(SetRemainTime1, 1000); //启动计时器，1秒执行一次
                        layer.msg('验证码已经发送', { icon: 1 });

                    }
                  
                },
                error: function (result) {
                    layer.msg('失败！', function () {
                        //关闭后的操作
                    })
                }
            });
        })
        function SetRemainTime1() {
            if (curCount1 == 0) {
                window.clearInterval(InterValObj1);//停止计时器
                $("#getCode").removeAttr("disabled");//启用按钮
                $("#getCode").val("重新发送");
            }
            else {
                curCount1--;
                $("#getCode").val(+curCount1 + "秒再获取");
            }
        }
        function edit_info() {
            console.log($('#signupForm').serialize());
            $.ajax({
                url: "?action=resetPassword",
                data: $('#signupForm').serialize(),
                dataType: "json",
                type: "POST",
                success: function (data) {
                   
                    if (data.code == "200") {
                        window.location.href = "../login/login.aspx";
                        alert('重置密码成功,将会跳转到登录界面');
                    }
                    if (data.code == "100") {
                        layer.msg('请输入手机号码！', function () {
                            //关闭后的操作
                        });
                        return false;
                    }
                    else {
                        layer.msg('重置密码失败！', function () {
                            //关闭后的操作
                        });
                        return false;
                    }
                }
            });
        };
    </script>
</body>
</html>

