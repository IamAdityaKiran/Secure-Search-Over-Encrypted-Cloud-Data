<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="Final_Project.UserHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Home</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <center>
            
            <asp:TextBox ID="Keywords" runat="server" Width="792px"></asp:TextBox>
            &nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button runat="server" ID="search" OnClick="Search_Click" Text="Search" />
        </center>

        <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>

        <br /><br />
        <asp:Table BorderStyle="Dashed" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell Width="400px">
                    <asp:Label ID="Label1" runat="server">Name of the file</asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell Width="400px">
                    <asp:Label ID="Label2" runat="server">Owner of the file</asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell Width="300px">
                    <asp:Label ID="Label3" runat="server">Action</asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <asp:Table BorderStyle="Dashed" ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Name1"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Owner1"></asp:Label></asp:TableCell>
                    <asp:TableCell Width="300px">
                        <asp:Button runat="server" Text="Request" ID="Button1" OnClick="button_click" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Visible="false">
            <asp:Table ID="Table2" BorderStyle="Dashed" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Name2"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Owner2"></asp:Label></asp:TableCell>
                    <asp:TableCell Width="300px">
                        <asp:Button runat="server" ID="Button2" Text="Request" OnClick="button_click" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Visible="false">
            <asp:Table ID="Table3" BorderStyle="Dashed" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Name3"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Owner3"></asp:Label></asp:TableCell>
                    <asp:TableCell Width="300px">
                        <asp:Button runat="server" ID="Button3" Text="Request" OnClick="button_click" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server"  Visible="false">
            <asp:Table ID="Table4" BorderStyle="Dashed" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Name4"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Owner4"></asp:Label></asp:TableCell>
                    <asp:TableCell Width="300px">
                        <asp:Button runat="server" ID="Button4" Text="Request" OnClick="button_click" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
        <asp:Panel ID="Panel5" runat="server" Visible="false">
            <asp:Table ID="Table5" BorderStyle="Solid" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Name5"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Owner5"></asp:Label></asp:TableCell>
                    <asp:TableCell Width="300px">
                        <asp:Button runat="server" ID="Button5" Text="Request" OnClick="button_click" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
        <asp:Panel ID="Panel6" runat="server" Visible="false">
            <asp:Table ID="Table6" BorderStyle="Solid" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Name6"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Owner6"></asp:Label></asp:TableCell>
                    <asp:TableCell Width="300px">
                        <asp:Button runat="server" ID="Button6" Text="Request" OnClick="button_click" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
        <asp:Panel ID="Panel7" runat="server" Visible="false">
            <asp:Table ID="Table7" BorderStyle="Solid" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Name7"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Owner7"></asp:Label></asp:TableCell>
                    <asp:TableCell Width="300px">
                        <asp:Button runat="server" ID="Button7" Text="Request" OnClick="button_click" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
        <asp:Panel ID="Panel8" runat="server" Visible="false">
            <asp:Table ID="Table8" BorderStyle="Solid" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Name8"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Owner8"></asp:Label></asp:TableCell>
                    <asp:TableCell Width="300px">
                        <asp:Button runat="server" ID="Button8" Text="Request" OnClick="button_click" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
        <asp:Panel ID="Panel9" runat="server" Visible="false">
            <asp:Table ID="Table9" BorderStyle="Solid" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Name9"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Owner9"></asp:Label></asp:TableCell>
                    <asp:TableCell Width="300px">
                        <asp:Button runat="server" ID="Button9" Text="Request" OnClick="button_click" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
        <asp:Panel ID="Panel10" runat="server" Visible="false">
            <asp:Table ID="Table10" BorderStyle="Solid" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Name10"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="400px">
                        <asp:Label runat="server" ID="File_Owner10"></asp:Label></asp:TableCell>
                    <asp:TableCell Width="300px">
                        <asp:Button runat="server" ID="Button10" Text="Request" OnClick="button_click" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
        <asp:Panel ID="After_Req" runat="server" Visible="False">
            <asp:Table runat="server" Height="598px" Width="1476px">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label4" runat="server">Name of the File</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="filename" Width="1000px" Enabled="false"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label5" runat="server">File contents</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="filecontents" Width="1000px" Height="500px" Enabled="false" TextMode="MultiLine"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label6" runat="server">Enter the key</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="key" Enabled="true"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label7" runat="server">Key is sent by Owner</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button runat="server" ID="decrypt" OnClick="decrypt_Click" Text="Decrypt" />
                    </asp:TableCell>
                </asp:TableRow>

            </asp:Table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
