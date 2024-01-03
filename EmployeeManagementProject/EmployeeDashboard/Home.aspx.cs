using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementProject.EmployeeDashboard
{
    public partial class EmployeeHomeDashboard : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        protected void Page_Load(object sender, EventArgs e)
        {
         if (!IsPostBack)
            {
                PendingTask();
            }
        }

        // Pending Task Information
        public void PendingTask()
        {
            db = new EmployeeDataBaseEntities();
            var Total = (from T in db.TaskTables
                        where T.TaskId == 3 select T).Count();
            lblPendingTask.Text = Total.ToString();
            
        }
    }
}