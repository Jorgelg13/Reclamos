<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmReclamosAutosGeneral.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmReclamosAutosGeneral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading"><b>Listado De Reclamos En General Pendientes De Cerrar</b></div>
            <div class="panel-body">
                <div class="scrolling-table-container">
                    <asp:GridView ID="GridAutosGeneral" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourceReclamosAutosGeneral" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="id,idAutoReclamo,placa" DataNavigateUrlFormatString="/Modulos/MdReclamos/wbFrmReclamosAutosEditar.aspx?ID_reclamo={0}&amp;ultimoAuto={1}&amp;placa={2}" DataTextField="reportante" HeaderText="Reportante">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="reportante" HeaderText="Reportante" SortExpression="reportante" Visible="False">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="placa" HeaderText="Placa" SortExpression="placa">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="asegurado" HeaderText="Asegurado" SortExpression="asegurado">
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
                            <asp:BoundField DataField="ubicacion" HeaderText="Ubicacion" SortExpression="ubicacion">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="poliza" HeaderText="Poliza" SortExpression="poliza">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="aseguradora" HeaderText="Aseguradora" SortExpression="aseguradora">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="tipo_servicio" HeaderText="Tipo Reclamo" SortExpression="tipo_servicio">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nombre" HeaderText="Usuario" SortExpression="nombre">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="idAutoReclamo" HeaderText="idAutoReclamo" SortExpression="idAutoReclamo" InsertVisible="False" ReadOnly="True" Visible="False" />
                            <asp:BoundField DataField="hora_commit" HeaderText="Hora" SortExpression="hora_commit">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False"></HeaderStyle>

                                <ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="fecha_commit" HeaderText="Fecha" SortExpression="fecha_commit" DataFormatString="{0:dd/MM/yyyy}">
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
                    <asp:SqlDataSource ID="SqlDataSourceReclamosAutosGeneral" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT reclamo_auto.id, reclamo_auto.fecha_commit, reclamo_auto.hora_commit, reclamo_auto.tipo_servicio, reclamo_auto.reportante, reclamo_auto.telefono, reclamo_auto.ubicacion, auto_reclamo.id AS idAutoReclamo, auto_reclamo.placa, auto_reclamo.chasis, auto_reclamo.poliza, auto_reclamo.aseguradora, auto_reclamo.contratante,auto_reclamo.asegurado, usuario.nombre FROM auto_reclamo INNER JOIN reclamo_auto ON auto_reclamo.id = reclamo_auto.id_auto_reclamo INNER JOIN usuario ON reclamo_auto.id_usuario = usuario.id WHERE (reclamo_auto.id_estado = 1)"></asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

