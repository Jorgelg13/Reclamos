<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmReclamosAutos.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmReclamosAutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info col-sm-12 col-md-12 col-lg-12">
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Buscar Automovil</a></li>
                <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Verificar Coberturas</a></li>
                <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Ingresar Datos</a></li>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="home">
                    <div class="panel-body">
                        <div class=" form-inline">
                            <asp:TextBox runat="server" autocomplete="off" ID="txtBusqueda" Style="width: 30%" class="form-control" placeholder="Escriba una opcion de busqueda" data-toggle="tooltip" data-placement="top" title="Puede realizar una busqueda por placa, poliza, asegurado, propietario, o chasis"></asp:TextBox>
                            <asp:Button runat="server" Text="Buscar Auto" ID="btnBuscar" class="btn btn-primary" />
                        </div>
                        <br />
                        <div class="scrolling-table-container">
                            <asp:GridView ID="GridAutos" EmptyDataText="No se encontro ese registro" CssClass="table bs-table table-responsive table-hover" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="4" OnSelectedIndexChanged="GridAutos_SelectedIndexChanged" ForeColor="#333333" GridLines="None" AllowSorting="True">
                                <EditRowStyle BackColor="#2461BF" />
                                <EmptyDataRowStyle BackColor="LightBlue"
                                    ForeColor="Red" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
                                    <asp:BoundField DataField="placa" HeaderText="Placa" SortExpression="placa">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="propietario" HeaderText="Propietario" SortExpression="propietario">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="asegurado" HeaderText="Asegurado" SortExpression="asegurado">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vip" HeaderText="VIP" SortExpression="vip">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="poliza" HeaderText="Poliza" SortExpression="poliza">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nombre" HeaderText="Aseguradora" SortExpression="nombre">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="marca" HeaderText="Marca" SortExpression="marca">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="modelo" HeaderText="Modelo" SortExpression="modelo">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="color" HeaderText="Color" SortExpression="color">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="chasis" HeaderText="Chasis" SortExpression="chasis">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="motor" HeaderText="Motor" SortExpression="motor">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="estado" HeaderText="Estado Poliza" SortExpression="estado">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vigi" HeaderText="Fecha Inicial" SortExpression="vigi" DataFormatString="{0:dd/MM/yyyy}">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="vigf" HeaderText="Fecha Final" SortExpression="vigf" DataFormatString="{0:dd/MM/yyyy}">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="contratante" HeaderText="Contratante" SortExpression="contratante">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="gst_nombre" HeaderText="Ejecutivo" SortExpression="gst_nombre">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="inciso" HeaderText="Inciso Vehiculo" SortExpression="inciso">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="suma_aseg" HeaderText="Suma Asegurada" SortExpression="suma_aseg">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="moneda" HeaderText="Moneda" SortExpression="moneda">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="direccion" HeaderText="Direccion" SortExpression="direccion">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cia" HeaderText="cia" SortExpression="cia" />
                                    <asp:BoundField DataField="secren" HeaderText="secren" SortExpression="secren" />
                                    <asp:BoundField DataField="numero_gestor" HeaderText="numero_gestor" SortExpression="numero_gestor" />
                                    <asp:BoundField DataField="ramo" HeaderText="ramo" SortExpression="ramo" />
                                    <asp:BoundField DataField="cliente" HeaderText="Cliente" SortExpression="cliente" />
                                    <asp:BoundField DataField="programa" HeaderText="Programa" SortExpression="Programa" />
                                </Columns>
                                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#131B4D" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="profile">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridCoberturas" runat="server" CssClass="table bs-table table-responsive table-hover" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="descr" HeaderText="Descripcion" SortExpression="descr" />
                                <asp:BoundField DataField="placa" HeaderText="Placa" SortExpression="placa" />
                                <asp:BoundField DataField="limite1" HeaderText="Limite 1" SortExpression="limite1" />
                                <asp:BoundField DataField="limite2" HeaderText="Limite 2" SortExpression="limite2" />
                                <asp:BoundField DataField="deducible" HeaderText="Deducible" SortExpression="deducible" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="messages">
                    <div class="panel-body col-lg-12 col-md-12">
                            <div class="form-group col-md-6 col-lg-4 col-sm-12">
                                Reportante:<asp:TextBox runat="server" ID="txtReportante" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Reportante"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6 col-lg-4 col-sm-12">
                                Telefono:<asp:TextBox runat="server" ID="txtTelefono" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Telefono"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6 col-lg-4 col-sm-12">
                                Ubicacion:<asp:TextBox runat="server" ID="txtUbicacion" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Ubicacion"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6 col-lg-3 col-sm-12">
                                Fecha Incidente:<asp:TextBox runat="server" type="date" ID="txtFecha" Style="width: 100%" Height="32px" class="form-control" placeholder="Fecha"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6 col-lg-3 col-sm-12">
                                Hora Incidente:<asp:TextBox runat="server" type="time" ID="txtHora" Style="width: 100%" Height="32px" class="form-control" placeholder="Hora del incidente"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6 col-lg-3 col-sm-12">
                                Piloto:<asp:TextBox runat="server" ID="txtpiloto" autocomplete="off" Style="width: 100%" class="form-control" placeholder="piloto"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6 col-lg-3 col-sm-12">
                                Edad:<asp:TextBox runat="server" ID="txtEdad" autocomplete="off" type="number" Style="width: 100%" class="form-control" placeholder="edad piloto"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6 col-lg-3 col-sm-12">
                                Boleta:<asp:TextBox runat="server" ID="txtBoleta" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Numero de boleta"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6 col-lg-3 col-sm-12">
                                Ajustador:<asp:TextBox runat="server" ID="txtAjustador" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Ajustador"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6 col-lg-3 col-sm-12">
                                Titular:<asp:TextBox runat="server" ID="txtTitular" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Titular"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6 col-lg-3 col-sm-12">
                                Tipo:<asp:DropDownList CssClass="form-control" ID="DDLTipo" Style="width: 100%" Height="34px" runat="server">
                                    <asp:ListItem>Accidente</asp:ListItem>
                                    <asp:ListItem>Asistencia Vehicular</asp:ListItem>
                                    <asp:ListItem>Robo</asp:ListItem>
                                    <asp:ListItem>Robo parcial</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        <div class="form-group col-md-12 col-lg-12 col-sm-12">
                            Version:<asp:TextBox runat="server" ID="txtVersion" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Version"></asp:TextBox>
                            <asp:Button runat="server" style="margin-top:15px;" Text="Guardar" ID="txtGuardarReclamo" class="btn btn-primary" OnClick="txtGuardarReclamo_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal de asegurados VIP-->
    <div class="modal fade" id="ModalVip" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel"><b>Cliente Vip</b></h4>
                </div>
                <div class="modal-body">
                   <br />
                   <img src="../../imgUnity/cliente-vip.png" style="height:150px; width:auto;"/>
                    <br />
                    <ul>
                        <li><h4>Estimado Asesor este es un cliente VIP para Unity</h4></li>
                        <li><h4>Si la emergencia cuenta con lesionados/terceros o se reporte entre las 10PM y 6 AM enviar ajustador propio conjunto con el de la compañía.</h4></li>
                    </ul>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [poliza], [vigi], [vigf],  [nombre], [color], [marca], [contratante] , [gst_nombre],[marca], [motor], [chasis], [placa], [modelo], [propietario], [estado],[suma_aseg],[asegurado],[vip],[inciso],[moneda],[direccion],[cia],[secren],[numero_gestor],[ramo],[cliente], [programa] FROM [ViewBusquedaAuto] WHERE (placa like '%'+ @placa + '%') OR (propietario COLLATE Latin1_General_CI_AI like '%' + @propietario + '%') OR (poliza like '%' + @poliza + '%') OR (chasis like '%' + @chasis + '%' ) OR (contratante like '%' + @contratante + '%') OR (asegurado COLLATE Latin1_General_CI_AI like '%' + @asegurado + '%')">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtBusqueda" Name="placa" PropertyName="Text" Type="String" DefaultValue="" />
            <asp:ControlParameter ControlID="txtBusqueda" Name="propietario" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtBusqueda" Name="poliza" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtBusqueda" Name="chasis" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtBusqueda" Name="contratante" PropertyName="Text" />
            <asp:ControlParameter ControlID="txtBusqueda" Name="asegurado" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="select *from viewCoberturasAutos WHERE (chasis like '%' + @chasis + '%') ">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtBusqueda" Name="chasis" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
