<%@ Page Title="" Language="C#" MasterPageFile="~/Consultas/Tigo/tigo.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ReportesAutos.aspx.cs" Inherits="Consultas_Tigo_ReportesAutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-sm-2" style="padding-left:0px;">
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
    <div class="col-sm-10">
        <div class="panel panel-info">
            <div class="panel-heading">
                <b>Tabla con campos seleccionados<spam style="margin-left: 50px">Total de registros:</spam><asp:Label ID="lblConteo" runat="server"></asp:Label></b>
                <asp:CheckBox ID="checkSinFiltro" Checked="true" AutoPostBack="true" runat="server" Text="Sin Ningun Filtro" OnCheckedChanged="checkSinFiltro_CheckedChanged" Style="padding-left: 20px; display:none;" />
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="form-group  col-sm-12 col-md-6 col-lg-2">
                        <label>Estado:</label>
                        <asp:DropDownList ID="ddlEstado" runat="server" Style="width: 100%" CssClass="form-control">
                            <asp:ListItem Value="Cerrado">Cerrado</asp:ListItem>
                            <asp:ListItem Value="Seguimiento">Seguimiento</asp:ListItem>
                            <asp:ListItem Value="Nuevos">Nuevos</asp:ListItem>
                            <asp:ListItem Value="Pendientes">Pendientes</asp:ListItem>
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
                    <asp:Panel runat="server" ID="PanelCamposSeleccion" Visible="false">
                        <div class="scrolling-table-container" style="overflow-y: auto;">
                            <asp:GridView ID="GridCamposSeleccion" runat="server" CssClass="table bs-table table-responsive" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None" PageSize="3000">
                                <AlternatingRowStyle BackColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            </asp:GridView>
                        </div>
                    </asp:Panel>
                </asp:Panel>
            </div>
        </div>
    </div>
    <%-- botones circulares con las opciones multiples --%>
    <div id="container-floating">
        <div class="nd4 nds" data-toggle="tooltip" data-placement="left" data-original-title="Simone">
            <asp:LinkButton ID="linkSalir" ToolTip="Regresar a inicio" CssClass="letter" OnClick="linkSalir_Click" runat="server"><i class="fa fa-times" ></i></asp:LinkButton>
        </div>
        <div class="nd3 nds" data-toggle="tooltip" data-placement="left" data-original-title="contract@gmail.com">
            <asp:LinkButton ID="btnExportar" ToolTip="Exportar a excel" OnClick="btnExportar_Click" CssClass="letter" runat="server"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
        </div>
        <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
            <asp:LinkButton ID="btnGenerarTabla" ToolTip="Generar Reporte" OnClick="btnGenerarTabla_Click" CssClass="letter" autopostback="true" runat="server"><i class="fa fa-table"></i></asp:LinkButton>
        </div>
        <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
            <p class="plus">+</p>
            <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="Server">
    <style>
        body {
            /* el tamaño por defecto es 14px */
            font-size: 12px;
        }
    </style>
</asp:Content>

