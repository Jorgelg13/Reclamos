<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Implants.master" AutoEventWireup="true" CodeFile="consultas-implants.aspx.cs" Inherits="Modulos_MdReportes_consultas_implants" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading"><b>Reporte de atencion implants</b></div>
            <div class="panel-body">
                <div class="form-group  col-sm-12 col-md-6 col-lg-2" style="padding-top: 10px;">
                    <label>Desde:</label>
                    <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                </div>
                <div class="form-group  col-sm-12 col-md-6 col-lg-2" style="padding-top: 10px;">
                    <label>Hasta:</label>
                    <asp:TextBox ID="txtFechaFin" type="date" Height="34px" CssClass="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                </div>
                <div class="form-group  col-sm-12 col-md-6 col-lg-2" style="padding-top: 10px;">
                    <asp:LinkButton ID="btnGenerarTabla" title="Generar Datos" autopostback="true" runat="server" OnClick="btnGenerarTabla_Click" style="font-size:50px"><i class="fa fa-search"></i></asp:LinkButton>
                    <asp:LinkButton ID="btnExportar" title="Exportar a excel"  runat="server" OnClick="btnExportar_Click" style="font-size:50px"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
                </div>
                <div class="scrolling-table-container col-lg-12 col-md-12" style="padding: 0px;">
                    <asp:GridView ID="GridReporte" CssClass="table bs-table table-responsive" 
                        runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                        <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" Wrap="false" />
                        <PagerStyle BackColor="#131B4D" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" Wrap="true" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentJS" runat="Server">
</asp:Content>

