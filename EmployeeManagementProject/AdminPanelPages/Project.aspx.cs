using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementProject.BAL_Class;
namespace EmployeeManagementProject.AdminPanelPages
{
    public partial class Project : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        General ObjG=new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SatusBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(Session["UserId"]);
            db = new EmployeeDataBaseEntities();
            int Result = 0;
            var SetProject = new ProjectTable
            {
                ProjectName = txtProjectName.Text,
                StatusId = Convert.ToInt32(ddlStatus.SelectedValue),
                StartDate = Convert.ToDateTime(txtStartDate.Text),
                EndDate = Convert.ToDateTime(txtEndDate.Text),
                Details = txtDescription.Text,
                IsActive = true,
                CreateBy = UserID,
                CreateOn = DateTime.Now,
                UpdateBy = UserID,
                UpdateOn = DateTime.Now,
            };
            db.ProjectTables.Add(SetProject);
            Result = db.SaveChanges();
            if(Result > 0)
            {
                string message = "Project Details has been submited Succesfully";
                string url = "Project.aspx";

                ObjG.ShowMessageAndRedirect(this, message, url);
            }

        }

       

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanelPages/Project.aspx");
        }

       //Status Bind
       public void SatusBind()
        {
            db=new EmployeeDataBaseEntities();
            var Bind=(from S in db.ProjectStatusTables
                      where S.IsActive==true select S).ToList();
            if (Bind != null)
            {
                ddlStatus.DataSource = Bind;
                ddlStatus.DataTextField = "StatusName";
                ddlStatus.DataValueField = "StatusId";
                ddlStatus.DataBind();
                ddlStatus.Items.Insert(0, new ListItem("--Select Status--", "0"));
            }
        }
    }
}