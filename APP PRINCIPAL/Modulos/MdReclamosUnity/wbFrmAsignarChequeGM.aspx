<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbFrmAsignarChequeGM.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmAsignarChequeGM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading">Listado De Reclamos Pendientes de ingresar cheque</div>
            <div class="panel-body">
                <div class="scrolling-table-container">
                    <asp:GridView ID="GridGeneral" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True" GridLines="None" OnSelectedIndexChanged="GridGeneral_SelectedIndexChanged" PageSize="3000">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:CommandField>
                        </Columns>
                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <%-- modal para verificacion de envio de correo --%>
    <div class="modal fade" id="ingresar-cheque">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title"><b>Ingreso De Cheque..</b></h4>
                </div>
                <div class="modal-body form-inline">
                          <div class="form-group" style="width: 33%">
                            <label>Monto del cheque:</label>
                            <asp:TextBox ID="txtMontoCheque" Text="0.00" Style="width: 100%" CssClass="form-control" AutoComplete="off" runat="server" placeholder="Monto Total"></asp:TextBox>
                        </div>
                        <div class="form-group" style="width: 33%">
                            <label>Banco:</label>
                            <asp:DropDownList CssClass="form-control" ID="ddlBanco" Style="width: 100%" Height="34px" runat="server">
                                <asp:ListItem>---</asp:ListItem>
                                <asp:ListItem>Banco Industrial</asp:ListItem>
                                <asp:ListItem>Banco G&T</asp:ListItem>
                                <asp:ListItem>Banrural</asp:ListItem>
                                <asp:ListItem>Banco de Occidente</asp:ListItem>
                                <asp:ListItem>Banco Agromercantil</asp:ListItem>
                                <asp:ListItem>Banco Promerica</asp:ListItem>
                                <asp:ListItem>Bac Credomatic</asp:ListItem>
                                <asp:ListItem>Banco Internacional</asp:ListItem>
                                <asp:ListItem>Banco de los Trabajadores</asp:ListItem>
                                <asp:ListItem>Vivibanco</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group" style="width: 32%">
                            <label>No Cheque:</label>
                            <asp:TextBox ID="txtNumeroCheque" Style="width: 100%" autocomplete="off" class="form-control" placeholder="Numero de cheque" runat="server"></asp:TextBox>
                        </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
                </div>
            </div>
        </div>
     </div>
  </div>
</asp:Content>

