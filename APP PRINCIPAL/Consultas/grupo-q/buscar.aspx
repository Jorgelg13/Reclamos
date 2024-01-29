<%@ Page Title="Grupo Q" Language="C#" MasterPageFile="~/Consultas/grupo-q/MasterPage.master" AutoEventWireup="true" CodeFile="buscar.aspx.cs" Inherits="Consultas_vifrio_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row justify-content-md-center" style="justify-content:center">
            <img src="../../imgUnity/wtw_logo.png" />
        </div>
        <div class="row justify-content-md-center"  style="justify-content:center">
            <div class="col col-auto margen-container margen-container-movil" style="min-width:350px">
                <h4>Buscar Asegurado</h4>
                <div class="input-group mb-3">
                    <asp:TextBox runat="server" autocomplete="off" ID="txtBusqueda" class="form-control" placeholder="buscar por poliza, placa o chasis"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:Button runat="server" Text="Buscar" ID="btnBuscar" class="input-group-text" OnClick="btnBuscar_Click" />
                    </div>
                </div>
                <asp:GridView CssClass="table table-striped scrolling-table-container table-responsive "
                    ID="GridBuscar"
                    runat="server"
                    AutoGenerateColumns="True"
                    ForeColor="#333333"
                    GridLines="None"
                    OnSelectedIndexChanged="GridBuscar_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
                    </Columns>
                    <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                    <RowStyle Wrap="false" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                </asp:GridView>
                <div class="controles-guardar">
                    <asp:DropDownList CssClass="form-control" ID="ddlServicio" runat="server" Visible="false">
                        <asp:ListItem>Mano de obra</asp:ListItem>
                        <asp:ListItem>Repuestos</asp:ListItem>
                        <asp:ListItem>Pintura</asp:ListItem>
                    </asp:DropDownList>
                    <div class="input-group-append">
                        <asp:Button runat="server" Text="Guardar" ID="btnGuardar" class="input-group-text" Visible="false" OnClick="btnGuardar_Click" />
                    </div>
                </div>
                <br />
                <asp:Panel ID="panelSuccess" runat="server" Visible="false">
                    <div class="alert alert-success" role="alert">
                        <asp:Label ID="lblSuccess" runat="server" Text="Label"></asp:Label>
                    </div>
                </asp:Panel>
                <asp:Panel ID="panelError" runat="server" Visible="false">
                    <div class="alert alert-danger" role="alert">
                        <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
