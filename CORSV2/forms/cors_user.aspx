<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cors_user.aspx.cs" Inherits="CORSV2.forms.cors_user" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="renderer" content="webkit" />
    <title>卫星导航定位基准站网服务管理系统</title>
    <link rel="shortcut icon" href="../themes/images/favicon.ico" />
    <link href="../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet" />
    <link href="../themes/css/font-awesome.min.css?v=4.4.0" rel="stylesheet" />
    <link href="../themes/css/animate.css" rel="stylesheet" />
    <link href="../themes/css/style.css?v=4.1.0" rel="stylesheet" />
        <script src="../js/jquery.min.js?v=2.1.4"></script>

</head>

<body class="fixed-sidebar full-height-layout gray-bg" style="overflow: hidden">
    <div id="wrapper">
        <!--左侧导航开始-->
        <nav class="navbar-default navbar-static-side" role="navigation">
            <div class="nav-close">
                <i class="fa fa-times-circle"></i>
            </div>
            <div class="sidebar-collapse">
                <ul class="nav" id="side-menu">
                    <li class="nav-header">
                        <div class="dropdown profile-element">
                            <span style="margin-left: 25%">
                                <img alt="image" class="img-circle" src="../themes/images/profile_small.png" /></span>
                            <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                                <span class="clear" style="margin-left: 25%">
                                    <span class="block m-t-xs"><strong class="font-bold" runat="server" id="UserName"></strong></span>
                                    <span class="text-muted text-xs block" id="UserType" runat="server"><b class="caret"></b></span>
                                </span>
                            </a>
                            <ul class="dropdown-menu animated fadeInRight m-t-xs" style="padding-left: 5%">

                                <li><a class="J_menuItem" href="/forms/publicforms/login/userinfo.aspx">个人资料</a>
                                </li>
                                <li><a id="qualification" data-value="qualification" class="J_menuItem" href="" onclick="qualification()" runat="server">资质认证</a>
                                </li>

                                <%--                                  <li style="display:none;" ><a id="tempQualificationPerson" data-value="qualification" class="J_menuItem" href="user/person/qualification_certify.aspx" >资质认证</a>
                                </li>--%>
                                <li style="display: none;"><a id="tempQualificationCompany" data-value="qualification" class="J_menuItem" href="user/company/qualification_certify.aspx">资质认证</a>
                                </li>

                                <li class="divider"></li>
                                <li><a id="login" href="publicforms/Login/Login.aspx?action=exit">安全退出</a>
                                </li>
                            </ul>
                        </div>
                        <div class="logo-element">
                            CORS+
                       
                        </div>
                    </li>

                    <li id="userManage" runat="server">
                        <a href="#">
                            <i class="fa fa-user"></i>
                            <span class="nav-label">用户管理</span>
                            <span class="fa arrow"></span>
                        </a>
                        <ul class="nav nav-second-level">
                               <li><a class="J_menuItem" href="/forms/publicforms/login/userinfo.aspx">个人资料</a>
                                </li>
                                <li><a id="A1" data-value="qualification" class="J_menuItem" href="" onclick="qualification()" runat="server">资质认证</a>
                                </li>
                            <li><a class="J_menuItem" href=""  onclick="checkQualification2()">资质变更</a></li>
                            <li style="display: none;"><a id="A3"  class="J_menuItem" href="" onclick="checkQualification2()">资质变更</a>
                                </li>
                            <li>
                                <a class="J_menuItem" href="/forms/administrator/users/RtkUserManage.aspx">CORS账号管理</a>
                            </li>

                        </ul>
                    </li>
                    <li id="businessManage" runat="server">
                        <a href="#">
                            <i class="fa  fa-file-text"></i>
                            <span class="nav-label">业务管理</span>
                            <span class="fa arrow"></span>
                        </a>
                        <ul class="nav nav-second-level">
                             <li><a class="J_menuItem" href=""  onclick="checkQualification3()">在线充值</a></li>
                            <li style="display: none;"><a id="AddOrder1" class="J_menuItem" href="publicforms/login/Recharge.aspx">在线充值</a>
                            </li>
                        


                            <li><a class="J_menuItem" href=""  onclick="checkQualification1()">新增终端账号</a></li>
                            <li style="display: none;"><a id="AddOrder" class="J_menuItem" href="/forms/user/order/add_order.aspx">新增终端账号</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="" onclick="checkQualification()">订单管理</a>

                            </li>
                            <li style="display: none;"><a id="tempManageOrder" class="J_menuItem" href="/forms/user/order/manage_order.aspx">订单管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="user/invoice/manage_invoice.aspx">发票管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="user/contract/apply_contract.aspx">合同管理</a>
                            </li>
                                <li>
                                <a class="J_menuItem" href="administrator/order/PaymentRecord.aspx">缴费记录</a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a href="#">
                            <i class="fa fa-user"></i>
                            <span class="nav-label">信箱</span>
                            <span class="fa arrow"></span>
                        </a>
                        <ul class="nav nav-second-level">
                            <li>
                                <a class="J_menuItem" href="publicforms/mailbox/mail_manage.aspx">收件箱</a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a href="#">
                            <i class="fa  fa-file-text"></i>
                            <span class="nav-label">资源管理</span>
                            <span class="fa arrow"></span>
                        </a>
                        <ul class="nav nav-second-level">
                            <li>
                                <a class="J_menuItem" href="publicforms/download/ResourceDownload.aspx">资源下载</a>
                            </li>
                        </ul>
                    </li>
                                   <li>
                        <a href="#">
                            <i class="fa fa-home"></i>
                            <span class="nav-label">监控管理</span>
                            <span class="fa arrow"></span>
                        </a>
                        <ul class="nav nav-second-level">
                              <li>
                                <a class="J_menuItem" href="administrator/information/RtkSurveyMonitoring1.aspx">用户作业监控</a>
                            </li>
                           
                            <li>
                                <a class="J_menuItem" href="administrator/information/SystemOperationLog1.aspx">登录日志</a>
                            </li>
                            <%--  <li>
                                <a class="J_menuItem" href="administrator/information/StationDeform.aspx">系统修改日志</a>
                            </li>
                             <li>
                                <a class="J_menuItem" href="administrator/information/StationDeform.aspx">数据处理记录</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/information/StationDeform.aspx">服务连接记录</a>
                            </li>--%>
                            <li>
                                <a class="J_menuItem" href="administrator/information/RtkSurveyRecording1.aspx">测量作业记录</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/information/RtkUserTrace1.aspx">测量作业轨迹</a>
                            </li>
                           
                            <%--  <li>
                                <a class="J_menuItem" href="administrator/information/StationDeform.aspx">服务连接记录</a>
                            </li>--%>
                        </ul>
                    </li>
                    <li id="dataProcess" runat="server">
                        <a href="#">
                            <i class="fa fa-server"></i>
                            <span class="nav-label">数据处理</span>
                            <span class="fa arrow"></span>
                        </a>
                        <ul class="nav nav-second-level">
                            <li>
                                <a class="J_menuItem" href="publicforms/dataprocess/MultiPoint.aspx">多点转换</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="publicforms/dataprocess/ElevationTrans.aspx">高程转换</a>
                            </li>
                            <%--                     <li>
                                <a class="J_menuItem" href="publicforms/dataprocess/DXFTrans.aspxx">DXF文件转换</a>
                            </li>
                             <li>
                                <a class="J_menuItem" href="publicforms/dataprocess/SHPTrans.aspx">SHP文件转换</a>
                            </li>--%>
                            <%--      <li>
                                <a class="J_menuItem" href="publicforms/dataprocess/OBSQuality.aspx">观测文件质量检核</a>
                            </li>--%>
                            <li>
                                <a class="J_menuItem" href="publicforms/dataprocess/PPPServer.aspx">精密单点定位</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="publicforms/dataprocess/BaseLine.aspx">单站静态平差解算</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="publicforms/dataprocess/MultiBaseLine.aspx">多站静态平差解算</a>
                            </li>
                        </ul>
                    </li>

                </ul>
            </div>
        </nav>
        <!--左侧导航结束-->
        <!--右侧部分开始-->
        <div id="page-wrapper" class="gray-bg dashbard-1">
            <div class="row border-bottom">
                <nav class="navbar navbar-static-top" role="navigation" style="margin-bottom: 0">
                    <div class="navbar-header">
                        <a class="navbar-minimalize minimalize-styl-2 btn btn-primary " href="#"><i class="fa fa-bars"></i></a>

                    </div>
                   
                    <ul class="nav navbar-top-links navbar-right">
                        <li class="dropdown">
                            <a id="mail" name="mail" class="count-info J_menuItem" data-toggle="dropdown" href="publicforms/mailbox/mail_manage.aspx">
                                <i class="fa fa-envelope"></i><span class="label label-warning"><%=unreadMailNum%></span>
                            </a>
                        </li>
                        <li class="dropdown hidden-xs">
                            <a class="right-sidebar-toggle" aria-expanded="false">
                                <i class="fa fa-tasks"></i>主题
                            </a>
                        </li>
                    </ul>
                </nav>
            </div>
            <div class="row content-tabs">
                <button class="roll-nav roll-left J_tabLeft">
                    <i class="fa fa-backward"></i>
                </button>
                <nav class="page-tabs J_menuTabs">
                    <div class="page-tabs-content">
                        <a href="javascript:;" class="active J_menuTab" data-id="publicforms/Login/Login.aspx">首页</a>
                    </div>
                </nav>
                <button class="roll-nav roll-right J_tabRight">
                    <i class="fa fa-forward"></i>
                </button>
                <div class="btn-group roll-nav roll-right">
                    <button class="dropdown J_tabClose" data-toggle="dropdown">
                        关闭操作<span class="caret"></span>

                    </button>
                    <ul role="menu" class="dropdown-menu dropdown-menu-right">
                        <li class="J_tabShowActive"><a>定位当前选项卡</a>
                        </li>
                        <li class="divider"></li>
                        <li class="J_tabCloseAll"><a>关闭全部选项卡</a>
                        </li>
                        <li class="J_tabCloseOther"><a>关闭其他选项卡</a>
                        </li>
                    </ul>
                </div>
                <a href="publicforms/Login/Login.aspx?action=exit" class="roll-nav roll-right J_tabExit"><i class="fa fa fa-sign-out"></i>退出</a>
            </div>
<%--            <script>$('#iframe').attr('src', $('#iframe').attr('src'));</script>--%>
            <div class="row J_mainContent" id="content-main">
                <iframe class="J_iframe" name="iframe0" style="width: 100%; height: 100%"  src="/forms/publicforms/login/userinfo.aspx" frameborder="0" data-id="index_v1.html" ></iframe>
            </div>

<%--            /forms/publicforms/login/userinfo.aspx--%>
            <div class="footer">
                <div class="pull-right">
                    &copy;  <a href="#" target="_blank"></a>
                </div>
            </div>
        </div>
        <!--右侧部分结束-->
        <!--右侧边栏开始-->
        <div id="right-sidebar">
            <div class="sidebar-container">
                <ul class="nav nav-tabs navs-3">
                    <li class="active">
                        <a data-toggle="tab" href="#tab-1">
                            <i class="fa fa-gear"></i>主题
                        </a>
                    </li>
                </ul>
                <div class="tab-content">
                    <div id="tab-1" class="tab-pane active">
                        <div class="sidebar-title">
                            <h3><i class="fa fa-comments-o"></i>主题设置</h3>
                            <small><i class="fa fa-tim"></i>你可以从这里选择和预览主题的布局和样式，这些设置会被保存在本地，下次打开的时候会直接应用这些设置。</small>
                        </div>
                        <div class="skin-setttings">
                            <div class="title">主题设置</div>
                            <div class="setings-item">
                                <span>收起左侧菜单</span>
                                <div class="switch">
                                    <div class="onoffswitch">
                                        <input type="checkbox" name="collapsemenu" class="onoffswitch-checkbox" id="collapsemenu">
                                        <label class="onoffswitch-label" for="collapsemenu">
                                            <span class="onoffswitch-inner"></span>
                                            <span class="onoffswitch-switch"></span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="setings-item">
                                <span>固定顶部</span>
                                <div class="switch">
                                    <div class="onoffswitch">
                                        <input type="checkbox" name="fixednavbar" class="onoffswitch-checkbox" id="fixednavbar">
                                        <label class="onoffswitch-label" for="fixednavbar">
                                            <span class="onoffswitch-inner"></span>
                                            <span class="onoffswitch-switch"></span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="setings-item">
                                <span>固定宽度
                                </span>
                                <div class="switch">
                                    <div class="onoffswitch">
                                        <input type="checkbox" name="boxedlayout" class="onoffswitch-checkbox" id="boxedlayout">
                                        <label class="onoffswitch-label" for="boxedlayout">
                                            <span class="onoffswitch-inner"></span>
                                            <span class="onoffswitch-switch"></span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="title">皮肤选择</div>
                            <div class="setings-item default-skin nb">
                                <span class="skin-name ">
                                    <a href="#" class="s-skin-0">默认皮肤
                                    </a>
                                </span>
                            </div>
                            <div class="setings-item blue-skin nb">
                                <span class="skin-name ">
                                    <a href="#" class="s-skin-1">蓝色主题
                                    </a>
                                </span>
                            </div>
                            <div class="setings-item yellow-skin nb">
                                <span class="skin-name ">
                                    <a href="#" class="s-skin-3">黄色/紫色主题
                                    </a>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <!--右侧边栏结束-->
    </div>
    <div id="response"></div>
    <!-- 全局js -->
    <script src="../js/bootstrap.min.js?v=3.3.6"></script>
    <script src="../js/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="../js/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../js/plugins/layer/layer.min.js"></script>
    <!-- 自定义js -->
    <script src="../js/hplus.js?v=4.1.0"></script>
    <script type="text/javascript" src="../js/contabs.js"></script>
    <%--        <script src="../themes/index/jquery.min.js"></script>
    <script src="../themes/index/bootstrap.min.js"></script>
    <script src="../themes/index/contabs.js"></script>
    <script src="../themes/index/hplus.js"></script>
    <script src="../themes/index/jquery.metisMenu.js"></script>
<%--    <script src="../themes/index/jquery.slimscroll.min.js"></script>--%>
    <%--<script src="../themes/index/pace.min.js"></script>
    <script src="../themes/index/layer.min.js"></script>--%>--%>
    <script>
        
        //var temp = $('.J_iframe').attr('src');
        var temp = $('.J_menuTab active');
        if (temp != null)
        {
            $('#J_iframe').attr('src', $('#J_menuTab active').attr('src'));

        }
        //$('#J_iframe').attr('src', $('#iframe').attr('src'));
        //document.getElementsByTagName("body")[0].innerHTML = '';
        function qualification() {
            $.ajax({
                type: 'post',
                url: "?action=username_judge",
                success: function (data) {
                    if (data == "NO") {
                        $("#tempQualificationCompany").click();
                        layer.closeAll();
                        //layer.confirm('正在进入"测绘资质认证界面",您属于哪种用户？', {
                        //    btn: ['单位', '个人'] //按钮
                        //}, function () {
                        //    $("#tempQualificationCompany").click();
                        //    layer.closeAll();
                        //    // layer.close();
                        //    //layer.msg();

                        //}, function () {
                        //    $("#tempQualificationCompany").click();
                        //});
                    }
                    else if (data == "checking") {
                        layer.alert("资质认证审核中", { icon: 1 });
                    }

                    else {
                        layer.alert("已经完成资质认证", { icon: 1 });

                    }
                },
                // dataType: "json"
            });

        }

        function checkQualification() {
            $.get('/forms/cors_user.aspx?action=checkQualification', function (result) {
                if (result == "NO") {
                    layer.confirm('尚未进行资质认证，现在是否要认证？', {
                        btn: ['是', '否'] //按钮
                    }, function () {
                        $("#qualification").click();
                        layer.closeAll();
                        // layer.close();
                        //layer.msg();

                    }, function () {
                        layer.closeAll();
                    });
                }
                else if (result == "checking") {
                    layer.alert("资质认证审核中", { icon: 1 });
                }

                else {
                   
                   
                    $("#tempManageOrder").click();

                }
          


            })
        }
        function checkQualification1() {
            $.get('/forms/cors_user.aspx?action=checkQualification', function (result) {
                if (result == "NO") {
                    layer.confirm('尚未进行资质认证，现在是否要认证？', {
                        btn: ['是', '否'] //按钮
                    }, function () {
                        $("#qualification").click();
                        layer.closeAll();
                        // layer.close();
                        //layer.msg();

                    }, function () {
                        layer.closeAll();
                    });
                }
                else if (result == "checking") {
                    layer.alert("资质认证审核中", { icon: 1 });
                }

                else {


                    $("#AddOrder").click();
                       
                }



            })
        }
        function checkQualification2() {
            $.get('/forms/cors_user.aspx?action=checkQualification', function (result) {
                if (result == "NO") {
                    layer.confirm('尚未进行资质认证，现在是否要认证？', {
                        btn: ['是', '否'] //按钮
                    }, function () {
                        $("#qualification").click();
                        layer.closeAll();
                        // layer.close();
                        //layer.msg();

                    }, function () {
                        layer.closeAll();
                    });
                }
                else if (result == "checking") {
                    parent.layer.open({
                        type: 2,
                        title: '资质信息',
                        shadeClose: true,
                        shade: false,
                        maxmin: true, //开启最大化最小化按钮
                        area: ['1150px', '650px'],
                        content: 'user/company/qualification_Update.aspx'
                    });
                }

                else {


                    parent.layer.open({
                        type: 2,
                        title: '资质信息',
                        shadeClose: true,
                        shade: false,
                        maxmin: true, //开启最大化最小化按钮
                        area: ['1150px', '650px'],
                        content: 'user/company/qualification_Update.aspx'
                    });

                }



            })
        }
         function checkQualification3() {
            $.get('/forms/cors_user.aspx?action=checkQualification', function (result) {
                if (result == "NO") {
                    layer.confirm('尚未进行资质认证，现在是否要认证？', {
                        btn: ['是', '否'] //按钮
                    }, function () {
                        $("#qualification").click();
                        layer.closeAll();
                        // layer.close();
                        //layer.msg();

                    }, function () {
                        layer.closeAll();
                    });
                }
                else if (result == "checking") {
                    layer.alert("资质认证审核中", { icon: 1 });
                }

                else {


                    $("#AddOrder1").click();
                       
                }



            })
        }
         function checkQualification4() {
            $.get('/forms/cors_user.aspx?action=checkQualification', function (result) {
                if (result == "NO") {
                    layer.confirm('尚未进行资质认证，现在是否要认证？', {
                        btn: ['是', '否'] //按钮
                    }, function () {
                        $("#qualification").click();
                        layer.closeAll();
                        // layer.close();
                        //layer.msg();

                    }, function () {
                        layer.closeAll();
                    });
                }
                else if (result == "checking") {
                    layer.alert("资质认证审核中", { icon: 1 });
                }

                else {


                    $("#AddOrder2").click();
                       
                }



            })
        }
    </script>
    
</body>

</html>
