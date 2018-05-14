<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OpenAuthProviders.ascx.cs" Inherits="Account_OpenAuthProviders" %>

<fieldset class="open-auth-providers">
    <legend></legend>
    
    <asp:ListView runat="server" ID="providerDetails" ItemType="Microsoft.AspNet.Membership.OpenAuth.ProviderDetails"
        SelectMethod="GetProviderNames" ViewStateMode="Disabled">
        <ItemTemplate>
            <button type="submit" name="provider" value="<%#: Item.ProviderName %>"
                title="Inicie sesión con su <%#: Item.ProviderDisplayName %> cuenta.">
                <%#: Item.ProviderDisplayName %>
            </button>
        </ItemTemplate>
    
        <EmptyDataTemplate>
            <div class="message-info">
        
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
</fieldset>