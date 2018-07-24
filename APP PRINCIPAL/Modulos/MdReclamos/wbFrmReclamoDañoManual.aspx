<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmReclamoDañoManual.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmReclamoDañoManual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
     <%--    <META HTTP-EQUIV="Refresh" URL=wbFrmReclamosDaños.aspx">--%>
    <div class="container">
        <div  class="panel panel-default col-sm-12">
            <ul class="nav nav-tabs" role="tablist">
                <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Ingresar datos Poliza</a></li>
                <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Ingresar Datos</a></li>
            </ul>
              <div class="tab-content">
                <div role="tabpanel" class="tab-pane active" id="profile">
                    <div class="panel-body form-inline">
                        <br />
                        <asp:TextBox runat="server" ID="txtNombre" autocomplete="false" Style="width: 30%" class="form-control" placeholder="Nombre o Empresa"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtDireccion" autocomplete="false" Style="width: 35%" class="form-control" placeholder="Direccion"></asp:TextBox>
                        <asp:DropDownList CssClass="form-control" ID="ddlAseguradora" Style="width: 30%" Height="34px" runat="server">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:TextBox runat="server" ID="txtPoliza" autocomplete="false" Style="width: 47%" class="form-control" placeholder="Poliza"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtEjecutivo" autocomplete="false" Style="width: 40%" class="form-control" placeholder="Ejecutivo de la cuenta"></asp:TextBox>
                    </div>
                </div>
                <div role="tabpanel" class="tab-pane" id="messages">
                      <div class="panel-body form-inline">
                         <br />
                         <asp:TextBox runat="server" ID="txtReportante" autocomplete="false" Style="width: 30%" class="form-control" placeholder="Reportante" ></asp:TextBox >
                         <asp:TextBox runat="server" ID="txtTelefono" autocomplete="false" Style="width: 25%" class="form-control" placeholder="Telefono"></asp:TextBox>
                         <asp:TextBox runat="server" ID="txtUbicacion" autocomplete="false" Style="width: 40%" class="form-control" placeholder="Ubicacion"></asp:TextBox>                
                         <br />
                         <br />
                         <asp:TextBox runat="server" type="date" ID="txtFecha" autocomplete="false" Style="width: 40%" Height="34px" class="form-control" placeholder="Fecha"></asp:TextBox>
                         <asp:TextBox runat="server" type="time" ID="txtHora" autocomplete="false" Style="width: 15%" Height="34px" class="form-control" placeholder="Hora del incidente"></asp:TextBox>
                         <asp:TextBox runat="server" ID="txtBoleta" autocomplete="false" Style="width: 40%" class="form-control" placeholder="Numero de boleta"></asp:TextBox>
                         <br />
                         <br />
                         <asp:TextBox runat="server" ID="txtAjustador" autocomplete="false" Style="width: 40%" class="form-control" placeholder="Ajustador"></asp:TextBox>
                         <asp:TextBox runat="server" ID="txtTitular" autocomplete="false" Style="width: 45%" class="form-control" placeholder="Titular"></asp:TextBox>
                         <br />
                         <br />
                         <asp:TextBox runat="server" ID="txtVersion" autocomplete="false" Style="width: 95%" class="form-control" placeholder="Version"></asp:TextBox>
                         <br />
                         <br />
                         <asp:Button runat="server" Text="Guardar Reclamo" ID="txtGuardarReclamo" class="btn btn-primary" OnClick="btnGuardarReclamo_Click" />
                         <br />
                         <br />
                     </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>

