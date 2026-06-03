<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="ASPWebFormStudentManagementSystem.pages.AddStudent" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">

    <link href="../style/AddStudentStyle.css" rel="stylesheet" type="text/css" />

    <div class="form-Container">
        
        <asp:Label ID="pgTitle" class="pageheading" runat="server" Text="Add Student Detail" Width="449px"></asp:Label>

		<!-- Roll Number -->
        <div class="form-group">
            <asp:Label ID="lbRollNumber" runat="server" Text="Roll Number" AssociatedControlID="inputRollNumber"></asp:Label>
	        <br />
			<asp:TextBox ID="inputRollNumber" TextMode="Number" runat="server"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvRollNumber" runat="server" 
				ControlToValidate="inputRollNumber" ErrorMessage="Roll Number is Required" ForeColor="Red" />
        </div>

		<!-- Name -->
        <div class="form-group">
	        <asp:Label ID="lbName" runat="server" Text="Name" AssociatedControlID="inputName"></asp:Label>
	         <br />
			 <asp:TextBox ID="inputName" runat="server"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvName0" runat="server" 
				ControlToValidate="inputName" ErrorMessage="Name is Required" ForeColor="Red" />
	     </div>
	
		<!-- Email -->
	    <div class="form-group">
	        <asp:Label ID="lbEmail" runat="server" Text="Email" AssociatedControlID="inputEmail"></asp:Label>
	         <br />
			 <asp:TextBox ID="inputEmail" TextMode="Email" runat="server"></asp:TextBox>
	        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="inputEmail" ErrorMessage="Email is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="inputEmail" ErrorMessage="Enter Valid Email id" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
	    </div>

		<!-- Department -->
		<div class="form-group">
			<asp:Label ID="lbDepartment" runat="server" Text="Department" AssociatedControlID="ddlDepartment"></asp:Label>
			 <br />
			<asp:DropDownList ID="ddlDepartment"  class="styled-dropdown" runat="server">
			</asp:DropDownList>
			<asp:RequiredFieldValidator ID="rfvDepartment" runat="server" InitialValue="Select Department"
				ControlToValidate="ddlDepartment" ErrorMessage="Department is Required" ForeColor="Red" />
		</div>

        <!-- Address -->
        <div class="form-group">
			<asp:Label ID="lbAddress" runat="server" Text="Address" AssociatedControlID="inputAddress"></asp:Label>
			 <br />
			<asp:TextBox ID="inputAddress" runat="server" TextMode="MultiLine" Rows="2" Columns="30"> </asp:TextBox>
		</div>

		<!-- Gender -->
		<div class="form-group">
			<asp:Label ID="lbGender" runat="server" Text="Gender" AssociatedControlID="rblGenderList"></asp:Label>
			<br />
			<asp:RadioButtonList ID="rblGenderList" runat="server">
					<asp:ListItem class="ListItems" Text="Male" Value="Male"></asp:ListItem>
					<asp:ListItem Text="Female" Value="Female"></asp:ListItem>
			    </asp:RadioButtonList>
			<asp:RequiredFieldValidator ID="rfvGender" runat="server"  ErrorMessage="Gender is required" ForeColor="Red" ControlToValidate="rblGenderList" />
		</div>

		<!-- Age -->
        <div class="form-group">
			<asp:Label ID="lbAge" runat="server" Text="Age" AssociatedControlID="inputAge"></asp:Label>
			<br />
			<asp:TextBox ID="inputAge" TextMode="Number" runat="server"></asp:TextBox>

			<br />

			<asp:RangeValidator ID="rvAge" runat="server" ControlToValidate="inputAge" MinimumValue="16" MaximumValue="30" Type="Integer"
				ErrorMessage="Age must be between 16 and 30" ForeColor="Red" />
			<asp:RequiredFieldValidator ID="rfvAgeRequired" runat="server" ControlToValidate="inputAge" ErrorMessage="Age is required" ForeColor="Red" />
		</div>

		<!-- Date of Birth -->
		<div class="form-group">
			<asp:Label ID="lbDateOfBirth" runat="server" Text="Date of Birth" AssociatedControlID="inputDateOfBirth"></asp:Label>
			 <br />
			<asp:TextBox ID="inputDateOfBirth" runat="server" TextMode="Date"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvDateOfBirth" runat="server" ControlToValidate="inputDateOfBirth" ErrorMessage="Date Of Birth Is Required" ForeColor="Red" />
		</div>

	    <!-- Phone number -->
		<div class="form-group">
			<asp:Label ID="lbPhone" runat="server" Text="Phone" AssociatedControlID="inputPhone"></asp:Label>
			 <br />
			<asp:TextBox ID="inputPhone" runat="server"></asp:TextBox>
		    <br />
		    <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="inputPhone"
				ErrorMessage="Enter valid 10 digit phone number" ForeColor="Red" ValidationExpression="^[0-9]{10}$" />
			<asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="inputPhone" ErrorMessage="Phone Number is required" ForeColor="Red" />
		</div>

       
		<!-- Admission Date  -->
		<div class="form-group">
			<asp:Label ID="lbAdmissionDate" runat="server" Text="Admission Date" AssociatedControlID="inputAddmissionDate"></asp:Label>
			 <br />
			<asp:TextBox ID="inputAddmissionDate" runat="server" TextMode="Date"></asp:TextBox>
		</div>

		<!-- Validation summary 
		<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red"/>
		-->

		<!--Button-->
		<div class="form-group">
			<asp:Button ID="AddStudBtn" class="submit-btn" runat="server" Text="Add Student" OnClick="AddStudBtn_Click" CausesValidation="true"/>
		
			<asp:Button ID="CancelBtn" runat="server" class="cancel-btn" Text="Cancel" OnClick="CancelBtn_Click"     CausesValidation="false"/>
		</div>

    </div>

</asp:Content>


