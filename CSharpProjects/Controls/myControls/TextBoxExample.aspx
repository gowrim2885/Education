<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextBoxExample.aspx.cs" Inherits="Controls.TextBoxExample" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Text Box Example</title>
</head>
<body>
    <form id="form1" runat="server">
        Name: 
        <asp:TextBox ID="txtName" runat="server" Columns="30" MaxLength="20" ToolTip="Enter your Nmae"></asp:TextBox>
        <br /><br />

        Password:
        <asp:TextBox ID="txtPassword" runat="server"
            ToolTip="Enter your Password" TextMode="Password"></asp:TextBox>
        <br /><br />

        Address:
        <asp:TextBox ID="txtAddress" runat="server" Height="100px" Width="200px" MaxLength="500"
            ToolTip="Enter your Address" TextMode="MultiLine"></asp:TextBox>
        <br /><br />

        ReadOnlyFeild:
        <asp:TextBox ID="txtReadonly" runat="server" ReadOnly="true" Text="Can not be modify"    
            TextMode="MultiLine"></asp:TextBox>
        <br /><br />
        
        AutoPstBack: 
        <asp:TextBox ID="txtAutoPost" runat="server" AutoPostBack ="true" 
            OnTextChanged="txtAutoPost_TextChanged"
            ToolTip="Enter your Address" TextMode="MultiLine" ></asp:TextBox>
        <br /><br />
        
        <asp:Button ID="submit" runat="server" Text="Submit" OnClick="Button_Click" />
        <br /><br />

        <asp:label ID="result1" runat="server"></asp:label>
        <asp:label ID="result2" runat="server"></asp:label>

    </form>
</body>
</html>
