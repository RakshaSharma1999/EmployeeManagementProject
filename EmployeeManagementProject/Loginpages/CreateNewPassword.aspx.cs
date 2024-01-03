using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using EmployeeManagementProject.BAL_Class;
namespace EmployeeManagementProject.Loginpages
{
    public partial class CreateNewPassword : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        General ObjG=new General();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void btnCreatePassword_Click(object sender, EventArgs e)
        //{
        //    db = new EmployeeDataBaseEntities();

        //    var EmailIdCheck=(from L in db.LoginTables join P in db.PersonalDetails
        //                      on L.UserId equals P.EmployeeId where L.UserName==txtemailid.Text
        //                      && L.IsActive == true && P.IsActive == true select new
        //                      {
        //                          L.LoginId, L.UserName,L.RoleId,P.FirstName,P.LastName,P.DateOfBirth,
        //                         P.EmployeeId
        //                      }).FirstOrDefault();
        //    if (EmailIdCheck != null)
        //    {
        //        using (var dbContext = new EmployeeDataBaseEntities())
        //        {
        //            string Fname=EmailIdCheck.FirstName;
        //            string Lname=EmailIdCheck.LastName;
        //            string Fullname = Fname + "" + Lname;
        //            DateTime Bdate = Convert.ToDateTime(EmailIdCheck.DateOfBirth);

        //            var result = dbContext.Database.SqlQuery<string>("EXEC SPCreateVerifyCode @firstName, @lastName,@dOB",
        //                new SqlParameter("FirstName", Fname),
        //                new SqlParameter("LastName", Lname),
        //                new SqlParameter("DOB", Bdate)
        //                ).ToList();
        //           lblCode.Text = result[0];
        //            SendMailNew(txtemailid.Text, txtemailid.Text, lblCode.Text, Fullname);
        //            EmailVerifyPanel.Visible = false;
        //            VerifyCodePanel.Visible=true; 
        //        }
        //    }
        //    else
        //    {
        //        string massage = "This Email Address is not Available Choose a Different Address ";
        //        string url = "CreateNewPassword.aspx";

        //        ObjG.ShowMessageAndRedirect(this, massage, url);
        //    }

        //}

        protected void btnVerifyEmail_Click(object sender, EventArgs e)
        {
            db = new EmployeeDataBaseEntities();

            var EmailIdCheck = (from L in db.LoginTables
                                join P in db.PersonalDetails
                              on L.UserId equals P.EmployeeId
                                where L.UserName == txtemailid.Text
                              && L.IsActive == true && P.IsActive == true
                                select new
                                {
                                    L.LoginId,
                                    L.UserName,
                                    L.RoleId,
                                    P.FirstName,
                                    P.LastName,
                                    P.DateOfBirth,
                                    P.EmployeeId
                                }).FirstOrDefault();
            
            if (EmailIdCheck != null)
            {
                using (var dbContext = new EmployeeDataBaseEntities())
                {
                    int  EmployeeId=EmailIdCheck.EmployeeId;
                    string Fname = EmailIdCheck.FirstName;
                    string Lname = EmailIdCheck.LastName;
                    string Fullname = Fname + "" + Lname;
                    DateTime Bdate = Convert.ToDateTime(EmailIdCheck.DateOfBirth);

                    var result = dbContext.Database.SqlQuery<string>("EXEC SPCreateVerifyCode @empId, @firstName, @lastName,@dOB",
                        new SqlParameter("EmpId", EmployeeId),
                        new SqlParameter("FirstName", Fname),
                        new SqlParameter("LastName", Lname),
                        new SqlParameter("DOB", Bdate) 
                        ).ToList();
                    lblCode.Text = result[0];
                    SendMailNew(txtemailid.Text, txtemailid.Text, lblCode.Text, Fullname);
                    
                    EmailVerifyPanel.Visible = false;
                    VerifyCodePanel.Visible = true;
                }
            }
            else
            {
                string massage = "This Email Address is not Available Choose a Different Address ";
                string url = "CreateNewPassword.aspx";

                ObjG.ShowMessageAndRedirect(this, massage, url);
            }
        }
        protected void btnVerifyCodeNext_Click(object sender, EventArgs e)
        {
           db=new EmployeeDataBaseEntities();
            string Code = txtVerify.Text;
            if (Code == lblCode.Text)
            {
                EmailVerifyPanel.Visible = false;
                VerifyCodePanel.Visible = false;
                CreatePasswordPanel.Visible = true;
            }
            else
            {
                lblMsg.Text = "Code Is Not Correct Please Check Your Email Account";
            }
        }

        public void SendMailNew(string Email, string Username, string Code, string FullName)
        {
            string EmailFromAddress = ConfigurationManager.AppSettings["EmailFromAddress"].ToString();
            string EmailPassword = ConfigurationManager.AppSettings["EmailPassword"].ToString();



            var fromAddress = EmailFromAddress;
            var toAddress = Email;
            string fromPassword = EmailPassword.ToString();

            string subject = "Your Verification Code ";
            string body = "Dear ," + FullName + " ";
            body += "Your Email Verification code is :" + "\n";
            body +=   Code  + "\n";
            body += "If you didn't request a code ,you can ignore this Email.  " + "\n";

            body += "Thank you!" + "\n";
            body += "Warm Regards," + "\n";

            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {

                MailMessage mail = new MailMessage();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                mail.IsBodyHtml = true;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 50000;
            }

            smtp.Send(fromAddress, toAddress, subject, body);
        }

       

        protected void btnCreatePassword_Click(object sender, EventArgs e)
        {
           db=new EmployeeDataBaseEntities();
            var Check=(from L in db.LoginTables
                       where L.UserName==txtemailid.Text select L).FirstOrDefault();
            Check.Password=txtPassword.Text;
            db.SaveChanges();
            string massage = "Your Password has been Created";
            string url = "Login.aspx";

            ObjG.ShowMessageAndRedirect(this, massage, url);
        }
    }
}