<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div align="center">
        <asp:ImageButton ID="imgbtnCalculator" runat="server" Height="70px" 
            ImageUrl="~/Images/abacus.gif" PostBackUrl="~/frmSalaryCalculator.aspx" />
&nbsp;<asp:LinkButton ID="linkbtnCalculator" runat="server" 
            PostBackUrl="~/frmSalaryCalculator.aspx">Salary Calculator</asp:LinkButton>
        <br />
        <br />
        <asp:ImageButton ID="imgbtnNewEmployee" runat="server" Height="70px" 
            ImageUrl="~/Images/plus.png" PostBackUrl="~/frmPersonnel.aspx" />
&nbsp;<asp:LinkButton ID="linkbtnNewEmployee" runat="server" 
            PostBackUrl="~/frmPersonnel.aspx">Add Personnel</asp:LinkButton>
        <br />
        <br />
        <asp:ImageButton ID="imgbtnViewUserActivity" runat="server" Height="70px" 
            ImageUrl="~/Images/userActivity.png" 
            PostBackUrl="~/frmUserActivity.aspx" />
        <asp:LinkButton ID="linkbtnViewUserActivity" runat="server" 
            PostBackUrl="~/frmUserActivity.aspx">User Activity</asp:LinkButton>
        <br />
        <br />
        <asp:ImageButton ID="imgbtnViewPersonnel" runat="server" Height="70px" 
            ImageUrl="~/Images/personnel.jpg" PostBackUrl="~/frmViewPersonnel.aspx" />
&nbsp;<asp:LinkButton ID="linkbtnViewPersonnel" runat="server" 
            PostBackUrl="~/frmViewPersonnel.aspx">View Personnel</asp:LinkButton>
        <br />
        <br />
        <asp:ImageButton ID="imgbtnSearch" runat="server" Height="70px" 
            ImageUrl="~/Images/search.jpg" PostBackUrl="~/frmSearchPersonnel.aspx" />
&nbsp;<asp:LinkButton ID="linkbtnSearch" runat="server"  
            PostBackUrl="~/frmSearchPersonnel.aspx">Search Personnel</asp:LinkButton>
        <br />
        <br />
        <asp:ImageButton ID="imgbtnEditEmployees" runat="server" 
            ImageUrl="~/Images/people.jpg" PostBackUrl="~/frmEditPersonnel.aspx" 
            Width="70px" />
&nbsp;<asp:LinkButton ID="linkbtnEditEmployees" runat="server" 
            PostBackUrl="~/frmEditPersonnel.aspx">Edit Employees</asp:LinkButton>
        <br />
        <br />
        <asp:ImageButton ID="imgbtnManageUsers" runat="server" 
            ImageUrl="~/Images/user_lock.png" PostBackUrl="~/frmManageUsers.aspx" 
            Width="70px" />
&nbsp;<asp:LinkButton ID="linkbtnManageUsers" runat="server" 
            PostBackUrl="~/frmManageUsers.aspx">Manage Users</asp:LinkButton>
    </div>
</asp:Content>

