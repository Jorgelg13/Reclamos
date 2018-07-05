<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="wbFrmReporteNoConforme.aspx.cs" Inherits="Modulos_MdReclamosUnity_wbFrmReporteNoConforme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="container-fluid">
        <div class="col-sm-12 col-md-12 col-lg-12">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title"><b style="font-size: 16px;">Listado de reclamos no conformes <spam style="margin-left:100px">Total de registros: </spam><asp:Label ID="lblConteo" runat="server" Style="font-size: 20px;"></asp:Label></b></h3>
                </div>
                <div class="panel-body" style="height: 520px;">
                    <div class="scrolling-table-container" style="overflow-y: auto;">
                        <asp:GridView ID="GridNoConforme" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None" AllowCustomPaging="True" AllowPaging="True" PageSize="3000">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                            </Columns>
                            <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                            <PagerSettings PageButtonCount="30" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                        </asp:GridView>
                    </div>
                    <br />
                    <div class="form-inline">
                        <div class="form-group" style="width: 20%">
                            <label>Seleccionar Busqueda:</label>
                            <asp:DropDownList ID="ddlTipo" runat="server" Style="width: 100%" CssClass="form-control">
                                <asp:ListItem Value="in ('A','D','I','C')">Todos</asp:ListItem>
                                <asp:ListItem Value=" = 'A'">Autos</asp:ListItem>
                                <asp:ListItem Value=" = 'D'">Daños varios</asp:ListItem>
                                <asp:ListItem Value=" = 'I'">Individuales</asp:ListItem>
                                <asp:ListItem Value=" = 'C'">Colectivos</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group" style="width: 20%">
                            <label>Estado:</label>
                            <asp:DropDownList ID="ddlEstado" runat="server" Style="width: 100%" CssClass="form-control">
                                <asp:ListItem Value="in ('Abierto','Cerrado')">Todos</asp:ListItem>
                                <asp:ListItem Value=" = 'Cerrado'">Cerrados</asp:ListItem>
                                <asp:ListItem Value=" = 'Abierto'">Abiertos</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group" style="width: 15%">
                            <label>Fecha Inicio:</label>
                            <asp:TextBox ID="txtFechaInicio" Height="34px" type="date" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group" style="width: 15%">
                            <label>Fecha Fin:</label>
                            <asp:TextBox ID="txtFechaFin" type="date" Height="34px" CssClass="form-control" Style="width: 100%" placeholder="Escriba su busqueda" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group" style="width: 15%">
                            <asp:Button CssClass="btn btn-primary" ID="btnMostrarEficiencia"  OnClientClick="return false;" data-toggle="modal" data-target="#ModalEficiencia" style="margin-left:20px; margin-top: 22px;" runat="server" Text="Eficiencia" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- ------------------------ modal ver el detalle de eficiencia ------------------------------------------%>
        <div class="modal fade" id="ModalEficiencia" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="ModalComentario1"><b>Eficiencia por area</b></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group scrolling-table-container">
                            <asp:GridView ID="GridEficiencia" runat="server" CssClass="table bs-table table-responsive table-hover" AutoGenerateColumns="True" ForeColor="#333333" GridLines="None" AllowCustomPaging="True">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#131B4D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                            </asp:GridView>
                            <p style="font-size:20px"><b></b></p>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btnExportarEficiencia" OnClick="btnExportarEficiencia_Click" runat="server" Text="Descargar" CssClass="btn btn-success" />
                    </div>
                </div>
            </div>
        </div>
        <%-- botones circulares con las opciones multiples --%>
        <div id="container-floating">
            <div class="nd4 nds" data-toggle="tooltip" data-placement="left" data-original-title="Simone">
                <asp:LinkButton ID="linkSalir" OnClick="linkSalir_Click" CssClass="letter" runat="server"><i class="fa fa-times" aria-hidden="true"></i></asp:LinkButton>
            </div>
            <div class="nd3 nds" data-toggle="tooltip" data-placement="left" data-original-title="contract@gmail.com">
                <asp:LinkButton ID="btnExportar" OnClick="btnExportar_Click" CssClass="letter" runat="server"><i class="fa fa-file-excel-o" aria-hidden="true"></i></asp:LinkButton>
            </div>
            <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
                <asp:LinkButton ID="btnGenerarTabla" OnClick="btnGenerarTabla_Click" CssClass="letter" autopostback="true" runat="server"><i class="fa fa-table" aria-hidden="true"></i></asp:LinkButton>
            </div>
            <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
                <p class="plus">+</p>
                <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentJs" Runat="Server">
    <script>
        try {
            $('#ContentPlaceHolder1_GridEficiencia tr').each(function (index) {
                $tr = $(this);
                if (index > 0) {
                    $td = $tr[0].cells[3];
                    $td.innerText = $td.innerText + ' %';
                    $td.className = 'alinearNumeros';
                }
            });
        } catch (ex) {
        }
    </script>
</asp:Content>

