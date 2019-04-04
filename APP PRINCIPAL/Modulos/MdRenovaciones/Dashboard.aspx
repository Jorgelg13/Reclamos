<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Renovaciones.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Modulos_MdRenovaciones_Dashboard" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active">
                <a href="#elRoble" aria-controls="elRoble" role="tab" data-toggle="tab">Polizas Roble
                </a>
            </li>
            <li role="presentation">
                <a href="#todasPolizas" aria-controls="todasPolizas" role="tab" data-toggle="tab">Todas las Polizas
                </a>
            </li>
        </ul>
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane active" id="elRoble">
                <div class="row">
                    <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 15px;">
                        <asp:GridView ID="GridElRoble" CssClass="table bs-table table-responsive" OnSelectedIndexChanged="GridElRoble_SelectedIndexChanged" OnRowDeleting="GridElRoble_RowDeleting" runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                            <Columns>
                              <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
                              <asp:CommandField ShowDeleteButton="True" DeleteText="" ControlStyle-CssClass="fa fa-ban" ControlStyle-ForeColor="Red" HeaderText="Invalidar"/>
                              <asp:CommandField ShowEditButton="True"   EditText=""  ControlStyle-CssClass="fa fa-search btnRevisarPoliza" HeaderText=" Revisar"/>

                            </Columns>
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" Wrap="false" />
                            <PagerStyle BackColor="#131B4D" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="White" Wrap="false" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div role="tabpanel" class="tab-pane" id="todasPolizas">
                <div class="row">
                    <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 0px;">
                        <asp:GridView ID="GridAllPolizas" CssClass="table bs-table table-responsive" 
                            runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
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
               
                <div class="modal-footer">
                  <div class="form-inline">
                   <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" placeholder="Celular"></asp:TextBox>
                   <asp:LinkButton ID="lnkGuardar" OnClick="lnkGuardar_Click" title="Enviar Correo" runat="server" Style="font-size:40px; padding-left:20px;"><i class="fa fa-envelope-o"></i></asp:LinkButton>
                </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Js" runat="server" ContentPlaceHolderID="contentJS">
    <script>
         $('#summernote').html($('#ContentPlaceHolder1_txtCuerpo').val());
         $('#summernote').summernote();

         $('.note-editable').keyup(function () { 
             $('#<%=txtCuerpo.ClientID%>').val($('.note-editable').html());
        });

        $('.btnRevisarPoliza').attr('href', "javascript:void(0)");

        $('.btnRevisarPoliza').on('click', function () {
            $tr = $(this).closest('tr')[0].cells;
            $poliza = $tr[5].innerText + $tr[4].innerText + $tr[6].innerText + ".pdf";
            window.open('http://52.34.115.100:5556/files/RenovacionesElRoble/OneDrive%20-%20Unity%20Seguros/Renovaciones/Polizas/' + $poliza, '_blank');
        });
    </script>
</asp:Content>