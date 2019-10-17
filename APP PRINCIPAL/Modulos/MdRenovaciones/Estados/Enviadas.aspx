<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Renovaciones.master" AutoEventWireup="true" CodeFile="Enviadas.aspx.cs" Inherits="Modulos_MdRenovaciones_Estados_Enviadas" EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading"><b>Polizas Enviadas</b></div>
            <div class="panel-body">
                <div class="form-group  col-sm-12 col-md-6 col-lg-2" style="padding-top: 10px;">
                    <label>Desde:</label>
                    <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                </div>
                <div class="form-group  col-sm-12 col-md-6 col-lg-2" style="padding-top: 10px;">
                    <label>Hasta:</label>
                    <asp:TextBox ID="txtFechaFin" type="date" Height="34px" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                </div>
                <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 0px;">
                    <asp:GridView ID="GridEnviadas" CssClass="table bs-table table-responsive" runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                        <Columns>
                            <asp:TemplateField HeaderText="Seleccionar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkCancelar" runat="server" Text="Cancelar" AutoPostBack="true" OnCheckedChanged="chkCancelar_CheckedChanged" />
                                    <asp:CheckBox ID="chkRenovar" runat="server" Text="Renovar" AutoPostBack="true" OnCheckedChanged="chkRenovar_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" Wrap="false" />
                        <PagerStyle BackColor="#131B4D" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" Wrap="false" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" tabindex="-1" role="dialog" id="comentario" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Agregar informacion para la poliza</h4>
                </div>
                <div class="modal-body">
                    <asp:TextBox runat="server" ID="txtComentario" CssClass="form-control"  TextMode="multiline" Columns="75" Rows="10" placeholder="Agregar detalle"></asp:TextBox>
                    <asp:Label runat="server" ID="lblId"></asp:Label>
                </div>
                <div class="modal-footer">
                     <asp:Button runat="server" ID="btnCerrar" class="btn btn-defautl"  Text="Cerrar" OnClick="btnCerrar_Click"/>
                    <asp:Button runat="server" ID="btnGuardar" class="btn btn-primary"  Text="Guardar" OnClick="btnGuardar_Click"/>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
    <%-- botones circulares con las opciones multiples --%>
    <div id="container-floating">
        <div class="nd4 nds" data-toggle="tooltip" data-placement="left" data-original-title="contract@gmail.com">
            <asp:LinkButton ID="btnExportar" title="Exportar a excel" CssClass="letter" runat="server" OnClick="btnExportar_Click"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
        </div>
        <div class="nd3 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
            <asp:LinkButton ID="btnGenerarTabla" title="Buscar Datos" CssClass="letter" autopostback="true" runat="server" OnClick="btnGenerarTabla_Click"><i class="fa fa-table"></i></asp:LinkButton>
        </div>
        <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
            <asp:LinkButton ID="btnGuardarCambios" title="Guardar" CssClass="letter" autopostback="true" runat="server"><i class="fa fa-save"></i></asp:LinkButton>
        </div>
        <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
            <p class="plus">+</p>
            <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentJS" runat="Server">
</asp:Content>

