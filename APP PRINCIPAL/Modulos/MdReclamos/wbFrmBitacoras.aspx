<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmBitacoras.aspx.cs" Inherits="Modulos_MdAdmin_wbFrmBitacoras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
    <div class ="container-fluid">
          <div class="">
              <div class="form-inline">
                  <div class="form-group" style="width: 15%">
                      <label for="message-text" class="control-label">Buscar por:</label>
                      <asp:DropDownList CssClass="form-control" ID="ddlTipoBitacora" Style="width: 100%" Height="34px" runat="server">
                          <asp:ListItem Value ="1">Bitacora Autos</asp:ListItem>
                          <asp:ListItem Value ="2">Bitacora Daños varios</asp:ListItem>
                          <asp:ListItem Value ="3">Bitacora Autorizaciones</asp:ListItem>
                          <asp:ListItem Value ="4">Bitacora Medicos</asp:ListItem>
                      </asp:DropDownList>
                  </div>
                  <div class="form-group" style="width: 15%">
                      <label for="message-text" class="control-label">Fecha Inicio:</label>
                      <asp:TextBox ID="fechaInicio"  Style="width: 100%" CssClass="form-control" Height="34px" type="date" runat="server"></asp:TextBox>
                  </div>
                   <div class="form-group" style="width: 15%">
                      <label for="message-text" class="control-label">Fecha Final:</label>
                      <asp:TextBox ID="fechaFinal" Style="width: 100%" CssClass="form-control" Height="34px" type="date" runat="server"></asp:TextBox>
                  </div>
                  <div class="form-group" style="width: 4%">
                      <label for="message-text" class="control-label"></label>
                      <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                  </div>
                  <div class="form-group" style="width: 5%">
                      <label for="message-text" class="control-label"></label>
                      <button type="button" class="btn btn-primary" data-toggle="modal" data-target=".bs-example-modal-lg">Ver Detalle</button>
                  </div>
              </div>

              <asp:Label ID="Label4" Visible="false" runat="server"></asp:Label>
          </div>
          <br />
          <div class="panel panel-info" style = "min-height: 400px;">
              <div class="panel-heading">Registro de Reclamos de Autos</div>
              <div class="panel-body">
                 <div class="scrolling-table-container">
                     <asp:GridView ID="GridBitacoras" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="true" DataKeyNames="id" OnSelectedIndexChanged="GridBitacoras_SelectedIndexChanged">
                         <AlternatingRowStyle BackColor="White" />
                         <Columns>
                             <asp:CommandField ShowSelectButton="True" />
                         </Columns>
                         <EditRowStyle BackColor="#48086f" />
                         <FooterStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                         <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                         <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                     </asp:GridView>
                 </div>
              </div>
          </div>
            <div class="modal fade bs-example-modal-lg" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
               <div class="modal-dialog modal-lg" role="document">
                  <div class="modal-content">
                    <div class="modal-header">
                          <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                          <h4 class="modal-title" id="myModalLabel"><b>Bitacora De LLamadas realizadas</b></h4>
                      </div>
                      <div class="modal-body">
                           <div class="scrolling-table-container">
                               <asp:GridView ID="Gridllamadas"  CssClass="table bs-table table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                                   <AlternatingRowStyle BackColor="White" />      
                                   <EditRowStyle BackColor="#2461BF" />
                                   <FooterStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                                   <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                   <RowStyle BackColor="#EFF3FB" />
                                   <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                               </asp:GridView>
                           </div>
                      </div>
                      <div class="modal-footer">
                          <asp:Button ID="btnCancelar" CssClass="btn btn-warning" runat="server" Text="Cerrar" />
                      </div>
                  </div>
              </div>
          </div>
      </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>

