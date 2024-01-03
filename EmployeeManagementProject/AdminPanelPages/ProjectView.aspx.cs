using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementProject.BAL_Class;

namespace EmployeeManagementProject.AdminPanelPages
{
    public partial class ProjectView : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        General ObjG=new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProjectBind();
                SatusBind();
            }
        }
        private long ProjectID
        {
            get
            {
                if (ViewState["ProjectId"] != null)
                {
                    return (long)ViewState["ProjectId"];
                }
                return 0;
            }
            set
            {
                ViewState["ProjectId"] = value;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int UserId = Convert.ToInt32(Session["UserId"]);
            db =new EmployeeDataBaseEntities();
            var Edit = (from P in db.ProjectTables where P.ProjectId == ProjectID select P).FirstOrDefault();
            Edit.ProjectName=txtProjectName.Text;
            Edit.StartDate=Convert.ToDateTime(txtStartDate.Text);
            Edit.EndDate=Convert.ToDateTime(txtEndDate.Text);
            Edit.StatusId = Convert.ToInt32(ddlStatus.SelectedValue);
            Edit.Details=txtDescription.Text;
            Edit.UpdateBy = UserId;
            Edit.UpdateOn = DateTime.Now;
            db.SaveChanges();
            string message = "Data has been Updated Succesfully";
            string url = "ProjectView.aspx";

            ObjG.ShowMessageAndRedirect(this, message, url);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            EditPanel.Visible = false;
            ListPanel.Visible = true;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text!= "")
            {
                txtSearch.Text = "";
                ProjectBind();
            }
            else
            {
                ProjectBind();
            }
        }

        protected void GridViewProject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Projectid = Convert.ToInt32(e.CommandArgument);
            db= new EmployeeDataBaseEntities();
            if(e.CommandName=="ViewProjectDetails")
            {
                ViewPanel.Visible = true;
                ListPanel.Visible = false;
                var View=(from P in db.ProjectTables join
                          S in db.ProjectStatusTables on P.StatusId equals S.StatusId
                          where P.ProjectId==Projectid select new
                          {
                              P.ProjectName,P.Details,P.StartDate,P.EndDate,
                              S.StatusName
                          }).FirstOrDefault();
                lblProjectName.Text = View.ProjectName;
                lblStatus.Text = View.StatusName;
                lblStartDate.Text=(View.StartDate).ToString();
                lblEndDate.Text=(View.EndDate).ToString();
                lblDescription.Text=View.Details.ToString();
               
            }
            if (e.CommandName == "DeleteProjectDetails")
            {
                var Delete = (from P in db.ProjectTables where P.ProjectId == Projectid select P).FirstOrDefault();
                Delete.IsActive = false;
                db.SaveChanges();
                ProjectBind();
            }
            if (e.CommandName=="EditProjectDetails")
            {
                EditPanel.Visible = true;
                ListPanel.Visible= false;
                ProjectID = Projectid;
                var Edit = (from P in db.ProjectTables
                            where P.ProjectId == ProjectID select P).FirstOrDefault();
                    
                txtProjectName.Text = Edit.ProjectName;
                txtStartDate.Text = Convert.ToDateTime(Edit.StartDate).ToString("yyyy-MM-dd");
                txtEndDate.Text = Convert.ToDateTime(Edit.EndDate).ToString("yyyy-MM-dd");
                txtDescription.Text = Edit.Details;
                SatusBind();
                ddlStatus.SelectedValue=Edit.StatusId.ToString();
               
                    
                    }
           
        }

        protected void GridViewProject_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewProject.PageIndex = e.NewPageIndex;
            ProjectBind();
        }
        // Project List Bind
        public void ProjectBind()
        {
            db = new EmployeeDataBaseEntities();
            var Bind=(from P in db.ProjectTables join
                      S in db.ProjectStatusTables on P.StatusId equals S.StatusId
                      where P.IsActive == true
                      orderby P.ProjectId descending
                      select new
                      {
                          P.ProjectName,P.ProjectId,
                          P.StartDate, P.EndDate,
                          P.Details,S.StatusName
                      }).ToList();

            if (Bind != null)
            {
                GridViewProject.DataSource = Bind;
                GridViewProject.DataBind();
            }
            else
            {
                GridViewProject.DataSource = null;
                GridViewProject.DataBind();
            }
          
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            ListPanel.Visible = true;
            ViewPanel.Visible = false;
        }

        //Status Bind
        public void SatusBind()
        {
            db = new EmployeeDataBaseEntities();
            var Bind = (from S in db.ProjectStatusTables
                        where S.IsActive == true
                        select S).ToList();
            if (Bind != null)
            {
                
                ddlStatus.DataSource = Bind;
                ddlStatus.DataTextField = "StatusName";
                ddlStatus.DataValueField = "StatusId";
                ddlStatus.DataBind();
                ddlStatus.Items.Insert(0, new ListItem("--Select Status--", "0"));
            }
        }
        //Project Search
        public void Search()
        {
            db = new EmployeeDataBaseEntities();

            var Search=(from P in db.ProjectTables join
                        PS in db.ProjectStatusTables on P.StatusId equals PS.StatusId
                        where P.IsActive == true && (P.ProjectName.Contains(txtSearch.Text) ||
                        PS.StatusName.Contains(txtSearch.Text))
                        select new {
                            P.ProjectName,
                            P.ProjectId,
                            P.StartDate,
                            P.EndDate,
                            P.Details,
                            PS.StatusName
                        }

                        ).ToList();

            if( Search != null )
            {
                GridViewProject.DataSource = Search;
                GridViewProject.DataBind();
            }
            else
            {
                ProjectBind();
            }
        }
    }
}