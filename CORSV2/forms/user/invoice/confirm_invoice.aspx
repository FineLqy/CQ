<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="confirm_invoice.aspx.cs" Inherits="CORSV2.forms.user.invoice.confirm_invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="../../../themes/images/favicon.ico" />
    <link href="../../../themes/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/animate.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css" rel="stylesheet" />
    <link href="../../../themes/css/login.css" rel="stylesheet" />
    <link href="../../../themes/css/global-new.css" rel="stylesheet" />
    <link href="../../../themes/css/header.css" rel="stylesheet" />
    <link href="../../../themes/css/init.css" rel="stylesheet" />
    <link href="../../../themes/css/page.css" rel="stylesheet" />
    <link href="../../../themes/css/img-sprites-shop.css" rel="stylesheet" />
    <link href="../../../themes/css/slick.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/layer/skin/layer.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/layer/skin/layer.ext.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />

    <link href="css/global-201905061503.css" rel="stylesheet" />
    <link href="css/bee.css" rel="stylesheet" />
    <link href="css/break.css" rel="stylesheet" />

    <link href="css/monitor-sdk.css" rel="stylesheet" />
    <link href="css/tea-0.0.7.min.css" rel="stylesheet" />
    <link href="css/expense.css" rel="stylesheet" />
    <link rel="shortcut icon" href="../../favicon.ico" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet" />
    <style>
        /*.onfocus-item {
            border: 1px solid #a5c7fe !important;
        }

        .container {
            transform: none;
            transition: none;
            height: auto;
        }

            .container.animate {
                transition: left 0.3s;
                transform: translate3d(0,0,0);
            }

        [data-region-selector].tc-15-dropdown-in-hd .tc-15-dropdown-menu {
            max-height: none;
        }*/
    </style>
    <title></title>
</head>
<body>
    <%--<div id="fd" runat="server" style="display:block"><p>ftrebyr jhref </p></div>--%>
    <form id="form1" runat="server">
        <div class="tea-content">
            <div class="tea-content__header" style="padding-left: 6%;">
                <div class="tea-justify-grid">
                    <div class="tea-justify-grid__col tea-justify-grid__col--left">
                        <div class="expense-invoice-topswitch">
                            <h2 class="tea-h2"><span></span>确认开票信息</h2>
                        </div>
                    </div>
                </div>
            </div>
            <div class="tea-content__body">
                <div class="tea-content__inner">
                    <div class="tea-alert">
                        <%-- <div class="tea-alert__info">目前只支持 <span class="tea-text-warning">纸质发票</span>，暂不支持电子发票。在您提交开票申请后，我们将在 <span class="tea-text-warning">5个工作日</span> 内为您开票并用顺丰快递邮寄给您（发票金额大于等于10元免费邮寄）。</div>--%>
                        <div class="tea-alert__info"><span style="font-size:16px" class="tea-text-warning">目前只支持纸质发票，如需发票，可在工作时间至中心服务窗口开具发票。</span></div>
                    </div>
                    <div class="tea-card">
                        <div class="tea-card__body">
                            <div class="tea-card__title">
                                <div class="tea-justify-grid">
                                    <div class="tea-justify-grid__col tea-justify-grid__col--left">
                                        <h3 class="tea-h3">请选择发票抬头</h3>
                                    </div>
                                </div>
                            </div>
                            <%-- <div class="tea-card__content">
                                    <div class="tea-table tea-table--bordered">
                                        <div class="tea-table__header">
                                            <table class="tea-table__box">
                                                <colgroup>
                                                    <col style="width: 26px;">
                                                    <col style="width: auto;">
                                                    <col style="width: auto;">
                                                    <col style="width: auto;">
                                                </colgroup>
                                                <thead>
                                                    <tr>
                                                        <th class="">
                                                            <div></div>
                                                        </th>
                                                        <th class="">
                                                            <div><span class="tea-text-overflow">发票抬头</span></div>
                                                        </th>
                                                        <th class="">
                                                            <div><span class="tea-text-overflow">发票类型</span></div>
                                                        </th>
                                                        <th class="">
                                                            <div><span class="tea-text-overflow">操作</span></div>
                                                        </th>
                                                    </tr>
                                                </thead>
                                            </table>
                                        </div>
                                        <div class="tea-table__body">
                                            <table class="tea-table__box">
                                                <colgroup>
                                                    <col style="width: 26px;">
                                                    <col style="width: auto;">
                                                    <col style="width: auto;">
                                                    <col style="width: auto;">
                                                </colgroup>
                                                <tbody>
                                                    <tr>
                                                        <td class="">
                                                            <div>
                                                                <label class="tea-form-check">
                                                                    <input readonly="" type="radio" class="tea-radio" checked=""><span class="tea-form-check__label">&nbsp;</span></label></div>
                                                        </td>
                                                        <td class="">
                                                            <div><span class="tea-text-overflow">个人</span></div>
                                                        </td>
                                                        <td class="">
                                                            <div><span class="tea-text-overflow">个人增值税普通发票</span></div>
                                                        </td>
                                                        <td class="">
                                                            <div>
                                                                <div class="expense-table-edit"><a href="javascript:void(0)">修改</a><span class="divide-line"></span><a href="##" class="expense-table-edit-link text-underline">抬头详情</a></div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>--%>
                        </div>
                    </div>
                    <div class="tea-card">
                        <div class="tea-card__body">
                            <div class="tea-card__title">
                                <div class="tea-justify-grid">
                                    <div class="tea-justify-grid__col tea-justify-grid__col--left">
                                        <h3 class="tea-h3">请选择邮寄地址</h3>
                                    </div>
                                </div>
                            </div>


                            <table
                                id="table"
                                data-show-refresh="false"
                                data-show-export="false"
                                data-detail-view="false"
                                data-striped="true"
                                data-minimum-count-columns="1"
                                <%--                                                data-pagination="true"--%>
                                <%--                                                data-page-size="10"--%>
                                data-id-field="ID"
                                data-unique-id="ID"
                                data-page-list="[10]"
                                data-show-footer="false"
                                data-side-pagination="server"
                                data-url="?action=GetData"
                                data-smart-display="false">
                            </table>

                            <div id="message_info" class="tea-table__body" runat="server" style="display: block;">
                                <table class="tea-table__box">
                                    <colgroup>
                                        <col style="width: 26px;">
                                        <col style="width: auto;">
                                        <col style="width: auto;">
                                        <col style="width: 400px;">
                                        <col style="width: auto;">
                                    </colgroup>
                                    <tbody>
                                        <tr class="tea-table__tr--blank-new">
                                            <td colspan="5"><span class="tea-action-state"><span>暂无邮寄信息，<a href="##" onclick="addInvoiceInfo()"><i class="icon icon-plus--blue"></i><span>添加邮寄地址</span></a></span></span></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div id="add_message_info" class="expense-iv-after-table-bar" style="display: block; padding-bottom: 20px;" runat="server">
                            <div class="expense-iv-after-table-bar-l"><a href="##" onclick="addInvoiceInfo()"><i class="icon icon-plus--blue"></i><span>添加邮寄地址</span></a></div>
                        </div>


                    </div>
                </div>
                <div class="expense-layout-footer fixed">
                    <div class="expense-layout-footer-inner">
                        <div class="expense-layout-footer-l">
                            <div class="expense-layout-footer-label">待开票金额</div>
                            <div class="expense-layout-footer-num"><span class="expense-num-mod expense-text-warning"><em></em><span>元</span></span></div>
                            <div class="expense-layout-footer-txt">此纸质发票预计 <span class="tea-text-warning">5个工作日</span> 用顺丰寄出（发票金额大于等于10元免费邮寄）</div>
                        </div>
                        <div class="expense-layout-footer-r">
                            <%--              <button class="tea-btn tea-btn--weak">上一步</button>
                                    <button class="tea-btn tea-btn--weak">预览发票</button>--%>
                            <input type="button" id="submitInvoiceApply" class="btn-success btn-lg" disabled="disabled" value="提交" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="../../../js/jquery.min.js"></script>
    <script src="../../../js/bootstrap.min.js"></script>

    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script src="../../../js/plugins/layer/layer.js"></script>
    <link href="../../../themes/css/plugins/layer/skin/layer.css" rel="stylesheet" />
    <script>

        var table = $("#table");

        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID
            });
        }
        function addInvoiceInfo() {

            parent.layer.open({
                type: 2,
                title: '发票信息',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['1150px', '650px'],
                content: '/forms/user/invoice/set_invoice.aspx',
                end: function () {
                    location.reload();
                }
            });
        }
        function initialTable() {
            table.bootstrapTable({
                singleSelect: true,
                columns: [
                    {
                        field: 'state',
                        checkbox: true,
                    }, {
                        field: 'Invoice',
                        title: '发票抬头',

                    }, {
                        field: 'TaxNum',
                        title: '税号',
                    },
                    {
                        field: 'Bank',
                        title: '开户行',

                    }, {
                        field: 'AccountNum',
                        title: '银行账户'
                    }, {
                        field: 'Tel',
                        title: '电话号码',
                    }, {
                        field: 'UnitAddress',
                        title: '单位地址'
                    }
                ],
                onLoadSuccess: function (data) {

                    var rows = data.rows.length;
                    if (rows > 0) {
                        $("#message_info").hide();
                        //parent.layer.msg('请先选择要删除的订单');
                        //return false;
                    }
                    if (rows > 5) {
                        $(".expense-iv-after-table-bar").hide();
                        //parent.layer.msg('请先选择要删除的订单');
                        //return false;
                    }
                }
            });

        }
        function changedata() {
            table.bootstrapTable('refresh', {
                url: "?action=GetData&dataType=" + $("#dataType").val() + "&dataType1=" + $("#dataType1").val(),
                silent: true
            });

        };
        function view(id) {
            parent.layer.open({
                type: 2,
                title: 'CORS用户基本信息设置',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['1150px', '650px'],
                content: '/forms/user/order/manage_order.aspx?id=' + id
            });
        }

        //function invoice(id) {
        //    parent.layer.open({
        //        type: 2,
        //        title: 'CORS用户基本信息设置',
        //        shadeClose: true,
        //        shade: false,
        //        maxmin: true, //开启最大化最小化按钮
        //        area: ['1150px', '650px'],
        //        content: '/forms/user/order/manage_order.aspx?id=' + id
        //    });
        //}


        $("#download").click(function () {
            window.location.href = "?action=DownloadAll";

            $("#download").blur();
        });
        $("#refreshcors").click(function () {
            table.bootstrapTable('refresh');

        });



        $("#deletecors").click(function () {
            var ids = getIdSelections();
            if (ids.length == 0) {
                parent.layer.msg('请先选择要删除的订单');
                return false;
            }
            layer.alert('您确定要删除这个订单吗', {
                skin: 'layui-layer-lan' //样式类名
                , btn: ['确定', '取消'], title: '删除'
            }, function () {

                $.ajax({
                    url: "",
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
            ////显示信息
            //var rows = table.bootstrapTable("getOptions").totalRows;
            //if (rows > 0) {
            //    $("#message_info").hide();
            //    //parent.layer.msg('请先选择要删除的订单');
            //    //return false;
            //}
            //if (rows > 5) {
            //    $(".expense-iv-after-table-bar").hide();
            //    //parent.layer.msg('请先选择要删除的订单');
            //    //return false;
            //}
        });
        $("#submitInvoiceApply").click(function () {

            var ids = getIdSelections();
            var id = ids[0];
            if (ids.length == 0) {
                layer.alert('请先选择发票信息', { icon: 1 });
                return false;
            }
            $.ajax({
                url: "/forms/user/invoice/confirm_invoice.aspx",
                type: "post",
                data: {
                    invoiceInfoId: id,
                },
                success: function () {
                    layer.msg('发票申请完成，等待审核', {
                        time: 2000
                    }, function () {
                        window.location.href = "/forms/user/invoice/manage_invoice.aspx?action=random_number";
                    });

                    //layer.msg('发票申请成功,即将跳转',  { icon: 2 }, function () {
                    //        });
                    //setTimeout(function () { window.location.href = "/forms/user/invoice/manage_invoice.aspx?action=random_number"; }, 3000);
                    //layer.alert('删除成功', {
                    //    skin: 'layui-layer-lan' //样式类名
                    //             , closeBtn: 0
                    //});
                    //table.bootstrapTable('remove', {
                    //    field: 'ID',
                    //    values: ids
                    //}); $("#deletecors").blur();

                    //table.bootstrapTable('refresh');
                }, error: function () {
                    layer.msg('发票申请失败', {
                        time: 1000
                    }, function () {
                        window.location.href = "/forms/user/invoice/manage_invoice.aspx?action=random_number";
                    });
                }
            });
        });
        //$.get('/forms/user/invoice/confirm_invoice.aspx?invoiceInfoId=' + id, function (response) {
        //    if (response=="OK")
        //    {
        //        //layer.alert('发票申请成功',  function () {
        //        //    window.location.href = "/forms/user/invoice/manage_invoice.aspx?action=random_number";
        //        //});
        //        //layer.msg('发票申请成功,即将跳转',  { icon: 2 }, function () {
        //        //});
        //        setTimeout(function () { window.location.href = "/forms/user/invoice/manage_invoice.aspx?action=random_number"; }, 3000);
        //    }
        //    else {
        //        layer.alert('发票申请失败', { icon: 2 }, {
        //            time: 500
        //        }, function () {
        //            window.location.href = "/forms/user/invoice/manage_invoice.aspx?action=random_number";
        //        });
        //    }
        //    //layer.msg('发票申请成功', { icon: 1 });
        //    //table.bootstrapTable('refresh');
        //});


    </script>
</body>
</html>
