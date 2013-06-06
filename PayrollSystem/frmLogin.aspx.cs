using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class frmLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsDataLayer.SaveUserActivity(Server.MapPath("PayrollSystem_DB.mdb"), "frmLogin");
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        dsUser dsUserLogin;
        string SecurityLevel;

        dsUserLogin = clsDataLayer.VerifyUser(Server.MapPath("PayrollSystem_DB.mdb"),
                         Login1.UserName, Login1.Password);

        if (dsUserLogin.tblUserLogin.Count < 1)
        {
            e.Authenticated = false;

            if (clsBusinessLayer.SendEmail("prepress@vestatr.com",
            "paulortega@gmail.com", "", "", "Login Incorrect",
            "The login failed for UserName: " + Login1.UserName +
            " Password: " + Login1.Password))
            {
                Login1.FailureText = Login1.FailureText +
                " Your incorrect login information was sent to paulortega@gmail.com";
            }
            return;
        }

        SecurityLevel = dsUserLogin.tblUserLogin[0].SecurityLevel.ToString();

        switch (SecurityLevel)
        {

            case "A":
                // Add your comments here
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                Session["SecurityLevel"] = "A";
                break;
            case "U":
                // Add your comments here
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                Session["SecurityLevel"] = "U";
                break;
            default:
                e.Authenticated = false;
                break;
        }
    }
}