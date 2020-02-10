<%@ Page Title="Busqueda Reclamos Daños" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbFrmBusquedaReclamosDaños.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmBusquedaReclamosDaños" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading"><b>Busqueda De Reclamos</b></div>
            <div class="panel-body">
                <div class=" form-inline">
                    <asp:TextBox runat="server" autocomplete="off" ID="txtBusqueda" Style="width: 25%" class="form-control" placeholder="Escriba una opcion de busqueda" 
                        data-toggle="tooltip"></asp:TextBox>
                    <asp:DropDownList CssClass="form-control" ID="DDLTipo" Style="width: 15%" Height="34px" runat="server" CausesValidation="True">
                        <asp:ListItem Value="poliza">Poliza</asp:ListItem>
                        <asp:ListItem Value="asegurado">Asegurado</asp:ListItem>
                        <asp:ListItem Value="num_reclamo">No. Reclamo</asp:ListItem> 
                        <asp:ListItem Value="cliente">Cliente</asp:ListItem> 
                    </asp:DropDownList>
                     <asp:DropDownList CssClass="form-control" ID="ddlEstado" Style="width: 15%" Height="34px" runat="server" CausesValidation="True">
                        <asp:ListItem Value="seguimiento">Seguimiento</asp:ListItem>
                        <asp:ListItem Value="cerrado">Cerrado</asp:ListItem>
                    </asp:DropDownList>

                    <asp:Button runat="server" Text="Buscar" ID="btnBuscar" class="btn btn-primary" OnClick="btnBuscar_Click" />
                </div>
                <div class="scrolling-table-container">
                    <asp:GridView ID="GridBusquedaGeneral" runat="server" AllowPaging="true" CssClass="table bs-table table-responsive table-hover" 
                        AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridBusquedaGeneral_SelectedIndexChanged" PageSize="600">
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
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

