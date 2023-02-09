<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Consultas.master" AutoEventWireup="true" CodeFile="consultas.aspx.cs" Inherits="Modulos_Consultas_consultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info">
            <div class="panel-heading">Buscar Informacion de asegurado</div>
            <div class="panel-body">
                <div class="panel panel-info altura col-lg-4">
                    <div class="row">
                        <asp:Label runat="server" ID="lblTipo" style="display:none"></asp:Label>
                        <div class="col-sm-12 col-md-6 col-lg-5 margen">
                            <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control" placeholder="buscar" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-sm-12 col-md-6 col-lg-3 margen">
                            <asp:DropDownList runat="server" ID="ddlTipo" CssClass="form-control" placeholder="buscar" Width="100%">
                                <asp:ListItem Value="asegurado">Asegurado</asp:ListItem>
                                <asp:ListItem Value="poliza">Poliza</asp:ListItem>
                                <asp:ListItem Value="cliente">Cliente</asp:ListItem>
                                <asp:ListItem Value="placa">Placa</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-12 col-md-6 col-lg-3 margen">
                            <asp:Button runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" Text="Buscar" Width="100%"></asp:Button>
                        </div>
                    </div>
                    <div class="scrolling-table-container" style="overflow-y: auto;">
                        <asp:GridView ID="GridRegistros" runat="server" CssClass="table table-responsive table-hover" AutoGenerateColumns="True"
                            GridLines="None" AllowCustomPaging="True" PageSize="300" OnSelectedIndexChanged="GridRegistros_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="fa fa-search" SelectText="" />
                            </Columns>
                            <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Left" Wrap="false" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>
                <div class="panel-group col-lg-8" id="accordion" role="tablist" aria-multiselectable="true">
                    <div class="panel panel-info">
                        <div class="panel-heading" role="tab" id="headingOne">
                            <h4 class="panel-title">
                                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">Informacion General de la poliza
                                </a>
                            </h4>
                        </div>
                        <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel">
                            <div class="panel-body">
                                <asp:Panel runat="server" ID="PnAutos" Visible="false">
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <table class="table-style table table-responsive table-hover">
                                            <tr>
                                                <td><b>Poliza</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPoliza"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Asegurado</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblAsegurado"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Cliente</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblCliente"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Ejecutivo</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblEjecutivo"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Aseguradora</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblAseguradora"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Contratante</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblContratante"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Estado</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblEstado"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Programa</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPrograma"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Vigencia Inicial</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblVigi"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Vigencial Final</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblVigf"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <div class="titulo">
                                            <h3>Datos del vehiculo</h3>
                                            <a href="#" style="font-size: 60px;" class="fa fa-car "></a>
                                        </div>
                                        <table class="table-style table table-responsive table-hover">
                                            <tr>
                                                <td><b>Placa</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPlaca"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Marca</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblMarca"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Color</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblColor"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Modelo</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblModelo"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Chasis</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblChasis"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Motor</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblMotor"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <div class="titulo">
                                            <h3>Dias de vigencia: <b>
                                                <asp:Label runat="server" ID="lblVigencia"></asp:Label></b></h3>
                                            <a href="https://reclamosgt.unitypromotores.com/Modulos/MdReclamos/Copagos.aspx" target="_blank" ToolTip="Copagos"
                                                style="font-size: 40px;" class="fa fa-list-ol">Copagos</a>
                                        </div>

                                    </div>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="PnDanios" Visible="false">
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <table class="table-style table table-responsive table-hover">
                                            <tr>
                                                <td><b>Poliza</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPolizaDanios"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Asegurado</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblAseguradoDanios"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Cliente</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblClienteDanios"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Ejecutivo</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblEjecutivoDanios"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Aseguradora</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblAseguradoraDanios"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Contratante</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblContratanteDanios"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Estado</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblEstatoDanios"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Direccion</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblDireccionDanios"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Vigencia Inicial</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblVigiDanios"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Vigencial Final</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblVigfDanios"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <div class="titulo">
                                            <h3>Dias de vigencia: <b>
                                                <asp:Label runat="server" ID="lblVigenciaDanios"></asp:Label></b></h3>
                                            <a href="https://reclamosgt.unitypromotores.com/Modulos/MdReclamos/Copagos.aspx" target="_blank" ToolTip="Copagos"
                                                style="font-size: 40px;" class="fa fa-list-ol">Copagos</a>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <asp:Panel runat="server" ID="PnAsegurados" Visible="false">
                                      <div class="col-lg-12 col-md-12 col-sm-12">
                                        <table class="table-style table table-responsive table-hover">
                                            <tr>
                                                <td><b>Asegurado</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblAseguradoMedicos"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Poliza</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblPolizaAsegurado"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Ramo</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblRamoAsegurado"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Tipo</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblTipoAsegurado"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Clase</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblClaseAsegurado"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Ejecutivo</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblEjecutivoAsegurado"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Aseguradora</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblAseguradoraAsegurado"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Contratante</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblContratanteAsegurado"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Estado</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblEstadoAsegurado"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Vip</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblVip"></asp:Label></td>
                                            </tr>
                                             <tr>
                                                <td><b>Vigencia Inicial</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblVigiAsegurado"></asp:Label></td>
                                            </tr>
                                             <tr>
                                                <td><b>Vigencia Final</b></td>
                                                <td>
                                                    <asp:Label runat="server" ID="lblVigfAsegurado"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <div class="titulo">
                                            <h3>Dias de vigencia: <b>
                                                <asp:Label runat="server" ID="lblVigenciaAsegurado"></asp:Label></b></h3>
                                            <a href="https://reclamosgt.unitypromotores.com/Modulos/MdReclamos/Copagos.aspx" target="_blank" ToolTip="Copagos"
                                                style="font-size: 40px;" class="fa fa-list-ol">Copagos</a>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-info">
                        <div class="panel-heading" role="tab" id="headingTwo">
                            <h4 class="panel-title">
                                <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">Coberturas Disponibles
                                </a>
                            </h4>
                        </div>
                        <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel">
                            <div class="panel-body">
                                <div class="scrolling-table-container" style="overflow-y: auto;">
                                    <asp:GridView ID="GridCoberturas" runat="server" CssClass="table table-responsive table-hover" AutoGenerateColumns="True"
                                        GridLines="None" AllowCustomPaging="True" PageSize="300">
                                        <AlternatingRowStyle BackColor="White" />
                                        <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle HorizontalAlign="Left" Wrap="false" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-info">
                        <div class="panel-heading" role="tab" id="headingThree">
                            <h4 class="panel-title">
                                <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">Reclamos Pendientes
                                </a>
                            </h4>
                        </div>
                        <div id="collapseThree" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                            <div class="panel-body">
                                <div class="scrolling-table-container col-lg-4 col-md-4 col-sm-12">
                                    <asp:GridView ID="GridReclamos" runat="server" CssClass="table table-responsive table-hover" AutoGenerateColumns="True"
                                        GridLines="None" AllowCustomPaging="True" PageSize="300" OnSelectedIndexChanged="GridReclamos_SelectedIndexChanged">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="fa fa-search btnRevisarReclamo" SelectText="" />
                                        </Columns>
                                        <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle HorizontalAlign="Left" Wrap="false" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                </div>
                               <div class="panel panel-default col-lg-4 col-md-4 col-sm-12 panel-count">
                                    <div class="panel-heading">Reclamos en seguimiento</div>
                                    <div class="panel-body centrar-count">
                                        <b><asp:Label runat="server" ID="lblTotalReclamos"></asp:Label></b>
                                    </div>
                                </div>
                                <div class="panel panel-default col-lg-4 col-md-4 col-sm-12 panel-count">
                                    <div class="panel-heading">Reclamos reportados año actual</div>
                                    <div class="panel-body centrar-count">
                                       <b><asp:Label runat="server" ID="lblTotalAnio"></asp:Label></b>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentJS" runat="Server">
    <script>
        try {
            $('#ContentPlaceHolder1_GridRegistros tr').each(function (index) {
                $tr = $(this);
                $td = $tr[0].cells[1];
                $td.remove();

                $td = $tr[0].cells[1];
                $td.remove();
            });
          } catch (ex) {
        }

        if ($('#ContentPlaceHolder1_lblTipo').text() === "1") {

            $('.btnRevisarReclamo').attr('href', "javascript:void(0)");
            $('.btnRevisarReclamo').on('click', function () {
                $tr = $(this).closest('tr')[0].cells;
                $id = $tr[1].innerText;
                window.open('https://reclamosgt.unitypromotores.com/MdBitacora/wbFrmConsultaSeguimientoAutos.aspx?ID_reclamo=' + $id, '_blank');
            });
        }
        else if ($('#ContentPlaceHolder1_lblTipo').text() === "2") {
            $('.btnRevisarReclamo').attr('href', "javascript:void(0)");
            $('.btnRevisarReclamo').on('click', function () {
                $tr = $(this).closest('tr')[0].cells;
                $id = $tr[1].innerText;
                window.open('https://reclamosgt.unitypromotores.com/MdBitacora/wbFrmConsultaSeguimientoDa%C3%B1os.aspx?ID_reclamo=' + $id, '_blank');
            });
        }

        else if ($('#ContentPlaceHolder1_lblTipo').text() === "3") {
            $('.btnRevisarReclamo').attr('href', "javascript:void(0)");
            $('.btnRevisarReclamo').on('click', function () {
                $tr = $(this).closest('tr')[0].cells;
                $id = $tr[1].innerText;
                window.open('https://reclamosgt.unitypromotores.com/MdBitacora/wbFrmConsultaSeguimientoRmedicos.aspx?ID_reclamo=' + $id, '_blank');
            });
        }
      
    </script>

</asp:Content>

