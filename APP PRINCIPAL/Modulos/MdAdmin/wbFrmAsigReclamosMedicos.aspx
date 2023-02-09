<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmAsigReclamosMedicos.aspx.cs" Inherits="Modulos_MdAdmin_wbFrmAsigReclamosMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info col-sm-12 col-md-12 col-lg-12">
            <div class="tab-content">
                <div class="panel-body">
                    <div class=" form-inline">
                        <asp:Label ID="lblFechaInicio"  runat="server" Text="Fecha Inicio:   "></asp:Label>
                        <asp:TextBox ID="fechaInicio" CssClass="form-control" Height="34px" type="date" runat="server"></asp:TextBox>
                        <asp:Label ID="lblFechaFinal" runat="server" Text="Fecha Final:   "></asp:Label>
                        <asp:TextBox ID="fechaFinal" CssClass="form-control" Height="34px" type="date" runat="server"></asp:TextBox>
                        <asp:Button runat="server" Text="Buscar" ID="btnBuscar" class="btn btn-primary" />
                        <asp:SqlDataSource ID="SqlDataSourceUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT nombre, usuario FROM [gestores] where tipo ='Medicos' and estado = 1"></asp:SqlDataSource>
                        <asp:Label ID="Label3" class="form-control" runat="server" Text="Asignar Reclamo a:"></asp:Label>
                        <asp:DropDownList CssClass="form-control" ID="DDLusuario" runat="server" DataSourceID="SqlDataSourceUsuarios" DataTextField="nombre" DataValueField="usuario">
                        </asp:DropDownList>
                        <asp:Button ID="bntAsignar" runat="server" Text="Asignar" CssClass="btn btn-primary" OnClick="bntAsignar_Click" />
                    </div>
                    <br />
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridAsigMedicos" CssClass="table bs-table table-responsive table-hover" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="id" DataSourceID="SqlDataSourceReclamosMedicos">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Seleccionar">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="checkAsignar" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                                  <asp:BoundField DataField="nombre_completo" HeaderText="Creado por" SortExpression="nombre_completo">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="usuario_unity" HeaderText="Usuario Asignado" SortExpression="usuario_unity">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="estado_unity" HeaderText="Estado Unity" SortExpression="estado_unity">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="asegurado" HeaderText="Asegurado" SortExpression="asegurado">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="poliza" HeaderText="Poliza" SortExpression="poliza">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tipo_reclamo" HeaderText="Tipo Reclamo" SortExpression="tipo_reclamo">
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
                                <asp:BoundField DataField="telefono" HeaderText="Telefono" SortExpression="telefono">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="correo" HeaderText="Correo" SortExpression="correo">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="hora_commit" HeaderText="Hora Creacion" SortExpression="hora_commit">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fecha_commit" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Creacion" SortExpression="fecha_commit">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#ACD6F2" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSourceReclamosMedicos" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT reclamos_medicos.id, 
                        reclamos_medicos.tipo_reclamo, 
                        usuario.nombre_completo,
                        reclamos_medicos.telefono, 
                        reclamos_medicos.correo,
                        reclamos_medicos.hora_commit, 
                        reclamos_medicos.fecha_commit,
                        reclamos_medicos.usuario_unity,
                        reclamos_medicos.estado_unity,
                        reg_reclamos_medicos.asegurado,
                        reg_reclamos_medicos.poliza, 
                        reg_reclamos_medicos.aseguradora, 
                        reg_reclamos_medicos.contratante
                        FROM reclamos_medicos 
                        INNER JOIN reg_reclamos_medicos ON reclamos_medicos.id_reg_reclamos_medicos = reg_reclamos_medicos.id INNER JOIN usuario ON reclamos_medicos.id_usuario = usuario.id 
                        WHERE  ( Convert(date, fecha_commit, 103)  between @fechainicio and @fechaFin) and (reclamos_medicos.id_estado != 2 and reclamos_medicos.id_estado != 3)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="fechaInicio" Name="fechainicio" PropertyName="Text" />
                                <asp:ControlParameter ControlID="fechaFinal" Name="fechaFin" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

