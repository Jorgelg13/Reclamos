<%@ Page Title="" Language="C#" MasterPageFile="~/Consultas/vifrio/MasterPage.master"  EnableEventValidation="false" AutoEventWireup="true" CodeFile="reporte.aspx.cs" Inherits="Consultas_vifrio_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
        <div class="panel panel-info">
            <h2>Reporte</h2>
            <div class="panel-body">
                <div class="scrolling-table-container">
                    <asp:GridView ID="GridGeneral" runat="server" CssClass="table bs-table table-responsive table-hover " AutoGenerateColumns="True" ForeColor="#333333" GridLines="None" AllowCustomPaging="True" PageSize="3000">
                        <AlternatingRowStyle BackColor="White" />
                        <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </div>
         <asp:LinkButton ID="linkDescargar" OnClick="linkDescargar_Click" title="Descargar en excel" runat="server" Style="font-size: 70px; text-align: center; color:green" Text="descargar"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
    </div>
</asp:Content>

