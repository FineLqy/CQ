<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlPointInfo.aspx.cs" Inherits="CORSV2.forms.administrator.system.ControlPointInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">


    <title>控制点信息管理</title>



    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="../../../themes/css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
</head>

<body>
    <div class="wrapper wrapper-content animated fadeIn">
        <form runat="server" method="post" id="Form">

            <div class="col-sm-6" style="width: 100%">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>控制点信息</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="panel-body">
                            <div class="panel-group" id="accordion">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">1</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseOne">站址信息</a>
                                        </h5>
                                    </div>
                                    <div id="collapseOne" class="panel-collapse collapse in">

                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">点名</label>
                                            <input type="text" id="MarkName" readonly="readonly" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">点号</label>
                                            <input type="text" id="MarkID" readonly="readonly" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">标志是否完好</label>
                                            <select name="BZ" id="BZ" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 20%">
                                                <option>完好</option>
                                                <option>被拆</option>
                                                <option>破坏</option>
                                            </select>
                                            <input type="text" style="display: none" runat="server" id="pointid" />
                                        </div>
                                        <div class="hr-line-dashed"></div>

                                        <div>
                                            <label style="width: 10%; text-align: center">平面坐标精度等级</label>
                                            <select name="account" id="AccuracyClass" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 20%">
                                                <option>A级</option>
                                                <option>B级</option>
                                                <option>C级</option>
                                                <option>D级</option>
                                                <option>未知</option>
                                            </select>

                                            <label style="width: 10%; text-align: center">高程精度等级</label>
                                            <select name="account" id="GCgrade" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 20%">
                                                <option>一等</option>
                                                <option>二等</option>
                                                <option>三等</option>
                                                <option>四等</option>
                                                <option>未知</option>
                                            </select>
                                            <label style="width: 10%; text-align: center">点之记</label>
                                            <input type="text" id="PointRemark" runat="server" readonly="readonly" style="width: 10%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <input type="button" id="viewPointRemark" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="查看" />
                                            <input type="button" id="browerPointRemark" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="浏览" onclick="FilePointRemark.click()" />
                                            <input type="button" id="uploadPointRemark" disabled="disabled" runat="server" style="width: 4%;" class="btn btn-xs btn-white" value="上传" />
                                            <input id="FilePointRemark" type="file" runat="server" style="display: none; height: 1px; width: 1px" accept="image/*" />

                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">纬度</label>
                                            <input type="text" name="B" id="B" runat="server"  style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">经度</label>
                                            <input type="text" name="L" id="L" runat="server"   style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">高度（米）</label>
                                            <input type="text" id="H" name="H" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
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

    </div>

    <!-- 全局js -->
    <script src="../../../js/jquery.min.js?v=2.1.4"></script>
    <script src="../../../js/bootstrap.min.js?v=3.3.6"></script>
    <script src="../../../js/jquery.form.js"></script>
    <!-- 自定义js -->
    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/layer/laydate/laydate.js"></script>
    <script>


        $("#FilePointRemark").change(function () {
            var PointRemark = document.getElementById("PointRemark");
            var filPointRemark = document.getElementById("FilePointRemark");
            if (filPointRemark.files.length > 0) {
                PointRemark.value = filPointRemark.files[0].name;
            }
            else {
                PointRemark.value = "";
            }
            var upload = document.getElementById("uploadPointRemark");
            if (PointRemark.value != "") {

                upload.disabled = false;
            }
            else { upload.disabled = true; }
        });



        $("#uploadPointRemark").click(function () {
            var FilePointRemark1 = document.getElementById("FilePointRemark");
            var FilePointRemark2 = FilePointRemark1.value;
            var extStart = FilePointRemark2.lastIndexOf(".");
            var ext = FilePointRemark2.substring(extStart, FilePointRemark2.length).toUpperCase();
            if (ext != ".BMP" && ext != ".PNG" && ext != ".GIF" && ext != ".JPG" && ext != ".JPEG") {

                layer.alert('点之记为png,gif,jpeg,jpg格式图片！', {
                    skin: 'layui-layer-lan' //样式类名
                                 , closeBtn: 0
                });
                var PointRemark = document.getElementById("PointRemark");
                PointRemark.value = "";
                return false;
            }


            var isIE = /msie/i.test(navigator.userAgent) && !window.opera;
            var fileSize = 0;
            if (isIE && !FilePointRemark1.files) {
                var filePath = FilePointRemark1.value;
                var fileSystem = new ActiveXObject("Scripting.FileSystemObject");
                var file = fileSystem.GetFile(filePath);
                fileSize = file.Size;
            } else {
                fileSize = FilePointRemark1.files[0].size;
            }
            var size = fileSize / 1024;
            if (size > 2000) {
                layer.alert('图片大小不能超过2M！', {
                    skin: 'layui-layer-lan' //样式类名
                                                         , closeBtn: 0
                });
                var PointRemark = document.getElementById("PointRemark");
                PointRemark.value = "";
                return false;

            }


            var options = {
                url: "?upload=PointRemark",
                success: function (result) {
                    if (result == "1") {
                        layer.alert('上传成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        var upload = document.getElementById("uploadPointRemark");
                        upload.disabled = true;
                        var PointRemark = document.getElementById("PointRemark");
                        var filPointRemark = document.getElementById("FilePointRemark");
                        var viewPointRemark = document.getElementById("viewPointRemark");
                        var MarkName = document.getElementById("MarkName");
                        var suffix = filPointRemark.files[0].name.split('.')[filPointRemark.files[0].name.split('.').length - 1];
                        PointRemark.value = "/upload/PointRemark/" + MarkName.value.trim() + "." + suffix;
                        viewPointRemark.disabled = false;
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

        $("#viewPointRemark").click(function () {
            var PointRemark = document.getElementById("PointRemark");
            layer.open({
                type: 2,
                title: '点之记',
                shadeClose: true,
                shade: 0.8,
                area: ['40%', '60%'],
                content: '../information/ViewPic.aspx?src=' + PointRemark.value //iframe的url
            });
        });

        $("#save").click(function () {
            var MarkName = document.getElementById("MarkName");
            if (MarkName.value.trim() == "") {
                layer.alert('请输入点名', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            var MarkID = document.getElementById("MarkID");
            if (MarkID.value.trim() == "") {
                layer.alert('请输入点号', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }


            var lat = document.getElementById("B");
            if (lat.value == "") {
                layer.alert('请输入纬度', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (isNaN(lat.value)) {
                layer.alert('纬度格式输入错误', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            var lon = document.getElementById("L");
            if (lon.value == "") {
                layer.alert('请输入经度', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (isNaN(lon.value)) {
                layer.alert('经度格式输入错误', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }

            var h = document.getElementById("H");
            if (h.value == "") {
                layer.alert('请输入高度', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (isNaN(h.value)) {
                layer.alert('高度格式输入错误', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }

            $.ajax({
                type: "POST",
                url: "?action=save",
                data: $("Form").serialize(),
                asnyc: true,
                success: function (result) {
                    if (result == "1") {
                        layer.alert('保存成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        var index = parent.layer.getFrameIndex(window.name); //获取窗口索引

                        parent.$("#refresh").click();
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
        })
    </script>
</body>
</html>
