<%@ Page Title="Asignacion R. Autos" Language="C#" ValidateRequest="false" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmAsignacionUnity.aspx.cs" Inherits="Modulos_MdAdmin_wbFrmAsignacionUnity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
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
                        <asp:SqlDataSource ID="SqlDataSourceUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [id], [usuario] FROM [gestores] where tipo = 'autos'"></asp:SqlDataSource>
                        <asp:Label ID="Label3" class="form-control" runat="server" Text="Asignar Reclamo a:"></asp:Label>
                        <asp:DropDownList CssClass="form-control" ID="DDLusuario" runat="server" DataSourceID="SqlDataSourceUsuarios" DataTextField="usuario" DataValueField="id">
                        </asp:DropDownList>
                        <asp:Button ID="bntAsignar" runat="server" Text="Asignar" CssClass="btn btn-primary" OnClick="bntAsignar_Click"/>
                    </div>
                    <br />
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridAsignacionAutos" CssClass="table bs-table table-responsive table-hover" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourceAutos" ForeColor="#333333" GridLines="None" DataKeyNames="id">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                  <asp:TemplateField HeaderText="Seleccionar">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="checkAsignar" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:BoundField DataField="usuario_unity" HeaderText="Usuario Unity" SortExpression="usuario_unity">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="estado_unity" HeaderText="Estado Unity" SortExpression="estado_unity">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tipo_servicio" HeaderText="Tipo Servicio" SortExpression="tipo_servicio">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="poliza" HeaderText="Poliza" SortExpression="poliza">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="asegurado" HeaderText="Asegurado" SortExpression="asegurado">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="placa" HeaderText="Placa" SortExpression="placa">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="marca" HeaderText="Marca" SortExpression="marca">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="color" HeaderText="Color" SortExpression="color">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="modelo" HeaderText="Modelo" SortExpression="modelo">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="chasis" HeaderText="Chasis" SortExpression="chasis">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="motor" HeaderText="Motor" SortExpression="motor">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="propietario" HeaderText="Propietario" SortExpression="propietario">
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
                                <asp:BoundField DataField="hora" HeaderText="Hora" SortExpression="hora">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fecha" HeaderText="Fecha Percanse" SortExpression="fecha" DataFormatString="{0:dd/MM/yyyy}">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fecha_commit" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Commit" SortExpression="fecha_commit">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ubicacion" HeaderText="Ubicacion" SortExpression="ubicacion">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="reportante" HeaderText="Reportante" SortExpression="reportante">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="piloto" HeaderText="Piloto" SortExpression="piloto">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="edad" HeaderText="Edad" SortExpression="edad">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="version" HeaderText="version" SortExpression="version">
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
                                <asp:BoundField DataField="cabina" HeaderText="Cabina" SortExpression="cabina">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sucursal" HeaderText="Sucursal" SortExpression="sucursal">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="empresa" HeaderText="Empresa" SortExpression="empresa">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="pais" HeaderText="Pais" SortExpression="pais">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="usuario" HeaderText="Usuario" SortExpression="usuario">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" InsertVisible="False" ReadOnly="True">
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
                        <asp:SqlDataSource ID="SqlDataSourceAutos" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT
                                reclamo_auto.id,
                                reclamo_auto.usuario_unity,
                                reclamo_auto.estado_unity,
                                auto_reclamo.poliza,
                                auto_reclamo.placa,
                                auto_reclamo.marca,
                                auto_reclamo.color,
                                auto_reclamo.modelo,
                                auto_reclamo.chasis,
                                auto_reclamo.motor,
                                auto_reclamo.propietario,
                                auto_reclamo.ejecutivo,
                                auto_reclamo.aseguradora,
                                auto_reclamo.contratante,
                                auto_reclamo.estado_poliza,
                                auto_reclamo.asegurado,
                                reclamo_auto.boleta,
                                reclamo_auto.titular,
                                reclamo_auto.hora,
                                reclamo_auto.fecha,
                                reclamo_auto.fecha_commit,
                                reclamo_auto.fecha_cierre,
                                reclamo_auto.ubicacion,
                                reclamo_auto.reportante,
                                reclamo_auto.piloto,
                                reclamo_auto.edad,
                                reclamo_auto.telefono,
                                reclamo_auto.ajustador,
                                reclamo_auto.tipo_servicio,
                                reclamo_auto.usuario_unity,
                                reclamo_auto.version,
                                cabina.nombre as cabina,
                                sucursal.nombre as sucursal,
                                empresa.nombre as empresa,
                                pais.nombre as pais,
                                usuario.nombre as usuario

                                FROM
                                auto_reclamo
                                INNER JOIN reclamo_auto ON reclamo_auto.id_auto_reclamo = auto_reclamo.id
                                INNER JOIN cabina ON reclamo_auto.id_cabina = cabina.id
                                INNER JOIN sucursal ON cabina.id_sucursal = sucursal.id
                                INNER JOIN empresa ON sucursal.id_empresa = empresa.id
                                INNER JOIN pais ON empresa.id_pais = pais.id
                                INNER JOIN usuario ON reclamo_auto.id_usuario = usuario.id
                                where (fecha_cierre between @fechaInicio and @fechaFin) and (reclamo_auto.id_estado = 2) and 
                                (tipo_servicio != 'Asistencia Vehicular')
                                "
                            UpdateCommand=" UPDATE reclamo_auto SET usuario_unity= @usuario_unity where id = @id">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="fechaInicio" Name="fechaInicio" PropertyName="Text" />
                                <asp:ControlParameter ControlID="fechaFinal" Name="fechaFin" PropertyName="Text" />
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
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

