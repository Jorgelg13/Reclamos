<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pendientes.aspx.cs" Inherits="MdBitacora_CabinaVirtual_Pendientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Pendientes</title>
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../css/estilos.css" rel="stylesheet" />
    <link href="../../Scripts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron titulo-cabecera"  style="height: 81px; background-color:#087fca; ">
            <a href="#" style="color: white">
                <h2 style="width: 381px; padding-bottom: 20px;">Pendientes de atender</h2>
            </a>
            <div class="content-wrapper">
                <div class="float-right">
                    <div class="img-float-right" style="float: right;">
                        <img src="../../imgUnity/Unity%20Promotores-%20Logo%20en%20blanco.png" style="margin-top: -97px; width: 166px;" />
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
          <div class="col-lg-9 col-md-9 col-sm-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <b>Pendientes</b>
                </div>
                <div class="panel-body" style="padding: 0px;">
                    <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 0px;">
                        <asp:GridView ID="GridPendientes" runat="server" CssClass="table bs-table table-responsive" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                             <Columns>
                                    <asp:TemplateField HeaderText="Seleccionar">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="checkAsignar" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            <HeaderStyle BackColor="#087fca" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-12" style="margin-top: -21px;">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><b style="font-size: 16px;">Actualizar</b></h3>
                </div>
                <div class="panel-body" style="padding: 0px;">
                    <br />
                    <div class="form-group col-sm-12 col-md-12 col-lg-12">
                        <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control" style="width:100%">
                            <asp:ListItem Value="false">Pendiente</asp:ListItem>
                            <asp:ListItem Value="true">Atendido</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <asp:LinkButton runat="server" ID="lnGuardar" OnClick="lnGuardar_Click" Style="font-size: 40px;"><i class="fa fa-floppy-o"></i></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
      </div>
    </form>
</body>
</html>
