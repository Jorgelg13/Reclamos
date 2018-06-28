<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbFrmReclamosMedicosSeguimiento.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmReclamosMedicosSeguimientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="panelInformacion" Visible="false" runat="server">
        <div class="container">
            <div class="col-sm-2">
            </div>
            <div class=" col-sm-8">
                <div>
                    <h1>
                        <a href="/Modulos/MdReclamosUnity/wbFrmReclamosMedicosAsignados.aspx" style="font-size: 70px; text-align: center" class="fa fa-lock" aria-hidden="true">Este reclamo no esta aperturado o no tiene seguimiento</a>
                    </h1>
                </div>
            </div>
            <div class="col-sm-2">
            </div>
        </div>
    </asp:Panel>
        <%-- labels ocultos --%>
        <asp:Label ID="lblClaseOculto" Visible="false" runat="server"></asp:Label>
        <asp:Label ID="lblRamoMemo" Visible="false" runat="server"></asp:Label>
        <asp:Label ID="lblIdOculto" Style="display: none;" runat="server"></asp:Label>
        <asp:TextBox ID="txtTiempo" Style="display: none;" runat="server"></asp:TextBox>
        <asp:Label ID="lblDocumento" Style="display: none;" runat="server"></asp:Label>
        <asp:Panel ID="panelPrincipal" runat="server">
        <div class="panel panel-info col-sm-12 col-md-9 col-lg-9">
                <div class="panel-body">
                    <div class="img-float-right" style="float: right; padding-top: 15px;">
                        <asp:Label runat="server" ID="lblEstadoReclamo" Style="padding-right: 100px; font-size: 20px;">Estado: </asp:Label>
                        <asp:Label ID="labelID" runat="server" Text="ID" Style="margin-right: 20px;"></asp:Label>
                    </div>
                    <ul class="nav nav-tabs margen " role="tablist">
                        <li role="presentation" class="home">
                            <a href="#home" aria-controls="messages" role="tab" data-toggle="tab">Detalle del Reclamo</a>
                        </li>
                        <li role="presentation" class="coberturas">
                            <a href="#coberturas" aria-controls="settings" role="tab" data-toggle="tab">Seguimiento</a>
                        </li>
                       <li role="presentation" class="alarmas">
                            <a href="#alarmas" aria-controls="alarmas" role="tab" data-toggle="tab">Comentarios</a>
                        </li>
                        <li role="presentation" class="profile">
                            <a href="#profile" aria-controls="llamadas" role="tab" data-toggle="tab">Impresion De Boleta</a>
                        </li>
                        <li role="presentation" class="ingreso-datos">
                            <a href="#ingreso-datos" aria-controls="llamadas" role="tab" data-toggle="tab">Tiempo Reclamo</a>
                        </li>
                    </ul>
                    <%------------------------------------------------ detalle de gastos medicos ----------------------------------------------%>
                    <div class="tab-content" style="height: 700px;">
                        <div role="tabpanel" class="tab-pane active" id="home">
                            <div class="panel panel-info col-sm-12 col-md-12 col-lg-12 panel-cuadrado">
                                <div class="panel-heading panel-memos">
                                    <b>Detalle De Gastos Medicos</b>
                                    <b>
                                        <asp:Label ID="txtFechaModificado" runat="server" Style="padding-left: 15%;"></asp:Label>
                                    </b>
                                    <asp:CheckBox ID="checkMoneda" automplete="false" AutoPostBack="true" runat="server" Style="padding-left: 12%;" Text="Cambiar Moneda" OnCheckedChanged="checkMoneda_CheckedChanged" />
                                </div>
                                <div class="panel-body">
                                            <div style="height: auto; overflow-x: auto;">
                                                <asp:GridView ID="GridDetalleM" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="detalle_gasto_medico" OnSelectedIndexChanged="GridDetalleM_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="fecha" />
                                                        <asp:BoundField DataField="No. Factura" HeaderText="No. Factura" SortExpression="Factura" />
                                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" DataFormatString="{0:0,0.00}">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                            <ItemStyle Wrap="True" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="moneda" HeaderText="Moneda" SortExpression="Moneda" />
                                                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID">
                                                            <ControlStyle ForeColor="White" />
                                                            <HeaderStyle ForeColor="White" />
                                                            <ItemStyle ForeColor="White" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#EFF3FB" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                </asp:GridView>
                                            </div>
                                    <div class="form-group col-md-6 col-lg-3 col-sm-12">
                                        Tipo:
                                        <asp:DropDownList CssClass="form-control" ID="ddlDetalleGasto" Style="width: 100%" Height="32px" runat="server">
                                            <asp:ListItem Value="1">Medicamentos</asp:ListItem>
                                            <asp:ListItem Value="2">Laboratorios y examenes especiales</asp:ListItem>
                                            <asp:ListItem Value="3">Procedimientos Ambulatorios</asp:ListItem>
                                            <asp:ListItem Value="4">Hospitalizacion</asp:ListItem>
                                            <asp:ListItem Value="5">Fisioterapias</asp:ListItem>
                                            <asp:ListItem Value="6">Control Niño Sano</asp:ListItem>
                                            <asp:ListItem Value="7">Honorarios Por Consulta</asp:ListItem>
                                            <asp:ListItem Value="8">Dental</asp:ListItem>
                                            <asp:ListItem Value="9">Otros</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-6 col-lg-2 col-sm-12">
                                        Cantidad:
                                        <asp:TextBox ID="txtAgregarGasto" Text="0.00" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6 col-lg-3 col-sm-12">
                                        No. Factura:
                                        <asp:TextBox runat="server" ID="txtNumFactura" autocomplete="false" Style="width: 100%" placeholder="Numero de factura" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6 col-lg-2 col-sm-12">
                                        Fecha de gasto:<asp:TextBox runat="server" type="date" ID="txtFechaGasto" autocomplete="false" Style="width: 100%; height: 34px;" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6 col-lg-1 col-sm-12">
                                        <label style="color: white">Guardar</label>
                                        <asp:LinkButton ID="linkGuardarDetalleGMedico" OnClick="btnguardarDetalle_Click" title="Guardar detalle de gasto medico" runat="server" Style="font-size: 30px; width: 100%;"><i class="fa fa-floppy-o"></i></asp:LinkButton>
                                    </div>
                                    <asp:Label ID="lblTotal" Style="font-size: 20px; padding-left: 20px;" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <%----------------------- detalle para envio de memos a asegurado y aseguradora --------------------%>
                        <div role="tabpanel" class="tab-pane active " id="coberturas">
                            <div class="panel panel-info col-sm-12 col-md-12 col-lg-12 panel-cuadrado">
                                <div class="panel-heading panel-memos">
                                    <b>Detalle para envio de memos</b>
                                    <asp:CheckBox ID="checkAgregar" AutoPostBack="true" Text="Generar Memo Al Cliente" title="Generar Memo para el cliente" runat="server" Style="padding-left: 10%;" OnCheckedChanged="checkAgregar_CheckedChanged" />
                                    <asp:CheckBox ID="CheckMemoAseguradora" AutoPostBack="true" Text="Generar Memo Aseguradora" title="Generar Memo para la aseguradora" runat="server" Style="padding-left: 10%;" OnCheckedChanged="CheckMemoAseguradora_CheckedChanged" />
                                </div>
                                <div class="panel-body">
                                    <div style="height: 210px;">
                                        <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                            <label>Detalle para el cliente:</label>
                                            <asp:TextBox ID="txtdetalle" Style="width: 100%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="5" runat="server" />
                                        </div>
                                        <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                            <label>Observaciones para memo de aseguradora:</label>
                                            <asp:TextBox ID="txtObservaciones" Style="width: 100%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="5" runat="server" />
                                        </div>
                                        <div class="form-group col-sm-12 col-md-3 col-lg-3">
                                            <label>Elegir una direccion:</label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlDirecciones" Style="width: 97%; height: 32px;" runat="server"></asp:DropDownList>
                                        </div>
                                        <div class="form-group col-sm-12 col-md-3 col-lg-3">
                                            <label>Direccion Manual:</label>
                                            <asp:TextBox ID="txtDireccion" Style="width: 95%" autocomplete="off" class="form-control" placeholder="Si no existe la direccion puede escribirla aqui" runat="server" />
                                        </div>
                                        <div class="form-group col-sm-12 col-md-3 col-lg-3">
                                            <label>Ejecutivo:</label>
                                            <asp:TextBox ID="txtEjecutivo" Style="width: 95%" class="form-control" placeholder="Nombre de ejecutivo para memos" runat="server" />
                                        </div>
                                        <div class="form-group col-sm-12 col-md-3 col-lg-3">
                                            <label>Contacto:</label>
                                            <asp:TextBox ID="txtContacto" Visible="false" Style="width: 95%" class="form-control" placeholder="Contacto" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%----------------------------------------------- seccion de pagos y desglose del cheque del reclamo -----------------------%>
                            <div class="panel panel-info col-sm-12 col-md-12 col-lg-12 panel-cuadrado">
                                <div class="panel-heading panel-memos">
                                    <h4 class="panel-title">
                                        <b>Detalle de liquidación</b>
                                         <asp:Label ID="lblNumReclamo" Text="No. Reclamo:" runat="server" Style="padding-left: 60px; font-size: 14px;"></asp:Label>
                                    <asp:TextBox Style="width: 20%" ID="txtNumReclamo" Enabled="false" runat="server"></asp:TextBox>
                                    <asp:CheckBox ID="checkHabilitar" automplete="false" AutoPostBack="true" runat="server" Text="Habilitar" OnCheckedChanged="checkHabilitar_CheckedChanged" />
                                    </h4>
                                </div>
                                <div class="panel-body">
                                    <div style="height: auto; overflow-x: auto;">
                                        <asp:GridView ID="GridPagos" runat="server" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" AutoGenerateColumns="True" OnSelectedIndexChanged="GridPagos_SelectedIndexChanged">
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True" />
                                            </Columns>
                                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#EFF3FB" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    <%---------------------------------------- seccion de comentarios del reclamo ---------------------------------------------%>
                        <div role="tabpanel" class="tab-pane" id="alarmas">
                            <div class="scrolling-table-container">
                                <asp:GridView ID="GridComentarios" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowDataBound="GridComentarios_RowDataBound">
                                    <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#131B4D" Font-Bold="True" Wrap="false" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                            </div>
                        </div>
                        <%------------------------------------------     imprimir el formulario de datos    ----------------------------%>
                        <div role="tabpanel" class="tab-pane" id="profile">
                            <div id="imprimir" class="form-inline">
                                <br />
                                <asp:Label Style="font-size: 12px; text-align: center" runat="server"><b>CONTRASEÑA RECEPCION PAPELERIA PARA TRAMITE DE RECLAMOS</b></asp:Label>
                                <div class="img-float-left" style="float: left; padding-top: 50px;">
                                    <img src="../../imgUnity/Unity%20Promotores%20transparente.png" style="margin-top: -100px; width: 235px;">
                                </div>
                                <div class="img-float-right" style="float: right; padding-top: 10px;">
                                    <asp:Label ID="lblId" Style="font-size: 14px;" runat="server"></asp:Label>
                                </div>
                                <div class="form-inline" style="padding-top: 90px;">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label Style="font-size: 13px;" runat="server">Asegurado Titular:</asp:Label>
                                                <asp:Label Style="font-size: 13px;" runat="server" ID="lblAsegurado"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label Style="font-size: 13px;" runat="server">Aseguradora: </asp:Label>
                                                <asp:Label Style="font-size: 13px;" runat="server" ID="lblAseguradora"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label Style="font-size: 13px;" runat="server">Poliza:</asp:Label>
                                                <asp:Label Style="font-size: 13px;" runat="server" ID="lblpoliza"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label Style="font-size: 13px;" runat="server">Empresa:</asp:Label>
                                                <asp:Label Style="font-size: 13px;" runat="server" ID="lblEmpresa"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </div>
                                <div>
                                    <br />
                                    <br />
                                    <asp:GridView ID="GridRecibo" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                        <RowStyle HorizontalAlign="Left" Wrap="True" />
                                    </asp:GridView>
                                    <ul style="font-size: 13px;">
                                        <p>
                                            <b>IMPORTANTE</b>
                                        </p>
                                        <li>Si su formulario de reclamo no trae el diagnóstico del médico con la firma y sello. No se recibe para trámite. hasta estar debidamente completado.
                                        </li>
                                        <li>Si el expediente de su reclamo esta incompleto. Debe completarlo dentro de los próximos 5 dias hábiles posteriores a la entrega: de no complementarlo, Se le devolverá el expediente se le devolvera a la dirección que tenemos registrada.
                                        </li>
                                        <li>Facturas deben de venir únicamente a nombre del asegurado titular de la Póliza y en original (Roble puede recibir copias).
                                        </li>
                                        <li>Recetas Médicas. Ordenes y resultados de exámenes pueden ser en fotocopia completa y legible 
                                        </li>
                                    </ul>
                                    <br />
                                    <br />
                                    <p>
                                        Firma de quien entrega papeleria:____________________________________       Fecha Recepcion:
                                    <asp:Label Style="font-size: 13px;" runat="server" ID="lblfechaCreacion"></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <br />
                        <%------------------------------------------------ mostrar tiempos del reclamo ------------------------------------------%>
                        <div role="tabpanel" class="tab-pane" id="ingreso-datos">
                            <div class="col-md-4 col-lg-3">
                            </div>
                            <div class="clock center-block">
                            </div>
                            <div class="col-md-2 col-lg-2">
                            </div>
                            <br />
                            <div class="form-inline btn-acciones-laterales">
                                <div class="col-sm-12 col-md-4 col-lg-4">
                                    <div class="panel panel-info">
                                        <div class="panel-heading cabeceras">
                                            <p style="text-align: center; font-size: 16px;"><b>Recepcion</b></p>
                                        </div>
                                        <div class="panel-body">
                                            <a title="Fecha en que se recibio el reclamo medico" style="font-size: 70px;"><i class="fa fa-handshake-o" aria-hidden="true"></i></a>
                                            <p style="text-align: center">
                                                <asp:Label ID="lblFechaRecepcion" runat="server"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-4 col-lg-4">
                                    <div class="panel panel-info">
                                        <div class="panel-heading cabeceras">
                                            <p style="text-align: center; font-size: 16px;"><b>Asignacion</b></p>
                                        </div>
                                        <div class="panel-body">
                                            <a data-toggle="modal" title="Fecha en que fue asignado el reclamo a un usuario" style="font-size: 70px;"><i class="fa fa-male" aria-hidden="true"></i></a>
                                            <p style="text-align: center">
                                                <asp:Label ID="lblfechaAsignacion" runat="server"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-4 col-lg-4">
                                    <div class="panel panel-info">
                                        <div class="panel-heading cabeceras">
                                            <p style="text-align: center; font-size: 16px;"><b>Apertura</b></p>
                                        </div>
                                        <div class="panel-body">
                                            <a title="fecha en que el ejecutivo aperturo el reclamo" style="font-size: 70px;"><i class="fa fa-folder-open-o" aria-hidden="true"></i></a>
                                            <p style="text-align: center">
                                                <asp:Label ID="lblFechaApertura" runat="server"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-3 col-lg-3">
                                    <div class="panel panel-info">
                                        <div class="panel-heading cabeceras">
                                            <p style="text-align: center; font-size: 16px;"><b>Aseguradora</b></p>
                                        </div>
                                        <div class="panel-body">
                                            <a title="fecha que se envio a la aseguradora" style="font-size: 70px; text-align: center;"><i class="fa fa-university" aria-hidden="true"></i></a>
                                            <p style="text-align: center">
                                                <asp:Label ID="lblFechaAseguradora" runat="server"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-3 col-lg-3">
                                    <div class="panel panel-info">
                                        <div class="panel-heading cabeceras">
                                            <p style="text-align: center; font-size: 16px;"><b>Recepción De Cheque</b></p>
                                        </div>
                                        <div class="panel-body">
                                            <a title="fecha en que la aseguradora envio el cheque" style="font-size: 70px; text-align: center;"><i class="fa fa-list-alt" aria-hidden="true"></i></a>
                                            <p style="text-align: center">
                                                <asp:Label ID="lblFechaEnvioCheque" runat="server"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-3 col-lg-3">
                                    <div class="panel panel-info">
                                        <div class="panel-heading cabeceras">
                                            <p style="text-align: center; font-size: 16px;"><b>Envio de cheque</b></p>
                                        </div>
                                        <div class="panel-body">
                                            <a title="fecha en que se envio el cheque al asegurado" style="font-size: 70px; text-align: center;"><i class="fa fa-paper-plane-o" aria-hidden="true"></i></a>
                                            <p style="text-align: center">
                                                <asp:Label ID="lblEnvioCheque" runat="server"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-md-3 col-lg-3">
                                    <div class="panel panel-info">
                                        <div class="panel-heading cabeceras">
                                            <p style="text-align: center; font-size: 16px;"><b>Cierre del reclamo</b></p>
                                        </div>
                                        <div class="panel-body">
                                            <a title="fecha de cierre del reclamo" style="font-size: 70px; text-align: center;"><i class="fa fa-lock" aria-hidden="true"></i></a>
                                            <p style="text-align: center">
                                                <asp:Label ID="lblFechaCierreReclamo" runat="server"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblDestino" runat="server"></asp:Label>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%------------------------------------------------ imprimir memo para aseguradora ------------------------------------------%>
                            <div id="imprimirEnvioAseg" style="display: none" class="form-inline">
                                <br />
                                <div class="img-float-right" style="float: right; padding-top: 50px;">
                                    <img src="../../imgUnity/Unity%20Promotores%20transparente.png" style="margin-top: -100px; width: 235px;">
                                </div>
                                <div class="img-float-left" style="float: left; padding-top: 10px;">
                                    <p>Avenida Las Americas 22-23, Zona 14</p>
                                    <p>PBX: 2326-3700, 2386-3700</p>
                                    <p>www.unitypromotores.com</p>
                                </div>
                                <br />
                                <br />
                                <asp:Label ID="lblTituloMemoAseguradora" Style="font-size: 20px; padding-left: 130px;" runat="server"><b></b></asp:Label>
                                <div class="form-inline" style="padding-top: 90px;">
                                    <table style="width: 85%">
                                        <tr>
                                            <th>Para:
                                            </th>
                                            <td>
                                                <asp:Label ID="lblCartaDestinatario" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>De:
                                            </th>
                                            <td>
                                                <asp:Label ID="lblCartaEjecutivo" runat="server"></asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <th rowspan="3">Asunto:</th>
                                            <td>Reclamo de la poliza:</td>
                                            <td>
                                                <asp:Label ID="lblCartaPoliza" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>A nombre de:</td>
                                            <td>
                                                <asp:Label ID="lblCartaContratante" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Secuencia:</td>
                                            <td>
                                                <asp:Label ID="lblCartaId" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Fecha Incurrido:</th>
                                            <td>
                                                <asp:Label ID="lblCartaFechaCreacion" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Numero De Cliente:</th>
                                            <td>
                                                <asp:Label ID="lblNumeroClienteInterno" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <p>______________________________________________________________________________________________________________</p>
                                    <p>Adjunto Formulario de reclamo correspondiente a:</p>
                                    <p>
                                        Asegurado: 
                                   <b>
                                       <asp:Label Style="padding-left: 5px;" ID="lblCartaAseguradoPrincipal" runat="server"></asp:Label>
                                   </b>
                                    </p>
                                    <p>
                                        Dependiente: 
                                    <b>
                                        <asp:Label Style="padding-left: 5px;" ID="lblCartaDependiente" runat="server"></asp:Label></b>
                                    </p>
                                    <p>
                                        Certificado: <b>
                                            <asp:Label Style="padding-left: 5px;" ID="lblCartaCertificado" runat="server"></asp:Label></b>
                                    </p>
                                    <p>Detalle del Reclamo:</p>
                                    <asp:GridView ID="GridDetalleGMAseguradora" CssClass="table detalle" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="true" AutoGenerateColumns="False" DataSourceID="detalle_gasto_medico" OnRowDataBound="GridDetalleGMAseguradora_RowDataBound">
                                        <Columns>
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                                            <asp:BoundField DataField="No. Factura" HeaderText="No. Factura" SortExpression="Factura" />
                                            <asp:BoundField DataField="moneda" HeaderText="Moneda" SortExpression="Moneda" />
                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" DataFormatString="{0:0,0.00}">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle Wrap="True" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                    <p>Agradeciendo su pronta atención a la presente, quedamos de ustedes.</p>
                                    <br />
                                    <br />
                                    <p>__________________________________</p>
                                    <p>Atentamente</p>
                                    <p>
                                        <asp:Label ID="lblCartaEjecutivo2" runat="server"></asp:Label>
                                    </p>
                                    <br />
                                    <br />
                                    <p><b>Nota:</b></p>
                                    <p>
                                        <asp:Label ID="lblCartaObservacion" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <%------------------------------------------------ imprimir memo para el cliente ------------------------------------------%>
                        <div id="imprimirEnvioCliente" style="display: none" class="form-inline">
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <p style="font-size: 22px; text-align: center; padding-top: 0px;"><b>Envío de Documentos</b></p>
                            <p style="font-size: 16px; text-align: center; padding-bottom: 0px;">
                                <asp:Label ID="lblFechaEnvioCliente" runat="server"></asp:Label>
                            </p>
                            <div class="form-inline" style="padding-top: 30px;">
                                <table style="width: 60%; font-size: 13px;">
                                    <tr>
                                        <th>
                                            <asp:Label ID="lblMemoPara" Text="Para:" runat="server"></asp:Label>
                                        </th>
                                        <td>
                                            <asp:Label ID="lblMemoAsegurado" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Para: 
                                        </th>
                                        <td>
                                            <asp:Label ID="lblMemoContratante" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Dirección
                                        </th>
                                        <td>
                                            <asp:Label ID="lblMemoDireccion" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>De:</th>
                                        <td>
                                            <asp:Label ID="lblMemoDe" runat="server"></asp:Label>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <th>Asunto:</th>
                                        <td>
                                            <asp:Label ID="lblMemoAsunto" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Numero De Cliente:</th>
                                        <td>
                                            <asp:Label ID="lblNumeroCliente" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <b>Referencias</b>
                                <table class="detalle" style="width: 60%; font-size: 13px;">
                                    <tr>
                                        <th style="padding-left: 5px;"></th>
                                        <th></th>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 5px;">Póliza:</td>
                                        <td><b>
                                            <asp:Label ID="lblMemoPoliza" runat="server"></asp:Label></b></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 5px;">Certificado:</td>
                                        <td><b>
                                            <asp:Label ID="lblMemoCertificado" runat="server"></asp:Label></b></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 5px;">Asegurado:</td>
                                        <td><b>
                                            <asp:Label ID="lblMemoTitular" runat="server"></asp:Label></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 5px;">Dependiente:</td>
                                        <td><b>
                                            <asp:Label ID="LblMemoDependiente" runat="server"></asp:Label></b>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <p>Adjuntamos la papelería correspondiente al reclamo en referencia, de acuerdo al siguiente detalle:</p>
                                <p>
                                    Fecha del reclamo :
                                <asp:Label ID="lblFechaGastoMedico" runat="server"></asp:Label>
                                </p>
                                <table class="detalle" style="width: 40%; font-size: 13px;">
                                    <tr>
                                        <td style="padding-left: 5px;"><b>Numero de cheque:</b></td>
                                        <td style="text-align: right; padding-right: 5px;">
                                            <asp:Label ID="lblNumeroDeCheque" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 5px;"><b>Total Reclamado</b></td>
                                        <td style="text-align: right; padding-right: 5px;">
                                            <asp:Label ID="lblMemoReclamado" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 5px;"><b>Deducible:</b></td>
                                        <td style="text-align: right; padding-right: 5px;">
                                            <asp:Label ID="lblMemoDeducible" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 5px;"><b>Monto Pagado:</b></td>
                                        <td style="text-align: right; padding-right: 5px;">
                                            <asp:Label ID="lblMemoPagado" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 5px;"><b>Monto No Cubierto:</b></td>
                                        <td style="text-align: right; padding-right: 5px;">
                                            <asp:Label ID="lblMemoNocubierto" runat="server"></asp:Label></td>
                                    </tr>
                                </table>
                                <br />
                                <asp:Label ID="lblMemoDetalleCliente" runat="server" Text="Label"></asp:Label>
                                <br />
                                <br />
                                <p>Estamos a su disposición para cualquier duda o aclaración.</p>
                                <br />
                                <br />
                                <p>__________________________________</p>
                                <p>Atentamente</p>
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
        </div>
    <%------------------ botones laterales grandes  ------------------- --%>
    <div class="col-sm-12 col-md-3 col-lg-3">
        <div class="panel panel-info">
            <div class="panel-heading" role="tab" id="Opciones">
                <h4 class="panel-title">
                    <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseFive"><b>Opciones Multiples</b>
                    </a>
                </h4>
            </div>
            <div id="collapseFive" class="panel-collapse collapse in" role="tabpanel" aria-expanded="true">
                <div class="panel-body">
                    <div class="btn-acciones-laterales2">
                        <div class="col-xs-3 col-md-3 col-sm-4 col-lg-3">
                            <a onclick="printDiv('imprimir')" role="button" title="Imprimir El Formulario de documentos"><i class="fa fa-print"></i></a>
                        </div>
                        <div class="col-xs-3 col-md-3 col-sm-4 col-lg-3">
                            <a data-toggle="modal" role="button" title="Enviar un correo electronico" data-target="#exampleModal"><i class="fa fa-envelope-o"></i></a>
                        </div>
                        <div class="col-xs-3 col-md-3 col-sm-4 col-lg-3">
                            <a title="Agregar un comentario" role="button" data-toggle="modal" data-target="#ModalComentario"><i class="fa fa-pencil-square-o"></i></a>
                        </div>
                        <div class="col-xs-3 col-md-3 col-sm-4 col-lg-3">
                            <a title="Realizar Liquidacion" role="button" data-toggle="modal" data-target="#modalPago"><i class="fa fa-money"></i></a>
                        </div>
                        <div class="col-xs-3 col-md-3 col-sm-4 col-lg-3">
                            <asp:LinkButton ID="btnGuardar" role="button" OnClick="btnActualizar_Click" title="Actualizar Informacion" runat="server"><i class="fa fa-floppy-o"></i></asp:LinkButton>
                        </div>
                        <div class="col-xs-3 col-md-3 col-sm-4 col-lg-3">
                            <a onclick="printDiv('imprimirEnvioAseg')" role="button" title="Imprimir Memo a la aseguradora" data-toggle="modal"><i class="fa fa-paper-plane"></i></a>
                        </div>
                        <div class="col-xs-3 col-md-3 col-sm-4 col-lg-3">
                            <a onclick="printDiv('imprimirEnvioCliente')" role="button" title="Imprimir Memo al cliente" data-toggle="modal"><i class="fa fa-users"></i></a>
                        </div>
                        <div class="col-xs-3 col-md-3 col-sm-2 col-lg-3">
                            <a title="Programar proxima fecha de seguimiento" role="button" data-toggle="modal" data-target="#ModalProximaFecha"><i class="fa fa-calendar-check-o"></i></a>
                        </div>
                        <div class="col-xs-3 col-md-3 col-sm-4 col-lg-3">
                            <a title="Enviar Notificacion por falta de documentos" role="button" data-toggle="modal" data-target="#confirmar-sms"><i class="fa fa-comments"></i></a>
                        </div>
                        <div class="col-xs-3 col-md-3 col-sm-4 col-lg-3">
                            <a title="Producto No Conforme" role="button" data-toggle="modal" data-target="#ModalNoconforme" style="color: red"><i class="fa fa-frown-o"></i></a>
                        </div>
                         <div class="col-xs-3 col-md-3 col-sm-4 col-lg-3">
                            <a href="javascript:Scaner()" title="Escanear Documentos" role="button"><i class="fa fa-file-pdf-o"></i></a>
                        </div>
                         <div class="col-xs-3 col-md-3 col-sm-4 col-lg-3">
                            <a href="javascript:buscador()" title="Buscador de documentos" role="button"><i class="fa fa-search"></i></a>
                        </div>
                        <div class="col-xs-3 col-md-3 col-sm-4 col-lg-3">
                            <a title="Subir archivo al repositorio" data-toggle="modal" role="button" data-target="#ModalAdjuntar"><i class="fa fa-cloud-upload"></i></a>
                        </div>
                        <div class="col-xs-3 col-md-3 col-sm-4 col-lg-3">
                            <asp:LinkButton ID="linkRegresar" role="button" OnClick="Regresar_Click" title="Regresar a reclamos en seguimiento" runat="server"><i class="fa fa-arrow-left"></i></asp:LinkButton>
                        </div>
                        <div class="col-xs-3 col-md-3 col-sm-4 col-lg-3">
                            <a title="Cerrar El Reclamo" role="button" data-toggle="modal" data-target="#CierreReclamo"><i class="fa fa-lock" aria-hidden="true"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <%-- panel lateral con informacion de la poliza--%>
    <div class="col-sm-12 col-md-3 col-lg-3">
        <div class="panel panel-info">
            <div class="panel-heading" role="tab" id="headingFour">
                <h4 class="panel-title">
                    <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseFour"><b>Editar Datos Del Asegurado</b>
                    </a>
                </h4>
            </div>
            <div id="collapseFour" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                <div class="panel-body">
                    <div class="form-group col-sm-12 col-md-12 col-lg-12">
                        <label>Asegurado:</label>
                        <asp:TextBox runat="server" ID="txtAsegurado" autocomplete="false" Style="width: 100%" class="form-control" placeholder="Asegurado"></asp:TextBox>
                    </div>
                    <div class="form-group col-sm-12 col-md-12 col-lg-12">
                        <label>Aseguradora:</label>
                        <asp:TextBox runat="server" ID="txtAseguradora" autocomplete="false" Style="width: 100%" class="form-control" placeholder="Aseguradora"></asp:TextBox>
                    </div>
                    <div class="form-group col-sm-12 col-md-6 col-lg-6">
                        <label>Poliza:</label>
                        <asp:TextBox runat="server" ID="txtPoliza" autocomplete="false" Style="width: 100%" class="form-control" placeholder="Poliza"></asp:TextBox>
                    </div>
                    <div class="form-group col-sm-12 col-md-6 col-lg-6">
                        <label>Telefono:</label>
                        <asp:TextBox runat="server" ID="txtTelefono" autocomplete="false" Style="width: 100%" class="form-control" placeholder="Telefono"></asp:TextBox>
                    </div>
                    <div class="form-group col-sm-12 col-md-12 col-lg-12">
                        <label>Correo:</label>
                        <asp:TextBox runat="server" ID="txtCorreo" autocomplete="false" Style="width: 100%" class="form-control" placeholder="Correo"></asp:TextBox>
                    </div>
                    <div class="form-group col-sm-12 col-md-6 col-lg-6">
                        <label>Tipo Reclamo:</label>
                        <asp:DropDownList CssClass="form-control" ID="DDLTipo" Style="width: 100%" Height="34px" runat="server">
                            <asp:ListItem>Vida</asp:ListItem>
                            <asp:ListItem>Gastos Medicos</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-sm-12 col-md-6 col-lg-6">
                        <label>Estado:</label>
                        <asp:DropDownList CssClass="form-control" ID="ddlEstado" AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" Style="width: 100%" Height="34px" runat="server">
                            <asp:ListItem Value="8">--</asp:ListItem>
                            <asp:ListItem Value="4">Asegurado</asp:ListItem>
                            <asp:ListItem Value="5">Aseguradora</asp:ListItem>
                            <asp:ListItem Value="2">Cerrado</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%------------------ datos de la poliza y del asegurado  ------------------- --%>
    <div class="col-sm-12 col-md-3 col-lg-3">
        <div class="panel panel-info">
            <div class="panel-heading" role="tab" id="headingThree">
                <h4 class="panel-title">
                    <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseThree"><b>Datos de la Poliza</b>
                    </a>
                </h4>
            </div>
            <div id="collapseThree" class="panel-collapse collapse in" role="tabpanel" aria-expanded="true">
                <div class="panel-body">
                    <asp:Label ID="lblAsegurado2" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblPoliza2" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblRamo" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="tipo" Text="Tipo: " runat="server"></asp:Label>
                    <asp:Label ID="lblTipo" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblClase" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblEjecutivo" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblAseguradora2" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblContratante" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblVip" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblMoneda" runat="server"></asp:Label>
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Panel>
    <%------------------------ Confirmacion de cierre -------------------%>
    <div class="modal fade" id="CierreReclamo">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title"><b>Desea Cerrar El Reclamo..</b></h4>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnCerrarReclamo" CssClass="btn btn-primary" runat="server" Text="Cerrar" OnClick="btnCerrarReclamo_Click" />
                </div>
            </div>
        </div>
    </div>
    <%------------------------------------------------ funcion javascript para imprimir un div en especifico ------------------------------------------%>
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
    <%--------------------------  modal para enviar correos electronicos a los clientes -----------------------------%>
        <div class="modal fade" id="exampleModal" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title"><b>Enviar Correo Electronico</b></h4>
                    </div>
                    <div class="modal-body">
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
                            <label>Contraseña:</label>
                            <asp:TextBox ID="txtPassword" type="password" Style="width: 100%; font-size: 30px;" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnEnviarCorreoElectronico" CssClass="btn btn-primary" runat="server" Text="Enviar Correo" OnClick="btnEnviarCorreoElectronico_Click" />
                    </div>
                </div>
            </div>
        </div>
    <%--------------------------  modal para realizar una liquidacion ---------------------------------%>
    <div class="modal fade" id="modalPago" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title"><b>Realizar una liquidacion</b></h4>
                </div>
                <div class="modal-body">
                    <div class="form-inline">
                        <div class="form-group" style="width: 33%">
                            <label>Monto del cheque:</label>
                            <asp:TextBox ID="txtMontoCheque" Text="0.00" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server" placeholder="Monto Total"></asp:TextBox>
                        </div>
                        <div class="form-group" style="width: 33%">
                            <label>Banco:</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlBanco" Style="width: 100%" Height="34px" runat="server">
                                <asp:ListItem>---</asp:ListItem>
                                <asp:ListItem>Banco Industrial</asp:ListItem>
                                <asp:ListItem>Banco G&T</asp:ListItem>
                                <asp:ListItem>Banrural</asp:ListItem>
                                <asp:ListItem>Banco de Occidente</asp:ListItem>
                                <asp:ListItem>Banco Agromercantil</asp:ListItem>
                                <asp:ListItem>Banco Promerica</asp:ListItem>
                                <asp:ListItem>Bac Credomatic</asp:ListItem>
                                <asp:ListItem>Banco Internacional</asp:ListItem>
                                <asp:ListItem>Banco de los Trabajadores</asp:ListItem>
                                <asp:ListItem>Vivibanco</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group" style="width: 32%">
                            <label>No Cheque:</label>
                            <asp:TextBox ID="txtNumeroCheque" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Numero de cheque" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="form-inline">
                        <div class="form-group" style="width: 48%">
                            <label>Total Reclamado:</label>
                            <asp:TextBox ID="txtReclamado" Text="0.00" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server" placeholder="Total Reclamado"></asp:TextBox>
                        </div>
                        <div class="form-group" style="width: 50%">
                            <label>Total Aprobado:</label>
                            <asp:TextBox ID="txtAprobado" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Total Aprobado" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="form-inline">
                        <div class="form-group" style="width: 48%">
                            <label>Total No Cubierto:</label>
                            <asp:TextBox ID="txtNoCubiertos" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Total no Cubierto" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group" style="width: 50%">
                            <label>Deducible:</label>
                            <asp:TextBox ID="txtDeducible" Text="0.00" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Deducible" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="form-inline">
                        <div class="form-group" style="width: 48%; padding-top: 10px;">
                            <label>Coaseguro:</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlCoaseguro" Style="width: 100%" Height="34px" runat="server">
                                <asp:ListItem Value="0.15">15%</asp:ListItem>
                                <asp:ListItem Value="0.16">16%</asp:ListItem>
                                <asp:ListItem Value="0.17">17%</asp:ListItem>
                                <asp:ListItem Value="0.18">18%</asp:ListItem>
                                <asp:ListItem Value="0.19">19%</asp:ListItem>
                                <asp:ListItem Value="0.20">20%</asp:ListItem>
                                <asp:ListItem Value="0.21">21%</asp:ListItem>
                                <asp:ListItem Value="0.22">22%</asp:ListItem>
                                <asp:ListItem Value="0.23">23%</asp:ListItem>
                                <asp:ListItem Value="0.24">24%</asp:ListItem>
                                <asp:ListItem Value="0.25">25%</asp:ListItem>
                                <asp:ListItem Value="0.26">26%</asp:ListItem>
                                <asp:ListItem Value="0.27">27%</asp:ListItem>
                                <asp:ListItem Value="0.28">28%</asp:ListItem>
                                <asp:ListItem Value="0.29">29%</asp:ListItem>
                                <asp:ListItem Value="0.30">30%</asp:ListItem>
                                <asp:ListItem Value="0.31">31%</asp:ListItem>
                                <asp:ListItem Value="0.32">32%</asp:ListItem>
                                <asp:ListItem Value="0.33">33%</asp:ListItem>
                                <asp:ListItem Value="0.34">34%</asp:ListItem>
                                <asp:ListItem Value="0.35">35%</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group" style="width: 50%; padding-top: 10px;">
                            <label>Timbres:</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlTimbres" Style="width: 100%" Height="34px" runat="server">
                                <asp:ListItem Value="0.03">3%</asp:ListItem>
                                <asp:ListItem Value="0.04">4%</asp:ListItem>
                                <asp:ListItem Value="0.05">5%</asp:ListItem>
                                <asp:ListItem Value="0.06">6%</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-inline">
                        <div class="form-group" style="width: 32%; padding-top: 10px;">
                            <asp:Label Visible="false" ID="lblTotalCoaseguro" Text="Total Coaseguro" runat="server"></asp:Label>
                            <asp:TextBox ID="txtTotalCoaseguro" Visible="false" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Total Coaseguro" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group" style="width: 32%; padding-top: 10px;">
                            <asp:Label Visible="false" ID="lblTotalTimbres" Text="Total Timbres" runat="server"></asp:Label>
                            <asp:TextBox ID="txtTotalTimbres" Visible="false" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Total Timbres" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group" style="width: 34%; padding-top: 10px;">
                            <asp:Label Visible="false" ID="lblTotalLiquidacion" Text="Total" runat="server"></asp:Label>
                            <asp:TextBox ID="txtTotal" Visible="false" Style="width: 100%" Text="0.00" autocomplete="off" class="form-control" placeholder="Total" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-inline">
                        <div class="form-group" style="width: 32%; padding-top: 10px;">
                            <label>Moneda:</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlMoneda" Style="width: 100%" Height="34px" runat="server">
                                <asp:ListItem>Quetzales</asp:ListItem>
                                <asp:ListItem>Dollares</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group" style="width: 32%; padding-top: 10px;">
                            <label>Fecha Envio Cheque:</label>
                            <asp:TextBox runat="server" type="date" ID="txtFechaEnvioCheque" autocomplete="false" Style="width: 100%; height: 34px;" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group" style="width: 34%; padding-top: 10px;">
                            <label>Destino:</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlDestino" Style="width: 100%" Height="34px" runat="server">
                                <asp:ListItem Value="1">En Ruta</asp:ListItem>
                                <asp:ListItem Value="2">Recepcion</asp:ListItem>
                                <asp:ListItem Value="3">Correo</asp:ListItem>
                                <asp:ListItem Value="4">Cerrado Porque no Procede</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btnGuardarPago" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarPago_Click" />
                    <asp:Button ID="btnActualizarPago" Enabled="false" CssClass="btn btn-success" runat="server" Text="Actualizar" OnClick="btnActualizarPago_Click" />
                </div>
            </div>
        </div>
    </div>
    <%-- ------------------------ modal para ingresar un nuevo comentario ------------------------------------------%>
    <div class="modal fade" id="ModalComentario" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title"><b>Agregar Comentario</b></h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Comentario:</label>
                        <asp:TextBox ID="txtComentarios" Style="width: 99%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="6" placeholder="Comentarios Del Reclamo" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btnGuardarComentario" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarComentario_Click" />
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
                        <asp:Button ID="btnSubir" CssClass="btn btn-primary" runat="server" Text="Subir"  OnClick="btnSubir_Click"/>
                    </div>
                </div>
            </div>
        </div>
    <%----------------------  modal para mostrar el reclamo en una proxima fecha -----------------------%>
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
                    <asp:Button ID="btnGuardarProximaFecha" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarProximaFecha_Click" />
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
                <div class="modal-body">
                    <div class="form-inline">
                        <asp:DropDownList ID="ddlNoConforme" class="form-control" Style="width: 60%; height: 30px;" runat="server">
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
                    <asp:CheckBox runat="server" Text="Generar Memo" id="chGenerarMemoProductoNoConforme" AutoPostBack="true" OnCheckedChanged="chGenerarMemoProductoNoConforme_CheckedChanged"/>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btnProductoNoConforme" OnClick="btnProductoNoConforme_Click" CssClass="btn btn-primary" runat="server" Text="Guardar" />
                </div>
            </div>
        </div>
    </div>
    <%-- modal para notificacion de sms --%>
    <div class="modal fade" id="confirmar-sms">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title"><b>Enviar Notificacion por falta de Documentos</b></h4>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnEnviarSMS" CssClass="btn btn-primary" runat="server" Text="Enviar" OnClick="btnEnviarSMS_Click" />
                </div>
            </div>
        </div>
    </div>
    <%---------------------- textbox que sirve para mostrar el estado de un reclamo y asi detener el contador ------------------------------------%>
    <asp:TextBox runat="server" Style="display: none" ID="txtValorEstado"></asp:TextBox>
    <asp:SqlDataSource ID="detalle_gasto_medico" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="select descripcion as Descripcion, cantidad as Cantidad, num_factura as [No. Factura], convert(varchar,fecha_gasto_medico, 103) as Fecha, moneda, id as ID from detalle_gasto_medico where id_reclamo_medico = @id" DeleteCommand="delete from detalle_gasto_medico where id = @id">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblIdOculto" Name="id" PropertyName="Text" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="id" />
        </DeleteParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentJs" runat="Server">
     <script> 
         var id = $('#ContentPlaceHolder1_lblIdOculto').text();
         var ruta = $('#ContentPlaceHolder1_lblDocumento').text();
            function Scaner() {
                window.open('/Modulos/MdScanner/wbGastosMedicos.aspx?id='+id+'', "ventana1", "width=350,height=550,scrollbars=NO")
         }

         function documento() {
             window.open('http://52.34.115.100:5556/files/GastosMedicos/'+ruta+'', "ventana1", "width=700,height=800,scrollbars=NO")
         }

         function buscador() {
             var alto = $(window).height() - 200;
             var ancho = $(window).width() - 700;
             window.open('http://52.34.115.100:5556/explorador.html#files%2FGastosMedicos/'+ ruta, "ventana1", "width=" + ancho + ",height=" + alto + ",scrollbars=NO")
         }
      </script>
</asp:Content>

