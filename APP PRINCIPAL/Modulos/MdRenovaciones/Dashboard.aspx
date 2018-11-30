<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Renovaciones.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Modulos_MdRenovaciones_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active">
                <a href="#elRoble" aria-controls="elRoble" role="tab" data-toggle="tab">Polizas Roble
                </a>
            </li>
            <li role="presentation">
                <a href="#todasPolizas" aria-controls="todasPolizas" role="tab" data-toggle="tab">Todas las Polizas
                </a>
            </li>
        </ul>
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane active" id="elRoble">
                <div class="row">
                    <div class="form-group col-md-2 col-lg-2 col-sm-12" style="padding-top: 10px;">
                        <label>Estado:</label>
                        <asp:DropDownList CssClass="form-control" ID="ddlEstado" Style="width: 100%" Height="34px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLTipo_SelectedIndexChanged">
                            <asp:ListItem Value="2">Asignadas</asp:ListItem>
                            <asp:ListItem Value="3">Enviadas</asp:ListItem>
                            <asp:ListItem Value="4">Renovadas</asp:ListItem>
                            <asp:ListItem Value="5">Canceladas</asp:ListItem>
                            <asp:ListItem Value="6">No Enviadas</asp:ListItem>
                            <asp:ListItem Value="7">Facturadas</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group  col-sm-12 col-md-6 col-lg-2"  style="padding-top: 10px;">
                        <label>Fecha Inicio:</label>
                        <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group  col-sm-12 col-md-6 col-lg-2"  style="padding-top: 10px;">
                        <label>Fecha Fin:</label>
                        <asp:TextBox ID="txtFechaFin" type="date" Height="34px" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                    </div>
                    <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 0px;">
                        <asp:GridView ID="GridElRoble" OnSelectedIndexChanged="GridElRoble_SelectedIndexChanged" CssClass="table bs-table table-responsive" runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
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
            </div>
            <div role="tabpanel" class="tab-pane" id="todasPolizas">
                <div class="row">
                    <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 0px;">
                        <asp:GridView ID="GridAllPolizas" CssClass="table bs-table table-responsive" 
                            runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridAllPolizas_SelectedIndexChanged">
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
            </div>
        </div>
    </div>
</asp:Content>

