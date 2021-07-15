<%@ Page Title="Pronico" Language="C#" MasterPageFile="~/Consultas/pronico/CajaAhorro.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Dashboard.aspx.cs" Inherits="Consultas_Caja_de_ahorro_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel runat="server" ID="PanelPrincipal" Visible="true">
        <div class="container menu-cuadrado btn-acciones-laterales">
           <%-- <div class="col-md-2 col-lg-3" style="height: 190px;">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <p style="text-align: center; font-size: 12px; "><b>Autos y Coberturas</b></p>
                    </div>
                    <div class="panel-body">
                        <h1>
                            <a href="/Consultas/Caja-de-ahorro/ConsultarAutos.aspx" title="Consultar autos y coberturas" style="font-size: 60px;" class="fa fa-car"></a>
                            <br />
                            <br />
                        </h1>
                    </div>
                </div>
            </div>--%>
            <div class="col-md-6 col-lg-6" style="height: 190px;">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <p style="text-align: center; font-size: 12px;"><b>Consultar Asegurados</b></p>
                    </div>
                    <div class="panel-body">
                        <h1>
                            <a href="/Consultas/pronico/consultar-asegurados.aspx" title="Consultar Asegurados" style="font-size: 60px;" class="fa fa-users"></a>
                            <br />
                            <br />
                        </h1>
                    </div>
                </div>
            </div>
            <div class="col-md-6 col-lg-6" style="height: 190px;">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <p style="text-align: center; font-size: 12px;"><b>Consultar Reclamos</b></p>
                    </div>
                    <div class="panel-body">
                        <h1>
                            <asp:LinkButton runat="server" title="Consultar Reclamos de autos y gastos medicos" Style="font-size: 60px;" ID="ConsultarReclamos" OnClick="ConsultarReclamos_Click"><i class="fa fa-file-text-o"></i></asp:LinkButton>
                            <br />
                            <br />
                        </h1>
                    </div>
                </div>
            </div>
           <%--   <div class="col-md-4 col-lg-4" style="height: 190px;">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <p style="text-align: center; font-size: 12px;"><b>Sistema Control de Beneficios</b></p>
                    </div>
                    <div class="panel-body">
                        <h1>
                            <asp:LinkButton runat="server" title="sistema control de beneficios" Style="font-size: 60px;" ID="scb" OnClick="scb_Click"><img src="../../imgUnity/scb.png" style="height:110px; padding-top:0px"/></asp:LinkButton>
                            <br />
                        </h1>
                    </div>
                </div>
            </div>--%>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="PanelReclamos" Visible="false">
        <div class="container menu-cuadrado btn-acciones-laterales">
           <%-- <div class="col-md-6 col-lg-6" style="height: 200px;">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <p style="text-align: center; font-size: 14px;"><b>Reclamos de autos</b></p>
                    </div>
                    <div class="panel-body">
                        <h1>
                            <asp:LinkButton runat="server" title="Total reclamos de autos pendientes de cierre" Style="font-size: 70px;" ID="TotalReclamosAutos" OnClick="TotalReclamosAutos_Click"><i class="fa fa-car"></i></asp:LinkButton> 
                            <asp:LinkButton runat="server" Style="font-size: 60px; color:#565863" ID="TotalAutos" OnClick="TotalReclamosAutos_Click"></asp:LinkButton>
                            <br />
                            <br />
                        </h1>
                    </div>
                </div>
            </div>--%>
            <div class="col-md-6 col-lg-6" style="height: 200px;">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <p style="text-align: center; font-size: 14px;"><b>Reclamos de gastos medicos</b></p>
                    </div>
                    <div class="panel-body">
                        <h1>
                            <asp:LinkButton runat="server" OnClick="TotalReclamosMedicos_Click" title="Total de Reclamos de gastos medicos pendientes de cierre" Style="font-size: 70px;" ID="TotalReclamosMedicos"><i class="fa fa-user-md"></i></asp:LinkButton> 
                             <asp:LinkButton runat="server" Style="font-size: 60px; color:#565863" OnClick="TotalReclamosMedicos_Click" ID="TotalRM"></asp:LinkButton>
                            <br />
                            <br />
                        </h1>
                    </div>
                </div>
            </div>
            <%-- <div class="col-md-6 col-lg-6" style="height: 200px;">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <p style="text-align: center; font-size: 14px;"><b>Reportes Reclamos Autos</b></p>
                    </div>
                    <div class="panel-body">
                        <h1>
                            <asp:LinkButton runat="server" title="Reportes de reclamos de autos" OnClick="ReportesAutos_Click"
                                Style="font-size: 70px; color:green" ID="ReportesAutos"><i class="fa fa-file-excel-o"></i></asp:LinkButton> 
                            <br />
                            <br />
                        </h1>
                    </div>
                </div>
            </div>--%>
             <div class="col-md-6 col-lg-6" style="height: 200px;">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <p style="text-align: center; font-size: 14px;"><b>Reportes Reclamos Gastos Medicos</b></p>
                    </div>
                    <div class="panel-body">
                        <h1>
                            <asp:LinkButton runat="server" title="Reportes de reclamos de gastos medicos" OnClick="ReportesMedicos_Click"
                                Style="font-size: 70px; color:green" ID="ReportesMedicos"><i class="fa fa-file-excel-o" ></i></asp:LinkButton> 
                            <br />
                            <br />
                        </h1>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="PanelReclamosAutos" Visible="false">
        <div class="container-fluid">
            <div class="panel panel-info">
                <div class="panel-heading">Reclamos En General Pendientes De Cerrar</div>
                <div class="panel-body" style="padding:0px;">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridGeneral" runat="server" CssClass="table bs-table table-responsive" OnSelectedIndexChanged="GridGeneral_SelectedIndexChanged" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None" AllowCustomPaging="True" PageSize="3000">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <asp:LinkButton ID="linkDescargar" OnClick="linkDescargar_Click" title="Descargar en excel" runat="server" Style="font-size: 70px; text-align: center; color: green"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="PanelReclamosMedicos" Visible="false">
        <div class="container-fluid">
            <div class="panel panel-info">
                <div class="panel-heading">Reclamos En General Pendientes De Cerrar.</div>
                <div class="panel-body" style="padding:0px;">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridMedicos" runat="server" CssClass="table table-responsive" OnSelectedIndexChanged="GridMedicos_SelectedIndexChanged" AutoGenerateColumns="True" GridLines="None" PageSize="3000">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <asp:LinkButton ID="lnDescargarGastosMedicos" OnClick="lnDescargarGastosMedicos_Click" title="Descargar en excel" runat="server" Style="font-size: 70px; text-align: center; color: green"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="Server">
    <style>
        body {
    /* el tamaño por defecto es 14px */
    font-size: 12px;
}
        p{
            margin: -4px 0 -3px;
        }
    </style>
</asp:Content>

