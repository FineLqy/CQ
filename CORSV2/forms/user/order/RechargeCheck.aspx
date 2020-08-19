<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RechargeCheck.aspx.cs" Inherits="CORSV2.forms.user.order.RechargeCheck" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta charset="utf-8">
<%--    <title>订单支付 - 腾讯云</title>
    <meta name="keywords" content="云服务器,购买,腾讯云">
    <meta name="description" content="购买享优惠，免费领取代金券。腾讯云为企业提供近30款云产品，助力企业轻松跨入“互联网+”时代，产品包含云服务器、云数据库、云缓存Memcached、负载均衡、弹性web引擎等核心产品，立即购买多重优惠来袭！">
    <meta name="baidu-site-verification" content="EmN5HW4k98" />--%>
    <script>
        var speedMark = new Date();
    </script>
    <link href="//imgcache.qq.com/open_proj/proj_qcloud_v2/gateway/portal/css/global.css?max_age=2000002" rel="stylesheet" media="screen" />
    <link href="//imgcache.qq.com/open_proj/proj_qcloud_v2/gateway/shopcart/css/shopcart.css?max_age=2000003" rel="stylesheet" media="screen" />
    <link href='//imgcache.qq.com/qcloud/app/resource/ac/favicon.ico' rel='icon' type='image/x-icon' />
    <style>
</style>

    <style type="text/css">
        span.buy-warn-tip {
            color: red;
            vertical-align: initial;
            margin-left: 0px;
        }
    </style>
</head>
<!--[if IE 8 ]> <body class="ie8 "> <![endif]-->
<!--[if gt IE 8]><!-->
<body class="">
    <!--<![endif]-->


    <!--[if lt IE 9]>
<link href="//imgcache.qq.com/open_proj/proj_qcloud_v2/gateway/portal/css/global-components.css?max_age=31536000" rel="stylesheet" media="screen"/>
<script src="//imgcache.qq.com/qcloud/main/scripts/release/common/libs/updateTips.js?max_age=31536000&v=20161118"></script>
<![endif]-->
    <div class="body">
        <div class="mod-pay">
            <!--head start-->
            <div class="pay-head">
                <div class="pay-head-mod clearfix">
                    <div class="pay-head-title">
                        <h2>核对信息</h2>
                    </div>
                    <div class="pay-head-step">
                        <ul>
                            <li class="first curr"><em>1</em><span>核对信息</span></li>
                            <li class=""><em>2</em><span>支付</span></li>
                            <li class=""><em>3</em><span>支付结果</span></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!--head end-->

            <!--body start-->
            <div class="pay-body">
                <div id="check_container">

                    <div class="pay-table-panel">
                        <div class="shop-table-panel">
                            <div class="shop-table-fixed-head">
                                <table class="shop-table-box">
                                    <colgroup>
                                        <col style="width: 140px;">
                                        <col style="width: 275px;">
                                        <col style="width: 100px">
                                        <col style="width: 90px;">
                                        <col style="width: 90px;">

                                        <col style="width: 100px;">
                                        <col style="width: 100px;">
                                        <col style="width: 110px;">
                                        <col style="width: 50px;">
                                    </colgroup>
                                    <thead>
                                        <tr tabindex="0">
                                            <th>
                                                <div class="first-txt">
                                                    <span class="shop-th-sort-btn">
                                                        <span class="text-overflow" title="产品名称">产品名称</span>
                                                    </span>
                                                </div>
                                            </th>
                                            <th>
                                                <div>
                                                    <span class="shop-th-sort-btn">
                                                        <span class="text-overflow" title="单位名">单位名</span>
                                                    </span>
                                                </div>
                                            </th>
                                     
                                        
                                            <th>
                                                <div>
                                                    <span class="shop-th-sort-btn">
                                                        <span class="text-overflow" title="付费方式">付费方式</span>
                                                    </span>
                                                </div>
                                            </th>

                                          
                                            <th>
                                                <div>
                                                    <span class="shop-th-sort-btn">
                                                        <span class="text-overflow" title="优惠">优惠</span>
                                                    </span>
                                                </div>
                                            </th>
                                            <th>
                                                <div>
                                                    <span class="shop-th-sort-btn">

                                                        <span class="text-overflow" title="费用">费用</span>

                                                    </span>
                                                </div>
                                            </th>
                                            <th>
                                                <div>
                                                    <span class="shop-th-sort-btn">
                                                        <span></span>
                                                    </span>
                                                </div>
                                            </th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>

                            <div class="shop-table-fixed-body">
                                <table class="shop-table-box shop-table-rowhover" id="orderTable">
                                    <colgroup>
                                        <col style="width: 140px;">
                                        <col style="width: 275px;">
                                        <col style="width: 100px">
                                        <col style="width: 90px;">
                                        <col style="width: 90px;">

                                        <col style="width: 100px;">
                                        <col style="width: 100px;">
                                        <col style="width: 110px;">
                                        <col style="width: 50px;">
                                    </colgroup>
                                    <tbody>


                                        <tr tabindex="0">
                                            <td>
                                                <div id="order_number_div" class="first-txt" runat="server">
                                                    <%=order_number%>
<%--                                                  <input id="order_number_input" name="order_number_input" value= >--%>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="text-list-wrap">

                                                    <%=company%>
                                                </div>
                                            </td>
                                            <td>
                                                <div>
                                               
                                                
                                                </div>
                                            </td>
                                           
                                        
                                       
                                            <td>
                                                <div class="text-list-wrap">
                                                    无                                                
                                                </div>
                                            </td>
                                            <td>
                                                <div>
                                                    <div class="shop-td-cost">

                                                        <p class="shop-td-price">
                                                            <em>元</em>
                                                        </p>
                                                    </div>
                                                </div>
                                            </td>
                                            <td>
                                                <div>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div>

                        <div class="pay-fixed-mod">
                            <div class="pay-submit-wrap check_pay_submit_wrap">
                                <div class="pay-submit">
                                    <div class="cost">
                                        <span class="tit">总计费用:</span>
                                        <span class="price" data-id="realTotalCost">
                                            <span class="unit-icon">¥ <%=price%></span>
                                            <em class="check_real_total_cost"></em>
                                        </span>
                                    </div>
                                    <div class="pay-btn-wrap check_pay_btn_wrap">

                                        <a  class="shop-btn weak check_pay_btn check_apply_agent_pay_btn" style="" id="back" ><span></span>返回上页</a>
                                        <a  class="shop-btn pay check_pay_btn check_self_pay_btn" data-type="generalUserPayBtn" id="confirm"><span></span>
                                            确认购买                                            
                                        </a>
                                    </div>
<%--                                    <div><input id="order_number" name="order_number" runat="server" readonly="readonly" disabled="disabled" style.display="block" /></div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--body end-->
        </div>
    </div>
    <script src="../../../js/jquery-1.10.2.min.js"></script>
    <script src="../../../js/jquery.form.js"></script>
    <script>
        $("#confirm").click(function () {
            var order_number = document.getElementById("order_number_div").innerText;// $("#order_number_div").text;
            window.location.href = "Pay_Recharge.aspx?order_number=" + order_number;
            //$.ajax({
            //    type: "get",
            //    data:{
            //        ordernumber: order_number
            //    },
            //    url: "?action=confirm",
            //    success: function (data) {
            //        window.location.href = "pay_order.aspx?order_number="+data;
            //        //alert(data);
            //    }
                //  window.location.href = "?action=order_number_div";

        });
        $("#back").click(function () {
            var order_number = document.getElementById("order_number_div").innerText;// $("#order_number_div").text;
            //window.location.href = "pay_order.aspx?order_number=" + order_number;
            $.ajax({
                type: "post",
                data: {
                    ordernumber: order_number
                },
                url: "?action=back",
                success: function (data) {
                   // window.location.href = "add_order.aspx";
                    //alert(data);
                }
            });
            //  window.location.href = "?action=order_number_div";

        });
    </script>
</body>
</html>