<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Renovaciones.master" AutoEventWireup="true" CodeFile="NoEnviadas.aspx.cs" Inherits="Modulos_MdRenovaciones_Estados_NoEnviadas" EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="col-lg-9 col-md-9 col-sm-12">
            <div class="panel panel-info">
                <div class="panel-heading"><b>Polizas No Enviadas</b></div>
                <div class="panel-body">
                    <div class="form-group  col-sm-12 col-md-6 col-lg-2" style="padding-top: 10px;">
                        <label>Desde:</label>
                        <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group  col-sm-12 col-md-6 col-lg-2" style="padding-top: 10px;">
                        <label>Hasta:</label>
                        <asp:TextBox ID="txtFechaFin" type="date" Height="34px" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                    </div>
                    <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 0px;">
                        <asp:GridView ID="GridNoEnviadas" CssClass="table bs-table table-responsive" OnSelectedIndexChanged="GridNoEnviadas_SelectedIndexChanged" runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="Editar" />
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
        <div class="col-lg-3 col-md-3 col-sm-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><b style="font-size: 16px;">Actualizar Correo</b></h3>
                </div>
                <div class="panel-body">
                    <br />
                    <div class="form-group col-sm-12 col-md-12 col-lg-12">
                        <asp:TextBox runat="server" ID="txtCorreo" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Correo Electronico"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <a title="Actualizar y enviar" data-toggle="modal" role="button" Style="font-size: 40px"; data-target="#ModalCorreo"><i class="fa fa-floppy-o"></i></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- botones circulares con las opciones multiples --%> 
    <div id="container-floating">
        <div class="nd4 nds" data-toggle="tooltip" data-placement="left" data-original-title="contract@gmail.com">
            <asp:LinkButton ID="btnExportar" title="Exportar a excel" CssClass="letter" runat="server" OnClick="btnExportar_Click"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
        </div>
        <div class="nd3 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
            <asp:LinkButton ID="btnGenerarTabla" title="Buscar Datos" CssClass="letter" autopostback="true" runat="server" OnClick="btnGenerarTabla_Click"><i class="fa fa-table" aria-hidden="true"></i></asp:LinkButton>
        </div>
         <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
            <asp:LinkButton ID="btnGuardarCambios" title="Guardar" CssClass="letter" autopostback="true" runat="server"><i class="fa fa-save" aria-hidden="true"></i></asp:LinkButton>
        </div>
        <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
            <p class="plus">+</p>
            <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
        </div>
    </div>
      <%--------------------------  modal para enviar correos electronicos a los clientes ---------------------------------%>
    <div class="modal fade" id="ModalCorreo" data-keyboard="false" data-backdrop="static" style="overflow-y:auto">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span>&times;</span></button>
                    <h4 class="modal-title" id="imprimircarta"><b>Envio de correo electronico</b></h4>
                </div>
                <asp:TextBox  style="display:none" runat="server" ID="txtCuerpo"></asp:TextBox>
                <div id="summernote" class="modal-body">
                </div>
                <div class="form-inline">
                   <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" placeholder="Celular"></asp:TextBox>
                   <asp:LinkButton ID="lnkGuardar" OnClick="lnkGuardar_Click" title="Enviar Correo" runat="server" Style="font-size:40px; padding-left:20px;"><i class="fa fa-envelope-o"></i></asp:LinkButton>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentJS" runat="Server">
        <script>
         $('#summernote').html($('#ContentPlaceHolder1_txtCuerpo').val());
         $('#summernote').summernote();

         $('.note-editable').keyup(function () { 
             $('#<%=txtCuerpo.ClientID%>').val($('.note-editable').html());
         });
    </script>
</asp:Content>

