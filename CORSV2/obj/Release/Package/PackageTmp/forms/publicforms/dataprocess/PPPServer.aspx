<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PPPServer.aspx.cs" Inherits="CORSV2.forms.publicforms.dataprocess.PPPServer" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">


<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <!--360浏览器优先以webkit内核解析-->


    <title>精密单点定位</title>

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
                            <h5>精密单点定位</h5>
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
                                                            <div style="margin-top: 10px">
                                                                <span>成果压缩：</span>
                                                                <select runat="server" id="Encryption" style="margin-left: 10%" class="form-control">
                                                                    <option>采用用户名进行加密压缩
                                                                    </option>
                                                                    <option>采用秘密进行加密压缩
                                                                    </option>
                                                                    <option>不压缩
                                                                    </option>

                                                                </select>
                                                            </div>
                                                            <br />
                                                            <div class="input-append input-group" style="display: inline;">
                                                                <span style="float: left">观测文件：</span>
                                                                <input id="Text1" type="text" readonly="readonly" class="form-control" style="width: 60%; margin-left: 10%" />
                                                                <input id="Button1" type="button" value="选择文件" style="height: 34px" class="btn btn-default" onclick="DUODFILE.click()" />

                                                            </div>
                                                            <div style="align-content: center; margin-left: 20%; margin-top: 3%">
                                                                <button type="button" style="width: 15%; background-color: red; border-color: red" class="btn btn-success" id="BtnCheck">质量检核</button>
                                                                <button type="button" id="BtnSave" style="width: 15%; margin-left: 13%" class="btn btn-success">文件解算</button>
                                                                <%--<button type="button" id="BtnDownload" style="margin-left: 13%; width: 15%" class="btn btn-default">成果下载</button>
                                                              --%>  
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-default" Style="width: 15%;margin-left: 13%;" OnClick="LinkButton1_Click">成果下载</asp:LinkButton>
                                                                <asp:FileUpload ID="DUODFILE" accept=".*o" runat="server" Style="visibility: hidden;" onchange="Text1.value=this.value" />
                                                               <%-- <input type="text" id="downloadpath" style="display: none" />--%>
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
                                                data-url="PPPServer.aspx?action=GetData"
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
                        <h5>单点定位功能说明</h5>
                    </div>
                    <div class="ibox-content">
                        <p>我们提供事后单点定位功能，单点转换需上传指定格式的观测文件，我们会实时下载星历文件进行解算</p>
                        <p style="color: red">注意进行单点定位前请仔细阅读以下注意事项：</p>
                        <ol>
                            <li>上传文件格式说明：上传文件格式必须Rinex2.0或Rinex2.1的观测文件</li>
                            <li>采用SITEDOY0.YYo的格式，SITE为4位， 不要求是数字还是字母，DOY为准确的年积日，YY位年，例如2016，则为16，最后一位为o或者O。如:lxbz1230.16o</li>
                            <li>本系统为事后PPP处理，仅提供两天以前的数据进行处理</li>
                            <li>解算过程时间持续一段时间，在页面刷新后请等待30秒再下载成果文件</li>
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
            //$.ajax( {
            //    url: "MultiPonit.aspx",
            //    type:"POST",
            //    data: {
            //        id: thisid,
            //        action: "DownLoad"
            //    },
            //    success:function(){}
            //})
            window.location.href = "?action=DownLoad&&id=" + thisid;
        }
        $("#BtnCheck").click(function () {
            if ($("resulttext").val() == "转换中") {
                layer.alert('正在质量检核中请稍后', {
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
                $("#resulttext").val("转换中");
                layer.msg('正在检核中，请稍后', { time: 5000 });
                var options = {
                    url: "PPPServer.aspx?action=check",
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
                            layer.alert('检测失败', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            return false;
                        }
                        if (result == "1") {
                            $("#resulttext").val("");
                            layer.alert('初始数据错误请检查', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            return false;
                        }
                        if (result.indexOf(".report") >= 0) {
                            layer.alert('检核成功，请下载检核报告！', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            $("#LinkButton1").attr("style", "background-color: #5cb85c;border-color: #4cae4c;margin-left: 13%;color:white;width: 15%;");
                            $("#resulttext").val("");
                            //$("#downloadpath").val(result);

                            return false;
                        }


                    }, error: function () {
                        layer.alert('检测失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        $("#resulttext").val("");
                        return false;
                    }
                };
                $("#Form").ajaxSubmit(options);
            }
        })

        $("#BtnSave").click(function () {
            if ($("resulttext").val() == "转换中") {
                layer.alert('正在解算中请稍后', {
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
                $("#resulttext").val("转换中");
                layer.msg('正在解算中，请稍后', { time: 15000 });
                var options = {
                    url: "PPPServer.aspx?action=PPP",
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
                            layer.alert('解算失败！', {
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
                            $("#resulttext").val("");
                            layer.alert('天线文件不存在，无法解算！', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            return false;
                        }
                        if (result == "3") {
                            $("#resulttext").val("");
                            layer.alert('星历文件不存在，无法解算！', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            return false;
                        }
                        if (result.indexOf(".pos") >= 0) {
                            layer.alert('解算成功，请下载成果！', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            $("#LinkButton1").attr("style", "background-color: #5cb85c;border-color: #4cae4c;margin-left: 13%;color:white;width: 15%;");
                            $("#resulttext").val("");
                            //$("#downloadpath").val(result);
                            var table = $("#table");
                            table.bootstrapTable('refresh');
                            return false;
                        }


                    }, error: function () {
                        layer.alert('解算失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        $("#resulttext").val("");
                        return false;
                    }
                };
                $("#Form").ajaxSubmit(options);
            }

        })
        //$("#BtnDownload").click(function () {
        //    $.ajax({
        //        url: "PPPServer.aspx",
        //        type: "POST",
        //        data: {
        //            action: "DownloadAll",
        //            file: $("#downloadpath").val()
        //        },
        //        success: function (result) {
        //            if (result == "0") {
        //                layer.alert('下载失败', {
        //                    skin: 'layui-layer-lan', //样式类名,
        //                });
        //                $("#resulttext").val("");
        //                return false;
        //            }
        //        },
        //        error: function () {
        //            layer.alert('下载失败', {
        //                skin: 'layui-layer-lan', //样式类名,
        //            });
        //            $("#resulttext").val("");
        //            return false;
        //        }

        //    })

        //    $("#BtnDownload").blur();
        //});
        $(document).ready(function () {
            var table = $("#table");
            table.bootstrapTable();
        });
    </script>

</body>

</html>
