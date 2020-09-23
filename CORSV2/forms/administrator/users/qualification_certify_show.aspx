<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qualification_certify_show.aspx.cs" Inherits="CORSV2.forms.administrator.users.qualification_certify_show" %>

<!DOCTYPE html>
<html lang="en" class="no-js">
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
    <link rel="shortcut icon" href="favicon.ico" />
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body class="page-header-fixed">
    <link href="../../../themes/css/ucenter.css" rel="stylesheet" />
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
        </style>

        <!-- BEGIN PAGE -->
        <div class="page-content">
            <!-- BEGIN SAMPLE PORTLET CONFIGURATION MODAL FORM-->
            <div class="modal fade" id="portlet-config" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                            <h4 class="modal-title">Modal title</h4>
                        </div>
                        <div class="modal-body">
                            Widget settings form goes here
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn blue">Save changes</button>
                            <button type="button" class="btn default" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal -->
            <!-- END SAMPLE PORTLET CONFIGURATION MODAL FORM-->

            <!-- BEGIN PAGE HEADER-->
            <!-- END PAGE HEADER-->
            <!-- BEGIN DASHBOARD STATS -->
            <div class="row">
                <section id="ucenterSection">
                    <div class="ContentDiv certifyMainContent">
                        <form
                            id="verifyCompanyForm" runat="server" class="verifyCompanyForm vertifyCompanyForm vertifyForm" enctype="multipart/form-data">

                            <ul class="centerFormUl" style="padding-top: 0;">
                                <li class="vertifyLiTitle titleBottom">基本信息填写</li>
                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>机构名称：</label>
                                    <div class="labelRight">
                                        <input type="text" name="company_name" value="" id="company_name" class="form-control width-300 " placeholder="请确保跟公章信息一致" runat="server">
                                        <i class="errorTips errorCompany" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>

                                </li>

                                <li class="clearfix">

                                    <label class="labelLeft"><span class="required">*</span>机构类型：</label>
                                    <div class="labelRight">
                                        <input type="text" name="company_type_id" value="" id="company_type_id" class="form-control width-300 " q placeholder="请确保跟公章信息一致" runat="server">
                                        <i class="errorTips errorCompany" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li id="mapleve1i" class="clearfix cehui">
                                    <label class="labelLeft"><span class="required">*</span>测绘资质等级：</label>

                                    <div class="labelRight">
                                        <input type="text" name="map_level" value="" id="map_level" class="form-control width-300 " placeholder="请确保跟公章信息一致" runat="server">
                                    </div>
                                    <i class="errorTips errorZhizhao" hidden="true" style="display: none;">
                                        <span class="fa fa-warning"></span><em></em>
                                    </i>
                                </li>
                                <li id="map_qualificationID"  class="clearfix cehui">
                                    <label class="labelLeft"><span class="required">*</span>测绘资质证书编号：</label>
                                    <div class="labelRight">
                                        <input type="text" name="map_qualification_sn" id="map_qualification_sn" value="" class="form-control width-300" placeholder="填写示例：甲测资字4300001" runat="server">
                                        <i class="errorTips errorShui" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>组织机构编号：</label>
                                    <div class="labelRight">
                                        <input type="text" id="business_licence" name="business_licence" value="" class="form-control width-300" placeholder="三证合一请填写统一社会信用代码" runat="server">
                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>法定代表人姓名：</label>
                                    <div class="labelRight">
                                        <input type="text" name="corporate" id="corporate" value="" class="form-control width-300" runat="server">
                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>法定代表人电话：</label>
                                    <div class="labelRight">
                                        <input type="text" name="corporate_tel" id="corporate_tel" value="" class="form-control width-300" placeholder="填写示例：0731-88888888" runat="server">
                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>详细地址：</label>
                                    <div class="labelRight">
                                        <input type="text" id="address" name="address" class="form-control width-300" value="" runat="server">
                                        <i class="errorTips errorAddress" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>

                                    </div>
                                </li>

                                <li class="vertifyLiTitle" style="margin: 10px 0;">资料上传</li>

                                <li id="map_qualification" class="clearfix cehui" style="height: auto;">
                                    <label class="labelLeft"><span class="required">*</span>测绘资质复印件（盖章）：</label>
                                    <div class="labelRight">

                                        <!--用来存放item-->
                                        <div id="map_qualification_path_file" class="uploader-list">
                                            <img class="certify-img" src="" id="map_qualification_path" runat="server">
                                        </div>
                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>
                                <li class="clearfix" style="height: auto;">
                                    <label class="labelLeft"><span class="required">*</span>组织机构代码证复印件（盖章）：</label>
                                    <div class="labelRight">
                                        <!--用来存放item-->
                                        <div id="business_licence_path_file" class="uploader-list">
                                            <img id="business_licence_path" class="certify-img" src="" runat="server">
                                        </div>
                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>
                            <%--    <li class="clearfix" style="height: auto;">
                                    <label class="labelLeft"><span class="required">*</span>法定代表人身份证：</label>
                                    <div class="labelRight">
                                        <!--用来存放item-->
                                        <div id="corporate_id_card_front_file" class="uploader-list">
                                            <img class="certify-img" src="" id="corporate_id_card" runat="server">
                                              <img class="certify-img" src="" id="corporate_id_card_front" runat="server">
                                        </div>
                                    </div>
                                </li>

                                <li class="clearfix operator_id_card" style="height: auto;">
                                    <label class="labelLeft"><span class="required">*</span>经办人身份证：</label>
                                    <div class="labelRight">
                                        <div id="operator_id_card_front_file" class="uploader-list">
                                            <img class="certify-img" src="" id="operator_id_card_front" runat="server">
                                               <img class="certify-img" src="" id="corporate_id_card_reverse" runat="server">
                                        </div>
                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>
                                    <li class="clearfix operator_id_card" style="height: auto;">
                                    <label class="labelLeft"><span class="required">*</span>服务协议（盖章）：</label>
                                    <div class="labelRight">
                                        <div id="secrecy_agreement_path_file" class="uploader-list">
                                           <img class="certify-img" src="" id="secrecy_agreement_path" runat="server">
                                          <%--  <input id="Text1" runat="server" style="border:none;width:300px" />          
                                             <input id="secrecy_agreement"   runat="server" type="button" value="下载" />
                                        </div>
                                    </div>
                                </li>
                                <li class="clearfix operator_id_card" style="height: auto;">
                                    <label class="labelLeft"><span class="required">*</span>授权委托书扫描件（盖章）：</label>
                                    <div class="labelRight">
                                        <div id="client_authorization_path_file" class="uploader-list">
                                            <img class="certify-img" src="" id="client_authorization_path" runat="server">
                                           <%--<input id="Text2" style="border:none;width:300px" runat="server"  />
                                            
                                             <input id="client_authorization" runat="server" type="button" value="下载" />
                                            
                                        </div>
                                    </div>
                                </li>--%>
                                 



                                <li class="vertifyLiTitle titleBottom">联系人信息</li>
                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>联系人姓名：</label>
                                    <div class="labelRight">
                                        <input type="text" name="contact_name" id="contact_name" class="form-control width-300" value="" runat="server">
                                        <i class="errorTips errorName" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>
                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>联系人电话：</label>
                                    <div class="labelRight">
<%--                                        <input readonly="readonly" type="tel" name="contact_phone" id="contact_phone" class="form-control width-300" value="" placeholder="请填写手机号码" runat="server">--%>
                                        <input readonly="readonly" type="text" name="contactPhone" id="contactPhone" class="form-control width-300" value="" placeholder="请填写手机号码" runat="server">
                                         <i class="errorTips errorTel" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
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
    <link href="../../../js/plugins/webuploader/webuploader.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/layer/skin/layer.css" rel="stylesheet" />
        <script>
      
            $(function () {
                if ($("#company_type_id").val() == "市内测绘资质单位" || $("#company_type_id").val() == "市外测绘资质单位") {
                    document.getElementById("mapleve1i").style.display = "block";
                    document.getElementById("map_qualification").style.display = "block";

                    document.getElementById("map_qualificationID").style.display = "block";
                }
                else {
                    document.getElementById("mapleve1i").style.display = "none";
                    document.getElementById("map_qualification").style.display = "none";

                    document.getElementById("map_qualificationID").style.display = "none";
                }
            })
          
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

    </script>
    <script>

        //点击图片后放大
        $('img').zoomify();
    </script>
    <script>
        $(document).ready(function () {
            $("input").attr("readonly", "readonly")
        });
    </script>

    <!-- BEGIN FOOTER -->
    <!-- END FOOTER -->
    <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
    <!-- BEGIN CORE PLUGINS -->
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
            $("#body_loading").hide();
        }


    </script>

 

    <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>
