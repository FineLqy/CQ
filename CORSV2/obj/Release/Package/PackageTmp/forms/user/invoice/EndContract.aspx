<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EndContract.aspx.cs" Inherits="CORSV2.forms.user.invoice.EndContract" %>



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
				<h2 style="font-weight: 700">&nbsp;</h2>
			</div>

			<div class="col-md-12">
				<div class="progress"><span data-content="确认信息" >1</span><b></b><span data-content="合同申请成功" class="on" >2</span></div>
			</div>


			<form action="#" id="change_password_form" runat="server" class="form-horizontal">
                <div style="width:700px;height:600px;margin:0 auto">
                <table style="width:100%;height:150px; border-spacing:10px">
                    <tr>
                        <td style="font-size:24px;font-weight:bold">您的合同（草稿）创建成功<br /></td>
                    </tr>
                     <tr>
                        <td style="font-size:16px">合同号:<asp:Label ID="ContractId" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="font-size:16px">当前创建的为合同草稿，可下载预览;转为正式合同后具有法律效力，落款章有效，不可自行销毁。</td>
                    </tr>
                    <tr>
                        <td style="font-size:16px"><a id="download" >下载该草稿合同</a><asp:Button ID="Button1"  class="btn blue"  runat="server" Text="立即转为正式合同" OnClick="Button1_Click" /> <a href="../contract/apply_contract.aspx">跳转合同管理页</a>  </td>
                    </tr>
                </table>
				
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
    <script>
        $("#download").click(function () {
            
            window.location.href = "?action=DownloadAll";

            $("#download").blur();
        });
    </script>
<!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>
