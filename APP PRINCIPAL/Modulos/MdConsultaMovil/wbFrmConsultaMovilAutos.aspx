<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wbFrmConsultaMovilAutos.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmConsultaMovilAutos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html" charset= "utf-8" />
    <title>Consulta Movil</title>
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <link href="../../css/estilosMovil.css" rel="stylesheet" />
    <link href="../../bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

</head>
<body class="fondo">
    <form id="form1" runat="server">
        <section class="jumbotron2 fondoTexto" style="background-color: #131B4D">
            <div class="container-fluid">
                <p style="color: #eee;"><FONT SIZE=4>Informacion Polizas</FONT></p>
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
                                <asp:LoginStatus runat="server" LogoutAction="Redirect" Style="color: #eee;" LogoutText="Cerrar sesión" LogoutPageUrl="~/Modulos/MdReclamos/wbFrmConsultaMovilCliente" />
                                        </p>
                                    </LoggedInTemplate>
                                </asp:LoginView>
                            </section>
                        </div>
                    </div>
                </header>
            </div>
        </section>

            <div style="padding-right: 5px; padding-left: 10px;">
                <asp:TextBox ID="TextBox1" runat="server" class="form-control col-xs-6" placeholder="Buscar Auto" Style="width: 65%"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server" Visible="false" placeholder="Buscar"></asp:TextBox>
                <asp:TextBox ID="txtChasis" runat="server" Visible="false" placeholder="Buscar"></asp:TextBox>
                <button type="submit" class="btn btn-primary col-xs-2" style="background-color: #131B4D"><span class="glyphicon glyphicon-search"></span></button>
                <button type="button" class="btn btn-primary" data-toggle="modal" style="background-color: #131B4D" data-target="#myModal"><span class="glyphicon glyphicon-list-alt"></span></button>
            </div>
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel"><b style="color: black">Datos En General</b></h4>
                    </div>
                    <div class="modal-body">
                        <div class="scrolling-table-container">
                            <asp:GridView ID="GridView2" runat="server" CssClass="table bs-table table-responsive table-hover tabla-polizas" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourceCoberturasAutos" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="descr" HeaderText="Descripcion" SortExpression="descr">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="limite1" HeaderText="Limite 1" SortExpression="limite1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="limite2" HeaderText="Limite 2" SortExpression="limite2">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="deducible" HeaderText="Deducible" SortExpression="deducible">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="prima" HeaderText="Prima" SortExpression="prima">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="modal-footer">
                    </div>
                    <div class="container">
                        <asp:Label ID="lblPlaca" Style="color: black" runat="server" ></asp:Label>
                        <br />
                        <asp:Label ID="lblColor" Style="color: black" runat="server" ></asp:Label>
                        <br />
                        <asp:Label ID="lblMarca" Style="color: black" runat="server" ></asp:Label>
                        <br />
                        <asp:Label ID="lblModelo" Style="color: black" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblChasis" Style="color: black" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblMotor" Style="color: black" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblPropietario" Style="color: black" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblEjecutivo" Style="color: black" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblAseguradora" Style="color: black" runat="server"></asp:Label>
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>

        <br />
        <div class="container-fluid"  style ="padding-right: 0px; padding-left: 0px;">
            <div class="panel panel-default" style="height:380px;">
                <div class="panel-heading"><b>Informacion Autos</b></div>
                <div class="panel-body"  style ="padding-right: 0px; padding-left: 0px;">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridConsultaAuto" runat="server" CssClass="table bs-table table-responsive table-hover tabla-polizas" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourceBusquedaAutos" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridConsultaAuto_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="poliza" HeaderText="Poliza" SortExpression="poliza">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="asegurado" HeaderText="Asegurado" SortExpression="asegurado">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="placa" HeaderText="Placa" SortExpression="placa">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="marca" HeaderText="Marca" SortExpression="marca">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="color" HeaderText="Color" SortExpression="color">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="modelo" HeaderText="Modelo" SortExpression="modelo">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="motor" HeaderText="Motor" SortExpression="motor">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="chasis" HeaderText="Chasis" SortExpression="chasis">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nombre" HeaderText="Aseguradora" SortExpression="nombre">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="vigi" HeaderText="Vigencia Inicial" SortExpression="vigi" DataFormatString="{0:dd/MM/yyyy}">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="vigf" HeaderText="Vigencia Final" SortExpression="vigf" DataFormatString="{0:dd/MM/yyyy}">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="gst_nombre" HeaderText="Gestor" SortExpression="gst_nombre">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="suma_aseg" HeaderText="Suma Asegurada" SortExpression="suma_aseg">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="vip" HeaderText="vip" SortExpression="vip" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSourceBusquedaAutos" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [poliza], [asegurado], [placa], [marca], [color], [modelo], [motor], [chasis], [nombre], [vigi], [vigf], [gst_nombre], [suma_aseg], [vip] FROM [ViewBusquedaAuto] where (poliza = @poliza)  and (asegurado like  '%' + @asegurado +'%'  or placa like '%' + @placa +'%') ">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TextBox2" Name="poliza" PropertyName="Text" DefaultValue="" />
                                <asp:ControlParameter ControlID="TextBox1" Name="asegurado" PropertyName="Text" DefaultValue=" " />
                                <asp:ControlParameter ControlID="TextBox1" DefaultValue="-" Name="placa" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSourceCoberturasAutos" runat="server" ConnectionString="<%$ ConnectionStrings:seguroConnectionString %>" SelectCommand="SELECT [descr], [limite1], [limite2], [deducible], [prima] FROM [viewCoberturasAutos] where (chasis = @chasis)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtChasis" Name="chasis" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
             <%--<a href="/Modulos/MdConsultaMovil/wbFrmConsultaMovilCliente.aspx" type="button" class="btn btn-info btn-circle btn-lg botonRedondo" style="position: fixed; bottom: 16px; right: 18px;"><i class="material-icons">reply</i></a>--%>

              <%-- botones circulares con opciones en la parte inferior derecha de la pantalla--%>
            <div id="container-floating">
                <div class="nd4 nds" data-toggle="tooltip" data-placement="left" data-original-title="Simone">
                    <asp:LinkButton ID="linkSalir" OnClick="linkSalir_Click" CssClass="letter" runat="server"><i class="fa fa-times" aria-hidden="true"></i></asp:LinkButton>
                </div>
                <div class="nd3 nds" data-toggle="tooltip" data-placement="left" data-original-title="contract@gmail.com">
                    <asp:LinkButton ID="linkRefresar" CssClass="letter" autopostback="true" runat="server"><i class="fa fa-undo" aria-hidden="true"></i></asp:LinkButton>
                </div>
                <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
                    <a href="javascript:history.back()" class ="letter" ><i class="fa fa-arrow-circle-left" aria-hidden="true"></i></a>
                </div>
                <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
                    <p class="plus">?</p>
                    <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
                </div>
            </div>
        </div>
        <script src="../../Scripts/jquery-3.1.1.min.js"></script>
        <script src="../../bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
        <script src="../../Scripts/app.js"></script>
    </form>
</body>
</html>

