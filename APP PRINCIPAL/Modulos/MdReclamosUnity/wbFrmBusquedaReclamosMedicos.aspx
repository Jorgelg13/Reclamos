<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbFrmBusquedaReclamosMedicos.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmBusquedaReclamosMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading"><b>Busqueda De Reclamos</b></div>
            <div class="panel-body">
                <div class=" form-inline">
                    <div class="form-group col-lg-3 col-md-3 col-sm-12">
                        <label>Poliza</label>
                        <asp:TextBox runat="server" autocomplete="off" ID="txtBusqueda" Style="width: 100%" class="form-control" placeholder="Poliza"></asp:TextBox>
                    </div>
                    <div class="form-group col-lg-3 col-md-3 col-sm-12">
                        <label>Asegurado</label>
                        <asp:TextBox runat="server" autocomplete="off" ID="txtAsegurado" Style="width: 100%" class="form-control" placeholder="Nombre de asegurado" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="form-group col-lg-3 col-md-3 col-sm-12">
                        <label>Tipo Busqueda</label>
                        <asp:DropDownList CssClass="form-control" ID="DDLTipo" Style="width: 70%" Height="34px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLTipo_SelectedIndexChanged">
                            <asp:ListItem Value="dbo.reg_reclamos_medicos.poliza">Poliza</asp:ListItem>
                            <asp:ListItem Value="dbo.reclamos_medicos.asegurado">Asegurado</asp:ListItem>
                            <asp:ListItem Value="ambos">Ambos</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button runat="server" Text="Buscar" ID="btnBuscar" class="btn btn-primary" OnClick="btnBuscar_Click" />
                    </div>
                </div>
            </div>
            <div class="scrolling-table-container">
                <asp:GridView ID="GridBusquedaGeneral" EmptyDataText="No se encontro ese registro" runat="server" AllowPaging="true" CssClass="table bs-table table-responsive"
                    AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="500" OnSelectedIndexChanged="GridBusquedaGeneral_SelectedIndexChanged"
                    OnRowDataBound="GridBusquedaGeneral_RowDataBound" ShowFooter="true">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True">
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:CommandField>
                    </Columns>
                    <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
            </div>
        </div>
        <hr style="border:solid 0.5px;" />
        <div class="col-lg-4" style="text-align:center">
            <asp:Label CssClass="label label-info" runat="server" ID="lblMontoReclamado" Font-Size="X-Large"></asp:Label>
        </div>
        <div class="col-lg-4" style="text-align:center" >
            <asp:Label CssClass="label label-info" runat="server" ID="lblTotalAprobado" Font-Size="X-Large"></asp:Label>
        </div>
        <div class="col-lg-4" style="text-align:center">
            <asp:Label CssClass="label label-info" runat="server" ID="lblDeducible" Font-Size="X-Large"></asp:Label>
        </div>
    </div>
</asp:Content>

