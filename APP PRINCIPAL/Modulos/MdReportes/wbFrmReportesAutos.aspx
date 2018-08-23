<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="wbFrmReportesAutos.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmReportesAutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div class="col-sm-2">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><b style="font-size: 16px;">Seleccione los campos</b></h3>
                </div>
                <div class="panel-body scrolling-table-container" style="height: 525px; max-height: 600px;">
                    <asp:CheckBox runat="server" AutoPostBack="true" Text="Todos" ID="checkTodos" OnCheckedChanged="checkTodos_CheckedChanged" />
                    <asp:CheckBoxList ID="checkCampos" runat="server" Height="141px" Width="147px">
                        <asp:ListItem Value="reclamo_auto.estado_auto_unity as [Estado Auto]">Estado Auto</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.poliza as Poliza">Poliza</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.asegurado as Asegurado">Asegurado</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.cliente as Cliente">Cliente</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.vip as VIP">VIP</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.placa as Placa">Placa</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.marca as Marca">Marca</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.color as Color">Color</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.modelo as Modelo">Modelo</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.chasis as Chasis">Chasis</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.motor as Motor">Motor</asp:ListItem>
                        <asp:ListItem Value="(select top 1 cobertura from coberturas_afectadas where id_reclamo_auto = reclamo_auto.id) as [Cobertura Afectada]">Cober.Afectada</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.propietario as Propietario">Propietario</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.ejecutivo as Ejecutivo">Ejecutivo</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.aseguradora as Aseguradora">Aseguradora</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.contratante as Contratante">Contratante</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.estado_poliza as Estado_Poliza">Estatus Poliza</asp:ListItem>
                        <asp:ListItem Value="reclamo_auto.boleta as Boleta">Boleta</asp:ListItem>
                        <asp:ListItem Value="reclamo_auto.titular as Titular">Titular</asp:ListItem>
                        <asp:ListItem Value="reclamo_auto.hora as [Hora Siniestro]">Hora Siniestro</asp:ListItem>
                        <asp:ListItem Value="Convert(varchar(10),reclamo_auto.fecha, 103) As [Fecha Siniestro]">Fecha Siniestro</asp:ListItem>
                        <asp:ListItem Value="Convert(varchar(10),reclamo_auto.fecha_commit, 103) As [Fecha Creacion]">Fecha Creacion</asp:ListItem>
                        <asp:ListItem Value="reclamo_auto.ubicacion as Ubicacion">Ubicacion</asp:ListItem>
                        <asp:ListItem Value="reclamo_auto.reportante as Reportante">Reportante</asp:ListItem>
                        <asp:ListItem Value="reclamo_auto.version as Version">Version</asp:ListItem>
                        <asp:ListItem Value="(select top 1 CONCAT(fecha, '  /  ', descripcion) from comentarios_reclamos_autos where id_reclamo_auto = reclamo_auto.id order by id desc) as [Ultimo Comentario]">Ultimo Comentario</asp:ListItem>
                        <asp:ListItem Value="reclamo_auto.edad as Edad">Edad</asp:ListItem>
                        <asp:ListItem Value="reclamo_auto.telefono as Telefono">Telefono</asp:ListItem>
                        <asp:ListItem Value="reclamo_auto.ajustador as Ajustador">Ajustador</asp:ListItem>
                        <asp:ListItem Value="reclamo_auto.compromiso_pago as [Compromiso Pago]">Compromiso Pago</asp:ListItem>
                        <asp:ListItem Value="reclamo_auto.alquiler_auto as [Alquiler Auto]">Alquiler Auto</asp:ListItem>
                        <asp:ListItem Value="reclamo_auto.perdida_total as [Perdida Total]">Perdida Total</asp:ListItem>
                        <asp:ListItem Value="talleres.nombre as Taller">Taller</asp:ListItem>
                        <asp:ListItem Value="analistas.nombre as Analista">Analista</asp:ListItem>
                        <asp:ListItem Value="reclamo_auto.cierre_interno">Cierre Interno</asp:ListItem>
                        <asp:ListItem Value="reclamo_auto.num_reclamo">Numero Reclamo</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.moneda">Moneda</asp:ListItem>
                        <asp:ListItem Value="gestores.nombre as [Gestor Reclamo]">Gestor Reclamo</asp:ListItem>
                        <asp:ListItem Value="contacto_auto.contacto as Contacto">Contacto</asp:ListItem>
                        <asp:ListItem Value="contacto_auto.telefono as [Telefono Contacto]">Telefono Contc.</asp:ListItem>
                        <asp:ListItem Value="contacto_auto.correo as [Correo Contacto]">Correo Contc.</asp:ListItem>
                        <asp:ListItem Value="auto_reclamo.cliente as [No. Cliente]">No. Cliente</asp:ListItem>
                        <asp:ListItem Value="cabina.nombre as Cabina">Cabina</asp:ListItem>
                        <asp:ListItem Value="sucursal.nombre as Sucursal">Sucursal</asp:ListItem>
                        <asp:ListItem Value="empresa.nombre as Empresa">Empresa</asp:ListItem>
                        <asp:ListItem Value="pais.nombre as Pais">Pais</asp:ListItem>
                        <asp:ListItem Value="usuario.nombre as Usuario_cabina">Usuario Cabina</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
        <asp:Panel runat="server" ID="PnReporte">
            <div class="col-sm-10">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <b>Tabla con campos seleccionados<spam style="margin-left: 50px">Total de registros:</spam><asp:Label ID="lblConteo" runat="server"></asp:Label></b>
                        <asp:CheckBox ID="checkSinFiltro" Checked="true" AutoPostBack="true" runat="server" Text="Sin Ningun Filtro" OnCheckedChanged="checkSinFiltro_CheckedChanged" Style="padding-left: 20px;" />
                        <asp:DropDownList ID="ddlCiclos" runat="server" Style="width: 25%; height: 26px; margin-left: 20px;">
                            <asp:ListItem Value="Ciclo Total">Ciclo Total</asp:ListItem>
                            <asp:ListItem Value="Ciclo Unity">Ciclo Unity</asp:ListItem>
                            <asp:ListItem Value="Ciclo Cliente">Ciclo Cliente</asp:ListItem>
                            <asp:ListItem Value="Ciclo Aseguradora">Ciclo Aseguradora</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="Mostrar" Style="margin-left: 20px" runat="server" Text="Mostrar" OnClick="Mostrar_Click" />
                        <asp:Button ID="btnMostrarEficiencia" OnClick="btnMostrarEficiencia_Click" Style="margin-left: 20px" runat="server" Text="Eficiencia" />
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="form-group col-sm-12 col-md-6 col-lg-3">
                                <label>Seleccionar Busqueda:</label>
                                <asp:DropDownList ID="ddlElegir" runat="server" Style="width: 100%" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlElegir_SelectedIndexChanged">
                                    <asp:ListItem Value="auto_reclamo.asegurado">Asegurado</asp:ListItem>
                                    <asp:ListItem Value="auto_reclamo.cliente">No.Cliente</asp:ListItem>
                                    <asp:ListItem Value="reclamo_auto.estado_auto_unity">Estado Auto</asp:ListItem>
                                    <asp:ListItem Value="gestores.nombre">Gestor</asp:ListItem>
                                    <asp:ListItem Value="reclamo_auto.ajustador">Ajustador</asp:ListItem>
                                    <asp:ListItem Value="auto_reclamo.ejecutivo">Ejecutivo</asp:ListItem>
                                    <asp:ListItem Value="talleres.nombre">Taller</asp:ListItem>
                                    <asp:ListItem Value="auto_reclamo.poliza">Poliza</asp:ListItem>
                                    <asp:ListItem Value="reclamo_auto.cierre_interno">Cierre Interno</asp:ListItem>
                                    <asp:ListItem Value="auto_reclamo.aseguradora">Aseguradora</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group  col-sm-12 col-md-6 col-lg-3">
                                <label>Registros a buscar:</label>
                                <asp:TextBox ID="txtBuscar" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                                <asp:DropDownList ID="ddlBuscar" Visible="false" runat="server" Style="width: 100%" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group  col-sm-12 col-md-6 col-lg-2">
                                <label>Estado:</label>
                                <asp:DropDownList ID="ddlEstado" runat="server" Style="width: 100%" CssClass="form-control">
                                    <asp:ListItem Value="Cerrado">Cerrado</asp:ListItem>
                                    <asp:ListItem Value="Seguimiento">Seguimiento</asp:ListItem>
                                    <asp:ListItem Value="Todos">Todos</asp:ListItem>
                                    <asp:ListItem Value="Nuevos">Nuevos</asp:ListItem>
                                    <asp:ListItem Value="Pendientes">Pendientes</asp:ListItem>
                                    <asp:ListItem Value="Estado">Estado</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group  col-sm-12 col-md-6 col-lg-2">
                                <label>Fecha Inicio:</label>
                                <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group  col-sm-12 col-md-6 col-lg-2">
                                <label>Fecha Fin:</label>
                                <asp:TextBox ID="txtFechaFin" type="date" Height="34px" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Panel runat="server" ID="PanelPrincipal">
                            <div style="text-align: center; font-size: 20px;">
                                <b>
                                    <asp:Label runat="server" ID="lblTitulo"></asp:Label></b>
                                <br />
                                <asp:Label runat="server" ID="lblPeriodo"></asp:Label>
                                <br />
                                <asp:Label runat="server" ID="lblFechaGeneracion"></asp:Label>
                                <asp:Label runat="server" ID="lblUsuario" Style="padding-right: 15px;"></asp:Label>
                            </div>
                            <asp:Panel runat="server" ID="PanelCamposSeleccion" Visible="false">
                                <div class="scrolling-table-container" style="overflow-y: auto;">
                                    <asp:GridView ID="GridCamposSeleccion" runat="server" CssClass="table bs-table table-responsive" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None" PageSize="3000">
                                        <AlternatingRowStyle BackColor="White" />
                                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                                    </asp:GridView>
                                </div>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="PanelEficiencia" Visible="false">
                                <div class="scrolling-table-container" style="overflow-y: auto;">
                                    <asp:GridView ID="GridEficiencia" runat="server" CssClass="table bs-table table-responsive" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None" AllowCustomPaging="True" PageSize="3000" OnRowDataBound="GridEficiencia_RowDataBound" ShowFooter="true">
                                        <AlternatingRowStyle BackColor="White" />
                                        <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                                    </asp:GridView>
                                </div>
                            </asp:Panel>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <%----------------------------  ciclo de los reclamos  ---------------------%>
        <asp:Panel ID="PnCiclos" Visible="false" runat="server">
            <div class="col-sm-10">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h3 class="panel-title"><b style="font-size: 16px;">Promedio Por Aseguradora</b></h3>
                    </div>
                    <div class="panel-body" style="height: 520px;">
                        <div class="scrolling-table-container" style="overflow-y: auto;">
                            <asp:GridView ID="GridCiclos" runat="server" CssClass="table bs-table table-responsive" OnRowDataBound="GridCiclos_RowDataBound" AutoGenerateColumns="True" ShowFooter="true" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            </asp:GridView>
                        </div>
                        <asp:Label ID="lblTotalPonderados" runat="server"></asp:Label>
                        <asp:LinkButton ID="linKRegresar" OnClick="linKRegresar_Click" title="Regresar al reporte" runat="server" Style="padding-left: 20px; font-size: 70px; text-align: center; color: lightblue"><i class="fa fa-arrow-circle-o-left" aria-hidden="true"></i></asp:LinkButton>
                        <asp:LinkButton ID="linkDescarPromedio" OnClick="linkDescarPromedio_Click" title="Descargar en excel" runat="server" Style="font-size: 70px; text-align: center; color: green"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
                        <b>
                            <asp:Label ID="lblTituloCiclo" Style="font-size: 25px; padding-left: 50px;" runat="server"></asp:Label></b>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <%-- botones circulares con las opciones multiples --%>
        <div id="container-floating">
            <div class="nd4 nds" data-toggle="tooltip" data-placement="left" data-original-title="Simone">
                <asp:LinkButton ID="linkSalir" CssClass="letter" OnClick="linkSalir_Click" runat="server"><i class="fa fa-times" ></i></asp:LinkButton>
            </div>
            <div class="nd3 nds" data-toggle="tooltip" data-placement="left" data-original-title="contract@gmail.com">
                <asp:LinkButton ID="btnExportar" OnClick="btnExportar_Click" CssClass="letter" runat="server"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
            </div>
            <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
                <asp:LinkButton ID="btnGenerarTabla" OnClick="btnGenerarTabla_Click" CssClass="letter" autopostback="true" runat="server"><i class="fa fa-table"></i></asp:LinkButton>
            </div>
            <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
                <p class="plus">+</p>
                <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentJs" ID="JS">
    <script>
        try {
            $('#ContentPlaceHolder1_GridEficiencia tr').each(function (index) {
                $tr = $(this);
                if (index > 0) {
                    $td = $tr[0].cells[4];
                    $td.innerText = $td.innerText + ' %';
                    $td.className = 'alinearNumeros';
                }
            });
        } catch (ex) {
        }
    </script>
</asp:Content>



