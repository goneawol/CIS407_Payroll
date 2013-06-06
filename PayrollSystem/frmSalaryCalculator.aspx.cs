using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmSalaryCalculator : System.Web.UI.Page
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

        clsDataLayer.SaveUserActivity(Server.MapPath("PayrollSystem_DB.mdb"), "frmSalaryCalculator");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        double annualHours = 0;
        double payRate = 0;
        double salary = 0;

        annualHours = Convert.ToDouble(txtAnnualHours.Text);
        payRate = Double.Parse(txtRate.Text);
        salary = annualHours * payRate;

        lblSalary.Text = "$" + salary.ToString();
    }
}