﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbFrmReportesAutorizaciones.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmReportesAutorizaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="container-fluid">
        <div class="col-sm-2">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><b style="font-size: 16px;">Seleccione los campos</b></h3>
                </div>
                <div class="panel-body scrolling-table-container" style="height: 525px; max-height: 600px;">
                   <asp:CheckBox ID="CheckTodos" Text="Seleccionar Todos" AutoPostBack="true" runat="server" OnCheckedChanged="CheckTodos_CheckedChanged" />
                    <asp:CheckBoxList ID="checkCampos" runat="server" Height="141px" Width="147px">
                        <asp:ListItem Value="aut.reportante as Reportante">Reportante</asp:ListItem>
                        <asp:ListItem Value="aut.tipo_consulta as [Tipo Consulta]">Tipo Consulta</asp:ListItem>
                        <asp:ListItem Value="aut.tipo_estado as [Tipo Estado]">Tipo Estado</asp:ListItem>
                        <asp:ListItem Value="aut.correo as Correo">Correo</asp:ListItem>
                        <asp:ListItem Value="aut.telefono as Telefono">Telefono</asp:ListItem>
                        <asp:ListItem Value="aut.fecha_completa_commit as [Fecha Creacion]">Fecha Creacion</asp:ListItem>
                        <asp:ListItem Value="aut.fecha_completa_cierre as [Fecha Cierre]">Fecha Cierre</asp:ListItem>
                        <asp:ListItem Value="aut.total_tiempo as [Total Tiempo]">Total Tiempo</asp:ListItem>
                        <asp:ListItem Value="reg.asegurado as Asegurado">Asegurado</asp:ListItem>
                        <asp:ListItem Value="reg.poliza as Poliza">Poliza</asp:ListItem>
                        <asp:ListItem Value="reg.tipo as Tipo">Tipo</asp:ListItem>
                        <asp:ListItem Value="reg.clase as Clase">Clase</asp:ListItem>
                        <asp:ListItem Value="reg.ejecutivo as Ejecutivo">Ejecutivo</asp:ListItem>
                        <asp:ListItem Value="reg.aseguradora as Aseguradora">Aseguradora</asp:ListItem>
                        <asp:ListItem Value="reg.contratante as Contratante">Contratante</asp:ListItem>
                        <asp:ListItem Value="reg.vip as VIP">VIP</asp:ListItem>
                        <asp:ListItem Value="reg.moneda as Moneda">Moneda</asp:ListItem>
                        <asp:ListItem Value="reg.cliente as Cliente">Cliente</asp:ListItem>
                        <asp:ListItem Value="reg.telefono_acs">Telefono ACS</asp:ListItem>
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
                        <asp:GridView ID="GridCamposSeleccion" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" AllowCustomPaging="True" AllowPaging="True" PageSize="3000">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                            </Columns>
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerSettings PageButtonCount="30" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        </asp:GridView>
                    </div>
                    <br />
                    <asp:CheckBox ID="checkSinFiltro" runat="server" Text="Sin Ningun Filtro" AutoPostBack="true" OnCheckedChanged="checkSinFiltro_CheckedChanged" />
                    <asp:Button ID="btnMostrarEficiencia" OnClientClick="return false;" data-toggle="modal" data-target="#ModalDetalle" style="margin-left:20px" runat="server" Text="Eficiencia" />
                    <br />
                    <div class="form-inline">
                        <div class="form-group" style="width: 20%">
                            <label for="message-text" class="control-label">Seleccionar Busqueda:</label>
                            <asp:DropDownList ID="ddlElegir" runat="server" Style="width: 100%" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlElegir_SelectedIndexChanged" >
                                <asp:ListItem Value="aut.reportante">Reportante</asp:ListItem>
                                <asp:ListItem Value="reg.asegurado">Asegurado</asp:ListItem>
                                <asp:ListItem Value="reg.poliza">Poliza</asp:ListItem>
                                <asp:ListItem Value="reg.aseguradora">Aseguradora</asp:ListItem>
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
                                <asp:ListItem Value=" in ('Cerrado','Aseguradora', 'Asegurado', 'Revision', 'Enviado')">Todas</asp:ListItem>
                                <asp:ListItem Value=" = 'Cerrado'">Cerradas</asp:ListItem>
                                <asp:ListItem Value=" = 'Aseguradora'">Aseguradora</asp:ListItem>
                                <asp:ListItem Value=" = 'Asegurado'">Asegurado</asp:ListItem>
                                <asp:ListItem Value=" = 'Revision'">Revision</asp:ListItem>
                                <asp:ListItem Value=" = 'Enviado'">Enviado</asp:ListItem>
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
                        <h4 class="modal-title" id="ModalComentario1"><b>Detalle del reporte autorizaciones</b></h4>
                    </div>
                    <div class="modal-body">
                        <div class="scrolling-table-container" style="overflow-y: auto;">
                            <asp:GridView ID="GridEficiencia" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None" AllowCustomPaging="True" AllowPaging="True" PageSize="3000" ShowFooter="true" OnRowDataBound="GridPromedioAseguradora_RowDataBound">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                </Columns>
                                <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <PagerSettings PageButtonCount="30" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btnExportarEficiencia" runat="server" Text="Descargar" OnClick="btnExportarEficiencia_Click" CssClass="btn btn-success"  />
                    </div>
                </div>
            </div>
        </div>

        <%-- botones circulares con las opciones multiples --%>
        <div id="container-floating">
            <div class="nd4 nds" data-toggle="tooltip" data-placement="left" data-original-title="Simone">
                <asp:LinkButton ID="linkSalir" OnClick="linkSalir_Click" CssClass="letter" ToolTip="salir"  runat="server"><i class="fa fa-times" aria-hidden="true"></i></asp:LinkButton>
            </div>
            <div class="nd3 nds" data-toggle="tooltip" data-placement="left" data-original-title="contract@gmail.com">
                <asp:LinkButton ID="btnExportar" OnClick="btnExportar_Click" CssClass="letter" ToolTip="Exportar a excel" runat="server"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
            </div>
            <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
                <asp:LinkButton ID="btnGenerarTabla" OnClick="btnGenerarTabla_Click" CssClass="letter" ToolTip="Generar Reporte" autopostback="true" runat="server"><i class="fa fa-table" aria-hidden="true"></i></asp:LinkButton>
            </div>
            <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
                <p class="plus">+</p>
                <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentJs" Runat="Server">
</asp:Content>
