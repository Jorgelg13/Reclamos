<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="buscar-auto.aspx.cs" Inherits="Modulos_MdFlotillas_buscar_auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info col-sm-12 col-md-12 col-lg-12">
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Buscar Automovil</a></li>
                <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Ingresar Datos</a></li>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="home">
                    <div class="panel-body">
                        <div class=" form-inline">
                            <asp:TextBox runat="server" autocomplete="off" ID="txtBusqueda" Style="width: 30%" class="form-control" placeholder="Escriba una opcion de busqueda" data-toggle="tooltip" data-placement="top" title="Puede realizar una busqueda por placa, poliza, asegurado, propietario, o chasis"></asp:TextBox>
                            <asp:Button runat="server" Text="Buscar Auto" ID="btnBuscar"  class="btn btn-primary" OnClick="btnBuscar_Click" />
                        </div>
                        <br />
                        <div class="scrolling-table-container">
                            <asp:GridView ID="GridAutos" EmptyDataText="No se encontro ese registro" CssClass="table bs-table table-responsive table-hover" 
                                runat="server" AutoGenerateColumns="true"  CellPadding="4" 
                                OnSelectedIndexChanged="GridAutos_SelectedIndexChanged" ForeColor="#333333" GridLines="None">
                                <EmptyDataRowStyle BackColor="LightBlue"
                                    ForeColor="Red" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <AlternatingRowStyle BackColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#EFF3FB" Wrap="false" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
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
                            <asp:Button runat="server" Style="margin-top: 15px;" Text="Guardar" ID="txtGuardarReclamo" class="btn btn-primary" OnClick="txtGuardarReclamo_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal de asegurados VIP-->
    <div class="modal fade" id="ModalVip">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title"><b>Cliente Vip</b></h4>
                </div>
                <div class="modal-body">
                    <br />
                    <img src="../../imgUnity/cliente-vip.png" style="height: 150px; width: auto;" />
                    <br />
                    <ul>
                        <li>
                            <h4>Estimado Asesor este es un cliente VIP para Unity</h4>
                        </li>
                        <li>
                            <h4>Si la emergencia cuenta con lesionados/terceros o se reporte entre las 10PM y 6 AM enviar ajustador propio conjunto con el de la compañía.</h4>
                        </li>
                    </ul>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                </div>
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
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="select top 40 *from viewCoberturasAutos WHERE (chasis like '%' + @chasis + '%') ">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtBusqueda" Name="chasis" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentJS" Runat="Server">
</asp:Content>

