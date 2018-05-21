<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wbFrmAsignacionUsuarios.aspx.cs" Inherits="Modulos_MdReclamos_wbFrmAsignacionUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="Server">
    <div class=" col-sm-2">
        <div class="panel-body">
            <h1></h1>
        </div>
    </div>
    <div class="container col-sm-8">
        <div class="panel-group " id="accordion" role="tablist" aria-multiselectable="true">
            <div class="panel panel-info">
                <div class="panel-heading" role="tab" id="headingOne">
                    <h4 class="panel-title">
                        <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">Asignacion de usuarios
                        </a>
                    </h4>
                </div>
                <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                    <div class="panel-body">
                       <div class="col-md-6">
                            <div class="form-group" style="width: 100%">
                            <label for="message-text" class="control-label">Usuario:</label>
                            <asp:DropDownList ID="ddlUsuario" runat="server" Style="width: 90%" CssClass="form-control" DataSourceID="usuarios" DataTextField="UserName" DataValueField="UserId"> 
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="usuarios"  runat="server" ConnectionString="<%$ ConnectionStrings:SEG_RECLAMOSConnectionString %>" SelectCommand="SELECT [UserName], [UserId] FROM [Users] order by UserName"></asp:SqlDataSource>
                        </div>
                         <div class="form-group" style="width: 100%">
                            <label for="message-text" class="control-label">Pais:</label>
                            <asp:DropDownList ID="ddlPais" runat="server" Style="width: 90%" CssClass="form-control" DataSourceID="pais" DataTextField="nombre" DataValueField="codigo_pais">
                            </asp:DropDownList>
                             <asp:SqlDataSource ID="pais" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [nombre], [codigo_pais] FROM [pais]"></asp:SqlDataSource>
                        </div>
                         <div class="form-group" style="width: 100%">
                            <label for="message-text" class="control-label">Empresa:</label>
                            <asp:DropDownList ID="ddlEmpresa" runat="server" Style="width: 90%" CssClass="form-control" DataSourceID="empresa" DataTextField="nombre" DataValueField="id">                 
                            </asp:DropDownList>
                             <asp:SqlDataSource ID="empresa" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [id], [nombre] FROM [empresa]"></asp:SqlDataSource>
                        </div>
                         <div class="form-group" style="width: 100%">
                            <label for="message-text" class="control-label">Sucursal:</label>
                            <asp:DropDownList ID="ddlSucursal" runat="server" Style="width: 90%" CssClass="form-control" DataSourceID="sucursal" DataTextField="nombre" DataValueField="id">
                            </asp:DropDownList>
                             <asp:SqlDataSource ID="sucursal" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [id], [nombre] FROM [sucursal]"></asp:SqlDataSource>
                        </div>
                         <div class="form-group" style="width: 100%">
                            <label for="message-text" class="control-label">Cabina:</label>
                            <asp:DropDownList ID="ddlCabina" runat="server" Style="width: 90%" CssClass="form-control" DataSourceID="cabina" DataTextField="nombre" DataValueField="id">
                            </asp:DropDownList>
                             <asp:SqlDataSource ID="cabina" runat="server" ConnectionString="<%$ ConnectionStrings:reclamosConnectionString %>" SelectCommand="SELECT [id], [nombre] FROM [cabina]"></asp:SqlDataSource>
                        </div>
                           <div class="form-inline">
                                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Guardar</button>
                                <asp:Button ID="btnActualizar" CssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                                <asp:CheckBox ID="checkUpdate" CssClass="form-control" AutoPostBack="true" runat="server"/>
                           </div>
                       </div>
                       <div class="col-md-6">
                           <div class="form-group" style="width: 100%">
                             <label for="message-text" class="control-label">Nombre Completo:</label>
                             <asp:TextBox ID="txtNombre" autocomplete="false" Style="width: 90%" class="form-control" runat="server" placeholder ="Nombre Completo"></asp:TextBox>
                           </div>
                           <div class="form-group" style="width: 100%">
                               <label for="message-text" class="control-label">Correo Electronico:</label>
                               <asp:TextBox ID="txtCorreo" autocomplete="false" Style="width: 90%" class="form-control" runat="server" placeholder="Correo Electronico"></asp:TextBox>
                           </div>
                            <div class="form-group" style="width: 100%">
                               <label for="message-text" class="control-label">Area Asignada:</label>
                                <asp:DropDownList ID="ddlArea" runat="server" Style="width: 90%" CssClass="form-control">
                                    <asp:ListItem Value="ninguna">Ninguna</asp:ListItem>
                                    <asp:ListItem Value="autos">Autos</asp:ListItem>
                                    <asp:ListItem Value="Daños varios">Daños</asp:ListItem>
                                    <asp:ListItem Value="Medicos">Gastos Medicos</asp:ListItem>
                                </asp:DropDownList>
                           </div>
                           <div class="form-group" style="width: 100%">
                                <label for="message-text" class="control-label">Telefono:</label>
                               <asp:TextBox ID="txtTelefono" autocomplete="false" Style="width: 90%" class="form-control" runat="server" placeholder="Telefono"></asp:TextBox>
                           </div>
                           <div class="form-inline">
                               <div class="form-group" style="width: 50%">
                                   <label for="message-text" class="control-label">Fecha de Nacimiento:</label>
                                   <asp:TextBox type="date" ID="txtFechaNacimiento" Style="width: 80%" CssClass="form-control" runat="server" placeholder="Fecha Nacimiento" Height="36px"></asp:TextBox>
                               </div>
                               <div class="form-group" style="width: 48%">
                                    <label for="message-text" class="control-label">Numero de gestor:</label>
                                   <asp:TextBox ID="txtGestor" type="number" CssClass="form-control" Style="width: 80%" runat="server" placeholder="Numero de Gestor"></asp:TextBox>
                               </div>   
                           </div>
                            <br />
                           <div class="form-group" style="width: 100%">
                               <label for="message-text" class="control-label">Movil:</label>
                               <br />
                               <asp:CheckBox ID="checkMovil" AutoPostBack="true" Text="Permitir Busqueda Movil" runat="server" />
                           </div>
                        </div>
                       </div>
                        <div class="container">
                            <div class="modal fade" id="myModal">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h4 class="modal-title"><b>Confirmacion De guardar</b></h4>
                                        </div>
                                        <div class="modal-body">
                                            <p>Esta seguro que desea dar permisos a este usuario</p>
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button ID="btnGuardarAsignacion" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarAsignacion_Click" />
                                            <asp:Button ID="btnCancelar" CssClass="btn btn-warning" runat="server" Text="Cancelar" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>                    
                        <br />
                    </div>
                </div>
            </div>
        </div>
    <div class=" col-sm-2">
        <div class="panel-body">
            <h1></h1>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>

