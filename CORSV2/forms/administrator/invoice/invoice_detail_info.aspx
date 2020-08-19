<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="invoice_detail_info.aspx.cs" Inherits="CORSV2.forms.administrator.invoice.invoice_detail_info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

        <script src="../../../js/jquery-1.10.2.min.js"></script>
        <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet" />
        <link href="../../../themes/css/font-awesome.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css" rel="stylesheet" />
    <link href="../../../themes/css/bootstrap.min.3.2.0.css" rel="stylesheet" />

</head>
<body>
    <div class="container">
<%--        <div class="page-header">
            <h1>申请发票信息 <small></small></h1>
        </div>--%>
        <div class="pager">



            <div class="row">
                <div class="col-md-6">
                    <div class="input-group">
                        <span class="input-group-addon" id="">发票抬头</span>
                        <input id="invoiceHead"  runat="server" type="text" class="form-control" placeholder="" aria-describedby="basic-addon1" readonly="readonly" />
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="input-group">
                        <span class="input-group-addon" id="">发票税号</span>
                        <input id="taxNum" runat="server" type="text" class="form-control" placeholder="" aria-describedby="basic-addon1" readonly="readonly" />
                    </div>

                </div>
            </div>
            <div class="clearfix" style="margin-bottom: 20px;"></div>
            <div class="row" id="invoice" runat="server">
                <div class="col-md-12">
                    <!--用来存放item-->
                    <div id="invoice_path_file" class="uploader-list">
                        <img id="invoiceFile" class="certify-img" src="" runat="server" />
                    </div>
                    <div class="filePicker" id="invoice_path" style="float: left;">上传发票电子版图片</div>


                </div>
                <!--用来存放item-->
            </div>
            <div class="row" id="contract" runat="server">
                <div class="col-md-12">
                    <!--用来存放item-->
                    <div id="contract_path_file" class="uploader-list">
                        <img id="contractFile" class="certify-img" src="" runat="server" />
                    </div>
                    <div class="filePicker" id="contract_path" style="float: left;">上传合同电子版图片</div>


                </div>
                <!--用来存放item-->
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div style="float: left;">
                        <i class="errorTips errorZuzhi" hidden="true" style="display: none;">
                            <span class="fa fa-warning"></span><em></em>
                        </i>

                        <i class="tipsFile">*图片大小不要超过5M，支持PNG，JPG格式</i>
                    </div>

                </div>
            </div>
            <div class="clearfix" style="margin-bottom: 20px;"></div>
            <div class="row" id="submitInvoiceFile" runat="server">
                <div class="col-md-12">
                    <button class="btn  btn-success form-control" id="uploadInvoiceFile" onclick="uploadFile()">
                        <span>提交发票电子版图片</span>
                    </button>
                </div>
            </div>
                        <div class="row" id="submitContractFile" runat="server">
                <div class="col-md-12">
                    <button class="btn  btn-success form-control" id="uploadContractFile" onclick="uploadContractFile()">
                        <span>提交合同电子版图片</span>
                    </button>
                </div>
            </div>


        </div>

    </div>

    <script src="../../../js/geo.js"></script>
    <script src="../../../js/plugins/layer/layer.js"></script>
    <script src="../../../js/plugins/zoomify/zoomify.min.js"></script>
    <script src="../../user/company/js/webuploader.js"></script>
    <link href="../../../js/plugins/webuploader/webuploader.css" rel="stylesheet" />
    <script>
        var thumbnailWidth = 1000;
        var thumbnailHeight = 500;
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
                server: '/forms/administrator/invoice/invoice_detail_info.aspx?action=AddData',

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
        //注意：parent 是 JS 自带的全局对象，可用于操作父页面
        var index = parent.layer.getFrameIndex(window.name); //获取窗口索引
        function uploadFile() {
            var symbol = false;
            $(".certify-img").each(function () {
                var tempstring = $(this).attr("src");
                if ((typeof (tempstring) != "undefined") && tempstring != "") {
                    symbol = true;
                }
            });
            if (symbol) {
                $.post("/forms/administrator/invoice/invoice_detail_info.aspx?action=OK", function (result) {
                    if (result == "1") {
                        layer.msg('保存成功，即将回到发票栏', {
                            time: 1000
                        }, function () {
                            //window.parent.location.reload();//刷新父页面
                            location.reload();
                            window.location.href = "/forms/administrator/invoice/manage_invoice.aspx?action=random_number";
                            parent.layer.close(index);
                        });
                    } else {
                        layer.alert("提交出错");
                        $('.uploadFile').removeAttr("disabled");
                    }

                })
            }
            else {
                layer.msg('请先上传文件', { icon: 2 });

            }


        }

        //function uploadContractFile() {
        //    // var tempstring = $(".certify-img").attr("src");
        //    var symbol = false;
        //    $(".certify-img").each(function () {
        //        var tempstring = $(this).attr("src");
        //        if ((typeof (tempstring) != "undefined")&&tempstring!="") {
        //            symbol = true;
        //        }
        //    });
        //    if (symbol) {
        //        $.post("/forms/administrator/invoice/invoice_detail_info.aspx?action=OK", function (result) {
        //            if (result == "1") {
        //                layer.msg('保存成功，即将回到合同栏', {
        //                    time: 1000
        //                }, function () {
        //                    //window.parent.location.reload();//刷新父页面
        //                    location.reload();
        //                    window.location.href = "/forms/administrator/contract/manage_contract.aspx?action=random_number";
        //                    parent.layer.close(index);
        //                });
        //            } else {
        //                layer.alert("提交出错");
        //                $('.uploadFile').removeAttr("disabled");
        //            }

        //        })
        //    }
        //    else {
        //        layer.msg('请先上传文件', { icon: 2 });
        //    }
        //}
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




</body>
</html>
