<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbAsegurados.aspx.cs" Inherits="Modulos_MdCatalogos_wbAsegurados" %>

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
                            <asp:TextBox CssClass="form-control" Style="width: 70%" runat="server" ID="txtbuscar"></asp:TextBox>
                            <asp:Button CssClass="btn btn-primary" runat="server" ID="buscar" OnClick="buscar_Click" Text="Buscar" />
                        </div>
                        <br />
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtPoliza" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Poliza"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtEjecutivo" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Ejecutivo"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtAsegurado" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Asegurado"></asp:TextBox>
                        </div>
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:TextBox runat="server" ID="txtCarne" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="No. Carné"></asp:TextBox>
                        </div>
                         <div  class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:DropDownList ID="ddlParentesco" CssClass="form-control" Style="width: 100%" runat="server">
                               <asp:ListItem Value ="Titular">Titular</asp:ListItem>
                               <asp:ListItem Value ="Conyuge">Conyuge</asp:ListItem>
                               <asp:ListItem Value ="Hijo">Hijo</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div  class="form-group col-sm-12 col-md-12 col-lg-12">
                            <asp:DropDownList ID="ddlEstado" CssClass="form-control" Style="width: 100%" runat="server">
                               <asp:ListItem Value ="true">Activo</asp:ListItem>
                               <asp:ListItem Value ="false">Inactivo</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton runat="server" Visible="false" ID="Actualizar" OnClick="Actualizar_Click" ToolTip="Actualizar Registro" Style="font-size: 40px; text-align: center;"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>
                            <asp:LinkButton runat="server" enabled="false" ID="Guardar"  OnClick="Guardar_Click" ToolTip="Guardar registro"  Style="font-size: 40px; text-align: center;"><i class="fa fa-floppy-o"></i></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-9 col-md-9 col-sm-12">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h3 class="panel-title"><b style="font-size:16px;">Asegurados</b></h3>
                    </div>
                    <div class="panel-body" style="height: 430px;">
                        <div class="scrolling-table-container" style="overflow-y: auto;">
                            <asp:GridView ID="gridAsegurados" runat="server" CssClass="table table-responsive table-hover" OnSelectedIndexChanged="gridAsegurados_SelectedIndexChanged" AutoGenerateColumns="True" GridLines="None" 
                                AllowCustomPaging="True" AllowPaging="True" PageSize="300">
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
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentJs" Runat="Server">
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

