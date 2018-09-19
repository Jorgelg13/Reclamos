<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmReclamoMedicoManual.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmReclamoMedicoManual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class="panel panel-info col-sm-12 col-md-12 col-lg-12">
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active"><a>Ingresar Datos</a></li>
        </ul>
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane active" id="messages">
                <div class="panel-body info">
                    <div class="panel-body">
                        <div class="row">
                            <div class="form-group col-sm-12 col-md-4 col-lg-2">
                                <label>Asegurado o Titular:</label>
                                <asp:TextBox ID="txtAseguradoTitular" Style="width: 100%" class="form-control" runat="server" placeholder="asegurado"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-12 col-md-4 col-lg-2">
                                <label>No. Poliza:</label>
                                <asp:TextBox ID="txtPoliza" Style="width: 100%" CssClass="form-control" placeholder="Numero De Poliza" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-12 col-md-4 col-lg-2">
                                <label>Contratante:</label>
                                <asp:TextBox ID="txtEmpresa" Style="width: 100%" CssClass="form-control" placeholder="Empresa Contratante" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-12 col-md-4 col-lg-1">
                                <label>Tipo:</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlTipoReclamo" Style="width: 100%" Height="32px" runat="server">
                                    <asp:ListItem Value="I">Indivual</asp:ListItem>
                                    <asp:ListItem Value="C">Colectivos</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-sm-12 col-md-4 col-lg-3">
                                <label>Aseguradora:</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlAseguradora" Style="width: 100%" Height="32px" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-sm-12 col-md-4 col-lg-2">
                                <label>Dependiente:</label>
                                <asp:TextBox ID="txtDependiente" Style="width: 100%" class="form-control" runat="server" placeholder="Dependiente"></asp:TextBox>
                            </div>
                             <div class="form-group col-sm-12 col-md-4 col-lg-2">
                                <label>Telefono:</label>
                                <asp:TextBox ID="txtTelefono" maxlength="8" Style="width: 100%" class="form-control" runat="server" placeholder="telefono"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-12 col-md-4 col-lg-3">
                                <label>Correo:</label>
                                <asp:TextBox ID="txtCorreo" Style="width: 100%" class="form-control" runat="server" placeholder="correo electronico"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-12 col-md-4 col-lg-2">
                                <label>Tipo Reclamo:</label>
                                <asp:DropDownList CssClass="form-control" ID="DDLTipo" Style="width: 100%" Height="34px" runat="server">
                                    <asp:ListItem Value="2">Gastos Medicos</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-sm-12 col-md-4 col-lg-2">
                                <label>Recibido por:</label>
                                <asp:TextBox ID="txtRecepcion" Style="width: 100%" class="form-control" runat="server" placeholder="Reclamo recibido por"></asp:TextBox>
                            </div>
                               <div class="form-group col-sm-12 col-md-4 col-lg-1">
                                <label>Moneda:</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlMoneda" Style="width: 100%" Height="32px" runat="server">
                                    <asp:ListItem value="Quetzales">Quetzales</asp:ListItem>
                                    <asp:ListItem Value="Dolares">Dolares</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-sm-12 col-md-4 col-lg-2">
                                <label>Tipo Asegurado:</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlTipoAsegurado" Style="width: 100%" Height="32px" runat="server">
                                    <asp:ListItem>Principal</asp:ListItem>
                                    <asp:ListItem>Dependiente</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="scrolling-table-container">
                            <asp:GridView ID="GridRecibo" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="id" DataSourceID="SqlDataSourceRecibo">
                                <Columns>
                                    <asp:TemplateField HeaderText="Seleccionar">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="checkOpciones" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="descripcion" HeaderText="descripcion" />
                                    <asp:TemplateField HeaderText="Comentarios">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtComentarios" Autocomplete="off" Style="width: 100%;" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCantidad" Autocomplete="off" Style="width: 100%;" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <RowStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:GridView>
                        </div>
                        <ul>
                            <p>IMPORTANTE</p>
                            <li>Si su formulario de reclamo no trae el diagnostico del medico con la firma v sello. no se recibe para tramite. hasta estar debidamente completado.</li>
                            <li>Si el expediente de su reclamo esta incompleto. Debe completarlo dentro de los proximos 5 dias habiles posteriores a la entrega: de no complementarlo, Se le devolvera el expediente se le devolvera a la direccion que tenemos registrada.</li>
                            <li>Facturas deben de venir unicamente a nombre del asegurado titular de la Poliza v en original (Roble puede recibir copias).</li>
                            <li>Recetas Medicas. ordenes v resultados de examenes pueden ser en fotocopia completa v legible </li>
                        </ul>
                        <asp:Button runat="server" Text="Guardar" ID="btnGuardar" class="btn btn-primary" OnClick="btnGuardarReclamo_Click" />
                    </div>
                </div>
            </div>
        </div>
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

