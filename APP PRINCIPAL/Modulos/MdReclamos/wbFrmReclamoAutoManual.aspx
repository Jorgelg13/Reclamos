<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmReclamoAutoManual.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmInsertarAutoManual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class="container">
        <div class="panel panel-default col-sm-12">
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Ingresar Datos Auto</a></li>
                <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Ingresar Datos Reportante</a></li>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="home">
                    <div class="panel-body">
                        <div class=" form-inline">
                            <div class="panel-body form-inline">
                                <br />
                                <asp:TextBox runat="server" ID="txtPropietario" autocomplete="off" Style="width: 30%" class="form-control" placeholder="Nombre Propiertario"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtPlaca" autocomplete="off" Style="width: 25%" class="form-control" placeholder="Placa"></asp:TextBox>
                                <asp:DropDownList CssClass="form-control" ID="ddlAseguradora" Style="width: 40%" Height="34px" runat="server">
                                </asp:DropDownList>
                                <br />
                                <br />
                                <asp:TextBox runat="server" ID="txtEmpresa" autocomplete="off" Style="width: 25%" Height="34px" class="form-control" placeholder="Empresa"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtPoliza" autocomplete="off" Style="width: 20%" class="form-control" placeholder="No. poliza"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtChasis" autocomplete="off" Style="width: 25%" Height="34px" class="form-control" placeholder="No. chasis"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtMotor" autocomplete="off" Style="width: 25%" Height="34px" class="form-control" placeholder="No. Motor"></asp:TextBox>
                                <br />
                                <br />
                                <asp:TextBox runat="server" ID="txtMarca" autocomplete="off" Style="width: 40%" class="form-control" placeholder="Marca Vehiculo"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtColor" autocomplete="off" Style="width: 30%" class="form-control" placeholder="Color"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtEjecutivo" autocomplete="off" Style="width: 25%" class="form-control" placeholder="ejecutivo"></asp:TextBox>
                                 <br />
                                <br />
                                <asp:CheckBox runat="server" ID="checkProductosAlimenticios" OnCheckedChanged="checkProductosAlimenticios_CheckedChanged" AutoPostBack="true"  Style="width: 50%" class="form-control" Text="Fábrica de Productos Alimenticios René"></asp:CheckBox>
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="messages">
                    <div class="panel-body form-inline">
                        <br />
                        <asp:TextBox runat="server" ID="txtReportante" autocomplete="off" Style="width: 30%" class="form-control" placeholder="Reportante"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtTelefono" autocomplete="off" Style="width: 25%" class="form-control" placeholder="Telefono"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtUbicacion" autocomplete="off" Style="width: 40%" class="form-control" placeholder="Ubicacion"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox runat="server" type="date" ID="txtFecha" autocomplete="off" Style="width: 30%" Height="34px" class="form-control" placeholder="Fecha"></asp:TextBox>
                        <asp:TextBox runat="server" type="time" ID="txtHora" autocomplete="off" Style="width: 15%" Height="34px" class="form-control" placeholder="Hora del incidente"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtpiloto" autocomplete="off" Style="width: 50%" class="form-control" placeholder="piloto"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox runat="server" ID="txtBoleta" autocomplete="off" Style="width: 19%" class="form-control" placeholder="Numero de boleta"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtAjustador" autocomplete="off" Style="width: 25%" class="form-control" placeholder="Ajustador"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtTitular" autocomplete="off" Style="width: 25%" class="form-control" placeholder="Titular"></asp:TextBox>
                        <asp:DropDownList CssClass="form-control" ID="DDLTipo" Style="width: 25%" Height="34px" runat="server">
                            <asp:ListItem>Accidente</asp:ListItem>
                            <asp:ListItem>Asistencia Vehicular</asp:ListItem>
                            <asp:ListItem>Robo</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:TextBox runat="server" ID="txtVersion" autocomplete="off" Style="width: 95%" class="form-control" placeholder="Version"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button runat="server" Text="Guardar Reclamo" ID="txtGuardarReclamo" class="btn btn-primary" OnClick="txtGuardarReclamo_Click" />
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>
          <div class="modal fade" id="modal-recordatorio">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title"><b>Recordatorio Unity-Pepsico</b></h4>
                </div>
                <div class="modal-body">
                    <ul>
                        <li>
                            <h4>Estimado usuario, le recordamos que es importante reportar esta emergencia en el chat Unity-Pepsico</h4>
                        </li>
                    </ul>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

