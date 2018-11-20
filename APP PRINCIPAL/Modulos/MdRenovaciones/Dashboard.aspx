<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Renovaciones.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Modulos_MdRenovaciones_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Nav tabs -->
    <ul class="nav nav-tabs" role="tablist">
        <li role="presentation" class="active">
            <a href="#elRoble" aria-controls="elRoble" role="tab" data-toggle="tab">Polizas Roble
            </a>
        </li>
        <li role="presentation">
            <a href="#todasPolizas" aria-controls="todasPolizas" role="tab" data-toggle="tab">Todas las Polizas
            </a>
        </li>
    </ul>

    <!-- Tab panes -->
    <div class="tab-content">
        <div role="tabpanel" class="tab-pane active" id="elRoble">
            <div class="row">
                <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 0px;">
                    <asp:GridView ID="GridElRoble" OnSelectedIndexChanged="GridElRoble_SelectedIndexChanged" CssClass="table bs-table table-responsive table-hover" runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
                        </Columns>
                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" Wrap="false" />
                        <PagerStyle BackColor="#131B4D" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" Wrap="false" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div role="tabpanel" class="tab-pane" id="todasPolizas">
            <div class="row">
                  <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 0px;">
                    <asp:GridView ID="GridAllPolizas" OnSelectedIndexChanged="GridAllPolizas_SelectedIndexChanged" CssClass="table bs-table table-responsive table-hover" runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
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
</asp:Content>

