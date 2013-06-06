using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmViewPersonnel : System.Web.UI.Page
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
        
        string searchVal = "";

        if (Session["txtSearchName"] != null)
        {
            searchVal = Session["txtSearchName"].ToString();
            Session["txtSearchName"] = "";
        }

        if (!Page.IsPostBack)
        {
            if (searchVal == null)
            {
                //Declare the DataSet
                dsPersonnel myDataSet = new dsPersonnel();

                //Fill the dataset with what is returned from the function
                myDataSet = clsDataLayer.GetPersonnel(Server.MapPath("PayrollSystem_DB.mdb"));

                //Set the dataset with what is returned from the function
                grdViewPersonnel.DataSource = myDataSet.Tables["tblPersonnel"];

                //Bind the DataGrid
                grdViewPersonnel.DataBind();
            }
            else
            {
                //Declare the DataSet
                dsPersonnel myDataSet = new dsPersonnel();

                //Fill the dataset with what is returned from the function
                myDataSet = clsDataLayer.GetPersonnel(Server.MapPath("PayrollSystem_DB.mdb"), searchVal);

                //Set the dataset with what is returned from the function
                grdViewPersonnel.DataSource = myDataSet.Tables["tblPersonnel"];

                //Bind the DataGrid
                grdViewPersonnel.DataBind();
            }
        }

        clsDataLayer.SaveUserActivity(Server.MapPath("PayrollSystem_DB.mdb"), "frmViewPersonnel");
    }
}