<%@ Page Title="" Language="C#" MasterPageFile="~/ReclamosUnity.master" AutoEventWireup="true" CodeFile="wbFrmReclamosDañosAsignados.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmReclamosDañosAsignados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="panel panel-info col-sm-12">
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation" class="home">
                    <a href="#home" aria-controls="home" role="tab" data-toggle="tab" style="font-size: 16px;">Reclamos Asignados</a>
                </li>
                <li role="presentation" class="profile">
                    <a href="#profile" aria-controls="profile" role="tab" data-toggle="tab" style="font-size: 16px;">Historial De LLamadas</a>
                </li>
                <li role="presentation" class="coberturas">
                    <a href="#coberturas" aria-controls="coberturas" role="tab" data-toggle="tab" style="font-size: 18px;">Coberturas</a>
                </li>
                <li role="presentation" class="ingreso-datos">
                    <a href="#ingreso-datos" aria-controls="ingreso-datos" role="tab" data-toggle="tab" style="font-size: 18px;">Ingresar Datos</a>
                </li>
            </ul>
            <%------------------------------tabla principal de reclamos asignados -------------------------------%>
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="home">
                    <div class="panel-body">
                        <div class="scrolling-table-container">
                            <asp:GridView ID="GridReclamosDaños" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="True" DataKeyNames="id" OnSelectedIndexChanged="GridReclamosDaños_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:CommandField>
                                </Columns>
                                <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Wrap="False" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" Wrap="False" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <%---------------------tabla con llamadas registradas -------------------------------%>
                <div role="tabpanel" class="tab-pane" id="profile">
                    <div class="panel-body">
                        <div class="scrolling-table-container">
                            <asp:GridView ID="GridLlamadas" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <%-------------------------------------tabla coberturas----------------------------------------------%>
                <div role="tabpanel" class="tab-pane" id="coberturas">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GridCoberturas" CssClass="table bs-table tablaDetalleAuto table-responsive table-hover" runat="server" AutoGenerateColumns="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckCoberturas" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#48086f" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>
                <%----------------------------  opciones de checkobox --------------------------------------------------%>
                <div role="tabpanel" class="tab-pane" id="ingreso-datos">
                    <div class="panel-body form-inline">
                        <div style="height: 275px;" class="panel panel-info col-md-3">
                            <div class="panel-heading"><b style="font-size: 18px;">Selecciones</b></div>
                            <div class="panel-body">
                                <asp:CheckBox ID="checkPrioritario" Style="font-size: 18px;" runat="server" Text="Prioritario"  />
                                <br />
                                <br />
                                <asp:CheckBox ID="CheckComplicado" Style="font-size: 18px;" runat="server" Text="Complicado"  />
                                <br />
                                <br />
                                <asp:CheckBox ID="checkCompromiso" Style="font-size: 18px;" runat="server" Text="Compromiso De Pago" />
                            </div>
                        </div>
                        <div style="height: 275px;" class="panel panel-info col-md-4">
                            <div class="panel-heading"><b style="font-size: 18px;">Opciones Multiples</b></div>
                            <div class="panel-body">
                                <label style="width: 15%">Analista:</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlAnalista" Style="width: 80%" Height="34px" runat="server"></asp:DropDownList>
                                <br />
                                <br />
                                <label style="width: 15%">Taller:</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlTaller" Style="width: 80%" Height="34px" runat="server"></asp:DropDownList>
                                <br />
                                <br />
                                <label style="width: 15%">Gestor:</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlGestor" Style="width: 80%" Height="34px" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <%--Datos del contacto--%>
                        <div class="panel panel-info col-md-5" style="height: 275px;">
                            <div class="panel-heading"><b style="font-size: 18px;">Datos Contacto</b></div>
                            <div class="panel-body">
                                <div class="form-inline">
                                    <label>Nombre Contacto:</label>
                                    <asp:TextBox ID="txtContacto" Style="width: 95%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                    <br />
                                    <br />
                                    <label>Correo:</label>
                                    <asp:TextBox ID="txtCorreo" Style="width: 95%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                    <br />
                                    <br />
                                    <label>Telefono:</label>
                                    <asp:TextBox ID="txtTelefono" maxlength="15" Style="width: 95%" CssClass="form-control" AutoComplete="off" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-inline">
                        <asp:TextBox ID="txtObservaciones" Style="width: 50%" autocomplete="off" CssClass="form-control" TextMode="multiline" Columns="50" Rows="3" runat="server" placeholder="Observaciones" />
                        <asp:TextBox ID="txtComentarios" Style="width: 45%" autocomplete="off" class="form-control" TextMode="multiline" Columns="50" Rows="3" placeholder="Comentarios Del Reclamo" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:TextBox ID="txtNumReclamo" CssClass="form-control" placeholder="Numero de reclamo" Width="15%" runat="server"></asp:TextBox>
                        <asp:Button runat="server" Text="Guardar" ID="txtGuardar" class="btn btn-primary" OnClick="txtGuardar_Click" />
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>
        <%-----------------------------------   modal para agregar datos manualmente a un reclamo que se creo de forma manual ---------------------------------------%>
        <div class="modal fade" id="ModalActualizar" >
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title"><b>Agregar Datos que no fueron encontrados</b></h4>
                    </div>
                    <div class="modal-body ">
                        <div class="form-group">
                            <div class="form-inline">
                                <label style="width: 15%">Poliza</label>
                                <asp:TextBox ID="txtPoliza" Style="width: 80%" autocomplete="off" class="form-control" placeholder="Poliza" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                <label style="width: 15%">No. Cliente</label>
                                <asp:TextBox ID="txtCliente" Style="width: 80%" autocomplete="off" class="form-control" placeholder="Numero de cliente" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                <label style="width: 15%">Estatus</label>
                                <asp:DropDownList ID="ddlStatus" class="form-control" Style="width: 80%" runat="server">
                                    <asp:ListItem>Renovacion</asp:ListItem>
                                    <asp:ListItem>Nueva</asp:ListItem>
                                    <asp:ListItem>Cancelada</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <br />
                                <label style="width: 15%">Ramo</label>
                                <asp:DropDownList ID="ddlRamo" class="form-control" Style="width: 80%" runat="server"></asp:DropDownList>
                                <br />
                                <br />
                                <label style="width: 15%">Ejecutivo</label>
                                <asp:DropDownList ID="ddlEjecutivos" class="form-control" Style="width: 80%" runat="server"></asp:DropDownList>
                                <br />
                                <br />
                                <label style="width: 15%">Aseguradora</label>
                                <asp:DropDownList ID="ddlAseguradora" class="form-control"  Style="width: 80%" runat="server"></asp:DropDownList>
                                <br />
                                <br />
                                <label style="width: 15%">Contratante</label>
                                <asp:TextBox ID="txtContratante" Style="width: 80%" autocomplete="off" class="form-control" placeholder="Contratante" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                <label style="width: 15%">Asegurada</label>
                                <asp:TextBox ID="txtSumaAsegurada" Style="width: 80%" Text="0.00" autocomplete="off" class="form-control" placeholder="Suma Asegurada" runat="server"></asp:TextBox>
                                <br />
                                <br />
                                <label style="width: 15%">Moneda</label>
                                <asp:DropDownList ID="ddlMoneda" class="form-control" Style="width: 80%" runat="server">
                                    <asp:ListItem>Quetzales</asp:ListItem>
                                    <asp:ListItem>Dolares</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btnActualizarDatos" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnActualizarDatos_Click" />
                    </div>
                </div>
            </div>
        </div>
        <%---------------------------------------  botones  circulares -------------------------------------%>
        <div id="container-floating">
            <div class="nd4 nds" data-toggle="tooltip" data-placement="left" data-original-title="Simone">
                <asp:LinkButton ID="linkSalir" CssClass="letter" runat="server" OnClick="linkSalir_Click"><i class="fa fa-times" aria-hidden="true"></i></asp:LinkButton>
            </div>
            <div class="nd3 nds" data-toggle="tooltip" data-placement="left" data-original-title="contract@gmail.com">
                <asp:LinkButton ID="linkRefresar" CssClass="letter" autopostback="true" runat="server"><i class="fa fa-undo" aria-hidden="true"></i></asp:LinkButton>
            </div>
            <div class="nd1 nds" data-toggle="tooltip" data-placement="left" data-original-title="Edoardo@live.it">
                <asp:LinkButton ID="LinkButton1" CssClass="letter" OnClientClick="return false;" runat="server" data-toggle="modal" data-target="#ModalActualizar"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></asp:LinkButton>
            </div>
            <div id="floating-button" data-toggle="tooltip" data-placement="left" data-original-title="Create" onclick="newmail()">
                <p class="plus">?</p>
                <img class="edit" src="https://ssl.gstatic.com/bt/C3341AA7A1A076756462EE2E5CD71C11/1x/bt_compose2_1x.png">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="ContentJs">
     <script>
        $('#<%=txtTelefono.ClientID%>').on('input', function () {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
    </script>
</asp:Content>


