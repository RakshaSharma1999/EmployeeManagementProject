using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementProject.EmployeeDashboard
{
    public partial class EmployeeViewProfile : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmployeeDetailsShow();

            }
        }

        //Show Employee Details
        public void EmployeeDetailsShow()
        {
            db = new EmployeeDataBaseEntities();
            int UserId = Convert.ToInt32(Session["UserId"]);
            var List = (from P in db.PersonalDetails
                        join B in db.BloodGroups
                     on P.BloodGroupId equals B.BGId
                        join D in db.DepartmentMasters on P.DepartmentId equals D.DepartMentId
                        join C in db.ContactDetails on P.EmployeeId equals C.EmployeeId
                        join S in db.StateMasters on C.StateId equals S.StateId
                        join city in db.Cities on C.CityId equals city.ID
                        where P.IsActive == true && P.EmployeeId == UserId
                        select new
                        {
                            P.EmployeeId,
                            P.FirstName,
                            P.LastName,
                            P.ProfileImage,
                            P.Gender,
                            P.DateOfBirth,
                            P.DateofJoining,
                            B.BGName,
                            D.DepartMentName,
                            C.MobileNo,
                            C.EmailId,
                            S.StateName,
                            city.CityName,
                            C.HomeAddress
                        }
                                   ).FirstOrDefault();
            ProfileImage.ImageUrl = "~/ProfileImages/" + List.ProfileImage;
            lblFullName.Text = List.FirstName + " " + List.LastName;
            lblGender.Text = List.Gender;
            lblBGName.Text = List.BGName;
            lblDateOfBirth.Text = Convert.ToDateTime(List.DateOfBirth).ToString("yyyy-MM-dd");
            lblDepartMentName.Text = List.DepartMentName;
            lblMobileNo.Text = List.MobileNo;
            lblEmailId.Text = List.EmailId;
            lblStateName.Text = List.StateName;
            lblCityName.Text = List.CityName;
            lblHomeAddress.Text = List.HomeAddress;
            lblDateofJoining.Text = List.DateofJoining.ToString();
        }




    }

}