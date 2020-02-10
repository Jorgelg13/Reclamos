<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="aperturar-reclamos.aspx.cs" Inherits="Modulos_MdReclamosUnity_aperturar_reclamos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading"><b>Reaperturar Reclamos</b></div>
            <div class="panel-body">
                <div class="form-group  col-sm-12 col-md-6 col-lg-2">
                    <label>Desde:</label>
                    <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                </div>
                <div class="form-group  col-sm-12 col-md-6 col-lg-2">
                    <label>Hasta:</label>
                    <asp:TextBox ID="txtFechaFin" type="date" Height="34px" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                </div>
                <div class="form-group  col-sm-12 col-md-6 col-lg-2" style="padding-top: 26px;">
                    <asp:Button runat="server" ID="btnBuscar" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />
                    <asp:Button runat="server" ID="btnAperturar" CssClass="btn btn-primary" Text="Reaperturar" OnClick="btnAperturar_Click" />
                </div>
                <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 0px;">
                    <asp:GridView ID="GridReclamos" CssClass="table bs-table table-responsive"
                        runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                        <Columns>
                            <asp:TemplateField HeaderText="Reaperturar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="checkReaperturar" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" Wrap="false" />
                        <PagerStyle BackColor="#131B4D" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" Wrap="true" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentJs" runat="Server">
</asp:Content>

