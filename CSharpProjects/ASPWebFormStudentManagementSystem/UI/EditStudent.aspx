<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="ASPWebFormStudentManagementSystem.pages.EditStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../style/AddStudentStyle.css" rel="stylesheet" type="text/css" />

    <div class="form-Container">

        <div class="page-title">
            <asp:Label ID="lbpagetitle" class="updatepgtitle" runat="server" Text="Update the Student Details"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label ID="lbRollNumber" runat="server" Text="Roll Number" AssociatedControlID="inputRollNumber"></asp:Label>
            <asp:TextBox ID="inputRollNumber" TextMode="Number" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lbName" runat="server" Text="Name" AssociatedControlID="inputName"></asp:Label>
            <asp:TextBox ID="inputName" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lbEmail" runat="server" Text="Email" AssociatedControlID="inputEmail"></asp:Label>
            <asp:TextBox ID="inputEmail" TextMode="Email" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lbDepartment" runat="server" Text="Department" AssociatedControlID="ddlDepartment"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlDepartment" runat="server">
            </asp:DropDownList>
        </div>


        <div class="form-group">
            <asp:Label ID="lbAddress" runat="server" Text="Address" AssociatedControlID="inputAddress"></asp:Label>
            <asp:TextBox ID="inputAddress" runat="server" TextMode="MultiLine" Rows="2" Columns="30"> </asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lbGender" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButtonList ID="rblGender" runat="server">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div class="form-group">
            <asp:Label ID="lbAge" runat="server" Text="Age" AssociatedControlID="inputAge"></asp:Label>
            <asp:TextBox ID="inputAge" TextMode="Number" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lbDateOfBirth" runat="server" Text="Date of Birth" AssociatedControlID="inputDateOfBirth"></asp:Label>
            <asp:TextBox ID="inputDateOfBirth" runat="server" TextMode="Date"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lbPhone" runat="server" Text="Phone" AssociatedControlID="inputPhone"></asp:Label>
            <asp:TextBox ID="inputPhone" runat="server"></asp:TextBox>
        </div>



        <div class="form-group">
            <asp:Label ID="lbAdmissionDate" runat="server" Text="Admission Date" AssociatedControlID="inputAddmissionDate"></asp:Label>
            <asp:TextBox ID="inputAddmissionDate" runat="server" TextMode="Date"></asp:TextBox>
            <br />
            <br />
        </div>

        <div class="btn-set">
            <asp:Button ID="Update_Btn" class="update-btn" runat="server" OnClick="UpdateBtn_Click" Text="Update" Width="193px" />
            <asp:Button ID="Cancel_Btn" class="cancel-btn" runat="server" OnClick="CancelBtn_Click" Text="Cancel" Width="239px" />
        </div>

    </div>

</asp:Content>


