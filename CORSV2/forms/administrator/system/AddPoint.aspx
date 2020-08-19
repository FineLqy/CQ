<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPoint.aspx.cs" Inherits="CORSV2.forms.administrator.system.AddPoint" %>
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
                        <label class="col-sm-3 control-label">点名：</label>
                        <div class="col-sm-8">
                            <input id="MarkName" name="MarkName" runat="server" class="form-control" type="text" aria-required="true" aria-invalid="true">
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 1%">
                        <label class="col-sm-3 control-label">点号：</label>
                        <div class="col-sm-8">
                            <input id="MarkID" runat="server" name="MarkID" class="form-control" type="text">
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 1%">
                        <label class="col-sm-3 control-label">标志是否完好：</label>
                        <div class="col-sm-8">
                            <select name="BZ" id="BZ" runat="server" class="form-control" style="height: auto">
                                <option>完好</option>
                                <option>被拆</option>
                                <option>破坏</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 1%">
                        <label class="col-sm-3 control-label">平面坐标精度等级：</label>
                        <div class="col-sm-8">
                            <select name="AccuracyClass" id="AccuracyClass" runat="server" class="form-control" style="height: auto">
                                <option>A级</option>
                                <option>B级</option>
                                <option>C级</option>
                                <option>D级</option>
                                <option>未知</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 1%">
                        <label class="col-sm-3 control-label">高程精度等级：</label>
                        <div class="col-sm-8">
                            <select name="GCgrade" id="GCgrade" runat="server" class="form-control" style="height: auto">
                                <option>一等</option>
                                <option>二等</option>
                                <option>三等</option>
                                <option>四等</option>
                                <option>未知</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 1%">
                        <label class="col-sm-3 control-label">纬度：</label>
                        <div class="col-sm-8">
                            <input id="B" runat="server" name="B" class="form-control" type="text">
                        </div>
                        </div>
                        <div class="form-group" style="padding-top: 1%">
                            <label class="col-sm-3 control-label">经度：</label>
                            <div class="col-sm-8" >
                                <input id="L" runat="server" name="L" class="form-control" type="text">
                            </div>
                            </div>
                            <div class="form-group" style="padding-top: 1%">
                                <label class="col-sm-3 control-label">高度：</label>
                                <div class="col-sm-8">
                                    <input id="H" runat="server" name="H"  class="form-control" type="text">
                                </div>
                            </div>
                            <div class="form-group" style="padding-top: 1%">
                                <div class="col-sm-8 col-sm-offset-3">
                                    <button class="btn btn-sm btn-primary" id="save" type="button" style="margin-left: 45%; width: 12%">添加</button>
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


            var options = {
                url: "?action=save",
                success: function (result) {
                    if (result == "1") {
                        layer.alert('添加成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        var index = parent.layer.getFrameIndex(window.name); //获取窗口索引

                        parent.$("#refresh").click();
                        parent.$("#addnew").click();
                        parent.layer.close(index);
                    }
                    else {
                        if (result == "2") {
                            layer.alert('控制点已存在', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                        }
                        else {
                            layer.alert('添加失败', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                        }

                    }
                },
                error: function () {
                    layer.alert('保存失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                }
            };
            $("#Form").ajaxSubmit(options);

        })

    </script>
</body>

</html>

