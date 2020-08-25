<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeCompanyInfo.aspx.cs" Inherits="CORSV2.forms.publicforms.login.ChangeCompanyInfo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>修改单位</title>
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
				<h2 style="font-weight: 700">修改绑定单位</h2>
			</div>

			<div class="col-md-12">
				<div class="progress"><span data-content="验证绑定单位" class="on">1</span><b></b><span data-content="修改成功">2</span></div>
			</div>


			<form action="#" id="change_password_form" class="form-horizontal">
				<div class="form-body">
					<div class="form-group">
						<label class="control-label col-md-5">用户名</label>
						<div class="col-md-6">
							<p class="form-control-static"><%=userName %></p>
						</div>
					</div>

					<div class="form-group">
						<label class="control-label col-md-5"><span class="required">*</span>原始单位</label>
						<div class="col-md-6">
							<p class="form-control-static"><%=oldCompany %></p>
						</div>
					</div>
					<div class="form-group">
						<label class="control-label col-md-5"><span class="required">*</span>目前单位</label>
						<div class="col-md-6">
							<input id="new_company" name="new_company" style="width: 40%;"  class="form-control" required="required"/>
						</div>
					</div>
				</div>
				<div class="form-group">
					<label class="control-label col-md-5""></label>
                        <div class="col-md-6">
						<button style="width: 40%;" id="submit" type="button"  class="btn green">提交</button>
                            </div>
				</div>
			</form>
		<!-- END DASHBOARD STATS -->
	<!-- END PAGE -->
    <script src="../../../js/jquery.form.js"></script>
    <script src="../../../js/plugins/layer/layer.js"></script>
    <link href="../../../js/plugins/layer/skin/layer.css" rel="stylesheet" />
<script>
    $(document).ready(function () {
    });
    $("#submit").click(function () {
        var new_company = $("#new_company").val();

        //异步修改密码
        $.ajax({
            type: 'POST',
            url: "?action=changeCompanyInfo",
            data: {
                "new_company": new_company
            },
            success: function (data) {
                if (data.code == 200) {
                    //window.parent.location.href = "/forms/publicforms/login/login.aspx";
                    //alert('修改成功,将会跳转到登录界面');
                    layer.msg('单位修改成功,将重新登陆...');
                    window.setTimeout("window.parent.location='/forms/publicforms/login/login.aspx';", 500);
                } else {
                    layer.msg("单位修改失败");
                    return false;
                }
            },
            dataType: "json"
        });
    });
   
</script>

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
