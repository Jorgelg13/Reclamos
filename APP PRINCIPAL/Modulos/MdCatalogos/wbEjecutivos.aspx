<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbEjecutivos.aspx.cs" Inherits="Modulos_MdCatalogos_wbEjecutivos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Panel runat="server" ID="PnPrincipal" Visible="true">
         <div class="container-fluid">
            <div class="col-lg-3">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h3 class="panel-title"><b style="font-size: 16px;">Buscar y Actualizar</b></h3>
                    </div>
                    <div class="panel-body">
                        <div class="form-inline">
                            <asp:TextBox CssClass="form-control" Style="width: 70%" runat="server" ID="txtbuscar"></asp:TextBox>
                            <asp:Button CssClass="btn btn-primary" runat="server" ID="buscar" OnClick="buscar_Click" Text="Buscar" />
                        </div>
                        <br />
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtGestor" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Gestor"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtCodigo" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="codigo"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtCorreo" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="correo"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtTelefono" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="telefono"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton runat="server" Visible="false" ID="Actualizar" OnClick="Actualizar_Click" ToolTip="Actualizar ejecutivo" Style="font-size: 40px; text-align: center;"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="Guardar" ToolTip="Guardar ejecutivo" OnClick="Guardar_Click"  Style="font-size: 40px; text-align: center;"><i class="fa fa-floppy-o" aria-hidden="true"></i></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-9">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h3 class="panel-title"><b style="font-size:16px;">Ejecutivos</b></h3>
                    </div>
                    <div class="panel-body" style="height: 430px;">
                        <div class="scrolling-table-container" style="overflow-y: auto;">
                            <asp:GridView ID="GridEjecutivos" runat="server" CssClass="table table-responsive table-hover" OnSelectedIndexChanged="GridGeneral_SelectedIndexChanged" AutoGenerateColumns="True" GridLines="None" AllowCustomPaging="True" AllowPaging="True" PageSize="300">
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
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentJs" ID="JS">
    <script>
        try {
            $('#ContentPlaceHolder1_GridAseguradoras tr').each(function (index) {
                $tr = $(this);
                   $td = $tr[0].cells[1];
                   $td.remove();
            });
        } catch (ex) {
        }
    </script>
</asp:Content>


