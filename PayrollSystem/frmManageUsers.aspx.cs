using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmManageUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SecurityLevel"] != null)
        {
            if (Session["SecurityLevel"].ToString() == "U")
            {
                Response.Redirect("default.aspx");
            }
        }
        else
        {
            Response.Redirect("frmLogin.aspx");
        }

        clsDataLayer.SaveUserActivity(Server.MapPath("PayrollSystem_DB.mdb"), "frmManageUsers");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["txtUserName"] = txtUserName.Text;  // txtFirstName.Text;
        Session["txtUserPassword"] = txtPassword.Text; //txtLastName.Text;
        Session["txtSecurityLevel"] = ddSecurityLevel.SelectedValue; // txtPayRate.Text;


        //Literals used for each display rather than a text area.
        //User input from the text boxes will be transferred to each literal.
        //litFirstName.Text = (string)Session["txtFirstName"];
        //Can use above code or alternate: litFirstName.Text = Session["txtFirstName"].ToString();
        //litLastName.Text = (string)Session["txtLastName"];
        //litPayRate.Text = (string)Session["txtPayRate"];
        //litStartDate.Text = (string)Session["txtStartDate"];
        //litEndDate.Text = (string)Session["txtEndDate"];

        if (clsDataLayer.SaveUser(Server.MapPath("PayrollSystem_DB.mdb"),
            Session["txtUserName"].ToString(), Session["txtUserPassword"].ToString(), Session["txtSecurityLevel"].ToString()))
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            lblAddMsg.Text = "The user was successfully added!";
            grdUsers.DataBind();
        }

        else
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            lblAddMsg.Text = "The user was NOT added.";
        }

        // Session["txtFirstName"].ToString(),
        // Session["txtLastName"].ToString(),
        // Session["txtPayRate"].ToString(),
        // Session["txtStartDate"].ToString(),
        // Session["txtEndDate"].ToString()))
        //{
        //    lblSaveMsg.Text = "The information was successfully saved!";

        //}
        //else
        //{
        //    lblSaveMsg.Text = "The information was NOT saved.";
        //}
    }
}