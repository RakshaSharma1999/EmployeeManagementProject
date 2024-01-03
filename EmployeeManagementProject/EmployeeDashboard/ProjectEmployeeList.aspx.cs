using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementProject.EmployeeDashboard
{
    public partial class ProjectEmployeeList : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmployeeTaskBind();
                SatusBind();
            }
        }
        private long TaskID
        {
            get
            {
                if (ViewState["TaskId"] != null)
                {
                    return (long)ViewState["TaskId"];
                }
                return 0;
            }
            set
            {
                ViewState["TaskId"] = value;
            }
        }
        // Employee Task Bind
        public void EmployeeTaskBind()
        {
            int UserID = Convert.ToInt32(Session["UserId"]);
            db = new EmployeeDataBaseEntities();
            var Bind = (from T in db.TaskTables
                        join PT in db.ProjectTables on T.ProjectId equals PT.ProjectId
                        join PD in db.PersonalDetails on T.EmployeeId equals PD.EmployeeId
                        join PS in db.ProjectStatusTables on T.StatusId equals PS.StatusId
                        where T.IsActive == true && T.EmployeeId == UserID
                        orderby T.TaskId descending
                        select new
                        {
                            T.TaskId,
                            T.EmployeeId,
                            T.TaskName,
                            PT.ProjectName,
                            PD.FirstName,
                            PD.LastName,
                            PS.StatusName,
                            T.StartDate,
                            T.EndDate
                        }
                      ).ToList();
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

        protected void GridViewProject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            db = new EmployeeDataBaseEntities();
            int TaskId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Action")
            {
                TaskID = TaskId;
                ListPanel.Visible = false;
                ViewPanel.Visible = true;
                var View = (from T in db.TaskTables
                            join PT in db.ProjectTables on T.ProjectId equals PT.ProjectId
                            join PD in db.PersonalDetails on T.EmployeeId equals PD.EmployeeId
                            join PS in db.ProjectStatusTables on T.StatusId equals PS.StatusId
                            where T.TaskId == TaskID
                            select new
                            {
                                T.StatusId,
                                T.TaskId,
                                T.TaskName,
                                T.EmployeeId,
                                PT.ProjectName,
                                PD.FirstName,
                                PD.LastName,
                                PS.StatusName,
                                T.StartDate,
                                T.EndDate,
                                T.Details
                                
                            }
                      ).FirstOrDefault();
                lblEmployeeId.Text = View.EmployeeId.ToString();
                lblEmployeeName.Text = View.FirstName + " " + View.LastName;
                lblProjectName.Text = View.ProjectName;
                lblTaskName.Text = View.TaskName;
                lblStartDate.Text = Convert.ToDateTime(View.StartDate).ToString("dd-MM-yyyy");
                lblEndDate.Text = Convert.ToDateTime(View.EndDate).ToString("dd-MM-yyyy");
                lblDescription.Text = View.Details;
                ddlStatus.SelectedValue=View.StatusId.ToString();

            }
        }

        protected void GridViewProject_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewProject.PageIndex = e.NewPageIndex;
            EmployeeTaskBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                Response.Redirect("~/EmployeeDashboard/ProjectEmployeeList.aspx");
            }
            else
            {
                EmployeeTaskBind();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            db = new EmployeeDataBaseEntities();
            int UserID = Convert.ToInt32(Session["UserId"]);
            var Action=(from T in db.TaskTables
                        where T.TaskId == TaskID
                        select T).FirstOrDefault();
           Action.StatusId=Convert.ToInt32(ddlStatus.SelectedValue);
            db.SaveChanges();
            Response.Redirect("~/EmployeeDashboard/ProjectEmployeeList.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            ListPanel.Visible = true;
            ViewPanel.Visible = false;
        }

        //Search 
        public void Search()
        {
            db = new EmployeeDataBaseEntities();
            int UserID = Convert.ToInt32(Session["UserId"]);
            var Search = (from T in db.TaskTables
                          join PT in db.ProjectTables on T.ProjectId equals PT.ProjectId
                          join PD in db.PersonalDetails on T.EmployeeId equals PD.EmployeeId
                          join PS in db.ProjectStatusTables on T.StatusId equals PS.StatusId
                          where T.IsActive == true && T.EmployeeId==UserID &&
                          (PT.ProjectName.Contains(txtSearch.Text) || PS.StatusName.Contains(txtSearch.Text))
                          
                          select new
                          {
                              T.TaskId,
                              T.EmployeeId,
                              PT.ProjectName,
                              PD.FirstName,
                              PD.LastName,
                              PS.StatusName,
                              T.StartDate,
                              T.EndDate
                          }
                        ).ToList();
            if (Search != null)
            {
                GridViewProject.DataSource = Search;
                GridViewProject.DataBind();
            }
            else
            {
                EmployeeTaskBind();
            }
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
    }

}