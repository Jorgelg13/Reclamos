<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Renovaciones.master" AutoEventWireup="true" CodeFile="Invalidas.aspx.cs" Inherits="Modulos_MdRenovaciones_Estados_Invalidas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading"><b>Polizas Invalidas</b></div>
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
                    <asp:GridView ID="GridInvalidas" CssClass="table bs-table table-responsive" OnSelectedIndexChanged="GridInvalidas_SelectedIndexChanged" runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="Validar" />
                                <asp:CommandField ShowDeleteButton="True" DeleteText="" ControlStyle-CssClass="fa fa-search btnRevisarPolizaInvalida" ControlStyle-ForeColor="Red" HeaderText="Poliza Invalida"/>
                              <asp:CommandField ShowEditButton="True"   EditText=""  ControlStyle-CssClass="fa fa-search btnRevisarPolizaValida" HeaderText="Poliza Valida"/>
                            </Columns>
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" Wrap="false" />
                            <PagerStyle BackColor="#131B4D" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="White" Wrap="false" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentJS" Runat="Server">
    <script>
        $('.btnRevisarPolizaInvalida').attr('href', "javascript:void(0)");
        $('.btnRevisarPolizaValida').attr('href', "javascript:void(0)");

        $('.btnRevisarPolizaInvalida').on('click', function () {
            $tr = $(this).closest('tr')[0].cells;
            $poliza = $tr[5].innerText + $tr[4].innerText + $tr[6].innerText + ".pdf";
            window.open('http://52.34.115.100:5556/files/RenovacionesElRoble/OneDrive%20-%20Unity%20Seguros/Renovaciones/Invalidas/' + $poliza, '_blank');
        });

        $('.btnRevisarPolizaValida').on('click', function () {
            $tr = $(this).closest('tr')[0].cells;
            $poliza = $tr[5].innerText + $tr[4].innerText + $tr[6].innerText + ".pdf";
            window.open('http://52.34.115.100:5556/files/RenovacionesElRoble/OneDrive%20-%20Unity%20Seguros/Renovaciones/Polizas/' + $poliza, '_blank');
        });
    </script>
</asp:Content>

