<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recharge.aspx.cs" Inherits="CORSV2.forms.publicforms.login.Recharge" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta charset="utf-8" />
    <title>CORS服务选购</title>
    <script src="../../../js/jquery-1.10.2.min.js"></script>
    <script src="../../../js/jquery.form.js"></script>
   
    <link href="../../user/order/css/order_custom.css" rel="stylesheet" />
 
    <link href="../../user/order/css/global.css" rel="stylesheet" />
    <link href="../../user/order/css/shopcart.css" rel="stylesheet" />

</head>
<body class="" style="">
<form  method="post" id="order_form" runat="server"  enctype="multipart/form-data">
        <div class="body" style="margin-top:100px">
            <div class="shop-event" style="display: none" id="actArea">
            </div>

            <div class="mod-shop" id="appArea">
                <div >
                    <div class="shop-body" >
                        <div class="shop-container cvm-compatible-v1" style="margin-top: 0;">

                                <ul class="shop-list">
                       
                                    <li class="list" style="height:10px">
                                        <label class="shop-list-tit" style="width:1100px">
                                            <div>
                                                  <span>在线充值</span>
                                                  <a style="float:right" href="../../administrator/order/PaymentRecord.aspx">充值记录</a>
                                            </div>
                                            <div style="float:right">
                                               
                                            </div>
                                          
                                           
                                        </label>
                                       
                                    </li>
                            
                                   
                                </ul>
                                
                                  
                                    <div class="shop-submit">
                                          <li class="clearfix" style="width:500px">
                                 <label class="labelLeft"><span class="required" style="color:#888888">充值账号：</span></label>

                                 <label class="labelLeft"><span class="required" id="company" runat="server"></span></label><br /><br />
                                    <label class="labelLeft"><span class="required" style="color:#888888">余额：</span></label>
                                      <label class="labelLeft"><span class="required" id="Balance" runat="server"></span>元</label><br /><br />
                                                          <label class="labelLeft"><span class="required" style="color:#888888">充值金额：</span></label>
                                        <input type="text" name="Price" autocomplete="off"   value="" id="Price"  class="b-item"   runat="server"/>元<br /><br />
                         <span class="required" style="width:60px;height:20px;text-align:center;background-color:#FFF4E3; color:#987B4D">充值说明</span>
                                                                      
                                
                                     <span style="color:#888888"  >在线充值不能抵扣垫付未回款，如需抵扣请使用对公汇款；</span><br />
                     <span style="color:#888888"  >原国际信用卡支付渠道已下线，请使用微信支付代替，详情查看 微信国际卡支付指引。</span>

                                                          

                                </li>
                                        <br />
                                        <a href="javascript:;" class="shop-btn pay" id="liteBuySubmit" data-hot="cvmbuy.lite.confirmbuy">立即充值</a><br /><br />
                                        <span class="submit-tips" id="liteBuySubmitErrorTip" style="font-size: 12px; display: none;"></span>
                                    </div>
                                           
                            </div>
                        </div>
                    </div>
                </div>
            </div>
  
    </form>
   
   
   
    <script>
        $('#liteBuySubmit').click(function () {
            var Price = document.getElementById("Price");
            if ($(isNaN(Price.value)).val() ) {
                layer.alert('请输入正确的金额', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
          
                apply_num = Number($('#apply_num').val());
            price = Number($('#price').val());
     
            if (Price.value==""||Price.value<=0) {
                alert('请输入正确的金额');
                 return false;
            }
         
                $('#order_form').ajaxSubmit({
                    type: 'POST',
                    url: "?action=order",
                    data: {
                       
                        company: company,
                        Balance: Balance,
                        
                       
                    },
                    traditional: true,//防止深度序列化
                    success: function (data) {
                        if (data.code == 200) {
                            return false;
                        }
                        if (data.length > 5) {
                            window.location.href = "/forms/user/order/RechargeCheck.aspx?order_number=" + data;
                        }
                    },
                });
            
           
        });
    </script>
</body>
</html>
