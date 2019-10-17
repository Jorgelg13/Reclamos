<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Renovaciones.master" AutoEventWireup="true" CodeFile="cambiar-estado.aspx.cs" Inherits="Modulos_MdRenovaciones_Catalogo_cambiar_estado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading"><b>Cambiar Estado</b></div>
            <div class="panel-body">
                <div class="form-group  col-sm-12 col-md-6 col-lg-2" style="padding-top: 10px;">
                    <label>Desde:</label>
                    <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                </div>
                <div class="form-group  col-sm-12 col-md-6 col-lg-2" style="padding-top: 10px;">
                    <label>Hasta:</label>
                    <asp:TextBox ID="txtFechaFin" type="date" Height="34px" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                </div>
                <div class="form-group  col-sm-12 col-md-6 col-lg-2" style="padding-top: 10px;">
                    <label>Estado:</label>
                    <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control" Width="100%">
                        <asp:ListItem Value="1">Cargada</asp:ListItem>
                        <asp:ListItem Value="2">Asignada</asp:ListItem>
                        <asp:ListItem Value="3">Enviada</asp:ListItem>
                        <asp:ListItem Value="4">Renovada</asp:ListItem>
                        <asp:ListItem Value="5">Cancelada</asp:ListItem>
                        <asp:ListItem Value="6">No Enviada</asp:ListItem>
                        <asp:ListItem Value="8">Invalida</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 0px;">
                    <asp:GridView ID="GridPolizas" CssClass="table bs-table table-responsive" runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                        <Columns>
                            <asp:TemplateField HeaderText="Seleccionar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chCambiarEstado" runat="server" Text="Cambiar"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" Wrap="false" />
                        <PagerStyle BackColor="#131B4D" ForeColor="White" HorizontalAlign="Center" />
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
            <asp:LinkButton ID="btnGenerarTabla" OnClick="btnGenerarTabla_Click" title="Buscar Datos" CssClass="letter" autopostback="true" runat="server"><i class="fa fa-table"></i></asp:LinkButton>
        </div>
        <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
            <asp:LinkButton ID="btnGuardarCambios" title="Guardar" OnClick="btnGuardarCambios_Click" CssClass="letter" autopostback="true" runat="server"><i class="fa fa-save"></i></asp:LinkButton>
        </div>
        <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
            <p class="plus">+</p>
            <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentJS" Runat="Server">
</asp:Content>

