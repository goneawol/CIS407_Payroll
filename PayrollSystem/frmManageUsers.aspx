<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmManageUsers.aspx.cs" Inherits="frmManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div align="center">
    
        <asp:Label ID="Label2" runat="server" Text="Manage Users"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="User Name: "></asp:Label>
        &nbsp;<asp:TextBox ID="txtUserName" runat="server" Width="130px"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Password: "></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="130px"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Security Level: "></asp:Label>
        <asp:DropDownList ID="ddSecurityLevel" runat="server">
            <asp:ListItem Value="U">User</asp:ListItem>
            <asp:ListItem Value="A">Admin</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Add User" />
        <br />
        <asp:Label ID="lblAddMsg" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Current Users:"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="grdUsers" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="UserID" DataSourceID="AccessDataSource1" CellPadding="4" 
            ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="UserID" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" 
                    SortExpression="UserName" />
                <asp:BoundField DataField="UserPassword" HeaderText="UserPassword" 
                    SortExpression="UserPassword" />
                <asp:TemplateField HeaderText="SecurityLevel" SortExpression="SecurityLevel">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                            DataSourceID="AccessDataSource2" DataTextField="SecurityLevel" 
                            DataValueField="SecurityLevel" SelectedValue='<%# Bind("SecurityLevel") %>'>
                        </asp:DropDownList>
                        <asp:AccessDataSource ID="AccessDataSource2" runat="server" 
                            DataFile="~/PayrollSystem_DB.mdb" 
                            SelectCommand="SELECT DISTINCT [SecurityLevel] FROM [tblUserLogin]">
                        </asp:AccessDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("SecurityLevel") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
            DataFile="~/PayrollSystem_DB.mdb" 
            DeleteCommand="DELETE FROM [tblUserLogin] WHERE [UserID] = ?" 
            InsertCommand="INSERT INTO [tblUserLogin] ([UserID], [UserName], [UserPassword], [SecurityLevel]) VALUES (?, ?, ?, ?)" 
            SelectCommand="SELECT * FROM [tblUserLogin]" 
            UpdateCommand="UPDATE [tblUserLogin] SET [UserName] = ?, [UserPassword] = ?, [SecurityLevel] = ? WHERE [UserID] = ?">
            <DeleteParameters>
                <asp:Parameter Name="UserID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="UserID" Type="Int32" />
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="UserPassword" Type="String" />
                <asp:Parameter Name="SecurityLevel" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="UserPassword" Type="String" />
                <asp:Parameter Name="SecurityLevel" Type="String" />
                <asp:Parameter Name="UserID" Type="Int32" />
            </UpdateParameters>
        </asp:AccessDataSource>
    </div>
</asp:Content>

