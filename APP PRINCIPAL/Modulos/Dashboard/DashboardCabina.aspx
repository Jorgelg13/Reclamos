<%@ Page Title="Reclamos Unity" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DashboardCabina.aspx.cs" Inherits="_Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <div class="container menu-cuadrado btn-acciones-laterales">
        <div class="col-md-6 col-lg-6">
            <div class="panel panel-info" style="height: 200px;">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b>Asistencias y accidentes de autos</b></p>
                </div>
                <div class="panel-body">
                    <h1>
                        <a href="/Modulos/MdReclamos/wbFrmReclamosAutosGeneral.aspx" style="font-size: 100px;" class="fa fa-car " aria-hidden="true"><span>   </span><asp:Label ID="totalReclamosAutos" runat="server" aria-hidden="true" ForeColor="#797D7F"></asp:Label></a>
                        <br />
                    </h1>
                </div>
            </div>
        </div>
        <div class="col-md-6 col-lg-6">
            <div class="panel panel-info" style="height: 200px;">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b>Asistencias de daños varios</b></p>
                </div>
                <div class="panel-body">
                    <h1>
                        <a href="/Modulos/MdReclamos/wbFrmReclamosDañosGeneral.aspx" style="font-size: 100px;" class="fa fa-exclamation-triangle" aria-hidden="true"><span>   </span><asp:Label ID="totalReclamosDaños" runat="server" aria-hidden="true" ForeColor="#797D7F"></asp:Label></a>
                    </h1>
                </div>
            </div>
        </div>
    </div>

    <div class="container menu-cuadrado btn-acciones-laterales">
        <div class="col-md-6 col-lg-6" >
            <div class="panel panel-info" style="height: 200px;">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b>Reclamos Medicos en recepcion</b></p>
                </div>
                <div class="panel-body">
                    <h1>
                        <a href="/Modulos/MdReclamos/wbFrmReclamosMedicosGeneral.aspx" style="font-size: 100px;" class="fa fa-heartbeat" aria-hidden="true"><span>    </span><asp:Label ID="totalReclamosMedicos" runat="server" aria-hidden="true" ForeColor="#797D7F"></asp:Label></a>
                    </h1>
                </div>
            </div>
        </div>
        <div class="col-md-6 col-lg-6" >
            <div class="panel panel-info" style="height: 200px;">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b>Autorizaciones reportadas</b></p>
                </div>
                <div class="panel-body">
                    <h1>
                        <a href="/Modulos/MdReclamos/wbFrmAutorizacionesGenerales.aspx" style="font-size: 100px;" class=" fa fa-medkit" aria-hidden="true"><span>    </span><asp:Label ID="totalReclamosAutorizaciones" runat="server" Style="padding-left: 10px;" aria-hidden="true" ForeColor="#797D7F"></asp:Label></a>
                        <br />
                    </h1>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
</asp:Content>
