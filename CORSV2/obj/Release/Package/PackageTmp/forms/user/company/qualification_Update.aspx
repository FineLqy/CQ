<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qualification_Update.aspx.cs" Inherits="CORSV2.forms.user.company.qualification_Update" %>

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
                                <li class="vertifyLiTitle titleBottom">基本信息填写</li>
                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>机构名称：</label>
                                    <div class="labelRight">
                                        <input type="text" name="company_name" value="" id="company_name" class="form-control width-300 " placeholder="请确保跟公章信息一致" runat="server">
                                        <i class="errorTips errorCompany" hidden="true" >
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>

                                </li>

                                <li class="clearfix">

                                    <label class="labelLeft"><span class="required">*</span>机构类型：</label>
                                    <div class="labelRight">
                                     
                                       <select name="type_id" id="type_id" class="form-control width-300 "  onchange="change()" runat="server" >
                                              
                                            <option value="1">测绘资质单位</option>
                                                <option value="2">政府机构</option>
                                             <option value="3">仪器公司</option>
                                                <option value="4">科研院所</option>
                                           <option value="5">其他非测绘资质执证单位</option>
                                           <option value="6">市外测绘资质单位</option>
                                           
                                               
                                            </select>
                                        <i class="errorTips errorCompany" hidden="true" >
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li id="mapleve1i" class="clearfix cehui">
                                    <label class="labelLeft"><span class="required">*</span>测绘资质等级：</label>

                                    <div class="labelRight">
                                        <select id="maplevel" name="maplevel" runat="server" class=" form-control width-300 " >
                                          <option value=" "></option>
                                            <option value="甲级">甲级</option>
                                            <option value="乙级">乙级</option>
                                            <option value="丙级">丙级</option>
                                            <option value="丁级">丁级</option>
                                        </select>
                                    </div>
                                    <i class="errorTips errorZhizhao" hidden="true" >
                                        <span class="fa fa-warning"></span><em></em>
                                    </i>
                                </li>
                                <li id="map_qualificationID" class="clearfix cehui">
                                    <label class="labelLeft"><span class="required">*</span>测绘资质证书编号：</label>
                                    <div class="labelRight">
                                        <input type="text" name="map_qualification_sn" id="map_qualification_sn" value="" class="form-control width-300" placeholder="填写示例：甲测资字4300001" runat="server">
                                        <i class="errorTips errorShui" hidden="true" >
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>组织机构编号：</label>
                                    <div class="labelRight">
                                        <input type="text" id="business_licence" name="business_licence" value="" class="form-control width-300" placeholder="三证合一请填写统一社会信用代码" runat="server">
                                        <i class="errorTips errorZuzhi" hidden="true" >
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>法定代表人姓名：</label>
                                    <div class="labelRight">
                                        <input type="text" name="corporate" id="corporate" value="" class="form-control width-300" runat="server">
                                        <i class="errorTips errorZuzhi" hidden="true" >
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>法定代表人电话：</label>
                                    <div class="labelRight">
                                        <input type="text" name="corporate_tel" id="corporate_tel" value="" class="form-control width-300" placeholder="填写示例：0731-88888888" runat="server">
                                        <i class="errorTips errorZuzhi"  >
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>详细地址：</label>
                                    <div class="labelRight">
                                        <input type="text" id="address" name="address" class="form-control width-300" value="" runat="server">
                                       

                                    </div>
                                </li>


                                <li class="vertifyLiTitle" style="margin: 10px 0;">资料上传</li>

                                <li id="map_qualification" class="clearfix cehui" style="height: auto;">
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


                                <li class="clearfix" style="height: auto;">
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

                                        <i class="tipsFile">图片大小不要超过5M，支持PNG，JPG格式.</i>
                                        <br>
                                       

                                    </div>
                                </li>


                                <li class="clearfix operator_id_card" style="height: auto;">
                                    <label class="labelLeft"><span class="required">*</span>授权委托书扫描件（盖章）：</label>
                                    <div class="labelRight" style="width:500px">
                                        <div id="client_authorization_path_file" class="uploader-list">
                                            <img id="client_authorization_path_file_" class="certify-img" src="" runat="server">
                                        </div>
                                        <div class="filePicker" id="client_authorization_path">选择图片</div>

                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>

                                        <i class="tipsFile">图片大小不要超过5M，支持PNG，JPG格式.</i>

                                    </div>
                                </li>
                            <%-- <%--   服务协议（盖章）”--%>
                                <%--  <li class="clearfix" style="height: auto;">
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
                                        <input id="Hidden1" type="hidden" runat="server"  />
                                        <input type="text" id="phone" name="phone" class="form-control width-300" value="" placeholder="请填写手机号码" runat="server">
                                        <i class="errorTips errorTel" hidden="true" style="display: none;">
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
        window.onload = function () {
            if ($("#type_id").val() == "1" || $("#type_id").val() == "6") {
                document.getElementById("mapleve1i").style.display = "block";
                document.getElementById("map_qualification").style.display = "block";

                document.getElementById("map_qualificationID").style.display = "block";
            }
            else {
                document.getElementById("mapleve1i").style.display = "none";
                document.getElementById("map_qualification").style.display = "none";

                document.getElementById("map_qualificationID").style.display = "none";
            }
        }
       
        </script>
    <script>


        function change() {

            if ($("#type_id").val() == "1" || $("#type_id").val() == "6") {
                document.getElementById("mapleve1i").style.display = "block";
                document.getElementById("map_qualification").style.display = "block";
                
                document.getElementById("map_qualificationID").style.display = "block";
            }
            else {
                document.getElementById("mapleve1i").style.display = "none";
                document.getElementById("map_qualification").style.display = "none";

                document.getElementById("map_qualificationID").style.display = "none";
            }
        }
    </script>
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
            $('.centerBtnCompany').removeAttr("disabled");
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

  <%--  <script>
        //测绘资质企业，需要增加几个特别的内容
        $("body").on("change", ".company_type_id", function () {
            var company_type_id = $(this).val();
            //测绘资质企业
            if (company_type_id == 1) {
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
    </script>--%>

   
    <%--<script>
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
    </script>--%>


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

                        layer.alert('资质修改完成，等待审核', {
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