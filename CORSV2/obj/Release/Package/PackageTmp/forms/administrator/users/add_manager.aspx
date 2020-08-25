<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_manager.aspx.cs" Inherits="CORSV2.forms.administrator.users.add_manager" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">


<head>
    <title>添加系统管理员</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>


    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet"/>
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet"/>
    <link href="../../../themes/css/plugins/iCheck/custom.css" rel="stylesheet"/>
    <link href="../../../themes/css/animate.css" rel="stylesheet"/>
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet"/>


</head>

<body class="gray-bg">
            <div class="col-sm-6" style="width:70%;height:95%;margin-left:15%;margin-top:3%">
                <div class="ibox float-e-margins" style="height:95%;border:1px solid #e2e0e0">
                    <div class="ibox-title">
                        <h5>添加审批管理员</h5>
                        
                    </div>
                    <div class="ibox-content" style="height:100%">
                        <form class="form-horizontal m-t" id="signupForm" runat="server" style="height:100%">

                            <div class="form-group" style="margin-top:5%">
                                <label class="col-sm-3 control-label">用户名：</label>
                                <div class="col-sm-8">
                                    <input id="username" name="username" runat="server" class="form-control" type="text" aria-required="true" aria-invalid="true" />
                                 <span class="help-block m-b-none" style="color:red" id="ts"> </span>
                                </div>
                            </div>
                            <div class="form-group" style="padding-top:1%">
                                <label class="col-sm-3 control-label">密码：</label>
                                <div class="col-sm-8">
                                    <input id="password" runat="server" name="password" class="form-control" type="password">
                                </div>
                            </div>
                            <div class="form-group" style="padding-top:1%">
                                <label class="col-sm-3 control-label">确认密码：</label>
                                <div class="col-sm-8">
                                    <input id="confirm_password" runat="server" name="confirm_password" class="form-control" type="password">
                                    <span class="help-block m-b-none"><i class="fa fa-info-circle"></i> 请再次输入您的密码</span>
                                </div>
                            </div>
                       
                              <div class="form-group" style="padding-top:1%">
                                   <label  class="col-sm-3 control-label" >作业区域：</label>
                                          <div class="col-sm-8">
                                    <select name="belongsarea" id="belong_area"  runat="server" class="form-control">
                                      <option value="重庆市">重庆市</option>

<%--                                        <option value="郑州市">郑州市</option>
                                        <option value="开封市">开封市</option>
                                        <option value="三门峡市">三门峡市</option>
                                        <option value="洛阳市">洛阳市</option>
                                        <option value="焦作市">焦作市</option>
                                        <option value="新乡市">新乡市</option>
                                        <option value="鹤壁市">鹤壁市</option>
                                        <option value="安阳市">安阳市</option>
                                        <option value="濮阳市">濮阳市</option>
                                        <option value="商丘市">商丘市</option>
                                        <option value="许昌市">许昌市</option>
                                        <option value="漯河市">漯河市</option>
                                        <option value="平顶山市">平顶山市</option>
                                        <option value="南阳市">南阳市</option>
                                        <option value="信阳市">信阳市</option>
                                        <option value="周口市">周口市</option>
                                        <option value="驻马店市">驻马店市</option>--%>
                                            </select> 

                                          </div>
                            </div>
                            <div class="form-group" style="padding-top:1%">
                                <div class="col-sm-8 col-sm-offset-3">
                                    <button  style="margin-left:40%" id="add" type="submit" class="btn btn-success">添加</button>
     
                                
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

<%--    <script src="../../../js/demo/form-validate-demo.js"></script>--%>
       <script src="../../../js/plugins/layer/layer.min.js"></script>
        <script src="../../../js/plugins/validate/form-validate-demo.js"></script>
    <!-- layerDate plugin javascript -->
    <script src="../../../js/plugins/layer/laydate/laydate.js"></script>
    <script>
        function edit_info() {
            var user = document.getElementById("username");
            var pass = document.getElementById("password");
            var belongs = document.getElementById("belong_area")
            $.post("?actionAdd=" + user.value.toString().trim() + "}" + pass.value.toString().trim() + "}" + belongs.value.trim(), function (result) {
                if (result == "1") {
                    layer.alert('添加成功', {
                        skin: 'layui-layer-lan' //样式类名
                    , closeBtn: 0
                    });
                }
                else {
                    if (result == "2") {
                        layer.alert('该用户已存在', {
                            skin: 'layui-layer-lan' //样式类名
                                                , closeBtn: 0
                        });
                    }
                    else {
                        layer.alert('添加失败', {
                            skin: 'layui-layer-lan' //样式类名
                        , closeBtn: 0
                        });
                    }
                }

            })
        }
        //function check() {
        //    var user = document.getElementById("username");
        //    var username = user.value.trim();
        //    $.get("dwglcl.aspx?action=check_" + username, function (result) {
        //        if (result == "1") {
        //            var cm = document.getElementById("ts");
        //            cm.innerText = "用户名不可用"
        //            user.focus();
        //            return;
        //        }
        //        else {
        //            var cm = document.getElementById("ts");
        //            cm.innerText = ""
        //        }
        //    })
        //}
    </script>
</body>

</html>
