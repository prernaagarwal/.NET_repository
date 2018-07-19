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
             <td>EmpId<asp:TextBox ID="lblEmpID" runat="server"></asp:TextBox></td>
             <td>EmpName<asp:TextBox ID="lblEmpName" runat="server"></asp:TextBox></td>
             <td>EmpSalary<asp:TextBox ID="lblEmpSalary" runat="server"></asp:TextBox></td>
             <td>EmpDoj<asp:TextBox ID="lblEmpDoj" runat="server"></asp:TextBox></td>
             <td><asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" /></td>
             <td><asp:Button ID="Button2" runat="server" Text="Final Submit" OnClick="Button2_Click" /></td>
        </tr>
        <tr>
            <td colspan="2"><asp:GridView ID="gridview1" runat="server"></asp:GridView></td>
            <td style="background-color: black"></td>
            <td colspan="2"><asp:GridView ID="gridview2" runat="server"></asp:GridView></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
