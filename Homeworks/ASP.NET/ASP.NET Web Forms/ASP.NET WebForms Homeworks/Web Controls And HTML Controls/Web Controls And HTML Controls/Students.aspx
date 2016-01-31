<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Students.aspx.cs" Inherits="Web_Controls_And_HTML_Controls.Students" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Register Student</h1>
    <br />
    <label for="first-name">First Name: </label>
    <input type="text" id="first-name" />
    <br />
    <label for="last-name">Last Name: </label>
    <input type="text" id="last-name" />
    <br />
    <label for="faculty-number">Faculty number: </label>
    <input type="text" id="faculty-number" />
    <br />
    <label for="university">University: </label>
    <asp:DropDownList ID="university" runat="server"
        AutoPostBack="True"
        OnSelectedIndexChanged="Selection_Change_University">
        <asp:ListItem Value="0">Choose University:</asp:ListItem>
        <asp:ListItem>University 1</asp:ListItem>
        <asp:ListItem>University 2</asp:ListItem>
        <asp:ListItem>University 3</asp:ListItem>
        <asp:ListItem>University 4</asp:ListItem>
    </asp:DropDownList>
    <br />
    <div id="specialityDiv" runat="server" visible="false">
        <label for="speciality">Speciality: </label>
        <asp:DropDownList ID="speciality" runat="server"
            AutoPostBack="True"
            OnSelectedIndexChanged="Selection_Change_Speciality">
            <asp:ListItem Value="0">Choose Speciality:</asp:ListItem>
            <asp:ListItem>Speciality 1</asp:ListItem>
            <asp:ListItem>Speciality 2</asp:ListItem>
            <asp:ListItem>Speciality 3</asp:ListItem>
            <asp:ListItem>Speciality 4</asp:ListItem>
        </asp:DropDownList>
        <br />
        <div id="coursesDiv" runat="server" visible="false">
            <label for="courses">Courses: </label>
            <asp:ListBox ID="courses"
                SelectionMode="Multiple"
                runat="server">
                <asp:ListItem>Item 1</asp:ListItem>
                <asp:ListItem>Item 2</asp:ListItem>
                <asp:ListItem>Item 3</asp:ListItem>
                <asp:ListItem>Item 4</asp:ListItem>
                <asp:ListItem>Item 5</asp:ListItem>
                <asp:ListItem>Item 6</asp:ListItem>
                <asp:ListItem>Course 1</asp:ListItem>
                <asp:ListItem>Course 2</asp:ListItem>
                <asp:ListItem>Course 3</asp:ListItem>
                <asp:ListItem>Course 4</asp:ListItem>
                <asp:ListItem>Course 5</asp:ListItem>
                <asp:ListItem>Course 6</asp:ListItem>
                <asp:ListItem>Other 1</asp:ListItem>
                <asp:ListItem>Other 2</asp:ListItem>
                <asp:ListItem>Other 3</asp:ListItem>
                <asp:ListItem>Other 4</asp:ListItem>
                <asp:ListItem>Other 5</asp:ListItem>
                <asp:ListItem>Other 6</asp:ListItem>
            </asp:ListBox>
            <br />
            <asp:Button ID="registerButton" runat="server"
                OnClick="Register"
                Text="Register" />
        </div>
    </div>
</asp:Content>
