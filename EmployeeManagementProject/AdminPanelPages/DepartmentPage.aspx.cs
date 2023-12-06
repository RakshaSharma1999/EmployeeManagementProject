using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementProject.BAL_Class;
namespace EmployeeManagementProject.AdminPanelPages
{
    public partial class DepartmentPage : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        General objG=new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDepartment();
            }
        
         }
        private long DepartmentId
        {
            get
            {
                if (ViewState["DepartmentId"] != null)
                {
                    return (long)ViewState["DepartmentId"];
                }
                return 0;
            }
            set
            {
                ViewState["DepartmentId"] = value;
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            db=new EmployeeDataBaseEntities();
            var Search=(from D in db.DepartmentMasters
                        where D.DepartMentName.Contains(txtSearch.Text) && D.IsActive == true
                        select D).ToList();
            if (Search != null)
            {
                GridViewDepartment.DataSource = Search;
                GridViewDepartment.DataBind();
            }
            else
            {
                BindDepartment();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanelPages/DepartmentPage.aspx");
        }

        protected void AddNew_Click(object sender, EventArgs e)
        {
            AddPanel.Visible = true;
            ListPanel.Visible = false;
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            db = new EmployeeDataBaseEntities();

            var DupCheck = (from d in db.DepartmentMasters
                            where d.IsActive == true && d.DepartMentName == txtDepartmentName.Text
                            select new { d.DepartMentId }
                          ).FirstOrDefault();
            if (DupCheck == null)
            {
                if (DepartmentId == 0)
                {
                    var Newdata = new DepartmentMaster
                    {
                        DepartMentName = txtDepartmentName.Text,
                        IsActive = true
                    };
                    db.DepartmentMasters.Add(Newdata);
                    db.SaveChanges();
                    string message = "Data has been submited Succesfully";
                    string url = "DepartmentPage.aspx";
                    objG.ShowMessageAndRedirect(this, message, url);
                }
                else
                {
                    var Update = (from d in db.DepartmentMasters
                                  where d.DepartMentId == DepartmentId
                                  select d).FirstOrDefault();
                    Update.DepartMentName = txtDepartmentName.Text;
                    db.SaveChanges();
                    string message = "Data has been Updated Succesfully";
                    string url = "DepartmentPage.aspx";

                    objG.ShowMessageAndRedirect(this, message, url);
                }
            }
            else
            {
                string message = "Data Already Exist";
                string url = "DepartmentPage.aspx";

                objG.ShowMessageAndRedirect(this, message, url);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentPage.aspx");
        }

        protected void GridViewDepartment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            db = new EmployeeDataBaseEntities();
            int Departmentid = 0;
            Departmentid = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "DeleteDepartment")
            {
                var Deletedata = (from d in db.DepartmentMasters
                                  where d.DepartMentId == Departmentid
                                  select d).FirstOrDefault();
                Deletedata.IsActive = false;
                db.SaveChanges();
                BindDepartment();
            }
            if (e.CommandName == "ViewDepartment")
            {
                ListPanel.Visible = false;
                ViewPanel.Visible = true;
                var View = (from d in db.DepartmentMasters
                            where d.DepartMentId == Departmentid
                            select d).FirstOrDefault();
                lblDepartmentId.Text = View.DepartMentId.ToString();
                lblDepartmentName.Text = View.DepartMentName.ToString();
            }

            if (e.CommandName == "EditDepartment")
            {
                DepartmentId = Departmentid;
                AddPanel.Visible = true;
                ListPanel.Visible = false;

                var Editdata = (from d in db.DepartmentMasters
                                where d.DepartMentId == Departmentid
                                select d).FirstOrDefault();

                txtDepartmentName.Text = Editdata.DepartMentName;
               
            }
        }

        protected void GridViewDepartment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewDepartment.PageIndex = e.NewPageIndex;
            BindDepartment();
        }

        // Gridview Bind
        public void BindDepartment()
        {
            db = new EmployeeDataBaseEntities();

            var Bind = (from d in db.DepartmentMasters
                        where d.IsActive == true
                        select d).ToList();
            if (Bind != null)
            {
                GridViewDepartment.DataSource = Bind;
                GridViewDepartment.DataBind();
            }
            else
            {
                GridViewDepartment.DataSource = null;
                GridViewDepartment.DataBind();
            }
        }

        protected void btnBackView_Click(object sender, EventArgs e)
        {
            ListPanel.Visible = true;
            ViewPanel.Visible = false;
        }
    }
}