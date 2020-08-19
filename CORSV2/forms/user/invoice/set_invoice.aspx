<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="set_invoice.aspx.cs" Inherits="CORSV2.forms.user.invoice.set_invoice" %>

<!DOCTYPE html>


<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>申请发票</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <meta name="MobileOptimized" content="320">

    <link rel="shortcut icon" href="../../favicon.ico" />
    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="../../../themes/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../../themes/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../themes/css/uniform.default.css" rel="stylesheet" />
    <link href="../../../themes/css/select2_metro.css" rel="stylesheet" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
    <link href="../../../themes/css/jquery.gritter.css" rel="stylesheet" />
    <link href="../../../themes/css/style-metronic.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css" rel="stylesheet" />
    <link href="../../../themes/css/style-responsive.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins.css" rel="stylesheet" />
    <link href="../../../themes/css/custom.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/layer/skin/layer.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/layer/skin/layer.ext.css" rel="stylesheet" />
    <script src="../../../js/jquery-1.10.2.min.js"></script>
    <link href="../../../themes/css/ucenter.css" rel="stylesheet" />
    <!-- END THEME STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
    <!-- END THEME STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body class="page-header-fixed">

    <div id="body_loading" class="dataTables_processing" style="z-index: 999999;">
        <i class="fa fa-coffee"></i>&nbsp;请稍等,正在努力加载中...
    </div>

    <div class="clearfix"></div>



    <!-- BEGIN CONTAINER -->



        <!-- BEGIN PAGE -->
        <div class="page-header">

</div>
            <!-- BEGIN DASHBOARD STATS -->
    <div class="container">
            <div class="row">
                
                <section id="ucenterSection">
                    <div class="ContentDiv certifyMainContent">
                        <form
                            id="verifyCompanyForm" class="verifyCompanyForm vertifyCompanyForm vertifyForm" enctype="multipart/form-data">
                            <ul class="centerFormUl" style="padding-top: 0;">
                                <li class="clearfix">
                                    <input type="hidden" name="invoice_info_id" id="invoice_info_id" value="" />
                                    <label class="labelLeft"><span class="required">*</span>开具类型：</label>
                                    <div class="labelRight">
                                        <div class="controls" id="user_type_div">

                                            <label class="radio">
                                                <input type="radio" name="user_type" class="user_type" value="1" checked="checked" />个人
                                            </label>
                                            <label class="radio">
                                                <input type="radio" name="user_type" class="user_type" value="2" />企业或机关
                                            </label>
                                        </div>
                                        <i class="errorTips errorCompany" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>


                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>发票抬头：</label>
                                    <div class="labelRight">
                                        <input type="text" name="invoice_header" id="invoice_header" value="" class="form-control width-300" placeholder="请填写您营业执照上的全称">
                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>


                                <li class="clearfix invoice_info">
                                    <label class="labelLeft">开票代码：</label>
                                    <div class="labelRight">
                                        <input type="text" name="invoice_info_code" id="invoice_info_code" value="" class="form-control width-300" placeholder="请填入六位开票代码（选填）">
                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>


                                <li class="clearfix">
                                    <label class="labelLeft"><span class="required">*</span>发票类型：</label>
                                    <div class="labelRight invoice_info">
                                        <div class="controls" id="invoice_type_div">
                                            <label class="radio">
                                                <input type="radio" checked name="invoice_type" id="invoice_type" value="1" />增值税普通发票
                                            </label>
                                            <label class="radio">
                                                <input type="radio" name="invoice_type" id="invoice_type" value="2" />增值税专用发票
                                            </label>
                                        </div>
                                        <i class="errorTips errorCompany" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                    <div class="labelRight invoice_type_1">
                                        增值税普通发票
                                    </div>
                                </li>

                                <li class="clearfix invoice_info">
                                    <label class="labelLeft"><span class="required">*</span>纳税人识别号：</label>
                                    <div class="labelRight">
                                        <input type="text" name="registration_certification" value="" class="form-control width-300" placeholder="请填写您税务登记证上的编号">
                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                        <span class="required">*无识别号请填0000</span>
                                    </div>
                                </li>

                                <li class="clearfix invoice_info">
                                    <label class="labelLeft"><span class="required invoice_type invoice_info">*</span>基本开户银行名称：</label>
                                    <div class="labelRight">
                                        <input type="text" name="bank_name" value="" class="form-control width-300" placeholder="请填写您开户许可证上的开户银行">
                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix invoice_info">
                                    <label class="labelLeft"><span class="required  invoice_type invoice_info">*</span>基本开户账号：</label>
                                    <div class="labelRight">
                                        <input type="text" name="bank_account" value="" class="form-control width-300" placeholder="请填写您开户许可证上的银行账号">
                                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix invoice_info">
                                    <label class="labelLeft"><span class="required invoice_type invoice_info">*</span>注册场所地址：</label>
                                    <div class="labelRight">
                                        <input type="text" id="address" name="address" value="" class="form-control width-300" placeholder="请填写您营业执照上的注册地址">
                                        <i class="errorTips errorAddress" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>

                                    </div>
                                </li>

                                <li class="clearfix invoice_info">
                                    <label class="labelLeft"><span class="required invoice_type invoice_info">*</span>注册固定电话：</label>
                                    <div class="labelRight">
                                        <input type="text" name="tel" value="" class="form-control width-300" placeholder="请填写有效的联系电话，格式：区号-号码">
                                        <i class="errorTips errorCompany" hidden="true" style="display: none;">
                                            <span class="fa fa-warning"></span><em></em>
                                        </i>
                                    </div>
                                </li>

                                <li class="clearfix">
                                    <label class="labelLeft">&nbsp;</label>
                                    <div class="labelRight">
                                        <div class="btn btn-primary invoiceBtn">提交信息</div>
                                    </div>
                                </li>
                            </ul>
                        </form>

                    </div>
                </section>
            </div>
        </div>
            <!-- END DASHBOARD STATS -->
        <!-- END PAGE -->

    <script src="../../../js/jquery-ui-1.10.3.custom.min.js"></script>
    <script src="../../../js/bootstrap.js"></script>
    <script src="../../../js/twitter-bootstrap-hover-dropdown.min.js"></script>
    <script src="../../../js/jquery.slimscroll.min.js"></script>
    <script src="../../../js/jquery.cookie.min.js"></script>
    <script src="../../../js/jquery.uniform.min.js"></script>
    <script src="../../../js/jquery.form.js"></script>
            <script src="../../../js/plugins/layer/layer.js"></script>
    <script src="../../../js/plugins/boostrap-datetimepicker/moment.min.js"></script>
    <script src="../../../js/plugins/boostrap-datetimepicker/daterangepicker.js"></script>


    <script>

        $(".invoice_type_1").hide(); $(".invoice_info").hide();
        $(".invoice_type_1").show();
        //发票开具类型为个人,只需要填写发票抬头
        $("body").on("change", ".user_type", function () {
            var user_type = $(this).val();
            //测绘资质企业
            if (user_type == 1 || user_type == 3) {
                //显示几个框
                $(".invoice_info").hide();
                $(".invoice_type_1").show();
            } else {
                //非测绘资质企业，隐藏几个框
                $(".invoice_info").show();
                var invoice_type = $('#invoice_type_div input:radio:checked').val();
                if (invoice_type == 1) {
                    $(".invoice_type").hide();
                }
                $(".invoice_type_1").hide();
            }
        });
        //	//如果非测绘企业,默认隐藏
        //		//发票类型为增值税普通发票,只需要填写部分信息
        $("body").on("change", "#invoice_type", function () {
            uploader.destroy;
            $(".filePicker").html("选择图片");
            initUploader();
            var invoice_type = $(this).val();
            if (invoice_type == 1) {
                $(".invoice_type").hide();
            } else {
                $(".invoice_info").show();
            }
        });
    </script>
    <!-- END CONTAINER -->
    <script type="text/javascript">
        // 企业认证的提交表单按钮
        $(".invoiceBtn").click(function () {
            $('.errorTips').hide(); // 隐藏所有的错误提示信息
            invoice_info_id = $('.verifyCompanyForm').find(":input[name='invoice_info_id']").val();
            //发票抬头
            invoice_header = $('.verifyCompanyForm').find(":input[name='invoice_header']").val();
            //发票类型
            invoice_type = $('#invoice_type_div input:radio:checked').val();
            //开具类型
            user_type = $('#user_type_div input:radio:checked').val();
            //税务登记号
            registration_certification = $('.verifyCompanyForm').find(":input[name='registration_certification']").val();
            //基本开户银行名称
            bank_name = $('.verifyCompanyForm').find(":input[name='bank_name']").val();
            //基本开户银行账户
            bank_account = $('.verifyCompanyForm').find(":input[name='bank_account']").val();
            //注册固定场所
            address = $('.verifyCompanyForm').find(":input[name='address']").val();
            //注册固定电话
            tel = $('.verifyCompanyForm').find(":input[name='tel']").val();
            //营业执照图片
            business_licence_img = $('.verifyCompanyForm').find(":input[name='business_licence_img']").val();
            //税务登记证复印件
            registration_certification_img = $('.verifyCompanyForm').find(":input[name='registration_certification_img']").val();
            //一般纳税人资格认证复印件
            general_taxpayer_img = $('.verifyCompanyForm').find(":input[name='general_taxpayer_img']").val();

            //开票代码
            invoice_info_code = $("#invoice_info_code").val();

            if (invoice_info_code && invoice_info_code.length != 6) {
                $("#invoice_info_code").focus();
                $(":input[name='invoice_info_code']").siblings('i').show().find('em').html('请填写6位有效发票代码');
                return false;
            }

            if (!invoice_header) {
                $(":input[name='invoice_header']").focus();
                $('.errorTips').hide();
                $(":input[name='invoice_header']").siblings('i').show().find('em').html('请填写发票抬头');
                return false;
            }
            if (user_type == 2) {
                if (!registration_certification) {
                    $(":input[name='registration_certification']").focus();
                    $('.errorTips').hide();
                    $(":input[name='registration_certification']").siblings('i').show().find('em').html('请填写税务登记证号');
                    return false;
                }

                if (invoice_type == 2) {
                    if (!bank_name) {
                        $(":input[name='bank_name']").focus();
                        $('.errorTips').hide();
                        $(":input[name='bank_name']").siblings('i').show().find('em').html('请填写基本开户银行名称');
                        return false;
                    }
                    if (!bank_account) {
                        $(":input[name='bank_account']").focus();
                        $('.errorTips').hide();
                        $(":input[name='bank_account']").siblings('i').show().find('em').html('请填写基本开户账号');
                        return false;
                    }
                    if (!address) {
                        $(":input[name='address']").focus();
                        $('.errorTips').hide();
                        $(":input[name='address']").siblings('i').show().find('em').html('请填写注册场所地址');
                        return false;
                    }
                    if (!tel) {
                        $(":input[name='tel']").focus();
                        $('.errorTips').hide();
                        $(":input[name='tel']").siblings('i').show().find('em').html('请填写注册固定电话');
                        return false;
                    }
                }
            }
            $(".invoiceBtn").attr("disabled", "disabled").val('提交中...');
            //注意：parent 是 JS 自带的全局对象，可用于操作父页面
            var index = parent.layer.getFrameIndex(window.name); //获取窗口索引

            $('#verifyCompanyForm').ajaxSubmit({
                type: "post",  //提交方式
                dataType: "json", //数据类型
                url: '/forms/user/invoice/set_invoice.aspx?action=invoiceInfoSubmit', //请求url
                success: function (obj) { //提交成功的回调函数
                    var code = obj.code;
                    if (code == 200) {
                        layer.msg('保存成功，即将回到发票栏', {
                            time: 500
                        }, function () {
                            //window.parent.location.reload();//刷新父页面
                            parent.layer.close(index);
                            window.location.href = "/forms/user/invoice/confirm_invoice.aspx?action=random_number";
                        });
                    } else {
                        layer.alert("提交出错");
                        $('.invoiceBtn').removeAttr("disabled");
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    if ('413' == XMLHttpRequest.status) {
                        layer.alert('上传出错，请重试');
                        $(".invoiceBtn").removeAttr("disabled").html('提交');
                    } else {
                        layer.alert('上传出错，请重试');
                        $(".invoiceBtn").removeAttr("disabled").html('提交');
                    }
                }
            });
        })
    </script>

    <!-- END PAGE LEVEL SCRIPTS -->

    <script>
        window.onload = function () {
            //do something
            $("#body_loading").hide();
        }
        //生成url
        function getUrl(url, params) {
            if (!params) {
                return url;
            }
            var urlmodel = '3';
            var connectstring = "&";
            if (urlmodel == '0') {
                connectstring = "&";
            } else if (urlmodel == '1') {
                connectstring = "?";
            } else if (urlmodel == '2') {
                connectstring = "?";
            } else {
                connectstring = "&";
            }
            url += connectstring;
            for (var key in params) {
                url += key + "=" + params[key] + "&";
            }
            return url;
        }
    </script>
    <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>
