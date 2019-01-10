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
                        <asp:GridView ID="GridElRoble" CssClass="table bs-table table-responsive" OnSelectedIndexChanged="GridElRoble_SelectedIndexChanged" runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
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
            <div role="tabpanel" class="tab-pane" id="todasPolizas">
                <div class="row">
                    <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 0px;">
                        <asp:GridView ID="GridAllPolizas" CssClass="table bs-table table-responsive" 
                            runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridAllPolizas_SelectedIndexChanged">
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
                <asp:LinkButton ID="lnkGuardar" OnClick="lnkGuardar_Click" title="Enviar Correo" runat="server" Style="font-size:40px; padding-left:20px;"><i class="fa fa-envelope-o"></i></asp:LinkButton>
            </div>
        </div>
    </div>
     <%-- botones circulares con las opciones multiples --%>
    <div id="container-floating">
        <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
            <asp:LinkButton ID="btnGuardarCambios" title="Enviar" CssClass="letter" autopostback="true" runat="server" OnClick="btnGuardarCambios_Click"><i class="fa fa-envelope-o" aria-hidden="true"></i></asp:LinkButton>
        </div>
        <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
            <p class="plus">+</p>
            <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
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
    </script>
</asp:Content>