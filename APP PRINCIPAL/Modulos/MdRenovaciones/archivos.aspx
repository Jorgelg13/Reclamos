<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Renovaciones.master" AutoEventWireup="true" CodeFile="archivos.aspx.cs" Inherits="Modulos_MdRenovaciones_archivos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container-fluid">
        <asp:Button runat="server" ID="Guardar" Text="Mover" OnClick="Guardar_Click"/>
        <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 15px;">
            <asp:GridView ID="GridArchivos" CssClass="table bs-table table-responsive" runat="server" AutoGenerateColumns="True"
                ForeColor="#333333" GridLines="None" OnRowDataBound="GridArchivos_RowDataBound">
                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" Wrap="false" />
                <PagerStyle BackColor="#131B4D" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" Wrap="false" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentJS" runat="Server">
</asp:Content>

