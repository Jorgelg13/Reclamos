<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbFrmReporteCheques.aspx.cs" Inherits="Modulos_MdReportes_wbFrmReporteCheques" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="col-sm-12 col-md-12 col-lg-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><b style="font-size: 16px;">Listado de cheques ingresados<span style="margin-left: 100px">Total de registros: </span>
                    <asp:Label ID="lblConteo" runat="server" Style="font-size: 20px;"></asp:Label></b></h3>
                </div>
                <div class="panel-body" style="max-height: 620px;">
                    <div class="form-inline">
                        <div class="form-group" style="width: 15%">
                            <label>Fecha Inicio:</label>
                            <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" 
                                Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group" style="width: 15%">
                            <label>Fecha Fin:</label>
                            <asp:TextBox ID="txtFechaFin" type="date" Height="34px" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server">
                            </asp:TextBox>
                        </div>
                         <div class="form-group" style="width: 15%">
                          <asp:CheckBox runat="server" ID="chFiltro" Text="Filtrar" OnCheckedChanged="chFiltro_CheckedChanged" AutoPostBack="true" />
                          <asp:DropDownList runat="server" ID="ddlUsuario" CssClass="form-control" Style="width: 100%" Enabled="false">
                          </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <asp:Panel runat="server" ID="PanelPrincipal">
                        <div style="text-align: center; font-size: 20px;">
                            <b>
                                <asp:Label runat="server" ID="lblTitulo"></asp:Label></b>
                            <br />
                            <asp:Label runat="server" ID="lblPeriodo"></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="lblFechaGeneracion"></asp:Label>
                            <asp:Label runat="server" ID="lblUsuario" Style="padding-right: 15px;"></asp:Label>
                        </div>
                        <br />
                        <div class="scrolling-table-container">
                            <asp:GridView ID="GridCheques" runat="server" CssClass="table bs-table table-responsive" AutoGenerateColumns="True" 
                                ForeColor="#333333" GridLines="None" AllowCustomPaging="True" PageSize="3000">
                                <AlternatingRowStyle BackColor="White" />
                                <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <PagerSettings PageButtonCount="30" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            </asp:GridView>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <%-- botones circulares con las opciones multiples --%>
        <div id="container-floating">
            <div class="nd4 nds" data-toggle="tooltip" data-placement="left" data-original-title="Simone">
                <asp:LinkButton ID="linkSalir" OnClick="linkSalir_Click" CssClass="letter" runat="server"><i class="fa fa-times"></i></asp:LinkButton>
            </div>
            <div class="nd3 nds" data-toggle="tooltip" data-placement="left" data-original-title="contract@gmail.com">
                <asp:LinkButton ID="btnExportar" OnClick="btnExportar_Click" CssClass="letter" runat="server"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
            </div>
            <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
                <asp:LinkButton ID="btnGenerarTabla" OnClick="btnGenerarTabla_Click" CssClass="letter" autopostback="true" runat="server"><i class="fa fa-table"></i></asp:LinkButton>
            </div>
            <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
                <p class="plus">+</p>
                <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentJs" runat="Server">
</asp:Content>

