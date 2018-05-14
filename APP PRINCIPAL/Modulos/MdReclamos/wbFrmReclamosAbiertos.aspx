<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmReclamosAbiertos.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmReclamosAbiertos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container-fluid">
          <div class="panel panel-info">
              <div class="panel-heading">Listado De Reclamos Pendientes De Cerrar</div>
              <div class="panel-body">
                 <div class="scrolling-table-container">
                     <asp:GridView ID="GridReclamosAbiertos" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id,idAuto" DataSourceID="SqlDataSourceReclamosAbiertos" ForeColor="#333333" GridLines="None">
                         <AlternatingRowStyle BackColor="White" />
                         <Columns>
                             <asp:HyperLinkField DataNavigateUrlFields="id,idAuto,placa" DataNavigateUrlFormatString="/Modulos/MdReclamos/wbFrmReclamosAutosEditar.aspx?ID_reclamo={0}&amp;ultimoAuto={1}&amp;placa={2}" DataTextField="reportante" HeaderText="Reclamos Pendientes" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:HyperLinkField>
                             <asp:BoundField DataField="id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="False" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Center" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="placa" HeaderText="Placa" SortExpression="placa" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="boleta" HeaderText="Boleta" SortExpression="boleta" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="piloto" HeaderText="Piloto" SortExpression="piloto" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="titular" HeaderText="Titular" SortExpression="titular" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="ubicacion" HeaderText="Ubicacion" SortExpression="ubicacion" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="hora" HeaderText="Hora" SortExpression="hora" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="reportante" HeaderText="Reportante" SortExpression="reportante" Visible="False" />
                             <asp:BoundField DataField="telefono" HeaderText="Telefono" SortExpression="telefono" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="ajustador" HeaderText="Ajustador" SortExpression="ajustador" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="id_auto_reclamo" HeaderText="id_auto_reclamo" SortExpression="id_auto_reclamo" Visible="False" />
                             <asp:BoundField DataField="idAuto" HeaderText="idAuto" InsertVisible="False" ReadOnly="True" SortExpression="idAuto" Visible="False" />
                         </Columns>
                         <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                         <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                         <RowStyle BackColor="#EFF3FB" />
                         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                     </asp:GridView>
                 </div>
              </div>
          </div>
        <asp:Label ID="lblusuario" runat="server" Text="Label" Visible="false"  ></asp:Label>
        <asp:SqlDataSource ID="SqlDataSourceReclamosAbiertos" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT reclamo_auto.id, reclamo_auto.boleta, reclamo_auto.titular, reclamo_auto.ubicacion, reclamo_auto.hora, reclamo_auto.fecha, reclamo_auto.reportante, reclamo_auto.piloto, reclamo_auto.telefono, reclamo_auto.ajustador, reclamo_auto.id_auto_reclamo, auto_reclamo.placa, auto_reclamo.id AS idAuto FROM reclamo_auto INNER JOIN auto_reclamo ON reclamo_auto.id_auto_reclamo = auto_reclamo.id WHERE (reclamo_auto.id_estado = 1 and reclamo_auto.id_usuario = @idUsuario)">
        </asp:SqlDataSource>
    </div>
</asp:Content>

