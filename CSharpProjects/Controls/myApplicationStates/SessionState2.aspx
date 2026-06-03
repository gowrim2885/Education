<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionState2.aspx.cs" Inherits="WebApplication1.SessionState2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
         <div>
             <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> 
             <br />
             <br />
         </div>
         <p>
             <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" Width="146px" />
         </p>
     </form>
</body>
</html>
