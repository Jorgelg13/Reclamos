<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmAutorizacionesAbiertas.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmAutorizacionesAbiertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
     <div class ="container-fluid">
          <div class="panel panel-default">
              <div class="panel-heading">Listado De Autorizaciones Pendientes De Cerrar</div>
              <div class="panel-body">
                 <div class="scrolling-table-container">
                      <asp:GridView ID="GridAutorizacionesAbiertas" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id,idRegMedico" DataSourceID="SqlDataSourceAutorizacionesAbiertas" ForeColor="#333333" GridLines="None">
                          <AlternatingRowStyle BackColor="White" />
                          <Columns>
                              <asp:HyperLinkField DataNavigateUrlFields="id,idRegMedico,poliza" DataNavigateUrlFormatString="/Modulos/MdReclamos/wbFrmAutorizacionesEditar.aspx?ID_reclamo={0}&amp;ultimoRegMedico={1}&amp;poliza={2}" DataTextField="reportante" >
                              <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                              <ItemStyle HorizontalAlign="Left" Wrap="False" />
                              </asp:HyperLinkField>
                              <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
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
                              <asp:BoundField DataField="aseguradora" HeaderText="Aseguradora" SortExpression="aseguradora" >
                              <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                              <ItemStyle HorizontalAlign="Left" Wrap="False" />
                              </asp:BoundField>
                              <asp:BoundField DataField="ejecutivo" HeaderText="Ejecutivo" SortExpression="ejecutivo" >
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
                              <asp:BoundField DataField="hora_commit" HeaderText="Hora " SortExpression="hora_commit" >
                              <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                              <ItemStyle HorizontalAlign="Left" Wrap="False" />
                              </asp:BoundField>
                              <asp:BoundField DataField="fecha_commit" HeaderText="Fecha " SortExpression="fecha_commit" DataFormatString="{0:dd/MM/yyyy}" >
                              <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                              <ItemStyle HorizontalAlign="Left" Wrap="False" />
                              </asp:BoundField>
                              <asp:BoundField DataField="telefono" HeaderText="Telefono" SortExpression="telefono" >
                              <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                              <ItemStyle HorizontalAlign="Left" Wrap="False" />
                              </asp:BoundField>
                              <asp:BoundField DataField="correo" HeaderText="Correo" SortExpression="correo" >
                              <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                              <ItemStyle HorizontalAlign="Left" Wrap="False" />
                              </asp:BoundField>
                              <asp:BoundField DataField="idRegMedico" HeaderText="idRegMedico" InsertVisible="False" ReadOnly="True" SortExpression="idRegMedico" Visible="False" />
                          </Columns>
                          <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                          <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                          <RowStyle BackColor="#EFF3FB" />
                          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                      </asp:GridView>
                       <asp:Label ID="lblusuario" runat="server" Text="Label" Visible="false"  ></asp:Label>
                      <asp:SqlDataSource ID="SqlDataSourceAutorizacionesAbiertas" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT autorizaciones.id, autorizaciones.reportante, autorizaciones.tipo_consulta, autorizaciones.tipo_estado, autorizaciones.correo, autorizaciones.telefono, autorizaciones.hora_commit, autorizaciones.fecha_commit, reg_reclamos_medicos.asegurado, reg_reclamos_medicos.poliza, reg_reclamos_medicos.ejecutivo, reg_reclamos_medicos.aseguradora, reg_reclamos_medicos.id AS idRegMedico FROM autorizaciones INNER JOIN reg_reclamos_medicos ON autorizaciones.id_reg_reclamos_medicos = reg_reclamos_medicos.id WHERE (autorizaciones.tipo_estado != 'cerrado' and autorizaciones.id_usuario = @idUsuario)">
                      </asp:SqlDataSource>
                 </div>
              </div>
          </div>  
      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>

