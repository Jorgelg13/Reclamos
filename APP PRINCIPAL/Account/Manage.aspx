
<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="Account_Manage" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
    </hgroup>
    <div class=" col-sm-4">
        <div class="panel-body">
            <h1></h1>
        </div>
    </div>

    <div class=" panel panel-default col-sm-4">
        <section id="passwordForm">
            <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                <p class="message-success"><%: SuccessMessage %></p>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="setPassword" Visible="false">
                <p>
                    No dispone de contraseña local para este sitio. Agregue una contraseña
                local para iniciar sesión sin que sea necesario ningún inicio de sesión externo.
                </p>
                <fieldset>
                    <legend>Formulario para establecer contraseña</legend>
                    <ol>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="password">Contraseña</asp:Label>
                            <asp:TextBox runat="server" ID="password" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="password"
                                CssClass="field-validation-error" ErrorMessage="El campo de contraseña es obligatorio."
                                Display="Dynamic" ValidationGroup="SetPassword" />

                            <asp:ModelErrorMessage runat="server" ModelStateKey="NewPassword" AssociatedControlID="password"
                                CssClass="field-validation-error" SetFocusOnError="true" />

                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="confirmPassword">Confirmar contraseña</asp:Label>
                            <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="confirmPassword"
                                CssClass="field-validation-error" Display="Dynamic" ErrorMessage="El campo de confirmación de contraseña es obligatorio."
                                ValidationGroup="SetPassword" />
                            <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="confirmPassword"
                                CssClass="field-validation-error" Display="Dynamic" ErrorMessage="La contraseña y la contraseña de confirmación no coinciden."
                                ValidationGroup="SetPassword" />
                        </li>
                    </ol>
                    <asp:Button runat="server" Text="Establecer contraseña" ValidationGroup="SetPassword" OnClick="setPassword_Click" />
                </fieldset>
            </asp:PlaceHolder>

            <asp:PlaceHolder runat="server" ID="changePassword" Visible="false">
                <h3>Formulario de cambio de contraseña</h3>
                <br />
                <asp:ChangePassword runat="server" CancelDestinationPageUrl="~/" ViewStateMode="Disabled" RenderOuterTable="false" SuccessPageUrl="Manage?m=ChangePwdSuccess">
                    <ChangePasswordTemplate>
                        <p class="validation-summary-errors">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                        <fieldset class="changePassword">

                            <ol>
                                <li>
                                    <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword">Contraseña actual</asp:Label>
                                    <asp:TextBox runat="server" ID="CurrentPassword" Style="width: 90%" CssClass="form-control" TextMode="Password" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                                        CssClass="field-validation-error" ErrorMessage="El campo de contraseña actual es obligatorio." />
                                </li>
                                <li>
                                    <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword">Nueva contraseña</asp:Label>
                                    <asp:TextBox runat="server" ID="NewPassword" Style="width: 90%" CssClass="form-control" TextMode="Password" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                                        CssClass="field-validation-error" ErrorMessage="La contraseña nueva es obligatoria." />
                                </li>
                                <li>
                                    <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword">Confirmar la nueva contraseña</asp:Label>
                                    <asp:TextBox runat="server" ID="ConfirmNewPassword" Style="width: 90%" CssClass="form-control" TextMode="Password" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword"
                                        CssClass="field-validation-error" Display="Dynamic" ErrorMessage="La confirmación de la nueva contraseña es obligatoria." />
                                    <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                        CssClass="field-validation-error" Display="Dynamic" ErrorMessage="La nueva contraseña y la contraseña de confirmación no coinciden." />
                                </li>
                            </ol>
                            <br />
                            <asp:Button runat="server" CssClass="btn btn-primary" CommandName="ChangePassword" Text="Cambiar contraseña" />
                        </fieldset>
                    </ChangePasswordTemplate>
                </asp:ChangePassword>
            </asp:PlaceHolder>
        </section>
    </div>
    <div class=" col-sm-4">
        <div class="panel-body">
            <h1></h1>
        </div>
    </div>
   
</asp:Content>
