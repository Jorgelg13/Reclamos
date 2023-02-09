<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pendientes.aspx.cs" Inherits="MdBitacora_pendientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/summernote.css" rel="stylesheet" />
    <link href="../css/estilos.css" rel="stylesheet" />
    <link href="../Scripts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/toastr.min.css" rel="stylesheet" />
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="../css/GridviewScroll.css" rel="stylesheet" />
    <title>Reclamos Pendientes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron titulo-cabecera" style="height: 115px;">
            <a href="/MdBitacora/DashboardUnity.aspx" style="color: white">
                <h2 style="width: 481px; padding-bottom: 20px;">Reclamos pendientes de cierre</h2>
            </a>
            <header>
                <div class="content-wrapper">
                    <div class="float-right">
                        <div class="img-float-right" style="float: right;">
                            <img src="../imgUnity/Unity%20Promotores-%20Logo%20en%20blanco.png" style="margin-top: -90px; width: 235px;"/>
                        </div>
                    </div>
                </div>
            </header>
        </div>
        <br />
        <br />
        <div class="container-fluid">
            <div class="panel panel-info">
                <div class="panel-heading"><b>Reclamos Pendientes</b></div>
                <div class="panel-body">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridPendientes" runat="server" CssClass="table bs-table table-responsive table-hover" 
                            AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridPendientes_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <%--archivos javascripts que se utilizan en el sistema--%>
        <script src="../Scripts/jquery-3.1.1.min.js"></script>
        <script src="../bootstrap/js/bootstrap.min.js"></script>
        <script src="../Scripts/jquery.cookie.min.js"></script>
        <script src="../Scripts/toastr.min.js"></script>
        <script src="../Scripts/gridviewScroll.min.js"></script>
        <script src="../Scripts/app.js"></script>
    </form>
</body>
</html>

