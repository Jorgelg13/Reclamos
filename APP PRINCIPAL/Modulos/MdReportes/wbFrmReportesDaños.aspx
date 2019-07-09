<%@ Page Title="Reportes Daños" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="wbFrmReportesDaños.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmReportesDaños" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="">
        <div class="col-sm-2">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><b style="font-size: 16px;">Seleccione los campos</b></h3>
                </div>
                <div class="panel-body scrolling-table-container" style="height: 525px; max-height: 600px;">
                    <asp:CheckBox Text="Todos" runat="server" ID="checkTodos" AutoPostBack="true" OnCheckedChanged="checkTodos_CheckedChanged" />
                    <asp:CheckBoxList ID="checkCampos" runat="server" Height="141px" Width="147px">
                        <asp:ListItem Value="reclamos_varios.estado_unity as [Estado Reclamo]">Estado</asp:ListItem>
                        <asp:ListItem Value="reclamos_varios.estado_reclamo_unity as [Estado Reclamo Unity]">Estado Unity</asp:ListItem>
                        <asp:ListItem Value="reg_reclamo_varios.poliza as Poliza">Poliza</asp:ListItem>
                        <asp:ListItem Value="reg_reclamo_varios.asegurado as Asegurado">Asegurado</asp:ListItem>
                        <asp:ListItem Value="reg_reclamo_varios.cliente as Cliente">Cliente</asp:ListItem>
                        <asp:ListItem Value="reg_reclamo_varios.aseguradora as Aseguradora">Aseguradora</asp:ListItem>
                        <asp:ListItem Value="reg_reclamo_varios.contratante as Contrante">Contratante</asp:ListItem>
                        <asp:ListItem Value="reg_reclamo_varios.ejecutivo as Ejecutivo">Ejecutivo</asp:ListItem>
                        <asp:ListItem Value="reg_reclamo_varios.ramo as Ramo">Ramo</asp:ListItem>
                        <asp:ListItem Value="reg_reclamo_varios.status as Estatus">Estatus Poliza</asp:ListItem>
                        <asp:ListItem Value="reg_reclamo_varios.tipo as Tipo">Tipo</asp:ListItem>
                        <asp:ListItem Value="reg_reclamo_varios.direccion as Direccion">Direccion</asp:ListItem>
                        <asp:ListItem Value="reg_reclamo_varios.vip as VIP">Vip</asp:ListItem>
                        <asp:ListItem Value="reg_reclamo_varios.suma_asegurada as [Suma Asegurada]">Suma Asegurada</asp:ListItem>
                        <asp:ListItem Value="reg_reclamo_varios.moneda as Moneda">Moneda</asp:ListItem>
                        <asp:ListItem Value="reclamos_varios.boleta as Boleta">Boleta</asp:ListItem>
                        <asp:ListItem Value="reclamos_varios.titular as Titular">Titular</asp:ListItem>
                        <asp:ListItem Value="reclamos_varios.reportante as Reportante ">Reportante</asp:ListItem>
                        <asp:ListItem Value="reclamos_varios.telefono as Telefono">Telefono</asp:ListItem>
                        <asp:ListItem Value="reclamos_varios.ajustador as Ajustador">Ajustador</asp:ListItem>
                        <asp:ListItem Value="reclamos_varios.reserva as Reserva">Reserva</asp:ListItem>
                        <asp:ListItem Value="reclamos_varios.version as Version">Version</asp:ListItem>
                        <asp:ListItem Value="(select top 1 CONCAT(fecha,'  /  ', descripcion) from comentarios_reclamos_varios where id_reclamos_varios = reclamos_varios.id order by id desc) as [Ultimo Comentario]">Ultimo Comentario</asp:ListItem>
                        <asp:ListItem Value="detalle_pagos_reclamos_varios.cobertura_pagada as [Cobertura Pagada]">Cobertura Pagada</asp:ListItem>
                        <asp:ListItem Value="detalle_pagos_reclamos_varios.valor_indemnizado as [Valor Indemnizado]">Valor Indemnizado</asp:ListItem>
                        <asp:ListItem Value="reclamos_varios.ubicacion as Ubicacion">Ubicacion</asp:ListItem>
                        <asp:ListItem Value="reclamos_varios.hora as Hora">Hora</asp:ListItem>
                        <asp:ListItem Value="Convert(varchar(10),reclamos_varios.fecha, 103) as [Fecha Siniestro]">Fecha Siniestro</asp:ListItem>
                        <asp:ListItem Value="reclamos_varios.hora_commit as [Hora Commit]">Hora Creacion</asp:ListItem>
                        <asp:ListItem Value="Convert(varchar(10),reclamos_varios.fecha_commit, 103) as [Fecha Creacion]">Fecha Creacion</asp:ListItem>
                        <asp:ListItem Value="Convert(varchar(10),reclamos_varios.fecha_apertura_reclamo, 103) as [Fecha Apertura]">Fecha Apertura</asp:ListItem>
                        <asp:ListItem Value="Convert(varchar(10),reclamos_varios.fecha_cierre_reclamo, 103) as [Fecha Cierre]">Fecha Cierre</asp:ListItem>
                        <asp:ListItem Value="gestores.nombre As Gestor">Gestor</asp:ListItem>
                        <asp:ListItem Value="talleres.nombre as Taller">Taller</asp:ListItem>
                        <asp:ListItem Value="analistas.nombre as Analista">Analista</asp:ListItem>
                        <asp:ListItem Value="contactos_reclamos_varios.nombre as [Nombre Contactos]">Contacto</asp:ListItem>
                        <asp:ListItem Value="contactos_reclamos_varios.telefono as [Telefono Contacto]">Telefono Contacto</asp:ListItem>
                        <asp:ListItem Value="reclamos_varios.observaciones as Observaciones">Observaciones</asp:ListItem>
                        <asp:ListItem Value="reclamos_varios.prioritario as Prioritario">Prioritario</asp:ListItem>
                        <asp:ListItem Value="reclamos_varios.complicado as Complicado">Complicado</asp:ListItem>
                        <asp:ListItem Value="reclamos_varios.compromiso_pago as Compromiso">Compromiso </asp:ListItem>
                        <asp:ListItem Value="reclamos_varios.num_reclamo as [No. Reclamo]">Num. Reclamo</asp:ListItem>
                        <asp:ListItem Value="cabina.nombre as Cabina">Cabina</asp:ListItem>
                        <asp:ListItem Value="sucursal.nombre as Sucursal">Sucursal</asp:ListItem>
                        <asp:ListItem Value="empresa.nombre as Empresa">Empresa</asp:ListItem>
                        <asp:ListItem Value="pais.nombre as Pais">Pais</asp:ListItem>
                        <asp:ListItem Value="usuario.nombre as Usuario">Usuario</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
        <div class="col-sm-10">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <b>Tabla con campos seleccionados
                        <spam style="margin-left: 50px">Total de registros: </spam>
                        <asp:Label ID="lblConteo" runat="server"></asp:Label></b>
                    <asp:CheckBox ID="checkSinFiltro" Style="padding-left: 30px;" Checked="true" AutoPostBack="true" runat="server" Text="Sin Ningun Filtro" OnCheckedChanged="checkSinFiltro_CheckedChanged" />
                    <asp:DropDownList ID="ddlCiclos" runat="server" Style="width: 10%; height: 25px;">
                        <asp:ListItem Value="Ciclo Total">Ciclo Total</asp:ListItem>
                        <asp:ListItem Value="Ciclo Unity">Ciclo Unity</asp:ListItem>
                        <asp:ListItem Value="Ciclo Cliente">Ciclo Cliente</asp:ListItem>
                        <asp:ListItem Value="Ciclo Aseguradora">Ciclo Aseguradora</asp:ListItem>
                    </asp:DropDownList>
                    <label>Monto Reserva:</label>
                    <asp:TextBox runat="server" ID="txtMonto" Text="0.00"></asp:TextBox>
                    <asp:Button ID="Mostrar" Style="margin-left: 20px" runat="server" Text="Mostrar" OnClick="Mostrar_Click" />
                    <asp:Button ID="btnMostrarEficiencia" Style="margin-left: 20px" runat="server" Text="Eficiencia" OnClick="btnMostrarEficiencia_Click" />
                </div>
                <div class="panel-body" style="height: auto;">
                    <div class="row">
                        <div class="form-group col-sm-12 col-md-6 col-lg-3">
                            <label>Seleccionar Busqueda:</label>
                            <asp:DropDownList ID="ddlElegir" runat="server" Style="width: 100%" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlElegir_SelectedIndexChanged">
                                <asp:ListItem Value="reg_reclamo_varios.poliza">Poliza</asp:ListItem>
                                <asp:ListItem Value="reclamos_varios.estado_reclamo_unity">Estado Reclamo</asp:ListItem>
                                <asp:ListItem Value="gestores.nombre">Gestor</asp:ListItem>
                                <asp:ListItem Value="reg_reclamo_varios.aseguradora ">Aseguradora</asp:ListItem>
                                <asp:ListItem Value="reg_reclamo_varios.asegurado">Asegurado</asp:ListItem>
                                <asp:ListItem Value="reg_reclamo_varios.moneda">Moneda</asp:ListItem>
                                <asp:ListItem Value="reclamos_varios">Ajustador</asp:ListItem>
                                <asp:ListItem Value="reg_reclamo_varios.ejecutivo">Ejecutivo</asp:ListItem>
                                <asp:ListItem Value="reg_reclamo_varios.cliente">Cliente</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-sm-12 col-md-6 col-lg-3">
                            <label>Registros a buscar:</label>
                            <asp:TextBox ID="txtBuscar" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                            <asp:DropDownList ID="ddlBuscar" Visible="false" runat="server" Style="width: 100%" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-sm-12 col-md-6 col-lg-2">
                            <label>Estado:</label>
                            <asp:DropDownList ID="ddlEstado" runat="server" Style="width: 100%" CssClass="form-control">
                                <asp:ListItem Value="Cerrado">Cerrado</asp:ListItem>
                                <asp:ListItem Value="Seguimiento">Seguimiento</asp:ListItem>
                                <asp:ListItem Value="Todos">Todos</asp:ListItem>
                                <asp:ListItem Value="reclamos_varios.estado_unity= 'Seguimiento'">Pendientes</asp:ListItem>
                                <asp:ListItem>Estado</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-sm-12 col-md-6 col-lg-2">
                            <label>Fecha Inicio:</label>
                            <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-6 col-lg-2">
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
                        <asp:Panel runat="server" ID="PanelCamposSeleccion">
                            <div class="scrolling-table-container">
                                <asp:GridView ID="GridCamposSeleccion" runat="server" CssClass="table table-responsive" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="PanelEficiencia">
                            <div class="scrolling-table-container">
                                <asp:GridView ID="GridEficiencia" runat="server" CssClass="table bs-table table-responsive" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None" OnRowDataBound="GridEficiencia_RowDataBound" ShowFooter="true">
                                    <AlternatingRowStyle BackColor="White" />
                                    <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Right" Wrap="False" />
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="PnCiclos">
                            <div style="height: 520px;">
                                <div class="scrolling-table-container" style="overflow-y: auto;">
                                    <div id="ciclos" class="col-sm-12 col-md-12 col-lg-12">
                                        <asp:GridView ID="GridCiclos" runat="server" CssClass="table bs-table table-responsive" OnRowDataBound="GridCiclos_RowDataBound" AutoGenerateColumns="True" ShowFooter="true" ForeColor="#333333" GridLines="None">
                                            <AlternatingRowStyle BackColor="White" />
                                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                                        </asp:GridView>
                                    </div>
                                    <div id="ciclos2" class="col-sm-12 col-md-6 col-lg-6">
                                        <asp:GridView ID="GridCiclos2" runat="server" CssClass="table bs-table table-responsive" OnRowDataBound="GridCiclos2_RowDataBound" AutoGenerateColumns="True" ShowFooter="true" ForeColor="#333333" GridLines="None">
                                            <AlternatingRowStyle BackColor="White" />
                                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </asp:Panel>
                </div>
            </div>
        </div>
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
                <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png" />
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
                        $td = $tr[0].cells[8];
                    $td.innerText = $td.innerText + ' %';
                    $td.className = 'alinearNumeros';
                }
            });
        } catch (ex) {
        }
    </script>
    <script>
        if ($('#ContentPlaceHolder1_ddlCiclos option:selected').text() == 'Ciclo Unity') {

            $('#ciclos2').show();
            $("#ciclos").removeClass("col-lg-12");
            $("#ciclos").addClass("col-lg-6");
        }
        else {
            $("#ciclos").addClass("col-lg-12");
            $('#ciclos2').hide();
        }
    </script>
</asp:Content>


