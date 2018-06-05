<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmAsigReclamosDaños.aspx.cs" Inherits="Modulos_MdAdmin_wbFrmAsigReclamosDaños" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info col-sm-12">
            <div class="tab-content">
                <div class="panel-body">
                    <div class=" form-inline">
                        <asp:Label ID="Label1" class="form-control" runat="server" Text="Fecha Inicio:   "></asp:Label>
                        <asp:TextBox ID="fechaInicio" CssClass="form-control" Height="34px" type="date" runat="server"></asp:TextBox>
                        <asp:Label ID="Label2" runat="server" class="form-control" Text="Fecha Final:   "></asp:Label>
                        <asp:TextBox ID="fechaFinal" CssClass="form-control" Height="34px" type="date" runat="server"></asp:TextBox>
                        <asp:Button runat="server" Text="Buscar" ID="btnBuscar" class="btn btn-primary" />
                        <asp:SqlDataSource ID="SqlDataSourceUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [usuario], nombre FROM [gestores] where tipo = 'Daños varios'"></asp:SqlDataSource>
                        <asp:Label ID="Label3" class="form-control" runat="server" Text="Asignar Reclamo a:"></asp:Label>
                        <asp:DropDownList CssClass="form-control" ID="DDLusuario" runat="server" DataSourceID="SqlDataSourceUsuarios" DataTextField="nombre" DataValueField="usuario">
                        </asp:DropDownList>
                    </div>
                    <br />
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridAsigDaños" CssClass="table bs-table table-responsive table-hover" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceDaños" GridLines="None" DataKeyNames="id" OnSelectedIndexChanged="GridAsigDaños_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField SelectText="Asignar" ShowSelectButton="True" />
                                 <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="usuario_unity" HeaderText="Usuario Unity" SortExpression="usuario_unity">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="estado_unity" HeaderText="Estado Unity" SortExpression="estado_unity">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="asegurado" HeaderText="Asegurado" SortExpression="asegurado">
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="poliza" HeaderText="Poliza" SortExpression="poliza">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cliente " HeaderText="Cliente " SortExpression="cliente ">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="direccion" HeaderText="Direccion" SortExpression="direccion">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ramo" HeaderText="Ramo" SortExpression="ramo">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ejecutivo" HeaderText="Ejecutivo" SortExpression="ejecutivo">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="aseguradora" HeaderText="Aseguradora" SortExpression="aseguradora">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="contratante" HeaderText="Contratante" SortExpression="contratante">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="estado_poliza" HeaderText="Estado Poliza" SortExpression="estado_poliza">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="boleta" HeaderText="Boleta" SortExpression="boleta">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="titular" HeaderText="Titular" SortExpression="titular">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ubicacion" HeaderText="Ubicacion" SortExpression="ubicacion">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="hora" HeaderText="Hora" SortExpression="hora">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fecha" HeaderText="Fecha Siniestro" SortExpression="fecha">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="reportante" HeaderText="Reportante" SortExpression="reportante">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="telefono" HeaderText="Telefono" SortExpression="telefono">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ajustador" HeaderText="Ajustador" SortExpression="ajustador">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="version" HeaderText="Version" SortExpression="version">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fecha_commit" HeaderText="Fecha Commit" SortExpression="fecha_commit">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="usuario" HeaderText="Usuario" SortExpression="nombre1">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#ACD6F2" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSourceDaños" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT
                                    dbo.reclamos_varios.id,
                                    dbo.reg_reclamo_varios.poliza,
                                    dbo.reg_reclamo_varios.asegurado,
                                    dbo.reg_reclamo_varios.[cliente ],
                                    dbo.reg_reclamo_varios.status,
                                    dbo.reg_reclamo_varios.tipo,
                                    dbo.reg_reclamo_varios.direccion,
                                    dbo.reg_reclamo_varios.ramo,
                                    dbo.reg_reclamo_varios.ejecutivo,
                                    dbo.reg_reclamo_varios.aseguradora,
                                    dbo.reg_reclamo_varios.contratante,
                                    dbo.reg_reclamo_varios.estado_poliza,
                                    dbo.reclamos_varios.usuario_unity,
                                    dbo.reclamos_varios.estado_unity,
                                    dbo.reclamos_varios.boleta,
                                    dbo.reclamos_varios.titular,
                                    dbo.reclamos_varios.ubicacion,
                                    dbo.reclamos_varios.hora,
                                    dbo.reclamos_varios.fecha,
                                    dbo.reclamos_varios.reportante,
                                    dbo.reclamos_varios.telefono,
                                    dbo.reclamos_varios.ajustador,
                                    dbo.reclamos_varios.version,
                                    dbo.reclamos_varios.fecha_commit,
                                    dbo.reclamos_varios.fecha_cierre,
                                    dbo.cabina.nombre as cabina,
                                    dbo.sucursal.nombre as sucursal,
                                    dbo.empresa.nombre as empresa,
                                    dbo.pais.nombre as pais,
                                    dbo.usuario.nombre as usuario
                                    FROM
                                    dbo.reclamos_varios
                                    INNER JOIN dbo.reg_reclamo_varios ON dbo.reclamos_varios.id_reg_reclamos_varios = dbo.reg_reclamo_varios.id
                                    INNER JOIN dbo.cabina ON dbo.reclamos_varios.id_cabina = dbo.cabina.id
                                    INNER JOIN dbo.sucursal ON dbo.cabina.id_sucursal = dbo.sucursal.id
                                    INNER JOIN dbo.empresa ON dbo.sucursal.id_empresa = dbo.empresa.id
                                    INNER JOIN dbo.pais ON dbo.empresa.id_pais = dbo.pais.id
                                    INNER JOIN dbo.usuario ON dbo.reclamos_varios.id_usuario = dbo.usuario.id
                                    where (fecha_cierre between @fechaInicio and @fechaFinal) and (reclamos_varios.id_estado =2)"
                            UpdateCommand=" UPDATE reclamos_varios SET usuario_unity= @usuario_unity where id = @id">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="fechaInicio" Name="fechaInicio" PropertyName="Text" />
                                <asp:ControlParameter ControlID="fechaFinal" Name="fechaFinal" PropertyName="Text" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="usuario_unity" />
                                <asp:Parameter Name="id" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>

