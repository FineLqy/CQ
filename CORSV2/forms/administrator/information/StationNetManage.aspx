<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StationNetManage.aspx.cs" Inherits="CORSV2.forms.administrator.information.StationNetManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>站网信息管理</title>

    <link rel="shortcut icon" href="../../favicon.ico" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
    <link href="../../../themes/css/plugins/chosen/chosen.css" rel="stylesheet" />
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content  animated fadeInRight" style="padding-top:0px;">
        <div class="row" style="padding-left:0px;padding-right:0px;">
            <div class="col-sm-8" style="padding-left:0px;padding-right:0px;width: 100%;" >
                <div class="ibox">
                    <div class="ibox-content">
                        <div class="newstable" style="margin-top: 1%">

                            <div class="bars pull-left">
                                <div class="btn-group hidden-xs" id="toolbar" role="group">
                                    <button type="button" data-toggle="modal" data-target="#myModal4" data-placement="top" title="添加基站" class="btn btn-outline btn-default">
                                        <i class="fa fa-plus"></i>添加站网 
                                    </button>

                                    <button type="button" id="refreshsta" class="btn btn-outline btn-default" title="刷新基站列表">
                                        <i class="fa fa-refresh"></i>刷新
                                    </button>

                                    <button type="button" id="deletesta" class="btn btn-outline btn-default" data-toggle="tooltip" data-placement="top" title="删除">
                                        <i class="fa fa-trash-o"></i>删除
                                    </button>
                                    <form id="Form">
                                        <div class="modal inmodal" id="myModal4" tabindex="-1" role="dialog" aria-hidden="true">
                                            <div class="modal-dialog">
                                                <div class="modal-content animated fadeIn">
                                                    <div class="modal-header">
                                                        <h4 class="modal-title">添加站网</h4>
                                                    </div>
                                                    <div class="modal-body" style="background-color:#ffffff">

                                                        <label style="width: 15%; text-align: left; font-size: 15px;">站网名</label>
                                                        <input type="text" id="NetName" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">站点数量</label>
                                                        <input type="text" id="Number" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">网络协议</label>
                                                        <select name="NetworkProtocol" id="NetworkProtocol" style="width: 20px; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 78%">
                                                            <option>TCP/IP</option>
                                                            <option>Ntrip</option>
                                                        </select>
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">IP</label>
                                                        <input type="text" id="IP" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">端口</label>
                                                        <input type="text" id="Port" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">源节点</label>
                                                        <input type="text" id="SourceNode" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">卫星系统</label>
                                                       
                                                        <select data-placeholder="选择卫星系统" id="SatelliteSystem" class="chosen-select" multiple="multiple" style="width: 78%;" tabindex="4">
                                                                <option value="110000" hassubinfo="true">Beidou</option>
                                                                <option value="120000" hassubinfo="true">GPS</option>
                                                                <option value="130000" hassubinfo="true">Galileo</option>
                                                                <option value="140000" hassubinfo="true">Glonass</option>                                                               
                                                        </select>
                                                      


                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px; vertical-align: top;">应用服务内容</label>
                                                        <textarea id="ServiceContent" name="ServiceContent" style="width: 78%; height: 60px; font-size: 12px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px" runat="server" />
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-white" data-dismiss="modal">关闭</button>
                                                        <button type="button" id="addstationnet" class="btn btn-success">添加</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </form>
                                </div>
                            </div>

                            <table
                                id="table"
                                data-toolbar="#toolbar"
                                data-search="true"
                                data-show-refresh="false"
                                data-show-toggle="true"
                                data-show-columns="true"
                                data-show-export="false"
                                data-detail-view="false"
                                data-striped="true"
                                data-minimum-count-columns="1"
                                data-show-pagination-switch="true"
                                data-pagination="true"
                                data-page-size="10"
                                data-id-field="ID"
                                data-unique-id="ID"
                                data-page-list="[10, 25, 50, 100]"
                                data-show-footer="false"
                                data-side-pagination="server"
                                data-url="?action=GetData"
                                data-smart-display="false">
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="../../../js/jquery.min.js"></script>
    <script src="../../../js/bootstrap.min.js"></script>

    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script src="../../../js/plugins/chosen/chosen.jquery.js"></script>
      <script src="../../../js/jquery.form.js"></script>
    <script>

        var table = $("#table");

        $("#addstationnet").click(function () {
            var NetName = document.getElementById("NetName");
            var Number = document.getElementById("Number");
            var NetworkProtocol = document.getElementById("NetworkProtocol");
            var SourceNode = document.getElementById("SourceNode");
            var SatelliteSystem = document.getElementById("SatelliteSystem");
            var ServiceContent = document.getElementById("ServiceContent");
            if (NetName.value == "") {
                layer.alert('请输入站网名', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (Number.value == "") {
                layer.alert('请输入站点数量', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (NetworkProtocol.value == "") {
                layer.alert('请选择网络协议', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (SourceNode.value == "") {
                layer.alert('请输入源结点', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (SatelliteSystem.value == "") {
                layer.alert('请选择卫星系统', {
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
                var port = document.getElementById("Port");
                if (port.value == "") {
                    layer.alert('请输入端口', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            }

           
            var sys = $(".chosen-choices").html();
            var SYS = delHtmlTag(sys);

            var jsonStr = "{\"NetName\":\"" + NetName.value + "\",\"NetworkProtocol\":\"" + NetworkProtocol.value + "\",\"Number\":\"" + Number.value + "\",\"SourceNode\":\"" + SourceNode.value + "\",\"IP\":\"" + ip.value + "\",\"Port\":\"" + port.value + "\",\"ServiceContent\":\"" + ServiceContent.value + "\",\"SatelliteSystem\":\"" + SYS + "\"}"


            $.ajax({
                type: "POST",
                url: "?action=add",
                data: {net:jsonStr},
                asnyc: true,
                success: function (result) {
                    if (result == "1") {
                        layer.alert('添加成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        table.bootstrapTable('refresh');
                    }
                    else if (result == "2") {
                        layer.alert('站网已存在', {
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

        function initialTable() {
            table.bootstrapTable({
                columns: [
                    {
                        field: 'state',
                        checkbox: true,
                    },
                    {
                        field: 'NetName',
                        title: '站网名称'
                    }, {
                        field: 'Number',
                        title: '站点数量',

                    }, {
                        field: 'IP',
                        title: 'IP地址',

                    }, {
                        field: 'Port',
                        title: '端口'
                    }, {
                        field: 'SourceNode',
                        title: '源节点'
                    }, {
                        field: 'NetworkProtocol',
                        title: '网络协议'

                    }, {
                        field: 'SatelliteSystem',
                        title: '卫星系统'
                    }, {
                        field: 'DataFormat',
                        title: '数据格式'

                    }, {
                        field: 'button',
                        title: '基站信息'

                    }],
            });
        }

        function view(id) {
            layer.open({
                type: 2,
                title: '站网基本信息设置',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['1150px', '650px'],
                content: 'StationNetSet.aspx?id=' + id

            });
        }
        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID
            });
        }


        $("#refreshsta").click(function () {
            table.bootstrapTable('refresh');

        });

        $("#deletesta").click(function () {
            var ids = getIdSelections();
            if (ids.length == 0) {
                parent.layer.msg('请先选择要删除的站网');
                return false;
            }
            layer.alert('您确定要删除这个站网吗', {
                skin: 'layui-layer-lan' //样式类名
                , btn: ['确定', '取消'], title: '删除'
            }, function () {



                $.ajax({
                    url: "",
                    type: "post",
                    data: {
                        action: "DeleteStas",
                        id: ids,
                    },
                    success: function () {
                        layer.alert('删除成功', {
                            skin: 'layui-layer-lan' //样式类名
                             , closeBtn: 0
                        });
                        table.bootstrapTable('remove', {
                            field: 'ID',
                            values: ids
                        });
                        $("#deletesta").blur();


                        table.bootstrapTable('refresh');
                    }, error: function () {
                        layer.alert('删除失败', {
                            skin: 'layui-layer-lan' //样式类名
                             , closeBtn: 0
                        });
                        return false;
                    }
                });

            }, function () {

                parent.layer.msg('删除已取消');
            });
        });
        
        function delHtmlTag(str) {
            return str.replace(/<[^>]+>/g, " ");//去掉所有的html标记
        }

        function showselect(select) {
            var selects = new Array();
            selects = select.split(";");
            var f = document.getElementsByClassName("chosen - choices");
            f.id = "ff";
            for (var i = 0; i < selects.length - 2; i++)
            {
               
                var ff = document.getElementById("ff");
                var li = document.createElement("li");
                var a = document.createElement("a");
                var span = document.createElement("span");
                ff.appendChild(li);
                
                li.classList.add("search-choice");
               
                a.classList.add("search - choice - close");
                
                span.innerText = selects[i];
                li.appendChild(span);
                li.appendChild(a);
                
            }

        }

        $(document).ready(function () {
            var config = {
                '.chosen-select': {
                    width:"78%"
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
            initialTable();
            //showselect("Beidou;GPS;")
            $(".search input").attr("placeholder", "搜索站网名");
        });
    </script>
</body>

</html>
