<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ResultadoEncuesta.aspx.cs" Inherits="MdBitacora_ResultadoEncuesta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/summernote.css" rel="stylesheet" />
    <link href="../css/estilos.css" rel="stylesheet" />
    <link href="../Scripts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/toastr.min.css" rel="stylesheet" />
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="../css/GridviewScroll.css" rel="stylesheet" />
    <title>Resultado Encuesta</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron titulo-cabecera" style="height: 100px; background-color: #087fca">
            <h2 style="width: 781px; padding-bottom: 20px;">Resultado De Encuesta</h2>
            <header>
                <div class="content-wrapper">
                    <div class="float-right">
                        <div class="img-float-right" style="float: right;">
                            <img src="../imgUnity/Unity%20Promotores-%20Logo%20en%20blanco.png" style="margin-top: -105px; width: 235px;" />
                        </div>
                    </div>
                </div>
            </header>
        </div>
        <br />
        <div class="form-group col-lg-2 col-md-2 col-sm-12">
            <label for="message-text" class="control-label">Tipo Encuesta:</label>
            <asp:DropDownList ID="ddlTipoEncuesta" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoEncuesta_SelectedIndexChanged" runat="server" Style="width: 100%" Height="34px" CssClass="form-control">
                <asp:ListItem Value="1">Implants</asp:ListItem>
                <asp:ListItem Value="2">Recepcion</asp:ListItem>
                <asp:ListItem Value="3">Egresos Hospitalarios</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group col-lg-2 col-md-2 col-sm-12">
            <label for="message-text" class="control-label">Fecha Inicio:</label>
            <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-lg-2 col-md-2 col-sm-12">
            <label for="message-text" class="control-label">Fecha Fin:</label>
            <asp:TextBox ID="txtFechaFin" type="date" Height="34px" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-lg-2 col-md-2 col-sm-12">
            <label for="message-text" class="control-label">Empresa:</label>
            <asp:DropDownList ID="ddlEmpresa" runat="server" Style="width: 100%" Height="34px" CssClass="form-control">
                <asp:ListItem Value="Todas">Todas</asp:ListItem>
                <asp:ListItem Value="Sidegua">sidegua</asp:ListItem>
                <asp:ListItem Value="Intupersa">Intupersa</asp:ListItem>
                <asp:ListItem Value="Walmart-zona-9">Walmart-zona-9</asp:ListItem>
                <asp:ListItem Value="Walmart-mixco">Walmart-mixco</asp:ListItem>
                <asp:ListItem Value="Telus-Margaritas">Telus-Margaritas</asp:ListItem>
                <asp:ListItem Value="Telus-Zona-10">Telus-Zona-10</asp:ListItem>
                <asp:ListItem Value="Transactel">Transactel</asp:ListItem>
                <asp:ListItem Value="Credomatic">Credomatic</asp:ListItem>
                <asp:ListItem Value="Caja-de-ahorro">Caja de ahorro</asp:ListItem>
                <asp:ListItem Value="Consulto-Seguro">Consulto Seguro</asp:ListItem>
                <asp:ListItem Value="Energuate">Energuate</asp:ListItem>
                <asp:ListItem Value="Bandegua-gt">Bandegua gt</asp:ListItem>
                <asp:ListItem Value="Aceros">Aceros</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group  col-lg-2 col-md-2 col-sm-12">
            <asp:Button runat="server" ID="btnBuscar" BackColor="#087fca" Style="margin-top: 24px;" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click1" />
        </div>
        <asp:Panel runat="server" ID="PnPrincipal">
            <div class="col-sm-12 col-md-12 col-lg-12">
                <br />
                <div class="scrolling-table-container col-sm-12 col-md-9 col-lg-9">
                    <b style="font-size: 20px">
                        <asp:Label runat="server" ID="lblTotalEncuestas"></asp:Label>
                    </b>
                    <asp:LinkButton ID="linkDescargar" Visible="false" OnClick="linkDescargar_Click" title="Descargar en excel" runat="server" Style="font-size: 20px; text-align: center; color: green"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
                    <asp:GridView ID="GridEncuestas" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#087fca" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#087fca" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" Wrap="false" />
                    </asp:GridView>
                </div>
                <div class="scrolling-table-container col-sm-12 col-md-3 col-lg-3">
                    <b style="font-size: 20px">
                        <asp:Label runat="server" ID="lblAgrupados"></asp:Label>
                    </b>
                    <asp:GridView ID="GridAgrupados" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#087fca" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#087fca" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                    </asp:GridView>
                </div>
            </div>
            <br />
            <div style="margin-top: 30%; padding-left: 20px;">
                <p><b>PREGUNTA 1: En una calificacion de 1 a 10 ¿con base en su experiencia con Unity Promotores, usted recomendaria a un familiar o amigo el servicio de Unity Promotores? </b></p>
                <p><b>PREGUNTA 2: En su experiencia, por favor calificar mi servicio, de 1 A 10, en donde 10 es excelente</b></p>
                <p><b>PREGUNTA 3: En su experiencia, por favor calificar el servicio de la aseguradora, de 1 a 10, en donde 10 es excelente</b></p>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="PnRecepcion" Visible="false">
            <div class="col-sm-12 col-md-12 col-lg-12">
                <br />
                <div class="scrolling-table-container col-sm-12 col-md-12 col-lg-12">
                    <b style="font-size: 20px">
                        <asp:Label runat="server" ID="lblTotalRecepcion"></asp:Label>
                    </b>
                    <asp:LinkButton ID="lnEncuestaRecepcion" Visible="false" OnClick="lnEncuestaRecepcion_Click" title="Descargar en excel" runat="server" Style="font-size: 20px; text-align: center; color: green"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                    <asp:GridView ID="GridRecepcion" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#087fca" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#087fca" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" Wrap="false" />
                    </asp:GridView>
                </div>
            </div>
            <br />
            <div style="margin-top: 30%; padding-left: 20px;">
                <p><b>PREGUNTA 1: En una calificacion de 1 a 10 ¿con base en su experiencia con Unity Promotores, usted recomendaria a un familiar o amigo el servicio de Unity Promotores? </b></p>
                <p><b>OPERACION : ¿Que operacion vino a realizar a Unity Promotores?</b></p>
                <p><b>PREGUNTA 2: En su experiencia, por favor calificar de 1 a 10 el servicio que recibio en donde 10 es excelente</b></p>
                <p><b>PREGUNTA 3: En su experiencia, por favor calificar de 1 a 10 el servicio que recibio en recepcion, en donde 10 es excelente</b></p>
            </div>
        </asp:Panel>
         <asp:Panel runat="server" ID="PnEgresosHospitalarios" Visible="false">
            <div class="col-sm-12 col-md-12 col-lg-12">
                <br />
                <div class="scrolling-table-container col-sm-12 col-md-12 col-lg-12">
                    <b style="font-size: 20px">
                        <asp:Label runat="server" ID="lbltotalegresos"></asp:Label>
                    </b>
                    <asp:LinkButton ID="lnEgresosHispilarios" Visible="false" OnClick="lnEgresosHispilarios_Click" title="Descargar en excel" runat="server" Style="font-size: 20px; text-align: center; color: green"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                    <asp:GridView ID="GridEgresosHospitalarios" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#087fca" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#087fca" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" Wrap="false" />
                    </asp:GridView>
                </div>
            </div>
            <br />
            <div style="margin-top: 30%; padding-left: 20px;">
                <p><b>¿Nombre del Hospital que brindo el servicio? </b></p>
                <p><b>¿Cual seria su satisfaccion en el servicio recibido por el hospital?</b></p>
                <p><b>¿Puede indicar el tiempo que demoro el tramite de egreso?</b></p>
            </div>
        </asp:Panel>
        <%--archivos javascripts que se utilizan en el sistema--%>
        <script src="../Scripts/jquery-3.1.1.min.js"></script>
        <script src="../bootstrap/js/bootstrap.min.js"></script>
        <script src="../Scripts/toastr.min.js"></script>
        <script src="../Scripts/gridviewScroll.min.js"></script>
        <script src="../Scripts/app.js"></script>
    </form>
</body>
</html>
