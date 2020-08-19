<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RtkUserManage.aspx.cs" Inherits="CORSV2.forms.administrator.users.RtkUserManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>RTK用户管理</title>

    <link rel="shortcut icon" href="../../favicon.ico" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet" />
    <style>
        table, th {
            vertical-align: middle;
            text-align: center;
        }
    </style>
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content  animated fadeInRight" style="padding-top: 0px;">
        <div class="row" style="padding-left: 0px; padding-right: 0px;">
            <div class="col-sm-8" style="padding-left: 0px; padding-right: 0px; width: 100%;">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>RTK用户管理</h5>
                    </div>

                    <div class="ibox-content">
                        <div class="newstable" style="margin-top: 1%">

                            <div class="bars pull-left">

                                <div class="btn-group hidden-xs" id="toolbar" role="group" style="height: 34px;" runat="server">
                                    <select id="cityType" class="btn btn-outline btn-default" runat="server" onchange="changedata();" style="height: inherit;">
                                        <option value="全部" selected="selected">全部区域</option>
                                    </select>
                                    <select id="dataType" class="btn btn-outline btn-default" runat="server" onchange="changedata();" style="height: inherit;">
                                        <option value="0" selected="selected">全部用户</option>
                                        <option value="1">企业用户</option>
                                        <option value="2">个人用户</option>
                                    </select>
                                     <button type="button" data-toggle="modal" data-target="#myModal4"  data-placement="top" title="续费管理"  class="btn btn-outline btn-default">
                                        <i class="fa fa-plus"></i>续费管理 
                                    </button>
                                    <button type="button" id="refreshcors" class="btn btn-outline btn-default" title="刷新单位列表" style="height: inherit;">
                                        <i class="fa fa-refresh"></i>刷新
                                    </button>
                                    <button type="button" id="deletecors" class="btn btn-outline btn-default" data-toggle="tooltip" data-placement="top" title="删除">
                                        <i class="fa fa-trash-o"></i>删除
                                    </button>
                                    <button type="button" id="download" class="btn btn-outline btn-default" data-toggle="tooltip" data-placement="top" title="导出xls">
                                        <i class="fa fa-download" aria-hidden="true"></i>导出xls
                                    </button>
                                      <form id="Form">
                                        <div class="modal inmodal" id="myModal4" tabindex="-1" role="dialog" aria-hidden="true">
                                            <div class="modal-dialog">
                                                <div class="modal-content animated fadeIn">
                                                    <div class="modal-header">
                                                        <h4 class="modal-title">续费管理</h4>
                                                    </div>
                                                    <div class="modal-body" style="background-color:#ffffff">

                                                       
                                                        <label style="width: 15%; text-align: left; font-size: 15px;">续费账号</label>
                                                       
                                                        <select data-placeholder="选择要续费的账号" id="SatelliteSystem"  class="chosen-select" multiple="true"  runat="server" style="width:240px;" tabindex="4">
                                                             
                                                                <option value="" hassubinfo="true"></option>                                                               
                                                        </select>
                                                      


                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px; vertical-align: top;">续费时长</label>
                                                        <select id="RenewalDuration" name="RenewalDuration" style="width:200px;height:30px"  >
                                                            <option value="一个月">一个月</option>
                                                           <option value="半年">半年</option>
                                                            <option value="一年">一年</option>
                                                            <option value="两年">两年</option>
                                                        </select>
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-white" data-dismiss="modal">关闭</button>
                                                        <button type="button" id="addstationnet" class="btn btn-success">立即续费</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </form>
                                </div>
                            </div>
                            <div>
                              <label  style="">
                                <span>终端账号总数量：</span><span  id="rtkUserNum" runat="server"></span>	
                                <span>正常在线总数量：</span><span  id="normalRtkUserNum" runat="server"></span>
                              </label>
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


  
      <link href="../../../themes/css/plugins/chosen/chosen.css" rel="stylesheet" />
    <script src="../../../js/plugins/chosen/chosen.jquery.js"></script>
      <script src="../../../js/jquery.form.js"></script>
    <script>

        var table = $("#table");


        function initialTable() {
            table.bootstrapTable({
                columns: [
                    {
                        field: 'state',
                        checkbox: true,
                    },
                    {
                        field: 'UserName',
                        title: '终端账号',
                        sortable: true
                    }, {
                        field: 'PassWord',
                        title: '终端密码',
                    }, {
                        field: 'reRegTime',
                        title: '注册时间',
                        sortable: true
                    }, {
                        field: 'reEndTime',
                        title: '到期时间',
                    },
                    {
                        field: 'accountState',
                        title: '账号状态',
                    }
                    , {
                        field: 'detailInfo',
                        title: '详细信息',
                    }
                   

                ],
            });
            $(".search input").attr("placeholder", "用户名");
        }
        function changedata() {
            table.bootstrapTable('refresh', {
                url: "?action=GetData&dataType=" + $("#dataType").val() + "&cityType=" + $("#cityType").val(),
                silent: true
            });

        };



        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID
            });
        }

        $("#download").click(function () {
            window.location.href = "?action=DownloadAll";

            $("#download").blur();
        });
        $("#refreshcors").click(function () {
            table.bootstrapTable('refresh');

        });

        //查看rtk用户详细信息
        function rtkUserDetailInfoView(id) {
            parent.layer.open({
                type: 2,
                title: '详细信息',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['1150px', '650px'],
                content: '/forms/administrator/users/rtkUserDetailInfoView.aspx?id=' + id
            });
        }

        $("#deletecors").click(function () {
            var ids = getIdSelections();
            if (ids.length == 0) {
                parent.layer.msg('请先选择要删除的用户');
                return false;
            }
            layer.alert('您确定要删除这个用户吗', {
                skin: 'layui-layer-lan' //样式类名
                , btn: ['确定', '取消'], title: '删除'
            }, function () {

                $.ajax({
                    url: "/forms/administrator/users/RtkUserManage.aspx",
                    type: "post",
                    data: {
                        action: "DeleteCors",
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
                        }); $("#deletecors").blur();

                        table.bootstrapTable('refresh');
                    }, error: function () {
                        layer.alert('删除失败', {
                            skin: 'layui-layer-lan' //样式类名
                            , closeBtn: 0
                        });
                    }
                });

            }, function () {

                parent.layer.msg('删除已取消');
            });
        });
        $(document).ready(function () {
            initialTable();
        });
    </script>



      <script>

        var table = $("#table");

        $("#addstationnet").click(function () {
           
            var SatelliteSystem = document.getElementById("SatelliteSystem");
            var RenewalDuration = document.getElementById("RenewalDuration");
         
            if (SatelliteSystem.value == "") {
                layer.alert('请选择卫星系统', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }


          

           
            var sys = $(".chosen-choices").html();
            var SYS = delHtmlTag(sys);

            var jsonStr = "{\"RenewalDuration\":\"" + RenewalDuration.value + "\",\"SatelliteSystem\":\"" + SYS + "\"}"


            $.ajax({
                type: "POST",
                url: "?action=add",
                data: {net:jsonStr},
                asnyc: true,
                success: function (result) {
                    if (result.length > 5) {
                       
                      window.location.href = "../../user/order/Renew_check.aspx?order_number=" + result;
                    }
                 
               
                }
            
            })
        });

       

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
