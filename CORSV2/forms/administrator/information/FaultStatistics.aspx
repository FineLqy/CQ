<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FaultStatistics.aspx.cs" Inherits="CORSV2.forms.administrator.information.FaultStatistics" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>基站故障统计</title>

    <link rel="shortcut icon" href="../../favicon.ico" />
    
    <link type="text/css" rel="stylesheet" href="../../../themes/css/bootstrap.min.css?v=3.3.6" />
    <link href="../../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="../../../themes/css/plugins/bootstrap-table/bootstrap-table.min.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css?v=4.1.0" rel="stylesheet">

      <script src="../../../js/jquery.min.js"></script>
        <style type="text/css">
			#warp{
	height: 640px;
	width: 95%;
	border: 1px solid #e0dede;
	overflow: hidden;
	margin: 10px 0 0 10px;
    float:left;
	position: relative;
			}
			  #box{
			  	height: 100%;
                  	
			  	overflow-x: hidden;  
                overflow-y: auto;
              
                padding: 10px;
               
			  }
			p{
				height: 30px;
				border: 1px solid #eee;
				margin: 0;
				padding: 0;
			}
			#scrollBar{
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
			#scrollBar:hover{
	background-color: #000000;
}
         
		</style>
    <script src="../../publicforms/map/setBar.js"></script>
    
<script>
			$(function(){
				
				setSrollBar()
			})
		</script>
</head>
<body class="gray-bg">
    <div class="wrapper wrapper-content  animated fadeInRight" style="padding-top:0px;width:75%;float:left">
        <div class="row" style="padding-left:0px;padding-right:0px;">
            <div class="col-sm-8" style="padding-left:0px;padding-right:0px;width: 100%;" >
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
                                data-page-size="15"
                                data-id-field="ID"
                                data-unique-id="ID"
                                data-page-list="[15,25, 50, 100]"
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
   
      
 
   
    <div style="width:24%;height:500px;float:left;margin-top:20px">
           <span>统计信息:</span> <button type="button" id="week" class="btn btn-outline btn-default" title="本周">
                                        <i ></i>本周
                                    </button>
    <button type="button" id="month" class="btn btn-outline btn-default" title="本月">
                                        <i ></i>本月
                                    </button>
    <button type="button" id="SinceOperation" class="btn btn-outline btn-default" title="运行以来">
                                        <i ></i>运行以来
                                    </button>
      <div id='warp'>
           <div id="box">
    
        <div id="d1" style="width:100%;height:50%;border-bottom:1px solid #e0dede"></div>
        <div id="d2" style="width:100%;height:50%;border-bottom:1px solid #e0dede"></div>
        
    </div>
               </div>
          </div>


    <script src="../../../js/bootstrap.min.js"></script>

    <script src="../../../js/plugins/layer/layer.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table-mobile.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/bootstrap-table.min.js"></script>
    <script src="../../../js/plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"></script>
      <script src="http://webapi.amap.com/maps?v=1.4.14&amp;key=b74b8fd91eb7e6bc323fc3387c02b261&amp;plugin=Map3D,AMap.Autocomplete,AMap.PlaceSearch,AMap.MarkerClusterer,AMap.DistrictSearch,AMap.CustomLayer,AMap.Heatmap"></script>
  <script src="../../../js/echarts-gl.min.js"></script>
     <script src="../../../js/echarts.min.js"></script>
     <script src="../../../js/echarts.js"></script>
    <script type="text/javascript" src="http://echarts.baidu.com/gallery/vendors/echarts/echarts-all-3.js"></script>
 
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
        $(function () {
            var v1 = [];
            var Rname = '123';
            $.ajax({
                url: "FaultStatistics.aspx/lodaa1",
                contentType: "application/json; charset=utf-8",
                data: "{t:'" + Rname + "'}",
                type: "Post",
                dataType: "json",
                success: function (data) {
                    var res = JSON.parse(data.d);
                    console.log(data)
                    console.log(res.dt1);
                    var da=new Array();
                      var Num = [];
                    for (var i in res.dt1) {
                        console.log( res.dt1[i].Num)
                        da.push( res.dt1[i].StationOName)
                          var op1 = echarts.init(document.getElementById('d1'));
                        var datacolor = da;
                        Num.push( res.dt1[i].Num)

option = {
    title: {
        text: '站点故障频率排行',
       
    },
    tooltip: {
        trigger: 'axis',
        axisPointer: {
            type: 'shadow'
        }
    },

     grid: {
      left: '15%',
      
    },
    // visualMap: {
    //     orient: 'horizontal',
    //     left: 'center',
    //     min: 10,
    //     max: 200000,
    //     text: ['High', 'Low'],
    //     // Map the score column to color
    //     dimension: 0,
    //     inRange: {
    //         color: ['#D7DA8B', '#E15457']
    //     }
    // },
    xAxis: {
        type: 'value',
        boundaryGap: [0, 0.01]
    },
    yAxis: {
        type: 'category',
        data:datacolor
    },
    series: [
        {
           
            type: 'bar',
            data: Num
        }
    ]
};

                        op1.setOption(option);              

                    }


                  


                }
            })
        });

    </script>

    
    <script>
        $(function () {
            var v1 = [];
            var Rname = '123';
            $.ajax({
                url: "FaultStatistics.aspx/lodaa2",
                contentType: "application/json; charset=utf-8",
                data: "{t:'" + Rname + "'}",
                type: "Post",
                dataType: "json",
                success: function (data) {
                    var res = JSON.parse(data.d);
                    console.log(data)
                    console.log(res.dt2);
                    var da=new Array();
                      var Num = [];
                    for (var i in res.dt2) {
                        console.log( res.dt2[i].Num)
                        da.push( res.dt2[i].Datayear)
                          var op2 = echarts.init(document.getElementById('d2'));
                        var datacolor = da;
                        Num.push( res.dt2[i].Num)

                         let pointStyle = {
     borderColor: '#ea6f21',
     color: '#fff',
     borderWidth: 2,
 }
 let labelStyle = {
     show: true,
     position: 'top',
     lineHeight: 20,
     borderRadius: 5,
     backgroundColor: 'rgba(255,255,255,.9)',
     borderColor: '#ccc',
     borderWidth: '1',
     padding: [5, 15, 4],
     color: '#000000',
     fontSize: 14,
     fontWeight: 'normal',
 }
 let total = Num
 let seriesData = []
 total = total.sort(function(a, b) {
     return a - b
 })
 total.forEach((item, index) => {
     let ob = {
         value: item,
         itemStyle: pointStyle,
         label: labelStyle,
     }
     if (index === total.length - 1) {
         ob.itemStyle = {
             borderColor: '#ea6f21',
             color: '#ea6f21',
             borderWidth: 3,
         }
         ob.label = {
             show: true,
             position: 'top',
             lineHeight: 20,
             backgroundColor: '#ea6f21',
             borderRadius: 5,
             borderColor: '#ea6f21',
             borderWidth: '1',
             padding: [5, 15, 4],
             color: '#fff',
             fontSize: 14,
             fontWeight: 'normal',
         }
     }
     seriesData.push(ob)
 })

 option = {
     title: {
         text: '站点故障总数',
         left: 'left',
     },
     grid: {
         top: '15%',
         left: '15%',
         right: '8%',
         bottom: '15%',
     },
     xAxis: [{
         type: 'category',
         axisTick: {
             show: false,
         },

         splitLine: {
             show: true,
             lineStyle: {
                 type: 'dashed',
             },
         },
         data: da,
     }, ],

     yAxis: [{
         type: 'value',
         min: 0,
         max: 100,
         splitNumber: 3,
         axisLine: {
             show: false,
         },
         axisTick: {
             show: false,
         },
         splitLine: {
             show: true,
             lineStyle: {
                 type: 'dashed',
             },
         },
     }, ],
     series: [{
         type: 'line',
         showAllSymbol: true,
         symbol: 'circle',
         symbolSize: 10,
         lineStyle: {
             normal: {
                 color: '#ea6f21',
                 width: 5,
             },
         },
         tooltip: {
             show: false,
         },
         areaStyle: {
             normal: {
                 color: new echarts.graphic.LinearGradient(
                     0,
                     0,
                     0,
                     1,
                     [{
                             offset: 0,
                             color: 'rgba(236, 169, 44, 1)',
                         },
                         {
                             offset: 1,
                             color: 'rgba(236, 169, 44,0)',
                         },
                     ],
                     false
                 ),
             },
         },
         data: seriesData,
         markLine: {
             symbol: ['none', 'none'], //去掉箭头
             itemStyle: {
                 normal: {
                     lineStyle: {
                         type: 'dashed',
                         color: '#ccc',
                         width: 2
                     }
                 },
             },
         
         },
     }, ],
 };

                    op2.setOption(option);                   

                    }


                  


                }
            })
        });

    </script>
</body>

</html>
