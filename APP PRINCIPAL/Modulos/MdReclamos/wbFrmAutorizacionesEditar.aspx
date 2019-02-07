<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmAutorizacionesEditar.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmAutorizacionesEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div>
        <div class="panel panel-info col-sm-9">
            <div class="panel-body">
                <ul class="nav nav-tabs margen " role="tablist">
                    <li role="presentation"><a href="#messages" class="active" aria-controls="messages" role="tab" data-toggle="tab">Confirmacion De datos</a></li>
                    <li role="presentation"><a href="#settings" aria-controls="settings" role="tab" data-toggle="tab">Registrar Estado</a></li>
                    <li role="presentation"><a href="#estados" aria-controls="estados" role="tab" data-toggle="tab">Historial Estados</a></li>
                </ul>
                <div class="tab-content ">
                    <div role="tabpanel" class="tab-pane " id="messages">
                        <div class="panel-body form-inline">
                            <br />
                            <asp:TextBox runat="server" ID="txtReportante" autocomplete="false" Style="width: 45%" class="form-control" placeholder="Reportante"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txtCorreo" autocomplete="false" Style="width: 45%" class="form-control" placeholder="Correo Electronico"></asp:TextBox>
                            <br />
                            <br />
                            <asp:TextBox runat="server" type="" ID="txtTelefono" autocomplete="false" Style="width: 20%" Height="34px" class="form-control" placeholder="Telefono"></asp:TextBox>
                            <asp:DropDownList CssClass="form-control" ID="DDLTipo" Style="width: 40%" Height="34px" runat="server">
                                <asp:ListItem>Medicamentos</asp:ListItem>
                                <asp:ListItem>Laboratorios y Examenes especiales</asp:ListItem>
                                <asp:ListItem>Procedimientos</asp:ListItem>
                                <asp:ListItem>Hospitalizaciones</asp:ListItem>
                                <asp:ListItem>Fisioterapias</asp:ListItem>
                                <asp:ListItem>Control de niño sano</asp:ListItem>
                                <asp:ListItem>Dental</asp:ListItem>
                                <asp:ListItem>Otros</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
                            <br />
                        </div>
                    </div>
                    <div role="tabpanel" class="tab-pane active" id="settings">
                        <div class="form-inline">
                            <br />
                            <br />
                            <asp:TextBox ID="txtRegistro" autocomplete="false" placeholder="Ingrese alguna descripcion" CssClass="form-control" Style="width: 70%" runat="server"></asp:TextBox>
                            <asp:DropDownList CssClass="form-control" ID="DDLEstado" Style="width: 25%" Height="34px" runat="server">
                                <asp:ListItem>Revision</asp:ListItem>
                                <asp:ListItem>Aseguradora</asp:ListItem>
                                <asp:ListItem>Asegurado</asp:ListItem>
                                <asp:ListItem>Enviado</asp:ListItem>
                                <asp:ListItem>Cerrado</asp:ListItem>
                                <asp:ListItem>Anulado</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
                            <!-- Button  modal -->
                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">
                                Guardar
                            </button>

                            <!-- Modal para confirmamcion de guardar estado-->
                            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title" id="myModalLabel"><b>Confirmacion De guardar</b></h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>Esta seguro que desea guardar estos cambios en la bitacora</p>
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button ID="btnGuardarEstado" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarEstado_Click1" />
                                            <asp:Button ID="btnCancelar" CssClass="btn btn-warning" runat="server" Text="Cancelar" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div role="tabpanel" class="tab-pane" id="estados">
                        <br />
                        <div class="scrolling-table-container">
                            <asp:GridView ID="gridEstados" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourceEstados" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" SortExpression="descripcion" />
                                    <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
                                    <asp:BoundField DataField="hora_commit" HeaderText="Hora" SortExpression="hora_commit" />
                                    <asp:BoundField DataField="fecha_commit" HeaderText="Fecha" SortExpression="fecha_commit" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="usuario" HeaderText="Usuario" SortExpression="usuario" />
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
            </div>
        </div>
        <div class="col-sm-3">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title">Datos De la Poliza</h3>
                </div>
                <div class="panel-body">
                    <asp:Label ID="lblAsegurado" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblPoliza" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblCertificado" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblRamo" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblTipo" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblClase" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblEjecutivo" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblAseguradora" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblContratante" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblEstadoPoliza" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblVip" runat="server"></asp:Label>
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
    <asp:TextBox ID="txtId" Visible="false" runat="server"></asp:TextBox>
    <asp:SqlDataSource ID="SqlDataSourceEstados" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [descripcion], [estado], [hora_commit], [fecha_commit],[usuario] FROM [bitacora_autorizaciones] WHERE (id_autorizaciones = @id_autorizaciones)">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtId" Name="id_autorizaciones" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

