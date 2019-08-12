<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmAutorizacionManual.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmAutorizacionManual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class="container">
        <div class="panel panel-info col-sm-12">
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Ingresar Datos Poliza </a></li>
                <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Ingresar Datos</a></li>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="home">
                    <div class="panel-body">
                        <div class="form-group col-sm-12 col-md-6 col-lg-6">
                            <label>Poliza:</label>
                            <asp:TextBox runat="server" ID="txtPoliza" autocomplete="off" Style="width: 100%" class="form-control" placeholder="No. de poliza"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-6 col-lg-6">
                            <label>Asegurado:</label>
                            <asp:TextBox runat="server" ID="txtAsegurado" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Nombre asegurado"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-6 col-lg-6">
                            <label>Ejecutivo:</label>
                            <asp:TextBox runat="server" ID="txtEjecutivo" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Ejecutivo de la cuenta"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-6 col-lg-6">
                            <label>Aseguradora:</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlAseguradora" Style="width: 100%" Height="34px" runat="server">
                            </asp:DropDownList>
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
                        <asp:Button runat="server" Text="Agregar" ID="btnAgregarNueva" class="btn btn-primary" OnClick="btnAgregarNueva_Click"/>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

