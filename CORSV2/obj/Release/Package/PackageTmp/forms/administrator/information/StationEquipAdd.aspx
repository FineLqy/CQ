<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StationEquipAdd.aspx.cs" Inherits="CORSV2.forms.administrator.information.StationEquipAdd" %>

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
                             <select id="MachineName" runat="server" class="form-control">
                                 <option>接收机</option>
                                 <option>天线类型</option>
                                 <option>气象仪类型</option>
                                 <option>原子钟类型</option>
                                 <option>交换机类型</option>
                                 <option>路由器类型</option>
                                 <option>防火墙类型</option>
                                 <option>防雷设备类型</option>
                                 <option>终端计算机类型</option>
                             </select>
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 1%">
                        <label class="col-sm-3 control-label">型号：</label>
                        <div class="col-sm-8">
                            <input id="Models" runat="server" name="Models" class="form-control" type="text">
                        
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 1%">
                        <label class="col-sm-3 control-label">序列号：</label>
                        <div class="col-sm-8">
                            <input id="SerialNumber" required="required" runat="server" name="SerialNumber" class="form-control" aria-required="true" aria-invalid="true" type="text">
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 1%">
                        <label class="col-sm-3 control-label">标识：</label>
                        <div class="col-sm-8">
                            <input class=" layer-date form-control" id="InstallationDate" runat="server" style="width:90%;max-width:none" placeholder="YYYY-MM-DD hh:mm:ss" onclick="laydate({ istime: true, format: 'YYYY-MM-DD hh:mm:ss' })">
                            <label class="laydate-icon" style="width: 5%; height: 34px; vertical-align: top"></label>
                                
                        </div>
                    </div>
                   
                    <div class="form-group" style="padding-top: 1%">
                        <div class="col-sm-8 col-sm-offset-3">
                               <button class="btn btn-sm btn-primary" id="save" type="button" style="margin-left: 43%;width:15%">添加</button>
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
     <script src="../../../js/plugins/layer/laydate/laydate.js"></script>
       <script src="../../../js/jquery.form.js"></script>
    <script>
        $("#save").click(function () {

           

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
