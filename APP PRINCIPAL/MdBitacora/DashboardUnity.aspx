<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashboardUnity.aspx.cs" Inherits="DashboardUnity" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/summernote.css" rel="stylesheet" />
    <link href="../css/estilos.css" rel="stylesheet" />
    <link href="../Scripts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/toastr.min.css" rel="stylesheet" />
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="../css/GridviewScroll.css" rel="stylesheet" />
    <title>Consulta Reclamos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron titulo-cabecera" style="height: 115px;">
            <h2 style="width: 781px; padding-bottom: 20px;">Consulta De Reclamos</h2>
            <header>
                <div class="content-wrapper">
                    <div class="float-right">
                        <div class="img-float-right" style="float: right;">
                            <img src="../imgUnity/Unity%20Promotores-%20Logo%20en%20blanco.png" style="margin-top: -90px; width: 235px;">
                        </div>
                    </div>
                </div>
            </header>
        </div>
        <br />
        <br />
        <div class="container menu-cuadrado btn-acciones-laterales">
            <div class="col-md-4 col-lg-4" style="height: 300px;">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <p style="text-align: center; font-size: 16px;"><b>Busqueda Reclamos Autos</b></p>
                    </div>
                    <div class="panel-body">
                        <h1>
                            <a href="/MdBitacora/wbFrmConsultaRAutos.aspx" title="Busqueda de reclamos de autos" style="font-size: 100px;" class="fa fa-car " aria-hidden="true"></a>
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
                            <a href="/MdBitacora/wbFrmConsultaDaños.aspx" title="Busqueda de reclamos de daños varios" style="font-size: 100px;" class="fa fa-exclamation-triangle" aria-hidden="true"></a>
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
                            <a href="/MdBitacora/wbFrmConsultaRmedicos.aspx" style="font-size: 100px;" class="fa fa-heartbeat" aria-hidden="true"></a>
                            <br />
                            <br />
                        </h1>
                    </div>
                </div>
            </div>
        </div>
        <%--archivos javascripts que se utilizan en el sistema--%>
        <script src="../Scripts/jquery-3.1.1.min.js"></script>
        <script src="../bootstrap/js/bootstrap.min.js"></script>
        <script src="../Scripts/jquery.cookie.min.js"></script>
        <script src="../Scripts/toastr.min.js"></script>
        <script src="../Scripts/gridviewScroll.min.js"></script>
        <script src="../Scripts/summernote.min.js"></script>
        <script src="../Scripts/jQuery.print.min.js"></script>
        <script src="../Scripts/app.js"></script>
    </form>
</body>
</html>


