<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkingAreaManage.aspx.cs" Inherits="CORSV2.forms.administrator.system.WorkingAreaManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>作业区域管理</title>
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
</head>
<body class="gray-bg" style="background-image:none">
    <div class="modal inmodal" id="addModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="panel panel-default" style="width: 400px;">
                <div class="panel-heading">
                    <h3 style="text-align: center;">添加作业区域
                        <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">×</span><span class="sr-only">关闭</span>
                        </button>
                    </h3>
                </div>
                <div class="panel-body">
                    <form method="post">
                        <input type="text" class="form-control" name="area" id="areaname" placeholder="作业区域名称" />
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

    <div class="modal inmodal" id="viewModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog" style="width: 70%; height: 700px;">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 style="text-align: center;">作业区域查看
                        <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">×</span><span class="sr-only">关闭</span>
                        </button>
                    </h3>
                </div>
                <div class="panel-body" id="viewDialog" style="width: 100%; height: 700px;">
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

                                    <button type="button" id="download" class="btn btn-outline btn-default">
                                        <i class="glyphicon glyphicon-download-alt" aria-hidden="true"></i>下载
                                    </button>
                                    <button type="button" id="view" class="btn btn-outline btn-default">
                                        <i class="glyphicon glyphicon-eye-open" aria-hidden="true"></i>查看
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
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/bootstrap-editable.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/extensions/editable/bootstrap-table-editable.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script src="../../../js/plugins/sweetalert/sweetalert.min.js"></script>
    <script>
        var table = $("#table");
        $(document).ready(function () { initialTable(); $('#viewModal').modal('hide'); });
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
                        field: 'AreaName',
                        title: '名称',
                        editable: {
                            type: 'text',
                            title: '区域名称',
                            validate: function (v) {
                                if (!v) return '区域名不能为空！';
                            }
                        }
                    }, {
                        field: 'AreaString',
                        title: '区域',
                        editable: {
                            type: 'text',
                            title: '区域坐标',
                            validate: function (v) {
                                if (!v) return '区域坐标不能为空！';
                                var ss = new Array();
                                ss = v.split(',');
                                for (var i = 0; i < ss.length; i++) {
                                    if (isNaN(ss[i])) return '格式错误！';
                                }
                            }
                        }
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
                    "area": $("#areaname").val(),
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
                if (response["_raw"] == "-1") {
                    alert("文件保存错误！");
                    location.reload();
                }
                else if (response["_raw"] == "0") {
                    alert("成功添加！");
                    location.reload();
                }
                else if (response == "-2") {
                    alert("区域名称重复！");
                    location.reload();
                }
                else {
                    alert("文件格式错误！");
                    location.reload();
                }
            });

            uploader.on('uploadError', function (file, reason) {
                alert("作业区域名称和文件不能为空");
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

                uploader.options.formData.area = $("#areaname").val();

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
        $("#download").click(function () {
            var ids = getIdSelections();
            if (ids.length < 1) {
                alert("未选中任何区域！");
                return;
            }
            else {
                window.location.href = "?action=Download&id=" + getIdSelections()[0];
                $("#download").blur();
            }

        });

        $("#view").click(function (e) {
            e.preventDefault();
            var ids = getIdSelections();
            if (ids.length < 1) {

                alert("未选中任何区域！");
                $('#viewModal').modal('hide'); $('#view').blur();
                return;
            }
            else {
                $('#viewModal').modal('show'); $('#view').blur();
                GetMap();
            }

        });

        var data; var map;
        function GetMap() {
            map = new BMap.Map("viewDialog");
            var point = new BMap.Point(106.55544, 29.569992);
            var areaString = table.bootstrapTable('getRowByUniqueId', getIdSelections()[0])["AreaString"];
            map.centerAndZoom("重庆", 11);
            map.enableScrollWheelZoom();                  // 启用滚轮放大缩小。
            map.addControl(new BMap.MapTypeControl({ mapTypes: [BMAP_NORMAL_MAP, BMAP_HYBRID_MAP] }));     //2Dͼ£¬πчͼ
            map.addControl(new BMap.MapTypeControl({ anchor: BMAP_ANCHOR_TOP_LEFT }));    //سʏ½ǣ¬Ĭɏµٍ¼¿ؼ�.addControl(new BMap.ScaleControl());           
            map.addControl(new BMap.NavigationControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT, type: BMAP_NAVIGATION_CONTROL_ZOOM }));  //ԒЂ½ǣ¬½�¬̵·Ű´ť
            map.addControl(new BMap.OverviewMapControl({ isOpen: true, anchor: BMAP_ANCHOR_TOP_RIGHT }));   //Ԓʏ½ǣ¬´򿨍
            $.post(
              "../../functions/GetWorkingArea.ashx",
              {
                  q: "get",
                  "AreaString": areaString
              },
              function (data) //回传函数
              {

                  var Iindex = 0;
                  var datas = data.split("<");
                  var datass = datas[0].split(",");
                  function addMarker(point, index) {
                      //             var myIcon = new BMap.Icon("http://api.map.baidu.com/img/markers.png", new BMap.Size(23, 25), {
                      //           offset: new BMap.Size(10, 25),                  // 指定定位位置
                      //                 imageOffset: new BMap.Size(0, 0 - index * 25)   // 设置图片偏移
                      //               });
                      //var marker = new BMap.Marker(point, {icon: myIcon});
                      var marker = new BMap.Marker(point);
                      map.addOverlay(marker);
                      var label = new BMap.Label(index + 1, { offset: new BMap.Size(20, -10) });
                      marker.setLabel(label);
                  }
                  var allpoints = new Array();
                  // 向地图添加标注
                  for (var i = 0; i < datass.length / 2; i++) {
                      var point = new BMap.Point(datass[2 * i], datass[2 * i + 1]);
                      allpoints.push(point);
                      addMarker(point, i);
                  }

                  var oval = new BMap.Polygon(allpoints, { strokeColor: "blue", strokeWeight: 6, strokeOpacity: 0.3, fillOpacity: 0.2 });
                  oval.setFillOpacity(0.1);
                  //setStrokeWeight(weight:Number)  none  设置多边形边线的宽度，取值为大于等于1的整数。  
                  //setFillOpacity(opacity:Number)  none  设置多边形的填充透明度，取值范围0 - 1。  
                  //setStrokeOpacity(opacity:Number)  none  设置多边形的边线透明度，取值范围0 - 1。  
                  //setStrokeColor(color:String)  none  设置多边型的边线颜色，参数为合法的CSS颜色值。  
                  map.addOverlay(oval);
              }
            );
        }
    </script>
</body>
</html>
