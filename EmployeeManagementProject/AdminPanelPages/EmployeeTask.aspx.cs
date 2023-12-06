using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementProject.BAL_Class;

namespace EmployeeManagementProject.AdminPanelPages
{
    public partial class EmployeeTask : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        General ObjG=new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmployeeTaskBind();
                SatusBind();
                ProjectBind();
               
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           db=new EmployeeDataBaseEntities();
            int UserID = Convert.ToInt32(Session["UserId"]);
            int Result = 0;

            if (TaskID == 0) { 
            var SetTask = new TaskTable
            {
                EmployeeId = Convert.ToInt32(txtEmployeeId.Text),
                ProjectId = Convert.ToInt32(ddlProjectName.SelectedValue),
                StatusId= Convert.ToInt32(ddlStatus.SelectedValue),
                StartDate=Convert.ToDateTime(txtStartDate.Text),
                EndDate=Convert.ToDateTime(txtEndDate.Text),
                Details=txtDescription.Text,
                IsActive=true,
                CreateBy= UserID,
                CreateOn=DateTime.Now,
                UpdateBy= UserID,
                UpdateOn= DateTime.Now,
            };
            db.TaskTables.Add(SetTask);
            Result=db.SaveChanges();
            if (Result > 0)
            {
                string message = "Task Details has been submited Succesfully";
                string url = "EmployeeTask.aspx";

                ObjG.ShowMessageAndRedirect(this, message, url);
            }
            }
            else
            {
                var Edit=(from T in db.TaskTables
                          where T.TaskId==TaskID select T).FirstOrDefault();
                Edit.EmployeeId=Convert.ToInt32(txtEmployeeId.Text);
                Edit.StartDate=Convert.ToDateTime(txtStartDate.Text);
                Edit.EndDate=Convert.ToDateTime(txtEndDate.Text);
                Edit.Details=txtDescription.Text;
                Edit.ProjectId=Convert.ToInt32(ddlProjectName.SelectedValue);
                Edit.StatusId= Convert.ToInt32(ddlStatus.SelectedValue);
                Edit.UpdateBy= UserID;
                Edit.UpdateOn= DateTime.Now;
               Result=db.SaveChanges();
                if (Result > 0)
                {
                    string message = "Task Details has been Updated ";
                    string url = "EmployeeTask.aspx";

                    ObjG.ShowMessageAndRedirect(this, message, url);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanelPages/EmployeeTask.aspx");
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
       // Project Bind
       public void ProjectBind()
        {
            db= new EmployeeDataBaseEntities();
            var Bind=(from P in db.ProjectTables
                      where P.IsActive == true 
                      select P).ToList(); 
            if(Bind != null)
            {
                ddlProjectName.DataSource = Bind;
                ddlProjectName.DataTextField ="ProjectName";
                ddlProjectName.DataValueField="ProjectId";
                ddlProjectName.DataBind();
                ddlProjectName.Items.Insert(0, new ListItem("--Select Project--", "0"));
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                txtSearch.Text = "";
                EmployeeTaskBind();
            }
            else
            {
                EmployeeTaskBind();
            }
        }

        protected void GridViewProject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            db = new EmployeeDataBaseEntities();
            int TaskId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "DeleteEmployeeTask")
            {
                var Delete = (from T in db.TaskTables
                              where T.TaskId == TaskId
                              select T).FirstOrDefault();
                Delete.IsActive = false;
                db.SaveChanges();
                EmployeeTaskBind();
            }
            if (e.CommandName== "ViewEmployeeTask")
            {
                ListPanel.Visible = false;
                ViewPanel.Visible = true;
                var View = (from T in db.TaskTables
                            join PT in db.ProjectTables on T.ProjectId equals PT.ProjectId
                            join PD in db.PersonalDetails on T.EmployeeId equals PD.EmployeeId
                            join PS in db.ProjectStatusTables on T.StatusId equals PS.StatusId
                            where T.TaskId== TaskId
                            select new
                            {
                                T.TaskId,
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
                lblEmployeeId.Text=View.EmployeeId.ToString();
                lblEmployeeName.Text=View.FirstName + " " + View.LastName;
                lblProjectName.Text=View.ProjectName;
                lblStartDate.Text=Convert.ToDateTime(View.StartDate).ToString("yyyy-MM-dd");
                lblEndDate.Text=Convert.ToDateTime(View.EndDate).ToString("yyyy-MM-dd");
                lblStatus.Text=View.StatusName;
                lblDescription.Text = View.Details;
               
            }
            if(e.CommandName=="EditEmployeeTask")
            {
                AddPanel.Visible = true;
                ListPanel.Visible = false;
                TaskID = TaskId;
                var Edit=(from T in db.TaskTables
                          where T.TaskId== TaskID select T).FirstOrDefault();
                txtEmployeeId.Text= Edit.EmployeeId.ToString();
                txtStartDate.Text= Convert.ToDateTime(Edit.StartDate).ToString("yyyy-MM-dd");
                txtEndDate.Text = Convert.ToDateTime(Edit.EndDate).ToString("yyyy-MM-dd");
                txtDescription.Text = Edit.Details;
                ddlStatus.SelectedValue=Edit.StatusId.ToString();
                ddlProjectName.SelectedValue = Edit.ProjectId.ToString();
            }
          
        }

        protected void GridViewProject_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewProject.PageIndex = e.NewPageIndex;
            EmployeeTaskBind();
        }

       // Employee Task Bind
       public void EmployeeTaskBind()
        {
            db = new EmployeeDataBaseEntities();
            var Bind=(from T in db.TaskTables 
                      join  PT in db.ProjectTables on T.ProjectId equals PT.ProjectId
                      join PD in db.PersonalDetails on T.EmployeeId equals PD.EmployeeId
                      join PS in db.ProjectStatusTables on T.StatusId equals PS.StatusId
                      where T.IsActive == true
                      select new {
                          T.TaskId,
                      T.EmployeeId,
                      PT.ProjectName,
                      PD.FirstName, PD.LastName,
                      PS.StatusName,T.StartDate, T.EndDate
                      }
                      ).ToList();
            if(Bind != null)
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

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ListPanel.Visible = false;
            AddPanel.Visible = true;
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            ListPanel.Visible = true;
            ViewPanel.Visible = false;
        }

        //Search 
        public void Search()
        {
            db=new EmployeeDataBaseEntities();
            var Search=(from T in db.TaskTables
                        join PT in db.ProjectTables on T.ProjectId equals PT.ProjectId
                        join PD in db.PersonalDetails on T.EmployeeId equals PD.EmployeeId
                        join PS in db.ProjectStatusTables on T.StatusId equals PS.StatusId
                        where T.IsActive==true && 
                        (PT.ProjectName.Contains(txtSearch.Text) || PS.StatusName.Contains(txtSearch.Text) ||
                        (PD.FirstName + " " + PD.LastName).Contains(txtSearch.Text))
                        select new {
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
            if(Search != null)
            {
                GridViewProject.DataSource = Search;
                GridViewProject.DataBind();
            }
            else
            {
                EmployeeTaskBind();
            }
        }

    }
}