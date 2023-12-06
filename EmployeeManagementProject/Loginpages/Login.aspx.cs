using EmployeeManagementProject.BAL_Class;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementProject.Loginpages
{
    public partial class Login : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        General ObjG=new General();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            db= new EmployeeDataBaseEntities();

            var ifexist = (from L in db.LoginTables
                           where L.UserName==txtemailid.Text && L.Password==txtpassword.Text
                           select new { L.LoginId }).FirstOrDefault();

            if (ifexist != null) { 

            var LoginDetail = (from L in db.LoginTables
                                join P in db.PersonalDetails
                              on L.UserId equals P.EmployeeId
                                where L.UserName == txtemailid.Text && L.Password==txtpassword.Text
                              && L.IsActive == true && P.IsActive == true
                                select new
                                {
                                    L.UserId,
                                    L.LoginId,
                                    L.UserName,
                                    L.Password,
                                    L.RoleId,
                                    P.FirstName,
                                    P.LastName,
                                    P.DateOfBirth,
                                    P.EmployeeId,
                                    P.ProfileImage
                                }).FirstOrDefault();
                Session["UserId"] = LoginDetail.UserId;
                Session["EmployeeId"] = LoginDetail.EmployeeId;
                Session["FirstName"] = LoginDetail.FirstName;
                Session["LastName"] = LoginDetail.LastName;
                Session["RoleId"] = LoginDetail.RoleId;
                Session["Profile"] = LoginDetail.ProfileImage;
                int RoleId = Convert.ToInt32(Session["RoleId"]);

                if (RoleId == 1)
                {
                    Response.Redirect("~/AdminPanelPages/Home.aspx");
                }
                else if(RoleId == 2)
                {
                    Response.Redirect("~/EmployeeDashboard/Home.aspx");
                }
            }

            else
            {
                string massage = "UserName and Password is not  Correct ";
                string url = "Login.aspx";

                ObjG.ShowMessageAndRedirect(this, massage, url);

            }
        }
    }
}