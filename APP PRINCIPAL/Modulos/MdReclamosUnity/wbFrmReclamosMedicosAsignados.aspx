<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbFrmReclamosMedicosAsignados.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmReclamosMedicosAsignados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class ="container-fluid">
          <div class="panel panel-info">
            <div class="panel-heading"><b>Listado De Reclamos Medicos Asignados</b></div>
              <div class="panel-body">
                 <div class="scrolling-table-container">
                     <asp:GridView ID="GridMedicosAsignados" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridMedicosAsignados_SelectedIndexChanged">
                         <AlternatingRowStyle BackColor="White" />
                         <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:CommandField>
                        </Columns>
                         <EditRowStyle BackColor="#2461BF" />
                         <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                         <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Wrap="True" />
                         <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                         <SortedAscendingCellStyle BackColor="#F5F7FB" />
                         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                         <SortedDescendingCellStyle BackColor="#E9EBEF" />
                         <SortedDescendingHeaderStyle BackColor="#4870BE" />
                     </asp:GridView>
                 </div>
              </div>
          </div>
    </div>
</asp:Content>

