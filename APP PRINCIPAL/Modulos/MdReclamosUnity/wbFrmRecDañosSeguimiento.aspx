<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbFrmRecDañosSeguimiento.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmRecDañosSeguimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-default col-sm-12">
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="home">
                    <a href="#home" aria-controls="home" role="tab" data-toggle="tab" style="font-size: 16px;">R. En Seguimiento</a>
                </li>
                <li role="presentation" class="profile">
                    <a href="#profile" aria-controls="profile" role="tab" data-toggle="tab" style="font-size: 16px;">R. Prioritarios</a>
                </li>
                <li role="presentation" class="coberturas">
                    <a href="#coberturas" aria-controls="coberturas" role="tab" data-toggle="tab" style="font-size: 18px;">R. Complicados</a>
                </li>
                <li role="presentation" class="ingreso-datos">
                    <a href="#ingreso-datos" aria-controls="ingreso-datos" role="tab" data-toggle="tab" style="font-size: 18px;">R. por Gestor</a>
                </li>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane" id="home">
                    <br />
                    <div class="form-inline">
                        <asp:DropDownList CssClass="form-control" AutoPostBack="True" ID="DDLTipo" Style="width: 15%" Height="34px" runat="server" CausesValidation="True" DataTextField="descripcion" DataValueField="id" DataSourceID="SqlDataSourceEstados" OnSelectedIndexChanged="DDLTipo_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <br />
                    <%-----------------------------------------------  reclamos en seguimiento-----------------------------------%>
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridReclamosSeguimiento" OnRowDataBound="GridReclamosSeguimiento_RowDataBound" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridReclamosSeguimiento_SelectedIndexChanged">
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

                        <%-----------------------------------------------  reclamos en seguimiento por estado -----------------------------------%>
                        <asp:GridView ID="GridReclamosEstado" OnRowDataBound="GridReclamosSeguimiento_RowDataBound" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridReclamosEstado_SelectedIndexChanged">
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

                <%-----------------------------------------------  reclamos Prioritarios  -----------------------------------%>
                <div role="tabpanel" class="tab-pane" id="profile">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridPrioritarios" OnRowDataBound="GridReclamosSeguimiento_RowDataBound" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridPrioritarios_SelectedIndexChanged">
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

                <%-----------------------------------------------  reclamos complicados -----------------------------------%>
                <div role="tabpanel" class="tab-pane" id="coberturas">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridComplicados" OnRowDataBound="GridReclamosSeguimiento_RowDataBound" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridComplicados_SelectedIndexChanged">
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
                <%-----------------------------------------------  reclamos en General-----------------------------------%>
                <div role="tabpanel" class="tab-pane" id="ingreso-datos">
                    <br />
                    <div class="form-inline">
                        <asp:DropDownList CssClass="form-control" AutoPostBack="True" ID="ddlgestor" Style="width: 15%" Height="34px" runat="server" CausesValidation="True" DataSourceID="SqlDataSourceGestores" DataTextField="nombre" DataValueField="id" OnSelectedIndexChanged="ddlgestor_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <br />
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridReclamosGeneral" OnRowDataBound="GridReclamosSeguimiento_RowDataBound" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridReclamosGeneral_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:CommandField>
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
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
        <asp:SqlDataSource ID="SqlDataSourceGestores" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [id], [nombre] FROM [gestores] where tipo = 'daños varios'"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceEstados" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [id], [descripcion] FROM [estados_reclamos_unity] where tipo = 'daños'"></asp:SqlDataSource>
    </div>
</asp:Content>

