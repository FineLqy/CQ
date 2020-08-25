<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update_order.aspx.cs" Inherits="CORSV2.forms.user.order.update_order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta charset="utf-8" />
    <title>CORS服务选购</title>
    <script src="../../../js/jquery-1.10.2.min.js"></script>
    <script src="../../../js/jquery.form.js"></script>
    <link href="css/global.css" rel="stylesheet" />
    <link href="css/shopcart.css" rel="stylesheet" />

</head>
<body class="" style="">
<form  method="post" id="order_form"  enctype="multipart/form-data">
        <div class="body">
            <div class="shop-event" style="display: none" id="actArea">
            </div>

            <div class="mod-shop" id="appArea">
                <div >
                    <div class="shop-body" >
                        <div class="shop-container cvm-compatible-v1" style="margin-top: 0;">
                            <h3> 续费账号:<asp:Label ID="Label1" runat="server" Text=""></asp:Label></h3>
                                <ul class="shop-list">
                       
                                    <li class="list">
                                         
                              
                            
                                        <label class="shop-list-tit">
                                            
                                            <span>服务类型</span>
                                            
                                        </label>
                                        <div class="shop-list-con">
                                            <div id="liteDeviceList">
                                                <ul class="shop-checkblock" >
                                                    <li>
                                                        <label id="m_service_label" class="shop-checkblock-item" data-value="dm" style="border-color: rgb(0, 121, 219);">
                                                            <h3 class="shop-checkblock-item-title">提供亚米级服务</h3>
                                                            <p class="shop-checkblock-item-desc">适用于估计坐标</p>
                                                            <input id="m_service" type="radio" name="demo-product" value="" checked="" class="shop-checkblock-item-radio" /></label></li>
                                                    <li>
                                                        <label id="cm_service_label" class="shop-checkblock-item" data-value="cm" style="border-color: #d8d2d2;">
                                                            <h3 class="shop-checkblock-item-title">提供厘米级服务</h3>
                                                            <p class="shop-checkblock-item-desc">适用于平时作业</p>
                                                            <input id="cm_service" type="radio" name="demo-product" value="" class="shop-checkblock-item-radio" /></label></li>
                                                    <li>
                                                        <label id="mm_service-label" class="shop-checkblock-item" data-value="mm">
                                                            <h3 class="shop-checkblock-item-title">提供毫米级服务</h3>
                                                            <p class="shop-checkblock-item-desc">适用于精密定位</p>
                                                            <input id="mm_service" type="radio" name="demo-product" value="" class="shop-checkblock-item-radio" /></label></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </li>
                                    <li class="list" style="display: none;">
                                        <label class="shop-list-tit">
                                            <span></span>
                                        </label>
                                        <div class="shop-list-con" id="liteMarketImageList"></div>
                                    </li>
                                    <li class="list" style="">
                                        <label class="shop-list-tit">
                                            <span>增值服务</span>
                                        </label>
                                        <div class="shop-list-con" id="liteSystemImageList">
                                            <ul class="shop-os-list shop-os-list-4">
                                                <li class="shop-os-item-box"  data-name="坐标转换" >
                                                    <div class="shop-os-item" data-value="CoorTransEnable" id="coor_tran" style="border-color:rgb(219, 219, 219);">
                                                        <div class="shop-os-logo" >
                                                            <img src="../../../themes/icon/坐标转换.png" alt="" >
                                                        </div>
                                                        <div class="shop-os-con" >
                                                            <h3 class="shop-os-tit" >坐标转换</h3>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="shop-os-item-box" data-value="1" data-name="高程转换 " >
                                                    <div class="shop-os-item" data-value="HeightTransEnable" id="height_tran" style="border-color:rgb(219, 219, 219);">
                                                        <div class="shop-os-logo" >
                                                            <img src="../../../themes/icon/高程转换.png" alt="" >
                                                        </div>
                                                        <div class="shop-os-con" >
                                                            <h3 class="shop-os-tit" >高程转换  </h3>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="shop-os-item-box" data-value="2" data-name="SHP文件转换" >
                                                    <div class="shop-os-item" data-value="SHPTransEnable" id="picture_tran" style="border-color:rgb(219, 219, 219);">
                                                        <div class="shop-os-logo" >
                                                            <img src="../../../themes/icon/图件转换.png" alt="" >
                                                        </div>
                                                        <div class="shop-os-con" >
                                                            <h3 class="shop-os-tit" >SHP文件转换</h3>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="shop-os-item-box" data-value="3" data-name="观测文件质量检查" >
                                                    <div class="shop-os-item" data-value="ObsQualityEnable"   style="border-color:rgb(219, 219, 219);">
                                                        <div class="shop-os-logo" >
                                                            <img src="../../../themes/icon/质量检查.png" alt="" >
                                                        </div>
                                                        <div class="shop-os-con" >
                                                            <h3 class="shop-os-tit" >观测文件质量检查</h3>
                                                        </div>
                                                    </div>
                                                </li>
                                            </ul>
                                        </div>

                                    </li>
                                </ul>
                                <div class="slice"></div>
                                <ul class="shop-list">
                                    <li class="list" style="visibility:hidden">
                                        <label class="shop-list-tit">
                                            <span>购买数量</span>
                                        </label>
                                        <div class="shop-list-con">
                                            <div class="shop-ui-block" id="liteGoodsNum">
                                                <div class="shop-input-num " >
                                                    <span class="shop-input-num-inner" >
                                                        <input type="text" class="num" value="1" id="apply_num" />
                                                        <span class="plus" data-opt="add" id="apply_add">
                                                            <i class="shop-num-plus-icon" ></i>
                                                        </span>
                                                        <span class="minus" data-opt="sub" id="apply_sub">
                                                            <i class="shop-num-minus-icon" ></i>
                                                        </span>
                                                    </span>
                                                    <span class="shop-tip-word">台</span>
                                                    <span class="shop-tip-word" style="display: none;" ></span>
                                                </div>
                                            </div>
                                            <p class="shop-tip-word err-style" id="liteGoodsNumTip" style="display: none"></p>
                                        </div>
                                    </li>
                                    <li class="list">
                                        <label class="shop-list-tit">
                                            <span>续费时长</span>
                                        </label>
                                        <div class="shop-list-con">
                                            <div class="shop-ui-block" id="liteDuration">
                                                <div class="shop-ui-block ui-block-70" >
                                                    <a href="javascript:void(0);" data-value="12"  class="b-item" >
                                                        <span class="text">1年</span><span ></span>
                                                    </a>
                                                    <a href="javascript:void(0);" data-value="24"  class="b-item" >
                                                        <span class="text">2年</span><span ></span>
                                                    </a>
                                                    <a href="javascript:void(0);" data-value="36"  class="b-item" >
                                                        <span class="text">3年</span>
                                                    </a>
                                                    <a href="javascript:void(0);" data-value="48"  class="b-item" >
                                                        <span class="text">4年</span>                                                                                                                                                                                                                                                                     </a>
                                                </div>
                                            </div>
                                            <span class="shop-tip-word">
                                                <a href="javascript:;" id="liteDurationChange">其他时长
                                                </a>
                                            </span>
                                           
                                        </div>
                                    </li>
                                </ul>
                                <div class="shop-submit-wrap fixed" id="litePriceWrap">
                                    <div class="shop-submit">
                                        <div class="cost">
                                            <div class="tit">费用:</div>
                                            <div class="price lite-total-price">
                                                <div class="price-control"><em></em>  <input style="border:none" readonly="readonly" type="text" class="num" value="1000" id="price" /><span  class="unit-txt">元</span></div>
                                            </div>
                                        </div>
                                        <a href="javascript:;" class="shop-btn pay" id="liteBuySubmit" data-hot="cvmbuy.lite.confirmbuy">立即购买</a>
                                        <span class="submit-tips" id="liteBuySubmitErrorTip" style="font-size: 12px; display: none;"></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </form>
    <script>
        //传到后台的订单时间
        var time = 1;
        var servertype = "dm";
        var otherserver = new Array();
        $(".shop-checkblock-item").click(function () {
            $(".shop-checkblock-item").css({ "border-color": "rgb(216, 210, 210)" });
            $(this).css({ "border-color": "rgb(0, 121, 219)" });
            servertype = $(this).attr("data-value");
        });
        $(".shop-os-item").click(function () {
            if ($(this).css("border-color") == "rgb(219, 219, 219)") {
                $(this).css({ "border-color": "rgb(0, 121, 219)" });

            }
            else {
                $(this).css({ "border-color": "rgb(219, 219, 219)" });
            }
        })
        $(".b-item").click(function () {
            time = $(this).attr("data-value");
            $(".b-item").css({ "backgroundColor": "rgb(255, 255 ,255)" });
            $(this).css({ "backgroundColor": "rgb(215, 230, 248)" });
            apply_num = Number($('#apply_num').val());
            var tempPrice = apply_num * Number(time)/12 * 1000;
            $('#price').val(tempPrice);
        })
    </script>
    <script>
        //申请账号个数
        var apply_num;
        $('#apply_add').click(function () {
            if ($('#apply_num').val() != "10") {
                apply_num = Number($('#apply_num').val()) + 1;
                $('#apply_num').val(apply_num);
                time = $(".b-item").attr("data-value");
                var tempPrice = apply_num * time/12 * 1000;
                $('#price').val(tempPrice);
            }

        })
        $('#apply_sub').click(function () {
            if ($('#apply_num').val() != "1") {
                apply_num = Number($('#apply_num').val()) - 1;
                $('#apply_num').val(apply_num);
                time = $(".b-item").attr("data-value");
                var tempPrice = apply_num * time/12 * 1000;
                $('#price').val(tempPrice);
            }
        })

    </script>

      <script>
        $('#liteBuySubmit').click(function () {
            
            if ($(".b-item").val()==1||time==1) {
                alert("请选择购买时长！");
            }
            else {
                apply_num = Number($('#apply_num').val());
                price = Number($('#price').val());
                $('.shop-os-item').each(function (key, value) {
                    if ($(this).css("border-color") == "rgb(0, 121, 219)") {
                        otherserver.push($(this).attr("data-value"));      //如果是其他标签 用 html();
                    }
                });
                $('#order_form').ajaxSubmit({
                    type: 'POST',
                    url: "?action=order",
                    data: {
                        time: time,
                        servertype: servertype,
                        applynum: apply_num,
                        price: price,
                        otherserver: otherserver.join(',')//转换成字符串
                    },
                    traditional: true,//防止深度序列化
                    success: function (data) {
                        if (data.code == 200) {
                            return false;
                        }
                        if (data.length > 5) {
                            window.location.href = "check_order.aspx?order_number=" + data;
                        }
                    },
                });
            }
           
        });
    </script>
 
</body>
</html>