<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmPersonnelVerified.aspx.cs" Inherits="frmPersonnelVerified" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
        <p>
            Information to Submit:<br />
            <br />
            <strong>First Name:</strong>
            <asp:Literal ID="litFirstName" runat="server"></asp:Literal>
        </p>
        <p>
            <strong>Last Name:</strong>
            <asp:Literal ID="litLastName" runat="server"></asp:Literal>
        </p>
        <p>
            <strong>Pay Rate:</strong>
            <asp:Literal ID="litPayRate" runat="server"></asp:Literal>
        </p>
        <p>
            <strong>Start Date:</strong>
            <asp:Literal ID="litStartDate" runat="server"></asp:Literal>
        </p>
        <p>
            <strong>End Date:</strong>
            <asp:Literal ID="litEndDate" runat="server"></asp:Literal>
        </p>
        <p>
            <asp:Label ID="lblSaveMsg" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnViewPersonnel" runat="server" 
                PostBackUrl="~/frmViewPersonnel.aspx" Text="View Personnel" />
        </p>
    </div>
</asp:Content>

