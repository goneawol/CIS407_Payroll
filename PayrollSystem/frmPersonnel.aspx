<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmPersonnel.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="style1" align="center">
        <asp:Label ID="Label6" runat="server" Text="Add User"></asp:Label>
        <br />
        <br />
    
    <asp:Panel ID="Panel1" runat="server" Height="250px" Width="600px" 
            HorizontalAlign="Left">
        
        <asp:Label ID="Label1" runat="server" Text="First Name:"></asp:Label>
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="fNameValidator" runat="server" 
            ControlToValidate="txtFirstName" ErrorMessage="Required" 
            ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        
        <asp:Label ID="Label2" runat="server" Text="Last Name:" width="71px"></asp:Label>
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="lNameValidator" runat="server" 
            ControlToValidate="txtLastName" ErrorMessage="Required" 
            ForeColor="Red"></asp:RequiredFieldValidator>
        <br />

        <asp:Label ID="Label3" runat="server" Text="Pay Rate:" width="71px"></asp:Label>
        <asp:TextBox ID="txtPayRate" runat="server"></asp:TextBox>



        &nbsp;<asp:RequiredFieldValidator ID="payRateValidator" runat="server" 
            ControlToValidate="txtPayRate" ErrorMessage="Required" 
            ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        
        <asp:Label ID="Label4" runat="server" Text="Start Date:" width="71px"></asp:Label>
        <asp:TextBox ID="txtStartDate" runat="server" ForeColor="#999999">Ex: 01/05/1998</asp:TextBox>
        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
            runat="server" ControlToValidate="txtStartDate" 
            ErrorMessage="Date not formatted correctly (xx/xx/xxxx)" ForeColor="Red" 
            ValidationExpression="^(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])/(19|20)\d\d$"></asp:RegularExpressionValidator>
        <br />

        <asp:Label ID="Label5" runat="server" Text="End Date:" width="71px"></asp:Label>
        <asp:TextBox ID="txtEndDate" runat="server" ForeColor="#999999">Ex: 01/05/2012</asp:TextBox>
        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
            runat="server" ControlToValidate="txtEndDate" 
            ErrorMessage="Date not formatted correctly (xx/xx/xxxx)" ForeColor="Red" 
            ValidationExpression="^(0[1-9]|1[012])/(0[1-9]|[12][0-9]|3[01])/(19|20)\d\d$"></asp:RegularExpressionValidator>
        <br />
        <br />

        <asp:Button ID="btnSubmit" runat="server" 
            Text="Submit" onclick="btnSubmit_Click" />
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </asp:Panel>
    </div>
</asp:Content>

