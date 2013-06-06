using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SecurityLevel"] == "A")
        {
            btnSubmit.Visible = true;

        }
        else
        {
            btnSubmit.Visible = false;
        }

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
        }

        clsDataLayer.SaveUserActivity(Server.MapPath("PayrollSystem_DB.mdb"), "frmPersonnel");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        txtFirstName.BackColor = System.Drawing.Color.White;
        txtLastName.BackColor = System.Drawing.Color.White;
        txtPayRate.BackColor = System.Drawing.Color.White;
        txtStartDate.BackColor = System.Drawing.Color.White;
        txtEndDate.BackColor = System.Drawing.Color.White;

        if (ValidateInput())
        {
            Session["txtFirstName"] = txtFirstName.Text;
            Session["txtLastName"] = txtLastName.Text;
            Session["txtPayRate"] = txtPayRate.Text;
            Session["txtStartDate"] = txtStartDate.Text;
            Session["txtEndDate"] = txtEndDate.Text;

            Response.Redirect("frmPersonnelVerified.aspx");
        }
    }

    private bool ValidateInput()
    {
        bool result = true;

        string errorMsg = "Validation Failed: ";
        string fName = txtFirstName.Text;
        fName = fName.Trim();
        string lName = txtLastName.Text;
        lName = lName.Trim();
        string payRate = txtPayRate.Text;
        payRate = payRate.Trim();
        string startDate = txtStartDate.Text;
        startDate = startDate.Trim();
        string endDate = txtEndDate.Text;
        endDate = endDate.Trim();


        if (fName == "")
        {
            txtFirstName.BackColor = System.Drawing.Color.Yellow;
            errorMsg += "Please enter a First Name. ";
            result = false;
        }

        if (lName == "")
        {
            txtLastName.BackColor = System.Drawing.Color.Yellow;
            errorMsg += "Please enter a Last Name. ";
            result = false;
        }

        if (payRate == "")
        {
            txtPayRate.BackColor = System.Drawing.Color.Yellow;
            errorMsg += "Please enter a Pay Rate. ";
            result = false;
        }

        if (startDate == "")
        {
            txtStartDate.BackColor = System.Drawing.Color.Yellow;
            errorMsg += "Please enter a Start Date. ";
            result = false;
        }

        if (endDate == "")
        {
            txtEndDate.BackColor = System.Drawing.Color.Yellow;
            errorMsg += "Please enter an End Date. ";
            result = false;
        }

        //Old Validation Code:
        //if (startDate != "" && endDate != "")
        //{
        //    DateTime sDate = DateTime.Parse(startDate);
        //    DateTime eDate = DateTime.Parse(endDate);
        //    if (DateTime.Compare(sDate, eDate) > 0)
        //    {
        //        txtStartDate.BackColor = System.Drawing.Color.Yellow;
        //        txtEndDate.BackColor = System.Drawing.Color.Yellow;
        //        errorMsg += "End date must be after start date. ";
        //        result = false;
        //    }
        //}

        if (startDate != "" && endDate != "")
        {
            DateTime sDate, eDate;
            if (DateTime.TryParse(startDate, out sDate) && DateTime.TryParse(endDate, out eDate))
            {
                if (DateTime.Compare(sDate, eDate) > 0)
                {
                    txtStartDate.BackColor = System.Drawing.Color.Yellow;
                    txtEndDate.BackColor = System.Drawing.Color.Yellow;
                    errorMsg += "End date must be after start date. ";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    result = false;
                }
            }
        }

        lblError.Text = errorMsg;
        return result;
    }
}