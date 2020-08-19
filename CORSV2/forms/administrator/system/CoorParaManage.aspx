<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoorParaManage.aspx.cs" Inherits="CORSV2.forms.administrator.system.CoorParaManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>坐标参数管理</title>
    <link rel="shortcut icon" href="../../favicon.ico" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
    <link href="../../../../themes/css/bootstrap.min.css?v=3.3.6" type="text/css" rel="stylesheet" />
    <link href="../../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../../themes/css/News.css" rel="stylesheet" />
    <link href="../../../themes/css/animate.css" rel="stylesheet" />
    <link href="../../../../../themes/css/style.wyy.1.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/sweetalert/sweetalert.css" rel="stylesheet" />
</head>
<body class="gray-bg" >
    <div class="wrapper wrapper-content  animated fadeInRight" style="padding-top:0px;">
        <div class="row" style="padding-left:0px;padding-right:0px;">
            <div class="col-sm-8" style="padding-left:0px;padding-right:0px;width: 100%;" >
        <div class="ibox float-e-margins">
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    <h5>坐标参数列表</h5>
                </div>

                <div class="ibox-content">
                    <div id="coortable">
                        <div class="bars pull-left">
                            <div class="btn-group hidden-xs" id="toolbar" role="group">
                                <button type="button" id="delete" class="btn btn-outline btn-default">
                                    <i class="glyphicon glyphicon-trash" aria-hidden="true"></i>删除
                                </button>
                                <button type="button" id="add" class="btn btn-outline btn-default">
                                    <i class="glyphicon glyphicon-plus" aria-hidden="true"></i>添加
                                </button>
                            </div>
                        </div>

                        <table
                            id="table"
                            data-toolbar="#toolbar"
                            data-show-refresh="true"
                            data-show-toggle="true"
                            data-show-columns="true"
                            data-show-export="false"
                            data-detail-view="false"
                            data-striped="true"
                            data-minimum-count-columns="1"
                            data-show-pagination-switch="false"
                            data-pagination="true"
                            data-page-size="10"
                            data-id-field="ID"
                            data-unique-id="ID"
                            data-page-list="[10, 25, 50, 100]"
                            data-show-footer="false"
                            data-side-pagination="server"
                            data-url="CoorParaManage.aspx?action=GetData"
                            data-smart-display="false">
                        </table>
                    </div>

                </div>
            </div>
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    坐标参数详情
                </div>
                <div class="ibox-content">

                    <form method="post" id="modifyform" class="form-horizontal">
                        <div class="form-group">
                            <input type="hidden" name="ID">
                            <label class="col-sm-2 control-label">原始坐标系名</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="YSZBXM" readonly="true" value="WGS84">
                            </div>
                            <label class="col-sm-2 control-label">原始坐标系备注名</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="YSRemarkName">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">原始坐标系长轴参数(m)</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="YSMajorAxis" readonly="true" value="6378137">
                            </div>
                            <label class="col-sm-2 control-label">原始坐标系扁率倒数</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="YSDAlpha" readonly="true" value="298.257223563">
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">目的坐标系名</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="MDZBXM">
                            </div>
                            <label class="col-sm-2 control-label">目的坐标系备注名</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="MDRemarkName">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">目的坐标系长轴参数(m)</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="MDMajorAxis">
                            </div>
                            <label class="col-sm-2 control-label">目的坐标系扁率倒数</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="MDDAlpha">
                            </div>
                        </div>
                       
                        <div class="form-group">
                            <label class="col-sm-2 control-label">平移参数X(m)</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="X">
                            </div>
                            <label class="col-sm-2 control-label">X轴旋转参数(秒)</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="aa">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">平移参数Y(m)</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="Y">
                            </div>
                            <label class="col-sm-2 control-label">Y轴旋转参数(秒)</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="bb">
                            </div>

                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">平移参数Z(m)</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="Z">
                            </div>
                            <label class="col-sm-2 control-label">Z轴旋转参数(秒)</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="cc">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">尺度因子(ppm)</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="m">
                            </div>
                            <label class="col-sm-2 control-label">作业区域</label>
                            <div class="col-sm-3">
                                <select class="form-control WorkArea" name="WorkArea" id="WorkArea">
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">中央子午线(度分秒)</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="CMeridian">
                            </div>
                            <label class="col-sm-2 control-label">投影抬高(m)</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="ProjElevation">
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">原点北(m)</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="OriginNorth">
                            </div>
                            <label class="col-sm-2 control-label">原点东(m)</label>
                            <div class="col-sm-3">
                                <input type="text" class="form-control" name="OriginEast">
                            </div>
                        </div>

                        <div class="form-group">
                            <button id="modify" class="btn btn-primary btn-lg col-sm-offset-3">修改</button>
                            <button  id="updatepara" class="btn btn-primary btn-lg col-sm-offset-5">保存</button>
                        </div>
                    </form>

                </div>
            </div>


        </div>
    </div>
</div>
        </div>
    <script src="../../../../js/jquery.min.js"></script>
    <script src="../../../../js/bootstrap.min.js"></script>
    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="../../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script src="../../../js/plugins/sweetalert/sweetalert.min.js"></script>
    <script>
        var table = $("#table");
        function initialTable() {
            table.bootstrapTable({
                columns: [
                    {
                        field: 'state',
                        checkbox: true,
                    },
                    {
                        field: 'ID',
                        title: 'ID'
                    }, {
                        field: 'YSZBXM',
                        title: '原始坐标系名'
                    }, {
                        field: 'MDZBXM',
                        title: '目的坐标系名'
                    }, {
                        field: 'X',
                        title: '平移参数X(m)'
                    }, {
                        field: 'Y',
                        title: '平移参数Y(m)'
                    }, {
                        field: 'Z',
                        title: '平移参数Z(m)'
                    }, {
                        field: 'aa',
                        title: 'X轴旋转参数(秒)'
                    }, {
                        field: 'bb',
                        title: 'Y轴旋转参数(秒)'
                    }, {
                        field: 'cc',
                        title: 'Z轴旋转参数(秒)'
                    }, {
                        field: 'm',
                        title: '尺度因子(ppm)'
                    }, {
                        field: 'YSMajorAxis',
                        title: '原始坐标系椭球长轴参数(m)'
                    }, {
                        field: 'YSe2',
                        title: '原始坐标系椭球参数偏心率平方'
                    }, {
                        field: 'MDMajorAxis',
                        title: '目的坐标系椭球长轴参数(m)'
                    }, {
                        field: 'MDe2',
                        title: '目的坐标系椭球偏心率的平方'
                    }, {
                        field: 'YSRemarkName',
                        title: '原始坐标系备注名'
                    }, {
                        field: 'MDRemarkName',
                        title: '目的坐标系备注名'
                    }, {
                        field: 'YSDAlpha',
                        title: '原始坐标系椭球扁率倒数'
                    }, {
                        field: 'MDDAlpha',
                        title: '目的坐标系椭球扁率倒数'
                    }, {
                        field: 'CMeridian',
                        title: '中央子午线(度分秒)'
                    },
                    {
                        field: 'ProjElevation',
                        title: '投影抬高（m）'
                    }, {
                        field: 'OriginNorth',
                        title: '原点北（m）'
                    }, {
                        field: 'OriginEast',
                        title: '原点东（m）'
                    }, {
                        field: 'AreaID',
                        title: '作业区域ID'
                    }],
            });
        }

        /*一下两个函数功能一样，前者是添加坐标参数窗口的函数，后者是修改参数的窗口*/
        function GetParentWorkingArea() {
            $(".WorkArea", window.parent.document).empty();
            $.getJSON("CoorParaManage.aspx?action=GetWorkingArea", function (data) {
                $.each(data, function (i, item) {
                    if (item["ID"] == "0") {
                        $(".WorkArea", window.parent.document).append($("<option></option>")
                    .attr("value", item["ID"])
                            .attr("selected","true")
                    .text(item["AreaName"]));
                    }
                    else
                    $(".WorkArea", window.parent.document).append($("<option></option>")
                    .attr("value", item["ID"])
                    .text(item["AreaName"]));
                });
            });

        }
        function GetWorkingArea() {
            $(".WorkArea").empty();
            $.getJSON("CoorParaManage.aspx?action=GetWorkingArea", function (data) {
                $.each(data, function (i, item) {
                    if (item["ID"] == "0") {
                        $(".WorkArea").append($("<option></option>")
                    .attr("value", item["ID"])
                            .attr("selected", "true")
                    .text(item["AreaName"]));
                    }
                    else
                        $(".WorkArea").append($("<option></option>")
                        .attr("value", item["ID"])
                        .text(item["AreaName"]));
                });
            });

        }

        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID
            });
        }

        table.on('click-row.bs.table', function (e, row, $element, field) {
            //if (row['YSZBXM'] != "GD") {//过渡坐标系
                $('#modifyform').find('[name]').each(function () {
                    var type = $(this)[0].nodeName.toLowerCase();
                    var name = $(this).attr('name');
                    $("#modifyform " + type + "[name='" + name + "']").val(row['' + name + '']);
                });
                if(row["YSZBXM"] !="GD")
                $('#modifyform input:not([name^="YS"]):not([name^="MD"]):not([name="ID"])').val("");
                $("#modifyform .WorkArea").val(row["AreaID"]);
                $("#modifyform input,#modifyform select").attr("readonly", "readonly");
            //}
            //else {
            //    $.getJSON("?action=GetGD", function (data) {
            //        $('#modifyform').find('[name]').each(function () {
            //            var type = $(this)[0].nodeName.toLowerCase();
            //            var name = $(this).attr('name');
            //            $("#modifyform " + type + "[name='" + name + "']").val(data['' + name + '']);
            //        });
            //        $("#modifyform .WorkArea").val(data["AreaID"]);
            //        $("#modifyform input,#modifyform select").attr("readonly", "readonly");
            //    });
            //}
        });
        //CURD
        $("#add").click(function () {
            parent.layer.open({
                title: '添加坐标参数',
                type: 1,
                maxmin: true,
                //skin: 'layui-layer-rim', //加上边框
                area: ['1000px', '800px'], //宽高
                content: '<br/><br/><form method="post" id="addparaform" style="width:98%;" class="form-horizontal"><div class="form-group"><label class="col-sm-2 control-label">原始坐标系名</label><div class="col-sm-3"><input type="text" class="form-control" name="YSZBXM" readonly="true"  value="WGS84"></div><label class="col-sm-2 control-label">原始坐标系备注名</label><div class="col-sm-3"><input type="text" class="form-control" name="YSRemarkName"></div></div><div class="form-group"><label class="col-sm-2 control-label">目的坐标系名</label><div class="col-sm-3"><input type="text" class="form-control" name="MDZBXM"></div><label class="col-sm-2 control-label">目的坐标系备注名</label><div class="col-sm-3"><input type="text" class="form-control" name="MDRemarkName"></div></div><div class="form-group"><label class="col-sm-2 control-label">平移参数X(m)</label><div class="col-sm-9"><input type="text" class="form-control" name="X"></div></div><div class="form-group"><label class="col-sm-2 control-label">平移参数Y(m)</label><div class="col-sm-9"><input type="text" class="form-control" name="Y"></div></div><div class="form-group"><label class="col-sm-2 control-label">平移参数Z(m)</label><div class="col-sm-9"><input type="text" class="form-control" name="Z"></div></div><div class="form-group"><label class="col-sm-2 control-label">X轴旋转参数(秒)</label><div class="col-sm-9"><input type="text" class="form-control" name="aa"></div></div><div class="form-group"><label class="col-sm-2 control-label">Y轴旋转参数(秒)</label><div class="col-sm-9"><input type="text" class="form-control" name="bb"></div></div><div class="form-group"><label class="col-sm-2 control-label">Z轴旋转参数(秒)</label><div class="col-sm-9"><input type="text" class="form-control" name="cc"></div></div><div class="form-group"><label class="col-sm-2 control-label">尺度因子(ppm)</label><div class="col-sm-9"><input type="text" class="form-control" name="m"></div></div><div class="form-group"><label class="col-sm-2 control-label">目的坐标椭球</label><div class="col-sm-9"><select class="form-control" name="DesEllip" id="desellipse"><option value="84">WGS84</option><option value="80">西安80</option><option value="54">北京54</option><option value="0">自定义</option></select></div></div><div class="form-group ellipsePara"><label class="col-sm-2 control-label">目的系椭球长轴(m)</label><div class="col-sm-9"><input type="text" class="form-control" name="MDMajorAxis" value="6378137" readonly="true"></div></div><div class="form-group ellipsePara"><label class="col-sm-2 control-label">目的系椭球扁率倒数</label><div class="col-sm-9"><input type="text" class="form-control" name="MDDAlpha" value="298.257223563" readonly="true"></div></div><div class="form-group"><label class="col-sm-2 control-label">中央子午线(度分秒)</label><div class="col-sm-9"><input type="text" class="form-control" name="CMeridian"></div></div><div class="form-group"><label class="col-sm-2 control-label">投影抬高(m)</label><div class="col-sm-9"><input type="text" class="form-control" name="ProjElevation"></div></div><div class="form-group"><label class="col-sm-2 control-label">原点北(m)</label><div class="col-sm-9"><input type="text" class="form-control" name="OriginNorth"></div></div><div class="form-group"><label class="col-sm-2 control-label">原点东(m)</label><div class="col-sm-9"><input type="text" class="form-control" name="OriginEast"></div></div><div class="form-group"><label class="col-sm-2 control-label">作业区域限定</label><div class="col-sm-9"><select class="form-control WorkArea" name="WorkArea"><option value="1">南宁</option><option value="2">哈萨克</option><option value="3">火星</option></select></div></div><div class="form-group"><label class="col-sm-2 control-label">参数加密</label><div class="col-sm-9"><select class="form-control" name="md" id="md"><option value="1">是</option><option value="0">否</option></select></div></div><div class="form-group"><button type="submit" id="addpara" class="btn btn-primary btn-lg col-sm-offset-5">添加</button></div></form>',
                success: function () {
                    GetParentWorkingArea();
                }
            });
            $("#add").blur();

        });

        $("#delete").click(function () {
            var ids = getIdSelections();
            var MDZBXMs = new Array();
            for (var i = 0; i < ids.length ; i++) {
                var rowId = ids[i];
                var rowdata = table.bootstrapTable('getRowByUniqueId', rowId);
                MDZBXMs[i] = rowdata.MDZBXM;
                if (rowdata.YSZBXM == "GD") {
                    swal({
                        title: "失败",
                        text: "无法删除原始坐标系名为GD的记录！"
                    });
                    return;
                }
                
            }

            swal({
                title: "您确定要删除这条信息吗",
                text: "删除后将无法恢复，请谨慎操作！",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "删除",
                cancelButtonText:"取消",
                closeOnConfirm: false
            }, function (isConfirm) {
                if (isConfirm) {
                    table.bootstrapTable('remove', {
                        field: 'MDZBXM',
                        values: MDZBXMs
                    });
                    $.ajax({
                        url: "CoorParaManage.aspx",
                        type: "post",
                        data: {
                            action: "Delete",
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

        $(window.parent.document).on('click', '#addpara', function (e) {
            e.preventDefault();
            $.ajax({
                url: 'CoorParaManage.aspx?action=AddPara',
                type: 'post',
                data: $('#addparaform',window.parent.document).serialize(),
                success: function (data) {
                    alert(data);
                    window.parent.layer.close();
                    window.location.reload();
                }
            });
        });

        $(document).on('click', '#updatepara', function (e) {
            e.preventDefault();
            $.ajax({
                url: 'CoorParaManage.aspx?action=UpdateData',
                type: 'post',
                data: $('#modifyform').serialize(),
                success: function (data) {
                    if(data == "0")
                        alert("请将参数填写完整！");
                    else if(data == "1"){
                        alert("参数验证未通过");
                    }
                    else {
                        alert("成功修改参数");
                        location.reload();
                    }
                }
            });
        });

        function showoption() {
            if ($("#desellipse",window.parent.document).val() == "0")//自定义椭球
            {
                $(".ellipsePara input[name='MDMajorAxis']", window.parent.document).val("");
                $(".ellipsePara input[name='MDMajorAxis']", window.parent.document).removeAttr("readonly");
                $(".ellipsePara input[name='MDDAlpha']", window.parent.document).val("");
                $(".ellipsePara input[name='MDDAlpha']", window.parent.document).removeAttr("readonly");
            }
            else if ($("#desellipse", window.parent.document).val() == "54")//54坐标系
            {
                $(".ellipsePara input[name='MDMajorAxis']", window.parent.document).attr("readonly", "true");
                $(".ellipsePara input[name='MDDAlpha']", window.parent.document).attr("readonly", "true");
                $(".ellipsePara input[name='MDMajorAxis']", window.parent.document).val("6378245");
                $(".ellipsePara input[name='MDDAlpha']", window.parent.document).val("298.3");
            }
            else if ($("#desellipse", window.parent.document).val() == "80")//80坐标系
            {
                $(".ellipsePara input[name='MDMajorAxis']", window.parent.document).attr("readonly", "true");
                $(".ellipsePara input[name='MDDAlpha']", window.parent.document).attr("readonly", "true");
                $(".ellipsePara input[name='MDMajorAxis']", window.parent.document).val("6378140");
                $(".ellipsePara input[name='MDDAlpha']", window.parent.document).val("298.257");
            }
            else if ($("#desellipse", window.parent.document).val() == "84")//84坐标系
            {
                $(".ellipsePara input[name='MDMajorAxis']", window.parent.document).attr("readonly", "true");
                $(".ellipsePara input[name='MDDAlpha']", window.parent.document).attr("readonly", "true");
                $(".ellipsePara input[name='MDMajorAxis']", window.parent.document).val("6378137");
                $(".ellipsePara input[name='MDDAlpha']", window.parent.document).val("298.257223563");
            }
            else {
                alert("WARNING! YOU R DOING STH THAT CAN LEAD ERROR TO THE SYSTEM!");
            }
        };

        $(window.parent.document).on('change','#desellipse',showoption);

        $(document).ready(function () {

            //Modify ellipse para is forbidden
            $("#modifyform input,#modifyform select").attr("readonly", "true");

            //click modify and then allow modify the para
            $("#modify").on('click', function (e) {
                e.preventDefault();
                if ($("#modifyform input[name='YSZBXM']").val() == "GD") {
                    alert("禁止修改过渡坐标");
                    return;
                }
                $("#modifyform input,#modifyform select").removeAttr("readonly");
                $('#modifyform input[name^="YS"]').attr("readonly","true");
            });
            initialTable();
            GetWorkingArea();
        });
    </script>
</body>
</html>
