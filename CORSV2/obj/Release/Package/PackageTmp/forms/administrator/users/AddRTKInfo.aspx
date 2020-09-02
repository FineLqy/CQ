<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRTKInfo.aspx.cs" Inherits="CORSV2.forms.administrator.users.AddRTKInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>CORS用户登记</title>
    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="../../../themes/css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
    <script src="../../../js/jquery-3.1.1.min.js"></script>
    <%--------- table选项卡---------%>
    <script src="../../../js/layui.js"></script>
    <script src="../../../js/element.js"></script>
    <%-----------------------------%>
</head>

<body class="gray-bg">


      
 

    <div class="wrapper wrapper-content animated fadeIn">
        <form runat="server" id="commentForm" method="post">


            <div class="layui-tab">
  <ul class="layui-tab-title">
    <li class="layui-this" style="font-weight:bold">自定义账号添加</li>
    <li style="font-weight:bold">账号自动生成</li>
    
  </ul>
  <div class="layui-tab-content">
    <div class="layui-tab-item layui-show">
     <div class="col-sm-6" style="width: 100%">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>用户登记</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="panel-body">
                            <div class="panel-group" id="accordion">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info" style="background-color: #1c84c6;">1</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseOne">用户基本信息</a>
                                        </h5>
                                    </div>
                                    <div id="collapseOne" class="panel-collapse collapse in">
                                        <div class="hr-line-dashed"></div>
                                       
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">用户名：</label>
                                            <input type="text" id="username" npropertychange="check()" oninput="check()" required="required" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">密码：</label>
                                            <input type="password" id="password" required="required" minlength="5" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">确认密码：</label>
                                            <input type="password" id="conpassword" required="required" minlength="5" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <label style="width: 10%; text-align: center"></label>
                                        <span style="color: red" id="ts"></span>
                                        <div class="hr-line-dashed" style="margin-top: 0px"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">所属单位：</label>
                                             <input type="text" id="Company" readonly="readonly"  runat="server" style="width: 20%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">账户是否可用：</label>
                                            <select name="account" id="status" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 20%">
                                                <option value="1">可用</option>
                                                <option value="0">不可用</option>
                                            </select>
                                            <label style="width: 10%; text-align: center">服务类型：</label>
                                            <select name="account" id="WorkType" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 20%">
                                                <option value="cm">厘米级</option>
                                                <option value="dm">亚米级</option>
                                            </select>
                                        </div>
                                     
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">联系人</label>
                                            <input type="text" id="Contacts" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">联系手机：</label>
                                            <input type="text" id="phone" name="phone" required="required" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" maxlength="11" minlength="11"  runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">Email：</label>
                                            <input type="text" id="email" name="email" required="required" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                       </div>
                                        <div class="hr-line-dashed"></div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-6" style="width: 100%">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>用户权限</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="panel-body">
                            <div class="panel-group" id="accordion1">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info" style="background-color: #1c84c6;">1</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseOne">实时服务权限</a>
                                        </h5>
                                    </div>
                                    <div id="collapseOne1" class="panel-collapse collapse in">

                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 12%; text-align: center">服务是否可用</label>
                                            <select name="account" id="ssfwky" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                                <option value="1">是</option>
                                                <option value="0">否</option>
                                            </select>
                                            <label style="width: 10%; text-align: center">服务模式</label>
                                            <select name="account" id="jfms" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                            <option>包时服务</option>
                                            </select>
                                            <label style="width: 10%; text-align: center">包时开始时间</label>
                                            <input class=" layer-date" id="ssbsks" runat="server" autocomplete="off" style="width: 10%;  height: 20px; vertical-align: top" placeholder="YYYY-MM-DD hh:mm:ss" onclick="laydate({ istime: true, format: 'YYYY-MM-DD hh:mm:ss' })">
                                            <label class="laydate-icon" style="width: 2%; height: 20px; vertical-align: top"></label>
                                            <label style="width: 10%; text-align: center">包时结束时间</label>
                                            <input class=" layer-date" id="ssbsjs" runat="server" autocomplete="off" style="width: 10%; height: 20px; vertical-align: top" placeholder="YYYY-MM-DD hh:mm:ss" onclick="laydate({ istime: true, format: 'YYYY-MM-DD hh:mm:ss' })">
                                            <label class="laydate-icon" style="width: 2%; height: 20px; vertical-align: top"></label>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                       
                                            <label style="width: 12%; text-align: center">地方坐标系</label>
                                            <select name="account" id="ssdfzbx" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                            </select>
                                            <label style="width: 10%; text-align: center">是否可用</label>
                                            <select name="account" id="ssdfzbxky" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                                <option>不可用</option>
                                                <option>可用</option>
                                            </select>
                                            <label style="width: 10%; text-align: center">可用坐标系</label>
                                            <input type="text" id="sskyzbx" readonly="readonly" runat="server" style="width: 35%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 12%; text-align: center">源列表配置</label>
                                            <select name="account" id="ssylbpz" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                            </select>
                                            <label style="width: 10%; text-align: center">是否可用</label>
                                            <select name="account" id="ssylbky" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                                <option>不可用</option>
                                                <option>可用</option>
                                            </select>
                                            <label style="width: 10%; text-align: center">可用源列表</label>
                                            <input type="text" id="sskyylb" runat="server" readonly="readonly" style="width: 35%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 12%; text-align: center">正常高获取</label>
                                            <select name="account" id="sszcghq" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 35%">
                                                <option value="1">可用</option>
                                                <option value="0">不可用</option>
                                            </select>
                                            <label style="width: 12%; text-align: center">高程基准</label>
                                            <select name="account" id="ssgcjz" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 35%">
                                                <option value="85GC">85国家高程</option>
                                                <option value="56GC">56国家高程</option>
                                            </select>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                                                        
                                        <div style="margin-left:45%">   
                                            <button type="button" id="SaveBtn" class="btn btn-sm btn-primary" runat="server" style="padding-bottom: 5px; vertical-align: top">添加用户</button>
                                    
                                            <br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

    </div>
    <div class="layui-tab-item">

          <div class="col-sm-6" style="width: 100%">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>用户登记</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="panel-body">
                            <div class="panel-group" id="accordion11">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info" style="background-color: #1c84c6;">1</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseOne">用户基本信息</a>
                                        </h5>
                                    </div>
                                    <div id="collapseOne11" class="panel-collapse collapse in">
                                        <div class="hr-line-dashed"></div>
                                       
                                        <div class="hr-line-dashed"></div>
                                <%--        <div>
                                            <label style="width: 10%; text-align: center">用户名：</label>
                                            <input type="text" id="Text1" npropertychange="check()" oninput="check()" required="required" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">密码：</label>
                                            <input type="password" id="password1" required="required" minlength="5" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">确认密码：</label>
                                            <input type="password" id="Password2" required="required" minlength="5" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>--%>
                                    <%--    <label style="width: 10%; text-align: center"></label>
                                        <span style="color: red" id="ts"></span>
                                        <div class="hr-line-dashed" style="margin-top: 0px"></div>--%>
                                        <div>
                                            <label style="width: 10%; text-align: center">所属单位：</label>
                                             <input type="text" id="Company1" readonly="readonly"  runat="server" style="width: 20%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">账户是否可用：</label>
                                            <select name="account" id="status1" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                                <option value="1">可用</option>
                                                <option value="0">不可用</option>
                                            </select>
                                            <label style="width: 10%; text-align: center">服务类型：</label>
                                            <select name="account" id="WorkType1" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                                <option value="cm">厘米级</option>
                                                <option value="dm">亚米级</option>
                                            </select>
                                            <label style="width: 10%; text-align: center">账号发放个数：</label>
                                             <input type="text" id="AccountNumber"  runat="server" style="width: 10%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                     
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">联系人</label>
                                            <input type="text" id="Contacts1" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">联系手机：</label>
                                            <input type="text" id="phone1"  name="phone1" required="required" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" maxlength="11" minlength="11"  runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">Email：</label>
                                            <input type="text" id="email1" name="email1" required="required" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                       </div>
                                        <div class="hr-line-dashed"></div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-6" style="width: 100%">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>用户权限</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="panel-body">
                            <div class="panel-group" id="accordion111">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h5 class="panel-title">
                                            <span class="label label-info" style="background-color: #1c84c6;">1</span> <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseOne">实时服务权限</a>
                                        </h5>
                                    </div>
                                    <div id="collapseOne111" class="panel-collapse collapse in">

                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 12%; text-align: center">服务是否可用</label>
                                            <select name="account" id="ssfwky1" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                                <option value="1">是</option>
                                                <option value="0">否</option>
                                            </select>
                                            <label style="width: 10%; text-align: center">服务模式</label>
                                            <select name="account" id="jfms1" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                            <option>包时服务</option>
                                            </select>
                                            <label style="width: 10%; text-align: center">包时开始时间</label>
                                            <input class=" layer-date" id="ssbsks1" runat="server" autocomplete="off" style="width: 10%;  height: 20px; vertical-align: top" placeholder="YYYY-MM-DD hh:mm:ss" onclick="laydate({ istime: true, format: 'YYYY-MM-DD hh:mm:ss' })">
                                            <label class="laydate-icon" style="width: 2%; height: 20px; vertical-align: top"></label>
                                            <label style="width: 10%; text-align: center">包时结束时间</label>
                                            <input class=" layer-date" id="ssbsjs1" runat="server" autocomplete="off" style="width: 10%; height: 20px; vertical-align: top" placeholder="YYYY-MM-DD hh:mm:ss" onclick="laydate({ istime: true, format: 'YYYY-MM-DD hh:mm:ss' })">
                                            <label class="laydate-icon" style="width: 2%; height: 20px; vertical-align: top"></label>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                       
                                            <label style="width: 12%; text-align: center">地方坐标系</label>
                                            <select name="account" id="ssdfzbx1" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                            </select>
                                            <label style="width: 10%; text-align: center">是否可用</label>
                                            <select name="account" id="ssdfzbxky1" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                                <option>不可用</option>
                                                <option>可用</option>
                                            </select>
                                            <label style="width: 10%; text-align: center">可用坐标系</label>
                                            <input type="text" id="sskyzbx1" readonly="readonly" runat="server" style="width: 35%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 12%; text-align: center">源列表配置</label>
                                            <select name="account" id="ssylbpz1" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                            </select>
                                            <label style="width: 10%; text-align: center">是否可用</label>
                                            <select name="account" id="ssylbky1" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                                <option>不可用</option>
                                                <option>可用</option>
                                            </select>
                                            <label style="width: 10%; text-align: center">可用源列表</label>
                                            <input type="text" id="sskyylb1" runat="server" readonly="readonly" style="width: 35%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 12%; text-align: center">正常高获取</label>
                                            <select name="account" id="sszcghq1" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 35%">
                                                <option value="1">可用</option>
                                                <option value="0">不可用</option>
                                            </select>
                                            <label style="width: 12%; text-align: center">高程基准</label>
                                            <select name="account" id="ssgcjz1" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 35%">
                                                <option value="85GC">85国家高程</option>
                                                <option value="56GC">56国家高程</option>
                                            </select>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                                                        
                                        <div style="margin-left:45%">   
                                            <button type="button" id="SaveBtn1" class="btn btn-sm btn-primary" runat="server" style="padding-bottom: 5px; vertical-align: top">添加用户</button>
                                    
                                            <br />
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
</div>





        </form>

    </div>

    <!-- 全局js -->
    <script src="../../../js/jquery.min.js?v=2.1.4"></script>
    <script src="../../../js/bootstrap.min.js?v=3.3.6"></script>
    <script src="../../../js/jquery.form.js"></script>
    <link href="../../../themes/css/layui.css" rel="stylesheet" />
    <!-- 自定义js -->
    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <!-- layerDate plugin javascript -->
    <script src="../../../js/plugins/layer/laydate/laydate.js"></script>
    <script src="../../../js/layui.js"></script>

    <script>
//注意：选项卡 依赖 element 模块，否则无法进行功能性操作
layui.use('element', function(){
  var element = layui.element;
  
  
});
</script>
    <script type="text/javascript">

        $('#SaveBtn').click(function () {
            if ($("#username").val().trim() == "") {
                layer.tips('用户名不能为空', '#username', {
                    tips: [2, '#a94442']
                });
                $("#username").focus();
                return false;
            }
            if ($("#password").val().trim() == "") {
                layer.tips('密码不能为空', '#password', {
                    tips: [2, '#a94442']
                });
                $("#password").focus();
                return false;
            }
          
            if ($("#conpassword").val().trim() == "") {
                layer.tips('确认密码不能为空', '#conpassword', {
                    tips: [2, '#a94442']
                });
                $("#conpassword").focus();
                return false;
            }
            if ($("#conpassword").val().trim() != $("#password").val().trim())
            {
                layer.tips('密码不一致', '#conpassword', {
                    tips: [2, '#a94442']
                });
                $("#conpassword").focus();
                return false;
            }
            if ($("#Contacts").val().trim() == "") {
                layer.tips('联系人不能为空', '#Contacts', {
                    tips: [2, '#a94442']
                });
                $("#Contacts").focus();
                return false;
            }
            if ($("#phone").val().trim() == "") {
                layer.tips('联系人电话不能为空', '#phone', {
                    tips: [2, '#a94442']
                });
                $("#phone").focus();
                return false;
            }
            if ($("#email").val().trim() == "") {
                layer.tips('联系人邮箱不能为空', '#email', {
                    tips: [2, '#a94442']
                });
                $("#email").focus();
                return false;
            }
            var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
            if (!myreg.test($("#email").val().trim())) {
                layer.tips('联系人邮箱格式错误', '#email', {
                    tips: [2, '#a94442']
                });
                $("#email").focus();
                return false;
            }

            if ($("#ssbsks").val().trim() == "") {
                layer.tips('时间不能为空', '#ssbsks', {
                    tips: [2, '#a94442']
                });
                $("#ssbsks").focus();
                return false;
            }

            if ($("#ssbsjs").val().trim() == "") {
                layer.tips('时间不能为空', '#ssbsjs', {
                    tips: [2, '#a94442']
                });
                $("#ssbsjs").focus();
                return false;
            }
            var options = {
                url: "?action=AddUser",// HtmlUtil.htmlEncode(tableText),
                type: "POST",
                //data: $("#commentForm").serialize(),
                success: function (result) {
                    switch(result)
                    {
                        case "1": {
                            layer.alert('添加成功', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                                                    
                            break;
                        }
                        case "0": {
                            layer.alert('添加失败', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            break;
                        }
                        case "-1": {
                            layer.alert('用户名已存在', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            break;
                        }
                        case "-2": {
                            layer.alert('用户数已达上限', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            var btn = document.getElementById("SaveBtn");
                            btn.disabled = true;
                            break;
                        }
                        default: {
                            layer.alert('添加失败', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            break;
                        }
                    }
                }, error: function () {
                    layer.alert('添加失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            };
            $("#commentForm").ajaxSubmit(options);

        });

        //检查输入信息是否合法
        function check() {
            var user = document.getElementById("username");
            var username = user.value.trim();
            $.get("?action=check&&data=" + username.trim(), function (result) {
                if (result == "1") {
                    var cm = document.getElementById("ts");
                    cm.innerText = ""
                }
                else {
                    var cm = document.getElementById("ts");
                    cm.innerText = "用户名不可用"
                    user.focus();
                    return;
                }
            })
        }


        //源列表是否可用
        $("#ssylbky").change(function () {
            if (ssylbky.selectedIndex == 0) {
                var source = sskyylb.value;
                sskyylb.value = source.replace(ssylbpz.value + ";", "");
            }
            else {
                var source = sskyylb.value;
                sskyylb.value = source.replace(ssylbpz.value + ";", "") + ssylbpz.value + ";";
            }
        });

        //实时源列表改变
        $("#ssylbpz").change(function () {
            ssylbky.selectedIndex = 0;
            var source1ky = new Array();
            source1ky = sskyylb.value.split(";");
            for (var i = 0; i < source1ky.length; i++) {
                if (source1ky[i] == ssylbpz.value) {
                    ssylbky.selectedIndex = 1;
                }
            }
        });

        //坐標系可用改變
        $("#ssdfzbxky").change(function () {
            if (ssdfzbxky.selectedIndex == 0) {
                var coor = sskyzbx.value;
                sskyzbx.value = coor.replace(ssdfzbx.value + ";", "");
            }
            else {
                var coor = sskyzbx.value;
                sskyzbx.value = coor.replace(ssdfzbx.value + ";", "") + ssdfzbx.value + ";";
            }
        });

        //坐標系改變
        $("#ssdfzbx").change(function () {
            ssdfzbxky.selectedIndex = 0;
            var zbx = new Array();
            zbx = sskyzbx.value.split(";");
            for (var i = 0; i < zbx.length; i++) {
                if (ssdfzbx.value == zbx[i]) {
                    ssdfzbxky.selectedIndex = 1;
                }
            }
        })
    </script>

      <script type="text/javascript">

          $('#SaveBtn1').click(function () {

              if ($("#AccountNumber").val().trim() == "")
              {
                   layer.tips('请输入添加的账号个数', '#AccountNumber', {
                    tips: [2, '#a94442']
                });
                $("#AccountNumber").focus();
                return false;
              }
            
            if ($("#Contacts1").val().trim() == "") {
                layer.tips('联系人不能为空', '#Contacts1', {
                    tips: [2, '#a94442']
                });
                $("#Contacts1").focus();
                return false;
            }
            if ($("#phone1").val().trim() == "") {
                layer.tips('联系人电话不能为空', '#phone1', {
                    tips: [2, '#a94442']
                });
                $("#phone1").focus();
                return false;
            }
            if ($("#email1").val().trim() == "") {
                layer.tips('联系人邮箱不能为空', '#email1', {
                    tips: [2, '#a94442']
                });
                $("#email1").focus();
                return false;
            }
            var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
            if (!myreg.test($("#email1").val().trim())) {
                layer.tips('联系人邮箱格式错误', '#email1', {
                    tips: [2, '#a94442']
                });
                $("#email1").focus();
                return false;
            }

            if ($("#ssbsks1").val().trim() == "") {
                layer.tips('时间不能为空', '#ssbsks1', {
                    tips: [2, '#a94442']
                });
                $("#ssbsks1").focus();
                return false;
            }

            if ($("#ssbsjs1").val().trim() == "") {
                layer.tips('时间不能为空', '#ssbsjs1', {
                    tips: [2, '#a94442']
                });
                $("#ssbsjs1").focus();
                return false;
            }
            var options = {
                url: "?action=AddUser1",// HtmlUtil.htmlEncode(tableText),
                type: "POST",
                //data: $("#commentForm").serialize(),
                success: function (result) {
                    switch(result)
                    {
                        case "1": {
                            layer.alert('添加成功', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                           
                            break;
                        }
                        case "0": {
                            layer.alert('上传失败', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            break;
                        }
                        case "-1": {
                            layer.alert('用户名已存在', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            break;
                        }
                        case "-2": {
                            layer.alert('用户数已达上限', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            var btn = document.getElementById("SaveBtn1");
                            btn.disabled = true;
                            break;
                        }
                        default: {
                            layer.alert('添加失败', {
                                skin: 'layui-layer-lan', //样式类名,
                            });
                            break;
                        }
                    }
                }, error: function () {
                    layer.alert('添加失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                    return false;
                }
            };
            $("#commentForm").ajaxSubmit(options);

        });

        //检查输入信息是否合法
        //function check() {
        //    var user = document.getElementById("username");
        //    var username = user.value.trim();
        //    $.get("?action=check&&data=" + username.trim(), function (result) {
        //        if (result == "1") {
        //            var cm = document.getElementById("ts");
        //            cm.innerText = ""
        //        }
        //        else {
        //            var cm = document.getElementById("ts");
        //            cm.innerText = "用户名不可用"
        //            user.focus();
        //            return;
        //        }
        //    })
        //}


        //源列表是否可用
        $("#ssylbky1").change(function () {
            if (ssylbky1.selectedIndex == 0) {
                var source1 = sskyylb1.value;
                sskyylb1.value = source1.replace(ssylbpz1.value + ";", "");
            }
            else {
                var source1 = sskyylb1.value;
                sskyylb1.value = source1.replace(ssylbpz1.value + ";", "") + ssylbpz1.value + ";";
            }
        });

        //实时源列表改变
        $("#ssylbpz1").change(function () {
            ssylbky1.selectedIndex = 0;
            var source1ky1 = new Array();
            source1ky1 = sskyylb1.value.split(";");
            for (var i = 0; i < source1ky1.length; i++) {
                if (source1ky1[i] == ssylbpz1.value) {
                    ssylbky1.selectedIndex = 1;
                }
            }
        });

        //坐標系可用改變
        $("#ssdfzbxky1").change(function () {
            if (ssdfzbxky1.selectedIndex == 0) {
                var coor = sskyzbx1.value;
                sskyzbx1.value = coor.replace(ssdfzbx1.value + ";", "");
            }
            else {
                var coor = sskyzbx1.value;
                sskyzbx1.value = coor.replace(ssdfzbx1.value + ";", "") + ssdfzbx1.value + ";";
            }
        });

        //坐標系改變
        $("#ssdfzbx1").change(function () {
            ssdfzbxky1.selectedIndex = 0;
            var zbx = new Array();
            zbx = sskyzbx1.value.split(";");
            for (var i = 0; i < zbx.length; i++) {
                if (ssdfzbx1.value == zbx[i]) {
                    ssdfzbxky1.selectedIndex = 1;
                }
            }
        })
    </script>

</body>

</html>
