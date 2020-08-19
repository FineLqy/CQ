<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractApplication.aspx.cs" Inherits="CORSV2.forms.user.invoice.ContractApplication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>合同索取</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
        <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="../../../themes/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../../themes/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../themes/css/uniform.default.css" rel="stylesheet" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
    <link href="../../../themes/css/jquery.gritter.css" rel="stylesheet" />
    <link href="../../../themes/css/style-metronic.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css" rel="stylesheet" />
    <link href="../../../themes/css/plugins.css" rel="stylesheet" />
    <link href="../../../themes/css/light.css" rel="stylesheet" />
    <link href="../../../themes/css/custom.css" rel="stylesheet" />

    <script src="../../../js/jquery-1.10.2.min.js"></script>

    <!-- END THEME STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />  
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body class="page-header-fixed">





<div class="clearfix"></div>
    <link href="../../../themes/css/ucenter.css" rel="stylesheet" />
    <link href="../../../themes/css/user_progress.css" rel="stylesheet" />
<!-- BEGIN CONTAINER -->
	
	
	

	<!-- BEGIN PAGE -->
		<!-- BEGIN PAGE HEADER-->
		<!-- END PAGE HEADER-->
		<!-- BEGIN DASHBOARD STATS -->
			<div class="col-md-12" style="text-align: center">
				<h2 style="font-weight: 700"></h2>
			</div>

			<div class="col-md-12">
				<div class="progress"><span data-content="确认信息" class="on">1</span><b></b><span data-content="合同申请成功" >2</span></div>
			</div>


			<form action="#" id="change_password_form" runat="server" class="form-horizontal">
				<div class="form-body">
					<div class="form-group">
						<label class="control-label col-md-5">甲方名称</label>
						<div class="col-md-6">
							<input id="UserNmae" name="UserNmae" style="width: 40%;" runat="server"  class="form-control" required="required"/>
						</div>
					</div>

					<div class="form-group">
						<label class="control-label col-md-5"><span class="required">*</span>地址</label>
						<div class="col-md-6">
						<input id="address" name="address" style="width: 40%;" runat="server"   class="form-control" required="required"/>
						</div>
					</div>
					<div class="form-group">
						<label class="control-label col-md-5"><span class="required">*</span>联系人</label>
						<div class="col-md-6">
							<input id="contacts" name="contacts" style="width: 40%;" runat="server"   class="form-control" required="required"/>
						</div>
					</div>
                    	<div class="form-group">
						<label class="control-label col-md-5"><span class="required">*</span>电话</label>
						<div class="col-md-6">
							<input id="phone" name="phone" style="width: 40%;" runat="server"   class="form-control" required="required"/>
						</div>
					</div>
				</div>
				<div class="form-group">
					<label class="control-label col-md-5""></label>
                        <div class="col-md-6">
						
                            <asp:Button Iid="submit" Width="30%"  class="btn green" runat="server" Text="下一步" OnClick="Unnamed1_Click" />
                            </div>
				</div>
			</form>
		<!-- END DASHBOARD STATS -->
	<!-- END PAGE -->
    <script src="../../../js/jquery.form.js"></script>
    <script src="../../../js/plugins/layer/layer.js"></script>
    <link href="../../../js/plugins/layer/skin/layer.css" rel="stylesheet" />


<!-- END PAGE LEVEL SCRIPTS -->
<script>
    jQuery(document).ready(function () {
        //App.init(); // initlayout and core plugins
    });
</script>

<script>
    window.onload = function () {

    }

</script>
<!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>
