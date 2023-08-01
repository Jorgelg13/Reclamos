<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="agregar.aspx.cs" Inherits="Modulos_flotillas_agregar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel runat="server" ID="PnPrincipal" Visible="true">
         <div class="container-fluid">
            <div class="col-lg-3 col-md-3 col-sm-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h3 class="panel-title"><b style="font-size: 16px;">Buscar y Actualizar</b></h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-inline">
                            <asp:TextBox CssClass="form-control" Style="width: 70%" runat="server" ID="txtbuscar" placeholder="buscar por placa"></asp:TextBox>
                            <asp:Button CssClass="btn btn-primary" runat="server" ID="buscar" OnClick="buscar_Click" Text="Buscar" />
                        </div>
                        <br />
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtNombreAsegurado" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Asegurado"></asp:TextBox>
                        </div>
                         <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtPoliza" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="poliza"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtModelo" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="modelo"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtMarca" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="marca"></asp:TextBox>
                        </div>
                          <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtLinea" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="linea"></asp:TextBox>
                        </div>
                          <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtPlaca" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="placa"></asp:TextBox>
                        </div>
                        <div class="form-inline">
                            <asp:Button CssClass="btn btn-primary" runat="server" ID="Guardar" OnClick="Guardar_Click" Text="Guardar" />
                            <asp:Button CssClass="btn btn-primary" runat="server" Visible="false" ID="Actualizar" OnClick="Actualizar_Click" Text="Actualizar" />
                            <%--<asp:LinkButton runat="server" Visible="false" ID="Actualizar" OnClick="Actualizar_Click" ToolTip="Actualizar registro" Style="font-size: 40px; text-align: center;"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>--%>
                            <%--<asp:LinkButton runat="server" enabled="false" ID="Guardar"  OnClick="Guardar_Click" ToolTip="Guardar registro"  Style="font-size: 40px; text-align: center;"><i class="fa fa-floppy-o"></i></asp:LinkButton>--%>
                            <asp:LinkButton data-toggle="modal" data-target="#myModal" runat="server" Visible="false" ID="Borrar"  ToolTip="Eliminar registro" Style="font-size: 40px; text-align: center; color:red"><i class="fa fa-trash"></i></asp:LinkButton>                        
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-9 col-md-9 col-sm-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h3 class="panel-title"><b style="font-size:16px;">Autos</b></h3>
                    </div>
                    <div class="panel-body" style="height: 430px;">
                        <div class="scrolling-table-container" style="overflow-y: auto;">
                            <asp:GridView ID="gridAutos" runat="server" CssClass="table table-responsive table-hover" OnSelectedIndexChanged="gridAutos_SelectedIndexChanged" AutoGenerateColumns="True" GridLines="None" AllowCustomPaging="True" AllowPaging="True" PageSize="300">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="Editar">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:CommandField>
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
              <div class="container">
                            <div class="modal fade" id="myModal">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h4 class="modal-title"><b>Confirmacion</b></h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>Esta seguro que desea eliminar este registro</p>
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button ID="btnEliminar" CssClass="btn btn-primary" runat="server" Text="Si" OnClick="btnEliminar_Click" />
                                            <asp:Button ID="btnCancelar" CssClass="btn btn-warning" runat="server" Text="No" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>         
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentJs" ID="JS">
    <script>
        try {
            $('#ContentPlaceHolder1_gridEstados tr').each(function (index) {
                $tr = $(this);
                   $td = $tr[0].cells[1];
                   $td.remove();
            });
        } catch (ex) {
        }
    </script>
</asp:Content>
