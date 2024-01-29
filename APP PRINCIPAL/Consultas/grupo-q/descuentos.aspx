<%@ Page Language="C#" AutoEventWireup="true" CodeFile="descuentos.aspx.cs" Inherits="Consultas_vifrio_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Descuentos Grupo Q</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous" />
    <link href="estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="fondo-descuentos">
        <div class="container">
            <div class="row justify-content-md-center" style="justify-content: center; display:flex; flex-direction:row">
                <img src="../../imgUnity/wtw_logo.png" />
                <img src="../../imgUnity/logo_grupo_q.png" />
            </div>
            <div class="col justify-content-md-center mb-3"  style="justify-content:center; text-align:center; display:flex; flex-direction:column">
                <span>Programe su cita por Whatsapp al 5814-0438 indicando la sucursal en donde desea realizar su servicio.</span>
                <span>Al llegar al centro de servicio deberá proporcionar su número de póliza para identificar su vehículo.</span>
                <span>Indicar el descuento que desee utilizar.</span>
            </div>
            <div class="row justify-content-center " style="justify-content: center; margin-top:-40px">
                <div class="col col-auto margen-container-table" style="min-width: 330px;">
                    <h5>Listado de descuentos</h5>
                    <asp:GridView CssClass="table table-striped scrolling-table-container"
                        ID="GridDescuentos"
                        runat="server"
                        AutoGenerateColumns="True"
                        ForeColor="#333333"
                        GridLines="None">
                        <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                        <RowStyle Wrap="false" HorizontalAlign="Left" Font-Size="Small" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
