using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementProject.BAL_Class;
namespace EmployeeManagementProject.EmployeeDashboard
{
    public partial class Leave : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        General ObjG=new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LeaveBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            db=new EmployeeDataBaseEntities();
            int UserID = Convert.ToInt32(Session["UserId"]);
            int Result = 0;
            var Set = new LeaveTable
            {
                EmployeeId = UserID,
                LeaveStartDate = Convert.ToDateTime(txtStartDate.Text),
                LeaveEndDate = Convert.ToDateTime(txtEndDate.Text),
                StatusId = 3,
                Reason = txtReason.Text,
                Description = txtDescription.Text,
                ApplyOn = DateTime.Now,
                IsActive = true,
                CreateBy = UserID,
                CreateOn=DateTime.Now
            };
            db.LeaveTables.Add(Set);
         
            Result =db.SaveChanges();
            if (Result > 0)
            {
                string message = "Your Leave Request has been Submitted ";
                string url = "Leave.aspx";

                ObjG.ShowMessageAndRedirect(this, message, url);
            }
        }

        protected void GridViewLeaveRequest_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            db=new EmployeeDataBaseEntities();
            int LeaveId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "ViewLeaveRequest")
            {
                ListPanel.Visible = false;
                ViewPanel.Visible = true;
                var View= (from L in db.LeaveTables
                           join S in db.LeaveStatusMasters on L.StatusId equals S.LeaveStatusId
                           where L.LeaveRequestId == LeaveId
                           select new
                           {
                               L.LeaveStartDate,
                               L.LeaveEndDate,
                               S.StatusType,
                               L.Reason,
                               L.ApplyOn,
                               L.LeaveRequestId,
                               L.Description
                           }

                      ).FirstOrDefault();
                lblLeaveStartDate.Text = Convert.ToDateTime(View.LeaveStartDate).ToString("dd-MM-yyyy");
                lblLeaveEndDate.Text = Convert.ToDateTime(View.LeaveEndDate).ToString("dd-MM-yyyy");
                lblStatus.Text=View.StatusType.ToString();
                lblReason.Text=View.Reason.ToString();
                lblDescription.Text=View.Description.ToString();
                lblApplyOn.Text=View.ApplyOn.ToString();
            }
            if(e.CommandName == "DeleteLeaveRequest")
            {
             var Delete=(from  L in db.LeaveTables where L.LeaveRequestId==LeaveId select L).FirstOrDefault();
                Delete.IsActive = false;
                db.SaveChanges();
                LeaveBind();
            }
        }

        protected void GridViewLeaveRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewLeaveRequest.PageIndex = e.NewPageIndex;
            LeaveBind();
        }

        // Leave Request List Bind
        public void LeaveBind()
        {
            db=new EmployeeDataBaseEntities();
            int UserID = Convert.ToInt32(Session["UserId"]);
            var Bind = (from L in db.LeaveTables
                        join S in db.LeaveStatusMasters on L.StatusId equals S.LeaveStatusId
                        where L.IsActive == true && L.EmployeeId== UserID
                        orderby L.LeaveRequestId descending
                        select new
                        {
                            L.LeaveStartDate,
                            L.LeaveEndDate,
                            S.StatusType,
                            L.Reason,
                            L.ApplyOn,
                            L.LeaveRequestId
                        }

                      ).ToList();
            if (Bind != null)
            {
                GridViewLeaveRequest.DataSource = Bind;
                GridViewLeaveRequest.DataBind();
            }
            else
            {
                GridViewLeaveRequest.DataSource = null;
                GridViewLeaveRequest.DataBind();
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ListPanel.Visible = false;
            AddPanel.Visible = true;    
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
          ViewPanel.Visible = false;
            ListPanel.Visible = true;
        }
    }
}