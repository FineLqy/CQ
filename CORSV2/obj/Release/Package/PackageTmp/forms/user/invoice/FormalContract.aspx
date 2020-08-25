<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormalContract.aspx.cs" Inherits="CORSV2.forms.user.invoice.FormalContract" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <meta name="MobileOptimized" content="320">
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
            <h3>转为正式合同短信检验</h3>
           
                <div class="form-group">
                    
                    <div class="col-sm-8">
                       <label class="col-sm-3 control-label"></label>
                        <span style="text-align:center"> 为了您的安全，请勿泄露您的验证码</span>
                     
                    </div>
                </div><br>
             <form class="form-horizontal m-t" id="signupForm" method="post" runat="server" action="">
        

                      <div class="form-group">
                    <label class="col-sm-3 control-label">合同号：</label>
                    <div class="col-sm-4">
             <input id="Num" type="text" runat="server" />
                    </div>

                </div>
                  <div class="form-group">

                    <label class="col-sm-3 control-label">手机号码：</label>
                    <div class="col-sm-8">
                       
                        <input id="phone" name="phone" runat="server" class="form-control" />

                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">手机验证码：</label>
                    <div class="col-sm-4">
                        <input name="userPhone" maxlength="6" placeholder="请输入验证码" class="form-control" value="" />
                    </div>

                 <%--   <div class="col-sm-2" style="text-align: center">
                        <input id="second" type="button" value="获取验证码" class="btn btn-primary" data-value="1" />
                        

                    </div>--%>

                    <p class="error-msg"></p>
                </div>

        
                                <div class="form-group">

                <div class="col-sm-8 col-sm-offset-3">
                    <input id="event_submit_do_regist" class="btn btn-primary form-control" style="padding-bottom:30px;" type="button" value="提交" name="event_submit_do_regist" />
                </div>
                </div>
                 
            </form>
        </div>
    </div>
    <script src="../../../js/jquery-1.10.2.min.js"></script>
    <script src="../../../js/md5.js"></script>
    <script src="../../../js/jquery.min.js"></script>
    <script src="../../../js/bootstrap.min.js?v=3.3.6"></script>
<%--    <script src="js/content.js"></script>--%>

    <%--    <script src="js/jquery.validate.min.js"></script>--%>
    <script src="js/jquery-validate.js"></script>
    <script src="js/messages_zh.min.js"></script>
    <script src="js/form-validate-demo.js"></script>
    <script src="js/stats.js"></script>
    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/jquery.form.js"></script>
    <%--    <script src="js/jquery-validate.js"></script>--%>
    <script>
        $("#getCode").click(function () {
            //修改data-value 以便于提交是判断是获取验证码而不是提交表单
            $("#getCode").attr("data-value", "2");
        });
        $("#event_submit_do_regist").click(function () {
                $("#signupForm").ajaxSubmit({
                    url: "?action=register",
                            type: "POST",
                            success: function (result) {
                               // var yyy = result;
                                //alert(result);
                                if (result == "1") {
                                   
                                    window.location.href = "../contract/apply_contract.aspx";
                                    alert('成功转为正式合同,将会跳转到合同管理页');

                                }
                                if (result == "0") //failed! username is not exist 
                                {
                                    layer.msg('失败！', function () {
                                        //关闭后的操作
                                    });
                                    return false;
                                }
                            }
                });
            //修改data-value 以便于提交是判断是获取验证码而不是提交表单
            //$("#getCode").attr("data-value", "1");
        });
        //$("#event_submit_do_regist").click(function () {
        //    $("#signupForm").validate({
        //        submitHandler: function (form) {
        //            $(form).ajaxSubmit();
        //        }
        //    })
        //});
        //$("#event_submit_do_regist").click(function () {
        //    $("#signupForm").ajaxSubmit({
        //        url: "?action=register",
        //                type: "POST",
        //                success: function (result) {
        //                    var yyy = result;
        //                    alert(result);
        //                    if (result == "1") {

        //                        window.location.href = "../login/login.aspx";
        //                        alert('注册成功,将会跳转到登录界面');

        //                    }
        //                    if (result == "0") //failed! username is not exist 
        //                    {
        //                        layer.msg('用户名或密码错误！', function () {
        //                            //关闭后的操作
        //                        });
        //                        return false;
        //                    }
        //                }
        //    });
        //});
        //$("#event_submit_do_regist").click(function () {
        function edit_info() {

            $.ajax({
                url: "?action=register",
                data: $('#signupForm').serialize(),
                type: "POST",
                success: function (result)
                {
                    if (result == "1") {
                          window.location.href = "../contract/apply_contract.aspx";
                                    alert('成功转为正式合同,将会跳转到合同管理页');


                    }
                    if (result == "0") //failed! username is not exist 
                    {
                        layer.msg('失败！', function () {
                            //关闭后的操作
                        });
                        return false;
                    }
                   

                }
            });




        };





    </script>

    <script type="text/javascript">


      
        var count = 60; //间隔函数，1秒执行
        var InterValObj1; //timer变量，控制时间
        var curCount1;//当前剩余秒数
     
        $("#second").click(function () {
            curCount1 = count;
            //设置button效果，开始计时
            $("#second").attr("disabled", "true");
            $("#second").val(+curCount1 + "秒再获取");
            InterValObj1 = window.setInterval(SetRemainTime1, 1000); //启动计时器，1秒执行一次
             sendyzm($("#second"));
            layer.msg('短信已发送！');
            
           
        });
        function SetRemainTime1() {
            if (curCount1 == 0) {
                window.clearInterval(InterValObj1);//停止计时器
                $("#second").removeAttr("disabled");//启用按钮
                $("#second").val("重新发送");
            }
            else {
                curCount1--;
                $("#second").val(+curCount1 + "秒再获取");
            }
        }
        //用ajax提交到后台的发送短信接口
        function sendyzm(obj) {
          

            $.ajax({
                url: "?action=aaa&&phone=" + $("#phone").val(),
                type: "POST",
                success: function (result) {
                    if (result == "1") {

                     
                    }
                    if (result == "0") //failed! username is not exist 
                    {
                        layer.msg('短信发送失败！', function () {
                            //关闭后的操作
                        });
                        return false;
                    }


                }
            });



        }
    </script>
</body>
</html>
