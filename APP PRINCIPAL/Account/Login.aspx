<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/login.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class=" col-sm-3">
        </div>
        <div class="container col-sm-5 login-unity">
            <asp:Login ID="Login1" runat="server">
            </asp:Login>
        </div>
        <div class=" col-sm-4">
        </div>
    </form>
    <p>
    </p>

    <script>
        document.getElementById("Login1_UserName").setAttribute("placeholder", "Usuario");
        document.getElementById("Login1_Password").setAttribute("placeholder", "Password");
    </script>
</body>
</html>
