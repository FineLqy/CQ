<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RtkUserTrace.aspx.cs" Inherits="CORSV2.forms.administrator.information.RtkUserTrace" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>测量作业轨迹</title>
    <link rel="shortcut icon" href="../../favicon.ico" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">
    <link href="../../../themes/css/bootstrap.min.3.2.0.css" type="text/css" rel="stylesheet" />
     <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/animate.css" rel="stylesheet">
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins/chosen/chosen.css" rel="stylesheet" />
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content animated fadeIn">
        <div class="ibox float-e-margins">

            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    作业历史轨迹
                </div>
                <div class="ibox-content">
                    <div class=" form-horizontal">
                        <div class=" form-group" role="group">
                            <div class="col-lg-2 col-sm-2">
                                <div class="input-group">
                                    <input type="text" class="form-control" id="RtkUserName" placeholder="用户名">
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-white dropdown-toggle" data-toggle="dropdown">
                                            <span class="caret"></span>
                                        </button>
                                        <ul class="dropdown-menu dropdown-menu-right" role="menu">
                                        </ul>
                                    </div>
                                    <!-- /btn-group -->
                                </div>
                            </div>

                            <div class="col-lg-3 col-sm-3">
                                <select data-placeholder="请选择账户" class="chosen-select" multiple tabindex="4" id="user">
                                </select>
                            </div>
                            <div class="col-lg-2 col-sm-2">
                                <input placeholder="开始日期" class="form-control  laydate-icon layer-date" id="start" onchange="startTimeQuery();">
                            </div>

                            <div class="col-lg-2 col-sm-2">
                                <input placeholder="结束日期" class="form-control  laydate-icon layer-date " id="end">
                            </div>

                            <div class="col-lg-1 col-sm-1">
                                <button type="button" id="query" class="btn btn-outline btn-default ">
                                    <i class="glyphicon glyphicon-map-marker" aria-hidden="true"></i>轨迹地图
                                </button>
                            </div>
                            <div class="col-lg-2 col-sm-2">
                                <button type="button" id="download" class="btn btn-outline btn-default ">
                                    <i class="glyphicon glyphicon-save" aria-hidden="true"></i>导出xls
                                </button>
                            </div>



                        </div>
                    </div>


                </div>
            </div>


            <div class="ibox float-e-margins">
                <div class="ibox-title">历史轨迹地图</div>
                <div class="ibox-content">
                    <div id="UserTraceMap" style="height:600px;width:100%;"></div>
                </div>
            </div>
        </div>
    </div>
     <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=7bGCq1WUPVv5H4LDIpH7u12v"></script>
    <script src="../../../js/jquery.min.js"></script>
    <script src="../../../js/bootstrap.min.3.2.0.js"></script>
    <script src="../../../js/plugins/chosen/chosen.jquery.js"></script>
    <script src="../../../js/plugins/suggest/bootstrap-suggest.min.js"></script>
    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/layer/laydate/laydate.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script>
        var table = $("#table");
        var squeryPara = new Array();
        squeryPara["startTime"] = "";
        squeryPara["endTime"] = "";
        squeryPara["company"] = "";


        var start = {
            elem: "#start", format: "YYYY-MM-DD hh:mm:ss", min: "1999-06-16 23:59:59", max: laydate.now(), istime: true, istoday: true, choose: function (datas) {
                end.min = datas; end.start = datas; squeryPara["startTime"] = $("#start").val();

            }
        };
        var end = {
            elem: "#end", format: "YYYY-MM-DD hh:mm:ss", min: laydate.now(), max: laydate.now(), istime: true, istoday: true, choose: function (datas) {
                start.max = datas; squeryPara["endTime"] = $("#end").val();
            }
        };
        laydate(start);
        laydate(end);

        function query() {
            var users = "";
            $(".chosen-choices .search-choice span").each(function (i, item) {
                users += item.innerText + ";";
            });
            users = users.substr(0, users.length - 1);
            var startTime = $("#start").val();
            var endTime = $("#end").val();
            GetMap(users, startTime, endTime);
            $("#query").blur();
        }

        $("#user").chosen({
            disable_search_threshold: 10,
            no_results_text: "无用户",
            width: "95%"
        });
        $("#query").on('click', query);
        function GetAccount() {
            $.ajax({
                url: "?action=GetUserAccount",
                data: { "UserName": $("#RtkUserName").val() },
                type: "post",
                success: function (dt) {
                    var data = JSON.parse(dt);
                    $("#user").empty();
                    $.each(data, function (i, item) {
                        $("#user").append($("<option></option>")
                        .attr("value", item["ID"])
                        .text(item["UserName"]));
                        $("#user").trigger('chosen:updated');
                    });
                }
            });
        }
        var testBsSuggest = $("#RtkUserName").bsSuggest({
            url: "?action=GetJsonCompany",
            showBtn: false,
            idField: "Id",
            keyField: "UserName"
        })
            .on("onDataRequestSuccess",
            function (e, result) { console.log("onDataRequestSuccess: ", result) })
            .on("onSetSelectValue",
            function (e, keyword) {
                GetAccount();
            })
            .on("onUnsetSelectValue", function (e) { console.log("onUnsetSelectValue") });


        function getIdSelections() {
            return $.map(table.bootstrapTable('getSelections'), function (row) {
                return row.ID;
            });
        }
        $("#download").click(function () {
            window.location.href = "?action=DownloadAll";
            $("#download").blur();
        });


        var data; var map;
        function GetMap(users, startTime, endTime) {
            map = new BMap.Map("UserTraceMap");
            var point = new BMap.Point(106.33, 29.35);
            map.centerAndZoom("重庆", 11);
            map.enableScrollWheelZoom();                  // 启用滚轮放大缩小。
            map.addControl(new BMap.MapTypeControl({ mapTypes: [BMAP_NORMAL_MAP, BMAP_HYBRID_MAP] }));     //2Dͼ£¬πчͼ
            map.addControl(new BMap.MapTypeControl({ anchor: BMAP_ANCHOR_TOP_LEFT }));    //سʏ½ǣ¬Ĭɏµٍ¼¿ؼ�.addControl(new BMap.ScaleControl());           
            map.addControl(new BMap.NavigationControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT, type: BMAP_NAVIGATION_CONTROL_ZOOM }));  //ԒЂ½ǣ¬½�¬̵·Ű´ť
            $.post(
              "/forms/functions/GetRTKUserTrace.ashx",
              {
                  q: "get",
                  users: users,
                  startTime: startTime,
                  endTime: endTime

              },
              function (data) //回传函数
              {
                  var Iindex = 0;
                  var datas = data.split("<");
                  var datass = datas[0].split("?");

                  function addMarker(point, index) {
                      //             var myIcon = new BMap.Icon("http://api.map.baidu.com/img/markers.png", new BMap.Size(23, 25), {
                      //           offset: new BMap.Size(10, 25),                  // 指定定位位置
                      //                 imageOffset: new BMap.Size(0, 0 - index * 25)   // 设置图片偏移
                      //               });
                      //var marker = new BMap.Marker(point, {icon: myIcon});
                      var marker = new BMap.Marker(point);
                      map.addOverlay(marker);
                      var label = new BMap.Label(datass[3 * index + 2], { offset: new BMap.Size(20, -10) });
                      marker.setLabel(label);
                  }

                  ///添加海量点
                  if (document.createElement('canvas').getContext) {

                      var points = [];
                      for (var i = 0; i < datass.length / 3; i++) {

                          var point = new BMap.Point(datass[3 * i], datass[3 * i + 1]);
                          point.index = i;
                          points.push(point);

                      }
                      var options = {
                          size: BMAP_POINT_SIZE_BIG,
                          shape: BMAP_POINT_SHAPE_RHOMBUS,
                          color: '#d340c3'
                      }
                      var pointCollection = new BMap.PointCollection(points, options);  // 初始化PointCollection
                      var opts = {
                          width: 100,     // 信息窗口宽度
                          height: 9     // 信息窗口高度
                          // 信息窗口标题
                      }
                      pointCollection.addEventListener("click", function (e) {
                          //var infoWindow = new BMap.InfoWindow(datass[3 * e.point.index + 2], opts);
                          map.openInfoWindow(new BMap.InfoWindow(datass[3 * e.point.index + 2], opts), e.point);
                      });

                      map.addOverlay(pointCollection);
                  }
                  else {
                      // 向地图添加标注
                      for (var i = 0; i < datass.length / 3; i++) {
                          var point = new BMap.Point(datass[3 * i], datass[3 * i + 1]);
                          addMarker(point, i);
                      }
                  }
              }
            );
        }
    </script>
</body>
</html>


