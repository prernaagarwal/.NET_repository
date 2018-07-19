<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
            <tr>
                <td>EmpName<asp:TextBox ID="lblEmpName" runat="server"></asp:TextBox></td>
                <td>EmpSalary<asp:TextBox ID="lblEmpSalary" runat="server"></asp:TextBox></td>
                <td>EmpDoj<asp:TextBox ID="lblEmpDoj" runat="server"></asp:TextBox></td>
                <td><asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" /></td>
                <td><asp:Button ID="Button2" runat="server" Text="Final Submit" OnClick="Button2_Click" /></td>
            </tr>
    </table>
       <br />
        <br />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <br />
        <br />

    <asp:GridView ID="GridView2" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
