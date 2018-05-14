<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmReclamosDañosAbiertos.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmReclamosDañosAbiertos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
    <div class ="container-fluid">
          <div class="panel panel-default">
              <div class="panel-heading">Listado De Reclamos Pendientes De Cerrar</div>
              <div class="panel-body">
                 <div class="scrolling-table-container">
                     <asp:GridView ID="GridReclamosAbiertos"  CssClass="table bs-table table-responsive table-hover" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id,id1" DataSourceID="SqlDataSourceReclamosAbiertos" ForeColor="#333333" GridLines="None">
                         <AlternatingRowStyle BackColor="White" />
                         <Columns>
                             <asp:HyperLinkField DataNavigateUrlFields="id1,id,poliza" DataNavigateUrlFormatString="/Modulos/MdReclamos/wbFrmReclamosDañosEditar.aspx?ID_reclamo={0}&amp;ultimoReg={1}&amp;poliza={2}" DataTextField="reportante" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:HyperLinkField>
                             <asp:BoundField DataField="reportante" HeaderText="Reportante" SortExpression="reportante" Visible="False" />
                             <asp:BoundField DataField="poliza" HeaderText="Poliza" SortExpression="poliza" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Center" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="id1" InsertVisible="False" ReadOnly="True" SortExpression="id1" Visible="False" />
                             <asp:BoundField DataField="boleta" HeaderText="Boleta" SortExpression="boleta" >
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
                             <asp:BoundField DataField="telefono" HeaderText="Telefono" SortExpression="telefono" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="ajustador" HeaderText="Ajustador" SortExpression="ajustador" >
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
                 </div>
              </div>
          </div>
        <asp:Label ID="lblusuario" runat="server" Text="Label" Visible="false"  ></asp:Label>
          <asp:SqlDataSource ID="SqlDataSourceReclamosAbiertos" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT reg_reclamo_varios.id, reg_reclamo_varios.poliza, reclamos_varios.id, reclamos_varios.boleta, reclamos_varios.titular, reclamos_varios.ubicacion, reclamos_varios.hora, reclamos_varios.fecha, reclamos_varios.reportante, reclamos_varios.telefono, reclamos_varios.ajustador FROM reclamos_varios INNER JOIN reg_reclamo_varios ON reclamos_varios.id_reg_reclamos_varios = reg_reclamo_varios.id WHERE (reclamos_varios.id_estado  = 1 and reclamos_varios.id_usuario = @idUsuario )">
          </asp:SqlDataSource>
    </div>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>

