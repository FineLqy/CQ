<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternetEquipAdd.aspx.cs" Inherits="CORSV2.forms.administrator.information.InternetEquipAdd" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="../../../themes/css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
</head>
<body class="gray-bg">
    <div class="col-sm-6">
        <div class="ibox float-e-margins" style="height: 95%; border: 1px solid #e2e0e0">
            <div class="ibox-content" style="height: 100%">
                <form class="form-horizontal m-t" id="Form" runat="server" style="height: 100%">
                    <div class="form-group" style="margin-top: 5%">
                        <label class="col-sm-3 control-label">设备名：</label>
                        <div class="col-sm-8">
                            <input id="MachineName" name="MachineName" runat="server" class="form-control" type="text" aria-required="true" aria-invalid="true">
                         
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 1%">
                        <label class="col-sm-3 control-label">IP：</label>
                        <div class="col-sm-8">
                            <input id="IP" runat="server" name="IP" class="form-control" type="text">
                        
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 1%">
                        <label class="col-sm-3 control-label">端口：</label>
                        <div class="col-sm-8">
                            <input id="Port" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" required="required" runat="server" maxlength="11" minlength="11" name="phone" class="form-control" aria-required="true" aria-invalid="true" type="text">
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 1%">
                        <label class="col-sm-3 control-label">标识：</label>
                        <div class="col-sm-8">
                            <input id="Logo" name="Logo" runat="server" class="form-control" type="text">
          
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 1%">
                        <label class="col-sm-3 control-label">用途：</label>
                        <div class="col-sm-8">
                            <input id="EUse" runat="server" name="EUse" class="form-control" type="text">
                        
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 1%">
                        <label class="col-sm-3 control-label">备注：</label>
                        <div class="col-sm-8">
                            <textarea id="Remark" name="Remark" style="width: 100%; height: 80px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px" runat="server">
                               
                            </textarea>
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 1%">
                        <div class="col-sm-8 col-sm-offset-3">
                               <button class="btn btn-sm btn-primary" id="save" type="button" style="margin-left: 45%;width:12%">添加</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>




    <!-- 全局js -->
    <script src="../../../js/jquery.min.js?v=2.1.4"></script>
    <script src="../../../js/bootstrap.min.js?v=3.3.6"></script>
    <script src="../../../js/plugins/layer/layer.min.js"></script>
       <script src="../../../js/jquery.form.js"></script>
    <script>
        $("#save").click(function () {

            var MachineName = document.getElementById("MachineName");
            var IP = document.getElementById("IP");
            var Port = document.getElementById("Port");
            var Logo = document.getElementById("Logo");
            var EUse = document.getElementById("EUse");
            var Remark = document.getElementById("Remark");
            if (MachineName.value.trim() == "")
            {
                layer.alert('请输入设备名', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (IP.value.trim() == "") {
                layer.alert('请输入IP', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            else
            {
                var re = /^(\d+)\.(\d+)\.(\d+)\.(\d+)$/;//正则表达式   
                if (re.test(IP.value)) {
                    if (RegExp.$1 < 256 && RegExp.$2 < 256 && RegExp.$3 < 256 && RegExp.$4 < 256)
                    { }
                    else {
                        layer.alert('存储IP地址格式错误', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                }
                else {
                    layer.alert('存储IP地址格式错误', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            }
            if (Port.value.trim() == "") {
                layer.alert('请输入端口', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }

            $.ajax({
                type:"POST",
                url: "?action=save",
                data: $("#Form").serialize(),
                success: function (result) {
                    if (result == "1") {
                        layer.alert('添加成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        parent.$("#refreshequip").click();
                    }
                    else if (result == "2") {
                        layer.alert('设备已存在', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                    else {
                        layer.alert('添加失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                },
                error: function () {
                    layer.alert('添加失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            })
        });
        
    </script>
</body>

</html>
