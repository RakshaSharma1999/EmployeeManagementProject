using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementProject.EmployeeDashboard
{
    public partial class EmployeeSalaryView : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SalaryBind();
            }
        }

        protected void GridViewEmployeeSalary_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            db = new EmployeeDataBaseEntities();
            int Salaryid = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "ViewEmployeeSalary")
            {
                ViewPanel.Visible = true;
                ListPanel.Visible = false;
                var View = (from S in db.SalaryTables
                            join P in db.PersonalDetails on S.EmployeeId equals P.EmployeeId
                            where S.SalaryId == Salaryid
                            select new
                            {
                                S.EmployeeId,
                                P.FirstName,
                                P.LastName,
                                S.GrossSalary,
                                S.BasicSalary,
                                S.NetSalary,
                                S.SalaryId,
                                S.HouseRentAllowance,
                                S.DearnessAllowance,
                                S.MedicalAllowance,
                                S.ConveyanceAllowance,
                                S.OtherAllowance,
                                S.ProfessionalTax,
                                S.ProvidentFund,
                                S.ESI

                            }

                          ).FirstOrDefault();
                lblEmployeeId.Text = View.EmployeeId.ToString();
                lblFullName.Text = View.FirstName + " " + View.LastName;
                lblGrossSalary.Text = View.GrossSalary.ToString();
                lblBasicSalary.Text = View.BasicSalary.ToString();
                lblNetSalary.Text = View.NetSalary.ToString();
                lblHRA.Text = View.HouseRentAllowance.ToString();
                lblDA.Text = View.DearnessAllowance.ToString();
                lblMedicalAllowance.Text = View.MedicalAllowance.ToString();
                lblConveyanceAllowance.Text = View.ConveyanceAllowance.ToString();
                lblOtherAllowance.Text = View.OtherAllowance.ToString();
                lblProfessionalTax.Text = View.ProfessionalTax.ToString();
                lblProvidentFund.Text = View.ProvidentFund.ToString();
                lblESI.Text = View.ESI.ToString();
            }
        }

        protected void GridViewEmployeeSalary_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEmployeeSalary.PageIndex = e.NewPageIndex;
            SalaryBind();
            
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EmployeeDashboard/EmployeeSalaryView.aspx");
        }

        // Salary Bind
        public void SalaryBind()
        {
            db = new EmployeeDataBaseEntities();
            int UserID = Convert.ToInt32(Session["UserId"]);
            var Bind = (from S in db.SalaryTables
                        join P in db.PersonalDetails on S.EmployeeId equals P.EmployeeId
                        where S.IsActive == true && S.EmployeeId== UserID
                        select new
                        {
                            P.EmployeeId,
                            P.FirstName,
                            P.LastName,
                            S.GrossSalary,
                            S.BasicSalary,
                            S.NetSalary,
                            S.SalaryId
                        }
                      ).ToList();
            if (Bind != null)
            {
                GridViewEmployeeSalary.DataSource = Bind;
                GridViewEmployeeSalary.DataBind();
            }
            else
            {
                GridViewEmployeeSalary.DataSource = null;
                GridViewEmployeeSalary.DataBind();
            }
        }
    }
}