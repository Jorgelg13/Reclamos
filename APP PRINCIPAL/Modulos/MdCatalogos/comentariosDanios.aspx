<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="comentariosDanios.aspx.cs" Inherits="Modulos_MdCatalogos_comentariosDanios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:Panel runat="server" ID="PnPrincipal" Visible="false">
        <div class="container-fluid">
            <div class="col-lg-3 col-md-3 col-sm-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h3 class="panel-title"><b style="font-size: 16px;">Buscar Reclamo</b></h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-inline">
                            <asp:TextBox CssClass="form-control" type="number" Style="width: 70%" runat="server" ID="txtbuscar" Text="0"></asp:TextBox>
                            <asp:Button CssClass="btn btn-primary" runat="server" ID="busca" Text="Buscar" OnClick="busca_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-9 col-md-9 col-sm-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h3 class="panel-title"><b style="font-size: 16px;">Comentarios</b></h3>
                    </div>
                    <div class="panel-body" style="height: 430px;">
                        <div class="scrolling-table-container" style="overflow-y: auto;">
                            <asp:GridView ID="gridComentarios" runat="server" CssClass="table table-responsive table-hover" OnSelectedIndexChanged="gridComentarios_SelectedIndexChanged" 
                                OnRowDataBound="gridComentarios_RowDataBound" AutoGenerateColumns="True" GridLines="None" PageSize="300">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" HeaderText="Seleccionar" />
                                </Columns>
                                <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle HorizontalAlign="Left" Wrap="True" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal fade" id="ModalComentario" data-keyboard="false" data-backdrop="static">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title"><b>Editar Comentario</b></h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label>Comentario:</label>
                                <asp:TextBox ID="txtComentario" Style="width: 99%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="15" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="btnGuardarComentario" CssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="btnGuardarComentario_Click"/>
                            <asp:Button ID="btnEliminar" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentJs" Runat="Server">
</asp:Content>

