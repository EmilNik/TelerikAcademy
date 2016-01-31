<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPlaylist.aspx.cs" Inherits="YouTubePlaylistsSystem.Web.ViewPlaylist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="fvDetails"
        ItemType="YouTubePlaylistsSystem.Data.Models.Playlist"
        SelectMethod="fvDetails_GetItem">
        <ItemTemplate>
            <h1><%#: Item.Title %> <small>category: <%#: Item.Category.Name %></small></h1>
            <asp:Button runat="server" ID="deleteButton" OnClick="DeleteButton_Click" CssClass="btn btn-danger" Text="Delete Playlist" />
            <p>
                <%#: Item.Description %>
            </p>
            <p>
                Author: <%#: Item.User.UserName %>
            </p>
            <p class="pull-right">
                <%# Item.DateCreated %>
            </p>
            <asp:Repeater runat="server" ID="VideosRepeater" ItemType="YouTubePlaylistsSystem.Data.Models.Video" SelectMethod="videoRepeater_Select">
                <HeaderTemplate>
                    <h3>Videos in this playlist:</h3>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <iframe width="420" height="345" src='<%# string.Format($"http://www.youtube.com/embed/{Item.URL}") %>'></iframe>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
