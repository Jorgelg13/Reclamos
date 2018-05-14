<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmReclamosDañosEditar.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmReclamosDañosEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div>
        <div class="panel panel-info col-sm-9">
            <div class="panel-body">
                <div style="float: right; padding-top: 5px;">
                    <b>
                        <asp:Label runat="server" ID="fechaCreacion" Style="padding-right: 7px; font-size: 15px;"></asp:Label></b>
                    <b>
                        <asp:Label runat="server" ID="HoraCreacion" Style="padding-right: 50px; font-size: 15px;"></asp:Label></b>
                </div>
                <ul class="nav nav-tabs margen " role="tablist">
                    <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Ver Coberturas</a></li>
                    <li role="presentation"><a href="#messages" class="active" aria-controls="messages" role="tab" data-toggle="tab">Confirmacion De datos</a></li>
                    <li role="presentation"><a href="#settings" aria-controls="settings" role="tab" data-toggle="tab">Registrar llamada</a></li>
                    <li role="presentation"><a href="#llamadas" aria-controls="llamadas" role="tab" data-toggle="tab">Historial de llamadas</a></li>
                </ul>
                <div class="tab-content ">
                    <asp:TextBox ID="txtBusquedaAuto" Visible="false" CssClass="form-control" Style="width: 30%" runat="server"></asp:TextBox>
                    <div role="tabpanel" class="tab-pane" id="profile">
                        <div class="scrolling-table-container">
                            <asp:GridView ID="GridCobeturas" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourceCoberturaPoliza" ForeColor="#333333" GridLines="None" Width="717px">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="descr" HeaderText="Descripcion" SortExpression="descr" />
                                    <asp:BoundField DataField="poliza" HeaderText="Poliza" SortExpression="poliza" />
                                    <asp:BoundField DataField="limite1" HeaderText="Limite 1" SortExpression="limite1" />
                                    <asp:BoundField DataField="limite2" HeaderText="Limite 2" SortExpression="limite2" />
                                    <asp:BoundField DataField="deducible" HeaderText="Deducible" SortExpression="deducible" />
                                </Columns>
                                <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div role="tabpanel" class="tab-pane " id="messages">
                        <div class="panel-body">
                            <div class="form-group col-sm-12 col-md-6 col-lg-4">
                                <label for="recipient-name" class="control-label">Reportante:</label>
                                <asp:TextBox runat="server" ID="txtReportante" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Reportante"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-12 col-md-6 col-lg-4">
                                <label for="recipient-name" class="control-label">Telefono:</label>
                                <asp:TextBox runat="server" ID="txtTelefono" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Telefono"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-12 col-md-6 col-lg-4">
                                <label for="recipient-name" class="control-label">Ubicacion:</label>
                                <asp:TextBox runat="server" ID="txtUbicacion" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Ubicacion"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-12 col-md-6 col-lg-3">
                                <label for="recipient-name" class="control-label">Boleta:</label>
                                <asp:TextBox runat="server" ID="txtBoleta" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Numero de boleta"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-12 col-md-6 col-lg-3">
                                <label for="recipient-name" class="control-label">Ajustador:</label>
                                <asp:TextBox runat="server" ID="txtAjustador" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Ajustador"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-12 col-md-6 col-lg-2">
                                <label for="recipient-name" class="control-label">Tipo Servicio:</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlTipoServicio" Style="width: 100%" Height="32px" runat="server">
                                    <asp:ListItem>Daños</asp:ListItem>
                                    <asp:ListItem>Robo</asp:ListItem>
                                    <asp:ListItem>RC</asp:ListItem>
                                    <asp:ListItem>Otros</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-sm-12 col-md-6 col-lg-4">
                                <label for="recipient-name" class="control-label">Titular:</label>
                                <asp:TextBox runat="server" ID="txtTitular" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Titular"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-12 col-md-12 col-lg-12">
                                <label for="recipient-name" class="control-label">Version:</label>
                                <asp:TextBox runat="server" ID="txtVersion" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Version"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div role="tabpanel" class="tab-pane active" id="settings">
                        <br />
                        <div class="form-group col-sm-12 col-md-10 col-lg-9">
                            <label for="recipient-name" class="control-label">Ingresar Detalle de llamada:</label>
                            <asp:TextBox ID="txtllamada" autocomplete="off" placeholder="ingrese el detalle de la llamada" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-2 col-lg-3">
                            <label for="recipient-name" class="control-label">Estado:</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlestado" Style="width: 100%" Height="35px" runat="server">
                                <asp:ListItem Value="1">Abierto</asp:ListItem>
                                <asp:ListItem Value="2">Cerrado</asp:ListItem>
                                <asp:ListItem Value="3">Anulado</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">
                            Guardar
                        </button>
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
                                        <asp:Button ID="btnGuardarllamada" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarllamada_Click" />
                                        <asp:Button ID="btnCancelar" CssClass="btn btn-warning" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div role="tabpanel" class="tab-pane" id="llamadas">
                        <div class="scrolling-table-container">
                            <asp:GridView ID="GridLLamadas" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourcelogllamadas" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" SortExpression="descripcion" />
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
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label8" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label9" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label10" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label11" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label12" runat="server"></asp:Label>
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSourceCoberturaPoliza" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT * FROM [busqCoberturasPolizasDaños] WHERE ( poliza like '%' + @poliza + '%') ">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtBusquedaAuto" Name="poliza" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:TextBox ID="TextBox1" Visible="false" runat="server"></asp:TextBox>
    <asp:SqlDataSource ID="SqlDataSourcelogllamadas" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [descripcion], [hora_commit], [fecha_commit], [usuario] FROM [bitacora_reclamos_varios] WHERE ([id_reclamos_varios] = @id_reclamos_varios)">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox1" Name="id_reclamos_varios" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

