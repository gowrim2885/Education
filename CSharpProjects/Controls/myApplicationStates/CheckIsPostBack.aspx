<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckIsPostBack.aspx.cs" Inherits="MyApp.CheckIsPostBack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Text1 {
            width: 130px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="FirstName"></asp:Label>
        <input id="Text1" type="text" /><br />

        <asp:Label ID="Label2" runat="server" Text="LastName"></asp:Label> 
        <input id="Text2" type="text" />
      
        <br />

        <asp:Label ID="Label3" runat="server" Text="City"></asp:Label>
  
        <asp:DropDownList ID="DropDownList1" runat="server">
           
        </asp:DropDownList>
        <br />
       <br />

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
