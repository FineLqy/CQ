<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataQualityAnalysis.aspx.cs" Inherits="CORSV2.forms.administrator.information.DataQualityAnalysis" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>基站数据质量分析</title>

    <link rel="shortcut icon" href="../../favicon.ico" />

    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">

    <script src="../../../js/jquery.min.js"></script>
    <style type="text/css">
        #warp {
            height: 980px;
            width: 95%;
            border: 1px solid #e0dede;
            overflow: hidden;
            margin: 10px 0 0 10px;
            float: left;
            position: relative;
        }

        #box {
            height: 100%;
            overflow-x: hidden;
            overflow-y: auto;
            padding: 10px;
        }

        p {
            height: 30px;
            border: 1px solid #eee;
            margin: 0;
            padding: 0;
        }

        #scrollBar {
            height: 100%;
            width: 5px;
            position: absolute;
            right: 0;
            top: 0;
            border-radius: 5px;
            background-color: #939393;
            opacity: 0.7;
            cursor: pointer;
        }

            #scrollBar:hover {
                background-color: #000000;
            }
    </style>
    <script src="../../publicforms/map/setBar.js"></script>

    <script>
        $(function () {

            setSrollBar()
        })
    </script>
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content  animated fadeInRight" style="padding-top: 0px; width: 75%; float: left">
        <div class="row" style="padding-left: 0px; padding-right: 0px;">
            <div class="col-sm-8" style="padding-left: 0px; padding-right: 0px; width: 100%;">
                <div class="ibox">
                    <div class="ibox-content">
                        <div class="newstable" style="margin-top: 1%">



                            <table
                                id="table"
                                data-toolbar="#toolbar"
                                data-search="true"
                                data-show-refresh="false"
                                data-show-toggle="true"
                                data-show-columns="true"
                                data-show-export="false"
                                data-detail-view="false"
                                data-striped="true"
                                data-minimum-count-columns="1"
                                data-show-pagination-switch="true"
                                data-pagination="true"
                                data-page-size="25"
                                data-id-field="ID"
                                data-unique-id="ID"
                                data-page-list="[25, 50, 100]"
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




    <div style="width: 24%; height: 980px; float: left; margin-top: 20px">
        <span>统计信息:</span>
        <button type="button" id="week" class="btn btn-outline btn-default" title="本周">
            <i></i>本周
        </button>
        <button type="button" id="month" class="btn btn-outline btn-default" title="本月">
            <i></i>本月
        </button>
            <button type="button" id="year" class="btn btn-outline btn-default" title="今年">
            <i></i>今年
        </button>
        <button type="button" id="SinceOperation" class="btn btn-outline btn-default" title="运行以来">
            <i></i>运行以来
        </button>
        <div id='warp'>
            <div id="box">

                <div id="d1" style="width: 100%; height: 25%; border-bottom: 1px solid #e0dede">1</div>
                <div id="d2" style="width: 100%; height: 25%; border-bottom: 1px solid #e0dede">2</div>
                <div id="d3" style="width: 100%; height: 25%; border-bottom: 1px solid #e0dede">3</div>
                <div id="d4" style="width: 100%; height: 25%; border-bottom: 1px solid #e0dede">4</div>
                <div id="d5" style="width: 100%; height: 25%; border-bottom: 1px solid #e0dede">5</div>
                <div id="d6" style="width: 100%; height: 25%; border-bottom: 1px solid #e0dede">6</div>
            </div>
        </div>
    </div>

    <script src="../../../js/bootstrap.min.js"></script>

    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
    <script>

        var table = $("#table");


        function initialTable() {
            table.bootstrapTable({
                columns: [

                    {
                        field: 'StationName',
                        title: '基站名'
                    }, {
                        field: 'StationOName',
                        title: 'Rinex站名',

                    }, {
                        field: 'TransferType',
                        title: '传输类型',

                    }, {
                        field: 'IP',
                        title: 'IP地址'
                    }, {
                        field: 'Port',
                        title: '端口'
                    }, {
                        field: 'Lat',
                        title: '纬度'
                    }, {
                        field: 'Lon',
                        title: '经度'

                    }, {
                        field: 'H',
                        title: '高度'
                    }, {
                        field: 'deIsOK',
                        title: '是否正常',


                    }, {
                        field: 'SatNum',
                        title: '卫星数',


                    }
                ],
            });
        }


  
        $("#refreshsta").click(function () {
            table.bootstrapTable('refresh');

        });

        $(document).ready(function () {
            initialTable();
            $(".search input").attr("placeholder", "搜索基站名或Rinex站名");
        });
    </script>

  

    <script>
     //查询本周数据
        $("#week").click(function () {
            
            var data1 = getStartDayOfWeek();
            var data2 = getEndDayOfWeek();
            $.ajax({
                url: "DataQualityAnalysis.aspx?action=GetData1",
                  
                dataType: "json",
                data: {
                    data1: data1,
                    data2: data2,

                },
                type: "POST",
                success: function (data) {
                    console.log(data);
                    var XData=new Array();
                          $('#table').on('click-row.bs.table', function (e, row, $element) {
                              console.log(row.StationOName);

                              for (var i in data) {
                                  for (var j in data[i]) {
                                     
                                      var num= j.substring(0,10);
                                      
                                      XData.push(num);
                                      for (var k in data[i][k]) {
                                          console(k)
                                      }
                                  }
                                  console.log(XData);
                                  
                              }

                              
 
            });

                }
            });
            
        
        });

          //查询本月数据
         $("#month").click(function(){
          alert(getStartDayOfMonth());
             alert(getEndDayOfMonth());
             var data1= getStartDayOfMonth();
               var dataM2 = getEndDayOfMonth();

                  $.ajax({
                url: "DataQualityAnalysis.aspx/GetData1",
                data: {
                    data1: data1,
                    dataM2: dataM2,

                },
                type: "POST",
                success: function (data) {

                }
            });
        
        });
          //查询今年数据
         $("#year").click(function(){
        alert($("#text2").val());
        
        });
              //查询所有数据
         $("#SinceOperation").click(function(){
        alert($("#text2").val());
        
        });


var now = new Date(); // 当前日期
var nowDayOfWeek = now.getDay(); // 今天本周的第几天
var nowDay = now.getDate(); // 当前日
var nowMonth = now.getMonth(); // 当前月
var nowYear = now.getYear(); // 当前年
nowYear += (nowYear < 2000) ? 1900 : 0;
         /**
     * 获得当前日期
     * 
     * @returns
     */
  function  getNowDay() {
        return this.formatDate(new Date());
    }
    /**
     * 获得本周的开始时间
     * 
     * @returns
     */
  function  getStartDayOfWeek() {
        var day = nowDayOfWeek || 7;
        return this.formatDate(new Date(now.getFullYear(), nowMonth, nowDay + 1 - day));
    }
    /**
     * 获得本周的结束时间
     * 
     * @returns
     */
  function  getEndDayOfWeek() {
        var day = nowDayOfWeek || 7;
        return this.formatDate(new Date(now.getFullYear(), nowMonth, nowDay + 7 - day));
    }
    /**
     * 获得本月的开始时间
     * 
     * @returns
     */
  function getStartDayOfMonth() {
        var monthStartDate = new Date(nowYear, nowMonth, 1);
        return this.formatDate(monthStartDate);
    }
    /**
     * 获得本月的结束时间
     * 
     * @returns
     */
   function getEndDayOfMonth() {
        var monthEndDate = new Date(nowYear, nowMonth, this.getMonthDays());
        return this.formatDate(monthEndDate);
    }
    /**
     * 获得本月天数
     * 
     * @returns
     */
   function getMonthDays() {
        var monthStartDate = new Date(nowYear, nowMonth, 1);
        var monthEndDate = new Date(nowYear, nowMonth + 1, 1);
        var days = (monthEndDate - monthStartDate) / (1000 * 60 * 60 * 24);
        return days;
    }
    /**
     * @param 日期格式化
     * @returns {String}
     */
        function formatDate(date) {
        var myyear = date.getFullYear();
        var mymonth = date.getMonth() + 1;
        var myweekday = date.getDate();
 
        if (mymonth < 10) {
            mymonth = "0" + mymonth;
        }
        if (myweekday < 10) {
            myweekday = "0" + myweekday;
        }
        return (myyear + "-" + mymonth + "-" + myweekday);
    }
    </script>
</body>

</html>
