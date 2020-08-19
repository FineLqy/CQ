<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElevationTrans.aspx.cs" Inherits="CORSV2.forms.publicforms.dataprocess.ElevationTrans" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">


<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <!--360浏览器优先以webkit内核解析-->


    <title>高程转换</title>

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
                            <h5>高程转换</h5>
                        </div>
                        <div class="ibox-content no-padding">
                            <div class="panel-body">

                                <div class="panel panel-default">
                                    <div class="panel-collapse collapse in">

                                        <div class="panel-body">
                                            <form runat="server" id="Form">

                                                <div style="border: 1px solid; border-color: silver; margin-top: 3px; padding: 20px; width: 100%; height: auto; float: left">
                                                    <div style="margin-top: 10px">
                                                        <span>项目名称：&nbsp &nbsp &nbsp &nbsp &nbsp </span>
                                                        <input style="margin-left: 10%" class="form-control" type="text" runat="server" id="ProjectName" />
                                                    </div>
                                                    <div style="margin-top: 10px">
                                                        <span id="CM">中央子午线经度（dms）：</span><input style="margin-left: 5%; width: 50%" type="text" runat="server" onkeypress="return (/[\d.]/.test(String.fromCharCode(event.keyCode)))" class="form-control" data-val="true" data-val-number="字段 X必须是一个数字。" data-val-regex="只能输入数字。" data-val-regex-pattern="^(\d+(\.\d+)?+\s)|(\-1)$" data-val-required="X字段是必需的。" id="OM" value="" readonly="readonly" />
                                                        <select runat="server" id="CMSelect" style="width: 20%" class="form-control">
                                                            <option>默认
                                                            </option>
                                                            <option>手动输入
                                                            </option>
                                                        </select>
                                                    </div>
                                                    <div style="margin-top: 10px; display: none">
                                                        <span id="sx">起始北坐标(m)：</span><input style="margin-left: 10%" type="text" runat="server" onkeypress="return (/[\d.]/.test(String.fromCharCode(event.keyCode)))" class="form-control" data-val="true" data-val-number="字段 X必须是一个数字。" data-val-regex="只能输入数字。" data-val-regex-pattern="^(\d+(\.\d+)?+\s)|(\-1)$" data-val-required="X字段是必需的。" id="OX" value="0" />
                                                    </div>
                                                    <div style="margin-top: 10px; display: none">
                                                        <span id="sy">起始东坐标(m)：</span><input style="margin-left: 10%" type="text" runat="server" onkeypress="return (/[\d.]/.test(String.fromCharCode(event.keyCode)))" class="form-control" data-val="true" data-val-number="字段 Y必须是一个数字。" data-val-regex="只能输入数字。" data-val-regex-pattern="^(\d+(\.\d+)?+\s)|(\-1)$" data-val-required="Y字段是必需的。" id="OY" value="500000" />
                                                    </div>
                                                    <div style="margin-top: 10px; display: none">
                                                        <span id="sz">投影抬高(m)：&nbsp &nbsp</span><input style="margin-left: 10%" type="text" runat="server" onkeypress="return (/[\d.]/.test(String.fromCharCode(event.keyCode)))" class="form-control" data-val="true" data-val-number="字段 Y必须是一个数字。" data-val-regex="只能输入数字。" data-val-regex-pattern="^(\d+(\.\d+)?+\s)|(\-1)$" data-val-required="Y字段是必需的。" id="OZ" value="0" />
                                                    </div>

                                                    <div style="margin-top: 10px">
                                                        <span>上传坐标类型：</span>
                                                        <select runat="server" id="CoorType" style="margin-left: 10%" class="form-control">
                                                            <option>BLH
                                                            </option>
                                                           <%-- <option>XYZ
                                                            </option>--%>
                                                            <option>xyH
                                                            </option>
                                                        </select>
                                                    </div>
                                                    <div style="margin-top: 10px">
                                                        <span>成果压缩类型：</span>
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
                                                        <span style="float: left">上传坐标文件：</span>
                                                        <input id="Text1" type="text" readonly="readonly" class="form-control" style="width: 60%; margin-left: 10%" />
                                                        <input id="Button1" type="button" value="选择文件" style="height: 34px" class="btn btn-default" onclick="DUODFILE.click()" />
                                                    </div>
                                                    <div style="margin-top: 5%">
                                                        <button id="TransBtn" class="btn btn-success" type="button" style="margin-left: 35%;">&nbsp 转&nbsp&nbsp 换 &nbsp</button>
                                                        <label id="resulttext" runat="server" style="color: red; display: none"></label>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-default" Style="margin-left: 10%;" OnClick="LinkButton1_Click">成果下载</asp:LinkButton>

                                                        <asp:FileUpload ID="DUODFILE" accept=".txt" runat="server" Style="visibility: hidden;" onchange="Text1.value=this.value" />
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
                                                data-url="ELevationTrans.aspx?action=GetData"
                                                data-smart-display="false">
                                                <thead>
                                                    <tr>
                                                        <th data-field="UserName">用户名</th>
                                                        <th data-field="ProjectName">项目名称</th>
                                                        <th data-field="Type">数据处理类型</th>
                                                        <th data-field="deTime">数据处理时间</th>
                                                         <th data-field="Amount">转点个数</th>
                                                         <th data-field="Cost">转点费用</th>
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
                        <h5>高程转换功能说明</h5>
                    </div>
                    <div class="ibox-content">
                        <p>我们提供多点转换功能</p>
                        <p style="color: red">注意进行多点转换前请仔细阅读以下注意事项：</p>
                        <ol>
                            <li>本平台仅提供重庆市行政区域内统一的高精度高程转换服务，超出范围将无法转换</li>
                            <li>本平台默认带号仅提供3度带转换，默认带号则按照3度带计算</li>
                            <li>每点收费叁拾元整，不足十个点按十个点收费</li>
                            <li>本平台支持的坐标格式有以下三类：<br />
                                <%--（1）笛卡尔坐标系(XYZ)<br />--%>
                                （1）大地坐标系(BLH)<br />
                                （2）高斯平面坐标系(xyH)<br />
                            </li>
                            <li>大地坐标系格式为经纬度，如37°24′43.2134″输入为37.24432134</li>
                            <li>高斯平面坐标系需要加带号</li>
                            <li>源坐标文件保存为txt格式并以单位简写命名如：地理信息中心（DLXXZX.txt）<a href="/Product/example.txt" target="_blank" onclick="">事例参考</a>
                            </li>

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
        $("#CMSelect").change(function () {
            var OM = document.getElementById("OM");
            var cmselect = document.getElementById("CMSelect")
            if (cmselect.value.trim() == "默认") {
                OM.value = "";
                OM.readOnly = true;
            }
            else {
                OM.readOnly = false;
                OM.value = "102";
            }
        })

        $("#TransBtn").click(function () {
            if ($("resulttext").val() == "转换中") {
                layer.alert('正在转换中请稍后', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            else {
                //对输入信息进行判断
                if ($("#ProjectName").val().trim() == "") {
                    layer.tips('项目名称不能为空', '#ProjectName', {
                        tips: [2, '#a94442']
                    });
                    $("#ProjectName").focus();
                    return false;
                }
                if ($("#OM").val().trim() == "") {

                    if ($("#CMSelect").val().trim() == "默认") { }
                    else
                    {
                        layer.tips('中央子午线经度不能为空', '#OM', {
                            tips: [2, '#a94442']
                        });
                        $("#OM").focus();
                        return false;
                    }
                }
                if ($("#OX").val().trim() == "") {
                    layer.tips('起始北坐标不能为空', '#OX', {
                        tips: [2, '#a94442']
                    });
                    $("#OX").focus();
                    return false;
                }
                if ($("#OY").val().trim() == "") {
                    layer.tips('起始东坐标不能为空', '#OY', {
                        tips: [2, '#a94442']
                    });
                    $("#OY").focus();
                    return false;
                }
                if ($("#OZ").val().trim() == "") {
                    layer.tips('投影抬高不能为空', '#OZ', {
                        tips: [2, '#a94442']
                    });
                    $("#OZ").focus();
                    return false;
                }
                if ($("#Text1").val().trim() == "") {
                    layer.tips('请选择坐标文件', '#Text1', {
                        tips: [2, '#a94442']
                    });
                    $("#Text1").focus();
                    return false;
                }
                layer.confirm('本系统只提供3度带转换，默认带号则按照3度带计算，请确认！', {
                    btn: ['确定', '取消'] //按钮
                }, function () {
                    if ($("#resulttext").val() == "转换中") {
                        layer.msg('已提交请稍后！');
                        return false;
                    }

                    $("#resulttext").val("转换中");
                    checkInput();
                    var options = {
                        url: "ElevationTrans.aspx?action=Trans",
                        success: function (result) {
                            if (result == "-1") {
                                $("#resulttext").val("");
                                layer.alert('贵单位无坐标转换权限', {
                                    skin: 'layui-layer-lan', //样式类名,
                                });
                                return false;
                            }
                            if (result == "0") {
                                $("#resulttext").val("");
                                layer.alert('上传文件格式错误', {
                                    skin: 'layui-layer-lan', //样式类名,
                                });
                                return false;
                            }
                            if (result == "1") {
                                $("#resulttext").val("");
                                layer.alert('余额不足', {
                                    skin: 'layui-layer-lan', //样式类名,
                                });
                                return false;
                            }
                            if (result == "2") {
                                $("#resulttext").val("");
                                layer.alert('初始数据错误请检查', {
                                    skin: 'layui-layer-lan', //样式类名,
                                });
                                return false;
                            }
                            if (result == "3") {
                                $("#resulttext").val("");
                                layer.alert('转换类型错误，转换失败', {
                                    skin: 'layui-layer-lan', //样式类名,
                                });
                                return false;
                            }
                            if (result.indexOf(".result") >= 0) {
                                //resultfile.value = result;
                                //downloadresult.disabled = false;
                                layer.alert('转换成功', {
                                    skin: 'layui-layer-lan', //样式类名,
                                });
                                $("#LinkButton1").attr("style", "background-color: #5cb85c;border-color: #4cae4c;margin-left: 10%;color:white");
                                $("#resulttext").val("");
                                var table = $("#table");
                                table.bootstrapTable('refresh');
                                return false;
                            }

                        }, error: function () {
                            layer.alert('转换失败', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            $("#resulttext").val("");
                            return false;
                        }
                    };
                    $("#Form").ajaxSubmit(options);
                }, function () {
                    layer.msg('取消成功', {
                    });
                });
            }
        })
        function checkInput() {
            var file = document.getElementById("DUODFILE");
            var fileValue = file.value.substring(file.value.lastIndexOf("."));
            if (fileValue.toLowerCase() != ".txt") {
                layer.alert('请上传指定格式文件', {
                    skin: 'layui-layer-lan' //样式类名
                                , closeBtn: 0
                });
                return false;
            }
        }

        function CreatModel(c, x, y) {
            var model = {};
            model.x = y;
            model.y = x;
            model.Z = 0;
            model.PointNO = c;
            return model;
        }

        $(document).ready(function () {
            var table = $("#table");
            table.bootstrapTable();
        });
    </script>

</body>

</html>
