<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Library.Web.Book" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1><%: this.Title %></h1>
        <div class="search-button">
            <div class="form-search">
                <div class="input-append">
                    <asp:TextBox runat="server" ID="TextBoxSearchParam" Type="text" Name="q" CssClass="col-md-3 search-query" PlaceHolder="Search by book title / author..."></asp:TextBox>
                    <asp:LinkButton runat="server" ID="LinkButtonSearch" OnClick="LinkButtonSearch_Click" CssClass="btn btn-secondary" Text="Search"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <asp:ListView runat="server" ID="ListViewCategories"
        ItemType="Library.Web.Models.Category"
        SelectMethod="ListViewCategories_GetData"
        GroupItemCount="3">
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <div class="col-md-4">
                <h2><%# Item.Name %></h2>
                <asp:Repeater runat="server" ID="RepeaterBooks"
                    ItemType="Library.Web.Models.Book"
                    DataSource="<%# Item.Books %>">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/BookDetails.aspx?id={0}", Item.Id) %>'
                                Text='<%# string.Format($"\"{Item.Title}\" by <i>{Item.Author}</i>") %>'></asp:HyperLink>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
