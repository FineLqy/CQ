<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="end_order.aspx.cs" Inherits="CORSV2.forms.user.order.end" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta charset="utf-8">
    <title>订单支付 -CORS服务</title>
    <meta name="keywords" content="CORS服务">
    <script>
        var speedMark = new Date();
</script>
<link href="//imgcache.qq.com/open_proj/proj_qcloud_v2/gateway/portal/css/global.css?max_age=2000002" rel="stylesheet" media="screen"/>
<link href="//imgcache.qq.com/open_proj/proj_qcloud_v2/gateway/shopcart/css/shopcart.css?max_age=2000003" rel="stylesheet" media="screen" />
<link href='//imgcache.qq.com/qcloud/app/resource/ac/favicon.ico' rel='icon' type='image/x-icon'/>
<style>
</style>

</head>
    <body>
    <div class="body">
        <div class="mod-pay">
            <!--head start-->
            <div class="pay-head">
                <div class="pay-head-mod clearfix">
                    <div class="pay-head-title">
                        <h2>支付</h2>
                    </div>
                    <div class="pay-head-step">
                        <ul>
                            <li class="first succeed"><em>1</em><span>核对信息</span></li>
                            <li class="curr"><em>2</em><span>支付</span></li>
                            <li class="curr"><em>3</em><span>支付结果</span></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!--head end-->

            <!--body start-->
            <div class="pay-body" id="pay_wrap">
            
                <div class="payment-wrap">
                    <div class="payment-top clearfix">
                        <div class="payment-left">
                            <div class="payment-tit">
                                <span>交易对象：</span>
                                <em>重庆市测绘工程院</em>
                            </div>
                        </div>
<%--                        <div class="payment-right">
                            <div class="cost">
                                <span class="tit">订单金额:</span>
							<span class="price">
								<span class="unit-icon">¥<%=price %></span>
								<em></em>
							</span>
                            </div>
                        </div>--%>
                    </div>
                
                    <div class="payment-mod clearfix" data-balance="0">
                    
                        <div class="payment-center payment-balance" style="text-align:center;" >
                            <label >
                                <span  style=" font-size: 32px;">支付成功</span>
                            </label>
                            
                        </div>
                    
                    </div>
                    
   
                    
             
                
                </div>
                <div id="iframeContainer" class="dialog-layer" style="display:none;z-index: 1000;">
                    <a class="close" title="关闭" href="javascript:;" id="iframeClose"><i>×</i></a>
                </div>
                <div class="shop-mask" id="iframeMask" style="display:none;"></div>
            <!--body end-->

            </div>
        </div>
    </div>
    

</body>
</html>
