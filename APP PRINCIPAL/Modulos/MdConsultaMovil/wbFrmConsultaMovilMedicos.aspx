<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wbFrmConsultaMovilMedicos.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmConsultaMovilMedicos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
            <asp:TextBox ID="txtRamo" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtSecren" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtPoliza" runat="server" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtAsegurado" Width="65%" autocomplete="off" runat="server" class="form-control col-xs-6 " placeholder="Buscar"></asp:TextBox>
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
                            <asp:GridView ID="GridView2" CssClass="table bs-table table-responsive table-hover tabla-polizas" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="224px">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="grupo" HeaderText="Grupo" SortExpression="grupo">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="codCobertura" HeaderText="Cod Cobertura" SortExpression="codCobertura">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" SortExpression="descripcion">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="clase1" HeaderText="Clase 1" SortExpression="clase1">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="clase2" HeaderText="Clase 2" SortExpression="clase2">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="clase3" HeaderText="Clase 3" SortExpression="clase3">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="clase4" HeaderText="Clase 4" SortExpression="clase4">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="clase5" HeaderText="Clase 5" SortExpression="clase5">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="clase6" HeaderText="Clase 6" SortExpression="clase6">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="clase7" HeaderText="Clase 7 " SortExpression="clase7">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="clase8" HeaderText="Clase 8" SortExpression="clase8">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="clase9" HeaderText="Clase 9" SortExpression="clase9">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="clase10" HeaderText="Clase 10" SortExpression="clase10">
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
                </div>
            </div>
        </div>

        <br />
        <div class="container-fluid" style ="padding-right: 0px; padding-left: 0px;">
            <div class="panel panel-default">
                <div class="panel-heading"><b>Informacion Polizas Medicas</b></div>
                <div class="panel-body" style ="padding-right: 0px; padding-left: 0px;">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridConsultasMedicas" runat="server"  CssClass="table bs-table table-responsive table-hover tabla-polizas" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourcePolizasMedicas" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridConsultasMedicas_SelectedIndexChanged">
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
                                <asp:BoundField DataField="nombre" HeaderText="Aseguradora" SortExpression="nombre">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="gst_nombre" HeaderText="Gestor " SortExpression="gst_nombre">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="contratante" HeaderText="Contratante" SortExpression="contratante">
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
                                <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="clase" HeaderText="Clase" SortExpression="clase">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ramo" HeaderText="Ramo" SortExpression="ramo">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="estado_poliza" HeaderText="Estado Poliza" SortExpression="estado_poliza">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="vip" HeaderText="VIP" SortExpression="vip">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="secren" HeaderText="Secuencia Renovacion" SortExpression="secren">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
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
                        <asp:SqlDataSource ID="SqlDataSourcePolizasMedicas" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [poliza], [asegurado], [nombre], [gst_nombre], [contratante], [vigi], [vigf], [tipo], [clase], [ramo], [estado_poliza], [vip],[secren] FROM [vistaReclamosMedicos] where (poliza = @poliza) and (asegurado like '%' + @asegurado +'%')">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtPoliza" Name="poliza" PropertyName="Text" DefaultValue="" />
                                <asp:ControlParameter ControlID="txtAsegurado" DefaultValue=" " Name="asegurado" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
         <%--<a href="/Modulos/MdConsultaMovil/wbFrmConsultaMovilCliente.aspx" type="button" class="btn btn-info btn-circle btn-lg botonRedondo" style="position: fixed; bottom: 16px; right: 18px;"><i class="material-icons">reply</i></a>--%>
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
        <asp:SqlDataSource ID="SqlDataSourceCoberturas" runat="server" ConnectionString="<%$ ConnectionStrings:seguroConnectionString %>" SelectCommand="pa_buscar_beneficios_hospital_por_poliza_" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtRamo" DefaultValue="" Name="i_ramo" PropertyName="Text" Type="Int32" />
                <asp:ControlParameter ControlID="txtPoliza" DefaultValue="" Name="i_poliza" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtSecren" DefaultValue="" Name="i_secren" PropertyName="Text" Type="Int16" />
                <asp:Parameter Name="o_valor_retorno" Type="Int32" DefaultValue="1" Direction="InputOutput" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
