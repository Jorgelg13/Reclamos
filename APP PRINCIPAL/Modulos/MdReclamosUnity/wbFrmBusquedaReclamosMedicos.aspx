<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbFrmBusquedaReclamosMedicos.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmBusquedaReclamosMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading"><b>Busqueda De Reclamos</b></div>
            <div class="panel-body">
                <div class=" form-inline">
                    <asp:TextBox runat="server" autocomplete="off" ID="txtBusqueda" Style="width: 25%" class="form-control" placeholder="Escriba una opcion de busqueda" data-toggle="tooltip" data-placement="top"></asp:TextBox>
                    <asp:DropDownList CssClass="form-control" ID="DDLTipo" Style="width: 15%" Height="34px" runat="server" CausesValidation="True">
                        <asp:ListItem Value="dbo.reg_reclamos_medicos.poliza">Poliza</asp:ListItem>
                        <asp:ListItem Value="dbo.reclamos_medicos.asegurado">Asegurado</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button runat="server" Text="Buscar" ID="btnBuscar" class="btn btn-primary" OnClick="btnBuscar_Click" />
                </div>
                <div class="scrolling-table-container">
                    <asp:GridView ID="GridBusquedaGeneral" EmptyDataText="No se encontro ese registro" runat="server" AllowPaging="true" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="300" OnSelectedIndexChanged="GridBusquedaGeneral_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:CommandField>
                        </Columns>
                        <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

