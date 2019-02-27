<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmReclamosMedicosGeneral.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmReclamosMedicosGeneral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class="col-md-1">
    </div>
    <div class="col-md-10">
        <div class="panel panel-default">
            <div class="panel-heading">Listado De Reclamos En General Pendientes De Cerrar</div>
            <div class="panel-body">
                <div class="scrolling-table-container">
                    <asp:GridView ID="GridReclamosMedicos" runat="server" CssClass="table bs-table table-responsive table-hover" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataSourceID="SqlDataSourceReclamosMedicosGeneral">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="/Modulos/MdReclamos/wbFrmReclamosMedicosEditar.aspx?ID_reclamo={0}" DataTextField="titular">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="asegurado" HeaderText="Asegurado" SortExpression="asegurado">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="poliza" HeaderText="Poliza" SortExpression="poliza">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="tipo_reclamo" HeaderText="Tipo Reclamo" SortExpression="tipo_reclamo"></asp:BoundField>
                            <asp:BoundField DataField="telefono" HeaderText="Telefono" SortExpression="telefono">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="correo" HeaderText="Correo" SortExpression="correo">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="hora_commit" HeaderText="Hora" SortExpression="hora_commit">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fecha_commit" HeaderText="Fecha" SortExpression="fecha_commit" DataFormatString="{0:dd/MM/yyyy}">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="aseguradora" HeaderText="Aseguradora" SortExpression="aseguradora">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="contratante" HeaderText="Contratante" SortExpression="contratante">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nombre" HeaderText="Usuario" SortExpression="nombre">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceReclamosMedicosGeneral" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT reclamos_medicos.id, 
                        reclamos_medicos.tipo_reclamo, 
                        reclamos_medicos.telefono, 
                        reclamos_medicos.correo,
                        reclamos_medicos.hora_commit, 
                        reclamos_medicos.fecha_commit, 
                        reg_reclamos_medicos.asegurado,
                        reclamos_medicos.titular,
                        reg_reclamos_medicos.poliza, 
                        reg_reclamos_medicos.aseguradora, 
                        reg_reclamos_medicos.contratante, 
                        usuario.nombre FROM reclamos_medicos 
                        INNER JOIN reg_reclamos_medicos ON reclamos_medicos.id_reg_reclamos_medicos = reg_reclamos_medicos.id INNER JOIN usuario ON reclamos_medicos.id_usuario = usuario.id 
                        WHERE reclamos_medicos.id_estado = 1 "></asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-1">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

