using EmployeeManagementProject.EmployeeDashboard;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementProject.AdminPanelPages
{
    public partial class LeaveView : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        protected void Page_Load(object sender, EventArgs e)
        {
          if (!IsPostBack)
            {
                LeaveBind();
                StatusBind();
            }
        }
        private long LeaveID
        {
            get
            {
                if (ViewState["LeaveRequestId"] != null)
                {
                    return (long)ViewState["LeaveRequestId"];
                }
                return 0;
            }
            set
            {
                ViewState["LeaveRequestId"] = value;
            }
        }
        // Leave Request List Bind
        public void LeaveBind()
        {
            db = new EmployeeDataBaseEntities();
            var Bind = (from L in db.LeaveTables
                        join S in db.LeaveStatusMasters on L.StatusId equals S.LeaveStatusId
                        join P in db.PersonalDetails on L.EmployeeId equals P.EmployeeId
                        where L.IsActive == true
                        orderby L.LeaveRequestId descending
                        select new
                        {
                            L.EmployeeId,
                            P.FirstName, P.LastName,
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

        protected void GridViewLeaveRequest_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            db = new EmployeeDataBaseEntities();
            int LeaveId = Convert.ToInt32(e.CommandArgument);
            if(e.CommandName== "Action")
            {
                LeaveID = LeaveId;
                ViewPanel.Visible = true;
                ListPanel.Visible = false;
              var Action=  (from L in db.LeaveTables
                 join S in db.LeaveStatusMasters on L.StatusId equals S.LeaveStatusId
                 join P in db.PersonalDetails on L.EmployeeId equals P.EmployeeId
                 where L.LeaveRequestId== LeaveID
                            select new
                 {
                     L.EmployeeId,
                     P.FirstName,
                     P.LastName,
                     L.LeaveStartDate,
                     L.LeaveEndDate,
                     S.StatusType,
                     L.StatusId,
                     L.Reason,
                     L.ApplyOn,
                     L.LeaveRequestId,
                     L.Description
                 }

                      ).FirstOrDefault();
                lblEmployeeId.Text= Action.EmployeeId.ToString();
                lblEmployeeName.Text=Action.FirstName +" "+ Action.LastName;
                lblLeaveStartDate.Text=Convert.ToDateTime(Action.LeaveStartDate).ToString("dd-MM-yyyy");
                lblLeaveEndDate.Text = Convert.ToDateTime(Action.LeaveEndDate).ToString("dd-MM-yyyy");
                lblReason.Text = Action.Reason;
                lblDescription.Text = Action.Description;
                lblApplyOn.Text = Action.ApplyOn.ToString();
                ddlStatus.SelectedValue=Action.StatusId.ToString();

            }
        }

        protected void GridViewLeaveRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewLeaveRequest.PageIndex = e.NewPageIndex;
            LeaveBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            db=new EmployeeDataBaseEntities();
            var Action=(from L in db.LeaveTables
                        where L.LeaveRequestId==LeaveID select L).FirstOrDefault();
            Action.StatusId = Convert.ToInt32(ddlStatus.SelectedValue);
            db.SaveChanges();
            Response.Redirect("~/AdminPanelPages/LeaveView.aspx");
        }
        //Bind Status
        public void StatusBind()
        {
            db=new EmployeeDataBaseEntities();
            var Bind = (from S in db.LeaveStatusMasters
                        where S.IsActive == true select S).ToList();    
            if (Bind != null)
            {
                ddlStatus.DataSource = Bind;
                ddlStatus.DataTextField = "StatusType";
                ddlStatus.DataValueField = "LeaveStatusId";
                ddlStatus.DataBind();

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            ListPanel.Visible = true;
            ViewPanel.Visible = false;  
        }

        protected void GridViewLeaveRequest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }
    }
}