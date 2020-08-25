<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoList.aspx.cs" Inherits="CORSV2.forms.ToDoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta charset="utf-8" />
    <title></title>
    <script src="../../../js/jquery-1.10.2.min.js"></script>
    <script src="../../../js/jquery.form.js"></script>
   
    <link href="../../user/order/css/order_custom.css" rel="stylesheet" />
    <link href="../../user/order/css/global.css" rel="stylesheet" />

    <link href="user/order/css/global.css" rel="stylesheet" />
    <link href="//netdna.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet"/>

      <link href="https://static.sobds.com/Public/Member/plugins/font-awesome/css/font-awesome.min.css?v=1.1.15" rel="stylesheet" type="text/css"/>
    <link href="https://static.sobds.com/Public/Member/plugins/bootstrap/css/bootstrap.min.css?v=1.1.15" rel="stylesheet" type="text/css"/>
    <link href="https://static.sobds.com/Public/Member/plugins/uniform/css/uniform.default.css?v=1.1.15" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" type="text/css" href="https://static.sobds.com/Public/Member/plugins/select2/select2_metro.css?v=1.1.15" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
    <link href="https://static.sobds.com/Public/Member/plugins/gritter/css/jquery.gritter.css?v=1.1.15" rel="stylesheet" type="text/css"/>
    <link href="https://static.sobds.com/Public/Member/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css?v=1.1.15" rel="stylesheet" type="text/css" />

    <link href="https://static.sobds.com/Public/Member/css/style-metronic.css?v=1.1.15" rel="stylesheet" type="text/css"/>
    <link href="https://static.sobds.com/Public/Member/css/style.css?v=1.1.15" rel="stylesheet" type="text/css"/>
    <link href="https://static.sobds.com/Public/Member/css/style-responsive.css?v=1.1.15" rel="stylesheet" type="text/css"/>
    <link href="https://static.sobds.com/Public/Member/css/plugins.css?v=1.1.15" rel="stylesheet" type="text/css"/>
    <link href="https://static.sobds.com/Public/Member/css/themes/light.css?v=1.1.15" rel="stylesheet" type="text/css" id="style_color"/>
    <link href="https://static.sobds.com/Public/Member/css/custom.css?v=1.1.15" rel="stylesheet" type="text/css"/>
    <link href="https://static.sobds.com/Public/Member/plugins/layer/skin/layer.css?v=1.1.15" rel="stylesheet" type="text/css"/>
    <link href="https://static.sobds.com/Public/Member/plugins/layer/skin/layer.ext.css?v=1.1.15" rel="stylesheet" type="text/css"/>
    <script src="https://static.sobds.com/Public/Member/plugins/jquery-1.10.2.min.js?v=1.1.15" type="text/javascript"></script>
    <link rel="stylesheet" href="https://static.sobds.com/Public/Member/plugins/data-tables/DT_bootstrap.css?v=1.1.15" />
    <link rel="stylesheet" href="https://static.sobds.com/Public/Member/plugins/webuploader/webuploader.css?v=1.1.15" />
    
    <style type="text/css">
        .desc {
       margin: 0 auto;
width: 200px;
height: 80px;
text-align: center;
line-height: 80px;
        }
        .div1 {
          display: inline-block;
          
        }
         .div2 {
          display: inline-block;
        }
       .dashboard-stat.grey{
        background-color:#ECEEF1;
        }
        .number {
        margin-left:120px;
        }
     
    </style>
</head>
<body class="" style="width:100%;height:100%;margin:0 auto;">
  
    <div class="dd" style="width:100%;height:100%">

    
    <div class="div1"  style="margin-top:10px; width:100%; height:200px" >
         <span style="margin-left:30px"> 待审核服务</span>  
         <hr />
	
			<div class="col-md-3">
					<div class="dashboard-stat grey">

						<div class="number">
							实时测绘基准服务
						</div>

						<div class="visual">

							<i class="fa fa-retweet"></i>

						</div>

						<div class="details">

							<div class="desc">
								
								<p class="text-error">0个待处理</p>
							</div>

						</div>

													<a class="more" data-toggle="modal" href="#qualification-certify-warning">
								查看详情 <i class="m-icon-swapright m-icon-white"></i>
							</a>

					</div>
				</div>
        	<div class="col-md-3">
					<div class="dashboard-stat grey">

						<div class="number">
							基准数据申领服务
						</div>

						<div class="visual">

							<i class="fa fa-bar-chart"></i>

						</div>

						<div class="details">

							<div class="desc">
								
								<p class="text-error">0个待处理</p>
							</div>

						</div>

													<a class="more" data-toggle="modal" href="#qualification-certify-warning">
								查看详情 <i class="m-icon-swapright m-icon-white"></i>
							</a>

					</div>
				</div>

			<div class="col-md-3">
					<div class="dashboard-stat grey">

						<div class="number">
							事后差分解算服务
						</div>

						<div class="visual">

							<i class="fa fa-file-text"></i>

						</div>

						<div class="details">

							<div class="desc">
								
								<p class="text-error">0个待处理</p>
							</div>

						</div>

													<a class="more" data-toggle="modal" href="#qualification-certify-warning">
								查看详情 <i class="m-icon-swapright m-icon-white"></i>
							</a>

					</div>
				</div>
    </div>
   
    <div class="div2" style="margin-top:60px;width:100%; height:200px">
         <span style="margin-left:30px"> 待审核费用</span>  
        <hr />
        	<div class="col-md-3" ">
					<div class="dashboard-stat grey" style="">

						<div class="number">
							开票管理
						</div>

						<div class="visual">

							<i class=" fa fa-align-center" style="color:#103F91" aria-hidden="true"></i>

						</div>

						<div class="details">

							<div class="desc">
								
								<p class="text-error"><%=InvoiceNum1 %>个待开票</p>
							</div>

						</div>

													<a class="more" data-toggle="modal" href="administrator/invoice/manage_invoice.aspx" style="background-color:#103F91">
								查看详情 <i class="m-icon-swapright m-icon-white"></i>
							</a>

					</div>
				</div>
            <div class="col-md-3">
					<div class="dashboard-stat grey">

						<div class="number">
							发票信息审核
						</div>

						<div class="visual">

							<i class=" fa fa-align-center" style="color:#103F91" aria-hidden="true"></i>

						</div>

						<div class="details">

							<div class="desc">
								
								<p class="text-error"><%=InvoiceNum %>个待审核</p>
							</div>

						</div>

													<a class="more" data-toggle="modal" href="administrator/invoice/manage_invoice.aspx" style="background-color:#103F91">
								查看详情 <i class="m-icon-swapright m-icon-white"></i>
							</a>

					</div>
				</div>
        <div class="col-md-3">
					<div class="dashboard-stat grey">

						<div class="number">
							订单审核
						</div>

						<div class="visual">

							<i class=" fa fa-align-center" style="color:#103F91" aria-hidden="true"></i>

						</div>

						<div class="details">

							<div class="desc">
								
								<p class="text-error"><%=OrderNum %>个待审核</p>
							</div>

						</div>

													<a class="more" data-toggle="modal" href="administrator/order/manage_order.aspx" style="background-color:#103F91">
								查看详情 <i class="m-icon-swapright m-icon-white"></i>
							</a>

					</div>
				</div>
    </div>
     <div class="div3" style="margin-top:60px">
         <span style="margin-left:30px"> 待审核认证</span>  
        <hr />
           <div class="col-md-3">
					<div class="dashboard-stat grey">

						<div class="number">
							资质认证
						</div>

						<div class="visual">

							<i class=" fa fa-pencil" style="color:#07C160" aria-hidden="true"></i>

						</div>

						<div class="details">

							<div class="desc">
								
								<p class="text-error"><%=qualificationNum%>个待审核</p>
							</div>

						</div>

													<a class="more" data-toggle="modal" href="administrator/users/UserManage.aspx" style="background-color:#07C160">
								查看详情 <i class="m-icon-swapright m-icon-white" ></i>
							</a>

					</div>
				</div>
         </div>

        </div>
</body>
</html>