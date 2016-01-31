<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageLivecycle.aspx.cs" Inherits="ASP.NET_Web_Forms_Application.PageLivecycle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
        <asp:Button ID="ButtonOK" Text="OK" runat="server"
            OnInit="ButtonOK_Init" OnLoad="ButtonOK_Load" OnClick="ButtonOK_Click"
            OnPreRender="ButtonOK_PreRender" OnUnload="ButtonOK_Unload" />
    </form>
</body>
</html>
