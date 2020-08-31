<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentRecord.aspx.cs" Inherits="CORSV2.forms.administrator.order.PaymentRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>缴费记录</title>

    <link rel="shortcut icon" href="../../favicon.ico" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
    <link href="../../user/order/css/shopcart.css" rel="stylesheet" />
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
                                    <select id="dataType1" runat="server" class="btn btn-outline btn-default" onchange="changedata();">
                                        <option value="类型" selected="selected">类型</option>
                                        <option value="0">申请</option>
                                        <option value="1">续费</option>
                                        <option value="2">充值</option>
                                       
                                    </select>
                                    <button type="button" id="refreshcors" class="btn btn-outline btn-default" title="刷新">
                                        <i class="fa fa-refresh"></i>刷新
                                    </button>
                                 
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
    <script>

        var table = $("#table");
       

     
      
        function initialTable() {
            table.bootstrapTable({
                columns: [
                   {
                        field: 'ID',
                        title: '订单编号'
                    },
                {
                        field: 'UserName',
                        title: '用户名'
                    },
                    {
                        field: 'ProductName',
                        title: '产品名称'
                    }, {
                        field: 'Company',
                        title: '单位名',

                    }, {
                        field: 'deType',
                        title: '类型',

                    }, {
                        field: 'Money',
                        title: '金额'
                    }
                , {
                        field: 'deRechargeTime',
                        title: '缴费时间'
                    }],
            });
        }
        
        function viewDevice(SerialNumber) {
            layer.open({
                type: 2,
                title: '设备信息设置',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['1150px', '650px'],
                content: 'DataCenterEquip.aspx?Serial=' + SerialNumber

            });
        }
    
        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID
            });
        }

       function changedata() {
            table.bootstrapTable('refresh', {
                url: "?action=GetData&dataType1=" + $("#dataType1").val(),
                silent: true
            });

        };

        $("#refreshcors").click(function () {
            table.bootstrapTable('refresh');
            //location.reload();

        });

    
        $(document).ready(function () {
            initialTable();
            $(".search input").attr("placeholder", "搜索单位名称");
        });
    </script>
</body>

</html>