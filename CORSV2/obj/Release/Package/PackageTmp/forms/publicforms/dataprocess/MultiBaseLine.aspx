<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultiBaseLine.aspx.cs" Inherits="CORSV2.forms.publicforms.dataprocess.MultiBaseLine" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<!DOCTYPE html>
<html>

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <!--360浏览器优先以webkit内核解析-->


    <title>静态平差解算</title>

    <link rel="shortcut icon" href="favicon.ico">
    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet">

    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
    <style>
        .form-control,
        .single-line {
            background-color: #FFFFFF;
            background-image: none;
            border: 1px solid #e5e6e7;
            border-radius: 1px;
            color: inherit;
            display: inline;
            padding: 6px 12px;
            -webkit-transition: border-color 0.15s ease-in-out 0s, box-shadow 0.15s ease-in-out 0s;
            transition: border-color 0.15s ease-in-out 0s, box-shadow 0.15s ease-in-out 0s;
            width: 70%;
            font-size: 14px;
        }

            .form-control:focus,
            .single-line:focus {
                border-color: #1c84c6 !important;
            }
    </style>
</head>

<body class="gray-bg">

    <div class="wrapper wrapper-content">
        <div class="row">
            <div class="col-sm-4" style="width: 75%">
                <div>
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>静态平差解算</h5>
                        </div>
                        <div class="ibox-content no-padding">
                            <div class="panel-body">

                                <div class="panel panel-default">
                                    <div class="panel-collapse collapse in">

                                        <div class="panel-body">
                                            <form runat="server" id="Form">

                                                <div class="panel panel-default">
                                                    <div class="panel-collapse collapse in">

                                                        <div class="panel-body">
                                                            <div style="margin-top: 10px">
                                                                <span>项目名称： </span>
                                                                <input style="margin-left: 10%" class="form-control" type="text" runat="server" id="ProjectName" />
                                                                <input type="text" id="resulttext" style="display: none" />
                                                            </div>

                                                            
                                                <div style="margin-top: 10px"">
                                                    <span>成果坐标系:</span>

                                                    <select id="model" runat="server" class="form-control" style="margin-left: 10%">
                                                        <option value="CGCS2000">CGCS2000坐标系</option>
                                                        <option value="BEIJING1954">1954北京坐标系</option>
                                                        <option value="XIAN1980">1980西安坐标系</option>

                                                    </select>

                                                </div>
                                                            <div style="margin-top: 10px">
                                                                 <span>采样率： </span>
                                                                <input style="margin-left: 10%;" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" class="form-control" type="text" runat="server" id="Interval" />
                                                                </div>
                                                            <div style="margin-top: 10px">
                                                               
                                                                <span>观测开始时间： </span>
                                                                <input style="margin-left: 8%;width:25%" class="form-control"  type="text" runat="server" id="StartTime" />
                                                                  <span style="padding-left:7%">观测结束时间： </span>
                                                                <input style="margin-left: 5%;width:25%" class="form-control"  type="text" runat="server" id="EndTime" />
                                                            </div>
                                                             <div style="margin-top: 10px">
                                                                <span>概率坐标 &nbsp&nbsp X： </span>
                                                                <input style="margin-left: 7%;width:16%" class="form-control"  type="text" runat="server" id="X" />
                                                                  <span style="padding-left:5%">Y： </span>
                                                                <input style="margin-left: 4%;width:16%" class="form-control"  type="text" runat="server" id="Y" />
                                                                  <span style="padding-left:5%">Z： </span>
                                                                <input style="margin-left: 4%;width:16%" class="form-control"  type="text" runat="server" id="Z" />
                                                            </div>
                                                            <br />
                                                            <div class="input-append input-group" style="display: inline;">
                                                                <span style="float: left">观测文件：</span>
                                                                <input id="Text1" type="text" readonly="readonly" class="form-control" style="width: 60%; margin-left: 10%" />
                                                                <input id="Button1" type="button" value="选择文件" style="height: 34px" class="btn btn-default" onclick="DUODFILE.click()" />

                                                            </div>
                                                            <div style="align-content: center; margin-left: 25%; margin-top: 3%">
                                                                <button type="button" id="BtnSave" style="width: 15%; margin-left: 18%" class="btn btn-success">文件解算</button>
                                                       <asp:FileUpload ID="DUODFILE" accept="" runat="server" Style="visibility: hidden;" onchange="Text1.value=this.value" />
                                                     
                                                                         </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default" style="margin-top: 1%">
                                    <div class="panel-collapse collapse in">
                                        <div class="panel-body">
                                            <table id="table"
                                                data-search="false"
                                                data-search-text=""
                                                data-show-refresh="false"
                                                data-show-toggle="false"
                                                data-show-columns="false"
                                                data-detail-view="false"
                                                data-striped="true"
                                                data-minimum-count-columns="1"
                                                data-show-pagination-switch="false"
                                                data-pagination="true"
                                                data-page-size="10"
                                                data-id-field="ID"
                                                data-unique-id="ID"
                                                data-page-list="[10, 25, 50, 100]"
                                                data-show-footer="false"
                                                data-side-pagination="server"
                                                data-url="BaseLine.aspx?action=GetData"
                                                data-smart-display="false">
                                                <thead>
                                                    <tr>
                                                        <th data-field="UserName">用户名</th>
                                                        <th data-field="ProjectName">项目名称</th>
                                                        <th data-field="Type">数据处理类型</th>
                                                        <th data-field="deTime">数据处理时间</th>
                                                         <th data-field="Amount">解算个数</th>
                                                         <th data-field="Cost">解算费用</th>
                                                        <th data-field="Result">数据处理结果</th>
                                                        <th data-field="Remark">备注</th>
                                                         <th data-field="BtnDownload">下载</th>
                                                    </tr>
                                                </thead>

                                            </table>
                                        </div>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-4" style="width: 25%">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>静态平差解算功能说明</h5>
                    </div>
                    <div class="ibox-content">
                        <p>我们提供静态平差解算功能，单点转换需上传指定格式的观测文件，我们会实时下载准备文件进行解算</p>
                        <p style="color: red">注意进行静态平差解算前请仔细阅读以下注意事项：</p>
                        <ol>
                            <li>上传文件格式说明：上传文件格式必须Rinex2.0或Rinex2.1的观测文件</li>
                            <li>采用SITEDOY0.YYo的格式，SITE为4位， 不要求是数字还是字母，DOY为准确的年积日，YY位年，例如2016，则为16，最后一位为o或者O。如:lxbz1230.16o</li>
                            <li>本系统为事后静态平差解算处理</li>
                            <li>解算过程时间持续一段时间，请于上传成功两天后登陆系统下载成果文件</li>
                        </ol>
                    </div>
                </div>
            </div>



        </div>
    </div>


    <!-- 全局js -->
    <script src="../../../js/jquery.min.js?v=2.1.4"></script>
    <script src="../../../js/bootstrap.min.js?v=3.3.6"></script>
    <script src="../../../js/plugins/layer/layer.min.js"></script>

    <script src="../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script src="../../../js/jquery.form.js"></script>
    <!-- 自定义js -->

    <script>
        function downloads(thisid) {
            window.location.href = "?action=DownLoad&&id=" + thisid;
        }

        $("#BtnSave").click(function () {
            if ($("resulttext").val() == "转换中") {
                layer.alert('正在上传中请稍后', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            else {
                if ($("#Text1").val().trim() == "") {
                    layer.tips('请选择观测文件', '#Text1', {
                        tips: [2, '#a94442']
                    });
                    $("#Text1").focus();
                    return false;
                }
                if ($("#ProjectName").val().trim() == "") {
                    layer.tips('项目名称不能为空', '#ProjectName', {
                        tips: [2, '#a94442']
                    });
                    $("#ProjectName").focus();
                    return false;
                }
                if ($("#Interval").val().trim() == "") {
                    layer.tips('采样率不能为空', '#Interval', {
                        tips: [2, '#a94442']
                    });
                    $("#Interval").focus();
                    return false;
                }
                if ($("#X").val().trim() == "") {
                    layer.tips('X不能为空', '#X', {
                        tips: [2, '#a94442']
                    });
                    $("#X").focus();
                    return false;
                }
                if ($("#Y").val().trim() == "") {
                    layer.tips('Y不能为空', '#Y', {
                        tips: [2, '#a94442']
                    });
                    $("#Y").focus();
                    return false;
                }
                if ($("#Z").val().trim() == "") {
                    layer.tips('Z不能为空', '#Z', {
                        tips: [2, '#a94442']
                    });
                    $("#Z").focus();
                    return false;
                }
                if ($("#StartTime").val().trim() == "") {
                    layer.tips('观测开始时间不能为空', '#StartTime', {
                        tips: [2, '#a94442']
                    });
                    $("#StartTime").focus();
                    return false;
                }
                if ($("#EndTime").val().trim() == "") {
                    layer.tips('观测结束时间不能为空', '#EndTime', {
                        tips: [2, '#a94442']
                    });
                    $("#EndTime").focus();
                    return false;
                }
                $("#resulttext").val("转换中");
                layer.msg('正在上传中，请稍后', { time: 10000 });
                var options = {
                    url: "MultiBaseLine.aspx?action=PPP",
                    success: function (result) {
                        if (result == "-1") {
                            $("resulttext").val("");
                            layer.alert('贵单位无数据处理权限', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            return false;
                        }
                        if (result == "0") {
                            $("resulttext").val("");
                            layer.alert('上传失败！', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            return false;
                        }
                        if (result == "1") {
                            $("#resulttext").val("");
                            layer.alert('文件命名错误！', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            return false;
                        }
                        if (result == "2") {
                            layer.alert('上传成功，请于两日后下载成果！', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            $("#resulttext").val("");

                            var table = $("#table");
                            table.bootstrapTable('refresh');
                            return false;
                        }
                        if (result == "5") {
                            $("#resulttext").val("");
                            layer.alert('观测文件错误！', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            return false;
                        }
                        if (result == "6") {
                            $("#resulttext").val("");
                            layer.alert('观测时段格式错误！', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            return false;
                        }
                        if (result == "7") {
                            $("#resulttext").val("");
                            layer.alert('概略坐标格式错误！', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            return false;
                        }
                    }, error: function () {
                        layer.alert('上传失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        $("#resulttext").val("");
                        return false;
                    }
                };
                $("#Form").ajaxSubmit(options);
            }

        })

        $(document).ready(function () {
            var table = $("#table");
            table.bootstrapTable();
        });
    </script>

</body>

</html>
