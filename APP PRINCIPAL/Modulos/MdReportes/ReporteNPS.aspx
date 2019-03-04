<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="ReporteNPS.aspx.cs" Inherits="Modulos_MdReportes_ReporteNPS" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-sm-12">
        <div class="panel panel-info">
            <div class="panel-heading">
                <b>Total de registros<asp:Label runat="server" ID="lbltotal"></asp:Label></b>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="form-group col-sm-12 col-md-6 col-lg-3">
                        <label>Seleccionar Busqueda:</label>
                        <asp:DropDownList ID="ddlElegir" runat="server" Style="width: 100%" CssClass="form-control">
                            <asp:ListItem Value="1">Autos</asp:ListItem>
                            <asp:ListItem Value="2">Daños</asp:ListItem>
                            <asp:ListItem Value="3">Gastos Medicos</asp:ListItem>
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
                    <div class="form-group col-sm-12 col-md-1 col-lg-1">
                        <label></label>
                        <asp:Button ID="btnBuscar" CssClass="btn btn-primary" Style="width: 100%" runat="server" Text="Buscar" OnClick="btnBuscar_Click"></asp:Button>
                        
                    </div>
                    <div class="form-group col-sm-12 col-md-1 col-lg-1">
                        <label></label>
                         <asp:LinkButton ID="linkDescargar" OnClick="linkDescargar_Click" title="Descargar en excel" runat="server" 
                             Style="font-size: 47px; color: green;"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                    </div>
                </div>
                <asp:Panel runat="server" ID="PanelPrincipal">
                    <div class="scrolling-table-container" style="overflow-y: auto;">
                        <asp:GridView ID="GridNPS" runat="server" CssClass="table bs-table table-responsive" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None" PageSize="3000">
                            <AlternatingRowStyle BackColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="true" />
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentJs" runat="Server">
</asp:Content>

