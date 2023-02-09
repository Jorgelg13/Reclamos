<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmReclamosAutosEditar.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmReclamosAutosEditar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <asp:TextBox ID="txtBusquedaAuto" Visible="false" CssClass="form-control active" Style="width: 30%" runat="server"></asp:TextBox>
    <div>
        <div class="panel panel-info col-sm-12 col-md-9 col-lg-9">
            <div class="panel-body">
                <div class="img-float-right" style="float: right; padding-top: 5px;">
                    <b><asp:Label runat="server" ID="fechaCreacion" Style="padding-right: 7px; font-size: 15px;"></asp:Label></b>
                    <b><asp:Label runat="server" ID="HoraCreacion" Style="padding-right: 50px; font-size: 15px;"></asp:Label></b>
                </div>
                <ul class="nav nav-tabs margen " role="tablist">
                    <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Ver Coberturas</a></li>
                    <li role="presentation"><a href="#messages" class="active" aria-controls="messages" role="tab" data-toggle="tab">Confirmacion De datos</a></li>
                    <li role="presentation"><a href="#settings" aria-controls="settings" role="tab" data-toggle="tab">Registrar llamada</a></li>
                    <li role="presentation"><a href="#llamadas" aria-controls="llamadas" role="tab" data-toggle="tab">Historial llamadas</a></li>
                </ul>
                <div class="tab-content ">
                    <div role="tabpanel" class="tab-pane" id="profile">
                        <div class="scrolling-table-container">
                            <asp:GridView ID="GridCoberturas" CssClass="table bs-table table-responsive table-hover" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1CoberturaEditar" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="descr" HeaderText="Descripcion" SortExpression="descr" />
                                    <asp:BoundField DataField="placa" HeaderText="Placa" SortExpression="placa" />
                                    <asp:BoundField DataField="limite1" HeaderText="limite1" SortExpression="limite1" />
                                    <asp:BoundField DataField="limite2" HeaderText="limite2" SortExpression="limite2" />
                                    <asp:BoundField DataField="deducible" HeaderText="deducible" SortExpression="deducible" />
                                </Columns>
                                <FooterStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
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
                             <div class="form-group col-sm-12 col-md-6 col-lg-2">
                                 <label for="recipient-name" class="control-label">Telefono:</label>
                                 <asp:TextBox runat="server" ID="txtTelefono" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Telefono"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-12 col-md-6 col-lg-6">
                                 <label for="recipient-name" class="control-label">Ubicacion:</label>
                                 <asp:TextBox runat="server" ID="txtUbicacion" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Ubicacion"></asp:TextBox>
                            </div>
                             <div class="form-group col-sm-12 col-md-6 col-lg-3">
                                 <label for="recipient-name" class="control-label">Piloto:</label>
                                 <asp:TextBox runat="server" ID="txtpiloto" autocomplete="off" Style="width: 100%" class="form-control" placeholder="piloto"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-12 col-md-6 col-lg-3">
                                 <label for="recipient-name" class="control-label">Boleta:</label>
                                 <asp:TextBox runat="server" ID="txtBoleta" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Numero de boleta"></asp:TextBox>
                            </div>
                             <div class="form-group col-sm-12 col-md-6 col-lg-3">
                                 <label for="recipient-name" class="control-label">Ajustador:</label>
                                 <asp:TextBox runat="server" ID="txtAjustador" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Ajustador"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-12 col-md-6 col-lg-3">
                                 <label for="recipient-name" class="control-label">Titular:</label>
                                 <asp:TextBox runat="server" ID="txtTitular" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Titular"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-12 col-md-6 col-lg-3">
                                 <label for="recipient-name" class="control-label">Tipo Servcio:</label>
                                 <asp:DropDownList CssClass="form-control" ID="DDLTipo" Style="width: 100%" Height="35px" runat="server">
                                   <asp:ListItem>Accidente</asp:ListItem>
                                   <asp:ListItem>Asistencia Vehicular</asp:ListItem>
                                   <asp:ListItem>Robo</asp:ListItem>
                                   <asp:ListItem>Robo parcial</asp:ListItem>
                            </asp:DropDownList>
                            </div>
                            <div class="form-group col-sm-12 col-md-12 col-lg-9">
                                 <label for="recipient-name" class="control-label">Version:</label>
                                 <asp:TextBox runat="server" ID="txtVersion" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Version"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div role="tabpanel" class="tab-pane active" id="settings">
                        <br />
                          <div class="form-group col-sm-12 col-md-10 col-lg-9">
                               <label for="recipient-name" class="control-label">Detalle de llamada:</label>
                               <asp:TextBox ID="txtllamada" autocomplete="off" placeholder="ingrese el detalle de la llamada" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                           </div>
                           <div class="form-group col-sm-12 col-md-2 col-lg-3">
                               <label for="recipient-name" class="control-label">Estado:</label>
                               <asp:DropDownList CssClass="form-control" ID="ddlestado" Style="width: 100%" Height="34px" runat="server">
                                <asp:ListItem Value="1">Abierto</asp:ListItem>
                                <asp:ListItem Value="2">Cerrado</asp:ListItem>
                                <asp:ListItem Value="3">Anulado</asp:ListItem>
                            </asp:DropDownList>
                           </div>
                            <!-- Button trigger modal -->
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
                            <asp:GridView ID="GridLLamadas" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourcelogLLamadas" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" SortExpression="descripcion" />
                                    <asp:BoundField DataField="hora_commit" HeaderText="Hora" SortExpression="hora_commit" />
                                    <asp:BoundField DataField="fecha_commit" HeaderText="Fecha" SortExpression="fecha_commit" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="usuario" HeaderText="Usuario" SortExpression="usuario" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-sm-12 col-md-3 col-lg-3">
        <div class="panel panel-info">
            <div class="panel-heading">
                <h3 class="panel-title">Datos Del Automovil</h3>
            </div>
            <div class="panel-body">
                <asp:Label ID="lblPlaca" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblColor" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblMarca" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblModelo" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblChasis" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblMotor" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblPropietario" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblEjecutivo" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblAseguradora" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblContratante" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblEstadoPoliza" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblCliente" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblPrograma" runat="server"></asp:Label>
                <br />
            </div>
        </div>
    </div>
      <div class="modal fade" id="modal-recordatorio">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title"><b>Recordatorio Unity-Pepsico</b></h4>
                </div>
                <div class="modal-body">
                    <ul>
                        <li>
                            <h4>Estimado usuario, le recordamos que es importante reportar esta emergencia en el chat Unity-Pepsico</h4>
                        </li>
                    </ul>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSourceBusquedaAuto" runat="server" ConnectionString="<%$ ConnectionStrings:seguroConnectionString %>" SelectCommand="SELECT [ramo], [poliza], [vigi], [vigf], [marca], [color], [motor], [chasis], [placa], [solicitud], [secart], [modelo], [valorauto], [propietario], [estado] FROM [ViewBusquedaAuto] WHERE (placa like '%' +@placa + '%') OR (propietario like '%' + @propietario +'%')">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtBusquedaAuto" Name="placa" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtBusquedaAuto" Name="propietario" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1CoberturaEditar" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="select top 10 *from viewCoberturasAutos where (placa like '%' + @placa + '%')">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtBusquedaAuto" Name="placa" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:TextBox ID="txtIdRecibido" Visible="false" runat="server"></asp:TextBox>
    <asp:SqlDataSource ID="SqlDataSourcelogLLamadas" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [descripcion], [fecha_commit], [hora_commit], [usuario] FROM [bitacora_reclamo_auto] WHERE ([id_reclamo] = @id_reclamo)">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtIdRecibido" Name="id_reclamo" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>



