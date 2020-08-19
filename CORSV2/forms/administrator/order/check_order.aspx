<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="check_order.aspx.cs" Inherits="CORSV2.forms.administrator.order.check_order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../../themes/css/bootstrap.min.3.2.0.css" rel="stylesheet" />
    <link href="../../../themes/css/animate.css" rel="stylesheet" />
    <link href="../../../themes/css/style.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div  class="ibox float-e-margins" style="text-align:center;float:inherit;vertical-align:middle;padding-top:inherit;"> 
            <img src="" id="TransferCertificate" runat="server" />
            <button type="button" class="btn btn-w-m btn-primary">审核通过</button>
            <button type="button" class="btn btn-w-m btn-danger">审核失败</button>

        </div>
    </form>
</body>
</html>
