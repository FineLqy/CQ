<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_order.aspx.cs" Inherits="CORSV2.forms.user.order.add_order" %>

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
            <script src="../../../js/jquery-3.1.1.min.js"></script>



   <%--Tab选项卡--%>
    <script src="../../../js/jquery.min.js"></script>
    <script src="../../../js/layui.js"></script>
    <link href="../../../themes/css/layui.css" rel="stylesheet" />
    <script src="../../../js/element.js"></script>
<%--    Table选项卡--%>


    <link href="css/shopcart_1.css" rel="stylesheet" />
</head>
<body class="" style="">
<form  method="post" id="order_form" runat="server"  enctype="multipart/form-data">

                        <div class="shop-container cvm-compatible-v1" style="margin-top: 0;">

<div class="layui-tab">
  <ul class="layui-tab-title">
    <li class="layui-this">快速订单</li>
    <li>自定义订单</li>

  </ul>
  <div class="layui-tab-content">
    <div class="layui-tab-item layui-show">
            <div class="mod-shop" id="appArea">
                <div >
                    <div class="shop-body" >
                        <div class="shop-container cvm-compatible-v1" style="margin-top: 0;">
                            
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
                                    <li class="list">
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
                                            <span>购买时长</span>
                                        </label>
                                        <div class="shop-list-con">
                                            <div class="shop-ui-block" id="liteDuration">
                                                <div class="shop-ui-block ui-block-70" >
                                                    <a href="javascript:void(0);" data-value="12"  class="b-item"  ">
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
                                  


                                      <li class="list">
                                        <label class="shop-list-tit">
                                            <span>否需要漫游</span>
                                        </label>
                                        <div class="shop-list-con">
                                            <div class="shop-ui-block" >
                                                <div class="shop-ui-block ui-block-70" >
                                                     
                                                        <select id="Select1" runat="server"  onchange="change()" style="width:100px;height:30px;font-size:16px">
                                <option value="是">是</option>
                                <option value="否">否</option>

                            </select> &nbsp;&nbsp;
                            <select id="Select2" runat="server" style="width:100px;height:30px; font-size:16px">
                                

                            </select>    <br />
                           
                                                </div>
                                            </div>
                                           

                                           
                                 
                                        </div>
                                    </li>
                                      <li class="list">
                                        <label class="shop-list-tit">
                                            <span>正常高是否可用</span>
                                        </label>
                                        
                                        <div class="shop-list-con" style="margin-top:12px">
                                            <div class="shop-ui-block" >
                                                <div class="shop-ui-block ui-block-70"  >
                                                    &nbsp;  &nbsp;  <input id="Checkbox1" checked="checked" runat="server" type="checkbox" />                                                                                                                                                                                                                                                          </a>
                                                </div>
                                            </div>
                                          
                                        </div>
                                    </li>
                                         <li class="list">
                                        <label class="shop-list-tit">
                                            <span>是否自动续费</span>
                                        </label>
                                        
                                        <div class="shop-list-con" style="margin-top:12px">
                                            <div class="shop-ui-block" >
                                                <div class="shop-ui-block ui-block-70"  >
                                                    &nbsp;  &nbsp;  <input id="Checkbox2" checked="checked" runat="server" type="checkbox" />                                                                                                                                                                                                                                                          </a>
                                                </div>
                                            </div>
                                          

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
    <div class="layui-tab-item">
              <div class="mod-shop" id="appArea">
                <div >
                    <div class="shop-body" >
                        <div class="shop-container cvm-compatible-v1" style="margin-top: 0;">
                            
                                <ul class="shop-list">
                       
                                    <li class="list">
                                        <label class="shop-list-tit">
                                            <span>服务类型</span>
                                        </label>
                                        <div class="shop-list-con">
                                            <div id="liteDeviceList1">
                                                <ul class="shop-checkblock" >
                                                    <li>
                                                        <label id="m_service_label1" class="shop-checkblock-item1" data-value="dm" style="border-color: rgb(0, 121, 219);">
                                                            <h3 class="shop-checkblock-item-title">提供亚米级服务</h3>
                                                            <p class="shop-checkblock-item-desc">适用于估计坐标</p>
                                                            <input id="m_service1" type="radio" name="demo-product" value="" checked="" class="shop-checkblock-item-radio" /></label></li>
                                                    <li>
                                                        <label id="cm_service_label1" class="shop-checkblock-item1" data-value="cm" style="border-color: #d8d2d2;">
                                                            <h3 class="shop-checkblock-item-title">提供厘米级服务</h3>
                                                            <p class="shop-checkblock-item-desc">适用于平时作业</p>
                                                            <input id="cm_service1" type="radio" name="demo-product" value="" class="shop-checkblock-item-radio" /></label></li>
                                                    <li>
                                                        <label id="mm_service-label1" class="shop-checkblock-item1" data-value="mm">
                                                            <h3 class="shop-checkblock-item-title">提供毫米级服务</h3>
                                                            <p class="shop-checkblock-item-desc">适用于精密定位</p>
                                                            <input id="mm_service1" type="radio" name="demo-product" value="" class="shop-checkblock-item-radio" /></label></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </li>
                                    <li class="list" style="display: none;">
                                        <label class="shop-list-tit">
                                            <span></span>
                                        </label>
                                        <div class="shop-list-con" id="liteMarketImageList1"></div>
                                    </li>
                                    <li class="list" style="">
                                        <label class="shop-list-tit">
                                            <span>增值服务</span>
                                        </label>
                                        <div class="shop-list-con" id="liteSystemImageList1">
                                            <ul class="shop-os-list shop-os-list-4">
                                                <li class="shop-os-item-box"  data-name="坐标转换" >
                                                    <div class="shop-os-item1" data-value="CoorTransEnable" id="coor_tran1" style="border-color:rgb(219, 219, 219);">
                                                        <div class="shop-os-logo" >
                                                            <img src="../../../themes/icon/坐标转换.png" alt="" >
                                                        </div>
                                                        <div class="shop-os-con" >
                                                            <h3 class="shop-os-tit" >坐标转换</h3>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="shop-os-item-box" data-value="1" data-name="高程转换 " >
                                                    <div class="shop-os-item1" data-value="HeightTransEnable" id="height_tran1" style="border-color:rgb(219, 219, 219);">
                                                        <div class="shop-os-logo" >
                                                            <img src="../../../themes/icon/高程转换.png" alt="" >
                                                        </div>
                                                        <div class="shop-os-con" >
                                                            <h3 class="shop-os-tit" >高程转换  </h3>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="shop-os-item-box" data-value="2" data-name="SHP文件转换" >
                                                    <div class="shop-os-item1" data-value="SHPTransEnable" id="picture_tran1" style="border-color:rgb(219, 219, 219);">
                                                        <div class="shop-os-logo" >
                                                            <img src="../../../themes/icon/图件转换.png" alt="" >
                                                        </div>
                                                        <div class="shop-os-con" >
                                                            <h3 class="shop-os-tit" >SHP文件转换</h3>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="shop-os-item-box" data-value="3" data-name="观测文件质量检查" >
                                                    <div class="shop-os-item1" data-value="ObsQualityEnable"   style="border-color:rgb(219, 219, 219);">
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
                               
                            <div  >
                                <div style="width:50%;float:left" >
                                 <ul class="shop-list">
                                    <li class="list">
                                        <label class="shop-list-tit">
                                            <span>购买数量</span>
                                        </label>
                                        <div class="shop-list-con">
                                            <div class="shop-ui-block" id="liteGoodsNum1">
                                                <div class="shop-input-num " >
                                                    <span class="shop-input-num-inner" >
                                                        <input type="text" class="num" value="1" id="apply_num1" />
                                                        <span class="plus" data-opt="add" id="apply_add1">
                                                            <i class="shop-num-plus-icon" ></i>
                                                        </span>
                                                        <span class="minus" data-opt="sub" id="apply_sub1">
                                                            <i class="shop-num-minus-icon" ></i>
                                                        </span>
                                                    </span>
                                                    <span class="shop-tip-word">台</span>
                                                    <span class="shop-tip-word" style="display: none;" ></span>
                                                </div>
                                            </div>
                                            <p class="shop-tip-word err-style" id="liteGoodsNumTip1" style="display: none"></p>
                                        </div>
                                    </li>
                                    <li class="list">
                                        <label class="shop-list-tit">
                                            <span>购买时长</span>
                                        </label>
                                        <div class="shop-list-con">
                                            <div class="shop-ui-block" id="liteDuration1">
                                                <div class="shop-ui-block ui-block-70" >
                                                    <a href="javascript:void(0);" data-value="12"  class="b-item1"  >
                                                        <span class="text">1年</span><span ></span>
                                                    </a>
                                                    <a href="javascript:void(0);" data-value="24"  class="b-item1" >
                                                        <span class="text">2年</span><span ></span>
                                                    </a>
                                                    <a href="javascript:void(0);" data-value="36"  class="b-item1" >
                                                        <span class="text">3年</span>
                                                    </a>
                                                    <a href="javascript:void(0);" data-value="48"  class="b-item1" >
                                                        <span class="text">4年</span>                                                                                                                                                                                                                                                                     </a>
                                                </div>
                                            </div>
                                            <span class="shop-tip-word">
                                                <a href="javascript:;" id="liteDurationChange1">其他时长
                                                </a>
                                            </span>

                                        </div>
                                    </li>
                                  


                                      <li class="list">
                                        <label class="shop-list-tit">
                                            <span>否需要漫游</span>
                                        </label>
                                        <div class="shop-list-con">
                                            <div class="shop-ui-block" >
                                                <div class="shop-ui-block ui-block-70" >
                                                     
                                                        <select id="Select3" runat="server"  onchange="change()" style="width:100px;height:30px;font-size:16px">
                                <option value="是">是</option>
                                <option value="否">否</option>

                            </select> &nbsp;&nbsp;
                            <select id="Select4" runat="server" style="width:100px;height:30px; font-size:16px">
                                

                            </select>    <br />
                           
                                                </div>
                                            </div>
                                           

                                           
                                 
                                        </div>
                                    </li>
                                      <li class="list">
                                        <label class="shop-list-tit">
                                            <span>正常高是否可用</span>
                                        </label>
                                        
                                        <div class="shop-list-con" style="margin-top:12px">
                                            <div class="shop-ui-block" >
                                                <div class="shop-ui-block ui-block-70"  >
                                                    &nbsp;  &nbsp;  <input id="Checkbox3" checked="checked" runat="server" type="checkbox" />                                                                                                                                                                                                                                                          </a>
                                                </div>
                                            </div>
                                          
                                        </div>
                                    </li>
                                         <li class="list">
                                        <label class="shop-list-tit">
                                            <span>是否自动续费</span>
                                        </label>
                                        
                                        <div class="shop-list-con" style="margin-top:12px">
                                            <div class="shop-ui-block" >
                                                <div class="shop-ui-block ui-block-70"  >
                                                    &nbsp;  &nbsp;  <input id="Checkbox4" checked="checked" runat="server" type="checkbox" />                                                                                                                                                                                                                                                          </a>
                                                </div>
                                            </div>
                                          

                                        </div>
                                    </li>
                                </ul>
                                </div >
                                <div id="showDiv" style="width:50%;float:left;margin-top:30px">

                                   <input id="inputText1" npropertychange="check(1)" oninput="check(1)" required="required"  placeholder="请输入用户名"   /><span id="msg1" style="color:red"></span>
                                </div>
                            </div>
                           

                                <div class="shop-submit-wrap fixed" id="litePriceWrap1">
                                    <div class="shop-submit">
                                        <div class="cost">
                                            <div class="tit">费用:</div>
                                            <div class="price lite-total-price">
                                                <div class="price-control"><em></em>  <input style="border:none" readonly="readonly" type="text" class="num" value="1000" id="price1" /><span  class="unit-txt">元</span></div>
                                            </div>
                                        </div>
                                        <a href="javascript:;" class="shop-btn pay" id="liteBuySubmit1" data-hot="cvmbuy.lite.confirmbuy">立即购买</a>
                                        <span class="submit-tips" id="liteBuySubmitErrorTip1" style="font-size: 12px; display: none;"></span>
                                    </div>
                                </div>
                               
                       
                                 
                            </div>
                        </div>
                    </div>
                </div>
    </div>
 
  </div>
</div>


                            </div>

           



<!-- 注意：如果你直接复制所有代码到本地，上述js路径需要改成你本地的 -->

         

       
         
  
    </form>

  

    <script>
        function change() {

            if ($("#Select1").val() == "是") {
                document.getElementById("Select2").style.display = "block";
            }
            else {
                document.getElementById("Select2").style.display = "none";
            }
        }
        
           
        
    </script>
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
               $.ajax({
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












    
    <script>
        function change() {

            if ($("#Select3").val() == "是") {
                document.getElementById("Select4").style.display = "block";
            }
            else {
                document.getElementById("Select4").style.display = "none";
            }
        }
        
           
        
    </script>
    <script>
      
       
        //传到后台的订单时间
        var time1 = 1;
        var servertype1 = "dm";
        var otherserver1 = new Array();
        $(".shop-checkblock-item1").click(function () {
            $(".shop-checkblock-item1").css({ "border-color": "rgb(216, 210, 210)" });
            $(this).css({ "border-color": "rgb(0, 121, 219)" });
            servertype1 = $(this).attr("data-value");
        });
        $(".shop-os-item1").click(function () {
            if ($(this).css("border-color") == "rgb(219, 219, 219)") {
                $(this).css({ "border-color": "rgb(0, 121, 219)" });

            }
            else {
                $(this).css({ "border-color": "rgb(219, 219, 219)" });
            }
        })
        

       
     
        $(".b-item1").click(function () {
          
            time1 = $(this).attr("data-value");
           
            $(".b-item1").css({ "backgroundColor": "rgb(255, 255 ,255)" });
            $(this).css({ "backgroundColor": "rgb(215, 230, 248)" });
            apply_num1 = Number($('#apply_num1').val());
            var tempPrice1 = apply_num1 * Number(time1)/12 * 1000;
            $('#price1').val(tempPrice1);
        })
    </script>
    <script>
        //申请账号个数
        var apply_num1;
        $('#apply_add1').click(function () {
            if ($('#apply_num1').val() != "10") {
                apply_num1 = Number($('#apply_num1').val()) + 1;
                $('#apply_num1').val(apply_num1);
                time1 = $(".b-item1").attr("data-value");
                var tempPrice1 = apply_num1 * time1/12 * 1000;
                $('#price1').val(tempPrice1);
                
                
                $('#showDiv').append('<div id=\"d' + apply_num1 + '"><input id=\"inputText' + apply_num1 + '" placeholder="\请输入用户名\"  npropertychange=\"check('+apply_num1+')\" oninput=\"check('+apply_num1+')\" /><span id="\msg' + apply_num1 + '" style=\"color:red"></span></div>')
               
  
            }

        })
        $('#apply_sub1').click(function () {
            if ($('#apply_num1').val() != "1") {
                apply_num1 = Number($('#apply_num1').val()) - 1;
                $('#apply_num1').val(apply_num1);
                time1 = $(".b-item1").attr("data-value");
                var tempPrice1 = apply_num1 * time1/12 * 1000;
                $('#price1').val(tempPrice1);
                $("#d" + Number(apply_num1 + 1)).remove();
            }
        })

    </script>
    <script>
        $('#liteBuySubmit1').click(function () {

            if ($(".b-item1").val() == 1 || time1 == 1) {
                alert("请选择购买时长！");
            }
            else {
                apply_num1 = Number($('#apply_num1').val());
                price1 = Number($('#price1').val());
                $('.shop-os-item1').each(function (key, value) {
                    if ($(this).css("border-color") == "rgb(0, 121, 219)") {
                        otherserver.push($(this).attr("data-value"));      //如果是其他标签 用 html();
                    }
                });
                var username1 = "";
              
                var usernames = [];
              
                for (var i = 1; i < apply_num1 + 1; i++) {

                    usernames[i - 1] = $('#inputText' + i).val();





                }
                usernames.sort();  //数组排序
                var reNum = 0;  //返回结果
                for (var i = 0; i < usernames.length; i++) {
                    if (i + 1 == usernames.length) {
                        continue;
                    }
                    if (usernames[i] == null || usernames[i] == "") {
                       
                    }
                    else {

                         //判断相邻的元素是否相同
                        if (usernames[i] == usernames[i + 1]) {
                            reNum += 1;
                        
                            if (reNum > 0) {
                                alert('不能输入重复的用户名！')

                            }
                        }
                        else {
                            $.ajax({
                                type: 'POST',
                                url: "?action=order1",
                                data: {
                                    time1: time1,
                                    servertype1: servertype1,
                                    applynum1: apply_num1,
                                    price1: price1,
                                    otherserver1: otherserver1.join(','),//转换成字符串
                                    username1: usernames.join(',')
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
                    }

                }





            }

        });
    </script>





        <script>
                //检查输入信息是否合法
            function check(index) {
                console.log(index)
                console.log($('#msg' + index))
            
                var username = $('#inputText' + index).val();
               
            console.log(username)
            $.get("?action=check&&data=" + username.trim(), function (result) {
                if (result == "1") {
                    $('#msg' + index).text('');

                    
                }
                else {

                    $('#msg' + index).text('用户名不可用');
                    console.log($('#msg' + index))
                    return;
                }
            })
        }
    </script>



    <script>
layui.use('element', function(){
  var $ = layui.jquery
  ,element = layui.element; //Tab的切换功能，切换事件监听等，需要依赖element模块
  

  
});
</script>

</body>
</html>
