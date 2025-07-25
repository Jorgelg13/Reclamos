<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="resumen-reclamos-autos.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmReportesAutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-sm-12">
        <div class="panel panel-info">
            <div class="panel-body">
                <div class="row">
                    <div class="form-group  col-sm-12 col-md-6 col-lg-2">
                        <label>Usuario:</label>
                        <asp:DropDownList ID="ddlGestor" Height="34px" runat="server" Style="width: 100%" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group  col-sm-12 col-md-6 col-lg-2">
                        <label>Fecha Inicio:</label>
                        <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group  col-sm-12 col-md-6 col-lg-2">
                        <label>Fecha Fin:</label>
                        <asp:TextBox ID="txtFechaFin" type="date" Height="34px" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                    </div>
                         <asp:Button ID="Mostrar" Style="margin-top: 28px" runat="server" Text="Generar" OnClick="Mostrar_Click" />
                </div>
                <asp:Panel runat="server" ID="PanelPrincipal">
                    <div style="text-align: center; font-size: 20px;">
                        <b>
                            <asp:Label runat="server" ID="lblTitulo"></asp:Label></b>
                        <br />
                        <asp:Label runat="server" ID="lblPeriodo"></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="lblFechaGeneracion"></asp:Label>
                        <asp:Label runat="server" ID="lblUsuario" Style="padding-right: 15px;"></asp:Label>
                    </div>
                    <asp:Panel runat="server" ID="PnCiclos" Visible="false">
                        <div style="height: 600px;">
                            <div class="table-container" style="overflow-y: auto;">
                                <div id="ciclos" class="col-sm-12 col-md-12 col-lg-4">
                                    <b>Asignaciones</b>
                                    <asp:GridView ID="GridAsignaciones" runat="server" CssClass="table bs-table table-responsive" OnRowDataBound="GridCiclos_RowDataBound" 
                                        AutoGenerateColumns="True" ShowFooter="true" ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" />
                                        <FooterStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                                    </asp:GridView>
                                    <br />
                                    <b>Reclamos por estado pendientes de <asp:Label runat="server" ID="lblGestor"></asp:Label></b>
                                    <asp:GridView ID="GridReclamosPorEstado" runat="server" CssClass="table bs-table table-responsive" OnRowDataBound="GridCiclos2_RowDataBound" 
                                         AutoGenerateColumns="True" ShowFooter="true" ForeColor="#333333" GridLines="None">
                                         <AlternatingRowStyle BackColor="White" />
                                         <FooterStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                                         <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                         <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                                     </asp:GridView>
                                </div>
                                <div id="ciclos2" class="col-sm-12 col-md-6 col-lg-8">
                                    <b>Reclamos agrupados</b>
                                    <asp:GridView ID="GridPendientes" runat="server" CssClass="table bs-table table-responsive" OnRowDataBound="GridCiclos2_RowDataBound" 
                                        AutoGenerateColumns="True" ShowFooter="true" ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" />
                                        <FooterStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                                    </asp:GridView>
                                    <br />
                                      <b>Reclamos sin aperturar</b>
                                      <asp:GridView ID="GridReclamosSinAperturar" runat="server" CssClass="table bs-table table-responsive" OnRowDataBound="GridCiclos2_RowDataBound" 
                                          AutoGenerateColumns="True" ForeColor="#333333" GridLines="None">
                                          <AlternatingRowStyle BackColor="White" />
                                          <FooterStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                                          <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                          <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                                      </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </asp:Panel>
            </div>
        </div>
    </div>
    <%-- botones circulares con las opciones multiples --%>
    <div id="container-floating">
        <div class="nd4 nds" data-toggle="tooltip" data-placement="left" data-original-title="Simone">
            <asp:LinkButton ID="linkSalir" CssClass="letter" OnClick="linkSalir_Click" runat="server" ToolTip="Salir"><i class="fa fa-times" ></i></asp:LinkButton>
        </div>
        <div class="nd3 nds" data-toggle="tooltip" data-placement="left" data-original-title="contract@gmail.com">
            <asp:LinkButton ID="btnExportar" OnClick="btnExportar_Click" CssClass="letter" runat="server" ToolTip="Exportar a excel"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
        </div>
        <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
            <asp:LinkButton ID="btnGenerarTabla" OnClick="btnGenerarTabla_Click" CssClass="letter" autopostback="true" runat="server" ToolTip="Generar tabla"><i class="fa fa-table"></i></asp:LinkButton>
        </div>
        <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
            <p class="plus">+</p>
            <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentJs" ID="JS">
    <script>
        try {
            $('#ContentPlaceHolder1_GridEficiencia tr').each(function (index) {
                $tr = $(this);
                if (index > 0) {
                    $td = $tr[0].cells[9];
                    $td.innerText = $td.innerText + ' %';
                    $td.className = 'alinearNumeros';

                     $td = $tr[0].cells[10];
                    $td.innerText = $td.innerText + ' %';
                    $td.className = 'alinearNumeros';
                }
            });
        } catch (ex) {
        }
         try {
            $('#ContentPlaceHolder1_GridCiclos tr').each(function (index) {
                $tr = $(this);
                if (index > 0) {
                    $td = $tr[0].cells[2];
                    $td.className = 'alinearNumeros';

                     $td = $tr[0].cells[3];
                    $td.innerText = $td.innerText + ' %';
                    $td.className = 'alinearNumeros';
                }
            });
        } catch (ex) {
        }

         try {
            $('#ContentPlaceHolder1_GridCiclos2 tr').each(function (index) {
                $tr = $(this);
                if (index > 0) {
                    $td = $tr[0].cells[2];
                    $td.className = 'alinearNumeros';

                     $td = $tr[0].cells[3];
                    $td.innerText = $td.innerText + ' %';
                    $td.className = 'alinearNumeros';
                }
            });
        } catch (ex) {
        }
    </script>
    <script>
      
    </script>
</asp:Content>



