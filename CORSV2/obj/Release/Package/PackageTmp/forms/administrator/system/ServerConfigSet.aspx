<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServerConfigSet.aspx.cs" Inherits="CORSV2.forms.administrator.system.ServerConfigSet" %>


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
                        <form
                            id="verifyCompanyForm" runat="server" class="verifyCompanyForm vertifyCompanyForm vertifyForm" enctype="multipart/form-data">

                            <ul class="centerFormUl" style="padding-top: 0;">
                                <li class="vertifyLiTitle titleBottom">配置信息修改</li>
                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>产品名称：</label>
                                    <div class="labelRight">
                                      <input type="text" name="ServerName" id="ServerName" value="" class="form-control width-300"  runat="server">
                                        
                                    </div>

                                </li>

                                <li class="clearfix">

                                    <label class="labelLeft"><span class="required">*</span>付款方式：</label>
                                    <div class="labelRight">
                                     
                                       <select name="paymentMethod" id="paymentMethod" class="form-control width-300 "  runat="server" >
                                              
                                            <option value="按年">按年</option>
                                                <option value="按月">按月</option>
                                             <option value="按量">按量</option>
                                               
                                           
                                               
                                            </select>
                                        <i class="errorTips errorCompany" hidden="true" >
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                
                                <li id="map_qualificationID" class="clearfix cehui">
                                    <label class="labelLeft"><span class="required">*</span>价格：</label>
                                    <div class="labelRight">
                                        <input type="text" name="Price" id="Price" value="" class="form-control width-300"  runat="server">
                                        <i class="errorTips errorShui" hidden="true" >
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>产品描述：</label>
                                    <div class="labelRight">
                                        <input type="text" id="ProductDescription" name="ProductDescription" value="" class="form-control width-300" runat="server">
                                        <i class="errorTips errorZuzhi" hidden="true" >
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                             
                            
                                <li class="clearfix">
                                    <label class="labelLeft">&nbsp;</label>
                                    <div class="labelRight">
                                        <button id="save" type="button" class="btn btn-lg btn-success">修改</button>
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
      
               
    </script>
    <!-- END CONTAINER -->
    <script>
        $("#save").click(function () {
            $.ajax({
                type: "POST",
                url: "?action=save",
                data: $("#verifyCompanyForm").serialize(),
                asnyc: true,
                success: function (result) {
                    if (result == "1") {

                        layer.alert('修改完成', {
                            time: 2000
                        }, function () {
                           
                        });

                    }
                    else {

                        layer.alert('修改失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });

                    }
                },
                error: function () {
                    layer.alert('修改失败', {
                        skin: 'layui-layer-lan', //样式类名,
                    });
                }
            });
        })
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
   
    <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>

