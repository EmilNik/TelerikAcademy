<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASP.NET_Web_Forms_Application._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Enter your name</h1>
        <input id="name" runat="server">">
        <asp:Button runat="server" ID="PrintNameButton" OnClick="PrintName" Text="Submit" />
        <br />
        <asp:Label runat="server" ID="OutputLabel" Text=" "></asp:Label>
    </div>
</asp:Content>
