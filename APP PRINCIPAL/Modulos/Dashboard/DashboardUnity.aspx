<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="DashboardUnity.aspx.cs" Inherits="DashboardUnity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container menu-cuadrado btn-acciones-laterales">
        <div class="col-md-4 col-lg-4" style="height: 300px;">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b>Seguimiento De Reclamos Autos</b></p>
                </div>
                <div class="panel-body">
                    <h1>
                        <a href="/Modulos/MdReclamosUnity/wbFrmReclamosGeneralAutos.aspx"  title="Total de reclamos de autos en seguimiento" style="font-size: 100px;" class="fa fa-car " aria-hidden="true"></a>
                        <br />
                        <br />
                        <p style="text-align:center"><asp:Label ID="totalReclamosAutos" runat="server" aria-hidden="true" ForeColor="#797D7F"></asp:Label></p>
                    </h1>
                </div>
            </div>
        </div>
        <div class="col-md-4 col-lg-4" style="height: 300px;">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b> Seguimiento De Reclamos Daños</b></p>
                </div>
                <div class="panel-body">
                   <h1>
                    <a href="/Modulos/MdReclamosUnity/wbFrmReclamosDañosGeneral.aspx" title="Total de reclamos de daños en seguimiento" style="font-size: 100px;" class="fa fa-exclamation-triangle" aria-hidden="true"></a>
                    <br />
                    <br />
                    <p style="text-align:center"><asp:Label ID="totalReclamosDaños" runat="server" aria-hidden="true" ForeColor="#797D7F"></asp:Label></p>
                </h1>
                </div>
            </div>
        </div>
        <div class="col-md-4 col-lg-4" style="height: 300px;">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b>Seguimiento De Reclamos Medicos</b></p>
                </div>
                <div class="panel-body">
                    <a href="/Modulos/MdReclamosUnity/wbFrmReclamosMedicosGeneral.aspx?id=1" style="font-size: 80px;" class="fa fa-heartbeat" aria-hidden="true"></a>
                    <br />
                    <div class="form-inline">
                        <h2>
                            <asp:LinkButton ID="lnTotalIndividuales" OnClick="lnTotalIndividuales_Click" ToolTip="Reclamos Individuales en total" runat="server" ForeColor="#797D7F"></asp:LinkButton>/
                        <asp:LinkButton ID="lnIndividualesFueraTiempo" OnClick="lnIndividualesFueraTiempo_Click" runat="server" Style="color: red" ToolTip="Reclamos individuales fuera de tiempo"></asp:LinkButton>
                        </h2>
                        <h2>
                            <asp:LinkButton ID="lnColectivos" OnClick="lnColectivos_Click" runat="server" ToolTip="Reclamos de colectivos en total" ForeColor="#797D7F"></asp:LinkButton>/
                        <asp:LinkButton ID="lnColectivosFueraTiempo" OnClick="lnColectivosFueraTiempo_Click" runat="server" Style="color: red" ToolTip="Reclamos de colectivos fuera de tiempo"></asp:LinkButton>
                        </h2>
                        <h2>
                            <asp:LinkButton ID="lnTotal" runat="server" ToolTip="Reclamos de gastos medicos en total" ForeColor="#797D7F"></asp:LinkButton>/
                        <asp:LinkButton ID="lnTotalFueraTiempo" runat="server" Style="color: red" ToolTip="Reclamos de gastos medicos en total fuera de tiempo"></asp:LinkButton>
                        </h2>
                        <h2>
                            <asp:LinkButton ID="lnPendienteDocumentacion" OnClick="lnPendienteDocumentacion_Click" runat="server" ToolTip="Reclamos de gastos medicos en total" ForeColor="#797D7F"></asp:LinkButton>/
                        <asp:LinkButton ID="lnPendienteDocumentacionFueraTiempo" runat="server" Style="color: red" ToolTip="Reclamos de gastos medicos en total fuera de tiempo"></asp:LinkButton>
                        </h2>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

