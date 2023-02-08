<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbFrmReclamosDañosSeguimiento.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmReclamosDañosSeguimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="">
        <asp:Label ID="lblID" runat="server" Style="display: none"></asp:Label>
        <div class="panel panel-info col-sm-12">
            <div class="img-float-right" style="float: right; padding-top: 15px;">
                <asp:Label runat="server" ID="lblProximaFecha" Style="padding-right: 30px; font-size: 16px;"></asp:Label>
                <label>Estado:</label>
                <asp:Label runat="server" ID="lblEstadoR" Style="padding-right: 70px; font-size: 16px;">Estado</asp:Label>
            </div>
            <asp:Label ID="lblNumReclamo" runat="server"></asp:Label>
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
                    <a href="#ingreso-datos" aria-controls="ingreso-datos" role="tab" data-toggle="tab">Liquidaciones</a>
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
                <asp:Label ID="lblBanderaCierreInterno" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="lblBanderaDeclinado" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="lblBanderaEnvioCheque" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="lblBanderaCierreDeducible" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="lblBanderaCierreReclamo" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="lblBanderaAlerta" runat="server" Style="display: none;"></asp:Label>
                <asp:Label ID="lblDocumento" runat="server" Style="display: none;"></asp:Label>
            </div>
            <%---------------------------------------------------------------------------------------------------%>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane" id="home">
                    <div class="panel panel-info col-sm-12 col-md-5 col-lg-5">
                        <div class="panel-heading" role="tab" >
                            <h4 class="panel-title">
                                <b>Datos De La Poliza</b>
                            </h4>
                        </div>
                        <div class="panel-body">
                            <div class="panel-body">
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
                                <asp:Label ID="lblDireccion" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblVip" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="lblSumaAsegurada" runat="server"></asp:Label>
                                <br />
                                <asp:LinkButton runat="server" OnClick="lnEditarPoliza_Click" ID="lnEditarPoliza" title="Editar Datos" style="font-size:30px;"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <%--------------------------  Grid de coberturas afectadas--------------------------------%>
                    <div class="panel panel-info col-sm-12 col-md-7 col-lg-7">
                        <div class="panel-heading" role="tab">
                            <h4 class="panel-title">
                                <b>Coberturas Afectadas</b>
                            </h4>
                        </div>
                        <div class="panel-body">
                            <div style="overflow-y: auto; overflow-x: auto;">
                                <asp:GridView ID="GridCoberturasAfectadas" CssClass="table bs-table tablaDetalleAuto table-responsive" runat="server" AutoGenerateColumns="true" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
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
                            <asp:GridView ID="Gridllamadas" CssClass="table bs-table tablaDetalleAuto table-responsive" runat="server" AutoGenerateColumns="true" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                            </asp:GridView>
                        </div>
                        <div class="scrolling-table-container col-sm-12 col-md-6 col-lg-6">
                            <b><span style="font-size: 20px">Datos del incidente:</span></b>
                            <asp:GridView ID="GridDatosAccidente" CssClass="table bs-table tablaDetalleAuto table-responsive" runat="server" AutoGenerateColumns="true" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
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
                        <div style="height: 275px;overflow:auto" class="panel panel-info col-sm-5 col-md-12 col-lg-4">
                            <div class="panel-heading">
                                <b>Selecciones</b>
                            </div>
                            <div class="panel-body">
                                <div class="form-group col-lg-12 col-md-12">
                                  <asp:CheckBox ID="CheckReaseuro" runat="server" Text="Reaseguro" ForeColor="Red" />
                                </div>
                                <div class="form-group col-lg-12 col-md-12">
                                   <asp:CheckBox ID="checkPrioritario" runat="server" Text="Prioritario"/>
                                </div>
                                <div class="form-group col-lg-12 col-md-12">
                                    <asp:CheckBox ID="CheckComplicado" runat="server" Text="Complicado" />
                                </div>
                                <div class="form-group col-lg-12 col-md-12">
                                    <asp:CheckBox ID="checkCompromiso" runat="server" Text="Compromiso De Pago" />                                    
                                </div>
                                 <div class="form-group col-lg-12 col-md-12">
                                    <asp:CheckBox ID="checkCuelloBotella" runat="server" Text="Cuello de botella" />                                    
                                </div>
                                <div class="form-group col-lg-12 col-md-12">
                                   <asp:CheckBox ID="checkCerrarReclamo" OnCheckedChanged="checkCerrarReclamo_CheckedChanged" AutoPostBack="true" runat="server" Text="Cerrar Reclamo" />                                    
                                </div>
                                <div class="form-group col-lg-12 col-md-12">
                                    <asp:DropDownList CssClass="form-control" ID="ddlTipoCierre" Enabled="false" Style="width: 100%" Height="34px" runat="server">
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
                                <div class="form-group col-lg-12 col-md-12">
                                   <label>Reserva:</label>
                                   <asp:TextBox runat="server" ID="txtReserva" Text="0.00" CssClass="form-control" Width="100%" placeholder="Reserva"></asp:TextBox>                                    
                                </div>
                                 <div class="form-group col-lg-12 col-md-12">
                                   <label>Deducible:</label>
                                   <asp:TextBox  type="number" runat="server" ID="txtDeducibleReserva" Text="0.00" CssClass="form-control" Width="100%" placeholder="Reserva"></asp:TextBox>                                    
                                </div>
                                 <div class="form-group col-lg-12 col-md-12">
                                   <label>Reserva final:</label>
                                   <asp:TextBox type="number" runat="server" ID="txtReservaFinal" Text="0.00" CssClass="form-control" Width="100%" placeholder="Reserva"></asp:TextBox>                                    
                                </div>
                            </div>
                        </div>
                        <%------------------------------- opciones multiples de los combobox -------------------------%>
                        <div style="height: 275px; overflow-y: auto" class="panel panel-info  col-sm-7 col-md-12 col-lg-8">
                            <div class="panel-heading"><b>Opciones Multiples</b></div>
                            <div class="panel-body">
                                <div class="form-inline">
                                    <label style="width: 15%">Etapa:</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlEstadoReclamo" AutoPostBack="True" Style="width: 80%" Height="34px" 
                                        runat="server" OnSelectedIndexChanged="ddlEstadoReclamo_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <br />
                                <div class="form-inline">
                                    <label style="width: 15%">Analista:</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlAnalista" Style="width: 80%" Height="34px" runat="server"></asp:DropDownList>
                                </div>
                                <br />
                                <div class="form-inline">
                                    <label style="width: 15%">Taller:</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlTaller" Style="width: 80%" Height="34px" runat="server"></asp:DropDownList>
                                </div>
                                <br />
                                <div>
                                    <label style="width: 15%">Gestor:</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlGestor" OnSelectedIndexChanged="ddlGestor_SelectedIndexChanged" 
                                        Style="width: 80%" Height="34px" runat="server" AutoPostBack="True"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <%----------------------------------  correos y comentarios --------------------------------%>
                        <div class="panel panel-info col-sm-12 col-md-12 col-lg-12" style="height: 210px;">
                            <div class="panel-heading">
                                <b>Cartas y observaciones</b>
                            </div>
                            <div class="panel-body form-inline">
                                <label>Tipo de carta: </label>
                                <asp:DropDownList CssClass="form-control" ID="ddlCartas" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCartas_SelectedIndexChanged">
                                    <asp:ListItem Value="elegir">Elegir</asp:ListItem>
                                    <asp:ListItem Value="cierre interno">Carta Cierre Interno</asp:ListItem>
                                    <asp:ListItem Value="declinado">Carta Declinado</asp:ListItem>
                                    <asp:ListItem Value="envio cheque">Carta envio cheque</asp:ListItem>
                                    <asp:ListItem Value="cierre deducible">Cierre deducible anual</asp:ListItem>
                                    <asp:ListItem Value="cierre reclamo">Cierre reclamo</asp:ListItem>
                                    <asp:ListItem Value="alerta tiempo">Alerta tiempo</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <br />
                                <asp:TextBox ID="txtContenidoCarta" Style="width: 100%; display: none;" autocomplete="off" CssClass="form-control" TextMode="multiline" Columns="50" Rows="3" runat="server" placeholder="Observaciones" />
                                <asp:TextBox ID="txtObservaciones" Style="width: 100%" autocomplete="off" CssClass="form-control" TextMode="multiline" Columns="50" Rows="3" runat="server" placeholder="Observaciones" />
                            </div>
                        </div>
                    </div>
                    <%-- --------------------------------------- barra de iconos -----------------------------------------%>
                    <div class="panel panel-info col-sm-12 col-md-6 col-lg-6 ">
                        <div class="tamano-botones panel-body form-inline">
                            <div class="col-xs-3 col-sm-2 col-md-2 col-lg-1 ">
                                <a title="Agregar un comentario" data-toggle="modal" role="button" data-target="#ModalComentario"><i class="fa fa-pencil-square-o"></i></a>
                            </div>
                            <div class="col-xs-3 col-sm-2 col-md-2 col-lg-1">
                                <a data-toggle="modal" title="Enviar un correo electronico" role="button" data-target="#exampleModal"><i class="fa fa-envelope-o"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Configurar Proxima fecha a mostrar" data-toggle="modal" role="button" data-target="#ModalProximaFecha"><i class="fa fa-calendar-check-o"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Imprimir Memos" data-toggle="modal" role="button" data-target="#Editor"><i class="fa fa-print"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Datos del Contacto" data-toggle="modal" role="button" data-target="#ModalDatosContacto"><i class="fa fa-user"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Datos del taller" id="DatosTaller" data-toggle="modal" role="button" data-target="#ModalTaller"><i class="fa fa-wrench"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Datos del Analista" id="DatosAnalista" data-toggle="modal" role="button" data-target="#ModalTaller"><i class="fa fa-male"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="tiempo total del reclamo" data-toggle="modal" role="button" data-target="#ModalTiempo"><i class="fa fa-clock-o"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Bitacora del reclamo" onclick="printDiv('imprimirBitacora')" data-toggle="modal" role="button" data-target="#"><i class="fa fa-file"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <asp:LinkButton ID="linkGuardarR" title="Actualizar Informacion" OnClick="btnActualizar_Click" runat="server"><i class="fa fa-floppy-o"></i></asp:LinkButton>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Producto no conforme" data-toggle="modal" role="button" data-target="#ModalNoconforme"><i class="fa fa-frown-o" style="color: red"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Enviar notificacion SMS" data-toggle="modal" role="button" data-target="#ModalSMS"><i class="fa fa-comments"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a href="javascript:Scaner()" title="Escanear Documentos" role="button"><i class="fa fa-file-pdf-o"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a href="javascript:buscador()" title="Buscador de documentos" role="button"><i class="fa fa-search"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Subir archivo al repositorio" data-toggle="modal" role="button" data-target="#ModalAdjuntar"><i class="fa fa-cloud-upload"></i></a>
                            </div>
                               <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Solicitud de documentos" id="solicitudDoc" data-toggle="modal" role="button" data-target="#SolicitudDocumentos"><i class="fa fa-list-ul"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Ver Documentos Solicitados" id="DocSolicitados" data-toggle="modal" role="button" data-target="#SolicitudDocumentos"><i class="fa fa-files-o"></i></a>
                            </div>
                             <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <a title="Problemas varios" data-toggle="modal" role="button" data-target="#ProblemasVarios"><i class="fa fa-exclamation-triangle"></i></a>
                            </div>
                            <div class="col-xs-3 col-md-2 col-sm-2 col-lg-1">
                                <asp:LinkButton ID="linkRegresar" OnClick="linkSalir_Click" title="Regresar a reclamos en seguimiento" runat="server"><i class="fa fa-arrow-left"></i></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <%-- ----------------------------------- table de comentarios anteriores --------------------------------%>
                    <div class="panel panel-info col-sm-12 col-md-6 col-lg-6">
                        <div class="panel-heading">
                            <b>Comentarios
                               <asp:Label ID="lblIdReclamo" runat="server" Style="padding-left: 30px; font-size: 12px;"></asp:Label>
                            </b>
                            <b>
                                <asp:Label ID="lblNumeroReclamo" Text="No. Reclamo:" runat="server" Style="padding-left: 30px; font-size: 12px;"></asp:Label>
                            </b>
                            <asp:TextBox Style="width: 15%" ID="txtNumReclamo" Enabled="false" runat="server"></asp:TextBox>
                            <b>
                                <asp:Label ID="lblContrato" Text="Contrato:" runat="server" Style="padding-left: 10px; font-size: 14px;"></asp:Label>
                            </b>
                            <asp:TextBox Style="width: 15%" ID="txtContrato" Enabled="false" runat="server"></asp:TextBox>
                            <asp:CheckBox ID="checkHabilitar" AutoPostBack="true" runat="server" OnCheckedChanged="checkHabilitar_CheckedChanged" />
                        </div>
                        <div class="panel-body" style="padding: 1px;">
                            <div style="height: 300px; overflow-x: auto;">
                                <asp:GridView ID="GridComentarios" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" style="padding-left:0px; margin-top:0px; padding-top:0px;" runat="server" AutoGenerateColumns="true"
                                    CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowDataBound="GridComentarios_RowDataBound">
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
                    <div class="col-sm-12 col-md-6 col-lg-6" style="overflow-x: auto;">
                        <a data-toggle="modal" data-target="#ModalActualizar" title="Realizar una liquidacion" role="button" style="font-size: 40px;"><i class="fa fa-money"></i></a>
                        <asp:Label ID="lblMoneda" runat="server" Style="font-size: 17px; padding-left: 20px;"></asp:Label>
                        <asp:GridView ID="GridLiquidaciones" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridLiquidaciones_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:CommandField>
                            </Columns>
                            <AlternatingRowStyle BackColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                        <div class="form-group">
                            <asp:Label ID="lblPagoTotal" Style="display: none" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-6 col-lg-6 scrolling-table-container">
                        <asp:GridView ID="GridPagosReclamos" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        </asp:GridView>
                    </div>
                </div>
                <%-----------------------------------   modal para Editar un pago  ---------------------------------------%>
                <div class="modal fade" id="ModalActualizar">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header" style="background-color: #ACD6F2">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title"><b>Agregar o Editar Liquidaciòn de reclamo</b></h4>
                            </div>
                            <div class="modal-body row">
                                <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                    <label>Cobertura:</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlCoberturas" Style="width: 100%" Height="30px" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                    <label>Ramo:</label>
                                    <asp:TextBox ID="txtRamo" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Ramo" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                    <label>Tipo Pago:</label>
                                    <asp:DropDownList ID="ddlElegir" CssClass="form-control" Style="width: 100%; height: 30px;" runat="server">
                                        <asp:ListItem Value="1">Valor Real</asp:ListItem>
                                        <asp:ListItem Value="2">Valor Repocision</asp:ListItem>
                                        <asp:ListItem Value="3">Valor Pactado</asp:ListItem>
                                        <asp:ListItem Value="4">Valor Factura</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                    <label>Monto Reclamado:</label>
                                    <asp:TextBox ID="txtMontoReclamado" Text="0.00" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Monto Reclamado" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-4 col-lg-4">
                                    <label>IVA:</label>
                                    <asp:TextBox ID="txtIva" Text="0.00" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="iva" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-4 col-lg-4">
                                    <label>Monto Ajustado:</label>
                                    <asp:TextBox ID="txtMontoAjustado" Text="0.00" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Monto Ajustado" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-4 col-lg-4">
                                    <label>Salvamento:</label>
                                    <asp:TextBox ID="txtSalvamento" Text="0.00" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Salvamento" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-4 col-lg-4">
                                    <label>Mejora Tecnologica:</label>
                                    <asp:TextBox ID="txtMejora" Text="0.00" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Mejora Tecnologica" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-4 col-lg-4">
                                    <label>Tiempo de uso:</label>
                                    <asp:TextBox ID="txtTiempoUso" Text="0.00" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Tiempo De Uso" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-4 col-lg-4">
                                    <label>Infra Seguro:</label>
                                    <asp:TextBox ID="txtInfraseguro" Text="0.00" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Infra Seguro" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                    <label>Perdidad Final Ajustada:</label>
                                    <asp:TextBox ID="txtPerdidaFinal" Text="0.00" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Perdida Final Ajustada" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                    <label>Deducible:</label>
                                    <asp:TextBox ID="txtDeducible2" Text="0.00" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Deducible " runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-4 col-lg-4">
                                    <label>No. Cheque:</label>
                                    <asp:TextBox ID="txtNumeroCheque" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="No. Cheque" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-4 col-lg-4">
                                    <label>Nombre Emision:</label>
                                    <asp:TextBox ID="txtEmisionCheque"  Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-4 col-lg-4">
                                    <label>Valor Indemnizado</label>
                                    <asp:TextBox ID="txtValorTotal" Text="0.00" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Valor Idemnizado " runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-4 col-lg-4">
                                    <label>Medio de pago</label>
                                    <asp:DropDownList ID="ddlMedioPago" CssClass="form-control" Style="width: 100%; height: 30px;" runat="server">
                                        <asp:ListItem >Ninguno</asp:ListItem>
                                        <asp:ListItem >Cheque</asp:ListItem>
                                        <asp:ListItem >Giro</asp:ListItem>
                                        <asp:ListItem >Transferencia</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group col-sm-12 col-md-4 col-lg-4">
                                    <label>Timbres:</label>
                                    <asp:TextBox ID="txtTimbres" Text="0.00" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Timbres " runat="server"></asp:TextBox>
                                </div>
                                
                                <div class="form-group col-sm-12 col-md-4 col-lg-4">
                                    <label>Destino Cheque</label>
                                    <asp:DropDownList ID="ddlDestinoCheque" CssClass="form-control" Style="width: 100%; height: 30px;" runat="server">
                                        <asp:ListItem Value="Ruta">Ruta</asp:ListItem>
                                        <asp:ListItem Value="Recepcion">Recepcion</asp:ListItem>
                                        <asp:ListItem Value="Escritura de pago">Escritura de pago</asp:ListItem>
                                        <asp:ListItem Value="No Aplica">No Aplica</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="modal-footer">
                               <asp:Button ID="btnPago" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnPago_Click" />
                               <asp:Button ID="btnActualizarPagos" runat="server" Text="Actualizar" CssClass="btn btn-success" OnClick="btnActualizarDatos_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <%-----------------------------------  modal para enviar correos electronicos a los clientes ------------------------%>
                <div class="modal fade" id="exampleModal" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title"><b>Enviar Correo Electronico</b></h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label>Correo Del Destinatario:</label>
                                    <asp:TextBox runat="server" ID="txtFrom" Enabled="true" Style="width: 40%" autocomplete="off" class="form-control" placeholder="Correo Electronico"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Correo Del Destinatario:</label>
                                    <asp:TextBox ID="txtDestinatario" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Cuerpo del correo:</label>
                                    <asp:TextBox ID="txtMensaje" Style="width: 100%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="3" placeholder="Cuerpo de mensaje" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label>Asunto :</label>
                                    <asp:TextBox ID="txtAsunto" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Contraseña de su correo:</label>
                                    <asp:TextBox ID="txtContrasena"  Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
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
                <div class="modal fade" id="ModalComentario" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title"><b>Agregar Comentario</b></h4>
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
                <div class="modal fade" id="ModalCobertura">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title"><b>Agregar Cobertura Afectada</b></h4>
                            </div>
                            <div class="modal-body ">
                                <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                    Cobertura:
                                    <asp:DropDownList ID="ddlSeleccionarCobertura" class="form-control" Style="width: 100%" runat="server" DataSourceID="selecionarCobertura" DataTextField="cobertura" DataValueField="id"></asp:DropDownList>
                                </div>
                                <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                    Cobertura:<asp:TextBox ID="txtCoberturaAfectada" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Si no existe escriba aqui" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-6 col-lg-6" style="width: 100%">
                                    Limite 1:
                                    <asp:TextBox ID="txtLimite1" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Limite 1" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-6 col-lg-6" style="width: 100%">
                                    Limite 2:
                                    <asp:TextBox ID="txtlimite2" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Limite 2" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-6 col-lg-6" style="width: 100%">
                                    Deducible :
                                    <asp:TextBox ID="txtDeducible" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Deducible" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-12 col-md-6 col-lg-6" style="width: 100%">
                                    <label>Prima :</label>
                                    <asp:TextBox ID="txtPrima" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Prima" runat="server"></asp:TextBox>
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
                <div class="modal fade" id="ModalProximaFecha">
                    <div class="modal-dialog modal-sm">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title"><b>Proxima Fecha A Mostrar</b></h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label>Proxima Fecha:</label>
                                    <asp:TextBox ID="txtProximaFecha" CssClass="form-control" autocomplete="off" Width="100%" type="date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                                <asp:Button ID="btnGuardarProximaFecha" Enabled="false" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarProximaFecha_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <!-------------------------------------  modal para mostrar el editor de envio de cartas -------------------------------------->
                <div class="modal fade" id="Editor" data-keyboard="false" data-backdrop="static">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title"><b>Impresion de cartas</b></h4>
                            </div>
                            <div id="summernote">
                            </div>
                            <a href="javascript:void(0)" onclick="$('.note-editable').print()" style="font-size: 40px; padding-left: 15px;"><i class="fa fa-print" aria-hidden="true"></i></a>
                            <asp:LinkButton ID="lnkGuardarCarta" OnClick="lnkGuardarCarta_Click" title="Guardar Carta" runat="server" Style="font-size: 40px; text-align: center;"><i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
                            <asp:Panel runat="server" ID="panelPrincipal">
                                <div style="display: none" id="MemosReclamos" class="tipo_letra">
                                    <div class="img-float-left" style="float: left; padding-top: 70px;">
                                        <p>
                                            Guatemala
                                        <asp:Label ID="lblCartaFecha" runat="server"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblCartaid" runat="server"></asp:Label>
                                            <br />
                                            <br />
                                            Señor(a)
                                            <br />
                                            <asp:Label ID="lblCartaCliente" runat="server"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblCartaEmpresa" runat="server"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblCartaDireccion" runat="server"></asp:Label>
                                        </p>
                                        <p>Presente</p>
                                    </div>
                                    <div style="padding-left: 300px; padding-top: 250px;">
                                        <table style="width: 100%">
                                            <tr>
                                                <td><b>Referencia:</b></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>No. Poliza:</td>
                                                <td>
                                                    <asp:Label ID="lblCartaPoliza" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>No.Reclamo:</td>
                                                <td>
                                                    <asp:Label ID="lblCartaNumeroReclamo" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Nombre Asegurado:</td>
                                                <td>
                                                    <asp:Label ID="lblCartaAsegurado" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <p style="padding-top: 20px;">Estimado Señor(@):</p>
                                    <!-- aqui inicia el cambio entre formato -->
                                    <div style="padding-top: 5px;">
                                        <div style="text-align: justify;">
                                            <asp:Label ID="lblMemo" runat="server"></asp:Label>
                                        </div>
                                        <asp:Panel runat="server" ID="PnDetallePago">
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
                                        <asp:Panel runat="server" ID="PanelDetalleDeducible" Visible="false">
                                            <table style="width: 30%; margin-left: 285px;" class="estilos-tabla">
                                                <tr class="estilos-tabla">
                                                    <th>Monto Reclamado</th>
                                                    <th>Q</th>
                                                </tr>
                                                <tr class="estilos-tabla">
                                                    <td>Monto Ajustado</td>
                                                    <td>Q</td>
                                                </tr>
                                                <tr class="estilos-tabla">
                                                    <td>Deducible</td>
                                                    <td>Q</td>
                                                </tr>
                                                <tr class="estilos-tabla">
                                                    <td>Subtotal</td>
                                                    <td>Q</td>
                                                </tr>
                                                <tr class="estilos-tabla">
                                                    <td>(-)Deducible Agregado Anual</td>
                                                    <td>Q</td>
                                                </tr>
                                                <tr class="estilos-tabla">
                                                    <td>Deducible por agotar</td>
                                                    <td>-Q</td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <br />
                                        <!--hasta aqui se mantiene el formato -->
                                        <p>
                                            Esperando lo encuentre todo de conformidad, quedo a sus órdenes,
                                        </p>
                                        <p>
                                            Atentamente,
                                        </p>
                                        <div style="padding-top: 30px;">
                                            <table style="width: 100%">
                                                 <tr>
                                                    <td style="text-align: center">
                                                        <asp:Label ID="lblCartaEjecutivo" runat="server"></asp:Label></td>
                                                     <td style="text-align: center">
                                                        <asp:Label ID="lblCartaAsesorReclamo" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                     <td style="text-align: center">Ejecutivo de la cuenta</td>
                                                    <td style="text-align: center">Asesor de Reclamos Daños</td>
                                                </tr>
                                            </table>
                                        </div>
                                        <p style="padding-top: 20px; text-align: justify; font-size: 11px;">
                                            <b>
                                                <i>Contar con clientes satisfechos es nuestro principal objetivo, cualquier sugerencia de mejora a nuestro proceso de envío de documentos
                                                    o cualquier inconformidad en la recepción del mismo, escríbanos a calidad@unitypromotores.com, en donde revisaremos
                                                    la información para darle una respuesta oportuna.
                                                </i>
                                            </b>
                                        </p>
                                    </div>
                                    <p style="text-align: right; padding-top: 20px;"><asp:label runat="server" ID="CodigoISO"></asp:label></p>
                                </div>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="Panelsecundario" Style="display: none">
                                <asp:Label runat="server" ID="lblcarta"></asp:Label>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
                <%--------------------------------- modal para mostrar los datos del contacto --------------------------------%>
                <div class="modal fade" id="ModalDatosContacto">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title"><b>Datos del contacto</b></h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label>Nombre Contacto:</label>
                                    <asp:TextBox ID="txtContacto" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Correo:</label>
                                    <asp:TextBox ID="txtCorreoContacto" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Telefono:</label>
                                    <asp:TextBox ID="txtTelefono" MaxLength="15" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                                 <div class="form-group">
                                     <b>Contacto ACS:</b>
                                     <br />
                                   <asp:Label runat="server" ID="lblContacto"></asp:Label>
                                     <br />
                                   <asp:Label runat="server" ID="lblTelefonoContacto"></asp:Label>
                                     <br />
                                   <asp:Label runat="server" ID="lblCorreoContacto"></asp:Label>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                                <asp:Button ID="btnActualizarContacto" CssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="btnActualizarContacto_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                    <%--------------------------------- modal para mostrar los datos del taller, y analista asignado --------------------------------%>
                <div class="modal fade" id="ModalTaller">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title" style="display:none" id="TituloTaller"><b>Datos del Taller</b></h4>
                                <h4 class="modal-title" style="display:none" id="TituloAnalista"><b>Datos Del Analista</b></h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group" id="CTaller" style="display:none">
                                    <div class="form-group">
                                        <label>Nombre:</label>
                                        <asp:TextBox ID="txtNombreTaller" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Direccion:</label>
                                        <asp:TextBox ID="txtDireccionTaller" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Telefono:</label>
                                        <asp:TextBox ID="txtTelefonoTaller" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Correo:</label>
                                        <asp:TextBox ID="txtCorreoTaller" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group" id="CAnalista" style="display:none">
                                    <div class="form-group">
                                        <label>Nombre:</label>
                                        <asp:TextBox ID="txtNombreAnalista" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Empresa:</label>
                                        <asp:TextBox ID="txtEmpresaAnalista" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Telefono:</label>
                                        <asp:TextBox ID="txtTelefonoAnalista" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Correo:</label>
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
                <div class="modal fade" id="ModalTiempo">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title"><b>Tiempo Del Reclamo</b></h4>
                            </div>
                            <div class="modal-body">
                                <div class="TiempoReclamo center-block" style="display:none">
                                </div>
                                <div class="scrolling-table-container">
                                    <b><span style="font-size: 20px">Estados y Tiempo del reclamo</span></b>
                                    <asp:GridView ID="GridEstados" CssClass="table bs-table table-responsive table-hover" runat="server" 
                                        AutoGenerateColumns="true" ShowFooter="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridEstados_RowDataBound">
                                        <AlternatingRowStyle BackColor="White" />
                                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                                        <FooterStyle BackColor="#131B4D" HorizontalAlign="Left" Wrap="False" ForeColor="White" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                            </div>
                        </div>
                    </div>
                </div>
                <%--------------------------------- modal para adjuntar archivos --------------------------------%>
                <div class="modal fade" id="ModalAdjuntar">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title"><b>Subir Archivos</b></h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <asp:FileUpload ID="SubirArchivo" runat="server" />
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                                <asp:Button ID="btnSubir" CssClass="btn btn-primary" runat="server" Text="Subir" OnClick="btnSubir_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <%-- modal para verificacion de envio SMS --%>
                <div class="modal fade " id="confirmacion_sms">
                    <div class="modal-dialog modal-sm">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title"><b>Desea Enviar Notificacion SMS..</b></h4>
                            </div>
                            <div class="modal-body" style="font-size:70px; text-align:center;">
                                <a><i class="fa fa-comments"></i></a>
                                <asp:TextBox ID="txtSMS" Style="width: 99%" autocomplete="off" class="form-control" TextMode="multiline"
                                    Columns="50" Rows="8" runat="server" Visible="false"></asp:TextBox>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-warning" data-dismiss="modal">Cancelar</button>
                                <asp:Button ID="btnEnviarNotificacion" CssClass="btn btn-primary" runat="server" Text="Enviar" OnClick="btnEnviarNotificacion_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <%-- modal para envio manual de sms --%>
                <div class="modal fade " id="ModalSMS">
                    <div class="modal-dialog modal-sm">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title"><b>Enviar Notificacion SMS..</b></h4>
                            </div>
                            <div class="modal-body">
                                <asp:TextBox ID="TxtEnvioSms" Style="width: 99%" autocomplete="off" class="form-control" TextMode="multiline"
                                    Columns="50" Rows="5" runat="server"></asp:TextBox>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-warning" data-dismiss="modal">Cancelar</button>
                                <asp:Button ID="btnEnviarSMS" CssClass="btn btn-primary" OnClick="btnEnviarSMS_Click" runat="server" Text="Enviar" />
                            </div>
                        </div>
                    </div>
                </div>
                <%--------------------------------- modal para mostrar seleccion para producto no conforme --------------------------------%>
                <div class="modal fade" id="ModalNoconforme">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title"><b>Seleccionar opcion de producto no conforme</b></h4>
                            </div>
                            <div class="modal-body col-lg-12">
                                <div class="form-group col-lg-9 col-md-6 col-sm-12">
                                    <asp:DropDownList ID="ddlNoConforme" class="form-control" Style="width: 100%; height: 30px;" runat="server">
                                        <asp:ListItem Value="Cartas hacia la SAT con errores">Cartas hacia la SAT con errores</asp:ListItem>
                                        <asp:ListItem Value="Cheques con datos incorrectos">Cheques con datos incorrectos</asp:ListItem>
                                        <asp:ListItem Value="Declinaciones con Datos incorrectos">Declinaciones con Datos incorrectos</asp:ListItem>
                                        <asp:ListItem Value="Nombre del asegurado incorrecto">Nombre del asegurado incorrecto</asp:ListItem>
                                        <asp:ListItem Value="Facturas de deducible con datos erróneos ">Facturas de deducible con datos erróneos </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group col-lg-3 col-md-3 col-sm-12">
                                    <asp:DropDownList ID="ddlEstadoNoConforme" class="form-control" Style="width: 100%; height: 30px;" runat="server">
                                        <asp:ListItem Value="Abierto">Abierto</asp:ListItem>
                                        <asp:ListItem Value="Cerrado">Cerrado</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group col-lg-12 col-md-12 col-sm-12">
                                    <asp:TextBox ID="txtObservacionesNoConf" Style="width: 100%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="3" placeholder="Comentarios del producto no conforme" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-lg-12 col-md-12 col-sm-12">
                                    <asp:Label runat="server" ID="lblProductoNoConforme"></asp:Label>
                                </div>
                                <div class="form-group col-lg-12 col-md-12 col-sm-12">
                                    <input type="checkbox" id="ChPNC" name="Memo">Generar Memo No Conforme
                                </div>
                                <div class="form-group col-lg-12 col-md-12 col-sm-12" id="ContenidoMemoPNC" style="display: none">
                                    <asp:TextBox runat="server" ID="txtParaPNC" class="form-control" type="text" placeholder="Para" style="width: 100%"></asp:TextBox>
                                    <br />
                                    <asp:TextBox runat="server" ID="txtDireccionPNC" class="form-control" type="text" placeholder="Direccion" style="width: 100%"></asp:TextBox>
                                    <br />
                                    <asp:TextBox runat="server" ID="txtContenidoPNC" rows="4" cols="65"  TextMode="multiline" placeholder="Contenido" style="width: 100%" class="form-control"
                                        Text="Estimado: Por este medio procedemos a devolver ___, debido a ____. "></asp:TextBox>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                                <asp:Button ID="btnProductoNoConforme" OnClick="btnProductoNoConforme_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                                <button id="ImprimirPNC" type="button" class="btn btn-primary" style="display:none" data-dismiss="modal">Imprimir</button>
                            </div>
                        </div>
                    </div>
                </div>
                <%-----------------------------------   modal para agregar datos manualmente a un reclamo que se creo de forma manual ---------------------------------------%>
                <div class="modal fade" id="EditarPoliza">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title"><b>Actualizar Poliza</b></h4>
                            </div>
                            <div class="modal-body ">
                                <div class="form-group col-lg-6 col-md-6 col-sm-12">
                                    <label>Poliza:</label>
                                    <asp:TextBox ID="txtPoliza" style="width:100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-lg-6 col-md-6 col-sm-12">
                                    <label>Asegurado:</label>
                                    <asp:TextBox ID="txtAsegurado" style="width:100%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group col-lg-6 col-md-6 col-sm-12">
                                    <label>Estado Poliza:</label>
                                    <asp:DropDownList ID="ddlStatus" style="width:100%" class="form-control" runat="server">
                                        <asp:ListItem>Renovacion</asp:ListItem>
                                        <asp:ListItem>Nueva</asp:ListItem>
                                        <asp:ListItem>Cancelada</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group col-lg-6 col-md-6 col-sm-12">
                                    <label>Ejecutivo:</label>
                                    <asp:DropDownList ID="ddlEjecutivos" style="width:100%; height:32px" class="form-control"  runat="server"></asp:DropDownList>
                                </div>
                                <div class="form-group col-lg-6 col-md-6 col-sm-12">
                                    <label>Aseguradora:</label>
                                    <asp:DropDownList ID="ddlAseguradora" style="width:100%" class="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="form-group col-lg-6 col-md-6 col-sm-12">
                                    <label>Suma Asegurada:</label>
                                    <asp:TextBox ID="txtSumaAsegurada" style="width:100%" Text="0.00" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                 <div class="form-group col-lg-6 col-md-6 col-sm-12">
                                    <label>No. Cliente:</label>
                                    <asp:TextBox ID="txtCliente" style="width:100%" Text="0" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                                 <div class="form-group col-lg-6 col-md-6 col-sm-12">
                                    <label>Direccion:</label>
                                    <asp:TextBox ID="txtDireccion" style="width:100%" autocomplete="off" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                                <asp:Button ID="btnActualizarPoliza" OnClick="btnActualizarPoliza_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                            </div>
                        </div>
                    </div>
                </div>
                <%-------------------- Solicitud de documentos --------------------%>
                <div class="modal fade" id="SolicitudDocumentos">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title"><b>Solicitud de documentos</b></h4>
                            </div>
                            <div class="modal-body">
                                <div id="gvDocumentos" style="display: none" class="scrolling-table-container">
                                    <asp:GridView ID="GridDocumentos" CssClass="table bs-table table-responsive table-hover" runat="server" AutoGenerateColumns="true" ForeColor="#333333" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Seleccionar">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chElegir" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <AlternatingRowStyle BackColor="White" />
                                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
                                    </asp:GridView>
                                </div>
                                <div id="gvDocSolicitados" style="display: none">
                                    <div id="SaludoDocumentos" style="display: none; text-align: justify">
                                        <br />
                                        <p><b>Estimado Asegurado:</b></p>
                                        <p>Un gusto saludarlo,  le informo que me ha sido asignada su reclamación para la presentación de documentos, así como seguimiento y finalización del mismo.  </p>
                                        <p>De momento estamos a la espera de recibir la solicitud formal de documentos por parte del ajustador, sin embargo los documentos que normalmente se requieren en este tipo de siniestro son los siguientes: </p>
                                    </div>
                                    <br />
                                    <asp:GridView ID="GridDocSeleccionados" CssClass="table detalle" runat="server" AutoGenerateColumns="true" ForeColor="#333333" GridLines="None" CellPadding="4">
                                        <AlternatingRowStyle BackColor="White" />
                                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
                                    </asp:GridView>
                                    <asp:TextBox ID="txtSolicitudDocumentos" Style="width: 100%; border: 0px; text-align: justify;" autocomplete="off" CssClass="form-control" TextMode="multiline" Columns="50" Rows="30" runat="server" placeholder="Observaciones" />
                                    <div id="ContenidoImpresion">
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                                <button type="button" id="ImprimirSolicitud" class="btn btn-primary">Imprimir</button>
                                <asp:Button CssClass="btn btn-primary" runat="server" ID="btnGuardarDocumentos" OnClick="btnGuardarDocumentos_Click" Text="Guardar" />
                            </div>
                        </div>
                    </div>
                </div>
                <%--------------------------------- modal para adjuntar problemas varios --------------------------------%>
                <div class="modal fade" id="ProblemasVarios">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title"><b>Comentar Problemas</b></h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <asp:CheckBox runat="server" ID="chTaller" Text="Problemas Con Taller" />
                                    <asp:TextBox ID="txtProblemaTaller" Style="width: 99%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="3" placeholder="Observacion Taller" runat="server"></asp:TextBox>
                                    <asp:CheckBox runat="server" ID="chAnalista" Text="Problemas con Ajustador" />
                                    <asp:TextBox ID="txtProblemaAjustador" Style="width: 99%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="3" placeholder="Observacion para ajustador" runat="server"></asp:TextBox>
                                    <asp:CheckBox runat="server" ID="chCabina" Text="Problemas con Cabina" />
                                    <asp:TextBox ID="txtProblemaCabina" Style="width: 99%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="3" placeholder="Observacion para cabina" runat="server"></asp:TextBox>
                                    <asp:CheckBox runat="server" ID="ChAseguradora" Text="Problemas con Aseguradora" />
                                    <asp:TextBox ID="txtProblemaAseguradora" Style="width: 99%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="3" placeholder="Observacion para aseguradora" runat="server"></asp:TextBox>
                                    <asp:CheckBox runat="server" ID="chEjecutivo" Text="Problemas con ejecutivo" />
                                    <asp:TextBox ID="txtProblemaEjecutivo" Style="width: 99%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="3" placeholder="Observacion para ejecutivo" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                                <asp:Button ID="btnProblema" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnProblema_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <%------------------------------------------------ imprimir bitacora de seguimiento del reclamo ------------------------------------------%>
                <div id="imprimirBitacora" style="display: none" class="form-inline">
                    <br />
                    <div class="img-float-right" style="float: right; padding-top: 50px;">
                         <img src="../../imgUnity/Unity%20Promotores%20-%20Alta%20resolución.png" style="margin-top: -100px; width: 235px;">
                    </div>
                    <div class="img-float-left" style="float: left; padding-top: 10px;">
                        <p>Avenida Las Americas 22-23, Zona 14</p>
                        <p>PBX: 2326-3700, 2386-3700</p>
                        <p>www.unitypromotores.com</p>
                    </div>
                    <br />
                    <asp:Label id="TituloMemo" Style="font-size: 20px; padding-left: 100px;" runat="server"><b>Bitacora del reclamo</b></asp:Label>
                    <div class="form-inline" style="padding-top: 90px;">
                        <table style="width: 100%">
                            <tr>
                                <td>Departamento:</td>
                                <td>Reclamos Daños</td>
                            </tr>
                             <tr>
                                <td>Asesor Reclamo:</td>
                                <td><asp:Label runat="server" ID ="bitAsesor"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Poliza:</td>
                                <td><asp:Label ID="BitPoliza" runat="server"></asp:Label></td>
                                <td>ID</td>
                                <td><asp:Label ID="BitId" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Asegurado:</td>
                                <td><asp:Label ID="BitAsegurado" runat="server"></asp:Label></td>
                                <td>Reportante</td>
                                <td><asp:Label ID="BitReportante" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Ejecutivo:</td>
                                <td><asp:Label ID="BitEjecutivo" runat="server"></asp:Label></td>
                                <td>Fecha Siniestro</td>
                                <td><asp:Label ID="BitFecha" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Aseguradora:</td>
                                <td><asp:Label ID="BitAseguradora" runat="server"></asp:Label></td>
                                <td>No. Reclamo</td>
                                <td><asp:Label ID="BitNumeroReclamo" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                        <p>______________________________________________________________________________________________________________</p>
                        <div id="bitacora">
                            <p><b>Detalle llamadas en cabina:</b></p>
                            <asp:GridView ID="Bitllamadas" CssClass="table detalle" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="True" OnRowDataBound="GridComentarios_RowDataBound">
                            </asp:GridView>
                            <br />
                            <p>______________________________________________________________________________________________________________</p>
                            <p><b>Detalle De Seguimiento en Unity:</b></p>
                            <asp:GridView ID="BitSeguimiento" CssClass="table detalle" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="True" OnRowDataBound="GridComentarios_RowDataBound">
                            </asp:GridView>
                        </div>
                        <br />
                    </div>
                </div>
                <div id="MemoPNC" style="display: none">
                    <br />
                    <div class="img-float-right" style="float: right; padding-top: 50px;">
                        <img src="../../imgUnity/Unity%20Promotores%20transparente.png" style="margin-top: -100px; width: 235px;">
                    </div>
                    <div class="img-float-left" style="float: left; padding-top: 5px;">
                        <p>Avenida Las Americas 22-23, Zona 14</p>
                        <p>PBX: 2326-3700, 2386-3700</p>
                        <p>www.unitypromotores.com</p>
                    </div>
                    <label style="font-size: 20px; padding-left: 100px;" runat="server"><b>Memo De Envio</b></label>
                    <br />
                    <div style="padding-top: 90px;">
                        <table style="width: 100%;">
                            <tr>
                                <td>Dirigido a:</td>
                                <td>
                                    <asp:Label runat="server" ID="ParaPNC"></asp:Label></td>
                                <td>Asesor Reclamo:</td>
                                <td>
                                    <asp:Label runat="server" ID="AsesorPNC"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Direccion:</td>
                                <td>
                                    <asp:Label runat="server" ID="DireccionPNC"></asp:Label></td>
                                <td>ID:</td>
                                <td>
                                    <asp:Label runat="server" ID="IdPNC"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Aseguradora:</td>
                                <td>
                                    <asp:Label runat="server" ID="AseguradoraPNC"></asp:Label></td>
                                <td>Asegurado:</td>
                                <td>
                                    <asp:Label runat="server" ID="AseguradoPNC"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Poliza:</td>
                                <td>
                                    <asp:Label runat="server" ID="PolizaPNC"></asp:Label></td>
                            </tr>
                        </table>
                    </div>
                    <p>___________________________________________________________________________________________________________</p>
                    <asp:Label runat="server" ID="ContenidoPNC" Style="padding-top: 20px;"></asp:Label>
                    <p style="padding-top: 60px;">Cordialmente,</p>
                    <p>Asesor de reclamos</p>
                    <asp:Label runat="server" ID="AsesorAsignadoPNC"></asp:Label>
                </div>
                <%-- data source con las conexiones a las tablas de la bd reclamos--%>
                <asp:SqlDataSource ID="SqlDataSourceEstados" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [id], [descripcion] FROM [estados_reclamos_unity]  where tipo = 'daños' order by descripcion"></asp:SqlDataSource>
                <asp:SqlDataSource ID="selecionarCobertura" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [id], [cobertura] FROM [coberturas] where tipo = 'daños'"></asp:SqlDataSource>

                <div id="container-floating">
                    <div class="nd4 nds" data-toggle="tooltip" data-placement="left" data-original-title="Simone">
                        <asp:LinkButton ID="linkSalir" title="regresar a reclamos en seguimiento" CssClass="letter" runat="server" OnClick="linkSalir_Click"><i class="fa fa-times"></i></asp:LinkButton>
                    </div>
                    <div class="nd3 nds" data-toggle="tooltip" data-placement="left" data-original-title="contract@gmail.com">
                        <asp:LinkButton ID="linkRefresar" title="Refrescar la pagina" CssClass="letter" autopostback="true" runat="server"><i class="fa fa-undo"></i></asp:LinkButton>
                    </div>
                    <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
                        <asp:LinkButton ID="btnActualizar" title="Actualizar registro" CssClass="letter" runat="server" OnClick="btnActualizar_Click"><i class="fa fa-floppy-o"></i></asp:LinkButton>
                    </div>
                    <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
                        <p class="plus">+</p>
                        <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentJs" runat="Server">
    <script>
        $(document).ready(function () {

            $('#<%=txtContenidoCarta.ClientID%>').val($('#MemosReclamos').html());

            $('.note-editable').keyup(function () {
                $('#<%=txtContenidoCarta.ClientID%>').val($('.note-editable').html());
            });

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

            var estado = $('#ContentPlaceHolder1_lblEstadoR').text();

            if (estado == 'Cerrado') {
                clock.stop();
            }
            else {
                clock.start();
            }
        });
    </script>
    <%-----funcion javascript para imprimir un div en especifico ---------%>
    <script>
        function printDiv(imprimir) {
            var contenido = document.getElementById(imprimir).innerHTML;
            var contenidoOriginal = document.body.innerHTML;
            document.body.innerHTML = contenido;
            window.print();
            document.body.innerHTML = contenidoOriginal;
           window.location.href = window.location.href;
        }
    </script>
    <script>
        $('#<%=txtTelefono.ClientID%>').on('input', function () {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
    </script>
    <script>
        $('#ImprimirSolicitud').on('click', function (event) {
            var contenido = $('#ContentPlaceHolder1_txtSolicitudDocumentos').val();
            var final = contenido.replace(/\n/g, '<br\>');
            $('#ContentPlaceHolder1_txtSolicitudDocumentos').css("display", "none");
            $('#ContenidoImpresion').html(final);
            $("#SaludoDocumentos").attr("style", "");
            $('#ContentPlaceHolder1_TituloMemo').text("Solicitud de Documentos");
            $('#bitacora').html($('#gvDocSolicitados').html());

            printDiv('imprimirBitacora');
        });

        $('#DocSolicitados').on('click', function (event) {
            $("#gvDocumentos").css("display", "none");
            $("#ContentPlaceHolder1_btnGuardarDocumentos").css("display", "none");
            $("#ImprimirSolicitud").css("display", "");
            $("#gvDocSolicitados").css("display", "");
        });
        
        $('#solicitudDoc').on('click', function (event) {
            $("#gvDocumentos").css("display", "");
            $("#ContentPlaceHolder1_btnGuardarDocumentos").css("display", "");
            $("#ImprimirSolicitud").css("display", "none");
            $("#gvDocSolicitados").css("display", "none");
        });
    </script>
    <script>
        var id = $('#ContentPlaceHolder1_lblID').text();
        var ruta = $('#ContentPlaceHolder1_lblDocumento').text();
        function Scaner() {
            window.open('/Modulos/MdScanner/wbReclamosVarios.aspx?id=' + id + '', "ventana1", "width=350,height=550,scrollbars=NO")
        }

        function buscador() {
            var alto = $(window).height() - 200;
            var ancho = $(window).width() - 700;
            window.open('https://archivos-reclamos.unitypromotores.com/explorador.html#files%2FReclamosVarios/' + ruta, "ventana1", "width=" + ancho + ",height=" + alto + ",scrollbars=NO")
        }
    </script>
    <script>
        $("#DatosTaller").on('click', function (event) {
            $('#TituloTaller').css("display", "");
            $('#TituloAnalista').css("display", "none");
            $('#CTaller').css("display", "");
            $('#CAnalista').css("display", "none");

        });

        $("#DatosAnalista").on('click', function (event) {
             $('#TituloAnalista').css("display", "");
             $('#TituloTaller').css("display", "none");
             $('#CTaller').css("display", "none");
             $('#CAnalista').css("display", "");
        });

        $('#ChPNC').on('click', function (event) {
             $('#ContentPlaceHolder1_btnProductoNoConforme').css("display", "none");
             $('#ContenidoMemoPNC').css("display", "");
             $('#ImprimirPNC').css("display", "");
        });

        $('#ImprimirPNC').on('click', function (event) {
            var para =  $('#ContentPlaceHolder1_txtParaPNC').val();
            $('#ContentPlaceHolder1_ParaPNC')[0].innerHTML = $('#ContentPlaceHolder1_txtParaPNC').val();
            $('#ContentPlaceHolder1_DireccionPNC')[0].innerHTML = $('#ContentPlaceHolder1_txtDireccionPNC').val();

            var contenido = $('#ContentPlaceHolder1_txtContenidoPNC').val();
             $('#ContentPlaceHolder1_ContenidoPNC')[0].innerHTML = contenido.replace(/\n/g, '<br\>');
            printDiv('MemoPNC');
        });
    </script>
</asp:Content>

