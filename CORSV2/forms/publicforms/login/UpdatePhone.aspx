<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePhone.aspx.cs" Inherits="CORSV2.forms.publicforms.login.UpdatePhone" %>


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
            <h3>更换手机号码</h3>
            <form class="form-horizontal m-t" id="signupForm" method="post" action="">

               	<div class="form-group">
						<label class="col-sm-3 control-label">用户名</label>
						<div class="col-md-6">
							<p class="form-control-static"><%=userName %></p>
						</div>
					</div>
                              <div class="form-group">
                    <label class="col-sm-3 control-label">原始手机号：</label>
                    <div class="col-md-6">
							<p class="form-control-static"><%=Yphone %></p>
						</div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">请输入新的手机号码：</label>
                    <div class="col-sm-8">
                        <input id="Xphone" name="Xphone" class="form-control"  runat="server" />
                     
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">手机验证码：</label>
                    <div class="col-sm-6">
                        <input name="verifyCode" id="verifyCode" maxlength="6" placeholder="请输入验证码" class="form-control" value="" />
                    </div>

                    <div class="col-sm-2" style="text-align: center">
                        <input id="getCode" type="button" value="获取验证码" class="btn btn-primary" data-value="1" />
                    </div>

                    <p class="error-msg"></p>
                </div>
                  
                <div class="form-group">

                <div class="col-sm-8 col-sm-offset-3">
                    <input  id="event_submit_do_regist" class="btn btn-primary form-control" style="padding-bottom:30px;" type="submit" value="提交" name="event_submit_do_regist" />
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


        $("#getCode").click(function () {
            var phone1 = $("#Xphone").val();
            $.ajax({
                url: "?action=getCode",
                data: {"phone1":phone1},
                type: "get",
                success: function (result) {
                    if (phone1 == "" || phone1==null) {
                        layer.msg('手机号不能为空！', { icon: 1 });
                        return false;
                    }
                            
                    if (result == "1") {
                        //window.location.href = "../login/login.aspx";
                        layer.msg('验证码已经发送', { icon: 1 });
                    }
                    if (result == "0") //failed! username is not exist 
                    {
                        layer.msg('注册失败！', function () {
                            //关闭后的操作
                        });
                        return false;
                    }
                    else {
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
        function edit_info() {

            $.ajax({
                url: "?action=resetPassword&&phone=" + $("#Xphone").val(),
                data: $('#signupForm').serialize(),
                dataType: "json",
                type: "POST",
                success: function (data) {
                    if (data.code == "200") {
                        layer.msg('手机号修改成功', { icon: 1 });
                        
                    }
                    if (data.code=="100") {
                        layer.msg('请输入正确的手机号！', function () {
                            //关闭后的操作
                        });
                        return false;
                    }
                    else {
                        layer.msg('手机号修改失败！', function () {
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