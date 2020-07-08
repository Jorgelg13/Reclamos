<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wbFrmConsultaSeguimientoDaños.aspx.cs" Inherits="MdBitacora_wbFrmConsultaSeguimientoDaños" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/summernote.css" rel="stylesheet" />
    <link href="../css/estilos.css" rel="stylesheet" />
    <link href="../Scripts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/toastr.min.css" rel="stylesheet" />
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="../css/GridviewScroll.css" rel="stylesheet" />
    <link href="../FlipClock/compiled/flipclock.css" rel="stylesheet" />
    <link href="../css/estilosContador.css" rel="stylesheet" />
    <title>Consulta Reclamos</title>
</head>
<body>
    <form id="form1" runat="server">
       <div class="jumbotron titulo-cabecera" style="height: 115px;">
            <h2 style="width: 781px; padding-bottom: 20px;">Reclamos De Daños Varios Unity Promotores</h2>
            <header>
                <div class="content-wrapper">
                    <div class="float-right">
                        <div class="img-float-right" style="float: right;">
                            <img src="../imgUnity/Unity%20Promotores-%20Logo%20en%20blanco.png" style="margin-top: -90px; width: 235px;" />
                        </div>
                    </div>
                </div>
            </header>
        </div>
        <br />
       <div class="container-fluid">
        <asp:Label ID="lblID" runat="server" Text="Label" Visible="false"></asp:Label>
        <div class="panel panel-info col-sm-12">
            <asp:Label ID="lblNumReclamo" runat="server" Text=""></asp:Label>
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
                    <a href="#ingreso-datos" aria-controls="ingreso-datos" role="tab" data-toggle="tab">Pagos Reclamos</a>
                </li>
            </ul>
            <%-- contiene textbox que no se visualisan pero q contienen registros que son utilizados en algunos metodos--%>
            <div>
                <asp:TextBox ID="txtEjecutivo" Visible="false" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtTiempo" Style="display: none" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtGestor" Visible="false" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtGestorTelefono" Visible="false" runat="server"></asp:TextBox>
                <asp:Label ID="lblEstadoReclamo" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblRamo" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="lblfechaSiniestro" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="lblFechaCommit" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="lblReportante" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="lblIDRec" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="lblAseguradoRec" Visible="false" runat="server"></asp:Label>
            </div>
            <%---------------------------------------------------------------------------------------------------%>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane" id="home">
                    <br />
                    <div class="panel panel-info col-sm-12 col-md-5 col-lg-5">
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
                                <asp:Label ID="lblDireccion" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblVip" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblSumaAsegurada" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <%--------------------------  Grid de coberturas afectadas--------------------------------%>
                    <div class="panel panel-info col-sm-12 col-md-7 col-lg-7">
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
                <%---------------------------------------- tabla que contiene las llamadas echas en cabina ------------------------------%>
                <div role="tabpanel" class="tab-pane" id="profile">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <br />
                        <div class="scrolling-table-container col-sm-12 col-md-6 col-lg-6">
                            <b><span style="font-size: 20px">LLamadas Realizadas en cabina:</span></b>
                            <asp:GridView ID="Gridllamadas" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                            </asp:GridView>
                        </div>
                        <div class="scrolling-table-container col-sm-12 col-md-6 col-lg-6">
                            <b><span style="font-size: 20px">Datos del incidente:</span></b>
                            <asp:GridView ID="GridDatosAccidente" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <%--------------------------.------------------------ selecciones de opciones por medio de checks--------------------------------%>
                <div role="tabpanel" class="tab-pane" id="coberturas">
                    <div class="panel-body form-inline col-lg-6 col-md-6">
                        <div style="height: 275px;" class="panel panel-info col-sm-12 col-md-4 col-lg-4">
                            <div class="panel-heading">
                                <b>Selecciones</b>
                            </div>
                            <div class="panel-body">
                                <asp:CheckBox ID="checkPrioritario" Enabled="false" runat="server" Text="Prioritario" AutoPostBack="True" />
                                <br />
                                <asp:CheckBox ID="CheckComplicado" Enabled="false" runat="server" Text="Complicado" AutoPostBack="True" />
                                <br />
                                <asp:CheckBox ID="checkCompromiso" Enabled="false" runat="server" Text="Compromiso De Pago" AutoPostBack="True" />
                                <br />
                                <asp:CheckBox ID="checkCerrarReclamo" Enabled="false" runat="server" Text="Cerrar Reclamo" />
                                <br />
                                <asp:DropDownList CssClass="form-control" ID="ddlTipoCierre" Style="width: 150px" Height="34px" runat="server">
                                    <asp:ListItem Value="Sin Cobertura">Sin Cobertura</asp:ListItem>
                                    <asp:ListItem Value="Pagado">Pagado</asp:ListItem>
                                    <asp:ListItem Value="A solicitud del asegurado">A solicitud del asegurado</asp:ListItem>
                                    <asp:ListItem Value="No supera Deducible">No supera deducible</asp:ListItem>
                                    <asp:ListItem Value="Tercero Responsale">Tercero Responsable</asp:ListItem>
                                    <asp:ListItem Value="Sin Documentos">Sin Documentos</asp:ListItem>
                                    <asp:ListItem Value="Cambio de corredor">Cambio de corredor</asp:ListItem>
                                    <asp:ListItem Value="Otros">Otros</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%------------------------------- opciones multiples de los combobox -------------------------%>
                        <div style="height: 275px;" class="panel panel-info  col-sm-12 col-md-8 col-lg-8">
                            <div class="panel-heading"><b>Opciones Multiples</b></div>
                            <div class="panel-body">
                                <div class="form-inline">
                                    <label style="width: 15%">Estado:</label>
                                    <asp:DropDownList Enabled="false" CssClass="form-control" ID="ddlEstadoReclamo" AutoPostBack="True" Style="width: 80%" Height="34px" runat="server" DataSourceID="SqlDataSourceEstados" DataTextField="descripcion" DataValueField="descripcion" OnSelectedIndexChanged="ddlEstadoReclamo_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <br />
                                <div class="form-inline">
                                    <label style="width: 15%">Analista:</label>
                                    <asp:DropDownList Enabled="false" CssClass="form-control" ID="ddlAnalista" Style="width: 80%" Height="34px" runat="server"></asp:DropDownList>
                                </div>
                                <br />
                                <div class="form-inline">
                                    <label style="width: 15%">Taller:</label>
                                    <asp:DropDownList Enabled="false" CssClass="form-control" ID="ddlTaller" Style="width: 80%" Height="34px" runat="server"></asp:DropDownList>
                                </div>
                                <br />
                                <div>
                                    <label style="width: 15%">Gestor:</label>
                                    <asp:DropDownList Enabled="false" CssClass="form-control" ID="ddlGestor" Style="width: 80%" Height="34px" runat="server" AutoPostBack="True"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <%----------------------------------  correos y comentarios-------------------------------------------------- --%>
                        <div class="panel panel-info col-sm-1 col-md-12 col-lg-12" style="height: 210px;">
                            <div class="panel-heading">
                                <b>Correos y comentarios</b>
                            </div>
                            <div class="panel-body form-inline">
                                <asp:TextBox Enabled="false" ID="txtObservaciones" Style="width: 100%" autocomplete="off" CssClass="form-control" TextMode="multiline" Columns="50" Rows="3" runat="server" placeholder="Observaciones" />
                                <asp:CheckBox Enabled="false" ID="chCartaCierre" Text="Carta Cierre Interno" AutoPostBack="true" runat="server" OnCheckedChanged="chCartaCierre_CheckedChanged" />
                                <asp:CheckBox Enabled="false" ID="chCartaDeclinado" Text="Carta Declinado" AutoPostBack="true" runat="server" OnCheckedChanged="chCartaDeclinado_CheckedChanged" />
                                <asp:CheckBox Enabled="false" ID="chEnvioCarta" Text="Carta Envio Cheque" AutoPostBack="true" runat="server" OnCheckedChanged="chEnvioCarta_CheckedChanged" />
                            </div>
                        </div>
                    </div>
                    <br>
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
                                <a title="Configurar Proxima fecha a mostrar" style="font-size: 40px; text-align: center;"><i class="fa fa-calendar-check-o" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-md-1 col-sm-12 col-lg-1">
                                <a title="Imprimir Memos" style="font-size: 40px;"><i class="fa fa-print" aria-hidden="true"></i></a>
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
                                <a title="Bitacora del reclamo" style="font-size: 40px;"><i class="fa fa-file" aria-hidden="true"></i></a>
                            </div>
                            <div class="col-md-1 col-sm-12 col-lg-1">
                                <asp:LinkButton Enabled="false" ID="linkGuardarR" title="Actualizar Informacion" runat="server" Style="font-size: 40px; text-align: center;"><i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
                            </div>
                            <div class="col-md-1 col-sm-12 col-lg-1">
                                <asp:LinkButton ID="linkRegresar" OnClick="linkSalir_Click" title="Regresar a busqueda" runat="server" Style="font-size: 40px; text-align: center;"><i class="fa fa-arrow-left" aria-hidden="true"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <%-- ----------------------------------- table de comentarios anteriores --------------------------------%>
                    <div class="panel panel-info col-sm-12 col-md-6 col-lg-6">
                        <div class="panel-heading">
                            <b>Comentarios Anteriores
                                   <asp:Label ID="lblIdReclamo" runat="server" Style="padding-left: 30px; font-size: 17px;"></asp:Label>
                            </b>
                            <b>
                                <asp:Label ID="lblNumeroReclamo" Text="Numero Reclamo:" runat="server" Style="padding-left: 30px; font-size: 17px;"></asp:Label>
                            </b>
                            <asp:TextBox Style="width: 15%" ID="txtNumReclamo" Enabled="false" runat="server"></asp:TextBox>
                            <asp:CheckBox ID="checkHabilitar" AutoPostBack="true" runat="server" OnCheckedChanged="checkHabilitar_CheckedChanged" />
                        </div>
                        <div class="panel-body">
                            <div style="height: 300px; overflow-x: auto;">
                                <asp:GridView ID="GridComentarios" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowDataBound="GridComentarios_RowDataBound">
                                    <FooterStyle BackColor="White" ForeColor="black" />
                                    <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" HorizontalAlign="Left" Wrap="True" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- -------------------------------------- tabla de detalle de pagos -------------------------------%>
                <div role="tabpanel" class="tab-pane" id="ingreso-datos">
                    <b>
                        <asp:Label ID="lblMoneda" runat="server" Style="font-size: 17px;"></asp:Label>
                    </b>
                    <asp:Label ID="lblPagoTotal" Style="font-size: 14px; padding-left: 3px;" runat="server" Text=""></asp:Label>
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridPagosReclamos" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridPagosReclamos_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:CommandField>
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Left" Wrap="False" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                        <button type="button" class="btn btn-primary" data-dismiss="modal" data-toggle="modal" data-target="#ModalActualizar">Realizar Liquidacion</button>
                    </div>
                </div>
                <%-----------------------------------   modal para Editar un pago  ---------------------------------------%>
                <div class="modal fade" id="ModalActualizar" tabindex="-1" role="dialog" aria-labelledby="ModalPagos">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header" style="background-color: #ACD6F2">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title" id="ModalActualizarDatos"><b>Agregar o Editar Liquidaciòn de reclamo</b></h4>
                            </div>
                            <div class="modal-body ">
                                <div class="form-group">
                                    <div class="form-inline">
                                        <div class="form-inline">
                                            <div class="form-group" style="width: 50%">
                                                <label for="message-text" class="control-label">Cobertura:</label>
                                                <asp:DropDownList class="form-control" ID="ddlCoberturas" Style="width: 100%" Height="34px" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group" style="width: 48%">
                                                <label>Ramo:</label>
                                                <asp:TextBox ID="txtRamo" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Ramo" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-inline">
                                            <div class="form-group" style="width: 50%">
                                                <label>Tipo Pago:</label>
                                                <asp:DropDownList ID="ddlElegir" class="form-control" Style="width: 100%" runat="server">
                                                    <asp:ListItem Value="1">Valor Real</asp:ListItem>
                                                    <asp:ListItem Value="2">Valor Repocision</asp:ListItem>
                                                    <asp:ListItem Value="3">Valor Pactado</asp:ListItem>
                                                    <asp:ListItem Value="4">Valor Factura</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group" style="width: 48%">
                                                <label>Monto Reclamado:</label>
                                                <asp:TextBox ID="txtMontoReclamado" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Monto Reclamado" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-inline">
                                            <div class="form-group" style="width: 50%">
                                                <label>IVA:</label>
                                                <asp:TextBox ID="txtIva" Style="width: 100%" autocomplete="off" class="form-control" placeholder="iva" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group" style="width: 48%">
                                                <label>Monto Ajustado:</label>
                                                <asp:TextBox ID="txtMontoAjustado" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Monto Ajustado" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-inline">
                                            <div class="form-group" style="width: 50%">
                                                <label>Salvamento:</label>
                                                <asp:TextBox ID="txtSalvamento" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Salvamento" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group" style="width: 48%">
                                                <label>Mejora Tecnologica:</label>
                                                <asp:TextBox ID="txtMejora" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Mejora Tecnologica" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-inline">
                                            <div class="form-group" style="width: 50%">
                                                <label>Tiempo de uso:</label>
                                                <asp:TextBox ID="txtTiempoUso" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Tiempo De Uso" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group" style="width: 48%">
                                                <label>Infra Seguro:</label>
                                                <asp:TextBox ID="txtInfraseguro" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Infra Seguro" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-inline">
                                            <div class="form-group" style="width: 50%">
                                                <label>Perdidad Final Ajustada:</label>
                                                <asp:TextBox ID="txtPerdidaFinal" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Perdida Final Ajustada" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group" style="width: 48%">
                                                <label>Deducible:</label>
                                                <asp:TextBox ID="txtDeducible2" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Deducible " runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-inline">
                                            <div class="form-group" style="width: 50%">
                                                <label>Timbres:</label>
                                                <asp:TextBox ID="txtTimbres" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Timbres " runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group" style="width: 48%">
                                                <label>Valor Indemnizado</label>
                                                <asp:TextBox ID="txtValorTotal" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Valor Idemnizado " runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <%-----------------------------------  modal para enviar correos electronicos a los clientes ------------------------%>
                <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title" id="exampleModalLabel"><b>Enviar Correo Electronico</b></h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="message-text" class="control-label">Correo Del Destinatario:</label>
                                    <asp:TextBox runat="server" ID="txtFrom" Enabled="true" Style="width: 40%" autocomplete="off" class="form-control" placeholder="Correo Electronico"></asp:TextBox>
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
                <%-----------------------------------------  modal para ingresar un nuevo comentario --------------------------%>
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
                <%-- -----------------------------------  modal para agregar una cobertura manualmente ---------------------------------------%>
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
                                        <div class="form-group">
                                          <label>Cobertura:</label>
                                            <asp:DropDownList ID="ddlSeleccionarCobertura" class="form-control" Style="width: 40%" runat="server" DataSourceID="selecionarCobertura" DataTextField="cobertura" DataValueField="id"></asp:DropDownList>
                                            <asp:TextBox ID="txtCoberturaAfectada" Style="width: 40%" autocomplete="off" class="form-control" placeholder="Si no existe escriba aqui" runat="server"></asp:TextBox>
                                        </div>
                                        <br />
                                        <div class="form-inline">
                                            <div class="form-group" style="width: 48%">
                                                <label>Limite 1:</label>
                                                <asp:TextBox ID="txtLimite1" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Limite 1" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group" style="width: 50%">
                                                <label>Limite 2:</label>
                                                <asp:TextBox ID="txtlimite2" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Limite 2" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-inline">
                                            <div class="form-group" style="width: 48%">
                                                <label>Deducible :</label>
                                                <asp:TextBox ID="txtDeducible" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Deducible" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group" style="width: 50%">
                                                <label>Prima :</label>
                                                <asp:TextBox ID="txtPrima" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Prima" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
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
                <%------------------------------ modal para programar la proxima fecha para que aparezca el reclamo -----------------------%>
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
                                    <asp:TextBox ID="txtProximaFecha" CssClass="form-control" autocomplete="off" Width="100%" type="date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                                <asp:Button ID="btnGuardarProximaFecha" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarProximaFecha_Click" />
                            </div>
                        </div>
                    </div>
                </div>
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
                            <div class="modal-footer">
                                <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                                <asp:Button ID="btnActualizarContacto" CssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="btnActualizarContacto_Click" />
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
                                    <asp:GridView ID="GridEstados" CssClass="table bs-table table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                <%-- data source con las conexiones a las tablas de la bd reclamos--%>
                <asp:SqlDataSource ID="SqlDataSourceEstados" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [id], [descripcion] FROM [estados_reclamos_unity]  where tipo = 'daños'"></asp:SqlDataSource>
                <asp:SqlDataSource ID="selecionarCobertura" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [id], [cobertura] FROM [coberturas] where tipo = 'daños'"></asp:SqlDataSource>
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
        <script src="../FlipClock/compiled/flipclock.min.js"></script>
        <script src="../Scripts/contador.js"></script>
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

                var estado = $('#ContentPlaceHolder1_txtValorEstado').val();

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
