<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Copagos.aspx.cs" Inherits="Modulos_MdReclamos_Copagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class="container-fluid">
        <div class="col-lg-3">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><b style="font-size: 16px;">Agregar Nuevo Archivo</b></h3>
                </div>
                <div class="panel-body">
                    <div class="form-inline">
                        <asp:TextBox CssClass="form-control" Style="width: 70%" runat="server" ID="txtbuscar"></asp:TextBox>
                        <asp:Button CssClass="btn btn-primary" runat="server" ID="buscar" Text="Buscar" OnClick="buscar_Click" />
                    </div>
                    <br />
                    <div class="form-group col-sm-12 col-md-12 col-lg-12">
                        <asp:TextBox runat="server" ID="txtNombre" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="nombre"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:FileUpload ID="SubirArchivo" runat="server" />
                    </div>
                    <div class="col-md-2">
                        <asp:LinkButton runat="server" Visible="false" ID="Actualizar" ToolTip="" Style="font-size: 40px; text-align: center;"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></asp:LinkButton>
                        <asp:LinkButton runat="server" ID="Guardar" OnClick="btnSubir_Click" ToolTip="Guardar Archivo" Style="font-size: 40px; text-align: center;"><i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-9">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><b style="font-size: 16px;">Listado de copagos</b></h3>
                </div>
                <div class="panel-body" style="height: 545px; padding: 0px;">
                    <div class="scrolling-table-container" style="overflow-y: auto; height: auto; max-height: 529px;">
                        <asp:GridView ID="GridCopagos" runat="server" CssClass="table table-responsive table-hover" AutoGenerateColumns="True" GridLines="None"
                            AllowCustomPaging="True" AllowPaging="True" PageSize="300" OnSelectedIndexChanged="GridCopagos_SelectedIndexChanged" OnRowDeleting="GridCopagos_RowDeleting">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText=" Borrar" ControlStyle-CssClass="fa fa-trash"  ControlStyle-ForeColor="Red" HeaderText="Eliminar" />
                                <asp:CommandField ShowDeleteButton="True" DeleteText="Ver"  HeaderText="Ver Archivo" />
                            </Columns>
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Left" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="validacion">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header text-center">
                    <h4 class="modal-title"><b>Desea borrar el registro..</b></h4>
                    <br/>
                </div>
                <div class="modal-body text-center">
                    <h2><asp:Label runat="server" ID="lblRegistro"></asp:Label></h2>
                </div>
                <div class="modal-footer text-center">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnBorrar" CssClass="btn btn-primary" runat="server" Text="Borrar" OnClick="btnBorrar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentJS" runat="Server">
    <script>
        try {
            $('#FeaturedContent_GridCopagos tr').each(function (index) {
                $tr = $(this);
                $td = $tr[0].cells[2];
                $td.remove();
            });
        } catch (ex) {
        }
    </script>
</asp:Content>

