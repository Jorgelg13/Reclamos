<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="aperturar-reclamos.aspx.cs" Inherits="Modulos_MdReclamosUnity_aperturar_reclamos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading"><b>Reaperturar Reclamos</b></div>
            <div class="panel-body">
                  <div class=" form-inline">
                    <asp:TextBox runat="server" autocomplete="off" ID="txtBusqueda" Style="width: 25%" class="form-control" placeholder="Escriba una opcion de busqueda" 
                        data-toggle="tooltip"></asp:TextBox>
                    <asp:DropDownList CssClass="form-control" ID="DDLTipo" Style="width: 15%" Height="34px" runat="server" CausesValidation="True">
                        <asp:ListItem Value="r.id">ID</asp:ListItem> 
                        <asp:ListItem Value="reg.poliza">Poliza</asp:ListItem>
                        <asp:ListItem Value="reg.asegurado">Asegurado</asp:ListItem>
                        <asp:ListItem Value="r.num_reclamo">No. de reclamo de Aseguradora</asp:ListItem> 
                        <asp:ListItem Value="reg.cliente">Cliente</asp:ListItem> 
                    </asp:DropDownList>
                    <asp:Button runat="server" Text="Buscar" ID="Button1" class="btn btn-primary" OnClick="btnBuscar_Click" />
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
                        <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" Wrap="false" />
                        <PagerStyle BackColor="#48086f" ForeColor="White" HorizontalAlign="Center" />
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

