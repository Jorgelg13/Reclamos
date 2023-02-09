<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="formulario-enrolamiento.aspx.cs" Inherits="Modulos_MdReclamos_formulario_enrolamiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
        <div class="container-fluid">
        <div class="col-lg-3">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><b style="font-size: 16px;">Agregar Nueva Carpeta</b></h3>
                </div>
                <div class="panel-body">
                     <div class="form-inline col-sm-12 col-md-12 col-lg-12">
                        <asp:DropDownList ID="ddlAseguradoras" runat="server" CssClass="form-control" style="width:60%">
                        </asp:DropDownList>
                        <asp:Button CssClass="btn btn-primary" runat="server" ID="Guardar" Text="Crear Carpeta" OnClick="Guardar_Click" />

                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-9">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><b style="font-size: 16px;">Listado de archivos por aseguradora</b></h3>
                </div>
                <div class="panel-body" style="height: 600px; padding:20px;">
                    <div class="scrolling-table-container" style="overflow-y: auto; height: auto;">
                        
                          <div class="form-inline col-lg-12">
                                <asp:FileUpload ID="SubirArchivo" runat="server" />
                                <asp:LinkButton runat="server" ID="GuardarArchivo" OnClick="btnSubir_Click" ToolTip="Guardar Archivo" Style="font-size: 30px;"><i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
                            </div>
                       <div class="col-lg-4">
                            <asp:GridView ID="GridCarpetas" runat="server" CssClass="table table-responsive table-hover" AutoGenerateColumns="True" GridLines="None"
                             PageSize="300" OnSelectedIndexChanged="GridCarpetas_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
                            </Columns>
                            <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Left" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                       </div>
                        <div class="col-lg-8">
                              <asp:GridView ID="GridArchivos" runat="server" CssClass="table table-responsive table-hover" AutoGenerateColumns="True" GridLines="None"
                            AllowCustomPaging="True" AllowPaging="True" PageSize="300" OnSelectedIndexChanged="GridCopagos_SelectedIndexChanged" OnRowDeleting="GridCopagos_RowDeleting">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText=" Borrar" ControlStyle-CssClass="fa fa-trash"  ControlStyle-ForeColor="Red" HeaderText="Eliminar" />
                                <asp:CommandField ShowDeleteButton="True" DeleteText="Ver"  HeaderText="Ver Archivo" />
                            </Columns>
                            <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Left" Wrap="False" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                        </div>
                      
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
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentJS" Runat="Server">
      <script>
        try {
            $('#FeaturedContent_GridCarpetas tr').each(function (index) {
                $tr = $(this);
                $tr2 = $(this);
                $td = $tr[0].cells[2];
                $td2 = $tr2[0].cells[1];
                $td.remove();
                $td2.remove();
            });
        } catch (ex) {
          }

          try {
              $('#FeaturedContent_GridArchivos tr').each(function (index) {
                  $tr = $(this);
                  $td = $tr[0].cells[2];
                  $td.remove();
              });
          } catch (ex) {
          }
      </script>
</asp:Content>

