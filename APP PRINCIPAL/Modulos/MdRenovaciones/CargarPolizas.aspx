<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Renovaciones.master" AutoEventWireup="true" CodeFile="CargarPolizas.aspx.cs" Inherits="Modulos_MdRenovaciones_CargarPolizas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading"><b>Listado de polizas</b></div>
            <div class="panel-body">
                <div class="form-inline">
                    <asp:FileUpload ID="Archivo" CssClass="btn btn-file" runat="server" />
                    <asp:Button ID="btnUpload" CssClass="btn btn-primary" runat="server" Text="Subir Archivo" OnClick="btnUpload_Click" />
                    <asp:Button ID="btnInsertar" CssClass="btn btn-primary" runat="server" Text="Insertar" OnClick="btnInsertar_Click" />
                    <asp:Label runat="server" ID="lblMensaje"></asp:Label>
                </div>
                <asp:RadioButtonList ID="rbHDR" runat="server" Visible="false">
                    <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                </asp:RadioButtonList>
                <div class="scrolling-table-container">
                    <asp:GridView ID="GridCargas" runat="server" CssClass="table bs-table table-responsive" AutoGenerateColumns="true"
                        ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" Wrap="false" />
                        <RowStyle BackColor="#EFF3FB" Wrap="false" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentJS" runat="Server">
</asp:Content>

