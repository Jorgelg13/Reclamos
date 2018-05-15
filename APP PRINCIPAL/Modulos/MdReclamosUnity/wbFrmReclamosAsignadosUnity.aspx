<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbFrmReclamosAsignadosUnity.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmReclamosAsignadosUnity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div>
            <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="LblUsuario" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:Label ID="lblPlaca" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblChasis" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblMarca" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblModelo" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblTelefono" runat="server" Visible="false"></asp:Label>
        </div>
        <div class="panel panel-info col-sm-12">
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="home">
                    <a href="#home" aria-controls="home" role="tab" data-toggle="tab" style="font-size: 16px;">Reclamos Asignados</a>
                </li>
                <li role="presentation" class="profile">
                    <a href="#profile" aria-controls="profile" role="tab" data-toggle="tab" style="font-size: 16px;">Historial De LLamadas</a>
                </li>
                <li role="presentation" class="coberturas">
                    <a href="#coberturas" aria-controls="coberturas" role="tab" data-toggle="tab" style="font-size: 18px;">Coberturas</a>
                </li>
                <li role="presentation" class="ingreso-datos">
                    <a href="#ingreso-datos" aria-controls="ingreso-datos" role="tab" data-toggle="tab" style="font-size: 18px;">Ingresar Datos</a>
                </li>
            </ul>
            <div class="tab-content">
                <%-- grid de asignacion de reclamos--%>
                <div role="tabpanel" class="tab-pane" id="home">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridAsignacion" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="true" OnSelectedIndexChanged="GridAsignacion_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:CommandField>
                            </Columns>
                            <EditRowStyle BackColor="#131B4D" />
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>
                <%-- grid de Historial de llamadas--%>
                <div role="tabpanel" class="tab-pane" id="profile">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="Gridllamadas" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                        </asp:GridView>
                    </div>
                </div>
                <%-- grid de asignacion de coberturas del auto--%>
                <div role="tabpanel" class="tab-pane" id="coberturas">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridCoberturas" runat="server" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSourceCoberturas" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckCoberturas" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="descr" HeaderText="Descripcion" SortExpression="descr">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="limite1" HeaderText="Limite 1" SortExpression="limite1">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="limite2" HeaderText="Limite 2" SortExpression="limite2">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="deducible" HeaderText="Deducible" SortExpression="deducible">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Prima" HeaderText="Prima" SortExpression="prima">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
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
                <%--  opciones de checkobox--%>
                <div role="tabpanel" class="tab-pane" id="ingreso-datos">
                    <div class="panel-body form-inline">
                        <div style="height: 275px;" class="panel panel-info col-sm-12 col-md-3 col-lg-3">
                            <div class="panel-heading"><b style="font-size: 18px;">Selecciones</b></div>
                            <div class="panel-body">
                                <asp:CheckBox ID="checkPrioritario" Style="font-size: 18px;" runat="server" Text="Prioritario" />
                                <br />
                                <br />
                                <asp:CheckBox ID="CheckComplicado" Style="font-size: 18px;" runat="server" Text="Complicado" />
                                <br />
                                <br />
                                <asp:CheckBox ID="checkCompromiso" Style="font-size: 18px;" runat="server" Text="Compromiso De Pago" />
                            </div>
                        </div>
                        <div style="height: 275px;" class="panel panel-info col-sm-12 col-md-4 col-lg-4">
                            <div class="panel-heading"><b style="font-size: 18px;">Opciones Multiples</b></div>
                            <div class="panel-body">
                                <label style="width: 15%">Analista:</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlAnalista" Style="width: 80%" Height="34px" runat="server"></asp:DropDownList>
                                <br />
                                <br />
                                <label style="width: 15%">Taller:</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlTaller" Style="width: 80%" Height="34px" runat="server"></asp:DropDownList>
                                <br />
                                <br />
                                <label style="width: 15%">Gestor:</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlGestor" Style="width: 80%" Height="34px" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <%--Datos del contacto--%>
                        <div class="panel panel-info col-sm-12 col-md-5 col-lg-5" style="height: 275px;">
                            <div class="panel-heading"><b style="font-size: 18px;">Datos Contacto</b></div>
                            <div class="panel-body">
                                <div class="form-inline">
                                    <label for="message-text" class="control-label">Nombre Contacto:</label>
                                    <asp:TextBox ID="txtContacto" Style="width: 95%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                    <br />
                                    <br />
                                    <label for="message-text" class="control-label">Correo:</label>
                                    <asp:TextBox ID="txtCorreo" Style="width: 95%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                    <br />
                                    <br />
                                    <label for="message-text" class="control-label">Telefono:</label>
                                    <asp:TextBox ID="txtTelefono" MaxLength="8" Style="width: 95%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-inline col-sm-12 col-md-12 col-lg-12">
                        <asp:TextBox ID="txtObservaciones" Style="width: 50%" autocomplete="off" CssClass="form-control" TextMode="multiline" Columns="50" Rows="4" runat="server" placeholder="Observaciones" />
                        <asp:TextBox ID="txtComentarios" Style="width: 45%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="4" placeholder="Comentarios Del Reclamo" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox ID="txtNumReclamo" CssClass="form-control" placeholder="Numero de reclamo" Width="15%" runat="server"></asp:TextBox>
                        <asp:Button runat="server" Text="Guardar" ID="txtGuardar" class="btn btn-primary" OnClick="txtGuardar_Click" />
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSourceCoberturas" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [descr], [limite1], [limite2], [deducible], [prima], [sumaaseg] FROM [viewCoberturasAutos] where chasis= @chasis">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblChasis" Name="chasis" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content runat="server" id="Content3" ContentPlaceHolderID="ContentJs">
     <script>
        $('#<%=txtTelefono.ClientID%>').on('input', function () {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
    </script>
</asp:Content>





