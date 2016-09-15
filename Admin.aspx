<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Final_Project.Admin" %>

<!--DOCTYPE html-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <Center><h2>Admin</h2></Center>
        <h3>Create a new User</h3>
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server">Username:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="username" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server">Password:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="password" TextMode="Password" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label3" runat="server">Re-enter Password</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="password1" TextMode="Password" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label5" runat="server">Email:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="email" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label4" runat="server">Other Notes:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="Notes" TextMode="MultiLine" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:DropDownList ID="Type" runat="server">
                        <asp:ListItem>DataOwner</asp:ListItem>
                        <asp:ListItem>DataUser</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button runat="server" Text="Create" OnClick="Create_User" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        
    </div>
    </form>
</body>
</html>