<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteMonitoring.aspx.cs" Inherits="CORSV2.forms.administrator.information.SiteMonitoring" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>基站监测</title>
    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="../../../themes/css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
</head>

<body>
        <form runat="server" method="post" id="Formsite">
            <div class="col-sm-6" style="width: 100%">
                <div class="ibox float-e-margins">
                    <div class="ibox-content">
                        <div class="panel-body">
                            <div class="panel-group" id="accordion">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">1</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseOne">接收卫星状态</a>
                                        </h5>
                                    </div>
                                    <div id="collapseOne" class="panel-collapse collapse in">

                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">卫星的类型</label>
                                            <input type="text" id="SatelliteType" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">编号</label>
                                            <input type="text" id="Numbering" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">轨迹</label>
                                            <input type="text" id="Track" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>

                                        <div>
                                             <label style="width: 10%; text-align: center">数量</label>
                                            <input type="text" id="Quantity" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">高度角</label>
                                            <input type="text" id="Angle" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                           <label style="width: 10%; text-align: center">时间</label>
                                            <input class=" layer-date" id="Time" runat="server" style="width: 20%; height: 32px; vertical-align: top; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px; max-width: none" placeholder="YYYY-MM-DD hh:mm:ss" onclick="laydate({ istime: true, format: 'YYYY-MM-DD hh:mm:ss' })">
                                            <label class="laydate-icon" style="width: 2%; height: 32px; vertical-align: top"></label>

                                          
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                          <div>
                                            <label style="width: 10%; text-align: center">信噪比</label>
                                            <input type="text" id="Ratio" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                           <input type="text" id="StationOName" runat="server" style="display:none; width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                          
                                          </div>
                                        <div class="hr-line-dashed"></div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">2</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseTwo">接收机存储状态</a>
                                        </h5>
                                    </div>
                                    <div id="collapseTwo" class="panel-collapse collapse in">
                                        <div class="hr-line-dashed"></div>

                                        <div>
                                            <label style="width: 10%; text-align: center">存储功能可用性</label>
                                             <select name="StorageEable" id="StorageEable" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 20%">
                                                <option>可用</option>
                                                <option>不可用</option>
                                            </select>
                                            <label style="width: 10%; text-align: center">设计容量</label>
                                            <input type="text" id="DesignCapacity" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">已用存储空间</label>
                                            <input type="text" id="UsedstorageSpace" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">可用存储空间</label>
                                            <input type="text" id="AvailablestorageSpace"  runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">可用存储空间百分比</label>
                                            <input type="text" readonly="readonly" id="AvailablestorageSpaceRate" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                       </div>
                                      
                                        <div class="hr-line-dashed"></div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">3</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseThree">设备电气参数状态</a>
                                        </h5>
                                    </div>
                                    <div id="collapseThree" class="panel-collapse collapse in">
                                      <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">接收机温度</label>
                                            <input type="text" id="ReceiverTemperature"  runat="server" style="width: 14%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">接收机电压</label>
                                            <input type="text" id="ReceiverVoltage" runat="server" style="width: 14%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">接收机电量</label>
                                            <input type="text" id="ReceiverElectricity" runat="server" style="width: 14%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">接收机CPU占用率</label>
                                            <input type="text" id="ReceiverCPU"  runat="server" style="width: 14%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                           
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                         <div>
                                             <label style="width: 10%; text-align: center">气象仪温度</label>
                                            <input type="text" id="WeatherTemperature"  runat="server" style="width: 14%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">气象仪电压</label>
                                            <input type="text" id="WeatherVoltage" runat="server" style="width: 14%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">气象仪电量</label>
                                            <input type="text" id="WeatherElectricity" runat="server" style="width: 14%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">气象仪CPU占用率</label>
                                            <input type="text" id="WeatherCPU"  runat="server" style="width: 14%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                         </div>
                                        <div class="hr-line-dashed"></div>
                                         <div>
                                             <label style="width: 10%; text-align: center">UPS温度</label>
                                            <input type="text" id="UPSTemperature"  runat="server" style="width: 14%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">UPS电压</label>
                                            <input type="text" id="UPSVoltage" runat="server" style="width: 14%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">UPS电量</label>
                                            <input type="text" id="UPSElectricity" runat="server" style="width: 14%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">UPSCPU占用率</label>
                                            <input type="text" id="UPSCPU"  runat="server" style="width: 14%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
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
                    }
                    else {
                        layer.alert('保存失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                    }
                },
                error: function () {
                    layer.alert('保存失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                }
            })
        })
    </script>
</body>
</html>

