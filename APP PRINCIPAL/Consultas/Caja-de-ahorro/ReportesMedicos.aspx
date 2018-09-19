<%@ Page Title="" Language="C#" MasterPageFile="~/Consultas/Caja-de-ahorro/CajaAhorro.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ReportesMedicos.aspx.cs" Inherits="Consultas_Caja_de_ahorro_ReportesMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-sm-12 col-md-2 col-lg-2" style="padding-left:0px;">
        <div class="panel panel-info">
            <div class="panel-heading">
                <h3 class="panel-title"><b style="font-size: 16px;">Seleccione los campos</b></h3>
            </div>
            <div class="panel-body" style="height: 525px; max-height: 600px; overflow-x: auto; overflow-y: auto;">
                <asp:CheckBox ID="CheckTodos" Text="Seleccionar Todos" AutoPostBack="true" runat="server" OnCheckedChanged="CheckTodos_CheckedChanged" />
                <asp:CheckBoxList ID="checkCampos" runat="server" Height="141px" Width="147px">
                    <asp:ListItem Value="reg_reclamos_medicos.asegurado as Asegurado">Asegurado</asp:ListItem>
                    <asp:ListItem Value="reg_reclamos_medicos.poliza as Poliza">Poliza</asp:ListItem>
                    <asp:ListItem Value="reg_reclamos_medicos.aseguradora as Aseguradora">Aseguradora</asp:ListItem>
                    <asp:ListItem Value="reg_reclamos_medicos.cliente as Cliente">No. Cliente</asp:ListItem>
                    <asp:ListItem Value="reg_reclamos_medicos.telefono_acs as [Telefono ACS]">Telefono acs</asp:ListItem>
                    <asp:ListItem Value="reclamos_medicos.estado_unity as [Estado Reclamo]">Estado Reclamo</asp:ListItem>
                    <asp:ListItem Value="reclamos_medicos.usuario_unity as Usuario">Usuario</asp:ListItem>
                    <asp:ListItem Value="reclamos_medicos.telefono as Telefono">Telefono</asp:ListItem>
                    <asp:ListItem Value="reclamos_medicos.correo as Correo">Correo</asp:ListItem>
                    <asp:ListItem Value="reclamos_medicos.empresa as Empresa">Empresa</asp:ListItem>
                    <asp:ListItem Value="reclamos_medicos.tipo_reclamo as [Tipo Reclamo]">Tipo Reclamo</asp:ListItem>
                    <asp:ListItem Value="reg_reclamos_medicos.ramo as Ramo">Ramo</asp:ListItem>
                    <asp:ListItem Value="reg_reclamos_medicos.tipo as Tipo">Tipo</asp:ListItem>
                    <asp:ListItem Value="reg_reclamos_medicos.clase as Clase">Clase</asp:ListItem>
                    <asp:ListItem Value="reg_reclamos_medicos.ejecutivo as Ejecutivo">Ejecutivo</asp:ListItem>
                    <asp:ListItem Value="reg_reclamos_medicos.estado_poliza as [Estado Poliza]">Estado Poliza</asp:ListItem>
                    <asp:ListItem Value="reg_reclamos_medicos.vip as VIP">VIP</asp:ListItem>
                    <asp:ListItem Value="reg_reclamos_medicos.moneda as Moneda">Moneda</asp:ListItem>
                    <asp:ListItem Value="reclamos_medicos.fecha_commit as [Fecha Creacion]">Fecha Creacion</asp:ListItem>
                    <asp:ListItem Value="reclamos_medicos.fecha_revision as [Fecha Revision]">Fecha Revision</asp:ListItem>
                    <asp:ListItem Value="reclamos_medicos.fecha_envio_aseg as [Fecha Envio Aseguradora]">Fecha Envio Aseg.</asp:ListItem>
                    <asp:ListItem Value="reclamos_medicos.fecha_modificacion as [Fecha Modificacion]">Fecha Modificacion</asp:ListItem>
                    <asp:ListItem Value="reclamos_medicos.fecha_envio_cheque as [Fecha Envio Cheque]">Fecha Env. Cheque</asp:ListItem>
                    <asp:ListItem Value="reclamos_medicos.fecha_cierre as [Fecha Cierre]">Fecha Cierre</asp:ListItem>
                    <asp:ListItem Value="reclamos_medicos.titular as Titular">Titular</asp:ListItem>
                    <asp:ListItem Value="reclamos_medicos.detalle_cliente">Detalle Cliente</asp:ListItem>
                    <asp:ListItem Value="reclamos_medicos.observacion as Observacion">Observacion</asp:ListItem>
                    <asp:ListItem Value="reg_reclamos_medicos.certificado as Certificado">Certificado</asp:ListItem>
                    <asp:ListItem Value="reclamos_medicos.num_reclamo as [Numero Reclamo]">Numero Reclamo</asp:ListItem>
                    <asp:ListItem Value="CONCAT(DATEDIFF(MINUTE, reclamos_medicos.fecha_completa_commit,reclamos_medicos.fecha_asignacion)/60 ,':',
                                                    DATEDIFF(MINUTE, reclamos_medicos.fecha_completa_commit,reclamos_medicos.fecha_asignacion)%60 ,':',
                                                    DATEDIFF(SECOND, reclamos_medicos.fecha_completa_commit,reclamos_medicos.fecha_asignacion)%60 ) as [Fecha creacion A Fecha Asignacion] ">Fecha Apertura a fecha asignacion</asp:ListItem>
                    <asp:ListItem Value="CONCAT(DATEDIFF(MINUTE, reclamos_medicos.fecha_asignacion,reclamos_medicos.fecha_apertura)/60, ':',
                                                    DATEDIFF(MINUTE, reclamos_medicos.fecha_asignacion,reclamos_medicos.fecha_apertura)%60, ':',
	                                                DATEDIFF(SECOND, reclamos_medicos.fecha_asignacion,reclamos_medicos.fecha_apertura)%60 ) as [Fecha Asignacion A Fecha Apertura] ">Fecha Asignacion a Fecha Apertura</asp:ListItem>
                    <asp:ListItem Value="CONCAT(DATEDIFF(MINUTE, reclamos_medicos.fecha_apertura, reclamos_medicos.fecha_envio_aseg)/60, ':',
	                                                DATEDIFF(MINUTE, reclamos_medicos.fecha_apertura, reclamos_medicos.fecha_envio_aseg)%60, ':',
	                                                DATEDIFF(SECOND, reclamos_medicos.fecha_apertura, reclamos_medicos.fecha_envio_aseg)%60 ) as [Fecha Apertura A Fecha Envio Aseguradora] ">Fecha Apertura A fecha env. Aseguradora</asp:ListItem>
                    <asp:ListItem Value="CONCAT(DATEDIFF(MINUTE, reclamos_medicos.fecha_envio_aseg,reclamos_medicos.fecha_recepcion_cheque)/60, ':',
	                                                DATEDIFF(MINUTE, reclamos_medicos.fecha_envio_aseg,reclamos_medicos.fecha_recepcion_cheque)%60, ':',
	                                                DATEDIFF(SECOND, reclamos_medicos.fecha_envio_aseg,reclamos_medicos.fecha_recepcion_cheque)%60 ) as [Fecha Aseguradora a Fecha Recepcion] ">Fecha Aseguradora a Fecha Recepcion</asp:ListItem>
                    <asp:ListItem Value="CONCAT(DATEDIFF(MINUTE, reclamos_medicos.fecha_completa_commit, reclamos_medicos.fecha_cierre)/60, ':',
	                                                DATEDIFF(MINUTE, reclamos_medicos.fecha_completa_commit, reclamos_medicos.fecha_cierre)%60, ':',
	                                                DATEDIFF(SECOND, reclamos_medicos.fecha_completa_commit, reclamos_medicos.fecha_cierre)%60 ) as [Fecha Creacion a cierre] ">Fecha creacion a cierre</asp:ListItem>
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
                    <asp:CheckBox ID="checkSinFiltro" Style="margin-left: 50px;display:none" runat="server"/>
                </div>
                <div class="panel-body" style="height: 520px;">
                    <div class="row">
                        <div class="form-group col-md-2 col-lg-2">
                            <label>Estado:</label>
                            <asp:DropDownList ID="ddlEstado" runat="server" Style="width: 100%" CssClass="form-control">
                                <asp:ListItem Value="reclamos_medicos.estado_unity = 'Cerrado'">Cerrado</asp:ListItem>
                                <asp:ListItem Value="reclamos_medicos.estado_unity = 'Seguimiento'">Seguimiento</asp:ListItem>
                                <asp:ListItem>Pendientes</asp:ListItem>
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
    <%-- botones circulares con las opciones multiples --%>
    <div id="container-floating">
        <div class="nd4 nds" data-toggle="tooltip" data-placement="left" data-original-title="Simone">
            <asp:LinkButton ID="linkSalir" ToolTip="Regresar a inicio" CssClass="letter" OnClick="linkSalir_Click" runat="server"><i class="fa fa-times" aria-hidden="true"></i></asp:LinkButton>
        </div>
        <div class="nd3 nds" data-toggle="tooltip" data-placement="left" data-original-title="contract@gmail.com">
            <asp:LinkButton ID="btnExportar" ToolTip="Exportar a excel" OnClick="btnExportar_Click" CssClass="letter" runat="server"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
        </div>
        <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
            <asp:LinkButton ID="btnGenerarTabla" ToolTip="Generar Reporte" OnClick="btnGenerarTabla_Click" CssClass="letter" autopostback="true" runat="server"><i class="fa fa-table" aria-hidden="true"></i></asp:LinkButton>
        </div>
        <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
            <p class="plus">+</p>
            <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="Server">
</asp:Content>

