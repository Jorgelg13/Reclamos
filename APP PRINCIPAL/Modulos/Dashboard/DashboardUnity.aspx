<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="DashboardUnity.aspx.cs" Inherits="DashboardUnity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container menu-cuadrado btn-acciones-laterales">
        <div class="col-md-4 col-lg-4" style="height: 220px;">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b>Seguimiento De Reclamos Autos</b></p>
                </div>
                <div class="panel-body">
                    <h1>
                        <a href="/Modulos/MdReclamosUnity/wbFrmReclamosGeneralAutos.aspx?id=5" title="Total de reclamos de autos en seguimiento" style="font-size: 80px;" class="fa fa-car"></a>
                        <br />
                        <p style="text-align: center">
                            <asp:Label ID="totalReclamosAutos" runat="server" aria-hidden="true" ForeColor="#797D7F"></asp:Label>
                        </p>
                    </h1>
                </div>
            </div>
        </div>
        <div class="col-md-4 col-lg-4" style="height: 220px;">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b>Seguimiento De Reclamos Daños</b></p>
                </div>
                <div class="panel-body">
                    <h1>
                        <a href="/Modulos/MdReclamosUnity/wbFrmReclamosDañosGeneral.aspx?id=6" title="Total de reclamos de daños en seguimiento" style="font-size: 80px;" class="fa fa-exclamation-triangle"></a>
                        <br />
                        <p style="text-align: center">
                            <asp:Label ID="totalReclamosDaños" runat="server" aria-hidden="true" ForeColor="#797D7F"></asp:Label>
                        </p>
                    </h1>
                </div>
            </div>
        </div>
        <div class="col-md-4 col-lg-4" style="height: 220px;">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b>Seguimiento De Reclamos Medicos</b></p>
                </div>
                <div class="panel-body">
                    <h1>
                        <a href="/Modulos/MdReclamosUnity/wbFrmReclamosMedicosGeneral.aspx?id=1" title="Total de reclamos de gastos medicos en seguimiento" style="font-size: 80px;" class="fa fa-heartbeat"></a>
                        <br />
                        <p>
                        <asp:LinkButton ID="lnTotal" runat="server" ToolTip="Reclamos de gastos medicos en total" ForeColor="#797D7F"></asp:LinkButton>
                        <%--<asp:LinkButton ID="lnTotalFueraTiempo" runat="server" Style="color: red" ToolTip="Reclamos de gastos medicos en total fuera de tiempo"></asp:LinkButton>--%>
                        </p>
                    </h1>
                </div>
            </div>
        </div>
        <%-- detalle de eficiencia por estados de reclamos --%>
        <div class="col-md-4 col-lg-4" style="height: 220px;">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b>Reclamos por estados de autos</b></p>
                </div>
                <div class="panel-body" style="text-align:center; padding:10px;">
                    <h3>
                        <asp:LinkButton ID="lnPendienteAseguradoAuto" OnClick="lnPendienteAseguradoAuto_Click" ToolTip="Reclamos en estado pendiente asegurado" runat="server" ForeColor="#797D7F"></asp:LinkButton>
                    </h3>
                    <h3>
                        <asp:LinkButton ID="lnlProcesoLegalAutos" OnClick="lnlProcesoLegalAutos_Click" ToolTip="Reclamos en estado proceso legal" runat="server" ForeColor="#797D7F"></asp:LinkButton>
                     </h3>
                    <h3>
                        <asp:LinkButton ID="lnlEsperaAfectado" OnClick="lnlEsperaAfectado_Click" ToolTip="Reclamos en estado espera afectado" runat="server" ForeColor="#797D7F"></asp:LinkButton>
                     </h3>
                    <h3>
                        <asp:LinkButton ID="lnlPendienteCompania" OnClick="lnlPendienteCompania_Click" ToolTip="Reclamos en estado reparacion" runat="server" ForeColor="#797D7F"></asp:LinkButton>
                    </h3>
                </div>
            </div>
        </div>
        <div class="col-md-4 col-lg-4" style="height: 220px;">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b>Reclamos por estados de daños</b></p>
                </div>
                <div class="panel-body" style="text-align:center; padding:10px;">
                    <h3>
                        <asp:LinkButton ID="lnPendienteAsegurado" OnClick="lnPendienteAsegurado_Click" ToolTip="Reclamos en estado pendiente asegurado" runat="server" ForeColor="#797D7F"></asp:LinkButton>
                    </h3>
                    <h3>
                        <asp:LinkButton ID="lnInactivo" OnClick="lnInactivo_Click" ToolTip ="Reclamos en estado inactivo" runat="server" ForeColor="#797D7F"></asp:LinkButton>
                    </h3>
                    <h3>
                        <asp:LinkButton ID="lnAjuste" OnClick="lnAjuste_Click" ToolTip="Reclamos en estado ajuste" runat="server" ForeColor="#797D7F"></asp:LinkButton>
                   </h3>
                    <h3>
                        <asp:LinkButton ID="lnFiniquito" OnClick="lnFiniquito_Click" ToolTip="Reclamos en estado pendiente finiquito" runat="server" ForeColor="#797D7F"></asp:LinkButton>
                    </h3>
                </div>
            </div>
        </div>
        <div class="col-md-4 col-lg-4" style="height: 220px;">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b>Reclamos Individuales y colectivos</b></p>
                </div>
                <div class="panel-body" style="text-align:center; padding:10px;">
                    <h3>
                        I: <asp:LinkButton ID="lnIndividualesFueraTiempo" OnClick="lnIndividualesFueraTiempo_Click" runat="server" Style="color: red" ToolTip="Reclamos individuales fuera de tiempo"></asp:LinkButton>/
                        <asp:LinkButton ID="lnTotalIndividuales" OnClick="lnTotalIndividuales_Click" ToolTip="Reclamos Individuales en total" runat="server" ForeColor="#797D7F"></asp:LinkButton>
                        <asp:Label ID="lbIndividualesFT" runat="server"></asp:Label>
                    </h3>
                    <h3>
                        C: <asp:LinkButton ID="lnColectivosFueraTiempo" OnClick="lnColectivosFueraTiempo_Click" runat="server" Style="color: red" ToolTip="Reclamos de colectivos fuera de tiempo"></asp:LinkButton>/
                        <asp:LinkButton ID="lnColectivos" OnClick="lnColectivos_Click" runat="server" ToolTip="Reclamos de colectivos en total" ForeColor="#797D7F"></asp:LinkButton>
                        <asp:Label ID="lbColectivosFT" runat="server"></asp:Label>
                    </h3>
                    <h3>
                        T: <asp:LinkButton ID="LnTotalFtGastosMedios" runat="server" Style="color: red" ToolTip="Reclamos de gastos medicos en total fuera de tiempo"></asp:LinkButton>/
                        <asp:LinkButton ID="lnTotalGastosMedicos"  runat="server" ToolTip="Reclamos de gastos medicos en total" ForeColor="#797D7F"></asp:LinkButton>
                        <asp:Label ID="lbltotalFt" runat="server"></asp:Label>
                    </h3>
                    <h3>
                        <asp:LinkButton ID="lnPendienteDocumentacion" OnClick="lnPendienteDocumentacion_Click" runat="server" ToolTip="Reclamos de gastos medicos en total" ForeColor="#797D7F"></asp:LinkButton>
                        <asp:LinkButton ID="lnPendienteDocumentacionFueraTiempo" runat="server" Style="color: red" ToolTip="Reclamos de gastos medicos en total fuera de tiempo"></asp:LinkButton>
                    </h3>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

