<%@ Page Title="Creacion Analistas" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbFrmAnalistas.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmAnalistas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="panel panel-info col-sm-12">
            <!-- Nav tabs -->
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Buscar Analista</a></li>
                <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Ingresar Analista </a></li>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="home">
                    <div class="panel-body">
                        <div class=" form-inline">
                            <asp:TextBox runat="server" autocomplete="off" ID="txtBusqueda" Style="width: 30%" class="form-control" placeholder="Nombre del Analista"></asp:TextBox>
                            <asp:Button runat="server" Text="Buscar" ID="btnBuscar" class="btn btn-primary" />
                        </div>
                        <br />
                        <div class="scrolling-table-container">
                            <asp:GridView ID="GridAnalistas" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" DataKeyNames="id" DataSourceID="SqlDataSourceTalleres">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" ButtonType="Button" />
                                    <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="True" SortExpression="id" InsertVisible="False">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="empresa" HeaderText="Empresa" SortExpression="empresa">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="telefono" HeaderText="Telefono" SortExpression="telefono">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="correo" HeaderText="Correo" SortExpression="correo">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:CheckBoxField DataField="estado" HeaderText="Estado" SortExpression="estado" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSourceTalleres" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="select *from analistas where (nombre like '%' + @nombre + '%' ) or (estado = 'True' or estado ='False')" UpdateCommand=" UPDATE analistas SET nombre = @nombre, empresa=@empresa, telefono= @telefono, correo =@correo, estado =@estado, tipo=@tipo where id = @id">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="txtBusqueda" Name="nombre" PropertyName="Text" DefaultValue=" " />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="nombre" />
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
                    <br />
                    <div class="form-group col-sm-12 col-md-4 col-lg-4">
                        <asp:TextBox runat="server" ID="txtNombre" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                    </div>
                     <div class="form-group col-sm-12 col-md-4 col-lg-4">
                        <asp:TextBox runat="server" ID="txtEmpresa" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Empresa"></asp:TextBox>
                    </div>
                    <div class="form-group col-sm-12 col-md-4 col-lg-4">
                        <asp:TextBox runat="server" ID="txtTelefono" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Telefono"></asp:TextBox>
                    </div>
                    <div class="form-group col-sm-12 col-md-6 col-lg-6">
                        <asp:DropDownList ID="ddlTipo" CssClass="form-control" Style="width: 100%" runat="server">
                            <asp:ListItem>Autos</asp:ListItem>
                            <asp:ListItem>Daños varios</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-sm-12 col-md-6 col-lg-6">
                        <asp:TextBox runat="server" ID="txtCorreo" type="email" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Correo Electronico"></asp:TextBox>
                    </div>
                    <br />
                    <br />
                    <asp:Button runat="server" Text="Guardar" ID="btnguardar" class="btn btn-primary" OnClick="btnguardar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

