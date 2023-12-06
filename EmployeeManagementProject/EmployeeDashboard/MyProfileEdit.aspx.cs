using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementProject.AdminPanelPages;
using EmployeeManagementProject.BAL_Class;
namespace EmployeeManagementProject.EmployeeDashboard
{
    public partial class MyProfileEdit : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        General ObjG=new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.RegisterTrigger(btnFileUpload);

            if (!IsPostBack)
            {
                
                EmployeeDetails();
                StateEditBind();
                CityEditBind();
                BloodGroupBind();
                DepartmentBind();
            }
        }
     
       

      
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            db = new EmployeeDataBaseEntities();
            int UserId = Convert.ToInt32(Session["UserId"]);
            var EditPersonalDetail = (from P in db.PersonalDetails where P.EmployeeId == UserId && P.IsActive == true select P).FirstOrDefault();

            EditPersonalDetail.FirstName = txtFirstName.Text;
            EditPersonalDetail.LastName = txtLastName.Text;
            EditPersonalDetail.DateOfBirth = Convert.ToDateTime(txtDateofBirth.Text);
            EditPersonalDetail.Gender = RadioButtonGender.SelectedItem.ToString();
            EditPersonalDetail.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
            EditPersonalDetail.BloodGroupId = Convert.ToInt32(ddlBloodgroup.SelectedValue);
            EditPersonalDetail.ProfileImage = lblFilePath.Text;
            EditPersonalDetail.CreateBy = UserId;
            EditPersonalDetail.CreateOn = DateTime.Now;
            EditPersonalDetail.UpdateBy = UserId;
            EditPersonalDetail.UpdateOn = DateTime.Now;
            db.SaveChanges();

            var EditContactDetails = (from C in db.ContactDetails where C.EmployeeId == UserId select C).FirstOrDefault();

            EditContactDetails.HomeAddress = txtAddress.Text;
            EditContactDetails.MobileNo = txtMobileNo.Text;
            EditContactDetails.StateId = Convert.ToInt32(ddlEditState.SelectedValue);
            EditContactDetails.CityId = Convert.ToInt32(ddlEditCity.SelectedValue);

            EditContactDetails.UpdateBy = UserId;
            EditContactDetails.UpdateOn = DateTime.Now;
            db.SaveChanges();
            string message = "Data has been Updated Succesfully";
            string url = "EmployeeViewProfile.aspx";

            ObjG.ShowMessageAndRedirect(this, message, url);

        }
        //State Edit Bind
        public void StateEditBind()
        {
            db = new EmployeeDataBaseEntities();
            var Bind = (from s in db.StateMasters
                        where s.IsActive == true
                        select s).ToList();
            if (Bind != null)
            {
                ddlEditState.DataSource = Bind;
                ddlEditState.DataTextField = "StateName";
                ddlEditState.DataValueField = "StateId";
                ddlEditState.DataBind();
                ddlEditState.Items.Insert(0, new ListItem("--Select State--", "0"));
            }
        }

        //City Edit Bind

        public void CityEditBind()
        {
            db = new EmployeeDataBaseEntities();
            var Bind = (from c in db.Cities
                        where c.StateID == ddlEditState.SelectedValue
                        select c).ToList();
            if (Bind != null)
            {
                ddlEditCity.DataSource = Bind;
                ddlEditCity.DataTextField = "CityName";
                ddlEditCity.DataValueField = "ID";
                ddlEditCity.DataBind();
                ddlEditCity.Items.Insert(0, new ListItem("--Select City--", "0"));
            }
        }
        //  Bind BloodGroup
        public void BloodGroupBind()
        {
            db = new EmployeeDataBaseEntities();

            var Bind = (from bg in db.BloodGroups
                        where bg.IsActive == true
                        select bg).ToList();

            if (Bind != null)
            {
                ddlBloodgroup.DataSource = Bind;
                ddlBloodgroup.DataTextField = "BGName";
                ddlBloodgroup.DataValueField = "BGId";
                ddlBloodgroup.DataBind();
                ddlBloodgroup.Items.Insert(0, new ListItem("--Select BloodGroup--", "0"));
            }
        }

        //  Department Bind
        public void DepartmentBind()
        {
            db = new EmployeeDataBaseEntities();
            var Bind = (from D in db.DepartmentMasters
                        where D.IsActive == true
                        select D).ToList();
            if (Bind != null)
            {
                ddlDepartment.DataSource = Bind;
                ddlDepartment.DataTextField = "DepartMentName";
                ddlDepartment.DataValueField = "DepartMentId";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, new ListItem("--Select Department--", "0"));
            }
        }
       
        public void EmployeeDetails()
        {
            db = new EmployeeDataBaseEntities();
            int UserId = Convert.ToInt32(Session["UserId"]);
            var EditPersonalDetail = (from P in db.PersonalDetails where P.EmployeeId == UserId && P.IsActive == true select P).FirstOrDefault();
            txtFirstName.Text = EditPersonalDetail.FirstName;
            txtLastName.Text = EditPersonalDetail.LastName;
            txtDateofBirth.Text = Convert.ToDateTime(EditPersonalDetail.DateOfBirth).ToString("yyyy-MM-dd");
            RadioButtonGender.SelectedValue = EditPersonalDetail.Gender;
            ddlDepartment.SelectedValue = EditPersonalDetail.DepartmentId.ToString();
            ddlBloodgroup.SelectedValue = EditPersonalDetail.BloodGroupId.ToString();
            ImageProfile.ImageUrl = "~/ProfileImages/" + EditPersonalDetail.ProfileImage.ToString();
            lblFilePath.Text = EditPersonalDetail.ProfileImage;

            var EditContactDetails = (from C in db.ContactDetails where C.EmployeeId == UserId select C).FirstOrDefault();
            txtAddress.Text = EditContactDetails.HomeAddress;
            txtMobileNo.Text = EditContactDetails.MobileNo;
            ddlEditState.SelectedValue = EditContactDetails.StateId.ToString();
            CityEditBind();
            ddlEditCity.SelectedValue = EditContactDetails.CityId.ToString();
        }
        public void UploadImage()
        {
            try
            {
                string ImageName = "";
                ImageName = System.Guid.NewGuid().ToString();
                string filename = "", newfile = "";
                string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

                if (!ProfileUpload.HasFile)
                {
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                    ProfileUpload.Focus();
                }


                string ext = System.IO.Path.GetExtension(ProfileUpload.PostedFile.FileName).ToLower();
                bool isValidFile = false;
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isValidFile = true;
                        break;
                    }
                }
                if (isValidFile == true)
                {

                    if (ProfileUpload.HasFile)
                    {

                        filename = Server.MapPath(ProfileUpload.FileName);
                        newfile = ProfileUpload.PostedFile.FileName;

                        FileInfo fi = new FileInfo(newfile);

                        // check folder exist or not
                        if (!System.IO.Directory.Exists(@"~\ProfileImages"))
                        {
                            try
                            {

                                string Imgname = ImageName;

                                string path = Server.MapPath(@"~\ProfileImages\");

                                System.IO.Directory.CreateDirectory(path);
                                ProfileUpload.SaveAs(path + @"\" + ImageName + ext);

                                ImageProfile.ImageUrl = @"~\ProfileImages\" + ImageName + ext;
                                ImageProfile.Visible = true;

                                lblFilePath.Text = Imgname + ext;


                            }
                            catch (Exception ex)
                            {
                                lblFilePath.Text = "Not able to create new directory";
                            }

                        }
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
                }
            }
            catch (Exception ex)
            {

            }

        }


        protected void ddlEditState_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityEditBind();
        }

        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            UploadImage();
        }
    }
}