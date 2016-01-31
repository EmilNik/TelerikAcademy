<%@ Page Title="Create Playlist" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="YouTubePlaylistsSystem.Web.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Create Playlist</h1>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Title</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                CssClass="text-danger" ErrorMessage="The Title field is required." />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label">Description</asp:Label>
        <div class="col-md-10">
            <asp:TextBox TextMode="MultiLine" runat="server" ID="Description" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Description"
                CssClass="text-danger" ErrorMessage="The Description field is required." />
        </div>
    </div>
    <div class="form-group">
        <asp:Label runat="server" CssClass="col-md-2 control-label">Category</asp:Label>
        <div class="col-md-10">
            <asp:DropDownList runat="server" ID="CategoryDropDown" CssClass="form-control">
            </asp:DropDownList>
        </div>
    </div>
    <br />
    <div id="videoURLDiv" runat="server">
        <asp:Label runat="server" AssociatedControlID="VideoURl" CssClass="col-md-2 control-label">VideoURl</asp:Label>
        <div class="col-md-10">
            <asp:TextBox runat="server" ID="VideoURl" CssClass="form-control" />
        </div>
        <%--<asp:Button runat="server" ID="AddButton" OnClick="Add_Click" Text="Add more URLs" CssClass="btn btn-default"/>--%>
    </div>
    <div class="form-group">
        <asp:Button runat="server" ID="SubmitButton" OnClick="CreatePlaylist_Click" Text="Create" CssClass="btn btn-primary" />
    </div>
</asp:Content>