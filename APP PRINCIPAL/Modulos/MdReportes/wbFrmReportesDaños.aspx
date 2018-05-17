<%@ Page Title="Reportes Daños" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="wbFrmReportesDaños.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmReportesDaños" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="col-sm-2">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><b style="font-size: 16px;">Seleccione los campos</b></h3>
                </div>
                <div class="panel-body scrolling-table-container" style="height: 525px; max-height: 600px;">
                    <asp:CheckBox Text="Todos" runat="server" id="checkTodos" AutoPostBack="true" OnCheckedChanged="checkTodos_CheckedChanged"/>
                    <asp:CheckBoxList ID="checkCampos" runat="server" Height="141px" Width="147px">
                        <asp:ListItem Value="reclamos_varios.estado_unity as [Estado Reclamo]">Estado Reclamo</asp:ListItem>
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
                        <asp:ListItem Value="reclamos_varios.estado_reclamo_unity as [Estado Reclamo Unity]">Estado Reclamo Unity</asp:ListItem>
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
                    <h3 class="panel-title"><b style="font-size: 16px;">Tabla con campos seleccionados <spam style="margin-left:100px">Total de registros: </spam><asp:Label ID="lblConteo" runat="server" Style="font-size: 20px;"></asp:Label></b></h3>
                </div>
                <div class="panel-body" style="height: 520px;">
                    <div class="scrolling-table-container" style="overflow-y: auto;">
                        <asp:GridView ID="GridCamposSeleccion" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                            </Columns>
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        </asp:GridView>
                    </div>
                    <br />
                    <asp:CheckBox ID="checkSinFiltro" AutoPostBack="true" runat="server" Text="Sin Ningun Filtro" OnCheckedChanged="checkSinFiltro_CheckedChanged" />
                    <asp:Button ID="btnMostrarEficiencia" OnClientClick="return false;" data-toggle="modal" data-target="#ModalDetalle" style="margin-left:20px" runat="server" Text="Eficiencia" />
                    <br />
                    <div class="form-inline">
                        <div class="form-group" style="width: 20%">
                            <label for="message-text" class="control-label">Seleccionar Busqueda:</label>
                            <asp:DropDownList ID="ddlElegir" runat="server" Style="width: 100%" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlElegir_SelectedIndexChanged">
                                <asp:ListItem Value="reg_reclamo_varios.poliza">Poliza</asp:ListItem>
                                <asp:ListItem Value="gestores.nombre">Gestor</asp:ListItem>
                                <asp:ListItem Value="reg_reclamo_varios.aseguradora ">Aseguradora</asp:ListItem>
                                <asp:ListItem Value="reg_reclamo_varios.asegurado">Asegurado</asp:ListItem>
                                <asp:ListItem Value="reg_reclamo_varios.moneda">Moneda</asp:ListItem>
                                <asp:ListItem Value="reclamos_varios">Ajustador</asp:ListItem>
                                <asp:ListItem Value="reg_reclamo_varios.ejecutivo">Ejecutivo</asp:ListItem>
                                <asp:ListItem Value="reg_reclamo_varios.cliente">Cliente</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group" style="width: 25%">
                            <label for="message-text" class="control-label">Registros a buscar:</label>
                            <asp:TextBox ID="txtBuscar" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                            <asp:DropDownList ID="ddlBuscar" Visible="false" runat="server" Style="width: 100%" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group" style="width: 20%">
                            <label for="message-text" class="control-label">Estado:</label>
                            <asp:DropDownList ID="ddlEstado" runat="server" Style="width: 100%" CssClass="form-control">
                                <asp:ListItem Value="Cerrado">Cerrado</asp:ListItem>
                                <asp:ListItem Value="Seguimiento">Seguimiento</asp:ListItem>
                                <asp:ListItem Value="Todos">Todos</asp:ListItem>
                                <asp:ListItem Value="reclamos_varios.estado_unity= 'Seguimiento'">Pendientes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group" style="width: 15%">
                            <label for="message-text" class="control-label">Fecha Inicio:</label>
                            <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group" style="width: 15%">
                            <label for="message-text" class="control-label">Fecha Fin:</label>
                            <asp:TextBox ID="txtFechaFin" type="date" Height="34px" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        
        <%-- ------------------------ modal ver el detalle de eficiencia ------------------------------------------%>
        <div class="modal fade" id="ModalDetalle" tabindex="-1" role="dialog" aria-labelledby="ModalDetalle2" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="ModalComentario1"><b>Detalle del reporte seleccionado</b></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
<%--                            <table style="width: 100%" class="table table-responsive table-hover" runat="server" id="tbl">
                                <tr>
                                    <th>Gestor</th>
                                    <th>Pendientes</th>
                                    <th>Nuevos</th>
                                    <th>Cerrados</th>
                                    <th>Eficiencia</th>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="lblGestor" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="lblPendientes" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="lblNuevos" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="lblCerrados" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="lblEficiencia" runat="server"></asp:Label></td>
                                </tr>
                            </table>--%>
                            <asp:GridView ID="GridEficiencia" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="GridEficiencia_RowDataBound" ShowFooter="true">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                </Columns>
                                <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btnExportarEficiencia" runat="server" Text="Descargar" CssClass="btn btn-success" OnClick="btnExportarEficiencia_Click" />
                    </div>
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
                <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
            </div>
        </div>
    </div>
</asp:Content>

