<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmLogin.aspx.cs" Inherits="frmLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Paul Ortega - Course Project</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    
        <asp:Image ID="Image1" runat="server" 
            ImageUrl="~/Images/CoolBiz_Productions_logo.JPG" />
        <br />
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Default.aspx" 
            onauthenticate="Login1_Authenticate" 
            TitleText="Please enter your User Name and Password in order to log into the system">
        </asp:Login>
    
    </div>
    </form>
</body>
</html>
