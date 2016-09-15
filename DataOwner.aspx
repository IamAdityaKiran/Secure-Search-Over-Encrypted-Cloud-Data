<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataOwner.aspx.cs" Inherits="Final_Project.DataOwner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/css/materialize.min.css" />
     <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.5/js/materialize.min.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <asp:Button ID="Upload" runat="server" Text="Upload File" OnClick="Upload_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Check" runat="server" Text="check for requests" OnClick="Check_Click" />
        <br /><br />
        <asp:Panel ID="upload_panel" Visible="false" runat="server">
            <asp:Table runat="server" Width="389px">
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Panel runat="server" HorizontalAlign="Center">
                        <asp:FileUpload runat="server" ID="fileupload" AllowMultiple="false" /><br /><br />
                            </asp:Panel>
                        <%--<div class="file-field input-field">
                            <div class="btn">
                                <span>File</span>
                                <input runat="server" id="file1" type="file" />
                            </div>
                            <div class="file-path-wrapper">
                                <input id="Text1" runat="server" class="file-path validate" type="text" />
                            </div>
                        </div>--%>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button Enabled="true" runat="server" ID="Gen_Keys" Text="Gen Keys" OnClick="Keys_Click"></asp:Button>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /><br /> 
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="ENC" Text="Encrypt & Save" runat="server" OnClick="ENC_Click"></asp:Button>
                        <br /><br />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Height="166px" TextMode="MultiLine" Width="690px"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="check_panel" Visible="false" OnLoad="check_panel_Load" runat="server">
            <asp:Label ID="Checked_Results" runat="server"></asp:Label>
            <asp:Panel ID="Panel1" runat="server" Visible="false">
            <asp:Table BorderStyle="Solid" ID="Table1" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="200px">
                        <asp:Label runat="server" ID="File_Name1"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="200px">
                        <asp:Label runat="server" ID="File_User1"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="300px">
                        <asp:Button runat="server" Width="150px" Text="Accept" ID="Accept1" OnClick="Accept_click" />
                        <asp:Button runat="server" Width="150px" Text="Reject" ID="Reject1" OnClick="Reject_click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
            <asp:Table BorderStyle="Solid" ID="Table2" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="200px">
                        <asp:Label runat="server" ID="File_Name2"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="200px">
                        <asp:Label runat="server" ID="File_User2"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="300px">
                        <asp:Button runat="server" Width="150px" Text="Accept" ID="Accept2" OnClick="Accept_click" />
                        <asp:Button runat="server" Width="150px" Text="Reject" ID="Reject2" OnClick="Reject_click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
            <asp:Panel ID="Panel3" runat="server" Visible="false">
            <asp:Table BorderStyle="Solid" ID="Table3" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="200px">
                        <asp:Label runat="server" ID="File_Name3"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="200px">
                        <asp:Label runat="server" ID="File_User3"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="300px">
                        <asp:Button runat="server" Width="150px" Text="Accept" ID="Accept3" OnClick="Accept_click" />
                        <asp:Button runat="server" Width="150px" Text="Reject" ID="Reject3" OnClick="Reject_click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
            <asp:Panel ID="Panel4" runat="server" Visible="false">
            <asp:Table BorderStyle="Solid" ID="Table4" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="200px">
                        <asp:Label runat="server" ID="File_Name4"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="200px">
                        <asp:Label runat="server" ID="File_User4"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="300px">
                        <asp:Button runat="server" Width="150px" Text="Accept" ID="Accept4" OnClick="Accept_click" />
                        <asp:Button runat="server" Width="150px" Text="Reject" ID="Reject4" OnClick="Reject_click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
            <asp:Panel ID="Panel5" runat="server" Visible="false">
            <asp:Table BorderStyle="Solid" ID="Table5" runat="server">
                <asp:TableRow>
                    <asp:TableCell Width="200px">
                        <asp:Label runat="server" ID="File_Name5"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="200px">
                        <asp:Label runat="server" ID="File_User5"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="300px">
                        <asp:Button runat="server" Width="150px" Text="Accept" ID="Accept5" OnClick="Accept_click" />
                        <asp:Button runat="server" Width="150px" Text="Reject" ID="Reject5" OnClick="Reject_click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>

        </asp:Panel>
    </div>
    </form>
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
</body>
</html>
