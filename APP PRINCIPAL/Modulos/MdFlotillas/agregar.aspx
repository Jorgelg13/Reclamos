<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="agregar.aspx.cs" Inherits="Modulos_flotillas_agregar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
    <asp:Panel runat="server" ID="PnPrincipal" Visible="true">
         <div class="container-fluid">
            <div class="col-lg-4 col-md-3 col-sm-12">
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
                            <asp:TextBox runat="server" ID="txtPropietario" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="propietario"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-12 col-lg-6">
                            <asp:TextBox runat="server" ID="txtInciso" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="inciso"></asp:TextBox>
                        </div>
                         <div class="form-group col-sm-12 col-md-12 col-lg-6">
                            <asp:TextBox runat="server" ID="txtMarca" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="marca"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-12 col-lg-6">
                            <asp:TextBox runat="server" ID="txtLinea" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="linea"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-12 col-lg-6">
                            <asp:TextBox runat="server" ID="txtChasis" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="chasis"></asp:TextBox>
                        </div>
                          <div class="form-group col-sm-12 col-md-12 col-lg-6">
                            <asp:TextBox runat="server" ID="txtMotor" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="motor"></asp:TextBox>
                        </div>
                          <div class="form-group col-sm-12 col-md-12 col-lg-6">
                            <asp:TextBox runat="server" ID="txtAnio" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Año"></asp:TextBox>
                        </div>
                          <div class="form-group col-sm-12 col-md-12 col-lg-6">
                            <asp:TextBox runat="server" ID="txtColor" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="color"></asp:TextBox>
                        </div>
                          <div class="form-group col-sm-12 col-md-12 col-lg-6">
                            <asp:TextBox runat="server" ID="txtPlaca" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="placa"></asp:TextBox>
                        </div>
                          <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtAseguradora" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="aseguradora"></asp:TextBox>
                        </div>
                          <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtAsegurado" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="asegurado"></asp:TextBox>
                        </div>
                          <div class="form-group col-sm-12 col-md-12 col-lg-6">
                            <asp:TextBox runat="server" ID="txtPoliza" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="poliza"></asp:TextBox>
                        </div>
                          <div class="form-group col-sm-12 col-md-12 col-lg-6">
                            <asp:TextBox runat="server" ID="txtVigencia" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="vigencia"></asp:TextBox>
                        </div>
                          <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtEjecutivo" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="ejecutivo"></asp:TextBox>
                        </div>
                          <div class="form-group col-sm-12 col-md-12 col-lg-6">
                            <asp:TextBox runat="server" ID="txtCodigoInterno" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="codigo interno"></asp:TextBox>
                        </div>
                          <div class="form-group col-sm-12 col-md-12 col-lg-6">
                            <asp:TextBox runat="server" ID="txtPagador" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="pagador"></asp:TextBox>
                        </div>

                        <div class="form-group row col-md-3 col-lg-8">
                            <asp:LinkButton runat="server" Visible="false" ID="Actualizar" OnClick="Actualizar_Click" ToolTip="Actualizar registro" Style="font-size: 40px; text-align: center;"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>
                            <asp:LinkButton runat="server" enabled="false" ID="Guardar"  OnClick="Guardar_Click" ToolTip="Guardar registro"  Style="font-size: 40px; text-align: center;"><i class="fa fa-floppy-o"></i></asp:LinkButton>
                            <asp:LinkButton data-toggle="modal" data-target="#myModal" runat="server" Visible="false" ID="Borrar"  ToolTip="Eliminar registro" Style="font-size: 40px; text-align: center; color:red"><i class="fa fa-trash"></i></asp:LinkButton>                        
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-8 col-md-9 col-sm-12">
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
