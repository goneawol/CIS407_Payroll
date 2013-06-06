using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmPersonnelVerified : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Literals used for each display rather than a text area.
        //User input from the text boxes will be transferred to each literal.
        litFirstName.Text = (string)Session["txtFirstName"];
        //Can use above code or alternate: litFirstName.Text = Session["txtFirstName"].ToString();
        litLastName.Text = (string)Session["txtLastName"];
        litPayRate.Text = (string)Session["txtPayRate"];
        litStartDate.Text = (string)Session["txtStartDate"];
        litEndDate.Text = (string)Session["txtEndDate"];

        //Display message either confirming data was saved or message informing
        //the data was NOT saved.
        if (clsDataLayer.SavePersonnel(Server.MapPath("PayrollSystem_DB.mdb"),
         Session["txtFirstName"].ToString(),
         Session["txtLastName"].ToString(),
         Session["txtPayRate"].ToString(),
         Session["txtStartDate"].ToString(),
         Session["txtEndDate"].ToString()))
        {
            lblSaveMsg.Text = "The information was successfully saved!";

        }
        else
        {
            lblSaveMsg.Text = "The information was NOT saved.";
        }

        clsDataLayer.SaveUserActivity(Server.MapPath("PayrollSystem_DB.mdb"), "frmPersonnelVerified");
    }
}