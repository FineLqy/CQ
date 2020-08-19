<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlPointManage.aspx.cs" Inherits="CORSV2.forms.administrator.system.ControlPointManage" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>控制点信息管理</title>
    <link href="../../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
    <link href="../../../themes/css/plugins/iCheck/custom.css" rel="stylesheet">
    <link href="../../../themes/css/plugins/fullcalendar/fullcalendar.css" rel="stylesheet">
    <link href="../../../themes/css/plugins/fullcalendar/fullcalendar.print.css" rel="stylesheet">
</head>

<body class="gray-bg">
    <form runat="server">
        <div class="wrapper wrapper-content">
            <div class="row">
                <div class="col-sm-12">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>控制点分布图</h5>
                        </div>
                        <div class="ibox-content">
                            <div class="row">
                                <div id="mapDiv" style="height: 680px; width: 100%;"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>控制点信息</h5>

                        </div>
                        <div class="ibox-content">
                            <div class="row">
                                <div class="col-sm-9" style="width: 100%">
                                    <div class="flot-chart">

                                        <div class="bars pull-left">
                                            <div class="btn-group hidden-xs" id="toolbar" role="group">
                                                 <button type="button" id="add" class="btn btn-outline btn-default" >
                                                    <i class="glyphicon glyphicon-plus" aria-hidden="true"></i>添加
                                                </button>
                                                <button type="button" id="delete" class="btn btn-outline btn-default">
                                                    <i class="glyphicon glyphicon-trash" aria-hidden="true"></i>删除
                                                </button>
                                                 <button type="button" id="refresh" class="btn btn-outline btn-default">
                                                    <i class="glyphicon glyphicon-refresh" aria-hidden="true"></i>刷新
                                                </button>
                                                <button type="button" id="download" class="btn btn-outline btn-default">
                                                    <i class="glyphicon glyphicon-save" aria-hidden="true"></i>导出xls
                                                </button>
                                               <button id="addnew" style="display:none"></button>
                                            </div>
                                        </div>
                                      
                                            <table id="table"
                                                data-toolbar="#toolbar"
                                                data-search="true"
                                                data-show-refresh="true"
                                                data-show-toggle="true"
                                                data-show-columns="true"
                                                data-show-export="false"
                                                data-detail-view="false"
                                                data-striped="true"
                                                data-minimum-count-columns="1"
                                                data-show-pagination-switch="false"
                                                data-pagination="true"
                                                data-page-size="15"
                                                data-id-field="ID"
                                                data-unique-id="ID"
                                                data-page-list="[15,30,50]"
                                                data-show-footer="false"
                                                data-side-pagination="server"
                                                data-url="?action=GetData"
                                                data-smart-display="false">
                                            </table>
                                    
                                    </div>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="../../../js/jquery.min.js?v=2.1.4"></script>
    <script src="../../../js/bootstrap.min.js?v=3.3.6"></script>

    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script src="../../../js/plugins/layer/layer.min.js"></script>
       <script type="text/javascript" src="http://api.tianditu.gov.cn/api?v=3.0&tk=898f3541e6c196c9a634710017691f6d"></script>
    <script>
        function view(id) {
            layer.open({
                type: 2,
                title: '控制点信息设置',
                shadeClose: true,
                shade: false,
                maxmin: true, //开启最大化最小化按钮
                area: ['1150px', '650px'],
                content: 'ControlPointInfo.aspx?id=' + id
            });
        }
        var map;
        //初始化地图对象 
        map = new TMap("mapDiv");
        //设置显示地图的中心点和级别 
        map.centerAndZoom(new TLngLat(106.554865, 29.565468), 9);
        map.setZoomLevels([5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18])
        //允许鼠标滚轮缩放地图 
        map.enableHandleMouseScroll();
        var allmarker;
        function loadpoint() {
            var rearch = $(".search input").val();
            $.ajax({
                type: "GET",
                url: "?action=getpoint&&data="+rearch,

                success: function (result) {
                    var myobj = eval(result);
                    var marker = new Array();
                    var infoWins = new Array();
                    for (var i = 0; i < myobj.length; i++) {
                        var lnglat = new TLngLat(myobj[i].L, myobj[i].B);
                        var icon = new TIcon("../../../themes/icon/Crose.png", new TSize(14, 14), { anchor: new TPixel(7, 7) });
                        marker[i] = new TMarker(lnglat, { icon: icon });
                        map.addOverLay(marker[i]);
                        var config = {

                            text: myobj[i].MarkName,
                            offset: new TPixel(15, -30),
                            position: new TMarker(lnglat)
                        };
                        infoWins.push(new TInfoWindow(new TLngLat(myobj[i].L, myobj[i].B), new TPixel([0, 0])))
                        // infoWins[i].setLabel(myobj[i].code + "<br/> 经度:" + myobj[i].x, + "<br/>纬度:" + myobj[i].y);
                        infoWins[i].setLabel("点名：" + myobj[i].MarkName + "<br/>大地坐标等级：" + myobj[i].AccuracyClass + "<br/>高程坐标等级：" + myobj[i].GCgrade + "<br/>	保存完好性：" + myobj[i].BZ + "<br/> 点之记图片 <img src=\"../../../"+myobj[i].PointRemark+"\" style=\"width:30px;hright:30px \" />");
                        infoWins[i].closeInfoWindowWithMouse();

                    }

                    allmarker = marker;


                    for (var m = 0; m < myobj.length; m++) {
                        (function (m) {
                            TEvent.addListener(marker[m], "click", function () {

                                map.addOverLay(infoWins[m]);
                            });
                        })(m);
                    }


                }
            });
        }
        $("#add").click(function () {
            layer.open({
                type: 2,
                title: '添加控制点',
                shadeClose: true,
                shade: 0.8,
                //maxmin:true,
                area: ['40%', '90%'],
                content: 'AddPoint.aspx' //iframe的url
            });
        })

        $("#addnew").click(function () {
            $.ajax({
                type: "GET",
                url: "?action=getpoint",

                success: function (result) {
                    var myobj = eval(result);
                    var marker = new Array();
                    var infoWins = new Array();
                    var i = myobj.length - 1;
                    var lnglat = new TLngLat(myobj[i].B, myobj[i].L);
                    var icon = new TIcon("../../../themes/icon/Crose.png", new TSize(14, 14), { anchor: new TPixel(7, 7) });
                    marker[0] = new TMarker(lnglat, { icon: icon });
                    map.addOverLay(marker[0]);
                    var config = {

                        text: myobj[i].MarkName,
                        offset: new TPixel(15, -30),
                        position: new TMarker(lnglat)
                    };
                    infoWins.push(new TInfoWindow(new TLngLat(myobj[i].B, myobj[i].L), new TPixel([0, 0])))
                    // infoWins[i].setLabel(myobj[i].code + "<br/> 经度:" + myobj[i].x, + "<br/>纬度:" + myobj[i].y);
                    infoWins[0].setLabel("点名：" + myobj[i].MarkName + "<br/>大地坐标等级：" + myobj[i].AccuracyClass + "<br/>高程坐标等级：" + myobj[i].GCgrade + "<br/>	保存完好性：" + myobj[i].BZ + "<br/> 点之记图片 <img src=\"../../../themes/icon/Crose.png\" style=\"width:30px;hright:30px \" />");
                    infoWins[0].closeInfoWindowWithMouse();

                    TEvent.addListener(marker[0], "click", function () {

                        map.addOverLay(infoWins[0]);
                    });

                }
            });
        })

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
                        field: 'MarkName',
                        title: '点名',
                        sortable: true
                    }, {
                        field: 'MarkID',
                        title: '点号',
                        sortable: true
                    }, {
                        field: 'AccuracyClass',
                        title: '平面坐标精度等级',
                        sortable: true
                    }, {
                        field: 'GCgrade',
                        title: '高程坐标精度等级',
                        sortable: true

                    }, {
                        field: 'BZ',
                        title: '标志是否完好',
                        sortable: true

                    }, {
                        field: 'Button',
                        title: '查看',
                        sortable: true

                    }],
                onLoadError: function (data) {
                    $('#table').bootstrapTable('removeAll');
                },
            });
            $(".search input").attr("placeholder", "点名");
            $(".search input").attr("onchange", "changes()");
        }
        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID
            });
        }
        function changes() {
           
            
            for (var i = 0; i < allmarker.length; i++)
            {
                map.removeOverLay(allmarker[i]);
                
            }

            //loadboundary();
            loadpoint();
        }
       
        $("#delete").click(function () {
            var ids = getIdSelections();
            table.bootstrapTable('remove', {
                field: 'ID',
                values: ids
            });




            $.ajax({
                url: "",
                type: "post",
                data: {
                    action: "Delete",
                    id: ids,
                },
                success: function (result) {
                    var myobj = eval(result);
                    if (myobj.length>0) {
                        layer.alert('删除成功', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                        
                        var marker = new Array();
                        var infoWins = new Array();
                        for (var i = 0; i < myobj.length; i++) {
                            var lnglat = new TLngLat(myobj[i].B, myobj[i].L);
                            var icon = new TIcon("../../../themes/icon/Crose.png", new TSize(14, 14), { anchor: new TPixel(7, 7) });
                            marker[i] = new TMarker(lnglat, { icon: icon });                            

                        }
                        for (var j = 0; j < marker.length; j++) {
                            for (var i = allmarker.length - 1; i >= 0 ; i--) {
                                var a = allmarker[i].getLngLat();
                                var a1 = a[0];
                                var a2 = a[1];
                                var b = marker[j].getLngLat();
                                var b1 = b[0];
                                var b2 = b[1];
                                if (a1 == b1) {
                                    map.removeOverLay(allmarker[i]);
                                    allmarker.splice(1, 1);
                                    break;
                                }


                            }
                        }
                    }
                    else {
                        layer.alert('删除失败', {
                            skin: 'layui-layer-lan', //样式类名,
                        });
                    }
                }
            });
            $("#delete").blur();
        });
        $("#download").click(function () {
            window.location.href = "?action=DownloadAll";

            $("#download").blur();
        });
        $("#refresh").click(function () {
            table.bootstrapTable("refresh");
        });
        var load = false;
        $(document).ready(function () {
           
            loadpoint();
            if (!load) {
                initialTable();
            }
        });
    </script>
</body>

</html>
