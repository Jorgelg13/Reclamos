﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Renovaciones.master" AutoEventWireup="true" CodeFile="Renovadas.aspx.cs" Inherits="Modulos_MdRenovaciones_Estados_Renovadas" EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading"><b>Polizas Renovadas</b></div>
            <div class="panel-body">
                <div class="form-group  col-sm-12 col-md-6 col-lg-2" style="padding-top: 10px;">
                    <label>Desde:</label>
                    <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                </div>
                <div class="form-group  col-sm-12 col-md-6 col-lg-2" style="padding-top: 10px;">
                    <label>Hasta:</label>
                    <asp:TextBox ID="txtFechaFin" type="date" Height="34px" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                </div>
                <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 0px;">
                    <asp:GridView ID="GridRenovadas" CssClass="table bs-table table-responsive" runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None" OnRowDeleting="GridRenovadas_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="Seleccionar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="checkAsignar" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:CommandField  DeleteText="Requerimientos" ControlStyle-CssClass="btn btn-info" ShowDeleteButton="True" ></asp:CommandField> --%>
                            <asp:CommandField ControlStyle-CssClass="btn btn-info ver-poliza" ShowSelectButton="True" SelectText="Ver Poliza" />
                        </Columns>
                        <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" Wrap="false" />
                        <PagerStyle BackColor="#48086f" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" Wrap="true" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <div style="display: none">
        <asp:Panel ID="pnlRequerimientos" runat="server">
            <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 0px;">
                <asp:GridView ID="gridRequerimientos" CssClass="table bs-table table-responsive" runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                    <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" Wrap="false" />
                    <PagerStyle BackColor="#48086f" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" Wrap="false" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
            </div>
        </asp:Panel>
    </div>
    <%-- botones circulares con las opciones multiples --%>
    <div id="container-floating">
        <div class="nd4 nds" data-toggle="tooltip" data-placement="left" data-original-title="contract@gmail.com">
            <asp:LinkButton ID="btnExportar" title="Exportar a excel" CssClass="letter" runat="server" OnClick="btnExportar_Click"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
        </div>
        <div class="nd3 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
            <asp:LinkButton ID="btnGenerarTabla" title="Buscar Datos" CssClass="letter" autopostback="true" runat="server" OnClick="btnGenerarTabla_Click"><i class="fa fa-table" aria-hidden="true"></i></asp:LinkButton>
        </div>
        <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
            <asp:LinkButton ID="btnGuardarCambios" title="Guardar" CssClass="letter" autopostback="true" runat="server" OnClick="btnGuardarCambios_Click"><i class="fa fa-save" aria-hidden="true"></i></asp:LinkButton>
        </div>
        <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
            <p class="plus">+</p>
            <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentJS" runat="Server">
    <script>
        $('.ver-poliza').on('click', function () {
            $tr = $(this).closest('tr')[0].cells;
            $poliza = $tr[4].innerText + $tr[3].innerText + $tr[5].innerText + ".pdf";
            window.open('https://archivos-reclamos.unitypromotores.com/files/RenovacionesElRoble/OneDrive%20-%20Unity%20Seguros/Renovaciones/Renovadas/' + $poliza, '_blank');
        });
    </script>
</asp:Content>

