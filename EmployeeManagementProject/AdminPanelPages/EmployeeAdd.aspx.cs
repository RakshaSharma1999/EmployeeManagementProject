using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementProject.BAL_Class;


namespace EmployeeManagementProject.AdminPanelPages
{
    public partial class EmployeeAdd : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        General ObjG=new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            this.Master.RegisterTrigger(btnFileUpload);
            if (!IsPostBack)
            {
                BloodGroupBind();
                RoleBind();
                DepartmentBind();
                StateBind();
                CityBind();
            }
        }


        protected void btnNext_Click(object sender, EventArgs e)
        {
            AddPanel.Visible = false;
            ContactPanel.Visible = true;
        }

      

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityBind();
        }

       

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            AddPanel.Visible = true;
            ContactPanel.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
          
            try {
                db = new EmployeeDataBaseEntities();
                
                int UserID = Convert.ToInt32(Session["UserId"]);
                // Check Duplicate
                var EmailCheck = (from C in db.ContactDetails
                                  where C.EmailId == txtEmailid.Text select new { C.ContactId }).FirstOrDefault();
                DateTime date =Convert.ToDateTime(txtDateofBirth.Text);
                if (EmailCheck == null) {
                    // Employee personal Details
                    var SetEmployee = new PersonalDetail
                    {
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        DateOfBirth = Convert.ToDateTime(txtDateofBirth.Text),
                        BloodGroupId = Convert.ToInt32(ddlBloodgroup.SelectedValue),
                        DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue),
                        Gender = RadioButtonGender.SelectedItem.ToString(),
                        DateofJoining = DateTime.Now,
                        ProfileImage = lblFilePath.Text,
                        CreateBy= UserID,
                        CreateOn= DateTime.Now,
                        UpdateBy= UserID,
                        UpdateOn= DateTime.Now,
                        IsActive = true,
                    };
                    db.PersonalDetails.Add(SetEmployee);
                    db.SaveChanges();
                    int EmpId = SetEmployee.EmployeeId;
                    // Contact Details
                    var SetContact = new ContactDetail
                    {
                        EmployeeId = EmpId,
                        MobileNo = txtMobileNo.Text,
                        EmailId = txtEmailid.Text,
                        StateId = Convert.ToInt32(ddlState.SelectedValue),
                        CityId = Convert.ToInt32(ddlCity.SelectedValue),
                        HomeAddress = txtAddress.Text,
                        CreateBy = UserID,
                        CreateOn= DateTime.Now,
                        UpdateBy = UserID,
                        UpdateOn= DateTime.Now,
                        IsActive = true,
                    };
                    db.ContactDetails.Add(SetContact);
                    db.SaveChanges();
                    // Login 
                    var SetLogin = new LoginTable
                    {
                        UserName = txtEmailid.Text,
                        UserId = EmpId,
                        RoleId = Convert.ToInt32(ddlRole.SelectedValue),
                        IsActive = true,
                    };
                    db.LoginTables.Add(SetLogin);
                    db.SaveChanges();
                    string message = "Data has been submited Succesfully";
                    string url = "EmployeeAdd.aspx";

                    ObjG.ShowMessageAndRedirect(this, message, url);
                }
                else
                {
                    lblMessage.Text = "Email ID Already Exists";
                }
            }
            catch(Exception E){
            }

            }
        protected void btnPreviousdetails_Click(object sender, EventArgs e)
        {
            ContactPanel.Visible = false;
            AddPanel.Visible = true;    
        }





        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            UploadImage();
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
        //  Bind Role
        public void RoleBind()
        {
            db = new EmployeeDataBaseEntities();
            var Bind = (from r in db.RoleMasters
                        where r.IsActive == true
                        select r).ToList();
            if (Bind != null)
            {
                ddlRole.DataSource = Bind;
                ddlRole.DataTextField = "RoleName";
                ddlRole.DataValueField = "RoleId";
                ddlRole.DataBind();
                ddlRole.Items.Insert(0, new ListItem("--Select Role Type--", "0"));
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
        //   State Bind
        public void StateBind()
        {
            db = new EmployeeDataBaseEntities();
            var Bind = (from s in db.StateMasters
                        where s.IsActive == true
                        select s).ToList();
            if (Bind != null)
            {
                ddlState.DataSource = Bind;
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateId";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("--Select State--", "0"));
            }
        }
        //City Bind
        public void CityBind()
        {
            db = new EmployeeDataBaseEntities();
            var Bind = (from c in db.Cities
                        where c.StateID == ddlState.SelectedValue
                        select c).ToList();
            if (Bind != null)
            {
                ddlCity.DataSource = Bind;
                ddlCity.DataTextField = "CityName";
                ddlCity.DataValueField = "CityID";
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, new ListItem("--Select City--", "0"));
            }
        }
    }
}