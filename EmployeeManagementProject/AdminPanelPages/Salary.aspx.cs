using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementProject.BAL_Class;

namespace EmployeeManagementProject.AdminPanelPages
{
    public partial class Salary : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        General ObjG=new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SalaryBind();
            }
        }
        private long SalaryID
        {
            get
            {
                if (ViewState["SalaryId"] != null)
                {
                    return (long)ViewState["SalaryId"];
                }
                return 0;
            }
            set
            {
                ViewState["SalaryId"] = value;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
           AddPanel.Visible = false;
            ListPanel.Visible = true;
        }

      

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int Result = 0;
            int UserID = Convert.ToInt32(Session["UserId"]);
            int EmpId=Convert.ToInt32(txtEmployeeId.Text);
            db =new EmployeeDataBaseEntities();
            var Check=(from P in db.PersonalDetails
                       where P.EmployeeId== EmpId && (P.FirstName + " " + P.LastName)==txtEmployeeName.Text
                       select P
                       ).FirstOrDefault();

            if(Check!=null) {

                if (SalaryID == 0) { 

            var Set = new SalaryTable {
                EmployeeId = Convert.ToInt32(txtEmployeeId.Text),
                GrossSalary = Convert.ToDecimal(txtGrossSalary.Text),
                BasicSalary = Convert.ToDecimal(txtBasicSalary.Text),
                HouseRentAllowance = Convert.ToDecimal(txtHRA.Text),
                DearnessAllowance = Convert.ToDecimal(txtDearnessAllowance.Text),
                ConveyanceAllowance = Convert.ToDecimal(txtConveyanceAllowance.Text),
                MedicalAllowance = Convert.ToDecimal(txtMedicalAllowance.Text),
                OtherAllowance = Convert.ToDecimal(txtOtherAllowance.Text),
                ProvidentFund = Convert.ToDecimal(txtProvidentFund.Text),
                ESI = Convert.ToDecimal(txtESI.Text),
                ProfessionalTax = Convert.ToDecimal(txtPT.Text),
                NetSalary = Convert.ToDecimal(txtNetSalary.Text),
                IsActive = true,
                CreateBy = UserID,
                CreateOn = DateTime.Now,
                UpdateBy = UserID,
                UpdateOn = DateTime.Now,
 
            };
                db.SalaryTables.Add(Set);
                Result = db.SaveChanges();
                if (Result > 0)
                {
                    string message = "Data has been submited Succesfully";
                    string url = "Salary.aspx";

                    ObjG.ShowMessageAndRedirect(this, message, url);
                }
                }
                else
                {
                    var Edit = (from S in db.SalaryTables where S.SalaryId==SalaryID
                                select S
                                ).FirstOrDefault();
                    Edit.EmployeeId = Convert.ToInt32(txtEmployeeId.Text);
                    Edit.GrossSalary = Convert.ToDecimal(txtGrossSalary.Text);
                    Edit.BasicSalary = Convert.ToDecimal(txtBasicSalary.Text);
                    Edit.HouseRentAllowance = Convert.ToDecimal(txtHRA.Text);
                    Edit.DearnessAllowance = Convert.ToDecimal(txtDearnessAllowance.Text);
                    Edit.ConveyanceAllowance = Convert.ToDecimal(txtConveyanceAllowance.Text);
                    Edit.MedicalAllowance = Convert.ToDecimal(txtMedicalAllowance.Text);
                    Edit.OtherAllowance = Convert.ToDecimal(txtOtherAllowance.Text);
                    Edit.ProvidentFund = Convert.ToDecimal(txtProvidentFund.Text);
                    Edit.ESI = Convert.ToDecimal(txtESI.Text);
                    Edit.ProfessionalTax = Convert.ToDecimal(txtPT.Text);
                    Edit.NetSalary = Convert.ToDecimal(txtNetSalary.Text);
                    Edit.UpdateBy = UserID;
                    Edit.UpdateOn = DateTime.Now;
                   Result= db.SaveChanges();
                    if (Result > 0)
                    {
                        string message = "Data has been Updated Succesfully";
                        string url = "Salary.aspx";

                        ObjG.ShowMessageAndRedirect(this, message, url);
                    }
                }
            }
            else
            {
                string message = "Employee Id and Employee Name is not Existed";
                string url = "Salary.aspx";

                ObjG.ShowMessageAndRedirect(this, message, url);
            }

        }

        // Salary Calculation
        public void Cal()
        {
            decimal BasicSalary = 0;
            decimal HRA = 0;
            decimal DA = 0;
            decimal OtherAllowance = 0;
            decimal ConveyanceAllowance = 0;
            decimal MedicalAllowance= 0;
            decimal GrossSalary = 0;
            decimal ESI = 0;
            decimal ESIPer = Convert.ToDecimal(3.25);
            decimal PF = 0;
            
            decimal Deduction= 0;
            if (txtGrossSalary.Text != "") { 
             GrossSalary = Convert.ToDecimal(txtGrossSalary.Text);
           
            BasicSalary = (GrossSalary * 50) / 100;
            DA = (BasicSalary * 20) / 100;
            HRA = (BasicSalary * 50) / 100;
            ESI = (GrossSalary * ESIPer) / 100;

                PF = (BasicSalary * 12) / 100;
                txtProvidentFund.Text = PF.ToString();
                txtBasicSalary.Text = BasicSalary.ToString();
            txtDearnessAllowance.Text=DA.ToString();
            txtHRA.Text = HRA.ToString();
                txtESI.Text = ESI.ToString();
                if (txtConveyanceAllowance.Text != "")
                {
                    if(txtMedicalAllowance.Text=="") { txtMedicalAllowance.Text = "0"; }
                    ConveyanceAllowance = Convert.ToDecimal(txtConveyanceAllowance.Text);
                    OtherAllowance = GrossSalary - (BasicSalary + HRA + DA + Convert.ToDecimal(txtMedicalAllowance.Text) + ConveyanceAllowance);
                    txtOtherAllowance.Text = OtherAllowance.ToString();
                }
                 if (txtMedicalAllowance.Text !="")
                {
                    if (txtConveyanceAllowance.Text == "") { txtConveyanceAllowance.Text = "0"; }
                    MedicalAllowance = Convert.ToDecimal(txtMedicalAllowance.Text);
                    OtherAllowance = GrossSalary - (BasicSalary + HRA + DA + MedicalAllowance + Convert.ToDecimal(txtConveyanceAllowance.Text));
                    txtOtherAllowance.Text = OtherAllowance.ToString();
                }

              if(txtESI.Text!="" || txtProvidentFund.Text!="" || txtPT.Text!="")
                {
                    if (txtPT.Text == "") { txtPT.Text = "0"; }
                    Deduction=GrossSalary - (ESI+PF+Convert.ToDecimal(txtPT.Text));
                }
                 txtNetSalary.Text= Deduction.ToString();
            }
            else
            {
                lblmsg.Text = "Please Enter Gross Salary";
            }
        }

       

        protected void txtGrossSalary_TextChanged(object sender, EventArgs e)
            {
            Cal();
        }

        protected void txtMedicalAllowance_TextChanged(object sender, EventArgs e)
            {
            Cal();
        }

        protected void txtConveyanceAllowance_TextChanged(object sender, EventArgs e)
        {
            Cal();
        }

        protected void txtBasicSalary_TextChanged(object sender, EventArgs e)
        {
            Cal();
        }

        protected void txtPT_TextChanged(object sender, EventArgs e)
        {
            Cal();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != null || txtSearchEmployeeId!=null)
            {
                Response.Redirect("~/AdminPanelPages/Salary.aspx");
                //txtSearch.Text = " ";
                //SalaryBind();
            }
            else
            {
                Response.Redirect("~/AdminPanelPages/Salary.aspx");
                //SalaryBind();
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            AddPanel.Visible = true;
            ListPanel.Visible = false;
        }

       

        protected void GridViewEmployeeSalary_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            db=new EmployeeDataBaseEntities();
            int Salaryid=Convert.ToInt32(e.CommandArgument);
            if(e.CommandName== "ViewEmployeeSalary")
            {
                ViewPanel.Visible = true;
                ListPanel.Visible=false;
                var View=(from S in db.SalaryTables
                          join P in db.PersonalDetails on S.EmployeeId equals P.EmployeeId
                          where S.SalaryId==Salaryid select new
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
                              S.MedicalAllowance,S.ConveyanceAllowance,
                              S.OtherAllowance,
                              S.ProfessionalTax,S.ProvidentFund,S.ESI

                          }
                          
                          ).FirstOrDefault();
                lblEmployeeId.Text = View.EmployeeId.ToString();
                lblFullName.Text=View.FirstName + " " + View.LastName;
                lblGrossSalary.Text = View.GrossSalary.ToString();
                lblBasicSalary.Text = View.BasicSalary.ToString();
                lblNetSalary.Text = View.NetSalary.ToString();
                lblHRA.Text = View.HouseRentAllowance.ToString();
                lblDA.Text = View.DearnessAllowance.ToString();
                lblMedicalAllowance.Text = View.MedicalAllowance.ToString();
                lblConveyanceAllowance.Text=View.ConveyanceAllowance.ToString();
                lblOtherAllowance.Text= View.OtherAllowance.ToString();
                lblProfessionalTax.Text=View.ProfessionalTax.ToString();
                lblProvidentFund.Text=View.ProvidentFund.ToString();
                lblESI.Text=View.ESI.ToString();
            }
            if(e.CommandName=="DeleteEmployeeSalary")
            {
             var Delete=(from S in db.SalaryTables
                         where S.SalaryId==Salaryid select S).FirstOrDefault();
                Delete.IsActive = false;
                db.SaveChanges();
                SalaryBind();
            }

            if(e.CommandName== "EditEmployeeSalary")
            {
                AddPanel.Visible = true;
                ListPanel.Visible = false;
                SalaryID = Salaryid;
                var Edit=(from S in db.SalaryTables
                          join P in db.PersonalDetails on S.EmployeeId equals P.EmployeeId
                          where S.SalaryId == SalaryID
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

                          }).FirstOrDefault();
                txtEmployeeId.Text = Edit.EmployeeId.ToString();
                txtEmployeeName.Text = Edit.FirstName + " " + Edit.LastName;
                txtGrossSalary.Text=Edit.GrossSalary.ToString();
                txtBasicSalary.Text= Edit.BasicSalary.ToString();
                txtHRA.Text = Edit.HouseRentAllowance.ToString();
                txtDearnessAllowance.Text=Edit.DearnessAllowance.ToString();
                txtConveyanceAllowance.Text= Edit.ConveyanceAllowance.ToString();   
                txtMedicalAllowance.Text=Edit.MedicalAllowance.ToString();
                txtOtherAllowance.Text=Edit.OtherAllowance.ToString();
               txtProvidentFund.Text=Edit.ProvidentFund.ToString();
                txtESI.Text = Edit.ESI.ToString();
                txtPT.Text=Edit.ProfessionalTax.ToString();
                txtNetSalary.Text=Edit.NetSalary.ToString();    
            }

        }

        protected void GridViewEmployeeSalary_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEmployeeSalary.PageIndex = e.NewPageIndex;
            SalaryBind();
        }
        // Salary Bind
        public void SalaryBind()
        {
            db=new EmployeeDataBaseEntities();
            var Bind=(from S in db.SalaryTables
                      join P in db.PersonalDetails on S.EmployeeId equals P.EmployeeId
                      where S.IsActive == true
                      select new
                      {
                          P.EmployeeId,P.FirstName,P.LastName,
                          S.GrossSalary,S.BasicSalary,S.NetSalary,S.SalaryId
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

        protected void btnback_Click(object sender, EventArgs e)
        {
            ViewPanel.Visible = false;
            ListPanel.Visible = true;
        }

        //Search
        public void Search()
        {
            db = new EmployeeDataBaseEntities();
            if (txtSearch.Text != "" && txtSearchEmployeeId.Text != "")
            {
                int EmpId = Convert.ToInt32(txtSearchEmployeeId.Text);
                var Search = (from S in db.SalaryTables
                              join P in db.PersonalDetails on S.EmployeeId equals P.EmployeeId
                              where S.IsActive == true && (S.EmployeeId == EmpId || (P.FirstName + " " + P.LastName).Contains(txtSearch.Text))
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
                              }).ToList();

                if (Search != null)
                {
                    GridViewEmployeeSalary.DataSource = Search;
                    GridViewEmployeeSalary.DataBind();
                }
                else
                {
                    SalaryBind();
                }
            }
            else if (txtSearchEmployeeId.Text != "")
            {
                int EmpId = Convert.ToInt32(txtSearchEmployeeId.Text);
                var Search = (from S in db.SalaryTables
                              join P in db.PersonalDetails on S.EmployeeId equals P.EmployeeId
                              where S.IsActive == true && S.EmployeeId == EmpId
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
                              }).ToList();

                if (Search != null)
                {
                    GridViewEmployeeSalary.DataSource = Search;
                    GridViewEmployeeSalary.DataBind();
                }
                else
                {
                    SalaryBind();
                }
            }
            else if (txtSearch.Text != "")
            {

                var Search = (from S in db.SalaryTables
                              join P in db.PersonalDetails on S.EmployeeId equals P.EmployeeId
                              where S.IsActive == true && (P.FirstName + " " + P.LastName).Contains(txtSearch.Text)
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
                              }).ToList();

                if (Search != null)
                {
                    GridViewEmployeeSalary.DataSource = Search;
                    GridViewEmployeeSalary.DataBind();
                }
                else
                {
                    SalaryBind();
                }
            }
            else
            {
                SalaryBind();
            }

        }
    }
}