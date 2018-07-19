<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="1">
        <tr>
            <td>Id</td>
            <td><asp:TextBox ID="txtEmpId" runat="server" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Name</td>
            <td><asp:TextBox ID="txtEmpName" runat="server" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Salary</td>
            <td><asp:TextBox ID="txtEmpSalary" runat="server" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Doj</td>
            <td><asp:TextBox ID="txtEmpDoj" runat="server" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" /></td>
        </tr>
    </table>    
    </div>
    </form>
</body>
</html>
