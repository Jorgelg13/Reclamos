<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Renovaciones.master" AutoEventWireup="true" CodeFile="correo.aspx.cs" Inherits="Modulos_MdRenovaciones_Catalogo_correo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Panel runat="server" ID="PnPrincipal" Visible="true">
         <div class="container-fluid">
            <div class="col-lg-4">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h3 class="panel-title"><b style="font-size: 16px;">Editar</b></h3>
                    </div>
                    <div class="panel-body">
                        <br />
                         <div class="scrolling-table-container" style="overflow-y: auto;">
                            <asp:GridView ID="GridContenido" runat="server" CssClass="table table-responsive table-hover" OnSelectedIndexChanged="GridContenido_SelectedIndexChanged" AutoGenerateColumns="True" GridLines="None" AllowCustomPaging="True" AllowPaging="True" PageSize="300">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="Editar">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:CommandField>
                                </Columns>
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle HorizontalAlign="Left" Wrap="False" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton runat="server" ID="Guardar" OnClick="Guardar_Click" ToolTip="Guardar Contenido"  Style="font-size: 40px; text-align: center;"><i class="fa fa-floppy-o"></i></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-8">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h3 class="panel-title"><b style="font-size:16px;">Contenido</b></h3>
                    </div>
                     <asp:TextBox Style="display: none" runat="server" ID="txtCuerpo"></asp:TextBox>
                     <div id="summernote" class="panel-body" style="height: 430px;">
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentJS" Runat="Server">
    <script>
         $('#summernote').html($('#ContentPlaceHolder1_txtCuerpo').val());
        $('#summernote').summernote();

        $('.note-editable').keyup(function () {
            $('#<%=txtCuerpo.ClientID%>').val($('.note-editable').html());
        });
    </script>
</asp:Content>

