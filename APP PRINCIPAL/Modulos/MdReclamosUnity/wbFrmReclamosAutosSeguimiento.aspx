﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbFrmReclamosAutosSeguimiento.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmReclamosAutosSeguimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="">
        <asp:Label ID="lblID" runat="server" Text="Label" Visible="false"></asp:Label>
        <div class="panel panel-default col-sm-12">
            <div class="img-float-right" style="float: right; padding-top: 15px;">
                <asp:Label runat="server" ID="lblProximaFecha" Style="padding-right: 30px; font-size: 16px;"></asp:Label>
                <label>Estado: </label>
                <asp:Label runat="server" ID="lblEstadoReclamo" Style="padding-right: 50px; font-size: 16px;"></asp:Label>
            </div>
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="home">
                    <a href="#home" aria-controls="home" role="tab" data-toggle="tab">Informacion General</a>
                </li>
                <li role="presentation" class="profile">
                    <a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">LLamadas En Cabina</a>
                </li>
                <li role="presentation" class="coberturas">
                    <a href="#coberturas" aria-controls="coberturas" role="tab" data-toggle="tab">Seguimiento</a>
                </li>
                <li role="presentation" class="ingreso-datos">
                    <a href="#ingreso-datos" aria-controls="ingreso-datos" role="tab" data-toggle="tab">Liquidacion</a>
                </li>
            </ul>
            <%-- contiene textbox que no se visualisan pero q contienen registros que son utilizados en algunos metodos--%>
            <div>
                <asp:TextBox ID="txtEjecutivo" Visible="false" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtTiempo" Style="display: none" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtGestor" Visible="false" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtGestorTelefono" Visible="false" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtFechaSiniestro" Visible="false" runat="server"></asp:TextBox>
                <asp:Label ID="lblNombreAsegurado" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="lblNumeroPoliza" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="lblDireccionAsegurado" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="lblEstadoAuto" Visible="false" runat="server"></asp:Label>
            </div>
            <%---------------------------------------------------------------------------------------------------%>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane" id="home">
                    <br />
                    <div class="panel panel-info col-lg-3 col-md-3 col-sm-12">
                        <div class="panel-heading" role="tab" id="heading1">
                            <h4 class="panel-title">
                                <b>Datos Del Auto</b>
                            </h4>
                        </div>
                        <div class="panel-body">
                            <div class="form-inline">
                                <label>Placa:</label>
                                <asp:TextBox ID="txtPlaca" Enabled="false" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                <label>Marca:</label>
                                <asp:TextBox ID="txtMarca" Enabled="false" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                <label>Color:</label>
                                <asp:TextBox ID="txtColor" Enabled="false" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                <label>Modelo:</label>
                                <asp:TextBox ID="txtModelo" Enabled="false" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                <label>Chasis:</label>
                                <asp:TextBox ID="txtChasis" Enabled="false" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                <label>Motor:</label>
                                <asp:TextBox ID="txtMotor" Enabled="false" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                <label>Propietario:</label>
                                <asp:TextBox ID="txtPropietario" Enabled="false" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                <asp:CheckBox ID="checkDatosAutos" AutoPostBack="true" runat="server" Text="Editar" OnCheckedChanged="checkDatosAutos_CheckedChanged" />
                                <asp:LinkButton ID="ActualizarDatos" OnClick="ActualizarDatos_Click" title="Guardar" runat="server" Style="font-size: 30px;"><i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <%----------------- seccion de datos de la poliza en general ------------------------------%>
                    <div class="panel panel-info col-md-4 col-lg-4 col-sm-12">
                        <div class="panel-heading" role="tab" id="headingTwo">
                            <h4 class="panel-title">
                                <b>Datos De La Poliza</b>
                            </h4>
                        </div>
                        <div class="panel-body">
                            <div class="panel-body form-inline">
                                <asp:Label ID="lblPoliza" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblAsegurado" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblcliente" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblEjecutivo" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblAseguradora" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblContratante" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblEstado" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblPrograma" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblTitular" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblVigi" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblVigf" runat="server"></asp:Label>
                                <br />
                            </div>
                        </div>
                    </div>
                    <%--------------------------------  coberturas afectadas del reclamos--------------------------------------%>
                    <div class="panel panel-info col-sm-12 col-md-5 col-lg-5">
                        <div class="panel-heading" role="tab" id="headingTree">
                            <h4 class="panel-title">
                                <b>Coberturas Afectadas</b>
                            </h4>
                        </div>
                        <div class="panel-body">
                            <div style="overflow-y: auto; overflow-x: auto;">
                                <asp:GridView ID="GridCoberturasAfectadas" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                </asp:GridView>
                            </div>
                            <asp:Button ID="coberturaADD" OnClientClick="return false;" runat="server" data-toggle="modal" data-target="#ModalCobertura" CssClass="btn btn-primary" Text="Agregar" />
                        </div>
                    </div>
                </div>
                <%-- tabla que contiene las llamadas echas en cabina--%>
                <div role="tabpanel" class="tab-pane" id="profile">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <br />
                        <div class="scrolling-table-container col-sm-12 col-md-6 col-lg-6">
                            <b><span style="font-size: 20px">LLamadas Realizadas en cabina</span></b>
                            <asp:GridView ID="Gridllamadas" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                            </asp:GridView>
                        </div>
                        <div class="scrolling-table-container col-sm-12 col-md-6 col-lg-6">
                            <b><span style="font-size: 20px">Datos Acerca Del Siniestro</span></b>
                            <asp:GridView ID="GridDatosAccidente" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <%---------------------- tab que contiene el seguimiento del reclamo -----------------%>
                <div role="tabpanel" class="tab-pane" id="coberturas">
                    <div class="panel-body form-inline col-lg-6 col-md-6">
                        <div style="height: 275px;" class="panel panel-info col-sm-5 col-md-12 col-lg-4">
                            <div class="panel-heading">
                                <b>Selecciones</b>
                            </div>
                            <div class="panel-body">
                                <asp:CheckBox ID="checkPrioritario" runat="server" Text="Prioritario" />
                                <br />
                                <asp:CheckBox ID="CheckComplicado" runat="server" Text="Complicado"/>
                                <br />
                                <asp:CheckBox ID="CheckPerdida" runat="server" Text="Perdida Total" AutoPostBack="True" OnCheckedChanged="CheckPerdida_CheckedChanged" />
                                <br />
                                <asp:CheckBox ID="ChecKAutoAlquiler" runat="server" Text="Alquiler De Auto" AutoPostBack="True" OnCheckedChanged="ChecKAutoAlquiler_CheckedChanged" />
                                <br />
                                <asp:CheckBox ID="checkCompromiso" runat="server" Text="Compromiso De Pago" />
                                <br />
                                <asp:CheckBox ID="checkCierreInterno" runat="server" Text="Cierre Interno" />
                                <br />
                                <asp:CheckBox ID="checkCerrarReclamo" runat="server" Text="Cerrar Reclamo" AutoPostBack="True" OnCheckedChanged="checkCerrarReclamo_CheckedChanged"  />
                            </div>
                        </div>
                        <div style="height: 275px; overflow-y: auto;" class="panel panel-info col-sm-7 col-md-12 col-lg-8">
                            <div class="panel-heading">
                                <b>Opciones Multiples</b>
                            </div>
                            <div class="panel-body">
                                <div class="form-inline">
                                    <label style="width: 15%">Estado:</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlEstadoAuto" Style="width: 80%" Height="34px" runat="server" DataSourceID="SqlDataSourceEstadosAutos" DataTextField="descripcion" DataValueField="descripcion" AutoPostBack="true" OnSelectedIndexChanged="ddlEstadoAuto_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <br />
                                <div class="form-inline">
                                    <label style="width: 15%">Analista:</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlAnalista" Style="width: 80%" Height="34px" runat="server" DataSourceID="SqlDataSourceAnalistas" DataTextField="nombre" DataValueField="id"></asp:DropDownList>
                                </div>
                                <br />
                                <div class="form-inline">
                                    <label style="width: 15%">Taller:</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlTaller" Style="width: 80%" Height="34px" runat="server" DataSourceID="SqlDataSourceTalleres" DataTextField="nombre" DataValueField="id"></asp:DropDownList>
                                </div>
                                <br />
                                <div class="form-inline">
                                    <label style="width: 15%">Gestor:</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlGestor" Style="width: 80%" Height="34px" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceGestores" DataTextField="nombre" DataValueField="id"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <%-- --------------------------------------- correos y comentarios-----------------------------------------%>
                        <div class="panel panel-info col-sm-12 col-md-12 col-lg-12 ">
                            <div class="panel-heading">
                                <b>Observaciones</b>
                            </div>
                            <div class="panel-body form-inline">
                                <asp:TextBox ID="txtObservaciones" Style="width: 100%" autocomplete="off" CssClass="form-control" TextMode="multiline" Columns="50" Rows="4" runat="server" placeholder="Observaciones" />
                                <asp:CheckBox ID="chCartaCierre" Text="Carta Cierre Interno" AutoPostBack="true" runat="server" OnCheckedChanged="chCartaCierre_CheckedChanged" />
                                <asp:CheckBox ID="chCartaDeclinado" Text="Carta Declinado" AutoPostBack="true" runat="server" OnCheckedChanged="chCartaDeclinado_CheckedChanged" />
                                <asp:CheckBox ID="chEnvioCarta" Text="Carta Envio Cheque" AutoPostBack="true" runat="server" OnCheckedChanged="chEnvioCarta_CheckedChanged" />
                                <br />
                            </div>
                        </div>
                    </div>
                    <%-- --------------------------------------- barra de iconos -----------------------------------------%>
                    <div class="panel panel-info col-sm-12 col-md-6 col-lg-6 ">
                        <div class="panel-body">
                            <div class="col-xs-3 col-sm-2 col-md-2 col-lg-1">
                                <a title="Agregar un comentario" data-toggle="modal" role="button" data-target="#ModalComentario" style="font-size: 40px;"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a data-toggle="modal" title="Enviar un correo electronico" role="button" data-target="#exampleModal" style="font-size: 40px;"><i class="fa fa-envelope-o" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Configurar Proxima fecha a mostrar" data-toggle="modal" role="button" data-target="#ModalProximaFecha" style="font-size: 40px; text-align: center;"><i class="fa fa-calendar-check-o" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Imprimir Memos" data-toggle="modal" role="button" data-target=".bs-example-modal-lg" style="font-size: 40px;"><i class="fa fa-print" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Datos del Contacto" data-toggle="modal" role="button" data-target="#ModalDatosContacto" style="font-size: 40px;"><i class="fa fa-user" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Datos del taller" data-toggle="modal" role="button" data-target="#ModalTaller" style="font-size: 40px;"><i class="fa fa-wrench" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Datos del Analista" data-toggle="modal" role="button" data-target="#ModalAnalista" style="font-size: 40px;"><i class="fa fa-male" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="tiempo total del reclamo" data-toggle="modal" role="button" data-target="#ModalTiempo" style="font-size: 40px;"><i class="fa fa-clock-o" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Bitacora del reclamo" onclick="printDiv('imprimirBitacora')" data-toggle="modal" role="button" data-target="#" style="font-size: 40px;"><i class="fa fa-file" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <asp:LinkButton ID="linkGuardarR" OnClick="btnActualizar_Click" title="Actualizar Informacion" runat="server" Style="font-size: 40px; text-align: center;"><i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
                            </div>
                             <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Producto no conforme" data-toggle="modal" role="button" data-target="#ModalNoconforme" style="font-size: 40px;"><i class="fa fa-frown-o" style="color:red" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <asp:LinkButton ID="linkRegresar" OnClick="linkRegresar_Click" title="Regresar a reclamos en seguimiento" runat="server" Style="font-size: 40px; text-align: center;"><i class="fa fa-arrow-left" aria-hidden="true"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <%------------------------------------ table de comentarios anteriores ---------------------------%>
                    <div class="panel panel-info col-md-6 col-lg-6 col-sm-12">
                        <div class="panel-heading">
                            <b>Comentarios Anteriores<asp:Label ID="lblIdReclamo" runat="server" Style="padding-left: 50px; font-size: 14px;"></asp:Label>
                                <asp:Label ID="lblNumReclamo" Text="No. Reclamo:" runat="server" Style="padding-left: 30px; font-size: 14px;"></asp:Label></b>
                            <asp:TextBox Style="width: 20%" ID="txtNumReclamo" Enabled="false" runat="server"></asp:TextBox>
                            <asp:CheckBox ID="checkHabilitar" AutoPostBack="true" runat="server" OnCheckedChanged="checkHabilitar_CheckedChanged" />
                        </div>
                        <div class="panel-body">
                            <div style="height: 300px; overflow-x: auto;" class="scrolling-table-container">
                                <asp:GridView ID="GridComentarios" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowDataBound="GridComentarios_RowDataBound">
                                    <AlternatingRowStyle BackColor="White" />
                                    <FooterStyle BackColor="White" ForeColor="black" />
                                    <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" HorizontalAlign="Left" Wrap="True" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- -------------------------- tabla de detalle de pagos----------------------------%>
                <div role="tabpanel" class="tab-pane" id="ingreso-datos">
                    <div class="form-inline">
                        <a runat="server" data-toggle="modal" role="button" data-target="#IngresarLiquidacion" id="lnPago" style="font-size: 40px;"><i class="fa fa-money"></i></a>
                        <asp:Label ID="lblPagoTotal" Style="font-size: 20px; padding-left: 3px;" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblMoneda" runat="server" Style="font-size: 17px;"></asp:Label>
                    </div>
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridPagosReclamos" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridPagosReclamos_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:CommandField>
                            </Columns>
                            <AlternatingRowStyle BackColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
            <%-----------------------------------   modal para Editar un pago  ---------------------------------------%>
                <div class="modal fade" id="IngresarLiquidacion" tabindex="-1" role="dialog" aria-labelledby="ModalPagos">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header" style="background-color: #ACD6F2">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title" id="ModalActualizarDatos"><b>Agregar o Editar Liquidaciòn de reclamo</b></h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                    Cobertura:<asp:DropDownList class="form-control" ID="ddlCoberturas" Style="width: 100%" Height="32px" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group col-sm-10 col-md-5 col-lg-5">
                                    Monto:<asp:TextBox ID="txtMonto" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Monto" runat="server" Text="0.00"></asp:TextBox>
                                </div>
                                <br />
                                <asp:CheckBox runat="server" Text="IVA" id="checkIva"/>
                                 <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                    IVA:<asp:TextBox ID="txtIva" Enabled="false" Style="width: 100%" autocomplete="off" class="form-control" placeholder="iva" runat="server"></asp:TextBox>
                                </div>
                                 <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                    Timbres:<asp:TextBox ID="txtTimbres" Enabled="false" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Timbres" runat="server" Text="0.00"></asp:TextBox>
                                </div>
                                 <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                    Deducible:<asp:TextBox ID="txtPagoDeducible" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Deducible" runat="server" Text="0.00"></asp:TextBox>
                                </div>
                                 <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                    Primas:<asp:TextBox ID="txtPrimasPago" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Primas" runat="server" Text="0.00"></asp:TextBox>
                                </div>
                                 <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                    <label>Seleccionar Cobertura:</label>
                                    <asp:DropDownList ID="ddlDestino" class="form-control" Style="width: 100%; height: 30px;" runat="server">
                                        <asp:ListItem Value="Ruta">Ruta</asp:ListItem>
                                        <asp:ListItem Value="Recepcion">Recepcion</asp:ListItem>
                                        <asp:ListItem Value="Escritura de pago">Escritura de pago</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                 <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                    Total:<asp:TextBox ID="txtTotal" Enabled="false" Style="width: 100%" autocomplete="off" class="form-control" placeholder="total" runat="server" Text="0.00"></asp:TextBox>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                                    <asp:Button runat="server" Text="Guardar" ID="btnPago" class="btn btn-primary" OnClick="btnPago_Click" />
                                    <asp:Button ID="btnActualizarPagos" Enabled="false" CssClass="btn btn-success" runat="server" Text="Actualizar" OnClick="btnActualizarPagos_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        <%--------------------------  modal para enviar correos electronicos a los clientes ---------------------------------%>
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="exampleModalLabel"><b>Enviar Correo Electronico</b></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="message-text" class="control-label">Correo de:</label>
                            <asp:TextBox runat="server" ID="txtFrom" Enabled="true" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Correo Electronico"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="message-text" class="control-label">Correo Del Destinatario:</label>
                            <asp:TextBox ID="txtDestinatario" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="recipient-name" class="control-label">Cuerpo del correo:</label>
                            <asp:TextBox ID="txtMensaje" Style="width: 100%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="3" placeholder="Cuerpo de mensaje" runat="server" />
                        </div>
                        <div class="form-group">
                            <label for="recipient-name" class="control-label">Asunto :</label>
                            <asp:TextBox ID="txtAsunto" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="message-text" class="control-label">Contraseña de su correo:</label>
                            <asp:TextBox ID="txtContrasena" type="password" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                        <button type="button" class="btn btn-success" onclick="enviarCorreo()">Enviar</button>
                        <asp:Button ID="btnEnviarCorreo" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnEnviarCorreo_Click" />
                    </div>
                </div>
            </div>
        </div>
        <%-- ------------------------ modal para ingresar un nuevo comentario ------------------------------------------%>
        <div class="modal fade" id="ModalComentario" tabindex="-1" role="dialog" aria-labelledby="ModalComentario1" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="ModalComentario1"><b>Agregar Comentario</b></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="message-text" class="control-label">Comentario:</label>
                            <asp:TextBox ID="txtComentarios" Style="width: 99%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="3" placeholder="Comentarios Del Reclamo" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btnGuardarComentario" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarComentario_Click" />
                    </div>
                </div>
            </div>
        </div>
        <%-----------------------------------   modal para agregar una cobertura manualmente ---------------------------------------%>
        <div class="modal fade" id="ModalCobertura" tabindex="-1" role="dialog" aria-labelledby="ModalCobertura1">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="ModalCobertura1"><b>Agregar Cobertura Afectada</b></h4>
                    </div>
                    <div class="modal-body ">
                        <div class="form-group">
                            <div class="form-inline">
                                <label style="width: 15%">Cobertura :</label>
                                <asp:DropDownList ID="ddlSeleccionarCobertura" class="form-control" Style="width: 40%" runat="server" DataSourceID="selecionarCobertura" DataTextField="cobertura" DataValueField="id"></asp:DropDownList>
                                <asp:TextBox ID="txtCoberturaAfectada" Style="width: 40%" autocomplete="off" class="form-control" placeholder="Nombre Cobertura" runat="server"></asp:TextBox>
                            </div>
                            <br />
                            <div class="form-inline">
                                <label style="width: 15%">Limite 1:</label>
                                <asp:TextBox ID="txtLimite1" Text="0.00" Style="width: 80%" autocomplete="off" class="form-control" placeholder="Limite 1" runat="server"></asp:TextBox>
                            </div>
                            <br />
                            <div class="form-inline">
                                <label style="width: 15%">Limite 2:</label>
                                <asp:TextBox ID="txtlimite2" Text="0.00" Style="width: 80%" autocomplete="off" class="form-control" placeholder="Limite 2" runat="server"></asp:TextBox>
                            </div>
                            <br />
                            <div class="form-inline">
                                <label style="width: 15%">Deducible :</label>
                                <asp:TextBox ID="txtDeducible" Text="0.00" Style="width: 80%" autocomplete="off" class="form-control" placeholder="Deducible" runat="server"></asp:TextBox>
                            </div>
                            <br />
                            <div class="form-inline">
                                <label style="width: 15%">Prima :</label>
                                <asp:TextBox ID="txtPrima" Text="0.00" Style="width: 80%" autocomplete="off" class="form-control" placeholder="Prima" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btnGuardarCobertura" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarCobertura_Click" />
                    </div>
                </div>
            </div>
        </div>
        <%--------------------------------- modal para programar la proxima fecha para que aparezca el reclamo --------------------------------%>
        <div class="modal fade" id="ModalProximaFecha" tabindex="-1" role="dialog" aria-labelledby="ModalProximaFecha1">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="ModalProximaFecha1"><b>Proxima Fecha A Mostrar</b></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="message-text" class="control-label">Proxima Fecha:</label>
                            <asp:TextBox ID="txtProximaFecha" CssClass="form-control" autocomplete="off" Style="height: 20px;" Width="100%" type="date" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btnGuardarProximaFecha" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarProximaFecha_Click" />
                    </div>
                </div>
            </div>
        </div>
        <%--------------------------------- modal para mostrar los datos del contacto --------------------------------%>
        <div class="modal fade" id="ModalDatosContacto" tabindex="-1" role="dialog" aria-labelledby="ModalDatosContacto">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="ModalDatosContacto2"><b>Datos del contacto</b></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="form-group">
                                <label for="message-text" class="control-label">Nombre Contacto:</label>
                                <asp:TextBox ID="txtContacto" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="message-text" class="control-label">Correo:</label>
                                <asp:TextBox ID="txtCorreoContacto" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="message-text" class="control-label">Telefono:</label>
                                <asp:TextBox ID="txtTelefono" MaxLength="8" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btnActualizarContacto" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnActualizarContacto_Click" />
                    </div>
                </div>
            </div>
        </div>
        <%--------------------------------- modal para mostrar los datos del taller asignado --------------------------------%>
        <div class="modal fade" id="ModalTaller" tabindex="-1" role="dialog" aria-labelledby="ModalDatosContacto">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="ModalTaller2"><b>Datos del Taller</b></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="form-group">
                                <label for="message-text" class="control-label">Nombre:</label>
                                <asp:TextBox ID="txtNombreTaller" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="message-text" class="control-label">Direccion:</label>
                                <asp:TextBox ID="txtDireccionTaller" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="message-text" class="control-label">Telefono:</label>
                                <asp:TextBox ID="txtTelefonoTaller" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="message-text" class="control-label">Correo:</label>
                                <asp:TextBox ID="txtCorreoTaller" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
        <%--------------------------------- modal para mostrar los datos Analista --------------------------------%>
        <div class="modal fade" id="ModalAnalista" tabindex="-1" role="dialog" aria-labelledby="ModalAnalista">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title"><b>Datos Del Analista</b></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <div class="form-group">
                                <label for="message-text" class="control-label">Nombre:</label>
                                <asp:TextBox ID="txtNombreAnalista" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="message-text" class="control-label">Telefono:</label>
                                <asp:TextBox ID="txtTelefonoAnalista" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="message-text" class="control-label">Correo:</label>
                                <asp:TextBox ID="txtCorreoAnalista" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
        <%--------------------  Tiempo del reclamo --------------------%>
        <div class="modal fade" id="ModalTiempo" tabindex="-1" role="dialog" aria-labelledby="ModalTiempo">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="ModalTiempo2"><b>Tiempo Del Reclamo</b></h4>
                    </div>
                    <div class="modal-body">
                        <div class="TiempoReclamo center-block">
                        </div>
                        <div class="scrolling-table-container">
                            <b><span style="font-size: 20px">Estados y Tiempo del reclamo</span></b>
                            <asp:GridView ID="GridEstadosAuto" CssClass="table bs-table table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>

            <%--------------------------------- modal para mostrar seleccion para producto no conforme --------------------------------%>
                <div class="modal fade" id="ModalNoconforme" tabindex="-1" role="dialog" aria-labelledby="ModalNoconforme">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title"><b>Seleccionar opcion de producto no conforme</b></h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-inline">
                                   <asp:DropDownList ID="ddlNoConforme" class="form-control" Style="width: 65%; height: 30px;" runat="server">
                                        <asp:ListItem Value="Cartas hacia la SAT con errores">Cartas hacia la SAT con errores</asp:ListItem>
                                        <asp:ListItem Value="Cheques con datos incorrectos">Cheques con datos incorrectos</asp:ListItem>
                                        <asp:ListItem Value="Declinaciones con Datos incorrectos">Declinaciones con Datos incorrectos</asp:ListItem>
                                        <asp:ListItem Value="Nombre del asegurado incorrecto">Nombre del asegurado incorrecto</asp:ListItem>
                                        <asp:ListItem Value="Facturas de deducible con datos erróneos ">Facturas de deducible con datos erróneos </asp:ListItem>
                                    </asp:DropDownList>  
                                     <asp:DropDownList ID="ddlEstadoNoConforme" class="form-control" Style="width: 30%; height: 30px;" runat="server">
                                        <asp:ListItem Value="Abierto">Abierto</asp:ListItem>
                                        <asp:ListItem Value="Cerrado">Cerrado</asp:ListItem>
                                    </asp:DropDownList> 
                                </div>
                                <br />
                                  <asp:TextBox ID="txtObservacionesNoConf" Style="width: 99%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="3" placeholder="Comentarios del producto no conforme" runat="server"></asp:TextBox>
                                <br />
                                 <asp:Label runat="server" ID="lblProductoNoConforme"></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                                <asp:Button ID="btnProductoNoConforme" OnClick="btnProductoNoConforme_Click" CssClass="btn btn-primary" runat="server" Text="Guardar"/>
                            </div>
                        </div>
                    </div>
                </div>

        <%-- data source con las conexiones a las tablas de la bd reclamos--%>
        <asp:SqlDataSource ID="SqlDataSourceGestores" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [id], [nombre] FROM [gestores] where tipo = 'autos'"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceAnalistas" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [id], [nombre] FROM [analistas] "></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceEstadosAutos" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [descripcion], [dias_revision] FROM [estados_reclamos_unity] where tipo = 'auto'"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceTalleres" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [id], [nombre] FROM [talleres]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="selecionarCobertura" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [id], [cobertura] FROM [coberturas] where tipo = 'autos'"></asp:SqlDataSource>


        <!-- modal para mostrar el editor de envio de cartas -->
        <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="imprimircarta"><b>Impresion de cartas</b></h4>
                    </div>
                    <div id="summernote">
                    </div>
                    <a href="javascript:void(0)" onclick="$('.note-editable').print()" style="font-size: 40px; padding-left: 15px;"><i class="fa fa-print" aria-hidden="true"></i></a>
                    <div style="display: none;" id="MemosReclamos" class="tipo_letra">
                        <div class="img-float-left" style="float: left; padding-top: 110px;">
                            <p>
                                Guatemala
                                <asp:Label ID="lblCartaFecha" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblCartaid" runat="server"></asp:Label>
                                <br />
                                Señor(a)
                                <br />
                                <asp:Label ID="lblCartaAsegurado" runat="server"></asp:Label>
                                <br />
                                Presente
                            </p>
                        </div>
                        <div>
                            <table style="width: 100%">
                                <tr>
                                    <td><b>Referencia:</b></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>Asunto: Nombre del asunto</td>
                                </tr>
                                <tr>
                                    <td>Vehiculo :<asp:Label ID="lblCartaVehiculo" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Poliza :<asp:Label ID="lblCartaPoliza" runat="server"></asp:Label></td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                        <p style="padding-top: 20px;">
                            Estimado(@):
                                <br />
                            !Reciba un cordial saludo¡
                        </p>
                        <!-- aqui inicia el cambio entre formato -->
                        <div style="padding-top: 5px;">
                            <div style="text-align: justify;">
                                <asp:Label ID="lblMemo" runat="server"></asp:Label>
                            </div>
                            <asp:Panel runat="server" ID="PnDetallePago" Visible="false">
                                <table style="width: 30%; margin-left: 285px;" class="estilos-tabla">
                                    <tr class="estilos-tabla">
                                        <th>Monto Reclamado</th>
                                        <th></th>
                                    </tr>
                                    <tr class="estilos-tabla">
                                        <td>Monto Sin Iva</td>
                                        <td>0.00</td>
                                    </tr>
                                    <tr class="estilos-tabla">
                                        <td>Deducible</td>
                                        <td>0.00</td>
                                    </tr>
                                    <tr class="estilos-tabla">
                                        <td>Subtotal</td>
                                        <td>0.00</td>
                                    </tr>
                                    <tr class="estilos-tabla">
                                        <td>(-)Timbres</td>
                                        <td>0.00</td>
                                    </tr>
                                    <tr class="estilos-tabla">
                                        <td>Total a Liquidar</td>
                                        <td>0.00</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br />
                            <!--hasta aqui se mantiene el formato -->
                            <div style="padding-top: 30px;">
                                <table style="width: 100%">
                                    <tr>
                                        <td>
                                        <asp:Label ID="lblCartaEjecutivo" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                        <asp:Label ID="lblCartaCorreoEjecutivo" runat="server"></asp:Label></td>
                                    </tr>
                                </table>
                            </div>
                            <div style="padding-top: 40px; text-align: justify">
                                <p>
                                    <b>
                                        <i>Contar con clientes satisfechos es nuestro principal objetivo, cualquier sugerencia de mejora a nuestro proceso de envío de documentos o cualquier inconformidad en la recepción del mismo, escríbanos a calidad@promotoresdeseguros.com, en donde revisaremos la información para darle una respuesta oportuna.
                                        </i>
                                    </b>
                                </p>
                            </div>
                        </div>
                        <p style="text-align: right; padding-top: 50px;">RE-DA-F-05/Ver.01</p>
                    </div>
                </div>
            </div>
        </div>

        <%-- modal para verificacion de envio de notificaciones --%>
        <div class="modal" tabindex="-1" id="confirmar_envio_correo" role="dialog" aria-labelledby="mySmallModalLabel" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title"><b>Desea Enviar Notificaciones</b></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-inline">
                            <a href="#" style="font-size: 40px;"><i class="fa fa-envelope-o" aria-hidden="true"></i></a>
                            <asp:CheckBox runat="server" ID="chEnviarCorreo" Text="Enviar Correo Electronico" Style="margin-left: 15px;" />
                            <a href="#" style="font-size: 40px;"><i class="fa fa fa-comments" aria-hidden="true"></i></a>
                            <asp:CheckBox runat="server" ID="chEnviarSMS" Text="Enviar Mensaje SMS" Checked="true" Style="margin-left: 15px;" />
                        </div>
                        <asp:TextBox ID="txtSMS" Style="width: 99%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="8" runat="server" Visible="false"></asp:TextBox>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-warning" data-dismiss="modal">Cancelar</button>
                        <asp:Button ID="btnEnviarNotificacion" CssClass="btn btn-primary" runat="server" Text="Enviar" OnClick="enviar_notificaciones_click" />
                    </div>
                </div>
            </div>
        </div>

        <%-- botones circulares con opciones en la parte inferior derecha de la pantalla--%>
        <div id="container-floating">
            <div class="nd4 nds" data-toggle="tooltip" data-placement="left" data-original-title="Simone">
                <asp:LinkButton ID="linkSalir" CssClass="letter" title="Regresar a reclamos en seguimiento" OnClick="linkSalir_Click" runat="server"><i class="fa fa-times" aria-hidden="true"></i></asp:LinkButton>
            </div>
            <div class="nd3 nds" data-toggle="tooltip" data-placement="left" data-original-title="contract@gmail.com">
                <asp:LinkButton ID="linkRefresar" CssClass="letter" title="Refrescar Pagina" autopostback="true" runat="server"><i class="fa fa-undo" aria-hidden="true"></i></asp:LinkButton>
            </div>
            <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
                <asp:LinkButton ID="btnActualizar" title="Actualizar informacion" CssClass="letter" OnClick="btnActualizar_Click" runat="server"><i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
            </div>
            <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
                <p class="plus">+</p>
                <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
            </div>
        </div>

        <%------------------------------------------------ imprimir bitacora de seguimiento del reclamo ------------------------------------------%>
        <div id="imprimirBitacora" style="display: none" class="form-inline">
            <br />
            <div class="img-float-right" style="float: right; padding-top: 50px;">
                <img src="../../imgUnity/Unity%20Promotores%20transparente.png" style="margin-top: -100px; width: 235px;">
            </div>
            <div class="img-float-left" style="float: left; padding-top: 10px;">
                <p>Avenida Las Americas 22-23, Zona 14</p>
                <p>PBX: 2326-3700, 2386-3700</p>
                <p>www.unitypromotores.com</p>
            </div>
            <asp:Label Style="font-size: 20px; padding-left: 130px;" runat="server"><b>Bitacora del reclamo</b></asp:Label>
            <div class="form-inline" style="padding-top: 90px;">
                <table style="width: 100%">
                    <tr>
                        <td>Poliza:</td>
                        <td>
                            <asp:Label ID="BitPoliza" runat="server"></asp:Label></td>
                        <td>Placa</td>
                        <td>
                            <asp:Label ID="BitPlaca" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Asegurado:</td>
                        <td>
                            <asp:Label ID="BitAsegurado" runat="server"></asp:Label></td>
                        <td>Marca</td>
                        <td>
                            <asp:Label ID="BitMarca" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Ejecutivo:</td>
                        <td>
                            <asp:Label ID="BitEjecutivo" runat="server"></asp:Label></td>
                        <td>Color</td>
                        <td>
                            <asp:Label ID="BitColor" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Aseguradora:</td>
                        <td>
                            <asp:Label ID="BitAseguradora" runat="server"></asp:Label></td>
                        <td>Modelo</td>
                        <td>
                            <asp:Label ID="BitModelo" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Contratante:</td>
                        <td>
                            <asp:Label ID="BitContratante" runat="server"></asp:Label></td>
                        <td>Chasis</td>
                        <td>
                            <asp:Label ID="BitChasis" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Estado:</td>
                        <td>
                            <asp:Label ID="BitEstado" runat="server"></asp:Label></td>
                        <td>Motor</td>
                        <td>
                            <asp:Label ID="BitMotor" runat="server"></asp:Label></td>
                    </tr>
                </table>
                <p>______________________________________________________________________________________________________________</p>
                <p><b>Detalle llamadas en cabina:</b></p>
                <asp:GridView ID="Bitllamadas" CssClass="table detalle" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="True" OnRowDataBound="GridComentarios_RowDataBound">
                </asp:GridView>
                <br />
                <p>______________________________________________________________________________________________________________</p>
                <p><b>Detalle De Seguimiento en Unity:</b></p>
                <asp:GridView ID="BitSeguimiento" CssClass="table detalle" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="True" OnRowDataBound="GridComentarios_RowDataBound">
                </asp:GridView>
                <br />
                <p>Agradeciendo su pronta atención a la presente, quedamos de ustedes.</p>
                <br />
                <br />
                <p>__________________________________</p>
                <p>Atentamente</p>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentJs" runat="Server">
    <script>
        $(document).ready(function () {
            var clock;
            var tiempo = $('#ContentPlaceHolder1_txtTiempo').val();
            var tiempo2 = parseInt(tiempo)

            clock = $('.TiempoReclamo').FlipClock(tiempo2, {
                clockFace: 'DailyCounter',
                autoStart: false,
                callbacks: {
                    stop: function () {
                        $('.message').html('The clock has stopped!')
                    }
                }
            });

            clock.setCountdown(false);

            var estado = $('#ContentPlaceHolder1_lblEstadoReclamo').text();

            if (estado == 'Cerrado') {
                clock.stop();
            }
            else {
                clock.start();
            }
        });
    </script>
    <%----------- funcion javascript para imprimir un div en especifico ---------%>
    <script>
        function printDiv(imprimir) {
            var contenido = document.getElementById(imprimir).innerHTML;
            var contenidoOriginal = document.body.innerHTML;
            document.body.innerHTML = contenido;
            window.print();
            document.body.innerHTML = contenidoOriginal;
            window.location.reload(true);
        }
    </script>
     <script>
         $('#<%=txtTelefono.ClientID%>').on('input', function () {
             this.value = this.value.replace(/[^0-9]/g, '');
         });
    </script>
</asp:Content>
