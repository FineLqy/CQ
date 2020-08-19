<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceConfig.aspx.cs" Inherits="CORSV2.forms.administrator.system.ServiceConfig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>服务配置信息管理</title>

    <link rel="shortcut icon" href="../../favicon.ico" />
    
    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
        <!-- 全局js -->
    <script src="../../../js/jquery.min.js?v=2.1.4"></script>
    <script src="../../../js/bootstrap.min.js?v=3.3.6"></script>

  <%--  <script src="../../../js/plugins/validate/jquery.validate.min.js"></script>
    <script src="../../../js/plugins/validate/messages_zh.min.js"></script>--%>
    <script src="../../../js/jquery.form.js"></script>
    <!-- 自定义js -->
    <%--    <script src="../../../js/content.js?v=1.0.0"></script>--%>
    <script src="../../../js/plugins/layer/layer.min.js"></script>

    <!-- layerDate plugin javascript -->
    <script src="../../../js/plugins/layer/laydate/laydate.js"></script>

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
                                    <button type="button" data-toggle="modal" data-target="#myModal4" data-placement="top" title="添加服务信息" class="btn btn-outline btn-default">
                                        <i class="fa fa-plus"></i>添加服务信息
                                    </button>

                                    <button type="button" id="refreshsta" class="btn btn-outline btn-default" title="刷新">
                                        <i class="fa fa-refresh"></i>刷新
                                    </button>
                                  
                                    <button type="button" id="deletesta" class="btn btn-outline btn-default" data-toggle="tooltip" data-placement="top" title="删除">
                                        <i class="fa fa-trash-o"></i>删除
                                    </button>
                                    <form method="post" id="Form">
                                        <div class="modal inmodal" id="myModal4" tabindex="-1" role="dialog" aria-hidden="true">
                                            <div class="modal-dialog">
                                                <div class="modal-content animated fadeIn">
                                                    <div class="modal-header">
                                                        <h4 class="modal-title">添加服务信息</h4>
                                                    </div>
                                                    <div class="modal-body" style="background-color:#ffffff">

                                                        <label style="width: 15%; text-align: left; font-size: 15px;">服务名称</label>
                                                        <input type="text" id="ServerName" autocomplete="off" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                       
                                                        <div><span>&nbsp</span></div>
                                                            <label style="width: 15%; text-align: left; font-size: 15px;">付款方式</label>
                                                        <select name="account" id="paymentMethod" style="width: 20px; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 78%">
                                                            <option>按年</option>
                                                            <option>按月</option>
                                                             <option>按量</option>
                                                        </select>
                                                         <div><span>&nbsp</span></div>
                                                    
                                                         <label style="width: 15%; text-align: center">价格</label>
                                        <input type="text" id="Price" autocomplete="off" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                        <div><span>&nbsp</span></div>
                                                       
                                                        <div><span>&nbsp</span></div>
                                                        <label style="width: 15%; text-align: left; font-size: 15px; vertical-align: top;">产品描述</label>
                                                        <textarea id="ProductDescription" autocomplete="off" name="Remark" style="width: 78%; height: 60px; font-size: 12px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px" runat="server" />
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-white" data-dismiss="modal">关闭</button>
                                                        <button type="button" onclick="addstation()" class="btn btn-success">添加</button>
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
    

    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>

    <script>

        var table = $("#table");

        //添加基站
        function addstation() {

            var ServerName = document.getElementById("ServerName");
            if (ServerName.value.trim() == "") {
                layer.alert('请输入服务名称', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            var Price = document.getElementById("Price");
            if (Price.value.trim() == "") {
                layer.alert('请输入产品价格', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
                if (isNaN(Price.value)) {
                layer.alert('请输入正确的价格', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
                var paymentMethod = document.getElementById("paymentMethod");
            var ProductDescription = document.getElementById("ProductDescription");


            //var ip = document.getElementById("ProductDescription");
            //if (ip.value == "") {
            //    layer.alert('请输入产品描述', {
            //        skin: 'layui-layer-lan', //样式类名,
            //    });
            //    return false;
            //}
         
        

           
 

                $.ajax({
                    url: "ServiceConfig.aspx?action=add",
                    data: {
                        ServerName: ServerName.value.trim(),
                        Price: Price.value.trim(),
                        paymentMethod: paymentMethod.value.trim(),
                        ProductDescription: ProductDescription.value.trim()
                     
                    },
                    type: "POST",
                    success: function (result) {
                        if (result == "0") {

                            layer.alert('配置信息已存在', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            return false;
                        }
                        else {
                            if (result == "1") {
                                layer.alert('添加成功', {
                                    skin: 'layui-layer-lan', //样式类名,
                                });
                                table.bootstrapTable('refresh');
                            }
                            else {
                                layer.alert('添加失败', {
                                    skin: 'layui-layer-lan', //样式类名,
                                });
                                return false;
                            }
                        }
                    }
                });

               
            }

        

        function initialTable() {
            table.bootstrapTable({
                columns: [
                    {
                        field: 'state',
                        checkbox: true,
                    },
                    {
                        field: 'ServerName',
                        title: '服务名称'
                    }, {
                        field: 'paymentMethod',
                        title: '付款方式',

                    }, {
                        field: 'Price',
                        title: '价格',

                    }, {
                        field: 'InsertDate1',
                        title: '添加时间',
                         sortable: true
                    }, {
                        field: 'ProductDescription',
                        title: '产品描述'
                    },
                 {
                        field: 'Update',
                        title: '操作'
                    },],
            });
        }
  
        function viewDevice(ServerName) {
           layer.open({
                type: 2,
                title: '产品配置信息设置',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['1150px', '650px'],
                content: 'ServerConfigSet.aspx?ServerName=' + ServerName

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
                parent.layer.msg('请先选择要删除的服务产品');
                return false;
            }
            layer.alert('您确定要删除这个服务产品吗', {
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
        $(document).ready(function () {
            initialTable();
            $(".search input").attr("placeholder", "搜索服务名称");
        });
    </script>
</body>

</html>
