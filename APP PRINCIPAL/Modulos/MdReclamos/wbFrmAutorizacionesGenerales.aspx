<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmAutorizacionesGenerales.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmAutorizacionesGenerales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
     <div class ="container-fluid">
          <div class="panel panel-info">
              <div class="panel-heading"><b>Listado De Autorizaciones Pendientes De Cerrar</b></div>
              <div class="panel-body">
                 <div class="scrolling-table-container">
                     <asp:GridView ID="GridAutorizacionesGenerales" runat="server"  CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSourceAutorizacionesGenerales" ForeColor="#333333" GridLines="None">
                         <AlternatingRowStyle BackColor="White" />
                         <Columns>
                             <asp:HyperLinkField DataNavigateUrlFields="id,id_reg_reclamos_medicos,poliza" DataNavigateUrlFormatString="/Modulos/MdReclamos/wbFrmAutorizacionesEditar.aspx?ID_reclamo={0}&amp;ultimoAuto={1}&amp;poliza={2}" DataTextField="reportante" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:HyperLinkField>
                             <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Center" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="reportante" HeaderText="Reportante" SortExpression="reportante" Visible="False" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="poliza" HeaderText="Poliza" SortExpression="poliza" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="asegurado" HeaderText="Asegurado" SortExpression="asegurado" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="tipo_consulta" HeaderText="Tipo Consulta" SortExpression="tipo_consulta" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="tipo_estado" HeaderText="Tipo Estado" SortExpression="tipo_estado" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="correo" HeaderText="Correo" SortExpression="correo" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="clase" HeaderText="Clase" SortExpression="clase" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Center" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="hora_commit" HeaderText="Hora" SortExpression="hora_commit" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Center" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="fecha_commit" HeaderText="Fecha" SortExpression="fecha_commit" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Center" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="id_reg_reclamos_medicos" HeaderText="id_reg_reclamos_medicos" SortExpression="id_reg_reclamos_medicos" Visible="False" />
                             <asp:BoundField DataField="aseguradora" HeaderText="Aseguradora" SortExpression="aseguradora" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="contratante" HeaderText="Contratante" SortExpression="contratante" >
                             <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                             <ItemStyle HorizontalAlign="Left" Wrap="False" />
                             </asp:BoundField>
                             <asp:BoundField DataField="nombre" HeaderText="Usuario" SortExpression="nombre" >
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
                     <asp:SqlDataSource ID="SqlDataSourceAutorizacionesGenerales" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT autorizaciones.id, autorizaciones.reportante, autorizaciones.tipo_consulta, autorizaciones.tipo_estado, autorizaciones.correo, autorizaciones.hora_commit, autorizaciones.fecha_commit, autorizaciones.id_reg_reclamos_medicos, reg_reclamos_medicos.asegurado, reg_reclamos_medicos.poliza, reg_reclamos_medicos.aseguradora, reg_reclamos_medicos.contratante, reg_reclamos_medicos.clase, usuario.nombre FROM autorizaciones INNER JOIN reg_reclamos_medicos ON autorizaciones.id_reg_reclamos_medicos = reg_reclamos_medicos.id INNER JOIN usuario ON autorizaciones.id_usuario = usuario.id WHERE (autorizaciones.tipo_estado != 'Cerrado')"></asp:SqlDataSource>
                 </div>
              </div>
          </div>  
      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>

