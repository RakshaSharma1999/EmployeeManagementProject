using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementProject.AdminPanelPages
{
    public partial class Home : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                TotalEmployee();
                TotalPendingRequest();
                TotalPendingProject();
            }
        }

        // Count Total Employee
        public void TotalEmployee()
        {
            db=new EmployeeDataBaseEntities();
            var Total=(from P in db.PersonalDetails where P.IsActive==true
                       select P.EmployeeId).Count();
            lblTotalEmployee.Text = Total.ToString();
        }
        // Count Pending Request
        public void TotalPendingRequest()
        {
            db = new EmployeeDataBaseEntities();
            var Total=(from L in db.LeaveTables where L.IsActive==true
                       where L.StatusId==3
                       select L.LeaveRequestId).Count();
            lblPendingRequest.Text = Total.ToString();
        }

        // Count Pending Project 
        public void TotalPendingProject()
        {
            db = new EmployeeDataBaseEntities();
            var Total=(from P in db.ProjectTables where P.IsActive==true
                       && P.StatusId==3
                       select P.ProjectId).Count();
            lblPendingProject.Text = Total.ToString();
        }
    }
}