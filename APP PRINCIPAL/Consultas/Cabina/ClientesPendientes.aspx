<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ClientesPendientes.aspx.cs" Inherits="Consultas_Cabina_ClientesPendientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../css/estilos.css" rel="stylesheet" />
    <link href="../../Scripts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../css/toastr.min.css" rel="stylesheet" />
    <link href="../../css/GridviewScroll.css" rel="stylesheet" />
    <title>Clientes Pendientes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron titulo-cabecera" style="height: 100px; background-color: #087fca">
            <h2 style="width: 781px; padding-bottom: 20px;">Clientes Pendientes</h2>
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
        <br />
        <div class="container-fluid">
            <div class="row">
                <div class="form-group col-lg-2 col-md-2 col-sm-12">
                    <label for="message-text" class="control-label">Fecha Inicio:</label>
                    <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-lg-2 col-md-2 col-sm-12">
                    <label class="control-label">Fecha Fin:</label>
                    <asp:TextBox ID="txtFechaFin" type="date" Height="34px" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-lg-2 col-md-2 col-sm-12">
                    <label class="control-label">Empresa:</label>
                    <asp:DropDownList ID="ddlEstado" runat="server" Style="width: 100%" Height="34px" CssClass="form-control">
                        <asp:ListItem Value="p">Pendientes</asp:ListItem>
                        <asp:ListItem Value="a">Atendidos</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group  col-lg-2 col-md-2 col-sm-12">
                    <asp:Button runat="server" ID="btnAtendidos" OnClick="btnAtendidos_Click" BackColor="#087fca" Style="margin-top: 24px;" Text="Atendidos" CssClass="btn btn-primary" />
                </div>
            </div>
            <asp:Panel runat="server" ID="PnPrincipal">
                <div class="col-sm-12 col-md-12 col-lg-12">
                    <br />
                    <div class="scrolling-table-container">
                        <asp:Label runat="server" ID="lblTotal"></asp:Label>
                        <asp:LinkButton ID="linkDescargar" Visible="false" title="Descargar en excel" runat="server" Style="font-size: 20px; text-align: center; color: green"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                        <asp:GridView ID="GridPendientes" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="Seleccionar">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="checkAsignar" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#087fca" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#087fca" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" Wrap="false" />
                        </asp:GridView>
                    </div>
                </div>
            </asp:Panel>
        </div>

        <%--archivos javascripts que se utilizan en el sistema--%>
        <script src="../../Scripts/jquery-3.1.1.min.js"></script>
        <script src="../../bootstrap/js/bootstrap.min.js"></script>
        <script src="../../Scripts/toastr.min.js"></script>
        <script src="../../Scripts/gridviewScroll.min.js"></script>
    </form>
</body>
</html>
