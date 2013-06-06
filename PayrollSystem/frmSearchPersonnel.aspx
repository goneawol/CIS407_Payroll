<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmSearchPersonnel.aspx.cs" Inherits="frmSearchPersonnel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div align="center">
    
        <asp:Label ID="Label1" runat="server" Text="Search for employee by last name:"></asp:Label>
&nbsp;<asp:TextBox ID="txtSearchName" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
            Text="Search" />
    
    </div>
</asp:Content>

