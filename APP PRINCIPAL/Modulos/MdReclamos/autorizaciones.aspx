<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="autorizaciones.aspx.cs" Inherits="Modulos_MdReclamos_autorizaciones" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
       <div class ="container-fluid">
          <div class="panel panel-default">
              <div class="panel-heading">Busqueda de autorizaciones</div>
              <div class="panel-body">
                     <div class="form-inline">
                           <div class="form-group" style="width: 15%">
                      <label class="control-label">Buscar</label>
                      <asp:TextBox ID="txtBuscar"  Style="width: 100%" CssClass="form-control" runat="server"></asp:TextBox>
                  </div>
                  <div class="form-group" style="width: 10%">
                      <label class="control-label">Fecha Inicio:</label>
                      <asp:TextBox ID="txtFechaInicio"  Style="width: 100%" CssClass="form-control" Height="34px" type="date" runat="server"></asp:TextBox>
                  </div>
                   <div class="form-group" style="width: 10%">
                      <label class="control-label">Fecha Final:</label>
                      <asp:TextBox ID="txtFechaFinal" Style="width: 100%" CssClass="form-control" Height="34px" type="date" runat="server"></asp:TextBox>
                  </div>
                  <div class="form-group" style="width: 4%">
                      <label class="control-label"></label>
                      <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                  </div>
              </div>
                 <div class="scrolling-table-container">
                      <asp:GridView ID="GridAutorizaciones" runat="server" CssClass="table bs-table table-responsive table-hover" 
                           CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridAutorizaciones_SelectedIndexChanged">
                          <AlternatingRowStyle BackColor="White" />
                          <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                          <RowStyle BackColor="#EFF3FB" Wrap="false" />
                          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                      </asp:GridView>
                 </div>
              </div>
          </div>  
      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentJS" Runat="Server">
</asp:Content>

