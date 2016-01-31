<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="YouTubePlaylistsSystem.Web.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView runat="server" ID="lvCategories"
        ItemType="YouTubePlaylistsSystem.Data.Models.Category"
        SelectMethod="lvCategories_GetData">
        <LayoutTemplate>
            <div runat="server" id="itemPlaceholder"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="col-md-12">
            <h1><%# Item.Name %></h1>
                <asp:ListView runat="server" ItemType="YouTubePlaylistsSystem.Data.Models.Playlist" DataSource="<%# Item.Playlists.OrderByDescending(x => x.DateCreated) %>">
                    <LayoutTemplate>
                        <ul runat="server" id="itemPlaceholder">
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <a href="ViewPlaylist.aspx?id=<%# Item.Id %>"><strong><%#: Item.Title %></strong> <i>by <%#: Item.User.UserName %></i></a>
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        No playlists.
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            <h1>No such category.</h1>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
