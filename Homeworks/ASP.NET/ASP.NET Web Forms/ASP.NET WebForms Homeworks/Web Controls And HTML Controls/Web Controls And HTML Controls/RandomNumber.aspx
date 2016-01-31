<%@ Page Title="Random Number" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RandomNumber.aspx.cs" Inherits="Web_Controls_And_HTML_Controls.RandomNumber" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Random Number</h1>
    <input id="randomNumberMin" runat="server" value="Enter Min Value" />
    <input id="randomNumberMax" runat="server" value="Enter Max Value" />
    <asp:Button ID="randomNumberSubmit" runat="server" Text="Generate random number" OnClick="generateRandomNumber" />
    <br />
    <br />
    <asp:Label ID="randomNumberOutput" runat="server" Text=" "></asp:Label>

</asp:Content>
