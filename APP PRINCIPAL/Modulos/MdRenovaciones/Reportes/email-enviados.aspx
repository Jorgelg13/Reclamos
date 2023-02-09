<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Renovaciones.master" AutoEventWireup="true" CodeFile="email-enviados.aspx.cs" Inherits="Modulos_MdRenovaciones_Reportes_email_enviados" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading">
                <b style="margin-right: 14px;">Reporte de emails enviados</b>
                <asp:CheckBox runat="server" ID="checkUsuarios" CssClass="ml-5" Text="Filtrar por usuario" AutoPostBack="true" OnCheckedChanged="checkUsuarios_CheckedChanged"/>
            </div>
            <div class="panel-body">
                <div class="form-group  col-sm-12 col-md-6 col-lg-2" style="padding-top: 10px;">
                    <label>Desde:</label>
                    <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                </div>
                <div class="form-group  col-sm-12 col-md-6 col-lg-2" style="padding-top: 10px;">
                    <label>Hasta:</label>
                    <asp:TextBox ID="txtFechaFin" type="date" Height="34px" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-sm-12 col-md-6 col-lg-2" style="padding-top: 10px;">
                    <label>Usuarios:</label>
                    <asp:DropDownList CssClass="form-control" style="width:100%" runat="server" ID="ddlUsuarios" >
                    </asp:DropDownList>
                </div>
                  <div class="form-group  col-sm-12 col-md-6 col-lg-2" style="padding-top: 10px;">
                    <label>Area:</label>
                    <asp:DropDownList CssClass="form-control" runat="server" ID="ddlArea">
                        <asp:ListItem Value="0">Todas</asp:ListItem>
                        <asp:ListItem Value="1">Individual</asp:ListItem>
                        <asp:ListItem Value="11">VIP</asp:ListItem>
                        <asp:ListItem Value="2">Corporativo</asp:ListItem>
                        <asp:ListItem Value="12">Cuentas Globales</asp:ListItem>
                        <asp:ListItem Value="3">Vida</asp:ListItem>
                        <asp:ListItem Value="4">Beneficios</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 0px;">
                    <asp:GridView ID="GridReporte" CssClass="table bs-table table-responsive" runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                        <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" Wrap="false" />
                        <PagerStyle BackColor="#48086f" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" Wrap="false" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <%-- botones circulares con las opciones multiples --%>
    <div id="container-floating">
        <div class="nd3 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
            <asp:LinkButton ID="btnExportar" title="Exportar a excel" CssClass="letter" runat="server" OnClick="btnExportar_Click"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
        </div>
        <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
            <asp:LinkButton ID="btnGenerarTabla" title="Generar Datos" CssClass="letter" autopostback="true" runat="server" OnClick="btnGenerarTabla_Click"><i class="fa fa-table"></i></asp:LinkButton>
        </div>
        <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create">
            <p class="plus">+</p>
            <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentJS" Runat="Server">
</asp:Content>

