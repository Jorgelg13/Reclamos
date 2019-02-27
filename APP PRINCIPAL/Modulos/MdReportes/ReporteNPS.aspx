<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="ReporteNPS.aspx.cs" Inherits="Modulos_MdReportes_ReporteNPS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-sm-12">
        <div class="panel panel-info">
            <div class="panel-heading">
                <b>Tabla con campos seleccionados<spam style="margin-left: 50px">Total de registros:</spam><asp:Label ID="lblConteo" runat="server"></asp:Label></b>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="form-group col-sm-12 col-md-6 col-lg-3">
                        <label>Seleccionar Busqueda:</label>
                        <asp:DropDownList ID="ddlElegir" runat="server" Style="width: 100%" AutoPostBack="true" CssClass="form-control">
                            <asp:ListItem Value="auto_reclamo.asegurado">Autos</asp:ListItem>
                            <asp:ListItem Value="auto_reclamo.cliente">Daños</asp:ListItem>
                            <asp:ListItem Value="reclamo_auto.estado_auto_unity">Gastos Medicos</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group  col-sm-12 col-md-6 col-lg-2">
                        <label>Estado:</label>
                        <asp:DropDownList ID="ddlEstado" runat="server" Style="width: 100%" CssClass="form-control">
                            <asp:ListItem Value="Cerrado">Cerrado</asp:ListItem>
                            <asp:ListItem Value="Seguimiento">Seguimiento dentro del rango</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group  col-sm-12 col-md-6 col-lg-2">
                        <label>Fecha Inicio:</label>
                        <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group  col-sm-12 col-md-6 col-lg-2">
                        <label>Fecha Fin:</label>
                        <asp:TextBox ID="txtFechaFin" type="date" Height="34px" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                    </div>
                </div>
                <asp:Panel runat="server" ID="PanelPrincipal">
                    <div class="scrolling-table-container" style="overflow-y: auto;">
                        <asp:GridView ID="GridCamposSeleccion" runat="server" CssClass="table bs-table table-responsive" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None" PageSize="3000">
                            <AlternatingRowStyle BackColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentJs" runat="Server">
</asp:Content>

