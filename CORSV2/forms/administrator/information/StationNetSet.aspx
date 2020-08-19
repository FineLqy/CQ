<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StationNetSet.aspx.cs" Inherits="CORSV2.forms.administrator.information.StationNetSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>


    <title>站网信息管理</title>


    <link href="../../../themes/css/plugins/chosen/chosen.css" rel="stylesheet" />
    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet"/>
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet"/>
    <link href="../../../themes/css/plugins/iCheck/custom.css" rel="stylesheet"/>
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
                                            <span class="label label-info">1</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseOne">站网基本信息</a>
                                        </h5>
                                    </div>
                                    <div id="collapseOne" class="panel-collapse collapse in">

                                        <div class="hr-line-dashed"></div>
                                        <div>
                                       
                                            <label style="width: 10%; text-align: center">站网名称</label>
                                            <input type="text" id="NetName" readonly="readonly" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">站点数量</label>
                                            <input type="text" id="Number" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">建设完成时间</label>
                                            <input class=" layer-date" id="BuildTime" runat="server" style="width: 20%; height: 32px; vertical-align: top; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px; max-width: none" placeholder="YYYY-MM-DD hh:mm:ss" onclick="laydate({ istime: true, format: 'YYYY-MM-DD hh:mm:ss' })">
                                            <label class="laydate-icon" style="width: 2%; height: 32px; vertical-align: top"></label>
                                            <input type="text" style="display: none" runat="server" id="netid" />
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <label style="width: 10%; text-align: center">站点分布示意图</label>
                                        <input type="text" id="DistributionDiagram" runat="server" readonly="readonly" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        <input type="button" id="viewDistributionDiagram" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="查看" />
                                        <input type="button" id="browerDistributionDiagram" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="浏览" onclick="FileDistributionDiagram.click()" />
                                        <input type="button" id="uploadDistributionDiagram" disabled="disabled" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="上传" />
                                        <input id="FileDistributionDiagram" type="file" runat="server" style="display: none; height: 1px; width: 1px" accept="image/*" onchange="DistributionDiagram.value=this.value;" />


                                        <div class="hr-line-dashed"></div>

                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">2</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseTwo">服务接入信息</a>
                                        </h5>
                                    </div>
                                    <div id="collapseTwo" class="panel-collapse collapse in">
                                        <div class="hr-line-dashed"></div>
                                        <div>


                                            <label style="width: 10%; text-align: center">IP</label>
                                            <input type="text" id="IP" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">

                                            <label style="width: 10%; text-align: center">端口</label>
                                            <input type="text" id="Port" runat="server" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">源节点</label>
                                            <input type="text" id="SourceNode" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">网络协议</label>
                                            <select name="account" id="NetworkProtocol" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 20%">
                                                <option>TCP/IP</option>
                                                <option>Ntrip</option>
                                            </select>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">3</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseThree">应用服务信息</a>
                                        </h5>
                                    </div>
                                    <div id="collapseThree" class="panel-collapse collapse in">
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <input type="text" runat="server" id="SysSelect" style="display:none" />

                                            <label style="width: 10%; text-align: center">数据格式</label>
                                            <input type="text" id="DataFormat" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">

                                            <label style="width: 10%; text-align: center">卫星系统</label>
                                            <select data-placeholder="选择卫星系统" id="SatelliteSystem" class="chosen-select" multiple="multiple" style="width: 78%;" tabindex="4">
                                                <option value="110000" runat="server" id="Beidou" hassubinfo="true">Beidou</option>
                                                <option value="120000" runat="server" id="GPS" hassubinfo="true">GPS</option>
                                                <option value="130000" runat="server" id="Galileo" hassubinfo="true">Galileo</option>
                                                <option value="140000" runat="server" id="Glonass" hassubinfo="true">Glonass</option>
                                            </select>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center; vertical-align: top">应用服务内容</label>
                                            <textarea id="ServiceContent" name="ServiceContent" style="width: 81%; height: 120px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px" runat="server">
                               
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
    <script src="../../../js/jquery.form.js"></script>
    <!-- 自定义js -->
    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/layer/laydate/laydate.js"></script>
    <script src="../../../js/plugins/chosen/chosen.jquery.js"></script>
    <script>



        $("#FileDistributionDiagram").change(function () {
            var DistributionDiagram = document.getElementById("DistributionDiagram");
            var filDistributionDiagram = document.getElementById("FileDistributionDiagram");
            if (filDistributionDiagram.files.length > 0) {
                DistributionDiagram.value = filDistributionDiagram.files[0].name;
            }
            else {
                DistributionDiagram.value = "";
            }
            var upload = document.getElementById("uploadDistributionDiagram");
            if (DistributionDiagram.value != "") {

                upload.disabled = false;
            }
            else { upload.disabled = true; }
        });


        $("#uploadDistributionDiagram").click(function () {

            var DistributionDiagram1 = document.getElementById("FileDistributionDiagram");
            var DistributionDiagram2 = DistributionDiagram1.value;
            var extStart = DistributionDiagram2.lastIndexOf(".");
            var ext = DistributionDiagram2.substring(extStart, DistributionDiagram2.length).toUpperCase();
            if (ext != ".BMP" && ext != ".PNG" && ext != ".GIF" && ext != ".JPG" && ext != ".JPEG") {

                layer.alert('站点分布示意图为png,gif,jpeg,jpg格式图片！', {
                    skin: 'layui-layer-lan' //样式类名
                                 , closeBtn: 0
                });
                var DistributionDiagram = document.getElementById("DistributionDiagram");
                DistributionDiagram.value = "";
                return false;
            }


            var isIE = /msie/i.test(navigator.userAgent) && !window.opera;
            var fileSize = 0;
            if (isIE && !DistributionDiagram1.files) {
                var filePath = DistributionDiagram1.value;
                var fileSystem = new ActiveXObject("Scripting.FileSystemObject");
                var file = fileSystem.GetFile(filePath);
                fileSize = file.Size;
            } else {
                fileSize = DistributionDiagram1.files[0].size;
            }
            var size = fileSize / 1024;
            if (size > 2000) {
                layer.alert('图片大小不能超过2M！', {
                    skin: 'layui-layer-lan' //样式类名
                                                         , closeBtn: 0
                });
                var DistributionDiagram = document.getElementById("DistributionDiagram");
                DistributionDiagram.value = "";
                return false;

            }

            var options = {
                url: "StationNetSet.aspx?upload=DistributionDiagram",
                success: function (result) {
                    if (result == "1") {
                        layer.alert('上传成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        var DistributionDiagram = document.getElementById("DistributionDiagram");
                        var filDistributionDiagram = document.getElementById("FileDistributionDiagram");
                        var NetName = document.getElementById("NetName");
                        var viewDistributionDiagram = document.getElementById("viewDistributionDiagram");
                        var suffix = filDistributionDiagram.files[0].name.split('.')[filDistributionDiagram.files[0].name.split('.').length - 1];
                        DistributionDiagram.value = "/upload/DistributionDiagram/" + NetName.value.trim() + "." + suffix;
                        viewDistributionDiagram.disabled = false;

                    }
                    else {
                        layer.alert('上传失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                }, error: function () {
                    layer.alert('上传失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            };
            $("#Form").ajaxSubmit(options);
            // $("#Form").ajaxForm(options);
        });

        $("#viewDistributionDiagram").click(function () {
            var DistributionDiagram = document.getElementById("DistributionDiagram");
            parent.layer.open({
                type: 2,
                title: '站点分布示意图',
                shadeClose: true,
                shade: 0.8,
                area: ['70%', '70%'],
                content: 'ViewPic.aspx?src=' + DistributionDiagram.value //iframe的url
            });
        });
        $("#save").click(function () {
            var NetName = document.getElementById("NetName");
            if (NetName.value.trim() == "") {
                layer.alert('请输入站网名', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            var Number = document.getElementById("Number");
            if (Number.value.trim() == "") {
                layer.alert('请输入站点数量', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }

            var ip = document.getElementById("IP");
            if (ip.value.trim() != "") {
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
            var port = document.getElementById("Port");
            if (port.value == "") {
                layer.alert('请输入端口', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }

            if (ip.value == "") {
                layer.alert('请输入IP地址', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }

            var SourceNode = document.getElementById("SourceNode");
            if (SourceNode.value == "") {
                layer.alert('请输入源节点', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            var SatelliteSystem = document.getElementById("SatelliteSystem");
            if (SatelliteSystem.value == "") {
                layer.alert('请选择卫星系统', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }


            var BuildTime = document.getElementById("BuildTime");
            if (BuildTime.value == "") {
                layer.alert('请输入建设完成时间', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }

            var sys = $(".chosen-choices").html();
            var SYS = delHtmlTag(sys);
            $.ajax({
                type: "POST",
                url: "?action=save&&sysdata="+SYS,
                data: $("Form").serialize(),
                asnyc: true,
                success: function (result) {
                    if (result == "1") {
                        layer.alert('保存成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        var index = parent.layer.getFrameIndex(window.name); //获取窗口索引

                        parent.$("#refreshsta").click();
                        //parent.layer.close(index);
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
        });
        function delHtmlTag(str) {
            return str.replace(/<[^>]+>/g, " ");//去掉所有的html标记
        }
        $(document).ready(function () {
            var sys="<%=sysselect%>";
            var syss=sys.toString();
            
            if(syss.indexOf("Beidou")!=-1)  
            {
                var beidou = document.getElementById("Beidou");
                beidou.selected = true;
            }
            if(syss.indexOf("GPS")!=-1)  
            {
                var GPS = document.getElementById("GPS");
                GPS.selected = true;
            }
            if(syss.indexOf("Galileo")!=-1)  
            {
                var Galileo = document.getElementById("Galileo");
                Galileo.selected = true;
            }
            if(syss.indexOf("Glonass")!=-1)  
            {
                var Glonass = document.getElementById("Glonass");
                Glonass.selected = true;
            }
            
            var config = {
                '.chosen-select': {
                    width: "30%"
                },
                '.chosen-select-deselect': {
                    allow_single_deselect: true
                },
                '.chosen-select-no-single': {
                    disable_search_threshold: 10
                },
                '.chosen-select-no-results': {
                    no_results_text: 'Oops, nothing found!'
                },
                '.chosen-select-width': {
                    width: "95%"
                }
            }
            for (var selector in config) {
                $(selector).chosen(config[selector]);
            }

        });
    </script>
</body>
</html>
