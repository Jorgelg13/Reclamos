<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbFrmTalleres.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmTalleres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
         <div  class="panel panel-info col-sm-12"> 
              <ul class="nav nav-tabs" role="tablist">
                <li role="presentation"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Buscar Taller</a></li>
                <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Ingresar Taller</a></li>
              </ul>
             <div class="tab-content">
                 <div role="tabpanel" class="tab-pane" id="home">
                     <div class="panel-body">
                         <div class=" form-inline">
                             <asp:TextBox runat="server" autocomplete="off" ID="txtBusqueda" Style="width: 30%" class="form-control" placeholder="Nombre del taller"></asp:TextBox>
                             <asp:Button runat="server" Text="Buscar" ID="btnBuscar" class="btn btn-primary" />
                         </div>
                         <br />
                         <div class="scrolling-table-container">
                             <asp:GridView ID="GridTalleres" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSourceTalleres">
                                 <AlternatingRowStyle BackColor="White" />
                                 <Columns>
                                     <asp:CommandField ShowEditButton="True" />
                                     <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="True" SortExpression="id" InsertVisible="False" >
                                     <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                     <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre">
                                     <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                     <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="direccion" HeaderText="Direccion" SortExpression="direccion">
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
                                     <asp:CheckBoxField DataField="estado" HeaderText="Estado" SortExpression="estado" />
                                 </Columns>
                                 <EditRowStyle BackColor="#2461BF" />
                                 <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                 <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                 <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                 <RowStyle BackColor="#EFF3FB" />
                                 <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                             </asp:GridView>
                             <asp:SqlDataSource ID="SqlDataSourceTalleres" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="select *from talleres where (nombre like '%' + @nombre + '%' )" UpdateCommand =" UPDATE talleres SET nombre = @nombre, direccion= @direccion, telefono= @telefono, correo =@correo, estado =@estado where id = @id"  >
                                 <SelectParameters>
                                     <asp:ControlParameter ControlID="txtBusqueda" Name="nombre" PropertyName="Text" DefaultValue=" " />
                                 </SelectParameters>
                                 <UpdateParameters>
                                     <asp:Parameter Name="nombre" />
                                     <asp:Parameter Name="direccion" />
                                     <asp:Parameter Name="telefono" />
                                     <asp:Parameter Name="correo" />
                                     <asp:Parameter Name="id" />
                                 </UpdateParameters>
                             </asp:SqlDataSource>
                         </div>
                     </div>
                 </div>

                    <%--segundo tab--%>
                 <div role="tabpanel" class="tab-pane" id="profile">
                  <div class="panel-body form-inline">
                         <br />
                         <asp:TextBox runat="server" ID="txtNombre" Style="width: 25%"  autocomplete="off" CssClass="form-control" placeholder="Nombre" ></asp:TextBox >
                         <asp:TextBox runat="server" ID="txtDireccion" Style="width: 25%" autocomplete="off" class="form-control" placeholder="Direccion"></asp:TextBox>
                         <asp:TextBox runat="server" ID="txtTelefono" Style="width: 20%" autocomplete="off" class="form-control" placeholder="Telefono"></asp:TextBox>
                         <asp:TextBox runat="server" ID="txtCorreo" type="email" Style="width: 25%" autocomplete="off" class="form-control" placeholder="Correo Electronico"></asp:TextBox>
                         <br />
                         <br />
                         <asp:Button runat="server" Text="Guardar" ID="btnguardar" class="btn btn-primary" OnClick="btnguardar_Click"/>
                     </div>
                 </div>
             </div>
         </div>
      </div>
</asp:Content>

