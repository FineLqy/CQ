<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userinfo.aspx.cs" Inherits="CORSV2.forms.publicforms.login.userinfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
    <link href="../../../themes/css/ucenter.css" rel="stylesheet" />
    <link href="../../../themes/css/uniform.default.css" rel="stylesheet" />
        <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
    <link href="../../../themes/css/style-userinfo.css" rel="stylesheet" />
    <link href="../../../themes/css/style-responsive.css" rel="stylesheet" />
    <link href="../../../themes/css/light.css" rel="stylesheet" />

    <!-- END THEME STYLES -->
</head>
<body>
    <form id="form1" runat="server">
        <!-- BEGIN DASHBOARD STATS -->
        <div class="form-body">
            <div class="row">
                <div class="col-md-12">
                    <h4>基本资料</h4>
                </div>
            </div>
            <hr>
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-2 text-center">
                       <img style="max-width: 120px; width: 100%;" src="../../../themes/icon/个人信息_o.png" />
                    </div>
                    <div class="col-md-10">
                        <p>登录账号 ：<span  id="userName" runat="server"></span></p>
                        <p>
                            账号等级 ：<span  id="userType" runat="server"></span>				
                        </p>
                        <p>
                            资质认证情况 ：
							<span class="text-error" id="qualificationStatus" runat="server">未认证</span>
                        </p>
                        <p>注册时间 ：<span id="registerTime" runat="server"></span></p>
                    </div>
                </div>
            </div>
            <hr>
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-2 text-center">
                        <p><b>登录密码</b></p>
                    </div>
                    <div class="col-md-7">
                        <p>安全性高的密码可以使帐户更安全。建议您定期更换密码，设置一个包含字母，符号或数字中至少两项且长度超过6位的密码。</p>
                    </div>
                    <div class="col-md-3">
                        <p><span class="text-success"><i style="font-size: 18px" class="fa fa-check-circle-o"></i>已设置 </span>| <a href="changepassword.aspx">修改</a></p>
                    </div>
                </div>
            </div>
            <hr>
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-2 text-center">
                        <b>手机绑定</b>
                    </div>
                    <div class="col-md-7">
                        <p>您已绑定了手机<span id="phone" runat="server" class="text-success"></span></p>
                    </div>
                    <div class="col-md-3">
                        <p><span class="text-success"><i style="font-size: 18px" class="fa fa-check-circle-o"></i>已设置 </span>| <a href="UpdatePhone.aspx">修改</a></p>
                    </div>
                </div>
            </div>
            <hr>
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-2 text-center">
                        <b>邮箱绑定</b>
                    </div>
                    <div class="col-md-7">
                        <p>您已绑定了邮箱<span id="email" runat="server" class="text-success"></span></p>
                    </div>
                     <div class="col-md-3">
                        <p><span class="text-success"><i style="font-size: 18px" class="fa fa-check-circle-o"></i>已设置 </span>| <a href="UpdateE_mail.aspx">修改</a></p>
                    </div>
                </div>
            </div>
                        <hr>
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-2 text-center">
                        <b>公司绑定</b>
                    </div>
                    <div class="col-md-7">
                        <p>您已绑定了<span id="company" runat="server" class="text-success"></span></p>
                    </div>
                       <div class="col-md-3" id="company_update" runat="server">
                        <p><span class="text-success"><i style="font-size: 18px" class="fa fa-check-circle-o"></i>已设置 </span></p>
                    </div>
                </div>
            </div>
            <hr />
               <div  id="RechargeBtn" runat="server" class="row">
                <div class="col-md-12">
                    <div class="col-md-2 text-center">
                        <b>余额</b>
                    </div>
                    <div class="col-md-7">
                        <p><span id="Balance" runat="server" class="text-success"></span>元</p>
                    </div>
                       <div class="col-md-3" id="Div1" runat="server">
                        <p><span class="text-success" visible="True"><a href="Recharge.aspx">充值</a></span></p>
                    </div>
                </div>
            </div>
            <!--/row-->
        </div>
        <!-- END DASHBOARD STATS -->
    </form>

    
    <script src="../../../js/jquery-1.10.2.min.js"></script>
    <script src="../../../js/md5.js"></script>
    <script src="../../../js/jquery.min.js"></script>
    <script src="../../../js/bootstrap.min.js?v=3.3.6"></script>

   





    
</body>
</html>
