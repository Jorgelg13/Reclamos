<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="bitacora-autos.aspx.cs" Inherits="Modulos_MdAdmin_bitacora_autos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        table {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        td, th {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 2px;
        }

        tr:nth-child(even) {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class="container-fluid">
        <div class="form-inline">
          <div class="form-group col-lg-2">
                <asp:TextBox CssClass="form-control" runat="server" ID="txtBuscar"  style="width: 100%"></asp:TextBox>
            </div>
            <div class="form-group col-lg-1">
                <asp:DropDownList CssClass="form-control" runat="server" ID="ddltipo" style="width:100%">
                  <asp:ListItem Value="r.id">ID</asp:ListItem>
                  <asp:ListItem Value="au.placa">placa</asp:ListItem>
                  <asp:ListItem Value="au.poliza">poliza</asp:ListItem>
                  <asp:ListItem Value="au.cliente">cliente</asp:ListItem>
                  <asp:ListItem Value="au.asegurado">Asegurado</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#bitacora">Ver Detalle</button>
            </div>
        </div>
    <br />
    <div class="panel panel-info" style="min-height: 400px;">
        <div class="panel-heading">Registro de Reclamos de Autos</div>
        <div class="panel-body">
            <div class="scrolling-table-container">
                <asp:GridView ID="GridBitacoras" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="true" DataKeyNames="id" OnSelectedIndexChanged="GridBitacoras_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="modal fade bs-example-modal-lg" id="bitacora">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title"><b>Bitacora De Reclamo</b></h4>
                </div>
                <div class="modal-body">
                    <table style="width: 100%">
                        <tr>
                            <td><b>Departamento:</b></td>
                            <td>Reclamos Autos</td>
                        </tr>
                        <tr>
                            <td><b>Numero Reclamo:</b></td>
                            <td>
                                <asp:Label ID="lblId" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><b>Poliza:</b></td>
                            <td>
                                <asp:Label ID="lblPoliza" runat="server"></asp:Label></td>
                            <td><b>Placa</b></td>
                            <td>
                                <asp:Label ID="lblPlaca" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><b>Asegurado:</b></td>
                            <td>
                                <asp:Label ID="lblAsegurado" runat="server"></asp:Label></td>
                            <td><b>Marca:</b></td>
                            <td>
                                <asp:Label ID="lblMarca" runat="server"></asp:Label></td>
                        </tr>
                        <tr id="ocultarEjecutivo1">
                            <td><b>Ejecutivo:</b></td>
                            <td>
                                <asp:Label ID="lblEjecutivo" runat="server"></asp:Label></td>
                            <td><b>Color:</b></td>
                            <td>
                                <asp:Label ID="lblColor" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><b>Aseguradora:</b></td>
                            <td>
                                <asp:Label ID="lblAseguradora" runat="server"></asp:Label></td>
                            <td><b>Modelo</b></td>
                            <td>
                                <asp:Label ID="lblModelo" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><b>Contratante:</b></td>
                            <td>
                                <asp:Label ID="lblContratante" runat="server"></asp:Label></td>
                            <td><b>Chasis:</b></td>
                            <td>
                                <asp:Label ID="lblChasis" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><b>Estado:</b></td>
                            <td>
                                <asp:Label ID="lblEstado" runat="server"></asp:Label></td>
                            <td><b>Motor:</b></td>
                            <td>
                                <asp:Label ID="lblMotor" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><b>Piloto:</b></td>
                            <td>
                                <asp:Label ID="lblPiloto" runat="server"></asp:Label></td>
                            <td><b>Reportante:</b></td>
                            <td>
                                <asp:Label ID="lblReportante" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><b>Tipo Servicio:</b></td>
                            <td>
                                <asp:Label ID="lblTipoServicio" runat="server"></asp:Label>
                            </td>
                             <td><b>Fecha Accidente:</b></td>
                            <td>
                                <asp:Label ID="lblHora" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                     <p>
                        <asp:Label runat="server" ID="lblUbicacion"></asp:Label>
                    </p>
                    <p>
                        <asp:Label runat="server" ID="lblversion"></asp:Label>
                    </p>
                    <br />
                    <div class="scrolling-table-container">
                        <asp:GridView ID="Gridllamadas" CssClass="table bs-table table-responsive table-hover" runat="server" AutoGenerateColumns="true" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                    <button type="button" onclick="printDiv('imprimirBitacora')" class="btn btn-primary" data-toggle="modal" data-target="#bitacora">Imprimir</button>
                </div>
            </div>
        </div>
    </div>
    <%------------------------------------------------ imprimir bitacora de seguimiento del reclamo ------------------------------------------%>
    <div id="imprimirBitacora" style="display: none" class="form-inline">
        <br />
        <div class="img-float-right" style="float: right; padding-top: 50px;">
            <img src="../../imgUnity/Unity%20Promotores%20transparente.png" style="margin-top: -100px; width: 235px;">
        </div>
        <div class="img-float-left" style="float: left; padding-top: 10px;">
            <p>Avenida Las Americas 22-23, Zona 14</p>
            <p>PBX: 2326-3700, 2386-3700</p>
            <p>www.unitypromotores.com</p>
        </div>
        <asp:Label ID="TituloMemo" Style="font-size: 16px; padding-left: 70px;" runat="server">Bitacora del reclamo</asp:Label>
        <div class="form-inline" style="padding-top: 90px;">
            <table style="width: 100%">
                <tr>
                    <td><b>Departamento:</b></td>
                    <td>Reclamos Autos</td>
                </tr>
                <tr>
                    <td><b>Numero Reclamo:</b></td>
                    <td>
                        <asp:Label ID="impId" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><b>Poliza:</b></td>
                    <td>
                        <asp:Label ID="impPoliza" runat="server"></asp:Label></td>
                    <td><b>Placa</b></td>
                    <td>
                        <asp:Label ID="impPlaca" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><b>Asegurado:</b></td>
                    <td>
                        <asp:Label ID="impAsegurado" runat="server"></asp:Label></td>
                    <td><b>Marca:</b></td>
                    <td>
                        <asp:Label ID="impMarca" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><b>Ejecutivo:</b></td>
                    <td>
                        <asp:Label ID="impEjecutivo" runat="server"></asp:Label></td>
                    <td><b>Color:</b></td>
                    <td>
                        <asp:Label ID="impColor" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><b>Aseguradora:</b></td>
                    <td>
                        <asp:Label ID="impAseguradora" runat="server"></asp:Label></td>
                    <td><b>Modelo</b></td>
                    <td>
                        <asp:Label ID="impModelo" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><b>Contratante:</b></td>
                    <td>
                        <asp:Label ID="impContratante" runat="server"></asp:Label></td>
                    <td><b>Chasis:</b></td>
                    <td>
                        <asp:Label ID="impChasis" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><b>Estado:</b></td>
                    <td>
                        <asp:Label ID="impEstado" runat="server"></asp:Label></td>
                    <td><b>Motor:</b></td>
                    <td>
                        <asp:Label ID="impMotor" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><b>Piloto:</b></td>
                    <td>
                        <asp:Label ID="impPiloto" runat="server"></asp:Label></td>
                    <td><b>Reportante:</b></td>
                    <td>
                        <asp:Label ID="impReportante" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><b>Tipo Servicio:</b></td>
                    <td>
                        <asp:Label ID="impTipoServicio" runat="server"></asp:Label></td>
                    <td><b>Fecha Accidente:</b></td>
                    <td>
                        <asp:Label ID="impFecha" runat="server"></asp:Label></td>
                </tr>
            </table>
            <br />
              <p>
                <asp:Label runat="server" ID="impUbicacion"></asp:Label>
            </p>
            <p>
                <asp:Label runat="server" ID="impversion"></asp:Label>
            </p>
           
            <hr />
            <div id="bitacoras">
                <p><b>Detalle llamadas en cabina:</b></p>
                <asp:GridView ID="Bitllamadas" CssClass="table detalle" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="True">
                </asp:GridView>
            </div>
            <br />
        </div>
    </div>
 </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    <script>
        function printDiv(imprimir) {
            var contenido = document.getElementById(imprimir).innerHTML;
            var contenidoOriginal = document.body.innerHTML;
            document.body.innerHTML = contenido;
            window.print();
            document.body.innerHTML = contenidoOriginal;
        }
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentJS" runat="Server">
</asp:Content>

