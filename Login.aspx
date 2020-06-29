<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExamAxity.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>User</td>
                    <td><asp:TextBox runat="server" ID="txtUser" ></asp:TextBox></td>
                    <td><asp:Label runat="server" ID="lblMsg" ForeColor="Red" Visible="False"></asp:Label></td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td><asp:TextBox runat="server" ID="TxtPassword" TextMode="Password" ></asp:TextBox></td>
                    <td><asp:Button ID="btnLogin"  Text="Login" runat="server" OnClick="btnLogin_Click"/></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
