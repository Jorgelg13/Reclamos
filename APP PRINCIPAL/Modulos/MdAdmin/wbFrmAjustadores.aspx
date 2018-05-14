<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmAjustadores.aspx.cs" Inherits="Modulos_MdAdmin_wbFrmAjustadores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class="container">
        <div class="panel panel-default col-sm-12">
            <!-- Nav tabs -->
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Buscar Ajustador</a></li>
                <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Ingresar Ajustador</a></li>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="home">
                    <div class="panel-body">
                        <div class=" form-inline">
                            <asp:TextBox runat="server" autocomplete="off" ID="txtBusqueda" Style="width: 30%" class="form-control" placeholder="Nombre del ajustador"></asp:TextBox>
                            <asp:Button runat="server" Text="Buscar" ID="btnBuscar" class="btn btn-primary" />
                        </div>
                        <br />
                        <div class="scrolling-table-container">
                            <asp:GridView ID="GridAjustadores" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSourceAjustadores">
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
                                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="correo" HeaderText="Correo" SortExpression="correo">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado">
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:CommandField ShowEditButton="True" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>

                            <asp:SqlDataSource ID="SqlDataSourceAjustadores" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="select *from ajustadores where (nombre like '%'+ @nombre +'%') or (aseguradora like '%' + @aseguradora + '%')" UpdateCommand=" UPDATE ajustadores SET nombre = @nombre, aseguradora= @aseguradora, telefono= @telefono, correo =@correo, estado =@estado where id = @id">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtBusqueda" Name="nombre" PropertyName="Text" />
                                    <asp:ControlParameter ControlID="txtBusqueda" Name="aseguradora" PropertyName="Text" />
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
                <%--segundo tab--%>
                <div role="tabpanel" class="tab-pane" id="profile">
                    <div class="panel-body form-inline">
                        <br />
                        <asp:TextBox runat="server" ID="txtNombre" Style="width: 30%" autocomplete="off" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtAseguradora" Style="width: 30%" autocomplete="off" class="form-control" placeholder="Aseguradora"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtTelefono" Style="width: 35%" autocomplete="off" class="form-control" placeholder="Telefono"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox runat="server" ID="txtTipo" Style="width: 25%" autocomplete="off" class="form-control" placeholder="Tipo Ajustador"></asp:TextBox>
                        <asp:TextBox runat="server" type="email" ID="txtCorreo" Style="width: 40%" Height="34px" class="form-control" placeholder="Correo"></asp:TextBox>
                        <asp:DropDownList CssClass="form-control" ID="DDLTipo" Style="width: 30%" Height="34px" runat="server">
                            <asp:ListItem>Activo</asp:ListItem>
                            <asp:ListItem>Inactivo</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:Button runat="server" Text="Guardar Ajustador" ID="btnguardar" class="btn btn-primary" OnClick="btnguardar_Click" />
                        <br />
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

