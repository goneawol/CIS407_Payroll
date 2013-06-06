using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SecurityLevel"] == null)
        {
            Response.Redirect("frmLogin.aspx");
        }

        if (Session["SecurityLevel"] == "U")
        {
            //imgbtnCalculator.Visible = false;
            //linkbtnCalculator.Visible = false;
            imgbtnNewEmployee.Visible = false;
            linkbtnNewEmployee.Visible = false;
            imgbtnViewUserActivity.Visible = false;
            linkbtnViewUserActivity.Visible = false;
            imgbtnEditEmployees.Visible = false;
            linkbtnEditEmployees.Visible = false;
            imgbtnManageUsers.Visible = false;
            linkbtnManageUsers.Visible = false;

            //LinkButton lb = (LinkButton)Master.FindControl("lbAddPersonnel");
            //lb.Visible = false;
            //(LinkButton)Master.FindControl("lbAddPersonnel").Visible = false;
            Master.FindControl("lbAddPersonnel").Visible = false;
            Master.FindControl("lbUserActivity").Visible = false;
            Master.FindControl("lbEditEmployees").Visible = false;
            Master.FindControl("lbManageUsers").Visible = false;
        }

        // Add your comments here
        clsDataLayer.SaveUserActivity(Server.MapPath("PayrollSystem_DB.mdb"), "frmDefault");
    }
}