<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashboardUnity.aspx.cs" Inherits="DashboardUnity" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/estilos.css" rel="stylesheet" />
    <link href="../Scripts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <title>Consulta Reclamos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron titulo-cabecera" style="height: 81px;">
            <h2 style="width: 781px; padding-bottom: 20px; font-size: 22px;">Consulta De Reclamos</h2>
            <div class="content-wrapper">
                <div class="float-right">
                    <div class="img-float-right" style="float: right;">
                        <img src="../imgUnity/Unity%20Promotores-%20Logo%20en%20blanco.png" style="margin-top: -97px; width: 166px;" />
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
        <asp:Panel runat="server" ID="PanelPrincipal">
            <div class="container menu-cuadrado btn-acciones-laterales">
                <div class="col-md-4 col-lg-4" style="height: 300px;">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <p style="text-align: center; font-size: 16px;"><b>Consultar Reclamos</b></p>
                        </div>
                        <div class="panel-body">
                            <h1>
                                <asp:LinkButton runat="server" title="Busqueda de reclamos" Style="font-size: 80px;" ID="ConsultarReclamos" OnClick="ConsultarReclamos_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                <br />
                                <br />
                            </h1>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-lg-4" style="height: 300px;">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <p style="text-align: center; font-size: 16px;"><b>Generar Reportes</b></p>
                        </div>
                        <div class="panel-body">
                            <h1>
                                <asp:LinkButton runat="server" title="Generar Reportes" Style="font-size: 80px;" ID="ConsultarReportes" OnClick="ConsultarReportes_Click"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                                <br />
                                <br />
                            </h1>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-lg-4" style="height: 300px;">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <p style="text-align: center; font-size: 16px;"><b>Maternidad</b></p>
                        </div>
                        <div class="panel-body">
                            <h1>
                                <asp:LinkButton runat="server" ID="ConsultarMaternidad" OnClick="ConsultarMaternidad_Click" title="Generar Reportes" Style="font-size: 80px;"><i class="fa fa-female"></i></asp:LinkButton>
                                <br />
                                <br />
                            </h1>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelConsultas" Visible="false">
            <div class="container menu-cuadrado btn-acciones-laterales">
                <div class="col-md-4 col-lg-4" style="height: 300px;">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <p style="text-align: center; font-size: 16px;"><b>Busqueda Reclamos Autos</b></p>
                        </div>
                        <div class="panel-body">
                            <h1>
                                <a href="/MdBitacora/wbFrmConsultaRAutos.aspx" title="Busqueda de reclamos de autos" style="font-size: 80px;" class="fa fa-car " aria-hidden="true"></a>
                                <br />
                                <br />
                            </h1>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-lg-4" style="height: 300px;">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <p style="text-align: center; font-size: 16px;"><b>Busqueda De Reclamos Daños</b></p>
                        </div>
                        <div class="panel-body">
                            <h1>
                                <a href="/MdBitacora/wbFrmConsultaDaños.aspx" title="Busqueda de reclamos de daños varios" style="font-size: 80px;" class="fa fa-home" aria-hidden="true"></a>
                                <br />
                                <br />
                            </h1>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-lg-4" style="height: 300px;">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <p style="text-align: center; font-size: 16px;"><b>Busqueda De Reclamos Medicos</b></p>
                        </div>
                        <div class="panel-body">
                            <h1>
                                <a href="/MdBitacora/wbFrmConsultaRmedicos.aspx" style="font-size: 80px;" class="fa fa-heartbeat"></a>
                                <br />
                                <br />
                            </h1>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelReportes" Visible="false">
            <div class="container menu-cuadrado btn-acciones-laterales">
                <div class="col-md-4 col-lg-4" style="height: 300px;">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <p style="text-align: center; font-size: 16px;"><b>Reportes de Reclamos de autos</b></p>
                        </div>
                        <div class="panel-body">
                            <h1>
                                <a href="/MdBitacora/ReportesAutos.aspx" title="Reportes de Autos" style="font-size: 80px;" class="fa fa-car "></a>
                                <br />
                                <br />
                            </h1>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-lg-4" style="height: 300px;">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <p style="text-align: center; font-size: 16px;"><b>Reportes de Daños varios</b></p>
                        </div>
                        <div class="panel-body">
                            <h1>
                                <a href="/MdBitacora/ReportesDanios.aspx" title="Reportes de daños varios" style="font-size: 80px;" class="fa fa-home"></a>
                                <br />
                                <br />
                            </h1>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-lg-4" style="height: 300px;">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <p style="text-align: center; font-size: 16px;"><b>Reportes de Gastos Medicos</b></p>
                        </div>
                        <div class="panel-body">
                            <h1>
                                <a href="/MdBitacora/ReportesMedicos.aspx" title="Reportes de gastos medicos" style="font-size: 80px;" class="fa fa-heartbeat"></a>
                                <br />
                                <br />
                            </h1>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <%--archivos javascripts que se utilizan en el sistema--%>
        <script src="../Scripts/jquery-3.1.1.min.js"></script>
        <script src="../bootstrap/js/bootstrap.min.js"></script>
        <script src="../Scripts/jquery.cookie.min.js"></script>
        <script src="../Scripts/app.js"></script>
    </form>
</body>
</html>


