<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmConsultarAjustadores.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmConsultarAjustadores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
    <div class="container">
        <div class="panel panel-default col-sm-12">
            <div class="tab-content">
                <div class=" form-inline">
                    <br />
                    <asp:TextBox runat="server" autocomplete="off" ID="txtBusqueda" Style="width: 30%" class="form-control" placeholder="Nombre del ajustador o Aseguradora"></asp:TextBox>
                    <asp:Button runat="server" Text="Buscar" ID="btnBuscar" class="btn btn-primary" />
                </div>
                <br />
                <div class="scrolling-table-container">
                    <asp:GridView ID="GridConsultasAjustadores" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSourceAjustadores">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="aseguradora" HeaderText="Aseguradora" SortExpression="aseguradora">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="telefono" HeaderText="Telefono" SortExpression="telefono">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceAjustadores" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="select *from ajustadores where (nombre like '%'+ @nombre +'%') or (aseguradora like '%' + @aseguradora + '%') or (tipo like '%' + @tipo + '%' )" UpdateCommand=" UPDATE ajustadores SET nombre = @nombre, aseguradora= @aseguradora, telefono= @telefono, correo =@correo, estado =@estado where id = @id">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtBusqueda" Name="nombre" PropertyName="Text" />
                            <asp:ControlParameter ControlID="txtBusqueda" Name="aseguradora" PropertyName="Text" />
                            <asp:ControlParameter ControlID="txtBusqueda" Name="tipo" PropertyName="Text" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="nombre" />
                            <asp:Parameter Name="aseguradora" />
                            <asp:Parameter Name="telefono" />
                            <asp:Parameter Name="correo" />
                            <asp:Parameter Name="estado" />
                            <asp:Parameter Name="id" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>

