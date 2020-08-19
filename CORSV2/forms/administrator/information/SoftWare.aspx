<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SoftWare.aspx.cs" Inherits="CORSV2.forms.administrator.information.SoftWare" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>软件管理</title>
    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="../../../themes/css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
</head>
<body>
  
        <form runat="server" method="post" id="Form">
            <div class="col-sm-6" style="width: 100%">
                <div class="ibox float-e-margins">
                    <div class="ibox-content">
                        <div class="panel-body">
                            <div class="panel-group" id="accordion">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">1</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseOne">基本信息</a>
                                        </h5>
                                    </div>
                                    <div id="collapseOne" class="panel-collapse collapse in">

                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">软件名</label>
                                            <input type="text" id="SoftWareName" readonly="readonly" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">软件类型</label>
                                            <input type="text" id="SoftWareType" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">编号</label>
                                            <input type="text" id="Num" runat="server" readonly="readonly" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>

                                            <label style="width: 10%; text-align: center">版本号</label>
                                            <input type="text" id="dType" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                    
                                            <label style="width: 10%; text-align: center">IP</label>
                                            <input type="text" id="IP" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                    
                                             <label style="width: 10%; text-align: center">配置</label>
                                            <input type="text" id="Config" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                    
                                            <input  type="text" id="IDS" style="display:none" runat="server"/>
                                        </div> 
                                         <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center; vertical-align: top">维护信息</label>
                                            <textarea id="Maintenance" name="Maintenance" style="width: 81%; height: 80px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px" runat="server">
                               
                                            </textarea>
                                        </div>
                                    <div class="hr-line-dashed"></div>
                                        <button class="btn btn-sm btn-primary" type="button" style="margin-left: 45%;width:8%" id="save">保存</button>
                                        <div class="hr-line-dashed"></div>
                 
                                    </div>
                                </div>
                                
                      
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>

    <!-- 全局js -->
    <script src="../../../js/jquery.min.js?v=2.1.4"></script>
    <script src="../../../js/bootstrap.min.js?v=3.3.6"></script>

    <script src="../../../js/plugins/validate/jquery.validate.min.js"></script>
    <script src="../../../js/plugins/validate/messages_zh.min.js"></script>

    <!-- 自定义js -->
    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/layer/laydate/laydate.js"></script>
    <script>
        $("#save").click(function () {
            
            var ip = document.getElementById("IP");
            if (ip.value == "") {
                layer.alert('请输入IP地址', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (ip.value.trim() != "")
            {
                var re = /^(\d+)\.(\d+)\.(\d+)\.(\d+)$/;//正则表达式   
                if (re.test(ip.value)) {
                    if (RegExp.$1 < 256 && RegExp.$2 < 256 && RegExp.$3 < 256 && RegExp.$4 < 256)
                    { }
                    else {
                        layer.alert('IP地址格式错误', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                }
                else {
                    layer.alert('IP地址格式错误', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            }

            
            $.ajax({
                type: "POST",
                url: "?action=save",
                data: $("Form").serialize(),
                asnyc: true,
                success: function (result)
                {
                    if (result == "1") {
                        layer.alert('保存成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        parent.$("#refreshsta").click();
                    }
                    else if (result == "2") {
                        layer.alert('序列号已存在', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                    else {
                        layer.alert('保存失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                },
                error: function () {
                    layer.alert('保存失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            })
        })
    </script>
</body>
</html>
