<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="YouTubePlaylistsSystem.Web.Account.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="fvDetails"
        ItemType="YouTubePlaylistsSystem.Data.Models.User"
        SelectMethod="fvDetails_GetItem">
        <ItemTemplate>
            <h1><%#: Item.UserName %></h1>
            <a class="btn btn-default" href="Manage.aspx">Edit Profile</a>
            <h2><%#: Item.FirstName %> <%#: Item.LastName %> </h2>

            <asp:Image runat="server" ID="profilePic" ImageUrl="<%# Item.imageURL %>" CssClass="pull-right" />

            <h3>Number of playlists: <%# Item.Playlists.Count() %></h3>
            <asp:ListView runat="server" ItemType="YouTubePlaylistsSystem.Data.Models.Playlist" DataSource="<%# Item.Playlists.OrderByDescending(x => x.DateCreated) %>">
                    <LayoutTemplate>
                        <ul runat="server" id="itemPlaceholder">
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <a href="/ViewPlaylist.aspx?id=<%# Item.Id %>"><strong><%#: Item.Title %></strong> <i>by <%#: Item.User.UserName %></i></a>
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        Nothing to see here.
                    </EmptyDataTemplate>
                </asp:ListView>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
