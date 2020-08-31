<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="apply_contract.aspx.cs" Inherits="CORSV2.forms.user.contract.apply_contract" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>CORS用户合同管理</title>

    <link rel="shortcut icon" href="../../favicon.ico" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet" />
        <style>
        table,th {
            vertical-align: middle;
            text-align:center;
        }
    </style>
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content  animated fadeInRight">
        <div class="row" style="padding-left:0px;padding-right:0px;">
            <div class="col-sm-8" style="padding-left:0px;padding-right:0px;width: 100%;">
                <div class="ibox">
                    <div class="ibox-title">
                        <h5>CORS用户合同管理</h5>

                    </div>
                    <div class="ibox-content">
                        <div class="newstable" style="margin-top: 1%">

                            <div class="bars pull-left">
                                <div class="btn-group hidden-xs" id="toolbar" role="group">
                                     <select id="dataType1" class="btn btn-outline btn-default" runat="server" onchange="changedata();">
                                        <option value="全部" selected="selected">全部区域</option>
                                        <option value="全省">全省</option>
                                    </select>
                                    <select id="dataType" class="btn btn-outline btn-default" onchange="changedata();">
                                        <option value="0" selected="selected">全部用户</option>
                                        <option value="1">个人用户</option>
                                        <option value="2">企业用户</option>
                                    </select>
                                    <button type="button" id="refreshcors" class="btn btn-outline btn-default" title="刷新单位列表">
                                        <i class="fa fa-refresh"></i>刷新
                                    </button>
                                   
                                     <button type="button" id="download"  class="btn btn-outline btn-default" data-toggle="tooltip" data-placement="top" title="导出xls">
                                        <i class="fa fa-download" aria-hidden="true"></i>导出xls
                                    </button>
                                </div>
                            </div>

                            <table
                                id="table"  style="table-layout: fixed"
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
        <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>

    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script>

        var table = $("#table");


        function initialTable() {
            table.bootstrapTable({
                columns: [
                    {
                        field: 'state',
                        checkbox: true,
                    }, {
                        field: 'deOrderNumber',
                        title: '合同编号',
                        sortable: true

                    }, {
                        field: 'Price',
                        title: '订单费用',
                        sortable: true
                    },
                    //{
                    //    field: 'rePayTime',
                    //    title: '订单支付时间',

                    //}, {
                    //    field: 'applyWay',
                    //    title: '开具方式'
                    //},
                    {
                        field: 'reSubmitTime',
                        title: '申请时间'
                        , sortable: true
                    },
                    {
                        field: 'recontractStatus',
                        title: '合同状态'
                    }, 
                    {
                        field: 'Remarks',
                        title: '备注'
                    },
                    {
                        field: 'button',
                        title: '操作',
                        events: operatEvents,
                        formatter: operatFrom,
                         width:260

                    }],
            });
            $(".search input").attr("placeholder", "订单号");
        }
        function changedata() {
            table.bootstrapTable('refresh', {
                url: "?action=GetData&dataType=" + $("#dataType").val() + "&dataType1=" + $("#dataType1").val(),
                silent: true
            });

        };

               function operatFrom(value,row,index){
                   //return "<a href='javascript:;' onclick='editRow(event)'>编辑</a>&nbsp;&nbsp;<a href='javascript:;' onclick='deleteRow(event)'>删除</a>";
                   if (row.recontractStatus=='正式') {
 return [
            '<a type="button" id="download" class="btn btn-primary " style="margin-right:15px;">下载</button>'
        ].join('');
                   }
                   else {
                        return [
                '<a type="button" id="edit" class="btn btn-success"  style="margin-right:15px;">转为正式</button>',
            '<a type="button" id="del" class="btn btn-danger" style="margin-right:15px;">作废</button>',
            '<a type="button" id="download" class="btn btn-primary " style="margin-right:15px;">下载</button>'
        ].join('');
                   }
       
                
    }
    window.operatEvents={
        "click #edit": function (e, value, row, index) {
            window.location.href = "../invoice/FormalContract.aspx?id=" + row.deOrderNumber; 
          
        },
        "click #del": function (e, value, row, index) {
                 layer.confirm('您确定要删除这个合同信息吗', function(index){
       
                     window.location.href = "?action=DeleteCors&&id=" + row.deOrderNumber;
                      layer.close(index);
      });
          
        } ,
        "click #download": function (e, value, row, index) {
         window.location.href = "?action=downloadfile&&id="+row.deOrderNumber;
       
           
        } 
    }





        //function view(id) {
        //    parent.layer.open({
        //        type: 2,
        //        title: 'CORS用户基本信息设置',
        //        shadeClose: true,
        //        shade: false,
        //        maxmin: true, //开启最大化最小化按钮
        //        area: ['1150px', '650px'],
        //        content: 'yhgl/CORSUserSet.aspx?id=' + id
        //    });
        //}
        function invoice(id) {
            //因为合同文件的路径和合同文件的状态是放在InvoiceList这个类里面里面的
            $.get('?invoiceListId=' + id, function (result) {
                if (result == "success")
                {
                    layer.msg('合同已申请', { icon: 1 });
                    table.bootstrapTable('refresh');
                }
            });
        }

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
        $(document).ready(function () {
            initialTable();
        });
    </script>
</body>

</html>

