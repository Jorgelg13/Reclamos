<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ControlMaternidad.aspx.cs" Inherits="MdBitacora_ControlMaternidad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/estilos.css" rel="stylesheet" />
    <link href="../Scripts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/toastr.min.css" rel="stylesheet" />
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <title>Control Maternidad</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron titulo-cabecera" style="height: 81px;">
            <h2 style="width: 781px; padding-bottom: 20px; font-size: 22px;">Control De Maternidad</h2>
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
        <div class="container-fluid">
            <div class="col-lg-3">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h3 class="panel-title"><b style="font-size: 16px;">Buscar</b></h3>
                    </div>
                    <div class="panel-body" style="height: 500px">
                        <div class="form-inline">
                            <asp:TextBox CssClass="form-control" Style="width: 70%" runat="server" ID="txtbuscar"></asp:TextBox>
                            <asp:Button CssClass="btn btn-primary" runat="server" ID="buscar" Text="Buscar" OnClick="buscar_Click" />
                        </div>
                        <br />
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <label>Poliza:</label>
                            <asp:TextBox runat="server" ID="txtPoliza" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Poliza"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                             <label>Nombre Asegurado:</label>
                            <asp:TextBox runat="server" ID="txtNombre" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <label>Ejecutivos:</label>
                            <asp:DropDownList runat="server" ID="ddlEjecutivos" CssClass="form-control" Width="100%">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <label>Fecha Probable de parto:</label>
                            <asp:TextBox runat="server" ID="txtFechaAprox" type="date" Style="width: 100%" autocomplete="off" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton runat="server" ID="Guardar" ToolTip="guardar registro" OnClick="Guardar_Click" Style="font-size: 40px;"><i class="fa fa-floppy-o"></i></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lnAtendidos" ToolTip="Actualizar" OnClick="lnAtendidos_Click" Style="font-size: 40px;"><i class="fa fa-check-square-o"></i></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Panel runat="server" ID="PanelSeleccionar" Visible="false">
                <div class="col-lg-9">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title"><b style="font-size: 16px;">Asegurados</b></h3>
                        </div>
                        <div class="panel-body" style="overflow-x: auto; height: 300px">
                            <asp:GridView ID="GridAsegurados" runat="server" CssClass="table table-responsive table-hover" OnSelectedIndexChanged="GridAsegurados_SelectedIndexChanged" AutoGenerateColumns="True" GridLines="None"
                                AllowCustomPaging="True" AllowPaging="True" PageSize="50">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="Elegir">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:CommandField>
                                </Columns>
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle HorizontalAlign="Left" Wrap="False" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="col-lg-9">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h3 class="panel-title"><b style="font-size: 16px;">Pendientes</b></h3>
                    </div>
                    <div class="panel-body" style="overflow-x: auto; height: 400px;">
                        <asp:GridView ID="GridPendientes" runat="server" CssClass="table table-responsive table-hover" AutoGenerateColumns="True" GridLines="None" AllowCustomPaging="True" AllowPaging="True" PageSize="300">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChAtendido" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Left" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <%--archivos javascripts que se utilizan en el sistema--%>
        <script src="../Scripts/jquery-3.1.1.min.js"></script>
        <script src="../bootstrap/js/bootstrap.min.js"></script>
        <script src="../Scripts/jquery.cookie.min.js"></script>
        <script src="../Scripts/toastr.min.js"></script>
        <script src="../Scripts/app.js"></script>
    </form>
</body>
</html>
