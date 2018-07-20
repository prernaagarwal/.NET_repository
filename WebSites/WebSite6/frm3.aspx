<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm3.aspx.cs" Inherits="frm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="welcome" runat="server" Text="Welcome"></asp:Label><br /><br />
        <%--<asp:GridView ID="grid" runat="server"></asp:GridView>--%><br /><br />
        <asp:GridView ID="grid" runat="server" EnableViewState="False"></asp:GridView><br /><br />
        <asp:Button ID="btn" runat="server" Text="Postback" />
    </div>
    </form>
</body>
</html>
