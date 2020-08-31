﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataQualityAnalysis.aspx.cs" Inherits="CORSV2.forms.administrator.information.DataQualityAnalysis" %>


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
			#warp{
	height: 980px;
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
   
      
 
   
    <div style="width:24%;height:980px;float:left;margin-top:20px">
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
    
        <div id="d1" style="width:100%;height:25%;border-bottom:1px solid #e0dede">1</div>
        <div id="d2" style="width:100%;height:25%;border-bottom:1px solid #e0dede">2</div>
        <div id="d3" style="width:100%;height:25%;border-bottom:1px solid #e0dede">3</div>
        <div id="d4" style="width:100%;height:25%;border-bottom:1px solid #e0dede">4</div>
        <div id="d5" style="width:100%;height:25%;border-bottom:1px solid #e0dede">5</div>
        <div id="d6" style="width:100%;height:25%;border-bottom:1px solid #e0dede">6</div>
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
        $(function () {
            var v1 = [];
            var Rname = '123';
            $.ajax({
                url: "DataQualityAnalysis.aspx/lodaa3",
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
</body>

</html>