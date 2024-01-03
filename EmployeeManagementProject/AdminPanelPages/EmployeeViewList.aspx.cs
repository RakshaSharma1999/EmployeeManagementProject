using EmployeeManagementProject.AdminPanelPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using EmployeeManagementProject.BAL_Class;
using System.IO;

namespace EmployeeManagementProject.AdminPanelPages
{
    public partial class EmployeeViewList : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        General ObjG=new General();
        
        protected void Page_Load(object sender, EventArgs e)
        {
                this.Master.RegisterTrigger(btnFileUpload);
            if (! IsPostBack)
            {
                EmployeeListBind();
                StateBind();
                CityBind();
                StateEditBind();
                CityEditBind();
                BloodGroupBind();
                DepartmentBind();
            }
        }
        private long EmployeeID
        {
            get
            {
                if (ViewState["EmployeeId"] != null)
                {
                    return (long)ViewState["EmployeeId"];
                }
                return 0;
            }
            set
            {
                ViewState["EmployeeId"] = value;
            }
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEmployee();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text!="")
            {
                txtSearch.Text = "";
                EmployeeListBind();
            }
            else
            {
                EmployeeListBind();
            }
        }

        protected void GridViewEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int EmpId = Convert.ToInt32(e.CommandArgument);
            db=new EmployeeDataBaseEntities();
            // View
            if(e.CommandName== "ViewEmployeeDetails")
            {
                ViewPanel.Visible = true;
                ListPanel.Visible = false;

                var List = (from P in db.PersonalDetails
                            join B in db.BloodGroups
                         on P.BloodGroupId equals B.BGId
                            join D in db.DepartmentMasters on P.DepartmentId equals D.DepartMentId
                            join C in db.ContactDetails on P.EmployeeId equals C.EmployeeId
                            join S in db.StateMasters on C.StateId equals S.StateId
                            join city in db.Cities on C.CityId equals city.ID
                            where P.IsActive == true && P.EmployeeId==EmpId
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
                lblFullName.Text=List.FirstName + " " + List.LastName;
                lblGender.Text=List.Gender;
                lblBGName.Text=List.BGName;
                lblDateOfBirth.Text = Convert.ToDateTime(List.DateOfBirth).ToString("yyyy-MM-dd");
                lblDepartMentName.Text=List.DepartMentName;
                lblMobileNo.Text=List.MobileNo;
                lblEmailId.Text=List.EmailId;
                lblStateName.Text=List.StateName;
                lblCityName.Text=List.CityName;
                lblHomeAddress.Text=List.HomeAddress;
                lblDateofJoining.Text = List.DateofJoining.ToString();
            }

            // Edit
            if(e.CommandName== "EditEmployeeDetails")
            {
                EmployeeID = EmpId;
                EditPanel.Visible = true;
                ListPanel.Visible = false;

                var EditPersonalDetail = (from P in db.PersonalDetails where P.EmployeeId == EmpId && P.IsActive == true select P).FirstOrDefault();
                txtFirstName.Text = EditPersonalDetail.FirstName;
                txtLastName.Text = EditPersonalDetail.LastName;
                txtDateofBirth.Text =Convert.ToDateTime(EditPersonalDetail.DateOfBirth).ToString("yyyy-MM-dd") ;
                RadioButtonGender.SelectedValue= EditPersonalDetail.Gender;
                ddlDepartment.SelectedValue=EditPersonalDetail.DepartmentId.ToString();
                ddlBloodgroup.SelectedValue = EditPersonalDetail.BloodGroupId.ToString();
                 ImageProfile.ImageUrl= "~/ProfileImages/" + EditPersonalDetail.ProfileImage.ToString();
                lblFilePath.Text = EditPersonalDetail.ProfileImage;

                var EditContactDetails=(from C in db.ContactDetails where C.EmployeeId==EmpId select C).FirstOrDefault();
                txtAddress.Text = EditContactDetails.HomeAddress;
                txtMobileNo.Text = EditContactDetails.MobileNo;
               ddlEditState.SelectedValue=EditContactDetails.StateId.ToString();
                CityEditBind();
                ddlEditCity.SelectedValue = EditContactDetails.CityId.ToString();

            }
           
            //Delete 
            if(e.CommandName=="DeleteEmployeeDetails")
            {
                var DeleteEmployeeDetail = (from P in db.PersonalDetails where P.EmployeeId == EmpId  select P).FirstOrDefault();
               DeleteEmployeeDetail.IsActive = false;
                db.SaveChanges();
                EmployeeListBind();
            }
        }

        protected void GridViewEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEmployee.PageIndex = e.NewPageIndex;
            EmployeeListBind();
        }

       // Employee List Bind
       public void EmployeeListBind()
        {
            db= new EmployeeDataBaseEntities();
            var ListBind= (from P in db.PersonalDetails
                           join B in db.BloodGroups
                        on P.BloodGroupId equals B.BGId
                           join D in db.DepartmentMasters on P.DepartmentId equals D.DepartMentId
                           join C in db.ContactDetails on P.EmployeeId equals C.EmployeeId
                           join S in db.StateMasters on C.StateId equals S.StateId
                           join city in db.Cities on C.CityId equals city.ID
                           where P.IsActive == true 
                           orderby P.EmployeeId descending
                           select new
                           {
                               P.EmployeeId,
                               P.FirstName,
                               P.LastName,
                               P.ProfileImage,
                               P.Gender,
                               B.BGName,
                               D.DepartMentName,
                               C.MobileNo,
                               C.EmailId,
                               S.StateName,
                               city.CityName,
                               C.HomeAddress
                           }
                        ).ToList();
            if ( ListBind != null )
            {
                GridViewEmployee.DataSource = ListBind;
                GridViewEmployee.DataBind();
            }
            else
            {
                GridViewEmployee.DataSource= null;
                GridViewEmployee.DataBind();
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            //Response.Redirect("./EmployeeViewList.aspx");
            ViewPanel.Visible = false;
            ListPanel.Visible = true;
        }




      // Search Employee Function  
        public void SearchEmployee()
        {
            db=new EmployeeDataBaseEntities();

            if (ddlState.SelectedValue != null || ddlCity.SelectedValue!=null)
            {
                ddlState.SelectedValue = "0";
                ddlCity.SelectedValue = "0";
            }

            var Search= (from P in db.PersonalDetails
                          join D in db.DepartmentMasters on P.DepartmentId equals D.DepartMentId
                          join BG in db.BloodGroups on P.BloodGroupId equals BG.BGId
                          join CD in db.ContactDetails on P.EmployeeId equals CD.EmployeeId
                          join S in db.StateMasters on CD.StateId equals S.StateId
                          join C in db.Cities on CD.CityId equals C.ID
                          where P.IsActive == true && ((P.FirstName+" "+P.LastName).Contains(txtSearch.Text) || D.DepartMentName.Contains(txtSearch.Text)
                          || BG.BGName.Contains(txtSearch.Text) || (P.Gender==txtSearch.Text || P.Gender==txtSearch.Text)
                          )
                         
                             select new {

                                P.EmployeeId,
                                P.FirstName,
                                P.LastName,
                                P.ProfileImage,
                                P.Gender,
                                BG.BGName,
                                D.DepartMentName,
                                CD.MobileNo,
                                CD.EmailId,
                                S.StateName,
                                C.CityName,
                                CD.HomeAddress

                            }).ToList();
            if(Search.Count==0)
            {
                var SearchMobile = (from P in db.PersonalDetails
                              join D in db.DepartmentMasters on P.DepartmentId equals D.DepartMentId
                              join BG in db.BloodGroups on P.BloodGroupId equals BG.BGId
                              join CD in db.ContactDetails on P.EmployeeId equals CD.EmployeeId
                              join S in db.StateMasters on CD.StateId equals S.StateId
                              join C in db.Cities on CD.CityId equals C.ID
                              where P.IsActive == true && CD.MobileNo.Contains(txtSearch.Text)

                              select new
                              {

                                  P.EmployeeId,
                                  P.FirstName,
                                  P.LastName,
                                  P.ProfileImage,
                                  P.Gender,
                                  BG.BGName,
                                  D.DepartMentName,
                                  CD.MobileNo,
                                  CD.EmailId,
                                  S.StateName,
                                  C.CityName,
                                  CD.HomeAddress

                              }).ToList();
                Search = SearchMobile;
            }

            if (Search != null)
            {
                GridViewEmployee.DataSource = Search;
                GridViewEmployee.DataBind();
            }
            else
            {
                EmployeeListBind();
            }
        }

        // Search Employee State 
        public void SearchState()
        {

            db = new EmployeeDataBaseEntities();
            if (txtSearch.Text!=null)
            {
                txtSearch.Text = "";
            }

            int StateId = Convert.ToInt32(ddlState.SelectedValue);


            var Search = (from P in db.PersonalDetails
                          join D in db.DepartmentMasters on P.DepartmentId equals D.DepartMentId
                          join BG in db.BloodGroups on P.BloodGroupId equals BG.BGId
                          join CD in db.ContactDetails on P.EmployeeId equals CD.EmployeeId
                          join S in db.StateMasters on CD.StateId equals S.StateId
                          join C in db.Cities on CD.CityId equals C.ID
                          where P.IsActive == true && CD.StateId == StateId

                          select new
                          {

                              P.EmployeeId,
                              P.FirstName,
                              P.LastName,
                              P.ProfileImage,
                              P.Gender,
                              BG.BGName,
                              D.DepartMentName,
                              CD.MobileNo,
                              CD.EmailId,
                              S.StateName,
                              C.CityName,
                              CD.HomeAddress

                          }).ToList();

            if (Search != null)
            {
                GridViewEmployee.DataSource = Search;
                GridViewEmployee.DataBind();
            }
            else
            {
                EmployeeListBind();
            }
        }

        // Search Employee City 
        public void SearchCity()
        {
            db = new EmployeeDataBaseEntities();

            int StateId = Convert.ToInt32(ddlState.SelectedValue);
            int CityId= Convert.ToInt32(ddlCity.SelectedValue);

            var Search = (from P in db.PersonalDetails
                          join D in db.DepartmentMasters on P.DepartmentId equals D.DepartMentId
                          join BG in db.BloodGroups on P.BloodGroupId equals BG.BGId
                          join CD in db.ContactDetails on P.EmployeeId equals CD.EmployeeId
                          join S in db.StateMasters on CD.StateId equals S.StateId
                          join C in db.Cities on CD.CityId equals C.ID
                          where P.IsActive == true && CD.StateId == StateId && CD.CityId == CityId

                          select new
                          {

                              P.EmployeeId,
                              P.FirstName,
                              P.LastName,
                              P.ProfileImage,
                              P.Gender,
                              BG.BGName,
                              D.DepartMentName,
                              CD.MobileNo,
                              CD.EmailId,
                              S.StateName,
                              C.CityName,
                              CD.HomeAddress

                          }).ToList();

            if (Search != null)
            {
                GridViewEmployee.DataSource = Search;
                GridViewEmployee.DataBind();
            }
            else
            {
                EmployeeListBind();
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityBind();
            SearchState();
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchCity();
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
        //City Search Bind
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            db = new EmployeeDataBaseEntities();
            int UserId =Convert.ToInt32(Session["UserId"]);
            var EditPersonalDetail = (from P in db.PersonalDetails where P.EmployeeId == EmployeeID && P.IsActive == true select P).FirstOrDefault();

            EditPersonalDetail.FirstName = txtFirstName.Text;
             EditPersonalDetail.LastName= txtLastName.Text;
             EditPersonalDetail.DateOfBirth= Convert.ToDateTime(txtDateofBirth.Text);
            EditPersonalDetail.Gender = RadioButtonGender.SelectedItem.ToString();
            EditPersonalDetail.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
            EditPersonalDetail.BloodGroupId = Convert.ToInt32(ddlBloodgroup.SelectedValue);
            EditPersonalDetail.ProfileImage = lblFilePath.Text;
            EditPersonalDetail.CreateBy = UserId;
            EditPersonalDetail.CreateOn = DateTime.Now;
            EditPersonalDetail.UpdateBy = UserId;
            EditPersonalDetail.UpdateOn = DateTime.Now;
           db.SaveChanges();

            var EditContactDetails = (from C in db.ContactDetails where C.EmployeeId == EmployeeID select C).FirstOrDefault();

            EditContactDetails.HomeAddress = txtAddress.Text;
             EditContactDetails.MobileNo= txtMobileNo.Text;
             EditContactDetails.StateId= Convert.ToInt32(ddlEditState.SelectedValue);
            EditContactDetails.CityId = Convert.ToInt32(ddlEditCity.SelectedValue);
           
            EditContactDetails.UpdateBy = UserId;
            EditContactDetails.UpdateOn = DateTime.Now;
            db.SaveChanges();
            string message = "Data has been Updated Succesfully";
            string url = "EmployeeViewList.aspx";

            ObjG.ShowMessageAndRedirect(this, message, url);

        }

        protected void btnFileUpload_Click(object sender, EventArgs e)
        {

            UploadImage();
        }

        protected void ddlEditState_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityEditBind();
        }

        protected void btnEditBack_Click(object sender, EventArgs e)
        {
            ListPanel.Visible = true;
            EditPanel.Visible = false;
        }

        
    }
}

