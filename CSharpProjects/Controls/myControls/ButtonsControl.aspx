<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ButtonsControl.aspx.cs" Inherits="Controls.ButtonsControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Label ID="result1" runat="server"></asp:Label>
        <br />
        Select Gender:
        <br />
        <asp:RadioButton ID="MaleRadioButton" runat="server"
            OnCheckedChanged="MaleRadioButton_CheckedChanged" 
            Text ="Male" GroupName="Gender" TextAlign="Right"
            AutoPostBack="true"/>
        <br />
        
        <asp:RadioButton ID="FemaleRadioButton" runat="server"
            OnCheckedChanged="FemaleRadioButton_CheckedChanged" 
            Text="Female" GroupName="Gender" TextAlign="Right" 
            AutoPostBack="true"/>
        <br />
        <asp:Button ID="Submit" Text="Submit" runat="server" OnClick="Submit_Click" />

        
        <br />
        <br />

        <asp:Label ID="result2" runat="server"></asp:Label>
        <br />
        <asp:CheckBox ID="javascript" runat="server" OnCheckedChanged="Jsbox_CheckedChanged" AutoPostBack="true" Text="JavaScript"/>
        <br />
        <asp:CheckBox ID="html" runat="server" OnCheckedChanged="htmlbox_CheckedChanged" AutoPostBack="true" Text ="Html"/>
        <br />
        <asp:CheckBox ID="css" runat="server" OnCheckedChanged="cssbox_CheckedChanged" AutoPostBack="true" Text="CSS"/>
        <br />
        <asp:Button ID="Button2" Text="checkboxSubmit" runat="server" OnClick="checkboxSubmit_Click" />
        <br />
        <br />

        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" Text="About us"
            NavigateURL="~/About.aspx" Target="_blank"></asp:HyperLink>
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" OnClientClick="alert(&quot;Button clicked&quot;);"/>

        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm(&quot;Are you sure you want to continue?&quot;);">LinkButton</asp:LinkButton>
        <br />
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" Height="57px" Width="158px" ImageUrl="~/images/title_logo.jpg"/>
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" 
            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
       
       
    </form>
</body>
</html>
