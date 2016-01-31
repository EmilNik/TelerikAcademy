<%@ Page Title="Escaping" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Escaping.aspx.cs" Inherits="Web_Controls_And_HTML_Controls.Escaping" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Escaping</h1>
    <asp:TextBox ID="escapingInput" runat="server" Width="330px">&lt;h1&gt;Heading&lt;/h1&gt;Text&lt;script&gt;alert(&quot;bug!&quot;)&lt;/script&gt;</asp:TextBox>
    <asp:Button ID="escapeButton" runat="server" Text="Show Text" OnClick="ShowText" />
    <br />
    <strong>Label (unescaped):
    </strong>
    <br />
    <asp:Label ID="escapedLabel" runat="server"></asp:Label>
    <br />
    <strong>Label (escaped):
    </strong>
    <br />
    <asp:Literal ID="unescapedLabel" runat="server" Mode="Encode"></asp:Literal>
</asp:Content>
