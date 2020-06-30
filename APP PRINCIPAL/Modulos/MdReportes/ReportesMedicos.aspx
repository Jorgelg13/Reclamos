<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportesMedicos.aspx.cs" Inherits="ReportesMedicos" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../css/estilos.css" rel="stylesheet" />
    <link href="../../Scripts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <title>Reportes Medicos</title>
</head>
<body>
    <div class="jumbotron titulo-cabecera">
        <h2 style="width: 781px; padding-bottom: 20px;">Reclamos Unity Promotores</h2>
        <header>
            <div class="content-wrapper">
            </div>
        </header>
    </div>
    <br />
     <form id="form1" runat="server">
          <div class="container-fluid">
            <div class="panel panel-info">
                <div class="panel-heading"><b>Reporte de Autorizaciones</b></div>
                <div class="panel-body" style="padding:6px;">
                    <div class="panel-body form-inline">
                        <asp:Label ID="Label1" runat="server" Text="Fecha Inicio:   "></asp:Label>
                        <asp:TextBox ID="txtFechaInicio" CssClass="form-control" Height="34px" type="date" runat="server"></asp:TextBox>
                        <asp:Label ID="Label2" runat="server" Text="Fecha Final:   "></asp:Label>
                        <asp:TextBox ID="txtFechaFin" CssClass="form-control" Height="34px" type="date" runat="server"></asp:TextBox>
                        <asp:DropDownList runat="server" ID="ddlTipoFecha" CssClass="form-control">
                            <asp:ListItem Value="1">Fecha Registro</asp:ListItem>
                            <asp:ListItem Value="2">Fecha Cierre</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                        <asp:Button ID="btnRegresar" runat="server" Text="Inicio" CssClass="btn btn-primary" OnClick="btnRegresar_Click" />
                        <asp:LinkButton ID="linkDescargar" OnClick="linkDescargar_Click" title="Descargar en excel" runat="server" Style="font-size: 30px; text-align: center; color:green; padding:0px;"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
                    </div>
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridMedicos" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
