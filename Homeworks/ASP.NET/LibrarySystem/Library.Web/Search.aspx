<%@ Page Title="Search Result for Query" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Library.Web.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
        <h1><%: Title %>
            <asp:Literal runat="server" ID="LiteralSearchQuery" Mode="Encode"></asp:Literal></h1>
    </div>

    <asp:Repeater runat="server" ID="Reapeater" ItemType="Library.Web.Models.Book" SelectMethod="Reapeater_GetData">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink NavigateUrl='<%# string.Format("~/BookDetails.aspx?id={0}", Item.Id) %>' runat="server" ID="HyperLinkBook" Text="<%# GetTitle(Item) %>" />
                (Category: <%#: Item.Category.Name %>)                 
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>


    <div class="back-link">
        <a href="/">Back to books</a>
    </div>
</asp:Content>
