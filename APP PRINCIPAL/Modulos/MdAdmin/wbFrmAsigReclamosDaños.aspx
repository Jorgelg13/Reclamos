<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master"  AutoEventWireup="true" EnableEventValidation="false" CodeFile="wbFrmAsigReclamosDaños.aspx.cs" Inherits="Modulos_MdAdmin_wbFrmAsigReclamosDaños" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info">
            <div class="tab-content">
                <div class="panel-body">
                    <div class=" form-inline">
                        <asp:Label ID="Label1" class="form-control" runat="server" Text="Fecha Inicio:   "></asp:Label>
                        <asp:TextBox ID="fechaInicio" CssClass="form-control" Height="34px" type="date" runat="server"></asp:TextBox>
                        <asp:Label ID="Label2" runat="server" class="form-control" Text="Fecha Final:   "></asp:Label>
                        <asp:TextBox ID="fechaFinal" CssClass="form-control" Height="34px" type="date" runat="server"></asp:TextBox>
                        <asp:Button runat="server" Text="Buscar" ID="btnBuscar" OnClick="btnBuscar_Click" class="btn btn-primary" />
                        <asp:SqlDataSource ID="SqlDataSourceUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [usuario], nombre FROM [gestores] where tipo = 'Daños varios'"></asp:SqlDataSource>
                        <asp:Label ID="Label3" class="form-control" runat="server" Text="Asignar Reclamo a:"></asp:Label>
                        <asp:DropDownList CssClass="form-control" ID="DDLusuario" runat="server" DataSourceID="SqlDataSourceUsuarios" DataTextField="nombre" DataValueField="usuario">
                        </asp:DropDownList>
                         <asp:Button ID="bntAsignar" runat="server" Text="Asignar" CssClass="btn btn-primary" OnClick="bntAsignar_Click" />
                        <asp:LinkButton ID="linkDescargar" OnClick="linkDescargar_Click" title="Descargar en excel" runat="server" Style="font-size: 30px; text-align: center; color:green"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                    </div>
                    <br />
                    <asp:Panel runat="server" ID="PnPrincipal">
                        <div class="scrolling-table-container col-sm-12 col-md-9 col-lg-9">
                            <asp:GridView ID="GridAsigDaños" CssClass="table bs-table table-responsive" runat="server" AutoGenerateColumns="true" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Seleccionar">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="checkAsignar" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" Wrap="false" ForeColor="White" />
                                <PagerStyle BackColor="#ACD6F2" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" Wrap="false" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                        <div class="scrolling-table-container col-sm-12 col-md-3 col-lg-3">
                            <asp:GridView ID="GridAsignados" CssClass="table table-responsive table-hover" runat="server" AutoGenerateColumns="true" GridLines="None">
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#ACD6F2" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" Wrap="false" />
                            </asp:GridView>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

