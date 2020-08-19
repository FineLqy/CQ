<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BroadcastManage.aspx.cs" Inherits="CORSV2.forms.administrator.system.BroadcastManage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>播发服务管理</title>
    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="../../../themes/css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
</head>
<body class="gray-bg" >
    <div class="wrapper wrapper-content  animated fadeInRight" style="padding-top:0px;">
        <div class="row" style="padding-left:0px;padding-right:0px;">
            <div class="col-sm-8" style="padding-left:0px;padding-right:0px;width: 100%;" >
                <div class="ibox float-e-margins">
                    <div class="ibox-content">
                        <div class="panel-body">
                            <div class="panel-group" id="accordion">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info">1</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseOne">连接管理</a>
                                        </h5>
                                    </div>
                                    <div id="collapseOne" class="panel-collapse collapse in">
                                        <br />
                                        <div style="margin-left: 10px">
                                            <button class="btn btn-white btn-sm" data-toggle="modal" data-target="#myModal3"data-placement="left"" title="添加"><i class="fa fa-plus"></i>添加</button>
                                            <div class="modal inmodal" id="myModal3" tabindex="-1" role="dialog" aria-hidden="true">
                                <div class="modal-dialog" style="width:40%;height:35%">
                                    <div class="modal-content animated fadeIn">
                                        <div class="modal-header">
                                            <h4 class="modal-title">添加服务</h4>
                                        </div>
                                        <div class="modal-body">

                                            <label style="width:25%;text-align:left;font-size:large;" >服务端名称</label>
                                             <input type="text" id="ServiceName"  style="width: 70%;font-size:large; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                              <div class="hr-line-dashed"></div>
                                             <label style="width:25%;text-align:left;font-size:large;" >IP</label>
                                           <input type="text" id="IP"  style="width: 70%;font-size:large; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                              <div class="hr-line-dashed"></div>    
                                             <label style="width:25%;text-align:left;font-size:large;" >端口</label>
                                           <input type="text" id="Port" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" style="width: 70%;font-size:large; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                             
                                              </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-white" data-dismiss="modal">关闭</button>
                                    <button type="button" onclick="addservice()" class="btn btn-primary">添加</button>
                                </div>
                            </div>
                            </div>
                            </div>
                                            <button class="btn btn-white btn-sm" data-toggle="tooltip" data-placement="top" id="refreshservice" title="刷新"><i class="fa fa-refresh"></i>刷新</button>
                                            <button class="btn btn-white btn-sm" data-toggle="tooltip" data-placement="top" onclick="deleservice()" title="删除"><i class="fa fa-trash-o"></i>删除
                                            </button>
                                            <button class="btn btn-primary btn-sm" data-toggle="tooltip" data-placement="top" onclick="saveservice()" title="保存"><i class="fa fa-save"></i>保存</button>
                                        </div>
                                        <br />
                                        <div style="margin-left: 10px; margin-right: 10px;">
                                            <table  class="footable table table-stripped" data-page-size="10" data-filter="#filter" style="border: 1px solid #e5e6e7">
                                                <thead>
                                                    <tr>
                                                        <th style="width: 6%">序号</th>
                                                        <td style="width: 4%">
                                                            <input type="checkbox" />
                                                        </td>
                                                        <th style="width: 10%">服务名</th>
                                                        <th style="width: 20%">IP</th>
                                                        <th style="width: 15%">端口</th>
                                                        <th style="width: 25%">源列表</th>


                                                    </tr>
                                                </thead>
                                                <tbody id="list">
                                                </tbody>
                                                <tfoot>
                                                    <tr>
                                                        <td colspan="10" style="width: 100%">
                                                            <ul class="pagination pull-right" style="width: 100%"></ul>
                                                        </td>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div style="margin-left: 10px; margin-right: 10px">
                                            <label style="width: 10%; text-align: left">服务名：</label>
                                            <input type="text" id="servicename" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px; padding-left: 1%">
                                            <label style="width: 10%; text-align: left; padding-left: 3%">IP：</label>
                                            <input type="text" id="ip" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px; padding-left: 1%">
                                            <label style="width: 10%; text-align: left; padding-left: 3%">端口：</label>
                                            <input type="text" id="port" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px; padding-left: 1%">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div style="margin-left: 10px; margin-right: 10px">
                                            <label style="width: 10%; text-align: left">源列表：</label>
                                            <input type="text" id="sourcetable" readonly="readonly" runat="server" style="width: 70%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px; padding-left: 1%">
                                            <label style="width: 3%"></label>
                                            <button class="btn btn-sm btn-white" onclick="update()">更新源列表</button>
                                        </div>
                                        <div class="hr-line-dashed"></div>

                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <span class="label label-info">2</span>
                                            <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseTwo">源列表管理</a>
                                        </h4>
                                    </div>
                                    <div id="collapseTwo1" class="panel-collapse collapse in">
                                        <br />
                                        <div style="margin-left: 10px">
                                            <button class="btn btn-white btn-sm"  data-placement="left" data-toggle="modal" data-target="#myModal4" id="addsource" title="添加"><i class="fa fa-plus"></i>添加</button>
                                            <div class="modal inmodal" id="myModal4" tabindex="-1" role="dialog" aria-hidden="true">
                                <div class="modal-dialog" style="width:25%;height:35%">
                                    <div class="modal-content animated fadeIn">
                                        <div class="modal-header">
                                            <h4 class="modal-title">添加源</h4>
                                        </div>
                                        <div class="modal-body">

                                            <label style="width:25%;text-align:left;font-size:large;" >源名称</label>
                                             <input type="text" id="addsourcename"  style="width: 70%;font-size:large;; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                              <div class="hr-line-dashed"></div>
                                             <label style="width:25%;text-align:left;font-size:large;" >源类型</label>
                                            <select name="account" id="addsourcetype"  style="font-size:large; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 70%">
                                           <option>RTCM2</option>
                                                <option>RTCM3</option>
                                                 <option>RTCM31</option>
                                                 <option>RTCM32</option>
                                                <option>CMR</option>
                                            </select>
                                              </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-white" data-dismiss="modal">关闭</button>
                                    <button type="button" onclick="addsources()"  class="btn btn-primary">添加</button>
                                </div>
                            </div>
                            </div>
                            </div>
                                            <button class="btn btn-white btn-sm" data-toggle="tooltip" data-placement="top" onclick="refreshsources()" id="refreshsource" title="刷新"><i class="fa fa-refresh"></i>刷新</button>
                                            <button class="btn btn-white btn-sm" data-toggle="tooltip" data-placement="top" onclick="deleSource()" id="deletesource" title="删除"><i class="fa fa-trash-o"></i>删除</button>
                                            <button class="btn btn-primary btn-sm" data-toggle="tooltip" runat="server" onclick="savesource()" data-placement="top" title="保存"><i class="fa fa-save"></i>保存</button>
                                        </div>
                                        <br />
                                        <div style="margin-left: 10px; margin-right: 10px;">
                                     
                                             <table id="table"
                                    data-show-refresh="false"
                                    data-show-toggle="false"
                                    data-show-columns="false"
                     
                              
                                    data-detail-view="false"
                                    data-striped="false"
                                    data-minimum-count-columns="1"
                                    data-show-pagination-switch="false"
                                    data-pagination="false"
                                    data-page-size="10"
                                    data-id-field="ID"
                                    data-unique-id="ID"
                             
                                    data-show-footer="false"
                                    data-side-pagination="server"
                                    data-url="?action=GetData"
                                    data-smart-display="false">

                                </table>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div style="margin-left: 10px; margin-right: 10px">
                                            <label style="width: 8%; text-align: left">源  ：</label>
                                            <input type="text" id="source" runat="server" style="width: 10%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: left; padding-left: 3%">类型：</label>
                                            <select name="sourcetype" id="sourcetype" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                                <option>RTCM2</option>
                                                <option>RTCM3</option>
                                                <option>RTCM31</option>
                                                 <option>RTCM32</option>
                                                <option>CMR</option>
                                            </select>
                                            <label style="width: 10%; text-align: left; padding-left: 3%">映射：</label>
                                            <input type="text" id="map" runat="server" readonly="readonly" style="width: 42%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div style="margin-left: 10px; margin-right: 10px">
                                            <label style="width: 8%; text-align: left;">映射源：</label>
                                            <select name="mapsource" id="mapsource" onchange="mapsourcechange()" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 20%">
                                            </select>
                                            <label style="width: 10%; text-align: left; padding-left: 3%">优先级：</label>
                                            <select name="mapsource" id="level" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                                <option>1</option>
                                                <option>2</option>
                                                <option>3</option>
                                                <option>4</option>
                                            </select>
                                            <label style="width: 10%; text-align: left; padding-left: 3%">连接数：</label>
                                            <input type="text" id="connectnum" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" runat="server" style="width: 10%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px" value="0">
                                            <label style="width: 10%; text-align: left; padding-left: 3%">状态：</label>
                                            <select name="status" id="status" onchange="changestatus()" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 12%">
                                                <option>映射</option>
                                                <option>断开</option>

                                            </select>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
             </div>
    </div>

    <!-- 全局js -->
    <script src="../../../js/jquery.min.js?v=2.1.4"></script>
    <script src="../../../js/bootstrap.min.js?v=3.3.6"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <!-- 自定义js -->
        <%--<script src="../../../js/content.js?v=1.0.0"></script>--%>
        <script src="../../../js/plugins/footable/footable.all.min.js"></script>
    <script src="../../../js/plugins/layer/layer.min.js"></script>

    <!-- layerDate plugin javascript -->
    <script src="../../../js/plugins/layer/laydate/laydate.js"></script>
    <script>
        $("#refreshservice").click(function () {
            location.reload();
         

        });
        $('.modal').appendTo("body");
        var num = 0;
        var idid = "";
        function saveservice() {
            if (idid == "") {
                layer.alert('请选择服务', {
                    skin: 'layui-layer-lan' //样式类名
                         , closeBtn: 0
                });
                return false;
            }
            else {
                var sername = document.getElementById("servicename");
                if (sername.value == "") {
                    layer.alert('服务名不能为空', {
                        skin: 'layui-layer-lan' //样式类名
                         , closeBtn: 0
                    });
                    return false;
                }
                var ip1 = document.getElementById("ip");
                if (ip1.value == "") {
                    layer.alert('请输入IP地址', {
                        skin: 'layui-layer-molv', //样式类名,
                    });
                    return false;
                }
                if (ip1.value != null) {
                    var re = /^(\d+)\.(\d+)\.(\d+)\.(\d+)$/;//正则表达式   
                    if (re.test(ip1.value)) {
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
                var port1 = document.getElementById("port");
                if (port1.value == "") {
                    layer.alert('请输入端口', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
                var iddd = idid.toString();
                var sourcestr = document.getElementById("sourcetable");
                $.get("BroadcastManage.aspx?action=saveservice_" + iddd + "," + sername.value.toString().trim() + "," + ip1.value.toString().trim() + "," + port1.value.toString().trim() + "," + sourcestr.value.toString().trim(), function (result) {
                    if (result == "1") {
                        layer.alert('保存成功', {
                            skin: 'layui-layer-lan' //样式类名
                     , closeBtn: 0
                        }, function () { location.reload(); });

                    }
                    
                    else {

                        layer.alert('保存失败', {
                            skin: 'layui-layer-lan' //样式类名
                 , closeBtn: 0
                        });
                    }

                });


            }
        }
        function addservice() {
            var port = document.getElementById("Port");
            if (port.value == "") {
                layer.alert('请输入端口', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            var ip = document.getElementById("IP");
            if (ip.value == "") {
                layer.alert('请输入IP地址', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            if (ip.value != null) {
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
            var serviceName = document.getElementById("ServiceName");
            if (serviceName.value == "") {
                layer.alert('请输入服务端名', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }

            $.post("BroadcastManage.aspx?action=addservice_" + serviceName.value.toString().trim() + "," + ip.value.toString().trim() + "," + port.value.toString().trim(), function (data) {
                var dataArr = data.split('_');
                var result = dataArr[0];
                if (result == "0") {
                    layer.alert('服务名不可用', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
                else {
                    if (result != "false" && result != null && result != "") {

                        var reg = /^[0-9]+.?[0-9]*$/;
                        if (!reg.test(result)) {
                            layer.alert('添加失败', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            return false;
                        }
                        layer.alert('添加成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        var so = document.getElementById("")
                        var tr = document.createElement("tr");//创建一个标签
                        tr.id = result;
                        tr.onclick = function () {
                            var id = this.id;
                            idid = id;
                            var servicename = document.getElementById("servicename");
                            var ip = document.getElementById("ip");
                            var port = document.getElementById("port");
                            var sourcetable = document.getElementById("sourcetable");
                            $.get("BroadcastManage.aspx?action=loadservice_" + id, function (data) {
                                var text = data.split("_;");
                                if (text.length == 4) {
                                    servicename.value = text[0];
                                    ip.value = text[1];
                                    port.value = text[2];
                                    sourcetable.value = text[3];
                                }
                            })

                        }
                        var tdnum = document.createElement("td");
                        num = num + 1;
                        tdnum.innerText = num + 1;
                        var tdcheck = document.createElement("td");
                        var tdServiceName = document.createElement("td");
                        tdServiceName.innerText = serviceName.value;
                        var tdServiceIP = document.createElement("td");
                        tdServiceIP.innerText = ip.value;
                        var tdServicePort = document.createElement("td");
                        tdServicePort.innerText = port.value;
                        var tdSourceTable = document.createElement("td");
                        tdSourceTable.innerText = dataArr[1];


                        tdnum.style = "width:6%";
                        tdcheck.style = "width:4%";
                        tdServiceName.style = "width:10%";
                        tdServiceIP.style = "width:20%";
                        tdServicePort.style = "width:15%";
                        tdSourceTable.style = "width:25%";

                        var check = document.createElement("input");
                        check.type = "checkbox";
                        check.name = "check";
                        check.value = result;
                        check.id = result + "_1";



                        var bodyFa1 = document.getElementById("list");//通过id号获取frameli 的父类（也就是上一级的节点）
                        bodyFa1.appendChild(tr);

                        tr.appendChild(tdnum);
                        tr.appendChild(tdcheck);
                        tr.appendChild(tdServiceName);
                        tr.appendChild(tdServiceIP);
                        tr.appendChild(tdServicePort);
                        tr.appendChild(tdSourceTable);


                        tdcheck.appendChild(check);
                        $(document).ready(function () {

                            $('.footable').footable();
                            $('.footable2').footable();

                        });
                    }
                    else {
                        layer.alert('添加失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        return false;
                    }
                }
            });

        }
        function deleservice() {
            var obj = document.getElementsByName("check");
            var s = '';
            for (var i = 0; i < obj.length; i++) {
                if (obj[i].checked) {
                    s += obj[i].value + ','; //如果选中，将value添加到变量s中 

                }
            }

            if (s == '')
            {
                parent.layer.msg('请先选择要删除的服务');
                return false;
            }
            layer.alert('您确定要删除这条服务吗', {
                skin: 'layui-layer-lan' //样式类名
                , btn: ['确定', '取消'], title: '删除'
            }, function () {

                $.get("BroadcastManage.aspx?action=deleservice_" + s, function (result) {
                    if (result == "1") {
                        for (var i = obj.length - 1; i >= 0 ; i--) {
                            if (obj[i].checked) {
                                var table = document.getElementById("list");
                                var tr = document.getElementById(obj[i].value);
                                table.removeChild(tr);
                            }
                        }
                        layer.alert('删除成功', {
                            skin: 'layui-layer-lan' //样式类名
                               , closeBtn: 0
                        });
                        var servicename = document.getElementById("servicename");
                        var ip = document.getElementById("ip");
                        var port = document.getElementById("port");
                        var sourcetable = document.getElementById("sourcetable");
                        servicename.value = "";
                        ip.value = "";
                        port.value = "";
                        sourcetable.value = "";
                    }
                    else {
                        layer.alert('删除失败', {
                            skin: 'layui-layer-lan' //样式类名
                               , closeBtn: 0
                        });
                    }

                });}, function () {
          
                    parent.layer.msg('删除已取消');
                });


           
        
        }

        function update() {
            var ipp = document.getElementById("ip");
            var portt = document.getElementById("port");
            var sourcetablee = document.getElementById("sourcetable");
            $.post("BroadcastManage.aspx?action=gxylb_" + ipp.value.toString().trim() + "," + portt.value.toString().trim(), function (data) {
                var dataArr = data.split("_;");
                if (dataArr[0] == "1") {
                    sourcetablee.value = dataArr[1];
                    layer.alert('更新成功,若要保存请点击修改', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                }
                else {
                    layer.alert('更新失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                }
            });
        }

        function loadlist() {
            var information = '<%=Info%>';
            var infolist = new Array();
            infolist = information.split("_;");
            num = infolist.length - 1;
            for (var i = 0; i < infolist.length - 1 ; i++) {
                var cominfo = new Array();
                cominfo = infolist[i].split(",");


                var tr = document.createElement("tr");//创建一个标签
                tr.id = cominfo[0];
                tr.onclick = function () {

                    var id = this.id;
                    idid = id;
                    var servicename = document.getElementById("servicename");
                    var ip = document.getElementById("ip");
                    var port = document.getElementById("port");
                    var sourcetable = document.getElementById("sourcetable");
                    $.get("BroadcastManage.aspx?action=loadservice_" + id, function (data) {
                        var text = data.split("_;");
                        if (text.length == 4) {
                            servicename.value = text[0];
                            ip.value = text[1];
                            port.value = text[2];
                            sourcetable.value = text[3];
                        }
                    })

                }
                var tdnum = document.createElement("td");
                tdnum.innerText = i + 1;
                var tdcheck = document.createElement("td");
                var tdServiceName = document.createElement("td");
                tdServiceName.innerText = cominfo[1];
                var tdServiceIP = document.createElement("td");
                tdServiceIP.innerText = cominfo[2];
                var tdServicePort = document.createElement("td");
                tdServicePort.innerText = cominfo[3];
                var tdSourceTable = document.createElement("td");
                tdSourceTable.innerText = cominfo[4];


                tdnum.style = "width:6%";
                tdcheck.style = "width:4%";
                tdServiceName.style = "width:10%";
                tdServiceIP.style = "width:20%";
                tdServicePort.style = "width:15%";
                tdSourceTable.style = "width:25%";

                var check = document.createElement("input");
                check.type = "checkbox";
                check.name = "check";
                check.value = cominfo[0];
                check.id = cominfo[0] + "_1";



                var bodyFa1 = document.getElementById("list");//通过id号获取frameli 的父类（也就是上一级的节点）
                bodyFa1.appendChild(tr);

                tr.appendChild(tdnum);
                tr.appendChild(tdcheck);
                tr.appendChild(tdServiceName);
                tr.appendChild(tdServiceIP);
                tr.appendChild(tdServicePort);
                tr.appendChild(tdSourceTable);


                tdcheck.appendChild(check);
            }
            $(document).ready(function () {

                $('.footable').footable();
                $('.footable2').footable();

            });
        }

        var id_d = "";
        function savesource() {
            var sour = document.getElementById("source");
            if (sour.value.toString() == "") {
                layer.alert('源名称不能为空', {
                    skin: 'layui-layer-lan' //样式类名
                         , closeBtn: 0
                });
                return false;
            }
            else {
                var num = document.getElementById("connectnum")
                if (num.value.toString() == "") {
                    layer.alert('连接数不能为空', {
                        skin: 'layui-layer-lan' //样式类名
                         , closeBtn: 0
                    });
                    return false;
                }
                else {
                    var type = document.getElementById("sourcetype");
                    var map = document.getElementById("map");
                    var sourName = sour.value.toString().trim();
                    var sourType = type.value.toString().trim();
                    var mapstr = map.value.toString().trim();
                    if (id_d == "") {
                        layer.alert('请选择修改对象', {
                            skin: 'layui-layer-lan' //样式类名
                         , closeBtn: 0
                        });
                        return false;
                    }
                    else {
                        $.get("BroadcastManage.aspx?action=savesource_" + id_d + "," + num.value.toString() + "," + sourName + "," + sourType + "," + mapstr, function (result) {
                            if (result == "1") {
                                layer.alert('保存成功', {
                                    skin: 'layui-layer-lan' //样式类名
                             , closeBtn: 0
                                }, function () { location.reload(); });

                            }
                            else if (result == "-2") {

                                layer.alert('源名称重复！', {
                                    skin: 'layui-layer-lan' //样式类名
                         , closeBtn: 0
                                });
                            }
                            else {
                                if (result == "2") {
                                    layer.alert('保存成功,等待管理员审核！', {
                                        skin: 'layui-layer-lan' //样式类名
                             , closeBtn: 0
                                    });
                                }
                                else {
                                    layer.alert('保存失败', {
                                        skin: 'layui-layer-lan' //样式类名
                             , closeBtn: 0
                                    });
                                }
                            }

                        });
                    }
                }


            }
            return false;


        }
        function changestatus() {
            var stu = document.getElementById("status");
            var maxnum = document.getElementById("connectnum");
            if (stu.selectedIndex == 0) {

                var mapsource = document.getElementById("mapsource");
                var level = document.getElementById("level");
                var map = document.getElementById("map");
                var levelstr = ":" + level.value.toString() + ":";
                var mapstr = map.value.toString();
                var mapsoustr = mapsource.value.toString();
                var result = mapstr.indexOf(levelstr);
                if (result >= 0) {
                    layer.alert('该优先级已存在', {
                        skin: 'layui-layer-lan' //样式类名
                        , closeBtn: 0
                    });
                    stu.selectedIndex = 1;
                    return;
                }
                else {

                    if (maxnum.value.toString() == "") {
                        layer.alert('连接数不能为空', {
                            skin: 'layui-layer-lan' //样式类名
                         , closeBtn: 0
                        });
                        stu.selectedIndex = 1;
                        return false;
                    }
                    else {
                        var str = mapsoustr + ":" + level.value.toString() + ":" + maxnum.value.toString() + ";";
                        map.value = mapstr + str;
                        maxnum.readOnly = true;
                    }
                }
            }
            else {
                maxnum.readOnly = false;
                var map = document.getElementById("map");
                var mapstr = map.value.toString();
                var sourcename = document.getElementById("mapsource");
                var sourcenamestr = sourcename.value.toString();
                var maparr = mapstr.split(";");
                for (var j = 0; j < maparr.length; j++) {
                    var resu = maparr[j].indexOf(sourcenamestr);
                    if (resu >= 0) {
                        mapstr = mapstr.replace(maparr[j] + ";", "");
                        map.value = mapstr;
                        break;
                    }
                }
            }
        }

        function mapsourcechange() {


            var mapsource = document.getElementById("mapsource");
            var map = document.getElementById("map");
            var stu = document.getElementById("status");
            var a1 = "";
            var a2 = "";
            a1 = map.value.toString();
            a2 = mapsource.value.toString();
            var aa = a1.indexOf(a2);
            if (aa >= 0) {
                stu.selectedIndex = 0;
                stu.disabled = false;
                var a = map.value.split(";")
                for (var i = 0; i < a.length; i++) {
                    var b1 = a[i].toString();
                    var b2 = mapsource.value.toString();
                    var bb = b1.indexOf(b2);
                    if (bb >= 0) {
                        var text = a[i].split(":");
                        var level = document.getElementById("level");
                        level.value = text[2];
                        var maxnum = document.getElementById("connectnum");
                        maxnum.value = text[3];
                        maxnum.readOnly = true;

                    }
                }
            }
            else {

                stu.selectedIndex = 1;
                var name = mapsource.value.toString().split(":")[0]+':';
                var mapstr = map.value.toString();
                var result = mapstr.indexOf(name);
                if (result >= 0) {
                    stu.disabled = true;

                }
                else {
                    stu.disabled = false;

                }
                var maxnum = document.getElementById("connectnum");
                maxnum.readOnly = false;
            }
        }
        function refreshsources() {
            table.bootstrapTable('refresh');

        }

        function addsources() {
            var name = document.getElementById("addsourcename");
            var type = document.getElementById("addsourcetype");
            if (name.value.toString() == "") {
                layer.alert('源名称不能为空', {
                    skin: 'layui-layer-lan' //样式类名
                    , closeBtn: 0
                });
                return false;
            }
            else {
                $.get("BroadcastManage.aspx?action=addsource_" + name.value + "," + type.value, function (result) {
                    if (result == "1") {

                        layer.alert('源添加成功', {
                            skin: 'layui-layer-lan' //样式类名
                   , closeBtn: 0
                        }, function () { location.reload(); });

                    }
                    else {
                        if (result == "0") {
                            layer.alert('已存在该源', {
                                skin: 'layui-layer-lan' //样式类名
                                , closeBtn: 0
                            });
                        }
                        
                        else {
                            layer.alert('源添加失败', {
                                skin: 'layui-layer-lan' //样式类名
                                , closeBtn: 0
                            });
                        }
                    }
                })
            }
        }



        var table = $("#table");

        function initialTable() {
            table.bootstrapTable({
                columns: [
                    {
                        field: 'state',
                        checkbox: true,
                    },
                    {
                        field: 'ID',
                        title: 'ID'
                    },
                    {
                        field: 'Source',
                        title: '源'
                    }, {
                        field: 'SourceType',
                        title: '源类型'
                    }
                ],
            });
        }


        $(document).ready(function () {
            initialTable();
            loadlist();

        });

        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID
            });
        }

        $("table").on('click-row.bs.table', function (e, row, $element, field) {

            id_d = row.ID;
            var id = row.ID;
            $.get("BroadcastManage.aspx?action=cxylbxx_" + id, function (data) {
                var dataArr = new Array();
                dataArr = data.split("-!");
                var source1 = document.getElementById("source");
                source1.value = dataArr[0];
                var sourcetype1 = document.getElementById("sourcetype");
                sourcetype1.value = dataArr[1];
                var map = document.getElementById("map");
                map.value = dataArr[2];
                if (dataArr[2] == null || dataArr[2] == "") {
                    var stu = document.getElementById("status");
                    stu.selectedIndex = 1;
                }
                else {
                    var firstvalue = new Array();
                    firstvalue = dataArr[2].split(';');
                    var text = firstvalue[0].split(":");
                    var stu = document.getElementById("status");
                    stu.selectedIndex = 0;
                    var mapsource = document.getElementById("mapsource");
                    mapsource.value = text[0] + ":" + text[1];
                    var level = document.getElementById("level");
                    level.value = text[2];
                    var maxnum = document.getElementById("connectnum");
                    maxnum.value = text[3];

                }
            }
           );

        })
        function deleSource() {
            var ids = getIdSelections();
            if (ids.length == 0)
            {
                parent.layer.msg('请先选择要删除的源');
                return false;
            }
            layer.alert('您确定要删除这条源吗', {
                skin: 'layui-layer-lan' //样式类名
                , btn: ['确定', '取消'], title: '删除'
            }, function () {
                $.post("BroadcastManage.aspx?action=delesource_" + ids, function (result) {
                    if (result == "1") {
                        layer.alert('删除成功', {
                            skin: 'layui-layer-lan' //样式类名
                         , closeBtn: 0
                        });
                    }
                    else {
                        layer.alert('删除失败', {
                            skin: 'layui-layer-lan' //样式类名
                         , closeBtn: 0
                        });
                        return false;
                    }
                });
                table.bootstrapTable('remove', {
                    field: 'ID',
                    values: ids
                });
            }, function () {
          
                parent.layer.msg('删除已取消');
            });


           
        }

    </script>
</body>

</html>
