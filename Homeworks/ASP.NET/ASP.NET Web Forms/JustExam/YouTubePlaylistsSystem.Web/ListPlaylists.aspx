<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPlaylists.aspx.cs" Inherits="YouTubePlaylistsSystem.Web.ListPlaylists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:GridView runat="server" ID="usersGrid"
            AllowPaging="true"
            PageSize="10"
            ItemType="YouTubePlaylistsSystem.Data.Models.Playlist"
            DataKeyNames="Id"
            AllowSorting="true"
            AutoGenerateColumns="false"
            SelectMethod="GridViewPlaylists_GetData"
            CssClass="col-md-8">
            <Columns>
                <asp:DynamicField DataField="Id" />
                <asp:HyperLinkField DataTextField="Title" DataNavigateUrlFormatString="~/ViewPlaylist?id={0}" datanavigateurlfields="Id"/>
                <asp:DynamicField DataField="DateCreated" />
            </Columns>
        </asp:GridView>
</asp:Content>
