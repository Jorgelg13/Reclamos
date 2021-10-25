<%@ Page Language="C#" AutoEventWireup="true" CodeFile="descuentos.aspx.cs" Inherits="Consultas_vifrio_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>DescuentosVifrio</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous" />
    <link href="estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="fondo-descuentos">
        <div class="container">
            <div class="row justify-content-md-center" style="justify-content: center">
                <img src="../../imgUnity/unity-wtw2.png" />
            </div>
            <ul>
                <li>Programar su cita al 2413-1313 indicando la sucursal en donde desea realizar su servicio. <a href="http://www.vifrio.com/page.php?st=contacto&ref=18"> Ver sucursales aqui.</a></li>
                <li>Al llegar al centro de servicio deberá proporcionar su número de cuenta para identificar que es asociado de Caja de Ahorro.</li>
                <li>Indicar el descuento que desee utilizar.</li>
            </ul>
            <div class="row justify-content-center " style="justify-content: center; margin-top:-40px">
                <div class="col col-auto margen-container-table">
                    <h4>Listado de descuentos</h4>
                    <asp:GridView CssClass="table table-striped scrolling-table-container table-responsive "
                        ID="GridDescuentos"
                        runat="server"
                        AutoGenerateColumns="True"
                        ForeColor="#333333"
                        GridLines="None">
                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                        <RowStyle Wrap="false" HorizontalAlign="Left" Font-Size="Small" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
