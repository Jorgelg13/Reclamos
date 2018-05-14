<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmReclamosDañosGeneral.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmReclamosDañosGeneral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading">Listado De Reclamos En General Pendientes De Cerrar</div>
            <div class="panel-body">
                <div class="scrolling-table-container">
                    <asp:GridView ID="GridGeneral" runat="server" AutoGenerateColumns="False" CssClass="table bs-table table-responsive table-hover" CellPadding="4" DataSourceID="SqlDataSourceReclamosDañosGeneral" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="id,idReg,poliza" DataNavigateUrlFormatString="/Modulos/MdReclamos/wbFrmReclamosDañosEditar.aspx?ID_reclamo={0}&amp;ultimoAuto={1}&amp;poliza={2}" DataTextField="reportante">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="reportante" HeaderText="reportante" SortExpression="reportante" Visible="False" />
                            <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="poliza" HeaderText="Poliza" SortExpression="poliza">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="asegurado" HeaderText="asegurado" SortExpression="asegurado">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="telefono" HeaderText="Telefono" SortExpression="telefono">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ubicacion" HeaderText="Ubicacion" SortExpression="ubicacion">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ajustador" HeaderText="Ajustador" SortExpression="ajustador">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="hora_commit" HeaderText="Hora" SortExpression="hora_commit">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fecha_commit" HeaderText="Fecha" SortExpression="fecha_commit">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="idReg" HeaderText="idReg" InsertVisible="False" ReadOnly="True" SortExpression="idReg" Visible="False" />
                            <asp:BoundField DataField="aseguradora" HeaderText="Aseguradora" SortExpression="aseguradora">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="contratante" HeaderText="Contratante" SortExpression="contratante">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Expr2" HeaderText="Usuario" SortExpression="Expr2">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceReclamosDañosGeneral" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT reclamos_varios.reportante, reclamos_varios.id, reclamos_varios.ubicacion, reclamos_varios.telefono, reclamos_varios.ajustador, reclamos_varios.hora_commit, reclamos_varios.fecha_commit, reg_reclamo_varios.id AS idReg, reg_reclamo_varios.poliza, reg_reclamo_varios.asegurado, reg_reclamo_varios.aseguradora, reg_reclamo_varios.contratante, usuario.nombre AS Expr2 FROM reclamos_varios INNER JOIN reg_reclamo_varios ON reclamos_varios.id_reg_reclamos_varios = reg_reclamo_varios.id INNER JOIN usuario ON reclamos_varios.id_usuario = usuario.id WHERE (reclamos_varios.id_estado = 1)"></asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

