<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Renovaciones.master" AutoEventWireup="true" CodeFile="Renovadas.aspx.cs" Inherits="Modulos_MdRenovaciones_Estados_Renovadas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 0px;">
            <asp:GridView ID="GridRenovadas" OnSelectedIndexChanged="GridRenovadas_SelectedIndexChanged" CssClass="table bs-table table-responsive" runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
                </Columns>
                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" Wrap="false" />
                <PagerStyle BackColor="#131B4D" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" Wrap="false" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentJS" Runat="Server">
</asp:Content>

