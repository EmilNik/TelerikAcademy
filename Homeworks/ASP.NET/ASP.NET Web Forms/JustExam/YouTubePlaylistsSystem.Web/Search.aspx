<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="YouTubePlaylistsSystem.Web.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-md-12">
        <h1><%: Title %>
            <asp:Literal runat="server" ID="LiteralSearchQuery" Mode="Encode"></asp:Literal></h1>
    </div>

    <asp:Repeater runat="server" ID="Reapeater" ItemType="YouTubePlaylistsSystem.Data.Models.Playlist" SelectMethod="Reapeater_GetData">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink NavigateUrl='<%# string.Format("~/ViewPlaylist.aspx?id={0}", Item.Id) %>' runat="server" ID="HyperLinkBook" Text="<%# Item.Title %>" />
                (Category: <%#: Item.Category.Name %>)                 
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>

    <div class="back-link">
        <a href="/">Back to home</a>
    </div>
</asp:Content>
