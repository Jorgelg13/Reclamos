<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Implants.master" AutoEventWireup="true" CodeFile="asegurados.aspx.cs" Inherits="Implants_asegurados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="col-lg-3 col-md-3 col-sm-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><b style="font-size: 16px;">Agregar Registro</b></h3>
                </div>
                <div class="panel-body">
                    <div class="form-group col-sm-12 col-md-12 col-lg-12">
                        <asp:TextBox runat="server" ID="txtNombre" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Nombre asegurado"></asp:TextBox>
                    </div>
                    <div class="form-group col-sm-12 col-md-12 col-lg-12">
                        <asp:TextBox runat="server" ID="txtEmail" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="email"></asp:TextBox>
                    </div>
                    <div class="form-group col-sm-12 col-md-12 col-lg-12">
                        <asp:TextBox runat="server" ID="txtTelefono" MaxLength="8" autocomplete="off" type="number" Style="width: 100%" CssClass="form-control" placeholder="telefono"></asp:TextBox>
                    </div>
                     <div class="form-group col-sm-12 col-md-12 col-lg-12">
                        <asp:DropDownList ID="ddlEmpresa" runat="server" CssClass="form-control" Style="width: 100%">
                        </asp:DropDownList>
                    </div>
                     <div class="form-group col-sm-12 col-md-12 col-lg-12">
                        <asp:DropDownList ID="ddlMotivo" CssClass="form-control" Style="width: 100%" runat="server">
                            <asp:ListItem Value="">Seleccione Opcion</asp:ListItem>
                            <asp:ListItem Value="Coberturas y  Beneficios">Coberturas y Beneficios</asp:ListItem>
                            <asp:ListItem Value="Coberturas y  Beneficios">Coberturas y  Beneficios</asp:ListItem>
                            <asp:ListItem Value="Procedimientos, Autorización, Reclamos, Proveedores, Formularios de Reclamación">Procedimientos, Autorización, Reclamos, Proveedores, Formularios de Reclamación</asp:ListItem>
                            <asp:ListItem Value="Adición, Baja de Dependientes, Cambio Beneficiario, Formularios ">Adición,  Baja de Dependientes, Cambio Beneficiario, Formularios </asp:ListItem>
                            <asp:ListItem Value="Otros seguros">Otros seguros</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group col-sm-12 col-md-12 col-lg-12">
                        <asp:TextBox runat="server" ID="txtObservaciones" TextMode="multiline" Columns="5" Rows="5" Style="width: 100%" autocomplete="off" CssClass="form-control" placeholder="Observaciones"></asp:TextBox>
                    </div>
                    <div>
                        <asp:LinkButton runat="server" ID="GuardarConsulta" OnClick="GuardarConsulta_Click" ToolTip="Guardar Consulta" Style="font-size: 40px;padding-left:20px"><i class="fa fa-floppy-o"></i></asp:LinkButton>
                        <asp:LinkButton runat="server"  ID="CerrarConsulta" OnClick="CerrarConsulta_Click" ToolTip="Cerrar Consulta" Style="font-size: 40px;padding-left:10px"><i class="fa fa-lock"></i></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-9 col-md-9 col-sm-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><b style="font-size: 16px;">Registros</b></h3>
                </div>
                <div class="panel-body" style="height: 430px;">
                    <div class="scrolling-table-container" style="overflow-y: auto;">
                        <asp:GridView ID="GridRegistros" runat="server" CssClass="table table-responsive table-hover" AutoGenerateColumns="True" GridLines="None" AllowCustomPaging="True" PageSize="300">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                              <asp:TemplateField HeaderText="Cerrar Consulta">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chConsulta" runat="server" Text="Cerrar" />
                                </ItemTemplate>
                              </asp:TemplateField>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentJS" runat="Server">
</asp:Content>

