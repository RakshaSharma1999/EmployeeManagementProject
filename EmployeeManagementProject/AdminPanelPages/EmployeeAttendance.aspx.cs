using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementProject.BAL_Class;

namespace EmployeeManagementProject.AdminPanelPages
{
    public partial class EmployeeAttendance : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        General ObjG=new General();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            db=new EmployeeDataBaseEntities();
            int EmpId = Convert.ToInt32(txtEmployeeId.Text);

            var EmpCheck=(from P in db.PersonalDetails where P.EmployeeId== EmpId select P).FirstOrDefault();

            if (EmpCheck != null) { 

            TimeSpan.TryParse(txtCheckInTime.Text, out TimeSpan parsedInTime);
            TimeSpan.TryParse(txtCheckOutTime.Text, out TimeSpan parsedOutTime);

            var SetAttendance = new Attendance
                {
                    EmployeeId = Convert.ToInt32(txtEmployeeId.Text),
                    Attendancedate = Convert.ToDateTime(txtDate.Text),
                    CheckInTime = parsedInTime,
                    CheckOutTime = parsedOutTime,
                    IsActive = true
            };
         db.Attendances.Add(SetAttendance);
               db.SaveChanges();
                string message = "Employee is Present Today";
                string url = "EmployeeAttendance.aspx";

                ObjG.ShowMessageAndRedirect(this, message, url);
            }
            else
            {
                string message = "Employee is not Existed";
                string url = "EmployeeAttendance.aspx";

                ObjG.ShowMessageAndRedirect(this, message, url);
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}