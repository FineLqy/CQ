<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pay_order.aspx.cs" Inherits="CORSV2.forms.user.order.pay_order" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta charset="utf-8">
    <title>订单支付 -CORS服务</title>
    <link href="//imgcache.qq.com/open_proj/proj_qcloud_v2/gateway/portal/css/global.css?max_age=2000002" rel="stylesheet" media="screen" />
    <link href="//imgcache.qq.com/open_proj/proj_qcloud_v2/gateway/shopcart/css/shopcart.css?max_age=2000003" rel="stylesheet" media="screen" />
    <script src="../../../js/jquery-1.10.2.min.js"></script>

    <style>
</style>

</head>
<body>
    <div class="body">
        <div class="mod-pay">
            <!--head start-->
            <div class="pay-head">
                <div class="pay-head-mod clearfix">
                    <div class="pay-head-title">
                        <h2>支付</h2>
                    </div>
                    <div class="pay-head-step">
                        <ul>
                            <li class="first succeed"><em>1</em><span>核对信息</span></li>
                            <li class="curr"><em>2</em><span>支付</span></li>
                            <li class=""><em>3</em><span>支付结果</span></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!--head end-->

            <!--body start-->
            <div class="pay-body" id="pay_wrap">

                <div class="payment-wrap">
       

                    <div class="payment-mod clearfix" data-balance="0">


                        <li class="clearfix" style="height: auto;">
                            <label class="labelLeft"><span class="required"></span>上传支付订单收据（盖章）：</label>
                            <div class="labelRight">
                                <div id="secrecy_agreement_path_file" class="uploader-list">
                                    <img class="certify-img" src="">
                                </div>
                                <div class="filePicker" id="secrecy_agreement_path">选择图片</div>

                                <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                                    <span class="fa fa-warning"></span><em></em>
                                </i>

                                <i class="tipsFile">图片大小不要超过5M，支持PNG，JPG格式</i>
                                <br>
                            </div>
                        </li>

                    </div>

                    <div class="payment-mod">
                        <div class="payment-mod-tit clearfix">
                            <div class="payment-left payment-balance">
                                <label>
                                    <input type="checkbox" class="shop-checkbox pay_other_checkbox" checked="checked" disabled="disabled" />
                                    <span>使用其他支付方式</span>
                                    <span class="payment-icon-txt" id="commonTips">(在线支付支持以下4种支付渠道，点击“立即支付”后您可在新开页面选择其中任意一种渠道进行支付。)</span>
                                    <span class="payment-icon-txt" id="commonTips">交易限额说明</span>
                                </label>
                            </div>
                            <div class="payment-right payment-balance pay_other_show">
                                <div class="cost">
                                    <span class="tit">支付:</span>
                                    <span class="price">
                                        <span class="unit-icon">¥<%=price%></span>
                                        <em class="pay_other_value" style="font-weight: bold;"></em>

                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="shop-tab">
                            <div class="payment-icon-list">
                                <div class="payment-icon-list-inner">
                                    <ul>
                                        <li>
                                            <img src="https://mc.qcloudimg.com/static/img/31ff29aa7c86f41aa690617e796cc6ae/wx.png" alt=""></li>
                                        <li>
                                            <img src="https://mc.qcloudimg.com/static/img/bbbb0a8f787841a1fa779044b85b99e7/qq.png" alt=""></li>
                                        <li>
                                            <img src="https://mc.qcloudimg.com/static/img/017c58478b50aebdd36cc12ffbb35c35/visa.png" alt=""></li>
                                        <li>
                                            <img src="https://mc.qcloudimg.com/static/img/396c830c5565516f1c019cde90fee848/cup.png" alt=""></li>
                                    </ul>

                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="pay-submit-wrap step2">
                        <div class="pay-submit">
                            <div class="cost">
                            </div>
                            <a href="javascript:;" class="shop-btn pay" id="pay_pay_btn" ><span></span>立即支付</a>
                        </div>
                    </div>

                </div>
                <!--body end-->

            </div>
        </div>
    </div>
    <script src="../../../js/plugins/zoomify/zoomify.min.js"></script>
    <script src="../company/js/webuploader.js"></script>
    <link href="../../../js/plugins/webuploader/webuploader.css" rel="stylesheet" />
    <script src="../../../js/plugins/layer/layer.js"></script>

    <script>
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
                swf: '/js/plugins/webuploader/Uploader.swf',

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
              
                compress:false,
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
        $("#pay_pay_btn").click(function () {
            var tempstring = $(".certify-img").attr("src");

            if ((typeof (tempstring) != "undefined")&&tempstring!="") {
                window.location.href = "End_Recharge.aspx";
                // 存在
            }
            else {
                layer.msg('请先提交支付订单收据', { icon: 2 });
            }
        });
    </script>

</body>
</html>
