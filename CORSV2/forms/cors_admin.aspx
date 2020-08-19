<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cors_admin.aspx.cs" Inherits="CORSV2.forms.cors_admin" %>

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

                                <li><a id="userInfo" class="J_menuItem" href="/forms/publicforms/login/userinfo.aspx">个人资料</a>
                                </li>
                                <%--                               <li><a id="qualification" data-value="qualification" class="J_menuItem" href=""  onclick="qualification()">资质认证</a>
                                </li>--%>
                                <li class="divider"></li>
                                <li><a href="publicforms/Login/Login.aspx?action=exit">安全退出</a>
                                </li>
                            </ul>
                        </div>
                        <div class="logo-element">
                            CORS+
                       
                        </div>
                    </li>
                    <li>
                        <a href="#">
                            <i class="fa fa-cog"></i>
                            <span class="nav-label">系统管理</span>
                            <span class="fa arrow"></span>
                        </a>
                        <ul class="nav nav-second-level">
                            <li>
                                <a class="J_menuItem" href="administrator/system/BroadcastManage.aspx" data-index="0">播发服务管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/system/WorkingAreaManage.aspx">作业区域管理</a>
                            </li>
                          <%--    <li>
                                <a class="J_menuItem" href="administrator/system/RoamAreaManage.aspx">漫游区域管理</a>
                            </li>--%>
                                <li>
                                <a class="J_menuItem" href="administrator/system/RoamingAreaManagement.aspx">漫游区域管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/system/CoorParaManage.aspx">坐标参数管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/system/ControlPointManage.aspx">控制点管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/system/RefinedModel.aspx">精化模型管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/system/ResourcesDownload.aspx">资源下载管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/system/NewsManage.aspx">新闻动态管理</a>
                            </li>
                            <%--                            <li>
                                <a class="J_menuItem" href="administrator/system/Basestation.aspx">基站数据管理</a>
                            </li>--%>
                            <li>
                                <a class="J_menuItem" href="administrator/system/Ephemeris.aspx">星历数据管理</a>
                            </li>
                             <li>
                                <a class="J_menuItem" href="administrator/system/ServiceConfig.aspx">服务配置</a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a href="#">
                            <i class="fa fa-user"></i>
                            <span class="nav-label">用户管理</span>
                            <span class="fa arrow"></span>
                        </a>
                        <ul class="nav nav-second-level">
                            <li>
                                <a class="J_menuItem" href="administrator/users/UserManage.aspx">平台用户管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/users/rtkUserManage_Admin.aspx">RTK用户管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/users/AdminManage.aspx">管理员账号管理</a>
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
                            <li>
                                <a class="J_menuItem" href="publicforms/mailbox/mail_generate.aspx">写信</a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a href="#">
                            <i class="fa fa-book"></i>
                            <span class="nav-label">站网信息管理</span>
                            <span class="fa arrow"></span>
                        </a>
                        <ul class="nav nav-second-level">
                            <li>
                                <a class="J_menuItem" href="administrator/information/StationManage.aspx">基站信息管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/information/DataCenterManage.aspx">数据中心设备管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/information/InternetInfo.aspx">网络信息管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/information/StationNetManage.aspx">站网信息管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/information/SoftwareManage.aspx">软件信息管理</a>
                            </li>

                        </ul>
                    </li>
                    <li>
                        <a href="#">
                            <i class="fa  fa-file-text"></i>
                            <span class="nav-label">业务管理</span>
                            <span class="fa arrow"></span>
                        </a>
                        <ul class="nav nav-second-level">
                            <li>
                                <a class="J_menuItem" href="administrator/order/manage_order.aspx">订单管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="/forms/administrator/invoice/manage_invoice.aspx">发票管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="/forms/administrator/contract/manage_contract.aspx">合同管理</a>
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
                                <a class="J_menuItem" href="administrator/information/RtkSurveyMonitoring.aspx">用户作业监控</a>
                            </li>
                             <li>
                                <a class="J_menuItem" href="publicforms/map/Amap.aspx">实时监控</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/information/StationDeform.aspx">基站变形信息</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/information/SystemOperationLog.aspx">系统操作日志</a>
                            </li>
                            <%--                              <li>
                                <a class="J_menuItem" href="administrator/information/SystemOperationLog.aspx">系统修改日志</a>
                            </li>--%>
                            <li>
                                <a class="J_menuItem" href="administrator/information/DataProcessLog.aspx">数据处理记录</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/information/RtkSurveyRecording.aspx">测量作业记录</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/information/RtkUserTrace.aspx">测量作业轨迹</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/information/RtkUserHotPoint.aspx">作业热点图</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="administrator/information/RTKAlarmLog.aspx">RTK报警记录</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="publicforms/download/ResourceDownload.aspx">资源下载</a>
                            </li>
                            <%--                              <li>
                                <a class="J_menuItem" href="administrator/information/StationDeform.aspx">服务连接记录</a>
                            </li>--%>
                        </ul>
                    </li>
                    <li>
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
                            <li>
                                <a class="J_menuItem" href="publicforms/error.aspx">DXF文件转换</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="publicforms/error.aspx">SHP文件转换</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="publicforms/error.aspx">观测文件质量检核</a>
                            </li>
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
                            <a id="ToDoList" name="ToDoList" class="count-info J_menuItem" data-toggle="dropdown" href="ToDoList.aspx">
                                <i class="fa fa-desktop"></i>待办
                            </a>
                        </li>
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
        
            
            <div class="row J_mainContent" id="content-main">
              <%--  <iframe class="J_iframe" name="iframe0" style="width: 100%; height: 100%" src="/forms/publicforms/login/userinfo.aspx" frameborder="0" data-id="index_v1.html" seamless></iframe>--%>
                  <iframe class="J_iframe" name="iframe0" style="width: 100%; height: 100%" src="ToDoList.aspx" frameborder="0" data-id="index_v1.html" seamless></iframe>
            </div>
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
    <script src="../js/jquery.min.js?v=2.1.4"></script>
    <script src="../js/bootstrap.min.js?v=3.3.6"></script>
    <script src="../js/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="../js/plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../js/plugins/layer/layer.min.js"></script>
    <!-- 自定义js -->
    <script src="../js/hplus.js?v=4.1.0"></script>
    <script type="text/javascript" src="../js/contabs.js"></script>
    <script>
        function qualification() {
            $.ajax({
                type: 'post',
                url: "?action=username_judge",
                success: function (data) {
                    if (data != "unregister") {
                        $("#response").html(data);
                        return;
                    }
                    else {
                        var temp = $("#qualification").attr("data-value");
                        if (temp != "qualification") {
                            return;
                        }
                        document.getElementById("qualification").href = "user/company/qualification_certify.aspx";
                        $("#qualification").attr("data-value", "qualification_past");
                        $("#qualification").click();
                        //layer.confirm('正在进入"测绘资质认证界面",您属于哪种用户？', {
                        //    btn: ['个人', '单位'] //按钮
                        //}, function () {
                        //    window.location.href = "themes/index1css/Information.aspx?action=binding";
                        //    document.getElementById("qualification").href = "user/person/qualification_certify.aspx";
                        //    $("#qualification").attr("data-value", "qualification_past");
                        //    $("#qualification").click();
                        //}, function () {
                        //    document.getElementById("qualification").href = "user/company/qualification_certify.aspx";
                        //    $("#qualification").attr("data-value", "qualification_past");
                        //    $("#qualification").click();

                        //    //$("#qualification").attr("href") = "user/company/qualification_certify.aspx";
                        //    // window.location.href = "user/company/qualification_certify.aspx";
                        //});
                    }


                },

                // dataType: "json"
            });

        }
    </script>
</body>

</html>
