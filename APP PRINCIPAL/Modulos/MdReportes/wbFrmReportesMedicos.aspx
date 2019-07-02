<%@ Page Title="Reporte Gastos Medicos" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="wbFrmReportesMedicos.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmReportesMedicos" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-sm-12 col-md-2 col-lg-2">
        <div class="panel panel-info">
            <div class="panel-heading">
                <h3 class="panel-title"><b style="font-size: 16px;">Seleccione los campos</b></h3>
            </div>
            <div class="panel-body" style="height: 525px; max-height: 600px; overflow-x: auto; overflow-y: auto;">
                <asp:CheckBox ID="CheckTodos" Text="Seleccionar Todos" AutoPostBack="true" runat="server" OnCheckedChanged="CheckTodos_CheckedChanged" />
                <asp:CheckBoxList ID="checkCampos" runat="server" Height="141px" Width="147px">
                    <asp:ListItem Value="reg.asegurado as Asegurado">Asegurado</asp:ListItem>
                    <asp:ListItem Value="reg.poliza as Poliza">Poliza</asp:ListItem>
                    <asp:ListItem Value="reg.aseguradora as Aseguradora">Aseguradora</asp:ListItem>
                    <asp:ListItem Value="reg.cliente as Cliente">No. Cliente</asp:ListItem>
                    <asp:ListItem Value="reg.telefono_acs as [Telefono ACS]">Telefono acs</asp:ListItem>
                    <asp:ListItem Value="r.estado_unity as [Estado Reclamo]">Estado Reclamo</asp:ListItem>
                    <asp:ListItem Value="r.usuario_unity as Usuario">Usuario</asp:ListItem>
                    <asp:ListItem Value="r.telefono as Telefono">Telefono</asp:ListItem>
                    <asp:ListItem Value="r.correo as Correo">Correo</asp:ListItem>
                    <asp:ListItem Value="r.empresa as Empresa">Empresa</asp:ListItem>
                    <asp:ListItem Value="r.tipo_reclamo as [Tipo Reclamo]">Tipo Reclamo</asp:ListItem>
                    <asp:ListItem Value="reg.ramo as Ramo">Ramo</asp:ListItem>
                    <asp:ListItem Value="reg.tipo as Tipo">Tipo</asp:ListItem>
                    <asp:ListItem Value="reg.clase as Clase">Clase</asp:ListItem>
                    <asp:ListItem Value="reg.ejecutivo as Ejecutivo">Ejecutivo</asp:ListItem>
                    <asp:ListItem Value="reg.estado_poliza as [Estado Poliza]">Estado Poliza</asp:ListItem>
                    <asp:ListItem Value="reg.vip as VIP">VIP</asp:ListItem>
                    <asp:ListItem Value="reg.moneda as Moneda">Moneda</asp:ListItem>
                    <asp:ListItem Value="r.fecha_commit as [Fecha Creacion]">Fecha Creacion</asp:ListItem>
                    <asp:ListItem Value="r.fecha_revision as [Fecha Revision]">Fecha Revision</asp:ListItem>
                    <asp:ListItem Value="r.fecha_envio_aseg as [Fecha Envio Aseguradora]">Fecha Envio Aseg.</asp:ListItem>
                    <asp:ListItem Value="r.fecha_modificacion as [Fecha Modificacion]">Fecha Modificacion</asp:ListItem>
                    <asp:ListItem Value="r.fecha_envio_cheque as [Fecha Envio Cheque]">Fecha Env. Cheque</asp:ListItem>
                    <asp:ListItem Value="r.fecha_cierre as [Fecha Cierre]">Fecha Cierre</asp:ListItem>
                    <asp:ListItem Value="r.titular as Titular">Titular</asp:ListItem>
                    <asp:ListItem Value="r.detalle_cliente">Detalle Cliente</asp:ListItem>
                    <asp:ListItem Value="r.observacion as Observacion">Observacion</asp:ListItem>
                    <asp:ListItem Value="reg.certificado as Certificado">Certificado</asp:ListItem>
                    <asp:ListItem Value="r.num_reclamo as [Numero Reclamo]">Numero Reclamo</asp:ListItem>
                    <asp:ListItem Value="CONCAT(DATEDIFF(MINUTE, r.fecha_completa_commit,r.fecha_asignacion)/60 ,':',
                                                    DATEDIFF(MINUTE, r.fecha_completa_commit,r.fecha_asignacion)%60 ,':',
                                                    DATEDIFF(SECOND, r.fecha_completa_commit,r.fecha_asignacion)%60 ) as [Fecha creacion A Fecha Asignacion] ">Fecha Apertura a fecha asignacion</asp:ListItem>
                    <asp:ListItem Value="CONCAT(DATEDIFF(MINUTE, r.fecha_asignacion,r.fecha_apertura)/60, ':',
                                                    DATEDIFF(MINUTE, r.fecha_asignacion,r.fecha_apertura)%60, ':',
	                                                DATEDIFF(SECOND, r.fecha_asignacion,r.fecha_apertura)%60 ) as [Fecha Asignacion A Fecha Apertura] ">Fecha Asignacion a Fecha Apertura</asp:ListItem>
                    <asp:ListItem Value="CONCAT(DATEDIFF(MINUTE, r.fecha_apertura, r.fecha_envio_aseg)/60, ':',
	                                                DATEDIFF(MINUTE, r.fecha_apertura, r.fecha_envio_aseg)%60, ':',
	                                                DATEDIFF(SECOND, r.fecha_apertura, r.fecha_envio_aseg)%60 ) as [Fecha Apertura A Fecha Envio Aseguradora] ">Fecha Apertura A fecha env. Aseguradora</asp:ListItem>
                    <asp:ListItem Value="CONCAT(DATEDIFF(MINUTE, r.fecha_envio_aseg,r.fecha_recepcion_cheque)/60, ':',
	                                                DATEDIFF(MINUTE, r.fecha_envio_aseg,r.fecha_recepcion_cheque)%60, ':',
	                                                DATEDIFF(SECOND, r.fecha_envio_aseg,r.fecha_recepcion_cheque)%60 ) as [Fecha Aseguradora a Fecha Recepcion] ">Fecha Aseguradora a Fecha Recepcion</asp:ListItem>
                    <asp:ListItem Value="CONCAT(DATEDIFF(MINUTE, r.fecha_completa_commit, r.fecha_cierre)/60, ':',
	                                                DATEDIFF(MINUTE, r.fecha_completa_commit, r.fecha_cierre)%60, ':',
	                                                DATEDIFF(SECOND, r.fecha_completa_commit, r.fecha_cierre)%60 ) as [Fecha Creacion a cierre] ">Fecha creacion a cierre</asp:ListItem>
                </asp:CheckBoxList>
            </div>
        </div>
    </div>
    <asp:Panel ID="PnReporte" runat="server">
        <div class="col-sm-12 col-md-10 col-lg-10">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <b>Tabla con campos seleccionados<label style="margin-left: 50px">Total de registros: </label>
                        <asp:Label ID="lblConteo" runat="server" Style="font-size: 20px;"></asp:Label></b>
                    <asp:CheckBox ID="checkSinFiltro" Style="margin-left: 50px" AutoPostBack="true" runat="server" Text="Sin Ningun Filtro" OnCheckedChanged="checkSinFiltro_CheckedChanged" />
                    <asp:DropDownList ID="ddlCiclos" runat="server" Style="width: 15%; height: 24px;">
                        <asp:ListItem Value="Ciclo Aseguradora">Ciclo Aseguradora</asp:ListItem>
                        <asp:ListItem Value="Ciclo Cliente">Ciclo Total</asp:ListItem>
                        <asp:ListItem Value="Ciclo Ejecutivo">Ciclo Unity</asp:ListItem>
                        <asp:ListItem Value="Ciclo Ejecutivo por etapa">Ciclo Ejecutivo por etapas</asp:ListItem>
                        <asp:ListItem Value="Eficiencia">Eficiencia</asp:ListItem>
                    </asp:DropDownList>
                    <label>Moneda</label>
                    <asp:DropDownList ID="ddlMoneda" runat="server" Style="width: 10%; height: 24px;">
                        <asp:ListItem Value="reg.moneda in ('Dolares','Quetzales') or reg.moneda is null ">Ambas</asp:ListItem>
                        <asp:ListItem Value="reg.moneda = 'Dolares'">Dolares</asp:ListItem>
                        <asp:ListItem Value="reg.moneda = 'Quetzales'">Quetzales</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Mostrar" OnClick="Mostrar_Click" Style="margin-left: 20px" runat="server" Text="Mostrar" />
                </div>
                <div class="panel-body" style="height: 520px;">
                    <div class="row">
                        <div class="form-group col-md-2 col-lg-2">
                            <label>Busqueda:</label>
                            <asp:DropDownList ID="ddlElegir" runat="server" Style="width: 100%" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlElegir_SelectedIndexChanged">
                                <asp:ListItem Value="reg.poliza ">Poliza</asp:ListItem>
                                <asp:ListItem Value="r.usuario_unity ">Usuario</asp:ListItem>
                                <asp:ListItem Value="reg.aseguradora ">Aseguradora</asp:ListItem>
                                <asp:ListItem Value="reg.asegurado">Asegurado</asp:ListItem>
                                <asp:ListItem Value="reg.titular">Titular</asp:ListItem>
                                <asp:ListItem Value="reg.moneda">Moneda</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-2 col-lg-2">
                            <label>Registros a buscar:</label>
                            <asp:TextBox ID="txtBuscar" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                            <asp:DropDownList ID="ddlBuscar" Visible="false" runat="server" Style="width: 100%" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-2 col-lg-2">
                            <label>Tipo:</label>
                            <asp:DropDownList ID="ddlTipoReclamo" runat="server" Style="width: 100%" CssClass="form-control">
                                <asp:ListItem Value="reg.tipo = 'I'">Individual</asp:ListItem>
                                <asp:ListItem Value="reg.tipo = 'C'">Colectivos</asp:ListItem>
                                <asp:ListItem Value="reg.tipo = 'I' or reg.tipo = 'C'">Todos</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-2 col-lg-2">
                            <label>Estado:</label>
                            <asp:DropDownList ID="ddlEstado" runat="server" Style="width: 100%" CssClass="form-control">
                                <asp:ListItem Value="r.estado_unity = 'Cerrado'">Cerrado</asp:ListItem>
                                <asp:ListItem Value="r.estado_unity = 'Seguimiento'">Seguimiento</asp:ListItem>
                                <asp:ListItem Value="r.estado_unity = 'Seguimiento' or r.estado_unity = 'Cerrado'">Todos</asp:ListItem>
                                <asp:ListItem>Aperturados</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-2 col-lg-2">
                            <label>Fecha Inicio:</label>
                            <asp:TextBox ID="txtFechaInicio" Height="32px" type="date" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-2 col-lg-2">
                            <label>Fecha Fin:</label>
                            <asp:TextBox ID="txtFechaFin" type="date" Height="32px" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridCamposSeleccion" runat="server" CssClass="table bs-table table-responsive" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <%----------------------------  ciclo de los reclamos por aseguradora  ---------------------%>
    <asp:Panel runat="server" ID="PanelPrincipal" Visible="false">
        <div class="col-sm-10">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:LinkButton ID="linKRegresar" OnClick="linKRegresar_Click" title="Regresar al reporte" runat="server" Style="padding-left: 20px; padding-right: 10px; font-size: 26px; color: darkblue"><i class="fa fa-arrow-circle-o-left"></i></asp:LinkButton>
                    <asp:LinkButton ID="linkDescarExcel" OnClick="linkDescarExcel_Click" title="Descargar en excel" runat="server" Style="font-size: 26px; color: green"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                    <a title="Imprimir o descargar PDF" onclick="printDiv('Imprimir')" role="button" style="font-size: 26px; padding-left: 10px; color: red"><i class="fa fa-file-pdf-o"></i></a>
                </div>
                <div id="Imprimir">
                    <div class="img-float-right" style="float: right; padding-top: 80px;">
                        <img src="../../imgUnity/Unity%20Promotores%20transparente.png" style="margin-top: -100px; width: 205px;">
                    </div>
                    <div style="text-align: center; font-size: 15px;">
                        <b>
                            <asp:Label runat="server" ID="lblTitulo"></asp:Label></b>
                        <br />
                        <asp:Label runat="server" ID="lblPeriodo"></asp:Label>
                        <br />
                        <asp:Label Style="padding-left: 20px;" runat="server" ID="lblFechaGeneracion"></asp:Label>
                        <table style="width: 100%;">
                            <tr style="text-align: left;">
                                <td>
                                    <asp:Label runat="server" ID="lblMoneda"></asp:Label></td>
                                <td>
                                    <asp:Label runat="server" ID="lblUsuario"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblKpi" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </div>
                    <asp:Panel ID="PnCicloAseguradora" Visible="false" runat="server">
                        <div class="panel-body" style="height: auto;">
                            <asp:GridView ID="GridPromedioAseguradora" runat="server" OnRowDataBound="GridPromedioAseguradora_RowDataBound" CssClass="table bs-table table-responsive " AutoGenerateColumns="True" ShowFooter="true" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            </asp:GridView>
                        </div>
                    </asp:Panel>
                    <%----------------------------  ciclo de los reclamos por cliente  ---------------------%>
                    <asp:Panel ID="PnCicloCliente" Visible="false" runat="server">
                        <asp:GridView ID="GridCicloCliente" runat="server" CssClass="table bs-table table-responsive" ShowFooter="true" OnRowDataBound="GridCicloCliente_RowDataBound" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        </asp:GridView>
                    </asp:Panel>
                    <%----------------------------  ciclo de los reclamos por ejecutivo KPI  ---------------------%>
                    <asp:Panel ID="PnCicloEjecutivoKPI" Visible="false" runat="server">
                        <asp:GridView ID="GridEjecutivosKPI" runat="server" CssClass="table bs-table table-responsive" ShowFooter="true" OnRowDataBound="GridEjecutivosKPI_RowDataBound" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        </asp:GridView>
                    </asp:Panel>
                    <asp:Panel ID="PnCicloEjecutivo" Visible="false" runat="server">
                        <h3><b style="font-size: 16px;">Promedio Ejecutivo (Creacion / Asignacion)</b></h3>
                        <asp:GridView ID="GridCicloEjecutivo" runat="server" CssClass="table bs-table table-responsive col-lg-5" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        </asp:GridView>
                        <h3><b style="font-size: 16px;">Promedio Ejecutivo (Asignacion / Apertura)</b></h3>
                        <asp:GridView ID="GridCicloAsignacionApertura" runat="server" CssClass="table bs-table table-responsive" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        </asp:GridView>
                        <h3><b style="font-size: 16px;">Promedio Ejecutivo (Apertura / Aseguradora)</b></h3>
                        <asp:GridView ID="GridAperturaAseguradora" runat="server" CssClass="table bs-table table-responsive" AutoGenerateColumns="True"  ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        </asp:GridView>
                        <h3><b style="font-size: 16px;">Promedio Ejecutivo (Recepcion Cheque / Cierre)</b></h3>
                        <asp:GridView ID="GridRecepcionChequeCierre" runat="server" CssClass="table bs-table table-responsive" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        </asp:GridView>
                    </asp:Panel>
                    <%---------------------------- Eficiencia de usuarios  ---------------------%>
                    <asp:Panel ID="PnEficiencia" Visible="false" runat="server">
                        <asp:GridView ID="GridEficiencia" runat="server" CssClass="table bs-table table-responsive table-hover" OnRowDataBound="GridEficiencia_RowDataBound" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None" AllowCustomPaging="True" ShowFooter="true">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        </asp:GridView>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </asp:Panel>
    <%-- botones circulares con las opciones multiples --%>
    <div id="container-floating">
        <div class="nd4 nds" data-toggle="tooltip" data-placement="left" data-original-title="Simone">
            <asp:LinkButton ID="linkSalir" CssClass="letter" OnClick="linkSalir_Click" runat="server"><i class="fa fa-times" aria-hidden="true"></i></asp:LinkButton>
        </div>
        <div class="nd3 nds" data-toggle="tooltip" data-placement="left" data-original-title="contract@gmail.com">
            <asp:LinkButton ID="btnExportar" OnClick="btnExportar_Click" CssClass="letter" runat="server"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
        </div>
        <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
            <asp:LinkButton ID="btnGenerarTabla" OnClick="btnGenerarTabla_Click" CssClass="letter" autopostback="true" runat="server"><i class="fa fa-table" aria-hidden="true"></i></asp:LinkButton>
        </div>
        <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
            <p class="plus">+</p>
            <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentJs" ID="JS">
    <script>
        function printDiv(imprimir) {
            var contenido = document.getElementById(imprimir).innerHTML;
            var contenidoOriginal = document.body.innerHTML;
            document.body.innerHTML = contenido;
            window.print();
            document.body.innerHTML = contenidoOriginal;
            window.location.href = "/Modulos/MdReportes/wbFrmReportesMedicos.aspx";
        }
    </script>
    <script>
        try {
            $('#ContentPlaceHolder1_GridCicloCliente tr').each(function (index) {
                $tr = $(this);
                $td = $tr[0].cells[3];
                $td.remove();
                if (index > 0) {
                    $td = $tr[0].cells[3];
                    $td.innerText = $td.innerText + ' %';
                    $td.className = 'alinearNumeros';
                }
            });
        } catch (ex) {
        }

        try {
            $('#ContentPlaceHolder1_GridPromedioAseguradora tr').each(function (index) {
                $tr = $(this);
                $td = $tr[0].cells[3];
                $td.remove();
                if (index > 0) {
                    $td = $tr[0].cells[3];
                    $td.innerText = $td.innerText + ' %';
                    $td.className = 'alinearNumeros';

                }
            });
        } catch (ex) {
        }

        try {
            $('#ContentPlaceHolder1_GridEjecutivosKPI tr').each(function (index) {
                $tr = $(this);
                if (index > 0) {
                    $td = $tr[0].cells[3];
                    $td.innerText = $td.innerText + ' %';
                    $td.className = 'alinearNumeros';

                    $td = $tr[0].cells[2];
                    $td.innerText = $td.innerText + ' hrs';
                }
            });
        } catch (ex) {
        }

        try {
            $('#ContentPlaceHolder1_GridEficiencia tr').each(function (index) {
                $tr = $(this);
                if (index > 0) {
                    $td = $tr[0].cells[5];
                    $td.innerText = $td.innerText + ' %';
                    $td.className = 'alinearNumeros';
                }
            });
        } catch (ex) {
        }

    </script>
</asp:Content>

