<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wbFrmConsultaSeguimientoAutos.aspx.cs" Inherits="MdBitacora_wbFrmConsultaSeguimientoAutos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/summernote.css" rel="stylesheet" />
    <link href="../css/estilos.css" rel="stylesheet" />
    <link href="../font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../Scripts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/toastr.min.css" rel="stylesheet" />
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="../css/GridviewScroll.css" rel="stylesheet" />
    <title>Consulta Reclamos</title>
</head>
<body>
    <form id="form1" runat="server">
          <div class="jumbotron titulo-cabecera" style="height: 115px;">
            <h2 style="width: 781px; padding-bottom: 20px;">Reclamos Unity Promotores S.A</h2>
            <header>
                <div class="content-wrapper">
                    <div class="float-right">
                        <div class="img-float-right" style="float: right;">
                            <img src="../imgUnity/Unity%20Promotores-%20Logo%20en%20blanco.png" style="margin-top: -90px; width: 235px;">
                        </div>
                    </div>
                </div>
            </header>
        </div>
        <br />
        <br />
    <div class="container-fluid">
        <asp:Label ID="lblID" runat="server" Text="Label" Visible="false"></asp:Label>
        <div class="panel panel-default col-sm-12">
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
                <asp:TextBox ID="txtTiempo" style="display:none" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtGestor" Visible="false" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtGestorTelefono" Visible="false" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtFechaSiniestro" Visible="false" runat="server"></asp:TextBox>
                <asp:Label ID="lblNombreAsegurado" Visible="false" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblNumeroPoliza" Visible="false" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="lblDireccionAsegurado" Visible="false" runat="server" Text="Label"></asp:Label>
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
                                <asp:CheckBox ID="checkDatosAutos" AutoPostBack="true" runat="server" Text="" />
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
                                <asp:Label ID="lblEjecutivo" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblAseguradora" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblContratante" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblEstado" runat="server"></asp:Label>
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
                            <asp:Button ID="coberturaADD" OnClientClick="return false;" Enabled="false" runat="server" data-toggle="modal" data-target="#ModalCobertura" CssClass="btn btn-primary" Text="Agregar" />
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
                        <div style="height: 275px;" class="panel panel-info col-sm-12 col-md-4 col-lg-4">
                            <div class="panel-heading">
                                <b>Selecciones</b>
                            </div>
                            <div class="panel-body">
                                <asp:CheckBox Enabled="false" ID="checkPrioritario" runat="server" Text="Prioritario" AutoPostBack="True" />
                                <br />
                                <asp:CheckBox Enabled="false" ID="CheckComplicado" runat="server" Text="Complicado" AutoPostBack="True" />
                                <br />
                                <asp:CheckBox Enabled="false" ID="CheckPerdida" runat="server" Text="Perdida Total" AutoPostBack="True" OnCheckedChanged="CheckPerdida_CheckedChanged" />
                                <br />
                                <asp:CheckBox Enabled="false" ID="ChecKAutoAlquiler" runat="server" Text="Alquiler De Auto" AutoPostBack="True" OnCheckedChanged="ChecKAutoAlquiler_CheckedChanged" />
                                <br />
                                <asp:CheckBox Enabled="false" ID="checkCompromiso" runat="server" Text="Compromiso De Pago" AutoPostBack="True" />
                                <br />
                                <asp:CheckBox Enabled="false" ID="checkCierreInterno" runat="server" Text="Cierre Interno" AutoPostBack="True" />
                                <br />
                                <asp:CheckBox Enabled="false" ID="checkCerrarReclamo" runat="server" Text="Cerrar Reclamo" AutoPostBack="True" />
                            </div>
                        </div>
                        <div style="height: 275px;" class="panel panel-info col-sm-12 col-md-8 col-lg-8">
                            <div class="panel-heading">
                                <b>Opciones Multiples</b>
                            </div>
                            <div class="panel-body">
                                <div class="form-inline">
                                    <label style="width: 15%">Estado:</label>
                                    <asp:DropDownList Enabled="false" CssClass="form-control" ID="ddlEstadoAuto" Style="width: 80%" Height="34px" runat="server" DataSourceID="SqlDataSourceEstadosAutos" DataTextField="descripcion" DataValueField="descripcion" AutoPostBack="true" OnSelectedIndexChanged="ddlEstadoAuto_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <br />
                                <div class="form-inline">
                                    <label style="width: 15%">Analista:</label>
                                    <asp:DropDownList Enabled="false" CssClass="form-control" ID="ddlAnalista" Style="width: 80%" Height="34px" runat="server" DataSourceID="SqlDataSourceAnalistas" DataTextField="nombre" DataValueField="id"></asp:DropDownList>
                                </div>
                                <br />
                                <div class="form-inline">
                                    <label style="width: 15%">Taller:</label>
                                    <asp:DropDownList Enabled="false" CssClass="form-control" ID="ddlTaller" Style="width: 80%" Height="34px" runat="server" DataSourceID="SqlDataSourceTalleres" DataTextField="nombre" DataValueField="id"></asp:DropDownList>
                                </div>
                                <br />
                                <div class="form-inline">
                                    <label style="width: 15%">Gestor:</label>
                                    <asp:DropDownList Enabled="false" CssClass="form-control" ID="ddlGestor" Style="width: 80%" Height="34px" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceGestores" DataTextField="nombre" DataValueField="id"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
               <%-- --------------------------------------- correos y comentarios-----------------------------------------%>
                        <div class="panel panel-info col-sm-12 col-md-12 col-lg-12 ">
                            <div class="panel-heading">
                                <b>Observaciones</b>
                            </div>
                            <div class="panel-body form-inline">
                                <asp:TextBox Enabled="false" ID="txtObservaciones" Style="width: 100%" autocomplete="off" CssClass="form-control" TextMode="multiline" Columns="50" Rows="4" runat="server" placeholder="Observaciones" />
                                <asp:CheckBox Enabled="false" ID="chCartaCierre" Text="Carta Cierre Interno" AutoPostBack="true" runat="server" OnCheckedChanged="chCartaCierre_CheckedChanged" />
                                <asp:CheckBox Enabled="false" ID="chCartaDeclinado" Text="Carta Declinado" AutoPostBack="true" runat="server" OnCheckedChanged="chCartaDeclinado_CheckedChanged" />
                                <asp:CheckBox Enabled="false" ID="chEnvioCarta" Text="Carta Envio Cheque" AutoPostBack="true" runat="server" OnCheckedChanged="chEnvioCarta_CheckedChanged" />
                                <br />
                            </div>
                        </div>
                    </div>
                    <br />
                  <%-- --------------------------------------- barra de iconos -----------------------------------------%>
                      <div class="panel panel-info col-sm-12 col-md-6 col-lg-6 ">
                        <div class="panel-body form-inline">
                            <div class=" col-sm-12 col-md-1 col-lg-1">
                                <a title="Agregar un comentario"  style="font-size: 40px;"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-md-2 col-sm-1 col-lg-1">
                                <a title="Enviar un correo electronico" style="font-size: 40px;"><i class="fa fa-envelope-o" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-md-1 col-sm-12 col-lg-1">
                                <a title="Configurar Proxima fecha a mostrar"  style="font-size: 40px; text-align: center;"><i class="fa fa-calendar-check-o" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-md-1 col-sm-12 col-lg-1">
                                <a title="Imprimir Memos"  style="font-size: 40px;"><i class="fa fa-print" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-md-1 col-sm-12 col-lg-1">
                                <a title="Datos del Contacto" data-toggle="modal" role="button" data-target="#ModalDatosContacto" style="font-size: 40px;"><i class="fa fa-user" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-md-1 col-sm-12 col-lg-1">
                                <a title="Datos del taller" data-toggle="modal" role="button" data-target="#ModalTaller" style="font-size: 40px;"><i class="fa fa-wrench" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-md-1 col-sm-12 col-lg-1">
                                <a title="tiempo total del reclamo" style="font-size: 40px;"><i class="fa fa-clock-o" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-md-1 col-sm-12 col-lg-1">
                                <a title="Bitacora del reclamo"  style="font-size: 40px;"><i class="fa fa-file" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-md-1 col-sm-12 col-lg-1">
                                 <asp:LinkButton ID="linkGuardarR" enabled="false" title="Actualizar Informacion" runat="server" Style="font-size: 40px; text-align: center;"><i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
                            </div>
                            <div class="col-md-1 col-sm-12 col-lg-1">
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
                            <div style="height: 300px; overflow-x: auto;">
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
                    <br />
                    <div class="form-inline">
                        <div class="form-group" style="width: 15%">
                            <label for="message-text" class="control-label">Monto:</label>
                            <asp:TextBox runat="server" ID="txtMonto" Text="0.00" Style="width: 100%; padding-right: 30px;" autocomplete="off" class="form-control" placeholder="Monto"></asp:TextBox>
                        </div>
                        <div class="form-group" style="width: 15%">
                            <label for="message-text" class="control-label">Deducible:</label>
                            <asp:TextBox runat="server" ID="txtPagoDeducible" Text="0.00" Style="width: 100%;" autocomplete="off" class="form-control" placeholder="Deducble"></asp:TextBox>
                        </div>
                        <div class="form-group" style="width: 15%">
                            <label for="message-text" class="control-label">Primas:</label>
                            <asp:TextBox runat="server" ID="txtPrimasPago" Text="0.00" Style="width: 100%;" autocomplete="off" class="form-control" placeholder="Primas"></asp:TextBox>
                        </div>
                        <div class="form-group" style="width: 5%; margin-left: 2px;">
                            <label for="message-text" class="control-label">Con IVA:</label>
                            <asp:CheckBox ID="checkIva" CssClass="form-control" runat="server" Text="_IVA" AutoPostBack="True" />
                        </div>
                        <div class="form-group" style="width: 15%">
                            <label for="message-text" class="control-label">Seleccionar Cobertura:</label>
                            <asp:DropDownList class="form-control" AutoPostBack="true" ID="ddlCoberturas" Style="width: 100%" Height="34px" runat="server" OnSelectedIndexChanged="ddlCoberturas_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <br />
                            <asp:Button Enabled="false" runat="server" Text="Guardar Pago" ID="btnPago" class="btn btn-primary"/>
                        </div>
                        <div class="form-group">
                            <br />
                            <asp:Label ID="lblPagoTotal" Style="font-size: 20px; padding-left: 3px;" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <b>
                        <asp:Label ID="lblMoneda" runat="server" Style="font-size: 17px;"></asp:Label>
                    </b>
                    <asp:GridView ID="GridPagosReclamos" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
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
                                <asp:TextBox ID="txtTelefono" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
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
                        <asp:Label ID="lblCarta" runat="server" Text=""></asp:Label>
                    </div>
                    <a href="javascript:void(0)" onclick="$('.note-editable').print()" style="font-size: 40px; padding-left: 15px;"><i class="fa fa-print" aria-hidden="true"></i></a>
                    <asp:TextBox ID="txtCarta" Style="width: 100%; display: none;" autocomplete="off" CssClass="form-control" TextMode="multiline" Columns="50" Rows="30" runat="server" />
                </div>
            </div>
        </div>

        <%-- modal para verificacion de envio de correo --%>
        <div class="modal fade bs-example-modal-sm" tabindex="-1" id="confirmar_envio_correo" role="dialog" aria-labelledby="mySmallModalLabel">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title"><b>Desea Enviar Notificacion..</b></h4>
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
                <p class="plus"><i class="fa fa-cog" aria-hidden="true"></i></p>
                <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
            </div>
        </div>
    </div>
  <%--archivos javascripts que se utilizan en el sistema--%>
        <script src="../Scripts/jquery-3.1.1.min.js"></script>
        <script src="../bootstrap/js/bootstrap.min.js"></script>
        <script src="../Scripts/jquery.cookie.min.js"></script>
        <script src="../Scripts/toastr.min.js"></script>
        <script src="../Scripts/gridviewScroll.min.js"></script>
        <script src="../Scripts/summernote.min.js"></script>
        <script src="../Scripts/jQuery.print.min.js"></script>
        <script src="../Scripts/app.js"></script>
        
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

            var estado = $('#ds').val();

            if (estado == 2) {
                clock.stop();
            }
            else {
                clock.start();
            }
        });
    </script>
    </form>
</body>
</html>
