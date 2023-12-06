using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementProject
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Loginpages/Login.aspx");
            }
            else
            {
                lblFullName.Text = (Session["FirstName"]) + " " + (Session["LastName"]);

                ProfileImage.ImageUrl = "~/ProfileImages/" + Session["Profile"].ToString();
            }

        }

        public void RegisterTrigger(Control ct)
        {
            ScriptManagerId.RegisterPostBackControl(ct);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["UserId"] = null;
            Response.Redirect("/LoginPages/Login.aspx");
        }
    }
}