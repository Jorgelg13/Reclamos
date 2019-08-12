<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmAutorizaciones.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmAutorizaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-default col-sm-12">
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Buscar Asegurado </a></li>
                <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Ingresar Datos</a></li>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="home">
                    <div class="panel-body">
                        <div class=" form-inline">
                            <asp:TextBox runat="server" autocomplete="false" ID="txtBusqueda" Style="width: 30%" class="form-control" placeholder="Escriba no. de poliza"></asp:TextBox>
                            <asp:Button runat="server" Text="Buscar Poliza" ID="btnBuscar" class="btn btn-primary" OnClick="btnBuscar_Click" />
                        </div>
                        <br />
                        <div class="scrolling-table-container">
                            <asp:GridView ID="GridAutorizaciones" CssClass="table bs-table table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridAutorizaciones_SelectedIndexChanged" AllowSorting="True">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSourceAutorizaciones" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="select  *from vistaReclamosMedicos where (poliza like '%'+ @poliza +'%') OR (asegurado COLLATE Latin1_General_CI_AI  like '%' + @asegurado + '%') OR (contratante COLLATE Latin1_General_CI_AI  like '%' + @contratante + '%')">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtBusqueda" Name="poliza" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtBusqueda" Name="asegurado" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtBusqueda" Name="contratante" PropertyName="Text" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="messages">
                    <div class="panel-body">
                        <br />
                        <div class="form-group col-sm-12 col-md-4 col-lg-4">
                            <label>Reportante:</label>
                            <asp:TextBox runat="server" autocomplete="off" ID="txtReportante" Style="width: 100%" class="form-control" placeholder="Reportante"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-4 col-lg-4">
                            <label>Correo:</label>
                            <asp:TextBox runat="server" autocomplete="off" ID="txtCorreo" Style="width: 100%" class="form-control" placeholder="Correo Electronico"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-4 col-lg-4">
                            <label>Telefono:</label>
                            <asp:TextBox runat="server" type="" autocomplete="off" ID="txtTelefono" Style="width: 100%" Height="34px" class="form-control" placeholder="Telefono"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-6 col-lg-6">
                            <label>Tipo autorizacion:</label>
                            <asp:DropDownList CssClass="form-control" ID="DDLTipo" Style="width: 100%" Height="34px" runat="server">
                                <asp:ListItem>Medicamentos</asp:ListItem>
                                <asp:ListItem>Laboratorios y Examenes especiales</asp:ListItem>
                                <asp:ListItem>Procedimientos</asp:ListItem>
                                <asp:ListItem>Hospitalizaciones</asp:ListItem>
                                <asp:ListItem>Fisioterapias</asp:ListItem>
                                <asp:ListItem>Control de niño sano</asp:ListItem>
                                <asp:ListItem>Dental</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-sm-12 col-md-6 col-lg-6">
                            <label>Estado Autorizacion:</label>
                            <asp:DropDownList CssClass="form-control" ID="DDLEstado" Style="width: 100%" Height="34px" runat="server">
                                <asp:ListItem>Revision</asp:ListItem>
                                <asp:ListItem>Aseguradora</asp:ListItem>
                                <asp:ListItem>Asegurado</asp:ListItem>
                                <asp:ListItem>Enviado</asp:ListItem>
                                <asp:ListItem>Cerrado</asp:ListItem>
                                <asp:ListItem>Anulado</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:CheckBox ID="checkTramiteDirecto" Text="Tramite Directo" runat="server" Style="width: 15%; padding-left: 20px;" />
                        <asp:Button runat="server" Text="Guardar" ID="btnGuardarAutorizacion" class="btn btn-primary" OnClick="btnGuardarAutorizacion_Click" />
                        <asp:Button runat="server" Text="Agregar" ID="btnAgregarNueva" class="btn btn-primary" OnClick="btnAgregarNueva_Click" />
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

