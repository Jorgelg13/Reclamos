<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmReclamosMedicosEditar.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmReclamosMedicosEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info col-sm-12 col-md-9 col-lg-9">
            <div class="panel-body">
                <div class="img-float-right" style="float: right; padding-top: 15px;">
                    <asp:Label ID="labelID" runat="server" Text="ID"></asp:Label>
                </div>
                <ul class="nav nav-tabs margen " role="tablist">
                    <li role="presentation"><a href="#messages" class="active" aria-controls="messages" role="tab" data-toggle="tab">Datos En General</a></li>
                    <li role="presentation"><a href="#settings" aria-controls="settings" role="tab" data-toggle="tab">Impresion De Boleta</a></li>
                </ul>
                <div class="tab-content" style="height: 360px; overflow-x: auto;">
                    <br />
                    <%------------------------------ datos del asegurado -----------------------------------%>
                    <div role="tabpanel" class="tab-pane active " id="messages">
                        <div class="panel panel-info col-md-12">
                            <div class="panel-heading">
                                <b>Datos Del Asegurado</b>
                            </div>
                            <div class="panel-body">
                                <div style="height: 230px; overflow-x: auto;">
                                    <div class="panel-body form-inline">
                                        <div class="form-group" style="width: 45%; padding-top: 10px;">
                                            <label for="message-text" class="control-label">Asegurado:</label>
                                            <asp:TextBox runat="server" ID="txtAsegurado" autocomplete="false" Style="width: 100%" class="form-control" placeholder="Asegurado"></asp:TextBox>
                                        </div>
                                        <div class="form-group" style="width: 50%; padding-top: 10px;">
                                            <label for="message-text" class="control-label">Aseguradora:</label>
                                            <asp:TextBox runat="server" ID="txtAseguradora" autocomplete="false" Style="width: 100%" class="form-control" placeholder="Aseguradora"></asp:TextBox>
                                        </div>
                                        <div class="form-group" style="width: 45%; padding-top: 10px;">
                                            <label for="message-text" class="control-label">Poliza:</label>
                                            <asp:TextBox runat="server" ID="txtPoliza" autocomplete="false" Style="width: 100%" class="form-control" placeholder="Poliza"></asp:TextBox>
                                        </div>
                                        <div class="form-group" style="width: 50%; padding-top: 10px;">
                                            <label for="message-text" class="control-label">Telefono:</label>
                                            <asp:TextBox runat="server" ID="txtTelefono" autocomplete="false" Style="width: 100%" class="form-control" placeholder="Telefono"></asp:TextBox>
                                        </div>
                                        <div class="form-group" style="width: 40%; padding-top: 10px;">
                                            <label for="message-text" class="control-label">Correo:</label>
                                            <asp:TextBox runat="server" ID="txtCorreo" autocomplete="false" Style="width: 100%" class="form-control" placeholder="Correo"></asp:TextBox>
                                        </div>
                                        <div class="form-group" style="width: 30%; padding-top: 10px;">
                                            <label for="message-text" class="control-label">Tipo Reclamo:</label>
                                            <asp:DropDownList CssClass="form-control" ID="DDLTipo" Style="width: 100%" Height="34px" runat="server">
                                                <asp:ListItem>Vida</asp:ListItem>
                                                <asp:ListItem>Gastos Medicos</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group" style="width: 25%; padding-top: 10px;">
                                            <label for="message-text" class="control-label">Estado:</label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlEstado" Style="width: 100%" Height="34px" runat="server">
                                                <asp:ListItem Value="4">Asegurado</asp:ListItem>
                                                <asp:ListItem Value="5">Aseguradora</asp:ListItem>
                                                <asp:ListItem Value="3">Anulado</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%------------------------- imprimir el formulario de datos-----------------------------%>
                    <div role="tabpanel" class="tab-pane" id="settings">
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
                                            <asp:Label Style="font-size: 13px;" runat="server" for="message-text" class="control-label">Asegurado Titular:</asp:Label>
                                            <asp:Label Style="font-size: 13px;" runat="server" for="message-text" ID="lblAsegurado" class="control-label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label Style="font-size: 13px;" runat="server" for="message-text" class="control-label">Aseguradora: </asp:Label>
                                            <asp:Label Style="font-size: 13px;" runat="server" for="message-text" ID="lblAseguradora" class="control-label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label Style="font-size: 13px;" runat="server" for="message-text" class="control-label">Poliza:</asp:Label>
                                            <asp:Label Style="font-size: 13px;" runat="server" for="message-text" ID="lblpoliza" class="control-label"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label Style="font-size: 13px;" runat="server" for="message-text" class="control-label">Empresa:</asp:Label>
                                            <asp:Label Style="font-size: 13px;" runat="server" for="message-text" ID="lblEmpresa" class="control-label"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </div>
                            <div>
                                <br />
                                <br />
                                <asp:GridView ID="GridRecibo" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <RowStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:GridView>
                                <ul>
                                    <p><b>IMPORTANTE</b></p>
                                 <li>Si su formulario de reclamo no trae el diagnóstico del médico con la firma y sello. No se recibe para trámite. hasta estar debidamente completado.</li>
                                 <li>Si el expediente de su reclamo esta incompleto. Debe completarlo dentro de los próximos 5 dias hábiles posteriores a la entrega: de no complementarlo, Se le devolverá el expediente se le devolvera a la dirección que tenemos registrada.</li>
                                 <li>Facturas deben de venir únicamente a nombre del asegurado titular de la Póliza y en original (Roble puede recibir copias).</li>
                                 <li>Recetas Médicas. Ordenes y resultados de exámenes pueden ser en fotocopia completa y legible </li>
                                </ul>
                                <br />
                                <br />
                                <p>Firma de quien entrega papeleria:_______________________________  Fecha Recepcion:____________________</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- panel lateral con informacion de la poliza--%>
        <div class="col-md-3">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><b>Datos De la Poliza</b></h3>
                </div>
                <div class="panel-body">
                    <asp:Label ID="lblAsegurado2" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblPoliza2" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblRamo" runat="server"></asp:Label>
                    <br />
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
        <%------------------ botones laterales grandes  ------------------- --%>
        <div class="btn-acciones-laterales">
            <div class="col-md-1 col-sm-2">
                <div class="panel panel-info">
                    <div class="panel-heading">
                    </div>
                    <div class="panel-body">
                        <a href="#" onclick="printDiv('imprimir')" title="Imprimir El Formulario de documentos" style="font-size: 70px;"><i class="fa fa-print" aria-hidden="true"></i></a>
                    </div>
                </div>
            </div>
            <div class="col-md-1 col-sm-2 ">
                <div class="panel panel-info">
                    <div class="panel-heading">
                    </div>
                    <div class="panel-body">
                        <asp:LinkButton ID="linkGuardarR" OnClick="btnActualizar_Click" title="Actualizar Informacion" runat="server" Style="font-size: 70px; text-align: center;"><i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="col-md-1 col-sm-2">
                <div class="panel panel-info">
                    <div class="panel-heading">
                    </div>
                    <div class="panel-body">
                        <a href="#" title="Agregar un comentario" style="font-size: 70px;"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function printDiv(imprimir) {
            var contenido = document.getElementById(imprimir).innerHTML;
            var contenidoOriginal = document.body.innerHTML;
            document.body.innerHTML = contenido;
            window.print();
            document.body.innerHTML = contenidoOriginal;
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

