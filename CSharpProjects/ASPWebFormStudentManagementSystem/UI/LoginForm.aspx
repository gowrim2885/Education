<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="ASPWebFormStudentManagementSystem.pages.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../style/LoginFormStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="LoginForm" class="form" runat="server">
        <div id="header">Student Management System</div>
        <div class="container">
  
           <!-- Role -->
           <div class ="table">
               <div class="form-group">
                   <asp:Label runat="server" Text="Role"></asp:Label>
                    <asp:DropDownList ID="ddlRole" CssClass="ddlRolestyle" runat="server">
                       <asp:ListItem Selected="True" Text="-- Role --"> </asp:ListItem>
                       <asp:ListItem>Admin</asp:ListItem>
                       <asp:ListItem>Student</asp:ListItem>
                       <asp:ListItem Value="Faculty"></asp:ListItem>
                   </asp:DropDownList>
                </div>

                <!-- User Name -->
                <div class="form-group">
                        <asp:Label runat="server" Text="User Name"></asp:Label>
                        <asp:TextBox runat="server"  CssClass="input" ID="txtusername"></asp:TextBox>
                </div>

                <!-- Password -->
                <div class="form-group">
                    <asp:Label runat="server" Text="Password"></asp:Label>
                    <asp:TextBox runat="server"  ID="txtpassword" CssClass="input" TextMode="password"></asp:TextBox>
                </div>
   
                <!-- Button -->
                <div class="form-group">
                    <asp:Button ID="loginBtn" runat="server" CssClass="btn" Text="Login" />
                    <asp:Button ID="resetBtn" runat="server" CssClass="btn" Text="Reset" />
                </div>
           </div>
               
            <br />
        </div>
    </form>
</body>
</html>
