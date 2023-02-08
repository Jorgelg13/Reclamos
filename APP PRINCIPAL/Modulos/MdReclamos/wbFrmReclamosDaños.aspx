<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmReclamosDaños.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmReclamosDaños" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <%--    <META HTTP-EQUIV="Refresh" URL=wbFrmReclamosDaños.aspx">--%>
    <div class="container-fluid">
        <div class="panel panel-default col-sm-12 col-md-12 col-lg-12">
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Buscar Poliza</a></li>
                <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Verificar Coberturas</a></li>
                <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Ingresar Datos</a></li>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="home">
                    <div class="panel-body">
                        <div class=" form-inline">
                            <asp:TextBox ID="txtBusqueda" autocomplete="off" CssClass="form-control active" runat="server"></asp:TextBox>
                            <asp:Button ID="btnBuscar" CssClass="btn btn-primary " runat="server" Text="Buscar" OnClick="btnBuscar_Click"/>
                            <br />
                            <div class="scrolling-table-container">
                                <asp:GridView ID="GridDaños" runat="server" EmptyDataText="No se encontro ese registro" 
                                    CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True" CellPadding="4" 
                                    ForeColor="#333333" GridLines="None" HorizontalAlign="Center" 
                                    OnSelectedIndexChanged="GridDaños_SelectedIndexChanged" AllowSorting="True">
                                    <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                    </Columns>
                                    <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" Wrap="false"/>
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="profile">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridCoberturas" CssClass="table bs-table table-responsive table-hover" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourcebusquedaCobertura" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="descr" HeaderText="Descripcion" SortExpression="descr" />
                                <asp:BoundField DataField="poliza" HeaderText="Poliza" SortExpression="poliza" />
                                <asp:BoundField DataField="limite1" HeaderText="Limite 1" SortExpression="poliza" />
                                <asp:BoundField DataField="limite2" HeaderText="Limite 2" SortExpression="poliza" />
                                <asp:BoundField DataField="deducible" HeaderText="Deducible" SortExpression="poliza" />
                            </Columns>
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                        </asp:GridView>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="messages">
                    <div class="panel-body">
                       <div class="form-group col-sm-12 col-md-6 col-lg-3">
                          <label for="recipient-name" class="control-label">Reportante:</label>
                          <asp:TextBox runat="server" ID="txtReportante" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Reportante"></asp:TextBox>                          
                       </div>
                       <div class="form-group col-sm-12 col-md-6 col-lg-3">
                          <label for="recipient-name" class="control-label">Telefono:</label>
                           <asp:TextBox runat="server" ID="txtTelefono" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Telefono"></asp:TextBox>                                                   
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
                          <label for="recipient-name" class="control-label">Ubicacion:</label>
                           <asp:TextBox runat="server" ID="txtUbicacion" autocobmplete="off" Style="width: 100%" class="form-control" placeholder="Ubicacion"></asp:TextBox>
                       </div>
                       <div class="form-group col-sm-12 col-md-6 col-lg-3">
                          <label for="recipient-name" class="control-label">Fecha Incidente:</label>
                          <asp:TextBox runat="server" type="date" ID="txtFecha" autocomplete="off" Style="width: 100%" Height="32px" class="form-control" placeholder="Fecha"></asp:TextBox>                          
                       </div>
                       <div class="form-group col-sm-12 col-md-6 col-lg-3">
                          <label for="recipient-name" class="control-label">Hora Incidente:</label>
                           <asp:TextBox runat="server" type="time" ID="txtHora" autocomplete="off" Style="width: 100%" Height="32px" class="form-control" placeholder="Hora del incidente"></asp:TextBox>     
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
                       <div class="form-group col-sm-12 col-md-12 col-lg-9">
                          <label for="recipient-name" class="control-label">Causa:</label>
                          <asp:TextBox runat="server" ID="txtVersion" autocomplete="off" Style="width: 100%" class="form-control" placeholder="Version"></asp:TextBox>                                                  
                       </div>
                       <div class="form-group">
                          <asp:Button runat="server" Text="Guardar Reclamo" ID="txtGuardarReclamo" class="btn btn-primary" OnClick="btnGuardarReclamo_Click" />                                                                           
                       </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSourcebusquedaCobertura" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT * FROM [busqCoberturasPolizasDaños] WHERE ( poliza like '%' + @poliza + '%') ">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtBusqueda" Name="poliza" PropertyName="Text" Type="String" DefaultValue="91-0035715#2" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

