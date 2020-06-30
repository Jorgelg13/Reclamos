<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbFrmRecMedSeguimiento.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmRecMedSeguimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div>
            <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="LblUsuario" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:Label ID="lblPlaca" runat="server" Text="Label" Visible="false"></asp:Label>
        </div>
        <div class="panel panel-default col-sm-12">
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="home">
                    <a href="#home" aria-controls="home" role="tab" data-toggle="tab" style="font-size: 16px;">R. En Seguimiento</a>
                </li>
                <li role="presentation" class="profile">
                    <a href="#profile" aria-controls="profile" role="tab" data-toggle="tab" style="font-size: 16px;">R. Pendientes de cierre</a>
                </li>
                <li role="presentation" class="coberturas">
                    <a href="#coberturas" aria-controls="coberturas" role="tab" data-toggle="tab" style="font-size: 16px;">R. Por Gestor</a>
                </li>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane" id="home">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridReclamosSeguimiento" OnRowDataBound="GridReclamosSeguimiento_RowDataBound" 
                            runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True" CellPadding="4" 
                            ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridReclamosSeguimiento_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>

                <%-----------------------------------------------  reclamos Pendientes de ser cerrados  -----------------------------------%>
                <div role="tabpanel" class="tab-pane" id="profile">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridPendientes" runat="server" CssClass="table bs-table table-responsive table-hover" 
                            AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridPendientes_SelectedIndexChanged"
                            OnRowDataBound="GridReclamosSeguimiento_RowDataBound"
                            >
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>

                <%-----------------------------------------------  reclamos por gestor -----------------------------------%>
                <div role="tabpanel" class="tab-pane" id="coberturas">
                    <div class="form-inline">
                        <br />
                        <asp:DropDownList ID="ddlGestor" Style="height: 34px; width: 200px;" CssClass="form-control" runat="server" 
                            DataSourceID="SqlDataSourceGestores" DataTextField="usuario" DataValueField="id"></asp:DropDownList>
                        <asp:Button ID="btnBuscar" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                    </div>
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridReclamosPorGestor" runat="server" CssClass="table bs-table table-responsive table-hover" 
                            OnRowDataBound="GridReclamosSeguimiento_RowDataBound" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" 
                            GridLines="None" OnSelectedIndexChanged="GridReclamosPorGestor_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSourceGestores" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="select id, usuario  from gestores where tipo = 'Medicos'"></asp:SqlDataSource>
</asp:Content>

