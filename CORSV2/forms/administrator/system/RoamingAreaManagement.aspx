<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoamingAreaManagement.aspx.cs" Inherits="CORSV2.forms.administrator.system.RoamingAreaManagement" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link rel="shortcut icon" href="../../favicon.ico" />
    
    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css" rel="stylesheet">
        <!-- 全局js -->
    <script src="../../../js/jquery.min.js?v=2.1.4"></script>
    <script src="../../../js/bootstrap.min.js"></script>
    <link href="../../../themes/css/zyzn_1.css" rel="stylesheet" />
    <script src="../../../js/City_data.js"></script>
    <script type="text/javascript" src="../../../js/areadata.js"></script>
    <script type="text/javascript" src="../../../js/auto_area.js"></script>

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
                                    <button type="button" data-toggle="modal" data-target="#myModal4" data-placement="top" title="添加有效范围分组" class="btn btn-info">
                                        <i class="fa fa-plus"></i>添加分组
                                    </button>

                                    <button type="button" id="refreshsta" class="btn btn-outline btn-default" title="刷新">
                                        <i class="fa fa-refresh"></i>刷新
                                    </button>
                                  
                                    <button type="button" id="deletesta" class=" btn btn-danger"  data-toggle="tooltip" data-placement="top" title="删除">
                                        <i class="fa fa-trash-o"></i>删除
                                    </button>
                                    <form method="post" id="Form">
                                        <div class="modal inmodal" id="myModal4" tabindex="-1" role="dialog" aria-hidden="true">
                                            <div class="modal-dialog">
                                                <div class="modal-content animated fadeIn">
                                                    <div class="modal-header">
                                                        <h4 class="modal-title">添加有效范围分组</h4>
                                                    </div>
                                                    <div class="modal-body" style="background-color:#ffffff">

                                                        <label style="width: 15%; text-align: left; font-size: 15px;">分组名称</label>
                                                        <input type="text" id="GroupName" autocomplete="off" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                       
                                                        <div><span>&nbsp</span></div>
                                                            <label style="width: 15%; text-align: left; font-size: 15px;">分组描述</label>
                                                     <input type="text" id="Remark" autocomplete="off" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                                         <div><span>&nbsp</span></div>
                                                    
                                                         <label style="width: 15%; text-align: center">有效范围</label>
                                       <input type="text" id="GroupRange" class="area-duoxuan" value="" data-value="" style="width: 78%; font-size: 15px; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px" />
                                                       
                                                       
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

       
        function addstation() {

            var GroupName = document.getElementById("GroupName");
            if (GroupName.value.trim() == "") {
                layer.alert('请输入分组名称', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            var Remark = document.getElementById("Remark");
            if (Remark.value.trim() == "") {
                layer.alert('请输入分组描述', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            var GroupRange = document.getElementById("GroupRange");
           
            if (GroupRange.value.trim() == "") {
                layer.alert('请选择有效范围', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
           

            //var ip = document.getElementById("ProductDescription");
            //if (ip.value == "") {
            //    layer.alert('请输入产品描述', {
            //        skin: 'layui-layer-lan', //样式类名,
            //    });
            //    return false;
            //}
         
        

         
 

                $.ajax({
                    url: "RoamingAreaManagement.aspx?action=add",
                    data: {
                        GroupName: GroupName.value.trim(),
                        Remark: Remark.value.trim(),
                        GroupRange: GroupRange.value.trim(),
                     
                     
                    },
                    type: "POST",
                    success: function (result) {
                        if (result == "0") {

                            layer.alert('分组信息已存在', {
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
                        field: 'ID',
                      title: '编号'
                    },
                    {
                        field: 'GroupName',
                        title: '分组名称'
                    }, {
                        field: 'Remark',
                        title: '分组描述',

                    }, {
                        field: 'deInsertTime',
                        title: '添加时间',

                    },
                 {
                        field: 'Update',
                     title: '操作',
                         events: operatEvents,
                        formatter : operatFrom,
                    },],
            });
        }

        function operatFrom(value,row,index){
        //return "<a href='javascript:;' onclick='editRow(event)'>编辑</a>&nbsp;&nbsp;<a href='javascript:;' onclick='deleteRow(event)'>删除</a>";
        return [
                '<a type="button"  id="edit"  class="btn btn-success" style="margin-right:15px;">编辑</button>',
                '<a type="button" id="del" class="btn btn-danger" style="margin-right:15px;">删除</button>' ]
                .join('');
    }
    window.operatEvents={
        "click .edit": function (e, value, row, index) {
            alert("编辑了caseId是：" + row.ID);
            window.location.href = "?action=RoamingAreaManagementgSet.aspx&&GroupName=" + row.GroupName;
        },
        "click .del": function (e, value, row, index) {
                         layer.confirm('您确定要删除这个合同信息吗', function(index){
       
                     window.location.href = "?action=DeleteCors&&id=" + row.GroupName;
                      layer.close(index);
      });
        }
    }
  
        function viewDevice(GroupName) {
           layer.open({
                type: 2,
                title: '有效分组范围设置',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['1150px', '650px'],
                content: 'RoamingAreaManagementgSet.aspx?GroupName=' + GroupName

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
                parent.layer.msg('请先选择要删除的分组信息');
                return false;
            }
            layer.alert('您确定要删除这个分组信息吗', {
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
            $(".search input").attr("placeholder", "搜索分组名称");
        });
    </script>
</body>

</html>
