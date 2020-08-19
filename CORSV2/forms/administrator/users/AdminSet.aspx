<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminSet.aspx.cs" Inherits="CORSV2.forms.administrator.users.AdminSet" %>

<!DOCTYPE html>

<head>
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">


    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="../../../themes/css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">


</head>

<body class="gray-bg">
            <div class="col-sm-6" style="width:100%;">
                <div class="ibox float-e-margins" style="height:95%;border:1px solid #e2e0e0">
                    <div class="ibox-title">
                     
                        
                    </div>
                    <div class="ibox-content" style="height:100%">
                        <form class="form-horizontal m-t" id="signupForm" runat="server" style="height:100%">

                            <div class="form-group" style="margin-top:5%">
                                <label class="col-sm-3 control-label">用户名：</label>
                                <div class="col-sm-8">
                                    <input id="userName" readonly="readonly" name="userName" runat="server" class="form-control" type="text" aria-required="true" aria-invalid="true">
                                 <span class="help-block m-b-none" style="color:red" id="ts"> </span>
                                </div>
                            </div>
                            <div class="form-group" style="margin-top:5%">
                                <label class="col-sm-3 control-label">所属区域：</label>
                                <div class="col-sm-8">
                                    <input id="belongArea" readonly="readonly" name="belongArea" runat="server" class="form-control" type="text" aria-required="true" aria-invalid="true">
                                
                                </div>
                            </div>
                             <div class="form-group" style="padding-top:1%">
                                <label class="col-sm-3 control-label">旧密码：</label>
                                <div class="col-sm-8">
                                    <input id="oldPassword" runat="server" readonly="readonly" name="oldPassword" class="form-control" type="text">
                                </div>
                            </div>
                            <div class="form-group" style="padding-top:1%">
                                <label class="col-sm-3 control-label">新密码：</label>
                                <div class="col-sm-8">
                                    <input id="password" runat="server" name="password" class="form-control" type="password">
                                </div>
                            </div>
                            <div class="form-group" style="padding-top:1%">
                                <label class="col-sm-3 control-label">确认新密码：</label>
                                <div class="col-sm-8">
                                    <input id="confirm_password" runat="server" name="confirm_password" class="form-control" type="password">
                                    <span class="help-block m-b-none"><i class="fa fa-info-circle"></i> 请再次输入您的新密码</span>
                                </div>
                            </div>                       

                            <div class="form-group" style="padding-top:1%">
                                <div class="col-sm-8 col-sm-offset-3">
                                    <button type="button" style="margin-left:40%" id="add" onclick="addfun()" class="btn btn-success">修改</button>
     
                                
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>




    <!-- 全局js -->
    <script src="../../../js/jquery.min.js?v=2.1.4"></script>
    <script src="../../../js/bootstrap.min.js?v=3.3.6"></script>

    <!-- 自定义js -->
    <%--<script src="../../../js/content.js?v=1.0.0"></script>--%>

    <!-- jQuery Validation plugin javascript-->
    <script src="../../../js/plugins/validate/jquery.validate.min.js"></script>
    <script src="../../../js/plugins/validate/messages_zh.min.js"></script>

    <script src="../../../js/demo/form-validate-demo.js"></script>
       <script src="../../../js/plugins/layer/layer.min.js"></script>

    <!-- layerDate plugin javascript -->
    <script src="../../../js/plugins/layer/laydate/laydate.js"></script>
    <script>
        function addfun() {
            var user = document.getElementById("userName");
            var pass = document.getElementById("password");
            var compass = document.getElementById("confirm_password");
            var old = document.getElementById("oldPassword");
            if (compass.value != pass.value) {
                layer.alert('两次密码输入不一致', {
                    skin: 'layui-layer-lan' //样式类名
                    , closeBtn: 0
                });
            }
            else {
                var id = document.getElementById("Ids");
                $.post("/forms/administrator/users/AdminSet.aspx?action=" + user.value.toString().trim() + "}" + pass.value.toString().trim(), function (result) {
                    if (result == "1") {
                        layer.alert('修改成功', {
                            skin: 'layui-layer-lan' //样式类名
                        , closeBtn: 0
                        });
                        old.value = pass.value;
                        pass.value = "";
                        compass.value = "";
                    }
                    else {
                        layer.alert('修改失败', {
                            skin: 'layui-layer-lan' //样式类名
                        , closeBtn: 0
                        });
                    }

                })
            }
        }

    </script>
</body>

</html>
