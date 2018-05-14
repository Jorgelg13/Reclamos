<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmAutorizacionManual.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmAutorizacionManual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class="container">
        <div class="panel panel-default col-sm-12">
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Ingresar Datos Poliza </a></li>
                <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Ingresar Datos</a></li>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="home">
                    <div class="panel-body">
                        <div class=" form-inline">
                            <asp:TextBox runat="server" ID="txtPoliza" autocomplete="off" Style="width: 45%" class="form-control" placeholder="No. de poliza"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtAsegurado" autocomplete="off" Style="width: 50%" class="form-control" placeholder="Nombre asegurado"></asp:TextBox>
                            <br />
                            <br />
                            <asp:TextBox runat="server" ID="txtEjecutivo" autocomplete="off" Style="width: 50%" class="form-control" placeholder="Ejecutivo de la cuenta"></asp:TextBox>
                           <asp:DropDownList CssClass="form-control" ID="ddlAseguradora" Style="width: 45%" Height="34px" runat="server">
                           </asp:DropDownList>
                            <br />
                            <br />
                        </div>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="messages">
                    <div class="panel-body form-inline">
                        <br />
                        <asp:TextBox runat="server" ID="txtReportante" autocomplete="off" Style="width: 45%" class="form-control" placeholder="Reportante"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtCorreo" autocomplete="off" Style="width: 45%" class="form-control" placeholder="Correo Electronico"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox runat="server" type="" ID="txtTelefono" autocomplete="off" Style="width: 15%" Height="34px" class="form-control" placeholder="Telefono"></asp:TextBox>
                        <asp:DropDownList CssClass="form-control" ID="DDLTipo" Style="width: 35%" Height="34px" runat="server">
                            <asp:ListItem>Medicamentos</asp:ListItem>
                            <asp:ListItem>Laboratorios y Examenes especiales</asp:ListItem>
                            <asp:ListItem>Procedimientos</asp:ListItem>
                            <asp:ListItem>Hospitalizaciones</asp:ListItem>
                            <asp:ListItem>Fisioterapias</asp:ListItem>
                            <asp:ListItem>Control de niño sano</asp:ListItem>
                            <asp:ListItem>Dental</asp:ListItem>
                            <asp:ListItem>Otros</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList CssClass="form-control" ID="DDLEstado" Style="width: 25%" Height="34px" runat="server">
                            <asp:ListItem>Revision</asp:ListItem>
                            <asp:ListItem>Aseguradora</asp:ListItem>
                            <asp:ListItem>Asegurado</asp:ListItem>
                            <asp:ListItem>Enviado</asp:ListItem>
                            <asp:ListItem>Cerrado</asp:ListItem>
                            <asp:ListItem>Anulado</asp:ListItem>
                        </asp:DropDownList>
                        <asp:CheckBox ID="checkTramiteDirecto" Text="Tramite Directo" runat="server" Style="width: 15%; padding-left: 20px;" />
                        <br />
                        <br />
                        <asp:Button runat="server" Text="Guardar Autorizacion" ID="btnGuardarAutorizacion" class="btn btn-primary" OnClick="btnGuardarAutorizacion_Click" />
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

