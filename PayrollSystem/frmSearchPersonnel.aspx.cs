using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmSearchPersonnel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SecurityLevel"] == "U")
        {
            //LinkButton lb = (LinkButton)Master.FindControl("lbAddPersonnel");
            //lb.Visible = false;
            //(LinkButton)Master.FindControl("lbAddPersonnel").Visible = false;
            Master.FindControl("lbAddPersonnel").Visible = false;
            Master.FindControl("lbUserActivity").Visible = false;
            Master.FindControl("lbEditEmployees").Visible = false;
            Master.FindControl("lbManageUsers").Visible = false;
        }
        

        clsDataLayer.SaveUserActivity(Server.MapPath("PayrollSystem_DB.mdb"), "frmSearchPersonnel");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["txtSearchName"] = txtSearchName.Text;
        Response.Redirect("frmViewPersonnel.aspx");
    }
}