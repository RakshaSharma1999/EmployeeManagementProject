using EmployeeManagementProject.BAL_Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace EmployeeManagementProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        // DataBase Name using Entities and db is an object of databaseEntity
        EmployeeDataBaseEntities db;
        public void DoWork()
        {
        }
        #region  Upload Multiple Photos

        public FileUploadResponselistImage UploadMultiplePhotos_New(Stream stream)
        {

            FileUploadResponselistImage FUR = new FileUploadResponselistImage();

            ImagePathList FU = new ImagePathList();

            string f_path = "";

            try
            {
                MemoryStream ms = null;

                byte[] b = null;

                MultipartParser parser = null;
                parser = new MultipartParser(stream);

                b = parser.FileContents;

                int count = 0;
                var PathList = new List<ImagePathList>();
                foreach (var item in parser.MyContents)
                {
                    ImagePathList PathImage = new ImagePathList();
                    string Fname = "";


                    if (item.PropertyName.Contains("stream"))
                    {

                        Fname = Guid.NewGuid().ToString() + ".png";
                        b = item.Data;
                        ms = new MemoryStream(b, 0, b.Length);
                        //ms = new MemoryStream(item.Data, 0, item.Data.Length);



                        FileStream fs = new FileStream(Path.Combine(HttpRuntime.AppDomainAppPath, "Documents/") + Fname, FileMode.Create);

                        string ServerResponse = ConfigurationManager.AppSettings["FileStreamPath"].ToString();

                        ms.WriteTo(fs);

                        ms.Close();

                        fs.Close();

                        fs.Dispose();

                        FUR.status = "1";

                        f_path = ServerResponse + Fname;
                        PathImage.imageurl = ServerResponse + Fname;

                        PathList.Add(PathImage);

                    }

                }

                FUR.data = PathList;
                FUR.status = "1";

                return FUR;

            }

            catch (Exception ex)
            {

                FUR.status = "0";

                FUR.data = null;

                return FUR;

            }

        }

        #endregion

        #region Add Employee

        public CheckAddandDeleteEmployee SetEmployee(int EmpId, string
            FirstName, string LastName, string Gender, int BloodGroupId, int
            RoleId, int DepartmentId, string MobileNo, string EmailId,
            int StateId, int CityId, string HomeAddress)
        {
            CheckAddandDeleteEmployee ObjCheck = new CheckAddandDeleteEmployee();
            int Result = 0;
            db = new EmployeeDataBaseEntities();

            try
            {

                if (EmpId == 0)
                {
                    var namecheck = (from C in db.ContactDetails
                                     where C.EmailId == EmailId
                                     select C).FirstOrDefault();

                    if (namecheck == null)
                    {
                        var NewEmployeeData = new PersonalDetail
                        {
                            FirstName = FirstName,
                            LastName = LastName,
                            //DateOfBirth = DateOfBirth,
                            Gender = Gender,
                            BloodGroupId = BloodGroupId,
                            DepartmentId = DepartmentId,
                            DateofJoining = DateTime.Now,
                            IsActive = true,

                        };
                        db.PersonalDetails.Add(NewEmployeeData);
                        Result = db.SaveChanges();
                        int EmployeeId = NewEmployeeData.EmployeeId;
                        var NewContact = new ContactDetail
                        {
                            EmployeeId = EmployeeId,
                            MobileNo = MobileNo,
                            EmailId = EmailId,
                            StateId = StateId,
                            CityId = CityId,
                            HomeAddress = HomeAddress,
                            IsActive = true,

                        };
                        db.ContactDetails.Add(NewContact);
                        db.SaveChanges();

                        var NewLogin = new LoginTable
                        {
                            UserName = EmailId,
                            RoleId = RoleId,
                            UserId = EmployeeId,
                            IsActive = true
                        };
                        db.LoginTables.Add(NewLogin);
                        db.SaveChanges();

                    }
                    else
                    {
                        ObjCheck.EmployeeId = "-2";
                        ObjCheck.Status = false;
                        ObjCheck.Message = "Employee All";
                    }
                }
                else
                {
                    var UpdateEmployeedata = (from E in db.PersonalDetails
                                              where E.EmployeeId == EmpId
                                              select E).FirstOrDefault();
                    UpdateEmployeedata.FirstName = FirstName;
                    UpdateEmployeedata.LastName = LastName;
                    //UpdateEmployeedata.DateOfBirth = DateOfBirth;
                    UpdateEmployeedata.BloodGroupId = BloodGroupId;
                    UpdateEmployeedata.DepartmentId = DepartmentId;
                    UpdateEmployeedata.Gender = Gender;
                    db.SaveChanges();

                    var UpdateContact = (from C in db.ContactDetails
                                         where C.EmployeeId == EmpId
                                         select C).FirstOrDefault();
                    UpdateContact.MobileNo = MobileNo;
                    UpdateContact.EmailId = EmailId;
                    UpdateContact.StateId = StateId;
                    UpdateContact.CityId = CityId;
                    UpdateContact.HomeAddress = HomeAddress;
                    db.SaveChanges();
                    Result = EmpId;

                }

                if (Result > 0)
                {
                    ObjCheck.EmployeeId = Result.ToString();
                    ObjCheck.Status = true;
                    ObjCheck.Message = "Success";
                }
                else
                {
                    ObjCheck.EmployeeId = "0";
                    ObjCheck.Status = false;
                    ObjCheck.Message = "Failure";
                }





            }
            catch (Exception ex)
            {
                ObjCheck.EmployeeId = "-2";
                ObjCheck.Status = false;
                ObjCheck.Message = ex.Message;
            }

            return ObjCheck;
        }

        #endregion

        #region List Of Employee
        public CheckEmployeeList GetEmployee()
        {
            CheckEmployeeList ObjCheck = new CheckEmployeeList();
            List<EmployeeList> List = new List<EmployeeList>();
            EmployeeList objL = null;
            db = new EmployeeDataBaseEntities();
            try
            {
               var Get=(from P in db.PersonalDetails join B in db.BloodGroups
                        on P.BloodGroupId equals B.BGId
                        join D in db.DepartmentMasters on P.DepartmentId equals D.DepartMentId
                        join C in db.ContactDetails on P.EmployeeId equals C.EmployeeId
                        join S in db.StateMasters on C.StateId equals S.StateId
                        join city in db.Cities on C.CityId equals city.ID
                        where P.IsActive==true
                        select new
                        {
                        P.EmployeeId, P.FirstName,P.LastName,P.Gender,B.BGName,D.DepartMentName,C.MobileNo,C.EmailId,S.StateName,
                          city.CityName,C.HomeAddress
                        }
                        ).ToList();
                if (Get != null)
                {
                    foreach(var item  in Get)
                    {
                        objL=new EmployeeList();
                        objL.EmployeeId = item.EmployeeId;
                        objL.FirstName = item.FirstName;
                        objL.LastName=item.LastName;
                        objL.Gender = item.Gender;
                        objL.BloodgroupName = item.BGName;
                        objL.DepartmentName = item.DepartMentName;
                        objL.MobileNo = item.MobileNo;
                        objL.EmailId = item.EmailId;
                        objL.StateName = item.StateName;
                        objL.CityName = item.CityName;
                        objL.HomeAddress = item.HomeAddress;
                        List.Add(objL);
                    }
                    ObjCheck.Data = List;
                    ObjCheck.Status = true;
                    ObjCheck.Message = "Success";
                }
                else
                {
                    ObjCheck.Data = null;
                    ObjCheck.Status = false;
                    ObjCheck.Message = "Failure";
                }
            }
            catch(Exception ex)
            {
                ObjCheck.Data = null;
                ObjCheck.Status = false;
                ObjCheck.Message = ex.Message;

            }
            

         return ObjCheck;
        }
        #endregion

        #region Delete Employee
        public CheckAddandDeleteEmployee DeleteEmployeeDetails(int EmpId)
        {
            CheckAddandDeleteEmployee ObjCheck= new CheckAddandDeleteEmployee();
            db = new EmployeeDataBaseEntities();
            try
            {
             var Delete=(from P in db.PersonalDetails where P.EmployeeId== EmpId select P).FirstOrDefault();
                Delete.IsActive = false;
                db.SaveChanges();
                ObjCheck.EmployeeId = EmpId.ToString();
                ObjCheck.Status = true;
                ObjCheck.Message = "Success";
                

            }
            catch(Exception ex)
            {
                ObjCheck.EmployeeId = null;
                ObjCheck.Status = false;
                ObjCheck.Message = ex.Message;
            }
            return ObjCheck;
        }
        #endregion

        #region Search Employee 
        public CheckEmployeeList SearchEmplyee(string FirstName,string LastName, string MobileNo)
        {
            CheckEmployeeList ObjCheck= new CheckEmployeeList();
            List<EmployeeList> List= new List<EmployeeList>();
            EmployeeList objL = null;
            db=new EmployeeDataBaseEntities();

            try
            {
                var Get = (from P in db.PersonalDetails
                           join B in db.BloodGroups
                        on P.BloodGroupId equals B.BGId
                           join D in db.DepartmentMasters on P.DepartmentId equals D.DepartMentId
                           join C in db.ContactDetails on P.EmployeeId equals C.EmployeeId
                           join S in db.StateMasters on C.StateId equals S.StateId
                           join city in db.Cities on C.CityId equals city.ID
                           where P.IsActive == true && P.FirstName.Contains(FirstName) 
                           && P.LastName.Contains(LastName) && C.MobileNo.Contains(MobileNo)
                           select new
                           {
                               P.EmployeeId,
                               P.FirstName,
                               P.LastName,
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

                if (Get != null)
                {
                    foreach(var item in Get)
                    {
                        objL = new EmployeeList();
                        objL.FirstName = item.FirstName;
                        objL.LastName=item.LastName;
                        objL.BloodgroupName=item.BGName; 
                        objL.DepartmentName = item.DepartMentName;
                        objL.EmailId= item.EmailId;
                        objL.MobileNo= item.MobileNo;
                        objL.StateName= item.StateName;
                        objL.CityName= item.CityName;
                        objL.HomeAddress= item.HomeAddress;
                        List.Add(objL); 
                    }
                    ObjCheck.Data = List;
                    ObjCheck.Status = true;
                    ObjCheck.Message = "Success";
                }
                else
                {
                    ObjCheck.Data = null;
                    ObjCheck.Status = false;
                    ObjCheck.Message = "Failure";
                }
            }
            catch (Exception ex)
            {
                ObjCheck.Data = null;
                ObjCheck.Status = false;
                ObjCheck.Message = ex.Message;
            }
            return ObjCheck;
        }
        #endregion

        #region DepartMent List
        public CheckDepartmentList GetDepartmentList()
        {
            CheckDepartmentList ObjCheck = new CheckDepartmentList();
            List<DepartmentList> List = new List<DepartmentList>();
            DepartmentList ObjL = null;
            db=new EmployeeDataBaseEntities();
            try
            {
                var Get = (from d in db.DepartmentMasters
                            where d.IsActive == true
                            select d).ToList();
                if (Get != null)
                {
                    foreach(var item in Get)
                    {
                        ObjL = new DepartmentList();
                        ObjL.DepartmentId = item.DepartMentId;
                        ObjL.DepartmentName = item.DepartMentName;
                        List.Add(ObjL);
                    }
                    ObjCheck.Data = List;
                    ObjCheck.Status = true;
                    ObjCheck.Message = "Success";
                }
                else
                {
                    ObjCheck.Data = null;
                    ObjCheck.Status = false;
                    ObjCheck.Message = "Failure";
                }
            }
            catch(Exception ex)
            {
                ObjCheck.Data = null;
                ObjCheck.Status = false;
                ObjCheck.Message = ex.Message;
            }
            

            return ObjCheck;
        }
        #endregion

        #region Search DepartmentList
        public CheckDepartmentList GetSearchDepartmentList(string DepartmentName)
        {
            CheckDepartmentList ObjCheck = new CheckDepartmentList();
            List<DepartmentList> List = new List<DepartmentList>();
            DepartmentList ObjL = null;
            db = new EmployeeDataBaseEntities();
            try
            {
                var Get = (from D in db.DepartmentMasters
                              where D.IsActive==true && D.DepartMentName.Contains(DepartmentName) 
                              select D).ToList();
                if (Get != null)
                {
                    foreach (var item in Get)
                    {
                        ObjL = new DepartmentList();
                        ObjL.DepartmentId = item.DepartMentId;
                        ObjL.DepartmentName = item.DepartMentName;
                        List.Add(ObjL);
                    }
                    ObjCheck.Data = List;
                    ObjCheck.Status = true;
                    ObjCheck.Message = "Success";
                }
                else
                {
                    ObjCheck.Data = null;
                    ObjCheck.Status = false;
                    ObjCheck.Message = "Failure";
                }
            }
            catch (Exception ex)
            {
                ObjCheck.Data = null;
                ObjCheck.Status = false;
                ObjCheck.Message = ex.Message;
            }


            return ObjCheck;
        }
        #endregion

        #region Add Edit Department
        public CheckAddDepartment SetDepartmentDetails(string DepartmentId, string DepartmentName)
        {
            int Result = 0;
            int DeptId = Convert.ToInt32(DepartmentId);
            db=new EmployeeDataBaseEntities();
            CheckAddDepartment ObjCheck= new CheckAddDepartment();
            try
            {
                
                   if (DeptId == 0)
                    {
                        var Newdata = new DepartmentMaster
                        {
                            DepartMentName = DepartmentName,
                            IsActive = true
                        };
                        db.DepartmentMasters.Add(Newdata);
                        Result = db.SaveChanges();

                    }
                    else
                    {
                        var Update = (from d in db.DepartmentMasters
                                      where d.DepartMentId == DeptId
                                      select d).FirstOrDefault();
                        Update.DepartMentName = DepartmentName;
                        Result = db.SaveChanges();

                    }
                
               
                    if (Result > 0)
                    {
                        ObjCheck.DepartmentId = Result.ToString();
                        ObjCheck.Status = true;
                        ObjCheck.Message = "Success";
                    }
                    else
                    {
                        ObjCheck.DepartmentId = "0";
                        ObjCheck.Status = false;
                        ObjCheck.Message = "Failure";
                    }
                
            }
            catch (Exception ex)
            {
                ObjCheck.DepartmentId = "-2";
                ObjCheck.Status = false;
                ObjCheck.Message = ex.Message;
            }
            return ObjCheck;
        }
        #endregion

        #region Delete Department
        public CheckAddDepartment DeleteDepartmentDetails(string DepartmentId)
        {
            int Result = 0;
            int DeptId = Convert.ToInt32(DepartmentId);
            db = new EmployeeDataBaseEntities();
            CheckAddDepartment ObjCheck = new CheckAddDepartment();
            try
            {

                var Deletedata = (from d in db.DepartmentMasters
                                  where d.DepartMentId == DeptId
                                  select d).FirstOrDefault();
                Deletedata.IsActive = false;
               Result= db.SaveChanges();
                ObjCheck.DepartmentId = Result.ToString();
                ObjCheck.Status = true;
                ObjCheck.Message = "Success";
            }
            catch (Exception ex)
            {
                ObjCheck.DepartmentId = "-2";
                ObjCheck.Status = false;
                ObjCheck.Message = ex.Message;
            }
            return ObjCheck;
        }
        #endregion


        #region List Of Attendance
        public CheckAttendanceList GetAttendanceList()
        {
            CheckAttendanceList ObjCheck = new CheckAttendanceList();
            List<AttendanceList>List= new List<AttendanceList>();
            AttendanceList ObjL = null;
            db=new EmployeeDataBaseEntities();
            try
            {
                var Get=(from A in db.Attendances join
                         P in db.PersonalDetails on A.EmployeeId equals P.EmployeeId
                         orderby A.AttendanceId descending
                         where A.IsActive==true  select new { A.AttendanceId
                         , P.FirstName,P.LastName,A.Attendancedate,A.CheckInTime,
                         A.CheckOutTime}).ToList();

                if (Get != null)
                {
                    foreach(var item in Get)
                    {
                        ObjL = new AttendanceList();
                        ObjL.AttendanceId = item.AttendanceId;
                        ObjL.EmployeeName = item.FirstName + " " + item.LastName;
                        ObjL.Attendancedate=item.Attendancedate.ToString();
                        ObjL.CheckInTime =(item.CheckInTime).ToString();
                        ObjL.CheckOutTime =(item.CheckOutTime).ToString();
                        List.Add(ObjL);

                    }
                    ObjCheck.Data = List;
                    ObjCheck.Status=true;
                    ObjCheck.Message = "Success";
                }
                else
                {
                    ObjCheck.Data = null;
                    ObjCheck.Status = false;
                    ObjCheck.Message = "Failure";
                }

            }
            catch (Exception ex)
            {
                ObjCheck.Data = null;
                ObjCheck.Status = false;
                ObjCheck.Message = ex.Message;
            }

            return ObjCheck;

        }
        #endregion

        #region  Search Employee Attendance
        public CheckAttendanceList GetSearchAttendance(string EmployeeId,string AttendanceDate)
        {
            CheckAttendanceList ObjCheck = new CheckAttendanceList();
            List<AttendanceList> List = new List<AttendanceList>();
            AttendanceList ObjL=new AttendanceList();
            db = new EmployeeDataBaseEntities();
            try
            {
                if (EmployeeId != "" && AttendanceDate != "")
                {
                    int EmpId = Convert.ToInt32(EmployeeId);

                    DateTime ADate = Convert.ToDateTime(AttendanceDate);
                    var Search = (from A in db.Attendances
                                  join
                               P in db.PersonalDetails on A.EmployeeId equals P.EmployeeId
                                  where A.IsActive == true && A.EmployeeId == EmpId && A.Attendancedate == ADate
                                  select new
                                  {
                                      A.EmployeeId,
                                      P.FirstName,
                                      P.LastName,
                                      A.Attendancedate,
                                      A.CheckInTime,
                                      A.CheckOutTime,
                                      A.AttendanceId,

                                  }).ToList();
                    if (Search != null)
                    {
                        foreach (var item in Search)
                        {
                            ObjL = new AttendanceList();
                            ObjL.AttendanceId = item.AttendanceId;
                            ObjL.EmployeeId = Convert.ToInt32(item.EmployeeId);
                            ObjL.EmployeeName = item.FirstName + " " + item.LastName;
                            ObjL.Attendancedate = item.Attendancedate.ToString();
                            ObjL.CheckInTime = item.CheckInTime.ToString();
                            ObjL.CheckOutTime = item.CheckOutTime.ToString();
                            List.Add(ObjL);

                        }
                        ObjCheck.Data = List;
                        ObjCheck.Status = true;
                        ObjCheck.Message = "Success";
                    }
                    else
                    {
                        ObjCheck.Data = null;
                        ObjCheck.Status = false;
                        ObjCheck.Message = "Failure";
                    }

                }

               
            }
            catch (Exception ex)
            {
                ObjCheck.Data = null;
                ObjCheck.Status = false;
                ObjCheck.Message = ex.Message;
            }

            return ObjCheck;
        }


        #endregion

        //#region Add Edit Attendance
        // public CheckAddAttendance SetAttendanceDetails(string AtttendanceId,string EmployeeId)
        //{
        //   CheckAddAttendance ObjCheck= new CheckAddAttendance();
        //    int Result = 0;
        //    int AttendId = Convert.ToInt32(AtttendanceId);
        //    int EmpId=Convert.ToInt32(EmployeeId);
        //    db=new EmployeeDataBaseEntities();
        //    try {
        //        if (AttendId == 0)
        //        {
        //            var EmpCheck = (from P in db.PersonalDetails where P.EmployeeId == EmpId select P).FirstOrDefault();

        //            if (EmpCheck != null)
        //            {

        //                //TimeSpan.TryParse(txtCheckInTime.Text, out TimeSpan parsedInTime);
        //                //TimeSpan.TryParse(txtCheckOutTime.Text, out TimeSpan parsedOutTime);

        //                var SetAttendance = new Attendance
        //                {
        //                    EmployeeId = EmpId,
        //                    //Attendancedate = Convert.ToDateTime(txtDate.Text),
        //                    //CheckInTime = parsedInTime,
        //                    //CheckOutTime = parsedOutTime,
        //                    IsActive = true
        //                };
        //                db.Attendances.Add(SetAttendance);
        //                Result = db.SaveChanges();
        //            }


        //        }
        //        else
        //        {
        //            var EmpCheck = (from P in db.PersonalDetails where P.EmployeeId == EmpId select P).FirstOrDefault();

        //            if (EmpCheck != null)
        //            {
        //                //TimeSpan.TryParse(txtCheckInTime.Text, out TimeSpan parsedInTime);
        //                //TimeSpan.TryParse(txtCheckOutTime.Text, out TimeSpan parsedOutTime);
        //                var Edit = (from A in db.Attendances
        //                            where A.AttendanceId == AttendId
        //                            select A).FirstOrDefault();
        //                Edit.EmployeeId = EmpId;

        //                Result = db.SaveChanges();
        //            }
        //        }
        //        if (Result > 0)
        //        {
        //            ObjCheck.AttendanceId = Result.ToString();
        //            ObjCheck.Status = true;
        //            ObjCheck.Message = "Success";
        //        }
        //        else
        //        {
        //            ObjCheck.AttendanceId = "0";
        //            ObjCheck.Status = false;
        //            ObjCheck.Message = "Failure";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ObjCheck.AttendanceId = "-2";
        //        ObjCheck.Status = false;
        //        ObjCheck.Message = ex.Message;
        //    }
        //    return ObjCheck;

        //}
        //#endregion

        #region Delete Attendance
        public CheckAddAttendance DeleteAttendance(string AttendanceId)
        {
            CheckAddAttendance ObjCheck= new CheckAddAttendance();
            int Result = 0;
            int AttendId = Convert.ToInt32(AttendanceId);
            db = new EmployeeDataBaseEntities();
            try
            {

                var Delete = (from A in db.Attendances where A.AttendanceId == AttendId select A).FirstOrDefault();
                Delete.IsActive = false;
                Result=db.SaveChanges();
                ObjCheck.AttendanceId= Result.ToString();
                ObjCheck.Status = true;
                ObjCheck.Message = "Success";
            }
            catch (Exception ex)
            {
                ObjCheck.AttendanceId = "-2";
                ObjCheck.Status = false;
                ObjCheck.Message = ex.Message;
            }
            return ObjCheck;
        }

        #endregion

    }
}
