<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rtkUserDetailInfoView.aspx.cs" Inherits="CORSV2.forms.administrator.users.rtkUserDetailInfoView" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">


    <title>用户信息管理</title><%--1111--%>



    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="../../../themes/css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
</head>

<body class="gray-bg">
    <div class="wrapper wrapper-content animated fadeIn">
        <form id="signupForm" runat="server">

            <div class="col-sm-6" style="width: 100%">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>用户信息</h5>
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
                                        <div>
                                            <label style="width: 10%; text-align: center">用户名</label>
                                            <input type="text" id="UserName" readonly="readonly" runat="server" style="width: 20%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">密码</label>
                                            <input type="text" id="PassWord" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">账号是否可用</label>
                                            <select id="corszhky" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 20%">
                                                <option>可用
                                                </option>
                                                <option>不可用
                                                </option>
                                            </select>

                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 10%; text-align: center">联系人</label>
                                            <input type="text" id="Contacts" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">联系电话</label>
                                            <input type="text" id="Phone" runat="server" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">联系人邮箱</label>
                                            <input type="text" id="contactEmail" runat="server" style="width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px" />
                                        </div>
                                        <div class="hr-line-dashed" runat="server" id="cominfo4"></div>
                                       
                                        <div id="cominfo1" runat="server">
                                            <label style="width: 10%; text-align: center">所属单位</label>
                                            <input type="text" id="company" readonly="readonly" runat="server" style="width: 20%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <%-- <label style="width: 10%; text-align: center">测绘资质</label>
                                            <input type="text" id="chzz" readonly="readonly" runat="server" style="width: 20%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">证书编号</label>
                                            <input type="text" id="zzbh" readonly="readonly" runat="server" style="width: 20%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            --%>
                                            <label style="width: 10%; text-align: center">单位注册地</label>
                                            <input type="text" id="BelongArea" readonly="readonly" runat="server" style="width: 20%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">单位类型</label>
                                            <input type="text" id="dwType" readonly="readonly" runat="server" style="width: 20%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                         <div class="hr-line-dashed"></div>
                                         <div>
                                              <label style="width: 10%; text-align: center">用户所属</label>
                                            <input type="text" id="corsbelongarea" runat="server" style="width: 20%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">用户类型</label>
                                            <input type="text" id="corstype" readonly="readonly" runat="server" style="width: 20%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">

                                            <label style="width: 10%; text-align: center">注册时间</label>
                                            <input type="text" id="regtime" readonly="readonly" runat="server" style="width: 20%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed" id="user2" runat="server"></div>
                                        <div id="user1" runat="server">
                                            <label style="width: 10%; text-align: center;display:none">账户余额</label>
                                            <input type="text" id="UserBalance" runat="server" style="display:none;width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center">身份证</label>
                                            <input type="text" id="IDCardNumber" runat="server" readonly="readonly" style="width: 20%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center;display:none">身份证复印件</label>
                                            <input type="text" id="IDCard" runat="server" readonly="readonly" style="display:none;width: 15%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 1%"></label>
                                            <input type="button" id="viewIDCard" runat="server" style="width: 4%;display:none" class="btn btn-xs btn-white" value="查看" />

                                        </div>
                                        


                                       
                                        <div class="hr-line-dashed" id="cominfo3" runat="server"></div>
                                        <div id="cominfo12" runat="server">
                                            <label style="width: 10%; text-align: center">行业</label>
                                            <input type="text" id="Industry" readonly="readonly" runat="server" style="width: 20%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">

                                            <label style="width: 10%; text-align: center;display:none;">单位余额（元）</label>
                                            <input type="text" id="dwye" readonly="readonly" runat="server" style="display:none;width: 20%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                            <label style="width: 10%; text-align: center;display:none;">扣费金额（元）</label>
                                            <input type="text" id="kfje" value="0" runat="server" onkeyup="(this.v=function(){this.value=this.value.replace(/[^0-9-]+/,'');}).call(this)" onblur="this.v();" style="display:none;width: 20%; background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
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
                        <h5>CORS用户权限</h5>
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
                                            <select id="ssfwky" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                                <option>否</option>
                                                <option>是</option>

                                            </select>
                                            <label style="width: 10%; text-align: center">坐标系获取</label>
                                            <select id="ssdfzbxhq" onchange="ssdfzbxhqchange()" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 24%">
                                                <option>可用</option>

                                                <option>不可用</option>

                                            </select>
                                            <label style="width: 10%; text-align: center">服务类型</label>
                                            <select name="account" id="WorkType" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 24%">
                                                <option>厘米级</option>
                                                <option>亚米级</option>
                                                <option>米级</option>
                                            </select>
                                            </div>
                                            <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 12%; text-align: center">计费模式</label>

                                            <select id="jfms" onchange="ssjfmochange()" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                                <option>包时计费</option>
                                                <option>普通计费</option>

                                            </select>
                                            <label style="width: 10%; text-align: center">包时开始时间</label>
                                            <input class=" layer-date" id="ssbsks" runat="server" style="width: 20%; height: 20px; vertical-align: top" placeholder="YYYY-MM-DD hh:mm:ss" onclick="laydate({ istime: true, format: 'YYYY-MM-DD hh:mm:ss' })" disabled="disabled">
                                            <label class="laydate-icon" style="width: 2%; height: 20px; vertical-align: top"></label>
                                            <label style="width: 10%; text-align: center">包时结束时间</label>
                                            <input class=" layer-date" id="ssbsjs" readonly="readonly" runat="server" style="width: 20%; height: 20px; vertical-align: top" placeholder="YYYY-MM-DD hh:mm:ss" onclick="laydate({ istime: true, format: 'YYYY-MM-DD hh:mm:ss' })" disabled="disabled">
                                            <label class="laydate-icon" style="width: 2%; height: 20px; vertical-align: top"></label>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            
                                            <label style="width: 12%; text-align: center">坐标系</label>
                                            <select id="ssdfzbx" runat="server" onchange="dfzbxchange()" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                            </select>
                                            <label style="width: 10%; text-align: center">是否可用</label>
                                            <select id="ssdfzbxky" onchange="coor_ablechange()" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                                <option>不可用</option>
                                                <option>可用</option>

                                            </select>
                                            <label style="width: 10%; text-align: center">可用坐标系</label>
                                            <input type="text" id="sskyzbx" readonly="readonly" runat="server" style="width: 35%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 12%; text-align: center">源列表配置</label>
                                            <select id="ssylbpz" runat="server" onchange="sourcechange()" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                            </select>
                                            <label style="width: 10%; text-align: center">是否可用</label>
                                            <select id="ssylbky" onchange="changesourcetable()" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                                <option>不可用</option>
                                                <option>可用</option>

                                            </select>
                                            <label style="width: 10%; text-align: center">可用源列表</label>
                                            <input type="text" id="sskyylb" runat="server" readonly="readonly" style="width: 35%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <div>
                                            <label style="width: 12%; text-align: center">作业区域</label>
                                            <select id="sszyqu" onchange="changearea()" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                                <option>全部区域</option>
                                            </select>
                                            <label style="width: 10%; text-align: center">是否可用</label>
                                            <select id="sszyqyky" onchange="changeareaeable()" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                                <option>不可用</option>
                                                <option>可用</option>

                                            </select>
                                            <label style="width: 10%; text-align: center">可用区域</label>
                                            <input type="text" id="sskyqu" runat="server" readonly="readonly" style="width: 35%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                        </div>
                                        <div class="hr-line-dashed"></div>


                                        <div>
                                            <label style="width: 12%; text-align: center">正常高获取</label>
                                            <select id="sszcghq" name="sszcghq" runat="server" readonly="readonly" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 35%">
                                                <option>不可用</option>
                                                <option>可用</option>

                                            </select>
                                            <label style="width: 12%; text-align: center">高程基准</label>
                                            <select id="ssgcjz" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 35%">
                                                <option>85国家高程</option>
                                                <option>56国家高程</option>
                                            </select>
                                        </div>
                                        <div class="hr-line-dashed"></div>
                                        <label style="width: 45%"></label>

                                        <button id="save" type="button" class="btn btn-lg btn-success">保存</button>

                                       <%-- <asp:Button ID="SaveQx" runat="server" type="submit" CssClass="btn btn-lg btn-success" Style="padding-bottom: 5px; vertical-align: top" Text="保存" OnClick="SaveQx_Click" />
                               --%>         <div>
                                            <br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default" style="display: none">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <span class="label label-info" style="background-color: #1c84c6;">2</span>
                                        <a data-toggle="collapse" data-parent="#accordion" href="tabs_panels.html#collapseTwo">事后服务权限</a>
                                    </h4>
                                </div>
                                <div id="collapseTwo1" class="panel-collapse collapse in">
                                    <div class="hr-line-dashed"></div>
                                    <div>
                                        <label style="width: 12%; text-align: center">服务是否可用</label>
                                        <select id="shfwky" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                            <option>否</option>
                                            <option>是</option>

                                        </select>
                                        <label style="width: 10%; text-align: center">计费模式</label>

                                        <select id="shjfms" onchange="shfwmochange()" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">

                                            <option>包时计费</option>
                                            <option>普通计费</option>

                                        </select>
                                        <label style="width: 10%; text-align: center">包时开始时间</label>
                                        <input class=" layer-date" id="shbsks" runat="server" style="width: 10%; height: 20px; vertical-align: top" placeholder="YYYY-MM-DD hh:mm:ss" onclick="laydate({ istime: true, format: 'YYYY-MM-DD hh:mm:ss' })"/>
                                        <label class="laydate-icon" style="width: 2%; height: 20px; vertical-align: top"></label>
                                        <label style="width: 10%; text-align: center">包时结束时间</label>
                                        <input class=" layer-date" id="shbsjs" runat="server" style="width: 10%; height: 20px; vertical-align: top" placeholder="YYYY-MM-DD hh:mm:ss" onclick="laydate({ istime: true, format: 'YYYY-MM-DD hh:mm:ss' })"/>
                                        <label class="laydate-icon" style="width: 2%; height: 20px; vertical-align: top"></label>
                                    </div>
                                    <div class="hr-line-dashed"></div>
                                    <div>
                                        <label style="width: 12%; text-align: center">坐标转换列表</label>
                                        <select id="shzbzhlb" onchange="shzbzhlbchange()" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                        </select>
                                        <label style="width: 10%; text-align: center">是否可用</label>
                                        <select id="shzbky" onchange="shzbzhkychange();" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 10%">
                                            <option>不可用</option>
                                            <option>可用</option>

                                        </select>

                                        <label style="width: 10%; text-align: center">可转坐标系</label>
                                        <input type="text" id="shkzzbx" runat="server" readonly="readonly" style="width: 37%; background-color: #e5e6e7; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; padding-bottom: 2px">
                                    </div>

                                    <div class="hr-line-dashed"></div>
                                    <div>
                                        <label style="width: 12%; text-align: center">平面坐标转换</label>
                                        <select id="shpmzbzh" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 35%">
                                            <option>不可用</option>
                                            <option>可用</option>

                                        </select>
                                        <label style="width: 12%; text-align: center">正常高转换</label>
                                        <select id="shzcgzh" runat="server" style="background-color: #FFFFFF; background-image: none; border: 1px solid #e5e6e7; border-radius: 1px; color: inherit; display: normal; width: 35%">
                                            <option>不可用</option>
                                            <option>可用</option>


                                        </select>
                                    </div>
                                    <div class="hr-line-dashed"></div>

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

  <%--  <script src="../../../js/plugins/validate/jquery.validate.min.js"></script>
    <script src="../../../js/plugins/validate/messages_zh.min.js"></script>--%>
    <script src="../../../js/jquery.form.js"></script>
    <!-- 自定义js -->
    <%--    <script src="../../../js/content.js?v=1.0.0"></script>--%>
    <script src="../../../js/plugins/layer/layer.min.js"></script>

    <!-- layerDate plugin javascript -->
    <script src="../../../js/plugins/layer/laydate/laydate.js"></script>
    <script>
        $("#save").click(function () {

            var PassWord = document.getElementById("PassWord");
            if (PassWord.value == "") {
                layer.alert('密码不能为空', {
                    skin: 'layui-layer-lan', //样式类名,
                });
                return false;
            }
            //var kfje = document.getElementById("kfje");
            //if (kfje.value == "") {
            //    layer.alert('扣费金额', {
            //        skin: 'layui-layer-lan', //样式类名,
            //    });
            //    return false;
            //}
            //else {
            //    if (isNaN(kfje.value)) {
            //        layer.alert('扣费金额格式错误', { skin: 'layui-layer-lan', btn: ['确定'], title: '提示' });

            //        kfje.focus();
            //        return false;
            //    }
            //}
            $.ajax({
                type: "POST",
                url: "?action=save",
                data: $("#signupForm").serialize(),
                asnyc: true,
                success: function (result) {
                    if (result == "1") {
                        
                        layer.alert('保存成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });

                    }
                    else {

                        layer.alert('保存失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });

                    }
                },
                error: function () {
                    layer.alert('保存失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                }
            });
        });
        $("#viewIDCard").click(function () {
            var IDCard = document.getElementById("IDCard");
            if (IDCard.value == "") {
                layer.alert('未上传身份证复印件', { skin: 'layui-layer-lan', btn: ['确定', '取消'], title: '提示' });
            }
            else {
                var a = window.open("../../../" + IDCard.value, "_blank", "top=200,left=200,height=600,width=800,status=yes,toolbar=1,menubar=no,location=no,scrollbars=yes");
            }
        })
        //$().ready(function () {
        //    $("#signupForm").validate({
        //        rules: {

        //            username: {
        //                required: true,
        //                minlength: 3
        //            },
        //            password: {
        //                required: true,
        //                minlength: 5
        //            },
        //            email: {
        //                required: true,
        //                email: true
        //            },
        //            phone: {
        //                required: true,
        //                minlength: 11,
        //                maxlength: 11
        //            },
        //            kfje: {
        //                required: true
        //            }

        //        },
        //        messages: {
        //            username: {
        //                required: "请输入用户名",
        //                minlength: "不少于3个字符"
        //            },
        //            password: {
        //                required: "请输入密码",
        //                minlength: "不少于5个字符"
        //            },
        //            email: "请输入一个正确的邮箱",
        //            phone: {
        //                required: "请输入11手机号码",
        //                minlength: "请输入正确手机号码",
        //                maxlength: "请输入正确手机号码"
        //            },
        //            kfje: {
        //                required: "请输入缴费金额"
        //            }


        //        }
        //    });
        //})

        //实时服务计费模式改变
        function ssjfmochange() {

            if (jfms.selectedIndex == 0) {

                ssbsks.disabled = false;
                ssbsjs.disabled = false;
            }
            else {
                ssbsjs.disabled = true;
                ssbsks.disabled = true;
            }
        }
        //事后服务计费模式改变
        function shfwmochange() {

            if (shjfms.selectedIndex == 0) {

                shbsjs.disabled = false;
                shbsks.disabled = false;
            }
            else {
                shbsjs.disabled = true;
                shbsks.disabled = true;
            }
        }
        //实时地方坐标系获取改变
        function ssdfzbxhqchange() {

            if (ssdfzbxhq.selectedIndex == 1) {
                ssdfzbx.disabled = true;
                ssdfzbxky.disabled = true;
                sszcghq.disabled = true;


            }
            else {
                ssdfzbx.disabled = false;
                ssdfzbxky.disabled = false;
                sszcghq.disabled = false;
            }
        }
        //实时地方坐标系可用改变
        function coor_ablechange() {
            if (ssdfzbxky.selectedIndex == 0) {
                var coor = sskyzbx.value;
                sskyzbx.value = coor.replace(ssdfzbx.value + ";", "");
            }
            else {
                var coor = sskyzbx.value;
                sskyzbx.value = coor + ssdfzbx.value + ";";
            }
        }
        //实时地方坐标系改变
        function dfzbxchange() {
            ssdfzbxky.selectedIndex = 0;
            var zbx = new Array();
            zbx = sskyzbx.value.split(";");
            for (var i = 0; i < zbx.length; i++) {
                if (ssdfzbx.value == zbx[i]) {
                    ssdfzbxky.selectedIndex = 1;
                }
            }
        }
        //实时源列表改变
        function sourcechange() {
            ssylbky.selectedIndex = 0;
            var source1ky = new Array();
            source1ky = sskyylb.value.split(";");
            for (var i = 0; i < source1ky.length; i++) {
                if (source1ky[i] == ssylbpz.value) {
                    ssylbky.selectedIndex = 1;
                }
            }
        }
        //实时源列表是否可用
        function changesourcetable() {
            if (ssylbky.selectedIndex == 0) {
                var source = sskyylb.value;
                sskyylb.value = source.replace(ssylbpz.value + ";", "");
            }
            else {
                var source = sskyylb.value;
                sskyylb.value = source + ssylbpz.value + ";";
            }
        }
        //作业区域改变
        function changearea() {
            sszyqyky.selectedIndex = 0;
            var area1ky = new Array();
            area1ky = sskyqu.value.split(";");
            for (var i = 0; i < area1ky.length; i++) {
                if (area1ky[i] == sszyqu.value) {
                    sszyqyky.selectedIndex = 1;
                }
            }
        }
        //作业区域可用改变
        function changeareaeable() {
            var areaid = sskyqu.value;
            if (sszyqyky.selectedIndex == 1) {
                if (sszyqu.selectedIndex != 0) {
                    areaid += (sszyqu.value + ";");
                    sskyqu.value = areaid.replace("全部区域", "");
                }
                else {
                    sskyqu.value = "全部区域";
                }
            }
            else {

                sskyqu.value = areaid.replace(sszyqu.value + ";", "");
                if (sskyqu.value == "") {
                    sskyqu.value = "全部区域";
                    sszyqyky.selectedIndex = 1;
                    sszyqu.selectedIndex = 0;
                }

            }
        }

        //坐标转换列表改变
        function shzbzhlbchange() {
            shzbky.selectedIndex = 0;
            var coor1ky = new Array();
            coor1ky = shkzzbx.value.split(";");
            for (var i = 0; i < coor1ky.length; i++) {
                if (coor1ky[i] == shzbzhlb.value) {
                    shzbky.selectedIndex = 1;
                }
            }
        }
        //坐标转换列表是否可用改变
        function shzbzhkychange() {
            var kycoor = shkzzbx.value;
            if (shzbky.selectedIndex == 0) {
                shkzzbx.value = kycoor.replace(shzbzhlb.value + ";", "");
            }
            else {
                shkzzbx.value = kycoor.replace(shzbzhlb.value + ";", "") + shzbzhlb.value + ";";
            }
        }
    </script>


</body>

</html>
