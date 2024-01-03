using EmployeeManagementProject.BAL_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementProject.AdminPanelPages
{
    public partial class ViewAttendance : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        General ObjG = new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AttendanceBind();
            }
        }
        private long AttendanceID
        {
            get
            {
                if (ViewState["AttendanceId"] != null)
                {
                    return (long)ViewState["AttendanceId"];
                }
                return 0;
            }
            set
            {
                ViewState["AttendanceId"] = value;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != null || txtSearchDate.Text != null)
            {
                txtSearch.Text = "";
                txtSearchDate.Text = "";
                AttendanceBind();
            }
            else
            {
                AttendanceBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            db = new EmployeeDataBaseEntities();
            int EmpId = Convert.ToInt32(txtEmployeeId.Text);
            var EmpCheck = (from P in db.PersonalDetails where P.EmployeeId == EmpId select P).FirstOrDefault();

            if (EmpCheck != null)
            {
                TimeSpan.TryParse(txtCheckInTime.Text, out TimeSpan parsedInTime);
                TimeSpan.TryParse(txtCheckOutTime.Text, out TimeSpan parsedOutTime);
                var Edit = (from A in db.Attendances
                            where A.AttendanceId == AttendanceID
                            select A).FirstOrDefault();
                Edit.EmployeeId = Convert.ToInt32(txtEmployeeId.Text);
                Edit.Attendancedate = Convert.ToDateTime(txtDate.Text);
                Edit.CheckInTime = parsedInTime;
                Edit.CheckOutTime = parsedOutTime;
                db.SaveChanges();

                string message = "Employee Attendance Updated";
                string url = "AttendanceView.aspx";

                ObjG.ShowMessageAndRedirect(this, message, url);

            }

            else
            {
                string message = "Employee is not Existed";
                string url = "AttendanceView.aspx";

                ObjG.ShowMessageAndRedirect(this, message, url);
            }

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            EditPanel.Visible = false;
            ListPanel.Visible = true;
        }

        protected void GridViewEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEmployee.PageIndex = e.NewPageIndex;
            AttendanceBind();
        }

        protected void GridViewEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            db = new EmployeeDataBaseEntities();
            int AID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "EditEmployeeAttendance")
            {
                EditPanel.Visible = true;
                ListPanel.Visible = false;
                AttendanceID = AID;
                var Edit = (from A in db.Attendances
                            where A.AttendanceId == AttendanceID
                            select A).FirstOrDefault();
                txtEmployeeId.Text = Edit.EmployeeId.ToString();
                txtDate.Text = Convert.ToDateTime(Edit.Attendancedate).ToString("yyyy-MM-dd");


                //TimeSpan.TryParse(Edit.CheckInTime, out TimeSpan parsedInTime);
                //TimeSpan.TryParse(txtCheckOutTime.Text, out TimeSpan parsedOutTime);


            }
            if (e.CommandName == "DeleteEmployeeAttendance")
            {
                var Delete = (from A in db.Attendances where A.AttendanceId == AID select A).FirstOrDefault();
                Delete.IsActive = false;
                db.SaveChanges();
                AttendanceBind();
            }

        }

        // Attendance Bind
        public void AttendanceBind()
        {
            db = new EmployeeDataBaseEntities();
            var Bind = (from A in db.Attendances
                        join
                      P in db.PersonalDetails on A.EmployeeId equals P.EmployeeId
                        where A.IsActive == true
                        orderby A.AttendanceId descending
                        select new
                        {
                            A.EmployeeId,
                            P.FirstName,
                            P.LastName,
                            A.Attendancedate,
                            A.CheckInTime,
                            A.CheckOutTime,
                            A.AttendanceId,

                        }).ToList();

            if (Bind != null)
            {
                GridViewEmployee.DataSource = Bind;
                GridViewEmployee.DataBind();

            }



        }
        // Search Employee  Attendance

        public void Search()
        {
            db = new EmployeeDataBaseEntities();

            if (txtSearchDate.Text != "" && txtSearch.Text != "")
            {
                int EmpId = Convert.ToInt32(txtSearch.Text);
                DateTime ADate = Convert.ToDateTime(txtSearchDate.Text);
                var Search = (from A in db.Attendances
                              join
                           P in db.PersonalDetails on A.EmployeeId equals P.EmployeeId
                              where A.IsActive == true && A.EmployeeId == EmpId && A.Attendancedate == ADate
                              select new
                              {
                                  A.EmployeeId,
                                  P.FirstName,
                                  P.LastName,
                                  A.Attendancedate,
                                  A.CheckInTime,
                                  A.CheckOutTime,
                                  A.AttendanceId,

                              }).ToList();

                if (Search != null)
                {
                    GridViewEmployee.DataSource = Search;
                    GridViewEmployee.DataBind();
                }
                else
                {
                    AttendanceBind();
                }
            }

            else if (txtSearch.Text != "")
            {

                int EmpId = Convert.ToInt32(txtSearch.Text);
                var Search = (from A in db.Attendances
                              join
                           P in db.PersonalDetails on A.EmployeeId equals P.EmployeeId
                              where A.IsActive == true && A.EmployeeId == EmpId
                              select new
                              {
                                  A.EmployeeId,
                                  P.FirstName,
                                  P.LastName,
                                  A.Attendancedate,
                                  A.CheckInTime,
                                  A.CheckOutTime,
                                  A.AttendanceId,

                              }).ToList();

                if (Search != null)
                {
                    GridViewEmployee.DataSource = Search;
                    GridViewEmployee.DataBind();
                }
                else
                {
                    AttendanceBind();
                }
            }
            else
            {
                if (txtSearchDate.Text != "")
                {
                    DateTime ADate = Convert.ToDateTime(txtSearchDate.Text);
                    var Search = (from A in db.Attendances
                                  join
                               P in db.PersonalDetails on A.EmployeeId equals P.EmployeeId
                                  where A.IsActive == true && A.Attendancedate == ADate
                                  select new
                                  {
                                      A.EmployeeId,
                                      P.FirstName,
                                      P.LastName,
                                      A.Attendancedate,
                                      A.CheckInTime,
                                      A.CheckOutTime,
                                      A.AttendanceId,

                                  }).ToList();

                    if (Search != null)
                    {
                        GridViewEmployee.DataSource = Search;
                        GridViewEmployee.DataBind();
                    }
                    else
                    {
                        AttendanceBind();
                    }
                }
                else
                {
                    AttendanceBind();
                }

            }
        }
    }
}