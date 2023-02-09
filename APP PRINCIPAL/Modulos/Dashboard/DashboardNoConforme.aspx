<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="DashboardNoConforme.aspx.cs" Inherits="Modulos_Dashboard_DashboardNoConforme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel runat="server" ID="principal">
        <div class="Container menu-cuadrado btn-acciones-laterales">
            <div class="col-md-3 col-lg-3" style="height: 300px;">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <p style="text-align: center; font-size: 16px;"><b>Producto No Conforme Autos</b></p>
                    </div>
                    <div class="panel-body">
                        <h1>
                            <asp:LinkButton OnClick="autos_Click" runat="server" ID="autos" title="Total de reclamos de autos no conformes" Style="font-size: 100px;"><i class="fa fa-car"></i></asp:LinkButton>
                            <br />
                            <br />
                            <p style="text-align: center">
                                <asp:Label ID="lblautos" runat="server" aria-hidden="true" ForeColor="#797D7F"></asp:Label>
                            </p>
                        </h1>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-lg-3" style="height: 300px;">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <p style="text-align: center; font-size: 16px;"><b>Producto No Conforme Daños</b></p>
                    </div>
                    <div class="panel-body">
                        <h1>
                             <asp:LinkButton OnClick="danios_Click" runat="server" ID="danios" title="Total de reclamos de daños varios no conformes" Style="font-size: 100px;"><i class="fa fa-exclamation-triangle"></i></asp:LinkButton>
                            <br />
                            <br />
                            <p style="text-align: center">
                                <asp:Label ID="lbldanios" runat="server" aria-hidden="true" ForeColor="#797D7F"></asp:Label>
                            </p>
                        </h1>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-lg-3" style="height: 300px;">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <p style="text-align: center; font-size: 16px;"><b>Producto No Conforme Medicos I.</b></p>
                    </div>
                    <div class="panel-body">
                        <h1>
                            <asp:LinkButton OnClick="individuales_Click" runat="server" ID="individuales" title="Total de reclamos no conformes de gastos medicos Individuales" Style="font-size: 100px;"><i class="fa fa-heartbeat"></i></asp:LinkButton>
                            <br />
                            <br />
                            <p style="text-align: center">
                                <asp:Label ID="lblindividuales" runat="server" aria-hidden="true" ForeColor="#797D7F"></asp:Label>
                            </p>
                        </h1>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-lg-3" style="height: 300px;">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <p style="text-align: center; font-size: 16px;"><b>Producto No Conforme Medicos C.</b></p>
                    </div>
                    <div class="panel-body">
                        <h1>
                            <asp:LinkButton OnClick="colectivos_Click" runat="server" ID="colectivos" title="Total de reclamos no conformes de gastos medicos colectivos" Style="font-size: 100px;"><i class="fa fa-user-md"></i></asp:LinkButton>
                            <br />
                            <br />
                            <p style="text-align: center">
                                <asp:Label ID="lblcolectivos" runat="server" aria-hidden="true" ForeColor="#797D7F"></asp:Label>
                            </p>
                        </h1>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="PanelGrid" Visible="false">
        <div class="container-fluid">
            <div class="panel panel-info">
                <div class="panel-heading">Listado De Reclamos No Conformes</div>
                <div class="panel-body">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridNoConforme" runat="server" CssClass="table bs-table table-responsive table-hover" OnSelectedIndexChanged="GridNoConforme_SelectedIndexChanged" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" AllowCustomPaging="True" AllowPaging="True" PageSize="3000">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
              <asp:LinkButton ID="Regresar" OnClick="Regresar_Click" title="Regresar al dashboard" runat="server" Style="padding-left: 20px; font-size: 70px; text-align: center; color: lightblue"><i class="fa fa-arrow-circle-o-left" aria-hidden="true"></i></asp:LinkButton>
            <asp:LinkButton ID="linkDescargar" OnClick="linkDescargar_Click" title="Descargar en excel" runat="server" Style="font-size: 70px; text-align: center; color: green"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentJs" runat="Server">
</asp:Content>

