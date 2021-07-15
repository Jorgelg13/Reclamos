<%@ Page Title="Pronico" Language="C#" MasterPageFile="~/Consultas/pronico/CajaAhorro.master" AutoEventWireup="true" CodeFile="consultar-asegurados.aspx.cs" Inherits="Consultas_Caja_de_ahorro_ConsultarAsegurados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="container-fluid" style="padding:0px;">
        <div class="panel panel-info col-sm-12 col-md-8 col-lg-8">
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Buscar Asegurado</a></li>
                <%--<li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Verificar Coberturas</a></li>--%>
            </ul>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="home">
                    <div class="panel-body">
                        <div class="form-group col-sm-2 col-md-4 col-lg-5">
                            <asp:TextBox runat="server" autocomplete="off" ID="txtBusqueda" Style="width: 100%" class="form-control" placeholder="Escriba el nombre del asegurado"></asp:TextBox>
                        </div>
                        <div class="col-lg-1 col-md-1 col-sm-1">
                            <asp:Button runat="server" Text="Buscar" ID="btnBuscar" class="btn btn-primary" OnClick="btnBuscar_Click" />
                        </div>
                        <div class="scrolling-table-container col-lg-12 col-md-12" style="padding:0px;">
                            <asp:GridView ID="GridAsegurados" OnSelectedIndexChanged="GridAsegurados_SelectedIndexChanged" CssClass="table bs-table table-responsive table-hover" runat="server" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
                                </Columns>
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" Wrap="false" />
                                <PagerStyle BackColor="#131B4D" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="White" Wrap="false" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="profile">
                    <div class="scrolling-table-container">

                    </div>
                </div>
            </div>
        </div>
          <div class="col-sm-12 col-md-4 col-lg-4" style="padding-right: 0px; padding:3px;">
        <div class="panel panel-info" style="padding:0px;">
            <div class="panel-heading">
                <h3 class="panel-title">Datos en General</h3>
            </div>
            <div class="panel-body" style=" max-height:400px; overflow-y:auto">
                <table style="width: 100%" class="table table-hover table-responsive">
                    <tr>
                        <td>Asegurado</td>
                        <td><asp:Label ID="lblAsegurado" runat="server"></asp:Label></td>
                    </tr>
                     <tr>
                        <td>Certificado</td>
                        <td><asp:Label ID="lblCertificado" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Aseguradora</td>
                        <td><asp:Label ID="lblAseguradora" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Contratante</td>
                        <td><asp:Label ID="lblContratante" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Poliza</td>
                        <td><asp:Label ID="lblPoliza" runat="server"></asp:Label></td>
                    </tr>
                     <tr>
                        <td>Estado Poliza</td>
                        <td><asp:Label ID="lblEstado" runat="server"></asp:Label></td>
                    </tr>
                     <tr>
                        <td>Ramo</td>
                        <td><asp:Label ID="lblRamo" runat="server"></asp:Label></td>
                    </tr>
                      <tr>
                        <td>Clase</td>
                        <td><asp:Label ID="lblClase" runat="server"></asp:Label></td>
                    </tr>
                      <tr>
                        <td>Tipo</td>
                        <td><asp:Label ID="lblTipo" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Vigencia Inicial</td>
                        <td><asp:Label ID="lblVigi" runat="server"></asp:Label></td>
                    </tr>
                     <tr>
                        <td>Vigencia Final</td>
                        <td><asp:Label ID="lblVigf" runat="server"></asp:Label></td>
                    </tr>
                     <tr>
                        <td>Moneda</td>
                        <td><asp:Label ID="lblMoneda" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Ejecutivo</td>
                        <td><asp:Label ID="lblEjecutivo" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
     </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" Runat="Server">
        <style>
        table, th, td {
            border-collapse: collapse;
        }

        th, td {
            padding: 5px;
        }

        th {
            text-align: left;
        }
    </style>
        <style>
        body {
    /* el tamaño por defecto es 14px */
    font-size: 12px;
}
    </style>
     <script>
        try {
            $('#ContentPlaceHolder1_GridAsegurados tr').each(function (index) {
                $tr = $(this);
                   $td = $tr[0].cells[1];
                   $td.remove();
            });
        } catch (ex) {
        }
    </script>
</asp:Content>

