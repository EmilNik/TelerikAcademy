<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="YouTubePlaylistsSystem.Web.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="search-button pull-right col-md-3">
        <div class="form-search">
            <div class="input-append">
                <asp:TextBox runat="server" ID="TextBoxSearchParam" type="text" name="q" class="col-md-3 search-query" placeholder="Search by playlist title / author..."></asp:TextBox>
                <asp:LinkButton runat="server" ID="LinkButtonSearch" OnClick="LinkButtonSearch_Click" CssClass="btn  btn-primary" Text="Search"></asp:LinkButton>
                <p>I'm definitely not gonna be a front-ender...</p>
            </div>
        </div>
    </div>
    <h1>Most Popular</h1>
    <h2>10 Most Popular Playlists</h2>
    <asp:Repeater runat="server" ID="repeaterPlaylist"
        ItemType="YouTubePlaylistsSystem.Data.Models.Playlist"
        SelectMethod="repeaterPlaylist_GetData1">
        <ItemTemplate>
            <h3>
                <a href="ViewPlaylist.aspx?id=<%# Item.Id %>"><%#: Item.Title %></a>
                <small><%#: Item.Category.Name %></small>
            </h3>
            <p>
                <%#: Item.Description %>
            </p>
            <p>
                Rates: <%# Item.Rates.Count() %>
            </p>
            <i>by <%#: Item.User.UserName %> created on: <%# Item.DateCreated %>
            </i>
        </ItemTemplate>
    </asp:Repeater>

    <asp:ListView runat="server" ID="lvCategories"
        ItemType="YouTubePlaylistsSystem.Data.Models.Category"
        SelectMethod="lvCategories_GetData">
        <LayoutTemplate>
            <h2>All categories</h2>
            <div runat="server" id="itemPlaceholder"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="col-md-6">
                <h3>
                    <asp:HyperLink runat="server" ID="CategoryHyperLink" NavigateUrl='<%# string.Format($"~/Categories?id={Item.Id}") %>' Text=' <%#: Item.Name %>'></asp:HyperLink></h3>
                <asp:ListView runat="server" ItemType="YouTubePlaylistsSystem.Data.Models.Playlist" DataSource="<%# Item.Playlists.OrderByDescending(x => x.DateCreated).Take(3) %>">
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
    </asp:ListView>
</asp:Content>
