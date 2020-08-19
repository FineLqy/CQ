<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <title>Layui</title>
  <meta name="renderer" content="webkit">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
  <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <script src="publicforms/register/js/jquery.min.js"></script>
    
    <script src="../js/layui.js"></script>
    <link href="../themes/css/layui.css" rel="stylesheet" />
    <script src="../js/element.js"></script>
  <!-- 注意：如果你直接复制所有代码到本地，上述css路径需要改成你本地的 -->
</head>
<body>
              

 
<div class="layui-tab">
  <ul class="layui-tab-title">
    <li class="layui-this">网站设置</li>
    <li>用户管理</li>
    <li>权限分配</li>
    <li>商品管理</li>
    <li>订单管理</li>
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
    <div class="layui-tab-item">内容2</div>
    <div class="layui-tab-item">内容3</div>
    <div class="layui-tab-item">内容4</div>
    <div class="layui-tab-item">内容5</div>
  </div>
</div>



<!-- 注意：如果你直接复制所有代码到本地，上述js路径需要改成你本地的 -->
<script>
layui.use('element', function(){
  var $ = layui.jquery
  ,element = layui.element; //Tab的切换功能，切换事件监听等，需要依赖element模块
  

  
});
</script>

</body>
</html>