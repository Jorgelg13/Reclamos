<%@ Page Title="" Language="C#" MasterPageFile="~/Consultas/vifrio/MasterPage.master" AutoEventWireup="true" CodeFile="buscar.aspx.cs" Inherits="Consultas_vifrio_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row justify-content-md-center" style="justify-content:center">
            <img src="../../imgUnity/unity-wtw2.png" />
        </div>
        <div class="row justify-content-md-center"  style="justify-content:center">
            <div class="col col-auto margen-container margen-container-movil">
                <h4>Buscar poliza</h4>
                <div class="input-group mb-3">
                    <asp:TextBox runat="server" autocomplete="off" ID="txtBusqueda" class="form-control" placeholder="placa del vehiculo"></asp:TextBox>
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
                    <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                    <RowStyle Wrap="false" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                </asp:GridView>
                <div class="controles-guardar">
                    <asp:DropDownList CssClass="form-control" ID="ddlServicio" runat="server" Visible="false">
                        <asp:ListItem>Seleccionar servicio</asp:ListItem>
                        <asp:ListItem>Cambio de aceite de motor</asp:ListItem>
                        <asp:ListItem>Servicios Preventivos</asp:ListItem>
                        <asp:ListItem>Mano de obra mecánica</asp:ListItem>
                        <asp:ListItem>Cambio de aceite de caja automática </asp:ListItem>
                        <asp:ListItem>Cambio de líquido refrigerante</asp:ListItem>
                        <asp:ListItem>Cambio de líquido de frenos </asp:ListItem>
                        <asp:ListItem>Limpieza de motor</asp:ListItem>
                        <asp:ListItem>Cambio de líquido de caja mecánica</asp:ListItem>
                        <asp:ListItem>Cambio de líquido motor</asp:ListItem>
                        <asp:ListItem>Limpieza de A/C</asp:ListItem>
                        <asp:ListItem>Carga A/C</asp:ListItem>
                        <asp:ListItem>Repuestos</asp:ListItem>
                        <asp:ListItem>Baterías</asp:ListItem>
                        <asp:ListItem>Accesorios (Tunning)</asp:ListItem>
                        <asp:ListItem>Car Wash</asp:ListItem>
                        <asp:ListItem>Detailing</asp:ListItem>
                        <asp:ListItem>Producto Retail Chemical Guys</asp:ListItem>
                        <asp:ListItem>Plumillas</asp:ListItem>
                        <asp:ListItem>Polarizado</asp:ListItem>
                        <asp:ListItem>Alineación</asp:ListItem>
                        <asp:ListItem>Balanceo</asp:ListItem>
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
