<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmReclamosMedicos.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmReclamosMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
      <div class="col-md-1">
        </div>
          <div class="panel panel-default col-md-10">
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Buscar Asegurado </a></li>
                <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Ingresar Datos</a></li>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="home">
                    <div class="panel-body">
                        <div class=" form-inline">
                            <asp:TextBox runat="server" autocomplete="off" ID="txtBusqueda" Style="width: 30%" class="form-control" placeholder="Escriba no. de poliza o asegurado "></asp:TextBox>
                            <asp:Button runat="server" Text="Buscar" ID="btnBuscar" class="btn btn-primary" OnClick="btnBuscar_Click" />
                        </div>
                        <br />
                        <div class="scrolling-table-container">
                            <asp:GridView ID="GridMedicos" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridMedicos_SelectedIndexChanged" AllowSorting="True">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <FooterStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <%------------------------------------ panel para ingresar la informacion en el formulario --------------------------%>          
                  <div role="tabpanel" class="tab-pane" id="messages">
                    <div class="panel-body">
                          <div class="form-inline">
                            <div class="form-group" style="width: 25%">
                                <label for="message-text" class="control-label">Asegurado o Titular:</label>
                                <asp:TextBox ID="txtAsegurado" Style="width: 100%" class="form-control" runat="server" placeholder="asegurado"></asp:TextBox>
                            </div>
                             <div class="form-group" style="width: 20%">
                                <label for="message-text" class="control-label">No. Poliza:</label>
                                <asp:TextBox ID="txtpoliza" Style="width: 100%" CssClass="form-control" placeholder="Numero De Poliza" runat="server"></asp:TextBox>
                            </div>
                             <div class="form-group" style="width: 30%">
                                <label for="message-text" class="control-label">Contratante:</label>
                                <asp:TextBox ID="txtEmpresa" Style="width: 100%" CssClass="form-control" placeholder="Empresa Contratante" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group" style="width: 23%">
                                <label for="message-text" class="control-label">Aseguradora:</label>
                                <asp:TextBox ID="txtAseguradora" Style="width: 100%" CssClass="form-control" placeholder="Aseguradora" runat="server"></asp:TextBox>
                            </div>
                            <br />
                            <br />
                           <div class="form-group" style="width: 25%">
                               <label for="message-text" class="control-label">Dependiente:</label>
                               <asp:TextBox ID="txtDependiente" Style="width: 100%" class="form-control" runat="server" placeholder="Dependiente"></asp:TextBox>
                            </div>
                            <div class="form-group" style="width: 10%">
                                <label for="message-text" class="control-label">Telefono:</label>
                                <asp:TextBox ID="txtTelefono" maxlength="8" Style="width: 100%" class="form-control" runat="server" placeholder="telefono"></asp:TextBox>
                            </div>
                            <div class="form-group" style="width: 25%">
                               <label for="message-text" class="control-label">Correo:</label>
                               <asp:TextBox ID="txtCorreo" Style="width: 100%" class="form-control" runat="server" placeholder="correo electronico"></asp:TextBox>
                           </div>
                           <div class="form-group" style="width: 15%">
                               <label for="message-text" class="control-label">Tipo Reclamo:</label>
                               <asp:DropDownList CssClass="form-control" ID="DDLTipo" Style="width: 100%" Height="34px" runat="server">
                                 <asp:ListItem Value="2">Gastos Medicos</asp:ListItem>
                                 <asp:ListItem Value="1">Vida</asp:ListItem>
                               </asp:DropDownList>
                           </div>
                               <div class="form-group" style="width: 23%">
                               <label for="message-text" class="control-label">Recibido por:</label>
                               <asp:TextBox ID="txtRecepcion" Style="width: 100%" class="form-control" runat="server" placeholder="Reclamo recibido por"></asp:TextBox>
                           </div>
                        </div>
                        <br />
                         <div>
                         <asp:GridView ID="GridRecibo" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="id" DataSourceID="SqlDataSourceRecibo">
                                <Columns>
                                    <asp:TemplateField HeaderText="Seleccionar">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="checkOpciones" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="descripcion" HeaderText="descripcion"/>
                                    <asp:TemplateField HeaderText="Comentarios">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtComentarios" Autocomplete="off" style="width : 100%;"  CssClass="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCantidad" Autocomplete="off" style="width : 100%;"  CssClass="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <RowStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:GridView>
                             <ul>
                                 <p><b>IMPORTANTE</b></p>
                                 <li>Si su formulario de reclamo no trae el diagnóstico del médico con la firma y sello. No se recibe para trámite. hasta estar debidamente completado.</li>
                                 <li>Si el expediente de su reclamo esta incompleto. Debe completarlo dentro de los próximos 5 dias hábiles posteriores a la entrega: de no complementarlo, Se le devolverá el expediente se le devolvera a la dirección que tenemos registrada.</li>
                                 <li>Facturas deben de venir únicamente a nombre del asegurado titular de la Póliza y en original (Roble puede recibir copias).</li>
                                 <li>Recetas Médicas. Ordenes y resultados de exámenes pueden ser en fotocopia completa y legible </li>
                             </ul>
                        </div>
                          <asp:Button runat="server" Text="Guardar" ID="btnGuardar" class="btn btn-primary" OnClick="btnGuardar_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-1">
        </div>          
    <asp:SqlDataSource ID="SqlDataSourceRecibo" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [descripcion], [id] FROM [documentos_medicos] where tipo= 'Formulario1'"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentJS" runat="Server">
    <script>
        $('#<%=txtTelefono.ClientID%>').on('input', function () {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
    </script>
</asp:Content>

