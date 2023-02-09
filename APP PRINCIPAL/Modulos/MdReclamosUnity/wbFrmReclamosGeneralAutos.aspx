<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="wbFrmReclamosGeneralAutos.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmReclamosGeneralAutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading">Listado De Reclamos En General Pendientes De Cerrar</div>
            <div class="panel-body">
                <div class="scrolling-table-container">
                    <asp:GridView ID="GridGeneral" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridGeneral_SelectedIndexChanged" AllowCustomPaging="True" AllowPaging="True" PageSize="3000">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:CommandField>
                        </Columns>
                        <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </div>
         <asp:LinkButton ID="linkDescargar" OnClick="linkDescargar_Click" title="Descargar en excel" runat="server" Style="font-size: 70px; text-align: center; color:green"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
    </div>
</asp:Content>

