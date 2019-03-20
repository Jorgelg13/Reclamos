
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wbFrmConsultaDaños.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmBusquedaReclamosDaños" %>
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
    <title>Consulta Reclamos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron titulo-cabecera" style="height: 115px;">
             <a href="/MdBitacora/DashboardUnity.aspx" style="color:white">
            <h2 style="width: 381px; padding-bottom: 20px;">Reclamos Daños Unity Promotores</h2>
            </a>
            <header>
                <div class="content-wrapper">
                    <div class="float-right">
                        <div class="img-float-right" style="float: right;">
                            <img src="../imgUnity/Unity%20Promotores-%20Logo%20en%20blanco.png" style="margin-top: -90px; width: 235px;">
                        </div>
                    </div>
                </div>
            </header>
        </div>
        <br />
        <br />
        <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading"><b>Busqueda De Reclamos de daños varios</b></div>
            <div class="panel-body">
                <div class=" form-inline">
                    <asp:TextBox runat="server" autocomplete="off" ID="txtBusqueda" Style="width: 25%" class="form-control" placeholder="Escriba una opcion de busqueda" data-toggle="tooltip" data-placement="top"></asp:TextBox>
                    <asp:DropDownList CssClass="form-control" ID="DDLTipo" Style="width: 15%" Height="34px" runat="server" CausesValidation="True">
                        <asp:ListItem Value="reclamos_varios.id">Id</asp:ListItem>
                        <asp:ListItem Value="poliza">Poliza</asp:ListItem>
                        <asp:ListItem Value="asegurado">Asegurado</asp:ListItem>
                        <asp:ListItem Value="num_reclamo">No. Reclamo</asp:ListItem> 
                        <asp:ListItem Value="cliente">Cliente</asp:ListItem> 
                    </asp:DropDownList>
                    <asp:Button runat="server" Text="Buscar" ID="btnBuscar" class="btn btn-primary" OnClick="btnBuscar_Click" />
                    <asp:Button runat="server" Text="Inicio" ID="btnInicio" class="btn btn-primary" OnClick="btnInicio_Click"/>
                </div>
                <div class="scrolling-table-container">
                    <asp:GridView ID="GridBusquedaGeneral" runat="server" AllowPaging="true" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridBusquedaGeneral_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:CommandField>
                        </Columns>
                        <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
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
        <script src="../Scripts/summernote.min.js"></script>
        <script src="../Scripts/jQuery.print.min.js"></script>
        <script src="../Scripts/app.js"></script>
    </form>
</body>
</html>
