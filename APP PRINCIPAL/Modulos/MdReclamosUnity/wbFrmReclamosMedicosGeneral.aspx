﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="wbFrmReclamosMedicosGeneral.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmReclamosMedicosGeneral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading">Listado De Reclamos En General Pendientes De Cerrar.</div>
            <div class="panel-body">
                <div class="scrolling-table-container">
                    <asp:GridView ID="GridGeneral" runat="server" CssClass="table table-responsive table-hover" AutoGenerateColumns="True" CellPadding="4" GridLines="None" OnSelectedIndexChanged="GridGeneral_SelectedIndexChanged" OnRowDataBound="GridGeneral_RowDataBound" PageSize="3000">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:CommandField>
                        </Columns>
                        <FooterStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </div>
      <asp:LinkButton ID="linkDescargar"  OnClick="linkDescargar_Click" title="Descargar en excel" runat="server" Style="font-size: 70px; text-align: center; color:green"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
    </div>
</asp:Content>

