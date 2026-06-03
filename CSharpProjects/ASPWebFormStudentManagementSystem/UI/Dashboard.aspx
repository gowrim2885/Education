<%@ Page Title="DashboardPage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ASPWebFormStudentManagementSystem.pages.Dashboard" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../style/dashboard.css" rel="stylesheet" type="text/css" />

    <div class ="card">
        <section>

            <asp:Label ID="lbStudentCount" runat="server" Text="Total Students Count"></asp:Label>
            <br />
            <asp:TextBox ID="txtStudentCount" runat="server" ReadOnly="true"></asp:TextBox>

        </section>
        <section>

            <asp:Label ID="lbDepartmentCount" runat="server" Text="Total Departments Count"></asp:Label>
            <br />
            <asp:TextBox ID="txtDepartmentCount" runat="server" ReadOnly="true"></asp:TextBox>

        </section>
       <!--  <section>

            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

        </section>
        <section>

            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>

        </section> 
           -->

        </div>
          <div class="chartstyle">
            <asp:Chart ID="Chart1" runat="server"  Width="600px" Height="400px">
                <series>
                    <asp:Series Name="Series1" XValueMember="DepartmentName" YValueMembers = "StudentCount">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
               
              <asp:Label ID="ChartTitle" class="charttitle" runat="server">Student Per Department</asp:Label>
        </div>
          
</asp:Content>
