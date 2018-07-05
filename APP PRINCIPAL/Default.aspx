<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="seleccionar" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class="menu-cuadrado btn-acciones-laterales">
        <div class="col-md-3 col-lg-3">
        </div>
        <div class="col-md-3 col-lg-3" style="height:250px;">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b>Cabina De llamadas</b></p>
                </div>
                <div class="panel-body">
                    <a href="/Modulos/Dashboard/DashboardCabina.aspx" title="Control de reportes realizados en cabina de llamadas de emergencia" style="font-size: 90px;"><i class="fa fa-phone-square"></i></a>
                    <p style="text-align: center">
                       <b>Control de llamadas realizadas en cabina</b>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-3 col-lg-3" style="height:250px;">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b>Seguimiento Unity</b></p>
                </div>
                <div class="panel-body">
                    <a href="/Modulos/Dashboard/DashboardUnity.aspx" title="Seguimiento De Reclamos en Unity Promotores" style="font-size: 80px;">
                        <img src="imgUnity/Unity%20Promotores%20transparente.png" style="height:125px;"/></a>
                    <p style="text-align: center">
                        <b>Control De Reclamos en Unity</b>
                    </p>
                </div>
            </div>
        </div>
        <div class="col-md-3 col-lg-3" style="height:250px;">
        </div>
         <div class="col-md-3 col-lg-3" style="height:250px;">
        </div>
         <div class="col-md-3 col-lg-3" style="height:250px;">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b>Producto No Conforme</b></p>
                </div>
                <div class="panel-body">
                    <a href="/Modulos/Dashboard/DashboardNoConforme.aspx" title="Control de Producto no conforme" style="font-size: 80px;"><i class="fa fa-frown-o"></i></a>
                    <p style="text-align: center">
                       <b>Control de producto no conforme</b>
                    </p>
                </div>
            </div>
        </div>
         <div class="col-md-3 col-lg-3" style="height:250px;">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <p style="text-align: center; font-size: 16px;"><b>Control Mensajeria</b></p>
                </div>
                <div class="panel-body">
                    <a href="#" title="Control de mensajeria" style="font-size: 80px;"><i class="fa fa-envelope-o"></i></a>
                    <p style="text-align: center">
                       <b>Control De Mensajeria</b>
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

