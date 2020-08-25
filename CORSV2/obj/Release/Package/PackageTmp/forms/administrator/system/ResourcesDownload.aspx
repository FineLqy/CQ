<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResourcesDownload.aspx.cs" Inherits="CORSV2.forms.administrator.system.ResourcesDownload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>资源下载管理</title>
    <link rel="shortcut icon" href="../../favicon.ico" />

    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" type="text/css" rel="stylesheet" />
    <link href="../../../themes/css/bootstrap-editable.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/News.css" rel="stylesheet" />
    <link href="../../../themes/css/animate.css" rel="stylesheet" />
    <link href="../../../themes/css/style.wyy.1.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/webuploader/webuploader.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/sweetalert/sweetalert.css" rel="stylesheet" />
    <style>
        /*body {
            padding: 30px;
        }*/
    </style>
</head>
<body class="gray-bg" style="background-image:none">
    <div class="modal inmodal" id="addModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="panel panel-default" style="width: 400px;">
                <div class="panel-heading">
                    <h3 style="text-align: center;">添加资源文件
                        <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">×</span><span class="sr-only">关闭</span>
                        </button>
                    </h3>
                </div>
                <div class="panel-body">
                    <form method="post">
                        <input type="text" class="form-control" name="resource" id="resource_name" placeholder="文件名" />
                        <div class="form-group" style="margin-top: 20px;">
                            <input type="text" class="form-control" style="width: 70%; float: right;" id="filename" readonly="true" />
                            <div id="chooseFile" class="width: 30%;">选择文件</div>
                        </div>
                        <button class="btn btn-success btn-block" id="AddData">添加</button>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <div class="wrapper wrapper-content  animated fadeInRight" style="padding-top: 0px;">
        <div class="row" style="padding-left: 0px; padding-right: 0px;">
            <div class="col-sm-8" style="padding-left: 0px; padding-right: 0px; width: 100%;">
                <div class="ibox">
                <div class="ibox-content">
                    <div id="coortable">
                        <div class="bars pull-left">
                            <div class="btn-group hidden-xs" id="toolbar" role="group">
                                <button type="button" id="add" class="btn btn-outline btn-default" data-toggle="modal" data-target="#addModal">
                                    <i class="glyphicon glyphicon-plus" aria-hidden="true"></i>添加
                                </button>
     
                                <button type="button" id="delete" class="btn btn-outline btn-default">
                                    <i class="glyphicon glyphicon-trash" aria-hidden="true"></i>删除
                                </button>
                            </div>
                        </div>

                        <table
                            id="table"
                            data-toolbar="#toolbar"
                            data-search="true"
                            data-show-refresh="true"
                            data-show-toggle="true"
                            data-show-columns="true"
                            data-show-export="false"
                            data-detail-view="false"
                            data-striped="true"
                            data-minimum-count-columns="1"
                            data-pagination="true"
                            data-page-size="10"
                            data-id-field="ID"
                            data-unique-id="ID"
                            data-page-list="[10, 25, 50, 100]"
                            data-show-footer="false"
                            data-side-pagination="client"
                            data-url="?action=GetData"
                            data-smart-display="false">
                        </table>
                    </div>
                    </div>
                </div>
            </div>






        </div>
    </div>

    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=7bGCq1WUPVv5H4LDIpH7u12v"></script>
    <script src="../../../js/jquery.min.js"></script>
    <script src="../../../js/plugins/webuploader/webuploader.js"></script>
    <script src="../../../js/bootstrap.min.js"></script>
    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/bootstrap-editable.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/extensions/editable/bootstrap-table-editable.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script src="../../../js/plugins/sweetalert/sweetalert.min.js"></script>
    <script>
        var table = $("#table");
        $(document).ready(function () { initialTable(); });
        function initialTable() {
            table.bootstrapTable({
                columns: [
                    {
                        field: 'state',
                        radio: true,
                    },
                    {
                        field: 'ID',
                        title: 'ID',
                    }, {
                        field: 'ResourceName',
                        title: '文件名',
                        editable: {
                            type: 'text',
                            title: '文件名',
                            validate: function (v) {
                                if (!v) return '文件名不能为空！';
                            }
                        }
                    }, {
                        field: 'UploadUser',
                        title: '上传用户',
                    }, {
                        field: 'Remark',
                        title: '备注',
                    }],
                onEditableSave: function (field, row, oldValue, $el) {
                    $.ajax({
                        type: "post",
                        url: "?action=Update",
                        data: row,
                        dataType: 'JSON',
                        success: function (data, status) {
                            if (data == "0") {
                                alert('更新成功');
                            }
                            else {
                                alert("格式错误");
                            }
                        },
                        error: function () {
                            alert('编辑失败');
                        },
                        complete: function () {

                        }

                    });
                }
            });
        }
        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID
            });
        }


        $('#addModal').on('shown.bs.modal', function (e) {
            /*上传文件控件*/
            var state = 'pending';
            var uploader = WebUploader.create({
                // swf文件路径
                swf: window.location.origin + '/js/plugins/webuploader/Uploader.swf',
                // 文件接收服务端。
                server: '?action=AddData',
                formData: {
                    "resource": $("#resource_name").val(),
                },
                // 选择文件的按钮。可选。
                // 内部根据当前运行是创建，可能是input元素，也可能是flash.
                pick: '#chooseFile',
            });

            //当文件添加进来时候的事件
            uploader.on('fileQueued', function (file) {
                $("#filename").val(file.name);
            });

            uploader.on('uploadSuccess', function (file, response) {
                if (response == "-1") {
                    alert("服务器错误：文件保存失败！");
                    location.reload();
                }
                else if (response == "1") {
                    alert("成功添加资源！");
                    location.reload();
                }
                else if (response == "-3") {
                    alert("已存在该文件名！");
                    location.reload();
                }
                else {
                    alert("文件格式错误！");
                    location.reload();
                }
            });

            uploader.on('uploadError', function (file, reason) {
                alert("文件名和文件不能为空");
            });

            uploader.on('all', function (type) {
                if (type === 'startUpload') {
                    state = 'uploading';
                } else if (type === 'stopUpload') {
                    state = 'paused';
                } else if (type === 'uploadFinished') {
                    state = 'done';
                }

                //if (state === 'uploading') {
                //    $btn.text('暂停上传');
                //} else {
                //    $btn.text('开始上传');
                //}
            });

            $("#AddData").on('click', function (e) {
                e.preventDefault();

                uploader.options.formData.resource = $("#resource_name").val();

                if (state === 'uploading') {
                    uploader.stop();
                } else {
                    uploader.upload();
                }
            });
        })


        $("#delete").click(function () {

            swal({
                title: "您确定要删除这条信息吗",
                text: "删除后将无法恢复，请谨慎操作！",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "删除",
                cancelButtonText: "取消",
                closeOnConfirm: false
            }, function (isConfirm) {
                if (isConfirm) {
                    var ids = getIdSelections();
                    table.bootstrapTable('remove', {
                        field: 'ID',
                        values: ids
                    });
                    $.ajax({
                        url: "?action=Delete",
                        type: "post",
                        data: {
                            id: ids,
                        },
                        success: function () { }
                    });
                    $("#delete").blur();
                    swal("删除成功！", "您已经永久删除了这条信息。", "success")
                }
                else { swal("已取消", "您取消了删除操作！", "error"); return; }
            });


        });
        //$("#download").click(function () {
        //    window.location.href = "?action=Download&id=" + getIdSelections()[0];
        //    $("#download").blur();
        //});
    </script>
</body>
</html>
