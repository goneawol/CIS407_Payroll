<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmSalaryCalculator.aspx.cs" Inherits="frmSalaryCalculator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Annual Hours: "></asp:Label>
        &nbsp;<asp:TextBox ID="txtAnnualHours" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Rate: "></asp:Label>
        &nbsp;<asp:TextBox ID="txtRate" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Calculate Salary" />
        <br />
        <asp:Label ID="lblSalary" runat="server" Text="$"></asp:Label>
    </div>
</asp:Content>

