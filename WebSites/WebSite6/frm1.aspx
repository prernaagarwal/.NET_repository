<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm1.aspx.cs" Inherits="frm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lbl" runat="server"></asp:Label><br /><br />
        <asp:Button ID ="btn1" runat="server" text ="submit" OnClick="btn1_Click"/> 
        <asp:Button ID ="Button1" runat="server" text ="Next Page" OnClick="Button1_Click"/> 
    </div>
    </form>
</body>
</html>
