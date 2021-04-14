<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reclamos-pendientes.aspx.cs" EnableEventValidation="false" Inherits="Consultas_Colectivos_reclamos_pendientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../css/estilos.css" rel="stylesheet" />
    <link href="../../Scripts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../css/toastr.min.css" rel="stylesheet" />
    <link href="../../css/GridviewScroll.css" rel="stylesheet" />
    <title>Reclamos Pendientes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron titulo-cabecera" style="height: 100px; background-color: #087fca">
            <h2 style="width: 781px; padding-bottom: 20px;">Reclamos Pendientes</h2>
            <header>
                <div class="content-wrapper">
                    <div class="float-right">
                        <div class="img-float-right" style="float: right;">
                            <img src="../../imgUnity/Unity%20Promotores-%20Logo%20en%20blanco.png" style="margin-top: -105px; width: 235px;" />
                        </div>
                    </div>
                </div>
            </header>
        </div>
        <div style="display:flex; margin-top:15px;margin-left:25px;">
            <asp:LinkButton ID="lnExcel" OnClick="lnExcel_Click" title="Descargar en excel" runat="server" Style="font-size: 40px; text-align: center; color: green"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
            <h3>Descargar Excel</h3>
        </div>
        <div class="container-fluid">
            <div class="col-sm-12 col-md-12 col-lg-12">
                <br />
                <div class="scrolling-table-container">
                    <asp:Label runat="server" ID="lblTotal"></asp:Label>
                    <asp:LinkButton ID="linkDescargar" Visible="false" title="Descargar en excel" runat="server" Style="font-size: 20px; text-align: center; color: green"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                    <asp:GridView ID="GridPendientes" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#087fca" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#087fca" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" Wrap="false" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <%--archivos javascripts que se utilizan en el sistema--%>
        <script src="../../Scripts/jquery-3.1.1.min.js"></script>
        <script src="../../bootstrap/js/bootstrap.min.js"></script>
        <script src="../../Scripts/toastr.min.js"></script>
        <script src="../../Scripts/gridviewScroll.min.js"></script>
    </form>
</body>
</html>
