<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="CORSV2.forms.publicforms.Error" %>

<!DOCTYPE html>
<html>

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">


    <title>500错误</title>
    <link rel="shortcut icon" href="../../themes/images/favicon.ico" />
    <link href="../../themes/css/bootstrap.min.css?v=3.3.6" rel="stylesheet">
    <link href="../../themes/css/font-awesome.css?v=4.4.0" rel="stylesheet">
    <link href="../../themes/css/animate.css" rel="stylesheet">
    <link href="../../themes/css/style.css?v=4.1.0" rel="stylesheet">
</head>

<body class="gray-bg">


    <div class="middle-box text-center animated fadeInDown">
        <h1>500</h1>
        <h3 class="font-bold">开发中</h3>

        <div class="error-desc">
            开发中...
           
            <br />
            您可以返回主页看看
            
            <br />
            <button id="returnindex" class="btn btn-primary m-t">主页</button>
        </div>
    </div>

    <!-- 全局js -->
    <script src="../../js/jquery.min.js"></script>
    <script src="../../js/bootstrap.min.js?v=3.3.6"></script>
    <script type="text/javascript">
        $("#returnindex").click(function () {
            window.location.href = "../../Index.aspx";
        })
    </script>

</body>

</html>
