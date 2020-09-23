<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qualification_certify.aspx.cs" Inherits="CORSV2.forms.user.company.qualification_certify" %>

<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
 
    <title>CORS 平台</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <meta name="MobileOptimized" content="320">
          <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="../../../themes/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../../themes/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../themes/css/uniform.default.css" rel="stylesheet" />
    <link href="../../../themes/css/select2_metro.css" rel="stylesheet" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
    <link href="../../../themes/css/jquery.gritter.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css" rel="stylesheet" />
    <link href="../../../themes/css/style-metronic.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css" rel="stylesheet" />
    <link href="../../../themes/css/style-responsive.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins.css" rel="stylesheet" />
    <link href="../../../themes/css/light.css" rel="stylesheet" />
    <link href="../../../themes/css/custom.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/layer/skin/layer.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/layer/skin/layer.ext.css" rel="stylesheet" />
    <script src="../../../js/jquery-1.10.2.min.js"></script>
    <link href="../../../themes/css/plugins/dataTables/DT_bootstrap.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/webuploader/webuploader.css" rel="stylesheet" />
    <!-- END THEME STYLES -->
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body class="page-header-fixed">
    <!-- BEGIN HEADER -->
    <!-- END HEADER -->
    <div class="clearfix"></div>
    <link href="../../../themes/css/ucenter.css" rel="stylesheet" />
    <link href="css/zoomify.min.css" rel="stylesheet" />
    <!-- BEGIN CONTAINER -->
    <div class="page-container">

        <!-- BEGIN SIDEBAR -->
        <div class="page-sidebar navbar-collapse collapse">
            <!-- BEGIN SIDEBAR MENU -->

            <!-- END SIDEBAR MENU -->
        </div>
        <!-- END SIDEBAR -->


        

        <style>
            .radio {
                width:200px;
                /*display: initial;*/
            }

            .certify-img {
                max-width: 200px;
                max-height: 200px;
            }

            .filePicker {
                margin-top: 10px;
            }

            .webuploader-pick {
                padding: 5px 15px !important;
            }

            .min-width-200 {
                min-width: 200px;
            }
            li
        </style>

        <!-- BEGIN PAGE -->
        <div class="page-content">
            <!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
            <!-- /.modal -->
            <!-- END SAMPLE PORTLET CONFIGURATION MODAL FORM-->

            <!-- BEGIN PAGE HEADER-->
            <!-- END PAGE HEADER-->
            <!-- BEGIN DASHBOARD STATS -->
            <div class="row">
                <section id="ucenterSection">
                    <div class="ContentDiv certifyMainContent">
                        <form  method="post"
                            id="verifyCompanyForm" class="verifyCompanyForm vertifyCompanyForm vertifyForm" enctype="multipart/form-data">

                            <ul class="centerFormUl" style="padding-top: 0;">
                                <li class="vertifyLiTitle titleBottom">基本信息填写</li>
                                    <li class="clearfix">

                                    <label class="labelLeft"><span class="required">*</span>认证用户类型：</label>
                                    <div class="labelRight" style="width:500px">
                                        <div class="controls">
                                            <label class="radio">
                                                <input checked="checked" type="radio" name="type_id" class="type_id" value="1"  />
                                                	企业用户											
                                            </label>
                                            <label class="radio">
                                                <input type="radio" name="type_id" class="type_id" value="2" disabled="disabled" />
                                               个人用户											
                                            </label>
                                          
                                        
                                        </div>
                                        <i class="errorTips errorCompany" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>



                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>机构名称：</label>
                                    <div class="labelRight" style="width:500px">
                                        <input type="text" name="company_name" value="" id="company_name" npropertychange="check()" oninput="check()" required="required" class="form-control width-300 " placeholder="请确保跟公章信息一致" runat="server">
                                        <i class="errorTips errorCompany" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>

                                </li>

                                <li class="clearfix">

                                    <label class="labelLeft"><span class="required">*</span>机构类型：</label>
                                    <div class="labelRight" style="width:500px">
                                        <div class="controls">
                                            <label class="radio">
                                                <input checked="checked" type="radio" name="company_type_id" class="company_type_id" value="1"  />
                                                市内测绘资质单位												
                                            </label>
                                             <div class="controls">
                                            <label class="radio">
                                                <input  type="radio" name="company_type_id" class="company_type_id" value="8"  />
                                                市内非测绘资质单位												
                                            </label>
                                                 <label class="radio">
                                                <input type="radio" name="company_type_id" class="company_type_id" value="6" />
                                               市外测绘资质单位											
                                            </label>
                                             <label class="radio">
                                                <input type="radio" name="company_type_id" class="company_type_id" value="7" />
                                               市外非测绘资质单位											
                                            </label>
                                            <label class="radio">
                                                <input type="radio" name="company_type_id" class="company_type_id" value="2"  />
                                                政府机构（无资质）												
                                            </label>
                                            <label class="radio">
                                                <input type="radio" name="company_type_id" class="company_type_id" value="3" />
                                                仪器公司（无资质）												
                                            </label>
                                            <label class="radio">
                                                <input type="radio" name="company_type_id" class="company_type_id" value="4" />
                                                高校/科研院所（无资质）												
                                            </label>
                                            <label class="radio">
                                                <input type="radio" name="company_type_id" class="company_type_id" value="5" />
                                                其他非测绘资质执证单位												
                                            </label>
                                       
                                        </div>
                                        <i class="errorTips errorCompany" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix cehui">
                                    <label class="labelLeft"><span class="required">*</span>测绘资质等级：</label>
                                      <div class="labelRight" style="width:200px" >
                                    <select name="map_level" id="map_level" class="select2-select min-width-200" runat="server">
                                      
                                            <option value="">请选择...</option>
                                            <option value="甲级">甲级</option>
                                            <option value="乙级">乙级</option>
                                            <option value="丙级">丙级</option>
                                            <option value="丁级">丁级</option>
                                        
                                    </select>
                                          </div>
                                    <i class="errorTips errorZhizhao" hidden="true" style="display: none;">
                                        <span class="fa fa-warning"></span><em></em>
                                    </i>
                                </li>
                                <li class="clearfix cehui">
                                    <label class="labelLeft"><span class="required">*</span>测绘资质证书编号：</label>
                                    <div class="labelRight" style="width:500px">
                                        <input type="text" id="map_qualification_sn" name="map_qualification_sn" value="" class="form-control width-300" placeholder="填写示例：甲测资字4300001" runat="server">
                                        <i class="errorTips errorShui" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>组织机构编号：</label>
                                    <div class="labelRight" style="width:500px">
                                        <input type="text" id="business_licence" name="business_licence" value="" class="form-control width-300" placeholder="三证合一请填写统一社会信用代码" runat="server">
                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>


                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>申请类型：</label>
                                    <div class="labelRight" style="width:500px">
                                        <div class="controls">
                                            <label class="radio">
                                                <input type="radio" name="certify_type" class="certify_type" value="1" />法定代表人申请
                                            </label>
                                            <label class="radio">
                                                <input checked="checked" type="radio" name="certify_type" class="certify_type" value="2" />经办人申请
                                            </label>
                                        </div>
                                        <i class="errorTips errorCompany" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>


                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>法定代表人姓名：</label>
                                    <div class="labelRight" style="width:500px">
                                        <input type="text" id="corporate" name="corporate" value="" class="form-control width-300" runat="server">
                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>法定代表人电话：</label>
                                    <div class="labelRight" style="width:500px">
                                        <input id="corporate_tel" type="text" name="corporate_tel" value="" class="form-control width-300" placeholder="填写示例：0731-88888888" runat="server">
                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>机构地址：</label>
                                    <div class="labelRight" style="width:500px">
                                        <select id="province" name="province" class="select2-select " style="min-width: 97px;" runat="server">
                                            <option value="">省份</option>
                                            <option value="北京市">北京市</option>
                                            <option value="天津市">天津市</option>
                                            <option value="上海市">上海市</option>
                                            <option value="重庆市">重庆市</option>
                                            <option value="河北省">河北省</option>
                                            <option value="山西省">山西省</option>
                                            <option value="内蒙古">内蒙古</option>
                                            <option value="辽宁省">辽宁省</option>
                                            <option value="吉林省">吉林省</option>
                                            <option value="黑龙江省">黑龙江省</option>
                                            <option value="江苏省">江苏省</option>
                                            <option value="浙江省">浙江省</option>
                                            <option value="安徽省">安徽省</option>
                                            <option value="福建省">福建省</option>
                                            <option value="江西省">江西省</option>
                                            <option value="山东省">山东省</option>
                                            <option value="河南省">河南省</option>
                                            <option value="湖北省">湖北省</option>
                                            <option value="湖南省">湖南省</option>
                                            <option value="广东省">广东省</option>
                                            <option value="广西">广西</option>
                                            <option value="海南省">海南省</option>
                                            <option value="四川省">四川省</option>
                                            <option value="贵州省">贵州省</option>
                                            <option value="云南省">云南省</option>
                                            <option value="西藏">西藏</option>
                                            <option value="陕西省">陕西省</option>
                                            <option value="甘肃省">甘肃省</option>
                                            <option value="青海省">青海省</option>
                                            <option value="宁夏">宁夏</option>
                                            <option value="新疆">新疆</option>
                                            <option value="香港">香港</option>
                                            <option value="澳门">澳门</option>
                                            <option value="台湾省">台湾省</option>
                                        </select>
                                        <select id="city" name="city" class=" select2-select " style="min-width: 97px;" runat="server">
                                <%--            <option value="">地级市</option>
                                            <option value="" selected></option>--%>
                                        </select>

                                        <select id="town" name="town" class=" select2-select " style="min-width: 97px;" runat="server">
                                 <%--           <option value="">市、县级市、县</option>
                                            <option value="" selected></option>--%>
                                        </select>

                                        <i class="errorTips errorCompany" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>

                                    </div>
                                </li>
                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>详细地址：</label>
                                    <div class="labelRight" style="width:500px">
                                        <input type="text" id="address" name="address" class="form-control width-300" value="" runat="server">
                                        <i class="errorTips errorAddress" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>

                                    </div>
                                </li>

                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>邮编：</label>
                                    <div class="labelRight">
                                        <input type="text" id="post_code" name="post_code" value="" class="form-control width-300" placeholder="请填写6位数字邮编" runat="server">
                                        <i class="errorTips errorCompany" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="vertifyLiTitle" style="margin: 10px 0;">资料上传</li>

                                <li class="clearfix cehui" style="height: auto;">
                                    <label class="labelLeft"><span class="required">*</span>测绘资质复印件（盖章）：</label>
                                    <div class="labelRight"  style="width:200px">

                                        <!--用来存放item-->
                                        <div id="map_qualification_path_file" name="map_qualification_path_file" class="uploader-list" runat="server">
                                            <img class="certify-img" src="" id="map_qualification_path_file_" runat="server">
                                        </div>
                                        <div class="filePicker" id="map_qualification_path">选择图片</div>

                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                        <i class="tipsFile">复印件，1份，<span class="text-error">加盖机构公章</span><br>
                                            图片大小不要超过5M，支持PNG，JPG格式</i>
                                    </div>
                                </li>

                                <li class="clearfix" style="height: auto;">
                                    <label class="labelLeft"><span class="required">*</span>组织机构代码证复印件（盖章）：</label>
                                    <div class="labelRight" style="width:500px">
                                        <!--用来存放item-->
                                        <div id="business_licence_path_file" class="uploader-list">
                                            <img class="certify-img" src="" id="business_licence_path_file_" runat="server">
                                        </div>
                                        <div class="filePicker" id="business_licence_path">选择图片</div>
                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>

                                        <i class="tipsFile">营业执照/事业机构法人证/社会团体法人登记证/组织机构代码证（有其一即可，复印件，1份，<span class="text-error">加盖机构公章</span>）。<br>
                                            图片大小不要超过5M，支持PNG，JPG格式</i>

                                    </div>
                                </li>


                             <%--   <li class="clearfix" style="height: auto;">
                                    <label class="labelLeft"><span class="required">*</span>法定代表人身份证：</label>
                                    <div class="labelRight" style="width:500px">
                                        <!--用来存放item-->
                                        <div id="corporate_id_card_front_file" class="uploader-list">
                                            <img class="certify-img" src="" id="corporate_id_card_front_file_" runat="server">
                                        </div>
                                        <div class="filePicker" id="corporate_id_card_front">选择图片(正面)</div>

                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>

                                        <i class="tipsFile">图片大小不要超过5M，支持PNG，JPG格式</i>


                                        <div id="corporate_id_card_reverse_file" class="uploader-list">
                                            <img class="certify-img" src="">
                                        </div>
                                        <div class="filePicker" id="corporate_id_card_reverse">选择图片(反面)</div>

                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>

                                        <i class="tipsFile">图片大小不要超过5M，支持PNG，JPG格式</i>
                                    </div>
                                </li>

                                <li class="clearfix operator_id_card" style="height: auto;">
                                    <label class="labelLeft"><span class="required">*</span>经办人身份证：</label>
                                    <div class="labelRight" style="width:500px">
                                        <div id="operator_id_card_front_file" class="uploader-list">
                                            <img class="certify-img" src="" id="operator_id_card_front_file_" runat="server">
                                        </div>
                                        <div class="filePicker" id="operator_id_card_front">选择图片(正面)</div>

                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>

                                        <i class="tipsFile">图片大小不要超过5M，支持PNG，JPG格式</i>

                                        <div id="operator_id_card_reverse_file" class="uploader-list">
                                            <img class="certify-img" src="">
                                        </div>
                                        <div class="filePicker" id="operator_id_card_reverse">选择图片(反面)</div>


                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>

                                        <i class="tipsFile">图片大小不要超过5M，支持PNG，JPG格式</i>
                                    </div>
                                </li>

                                <li class="clearfix" style="height: auto;">
                                    <label class="labelLeft"><span class="required">*</span>服务保密协议扫描件（盖章）：</label>
                                    <div class="labelRight" style="width:500px">
                                        <div id="secrecy_agreement_path_file" class="uploader-list">
                                            <img id="secrecy_agreement_path_file_" class="certify-img" src="" runat="server" >
                                        </div>
                                        <div class="filePicker" id="secrecy_agreement_path">选择图片</div>

                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>

                                        <i class="tipsFile">图片大小不要超过5M，支持PNG，JPG格式.<a target="_blank" href="">请点击下载模板</a>，并打印<span class="text-error">填写盖章</span>扫描后,上传扫描件.</i>
                                        <br>
                                        <i class="tipsFile">注意：仅需上传<span class="text-error">保密协议首页</span>即可，<a onclick="showBig();">请点击查看上传图片样例<img id="test" style="width: 1px;" class="certify-img" src=""></a>.</i>

                                    </div>
                                </li>


                                <li class="clearfix " style="height: auto;">
                                    <label class="labelLeft"><span class="required">*</span>授权委托书扫描件（盖章）：</label>
                                    <div class="labelRight" style="width:500px">
                                        <div id="client_authorization_path_file" class="uploader-list">
                                            <img id="client_authorization_path_file_" class="certify-img" src="" runat="server">
                                        </div>
                                        <div class="filePicker" id="client_authorization_path">选择图片</div>

                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>

                                        <i class="tipsFile">图片大小不要超过5M，支持PNG，JPG格式.<a target="_blank" href="">请点击下载模板</a>,并打印<span class="text-error">填写盖章</span>扫描后,上传扫描件.</i>

                                    </div>
                                </li>--%>
                             <%--   服务协议（盖章）”--%>
                                <%--  <li class="clearfix " style="height: auto;">
                                    <label class="labelLeft"><span class="required">*</span>服务协议（盖章）：</label>
                                    <div class="labelRight" style="width:500px">
                                        <div id="Service_agreement_path_file" class="uploader-list">
                                            <img id="Img1" class="certify-img" src="" runat="server">
                                        </div>
                                        <div class="filePicker" id="Service_agreement_path">选择图片</div>

                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>

                                      

                                    </div>
                                </li>--%>


                                <li class="vertifyLiTitle titleBottom">联系人信息</li>
                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>联系人姓名：</label>
                                    <div class="labelRight" style="width:200px">
                                        <input type="text" id="contact_name" name="contact_name" class="form-control width-300" value="" runat="server">
                                        <i class="errorTips errorName" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>
                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>联系人电话：</label>
                                    <div class="labelRight" style="width:200px">
                                        <input type="tel" id="qcphone" name="qcphone" class="form-control width-300" value="" placeholder="请填写手机号码" runat="server">
                                        <i class="errorTips errorTel" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>
                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>联系人电子邮箱：</label>
                                    <div class="labelRight" style="width:200px">
                                        <input type="tel" name="contact_email" class="form-control width-300" value="">
                                        <i class="errorTips errorTel" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>
                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>联系人QQ：</label>
                                    <div class="labelRight" style="width:200px">
                                        <input type="tel" name="contact_qq" class="form-control width-300" value="">
                                        <i class="errorTips errorTel" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>联系人微信号：</label>
                                    <div class="labelRight" style="width:200px">
                                        <input type="tel" name="contact_wechat" class="form-control width-300" value="">
                                        <i class="errorTips errorTel" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>
                                <li class="clearfix">
                                    <label class="labelLeft">&nbsp;</label>
                                    <div class="labelRight">
                                        <div class="btn btn-primary centerBtnCompany">提交认证</div>
                                    </div>
                                </li>
                            </ul>
                        </form>

                    </div>
                </section>
            </div>
            <!-- END DASHBOARD STATS -->
            <div class="clearfix"></div>
        </div>
        <!-- END PAGE -->
    </div>
        <script src="../../../js/geo.js"></script>
    <script src="../../../js/plugins/layer/layer.js"></script>
    <script src="../../../js/plugins/zoomify/zoomify.min.js"></script>
<%--    <script src="../../../js/plugins/webuploader/webuploader.js"></script>--%>
    <script type="text/javascript" src="js/webuploader.js"></script>
    <link href="../../../js/plugins/webuploader/webuploader.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/layer/skin/layer.css" rel="stylesheet" />
    <script>
        var BASE_URL = "/Public/Member/plugins/webuploader";
        var thumbnailWidth = 1000;
        var thumbnailHeight = 1000;
        var field = "";
        //上传按钮响应
        $("body").on("click", ".filePicker", function () {
            field = $(this).attr("id");
            uploader.option('formData',
                { "field": field }
            );

        });


        function initUploader() {
            return WebUploader.create({

                // 选完文件后，是否自动上传。
                auto: true,

                // swf文件路径
                swf:  '/js/plugins/webuploader/Uploader.swf',

                // 文件接收服务端。
                server: '?action=AddData',

                // 选择文件的按钮。可选。
                // 内部根据当前运行是创建，可能是input元素，也可能是flash.
                pick: '.filePicker',

                // 只允许选择图片文件。
                accept: {
                    title: 'Images',
                    extensions: 'gif,jpg,jpeg,bmp,png',
                    mimeTypes: 'image/jpg,image/jpeg,image/png'
                },
                formData: {
                    field: "test"
                },
                duplicate: true
            });
        }

        // 初始化Web Uploader
        var uploader = initUploader();

        // 当有文件添加进来的时候
        uploader.on('fileQueued', function (file) {

        });


        // 当文件开始上传之前做校验,文件大小不超过5M
        uploader.on('beforeFileQueued', function (file) {
            if (file.size > 5 * 1024 * 2014) {
                layer.msg("文件大小不能超过5M!");
                return false;
            }
        });

        // 文件上传过程中创建进度条实时显示。
        uploader.on('uploadProgress', function (file, percentage) {
            var $li = $('#' + file.id),
                $percent = $li.find('.progress span');

            // 避免重复创建
            if (!$percent.length) {
                $percent = $('<p class="progress"><span></span></p>')
                    .appendTo($li)
                    .find('span');
            }

            $percent.css('width', percentage * 100 + '%');
        });

        // 文件上传成功，给item添加成功class, 用样式标记上传成功。
        uploader.on('uploadSuccess', function (file) {
            var $li = $(
                    '<div id="' + file.id + '">' +
                    '<img class="certify-img">' +
    //                '<div class="info">' + file.name + '</div>' +
                    '</div>'
                ),
                $img = $li.find('img');


            // $list为容器jQuery实例,替换原来的图片
            $("#" + field + "_file").html($li);

            // 创建缩略图
            uploader.makeThumb(file, function (error, src) {
                if (error) {
                    $img.replaceWith('<span>不能预览</span>');
                    return;
                }

                $img.attr('src', src);
            }, thumbnailWidth, thumbnailHeight);

            $('img').zoomify();
         //   $('.centerBtnCompany').removeAttr("disabled");
        });

        // 文件上传失败，显示上传出错。
        uploader.on('uploadError', function (file) {
            var $li = $('#' + file.id),
                $error = $li.find('div.error');

            // 避免重复创建
            if (!$error.length) {
                $error = $('<div class="error"></div>').appendTo($li);
            }

            $error.text('上传失败');
        });

        // 完成上传完了，成功或者失败，先删除进度条。
        uploader.on('uploadComplete', function (file) {
            $('#' + file.id).find('.progress').remove();
        });

        ////上传结果反馈
        //uploader.on("uploadAccept", function (file, data) {
        //    if (data.code != "200") {
        //        layer.msg(data.msg);
        //        // 通过return false来告诉组件，此文件上传有错。
        //        return false;
        //    }
        //});
    </script>

    <script type="text/javascript">
        var hasAttr = function (el, name) {
            var attr = el.getAttributeNode && el.getAttributeNode(name);
            return attr ? attr.specified : false
        }

        var addEvent = function (obj, type, callback) {
            if (obj.addEventListener) {
                obj.addEventListener(type, callback, false);
            }
            else if (obj.attachEvent) {
                obj.attachEvent("on" + type, callback);
            }
        }

        var done = function (el, fn) {
            if (!hasAttr(el, "tabindex")) {
                el.tabIndex = -1;
            }
            addEvent(el, "focus", function (e) {
                fn.call(el, (e || window.event));
            });
        }
            </script>

    <script>
        //测绘资质企业，需要增加几个特别的内容
        $("body").on("change", ".company_type_id", function () {
            var company_type_id = $(this).val();
            //测绘资质企业
            if (company_type_id == 1||company_type_id==6) {
                //显示几个框
                $(".cehui").show();
            } else {
                //非测绘资质企业，隐藏几个框
                $(".cehui").hide();
            }
            uploader.refresh();
            //        $(window).resize();
        });


        //申请类型
        $("body").on("change", ".certify_type", function () {
            var certify_type = $(this).val();
            //法人申请
            if (certify_type == 1) {
                //显示几个框
                $(".operator_id_card").hide();
            } else {
                //经办人申请，隐藏几个框
                $(".operator_id_card").show();
            }
            uploader.refresh();
            //        $(window).resize();
        });
    </script>

    <script>
        //认证机构名称重复判断
        $(document).ready(function () {
            $("#company_name").change(function () {
                company_name = $("#company_name").val();
                if (!company_name) {
                    $("#company_name").focus();
                    $('.errorTips').hide();
                    $(":input[name='company_name']").siblings('i').show().find('em').html('请填写机构名称');
                    return false;
                }

                //检查名称是否重复

                $.ajax({
                    type: 'POST',
                    url: "?action=company_judge",
                    data: { company_name: company_name },
                    success: function (data) {
                        if (data.code != 200) {
                            $("#company_name").focus();
                            $('.errorTips').hide();
                            $(":input[name='company_name']").siblings('i').show().find('em').html('该机构已注册，请联系管理员！');
                            return false;
                        }
                    },
                    dataType: "json"
                });


            });
        });
    </script>
    <!-- END CONTAINER -->
    <script type="text/javascript">
        function promptinfo() {
            var address = document.getElementById('address');
            var province = document.getElementById('province');
            var city = document.getElementById('city');
            var town = document.getElementById('town');
        }
        // focus第一个input
        $('.verifyPersonForm :input[name=real_name]').focus();


        $(".type").click(function () {
            var id = $(this).val();
            $(".vertify").css({ display: "none" });
            $("#vertifyTable" + id).css({ display: "" });
        })

        // input框有动作时隐藏错误提示
        $(':input').on('input', function () {
            $('.errorTips').hide();
        }).on('change', function () {
            $('.errorTips').hide();
        })

        /* 开始：资质认证部分 */

        // 省市信息
        var s = ["province", "city", "town"];
        var opt0 = ["省份", "地级市", "市、县级市、县"];
        var opt0 = [];
        for (i = 0; i < s.length - 1; i++)
            document.getElementById(s[i]).onchange = new Function("change(" + (i + 1) + ");promptinfo();");

        //		//				change(0);
        //
        // 资质认证的提交表单按钮
        $(".centerBtnCompany").click(function () {
            $('.errorTips').hide(); // 隐藏所有的错误提示信息
            //*机构名称：
            company_name = $(":input[name='company_name']").val();

            if (company_name.length < 2) {
                $(":input[name='company_name']").focus();
                $('.errorTips').hide();
                $(":input[name='company_name']").siblings('i').show().find('em').html('机构名称填写错误');
                return false;
            } 
            $.get("?action=check&&data=" + company_name.trim(), function (result) {
                if (result == "1") {
                    return true;
                }
                else {
                    $(":input[name='company_name']").siblings('i').show().find('em').html('该机构已认证,不能重复认证！');
                   
                    return false;
                }
            })

            //机构类型
            company_type_id = $(":input[name='company_type_id']:checked").val();
            alert(company_type_id)
            //测绘资质企业, 需要多校验几个内容
            if (company_type_id == 1 || company_type_id == 6) {
                //*测绘资质等级：
                map_level = $('#map_level').val();
                if (map_level == ''||map_level ==null) {
                    $(":input[name='map_level']").focus();
                    $('.errorTips').hide();
                    $(":input[name='map_level']").siblings('i').show().find('em').html('请选择测绘资质等级');
                    return false;
                }

                //*测绘资质证书编号：
                map_qualification_sn = $('.verifyCompanyForm').find(":input[name='map_qualification_sn']").val();
                if ($.trim(map_qualification_sn) == '') {
                    $(":input[name='map_qualification_sn']").focus();
                    $('.errorTips').hide();
                    $(":input[name='map_qualification_sn']").siblings('i').show().find('em').html('请填写测绘资质证书编号');
                    return false;
                }
            }

            //*组织机构编号：
            business_licence = $('.verifyCompanyForm').find(":input[name='business_licence']").val();
            if ($.trim(business_licence) == '') {
                $(":input[name='business_licence']").focus();
                $('.errorTips').hide();
                $(":input[name='business_licence']").siblings('i').show().find('em').html('请填写组织机构编号');
                return false;
            }


            certify_type = $(":input[name='certify_type']:checked").val();


            //法人
            corporate = $('.verifyCompanyForm').find(":input[name='corporate']").val();
            if ($.trim(corporate) == '') {
                $(":input[name='corporate']").focus();
                $('.errorTips').hide();
                $(":input[name='corporate']").siblings('i').show().find('em').html('请填写法定代表人姓名');
                return false;
            }

            var isQQ = /^[0-9]*$/;
            var isPhone = /^([0-9]{3,4}-)?[0-9]{7,8}$/;
            var isMob = /^((\+?86)|(\(\+86\)))?(13[0-9]{9}|14[0-9]{9}|17[0-9]{9}|15[0-9]{9}|18[0-9]{9})$/;
            //法人电话
            corporate_tel = $('.verifyCompanyForm').find(":input[name='corporate_tel']").val();
            if ($.trim(corporate_tel) == '') {
                $(":input[name='corporate_tel']").focus();
                $('.errorTips').hide();
                $(":input[name='corporate_tel']").siblings('i').show().find('em').html('请填写法定代表人电话');
                return false;
            }
            else if (!isMob.test(corporate_tel) && !isPhone.test(corporate_tel)) {
                $(":input[name='corporate_tel']").focus();
                $('.errorTips').hide();
                $(":input[name='corporate_tel']").siblings('i').show().find('em').html('法定代表人联系电话格式错误');
                return false;
            }


            province = $('.verifyCompanyForm').find(":input[name='province']").val();
            city = $('.verifyCompanyForm').find(":input[name='city']").val();
            town = $('.verifyCompanyForm').find(":input[name='town']").val();
            address = $('.verifyCompanyForm').find(":input[name='address']").val();
            //邮编
            post_code = $('.verifyCompanyForm').find(":input[name='post_code']").val();

            //*联系人姓名：
            contact_name = $('.verifyCompanyForm').find(":input[name='contact_name']").val();
            //*联系人电话：
            qcphone = $('.verifyCompanyForm').find(":input[name='qcphone']").val();

            //contact_email
            contact_email = $('.verifyCompanyForm').find(":input[name='contact_email']").val();

            contact_qq = $('.verifyCompanyForm').find(":input[name='contact_qq']").val();

            contact_wechat = $('.verifyCompanyForm').find(":input[name='contact_wechat']").val();


            if (company_name.length < 2) {
                $(":input[name='company_name']").focus();
                $('.errorTips').hide();
                $(":input[name='company_name']").siblings('i').show().find('em').html('错误的公司名称');
                return false;
            }
            if (province == '') {
                $(":input[name='province']").focus();
                $('.errorTips').hide();
                $(":input[name='province']").siblings('i').show().find('em').html('请选择省份');
                return false;
            }
            if (city == '' || city == '地级市') {
                $(":input[name='city']").focus();
                $('.errorTips').hide();
                $(":input[name='city']").siblings('i').show().find('em').html('请选择城市');
                return false;
            }
            if (town == '' || town == '市、县级市、县') {
                $(":input[name='town']").focus();
                $('.errorTips').hide();
                $(":input[name='town']").siblings('i').show().find('em').html('请选择市、县级市、县');
                return false;
            }
            if (!address) {
                $(":input[name='address']").focus();
                $('.errorTips').hide();
                $(":input[name='address']").siblings('i').show().find('em').html('请输入详细地址');
                return false;
            }
            if (business_licence.length < 6) {
                $(":input[name='business_licence']").focus();
                $('.errorTips').hide();
                $(":input[name='business_licence']").siblings('i').show().find('em').html('组织机构编号不符合规范');
                return false;
            }
            if (!post_code) {
                $(":input[name='post_code']").focus();
                $('.errorTips').hide();
                $(":input[name='post_code']").siblings('i').show().find('em').html('请输入邮编');
                return false;
            }
            else if (!/^\d{6}$/.test(post_code)) {
                $(":input[name='post_code']").siblings('i').show().find('em').html('邮编格式错误');
                $(":input[name='post_code']").focus();
                return false;
            }

            if (company_type_id == 1 || company_type_id == 6) {

                if ($("#map_qualification_path_file").find("img")[0].src != "") {
                    var tt = $("#map_qualification_path_file").find("img")[0].src;
                }
                else {
                    var odiv = document.getElementById("map_qualification_path_file");
                    done(odiv, function (e) {

                    });
                    //odiv.onfocus = function () { alert('获取焦点'); }
                    odiv.focus();
                    //$("#map_qualification_path_file").attr("tabindex","0");
                    $('.errorTips').hide();

                    $("#map_qualification_path_file").siblings('i').show().find('em').html('请上传资质证书');
                    return false;
                }
            }
          

            if ($("#business_licence_path_file").find("img")[0].src != "") {
                var tt = $("#business_licence_path_file").find("img")[0].src;
            }
            else {
                var odiv = document.getElementById("business_licence_path_file");
                done(odiv, function (e) {

                });
                //odiv.onfocus = function () { alert('获取焦点'); }
                odiv.focus();
                //$("#map_qualification_path_file").attr("tabindex","0");
                $('.errorTips').hide();

                $("#business_licence_path_file").siblings('i').show().find('em').html('请上传');
                return false;
            }

            //法定代表人身份证
            //if ($("#corporate_id_card_front_file").find("img")[0].src != "") {
            //    var tt = $("#corporate_id_card_front_file").find("img")[0].src;
            //}
            //else {
            //    var odiv = document.getElementById("corporate_id_card_front_file");
            //    done(odiv, function (e) {

            //    });
            //    //odiv.onfocus = function () { alert('获取焦点'); }
            //    odiv.focus();
            //    //$("#map_qualification_path_file").attr("tabindex","0");
            //    $('.errorTips').hide();

            //    $("#corporate_id_card_front_file").siblings('i').show().find('em').html('请上传');
            //    return false;
            //}

            if (certify_type==2) {
                //经办人身份证
                //if ($("#operator_id_card_front_file").find("img")[0].src != "") {
                //    var tt = $("#operator_id_card_front_file").find("img")[0].src;
                //}
                //else {
                //    var odiv = document.getElementById("operator_id_card_front_file");
                //    done(odiv, function (e) {

                //    });
                //    //odiv.onfocus = function () { alert('获取焦点'); }
                //    odiv.focus();
                //    //$("#map_qualification_path_file").attr("tabindex","0");
                //    $('.errorTips').hide();

                //    $("#operator_id_card_front_file").siblings('i').show().find('em').html('请上传');
                //    return false;
                //}
            }


            //授权委托书扫描件
            //if ($("#client_authorization_path_file").find("img")[0].src != "") {
            //    var tt = $("#client_authorization_path_file").find("img")[0].src;
            //}
            //else {
            //    var odiv = document.getElementById("client_authorization_path_file");
            //    done(odiv, function (e) {

            //    });
            //    //odiv.onfocus = function () { alert('获取焦点'); }
            //    odiv.focus();
            //    //$("#map_qualification_path_file").attr("tabindex","0");
            //    $('.errorTips').hide();

            //    $("#client_authorization_path_file").siblings('i').show().find('em').html('请上传');
            //    return false;
            //}

            //服务协议
            //if ($("#secrecy_agreement_path_file").find("img")[0].src != "") {
            //    var tt = $("#secrecy_agreement_path_file").find("img")[0].src;
            //}
            //else {
            //    var odiv = document.getElementById("secrecy_agreement_path_file");
            //    done(odiv, function (e) {

            //    });
            //    //odiv.onfocus = function () { alert('获取焦点'); }
            //    odiv.focus();
            //    //$("#map_qualification_path_file").attr("tabindex","0");
            //    $('.errorTips').hide();

            //    $("#secrecy_agreement_path_file").siblings('i').show().find('em').html('请上传');
            //    return false;
            //}

            if ($.trim(contact_name) == '') {
                $(":input[name='contact_name']").focus();
                $('.errorTips').hide();
                $(":input[name='contact_name']").siblings('i').show().find('em').html('请输入联系人姓名');
                return false;
            }
            if ($.trim(qcphone) == '') {
                $(":input[name='qcphone']").focus();
                $('.errorTips').hide();
                $(":input[name='qcphone']").siblings('i').show().find('em').html('请输入联系人电话');
                return false;
            }
            else if (!isMob.test(qcphone) && !isPhone.test(qcphone)) {
                $(":input[name='qcphone']").focus();
                $('.errorTips').hide();
                $(":input[name='qcphone']").siblings('i').show().find('em').html('联系人电话格式错误');
                return false;
            }
            if ($.trim(contact_email) == '') {
                $(":input[name='contact_email']").focus();
                $('.errorTips').hide();
                $(":input[name='contact_email']").siblings('i').show().find('em').html('请输入联系人电子邮箱');
                return false;
            }
            else if (!/\w+[@]{1}\w+[.]\w+/.test(contact_email)) {
                $(":input[name='contact_email']").focus();
                $('.errorTips').hide();
                $(":input[name='contact_email']").siblings('i').show().find('em').html('联系人电子邮箱格式错误');
                return false;
            }
            if ($.trim(contact_qq) == '') {
                $(":input[name='contact_qq']").focus();
                $('.errorTips').hide();
                $(":input[name='contact_qq']").siblings('i').show().find('em').html('请输入联系人QQ');
                return false;
            } else if (!isQQ.test(contact_qq)) {
                $(":input[name='contact_qq']").focus();
                $('.errorTips').hide();
                $(":input[name='contact_qq']").siblings('i').show().find('em').html('QQ格式错误');
                return false;
            }
            if ($.trim(contact_wechat) == '') {
                $(":input[name='contact_wechat']").focus();
                $('.errorTips').hide();
                $(":input[name='contact_wechat']").siblings('i').show().find('em').html('请输入联系人微信');
                return false;
            }

            //$(".centerBtnCompany").attr("disabled", "disabled").val('提交中...');


            $('#verifyCompanyForm').ajaxSubmit({
                type: "post",  //提交方式
                dataType: "json", //数据类型
                url: '?action=verifycompanyform', //请求url
                success: function (obj) { //提交成功的回调函数
                    var code = obj.code;
                    //alert(code);
                    if (code == 200) {
                        layer.alert('资质认证完成，等待审核', {
                            time: 2000
                        }, function () {
                            window.location.href = "/forms/publicforms/login/userinfo.aspx";
                        });
                    } if (code == 100) {
                      
                        layer.alert("该机构已认证,不能重复认证！");
                    }

                    else {
                      
                       // layer.alert("该机构已认证,不能重复认证！");
                      //  $('.centerBtnCompany').removeAttr("disabled");
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(XMLHttpRequest);
                    console.log(textStatus)
                    console.log(errorThrown)
                    if ('413' == XMLHttpRequest.status) {
                        layer.alert('上传的图片文件过大，请控制在5MB内');
                      //  $("#verifyPersonForm .centerBtn").removeAttr("disabled").html('提交认证');
                    } else {
                        layer.alert('上传出错，请重试');
                        //$("#verifyPersonForm .centerBtn").removeAttr("disabled").html('提交认证');
                    }
                }
            });
        })
    </script>
    <script>
        function check() {
            var user = document.getElementById("company_name");
            var username = user.value.trim();
            $.get("?action=check&&data=" + username.trim(), function (result) {
                if (result == "1") {
                   
                }
                else {
                  $(":input[name='company_name']").siblings('i').show().find('em').html('该机构已认证,不能重复认证！');
                  
                    return false;
                }
            })
        }
    </script>

    <script>
        $('img').zoomify();
        function showBig() {
            $("#test").click();
        }
    </script>
    <script>
        $(document).ready(function () {
            //如果非测绘企业,默认隐藏

            //如果法人办理,默认隐藏,经办人身份证、授权委托书
        });
    </script>

    <!-- BEGIN FOOTER -->

    <!-- END FOOTER -->

        <script src="../../../js/jquery-ui-1.10.3.custom.min.js"></script>
    <script src="../../../js/bootstrap.js"></script>
    <script src="../../../js/twitter-bootstrap-hover-dropdown.min.js"></script>
    <script src="../../../js/jquery.slimscroll.min.js"></script>
    <script src="../../../js/jquery.cookie.min.js"></script>
    <script src="../../../js/jquery.uniform.min.js"></script>
    <script src="../../../js/jquery.form.js"></script>
    <script src="../../../js/select2_pinyin.js"></script>
    <script src="../../../js/select2.min.js"></script>
    <script src="../../../js/plugins/boostrap-datetimepicker/moment.min.js"></script>
    <script src="../../../js/plugins/boostrap-datetimepicker/daterangepicker.js"></script>
    <script src="../../../js/plugins/layer/layer.js"></script>
    <script src="../../../js/plugins/layer/layer.ext.js"></script>

<!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="../../../js/app.js"></script>
    <script src="../../../js/jquery.dataTables.js"></script>
    <script src="../../../js/plugins/dataTables/DT_bootstrap.js"></script>
    <script src="../../../js/plugins/webuploader/webuploader.js"></script>
<!-- END PAGE LEVEL SCRIPTS -->
    <script>
        jQuery(document).ready(function () {
            App.init(); // initlayout and core plugins
        });
    </script>

    <script>
        $(".select2-select").select2();
    </script>
    <script>
        window.onload = function () {
            //do something
        }
        //生成url
        </script>
    <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>
