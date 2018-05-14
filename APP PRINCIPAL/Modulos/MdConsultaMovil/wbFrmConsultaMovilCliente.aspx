<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wbFrmConsultaMovilCliente.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmConsultaMovilCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html" charset="utf-8" />
    <title>Consulta Movil</title>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <link href="../../css/estilosMovil.css" rel="stylesheet" />
    <link href="../../bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../css/toastr.min.css" rel="stylesheet" />
</head>
<body class="fondo">
    <asp:Label ID="lblPoliza" Visible="false" runat="server" Text="Label"></asp:Label>
    <form id="form1" runat="server">
        <asp:TextBox ID="txtRamo" CssClass="inputTxtRamo" type="hidden" runat="server"></asp:TextBox>
        <section class="jumbotron2 fondoTexto" style="background-color: #131B4D">
            <div class="container-fluid">
                <p style="color: #eee;"><font size="4">Informacion Polizas</font></p>
                <header>
                    <div class="content-wrapper">
                        <div class="float-right">
                            <section id="login">
                                <asp:LoginView runat="server" ViewStateMode="Disabled">
                                    <AnonymousTemplate>
                                        <ul>
                                            <li><a class="color" id="loginLink" runat="server" href="~/Account/Login"><strong style="color: #eee;">Iniciar sesión</strong></a></li>
                                            <br />
                                        </ul>
                                    </AnonymousTemplate>
                                    <LoggedInTemplate>
                                        <p style="margin-bottom: 3px;">
                                            Hola  <a runat="server" style="color: #eee;" class="username" href="/Account/CambioContrasenaMovil" title="Manage your account">
                                                <asp:LoginName runat="server" CssClass="username" />
                                            </a>!
                                <asp:LoginStatus runat="server" LogoutAction="Redirect" Style="color: #eee;" LogoutText="Cerrar sesión" LogoutPageUrl="~/Modulos/MdConsultaMovil/wbFrmConsultaMovilCliente.aspx" />
                                        </p>
                                    </LoggedInTemplate>
                                </asp:LoginView>
                            </section>
                        </div>
                    </div>
                </header>
            </div>
        </section>
        <asp:Label ID="lblId" runat="server" Visible="false" Text="Label"></asp:Label>
        <div style="padding-right: 5px; padding-left: 5px;">
            <asp:TextBox ID="txtBuscar" runat="server" autocomplete="off" class="form-control col-xs-6" Style="width: 50%" placeholder="Buscar"></asp:TextBox>
            <asp:DropDownList class="form-control col-xs-3" ID="DDLTipo" Style="width: 35%" Height="34px" runat="server">
                <asp:ListItem>Asegurado</asp:ListItem>
                <asp:ListItem>poliza</asp:ListItem>
            </asp:DropDownList>
            <asp:ImageButton Style="padding-left: 7px; padding-bottom: 1px;" ID="ImageButton1" runat="server" Height="29px" ImageUrl="~/Images/lupa2-iloveimg-resized.png" OnClick="ImageButton1_Click" />
        </div>
        <br />
        <div class="container-fluid" style="padding-right: 0px; padding-left: 0px; margin-right: auto; margin-left: auto;">
            <div class="panel panel-default" style="height: 380px;">
                <div class="panel-heading"><b>Informacion Poliza</b></div>
                <div class="panel-body" style="padding-right: 0px; padding-left: 0px;">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridBusquedaCliente" EmptyDataText="No se encontro ese registro" CssClass="table bs-table table-responsive table-hover tabla-polizas" runat="server" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" AllowSorting="True" OnSelectedIndexChanged="GridBusquedaCliente_SelectedIndexChanged">
                            <EditRowStyle BackColor="#2461BF" />
                            <EmptyDataRowStyle BackColor="LightBlue"
                                ForeColor="Red" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#131B4D" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:seguroConnectionString %>" SelectCommand="SELECT * FROM  vistaBusquedaPolizaMovil WHERE (NombreCliente like  '%'+ @NombreCliente + '%') OR (poliza like  '%' + @poliza + '%')">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtBuscar" Name="NombreCliente" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtBuscar" Name="poliza" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <script src="../../Scripts/jquery-3.1.1.min.js"></script>
        <script src="../../bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
        <script src="../../Scripts/app.js"></script>
        <script src="../../Scripts/toastr.min.js"></script>
    </form>
</body>
</html>


