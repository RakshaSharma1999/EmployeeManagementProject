using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EmployeeManagementProject.BAL_Class
{

    // Models
    public class CommonModelClass
    {
    }
    public class ImagePathList
    {
        public string imageurl;


    }

    public class FileUploadResponselistImage
    {

        public List<ImagePathList> data;
        public string status { get; set; }

    }

    //Add Delete Edit Employee
    public class CheckAddandDeleteEmployee
    {
        public string EmployeeId { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
    // Show List Of Employee
    public class EmployeeList
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }  
        public string BloodgroupName { get; set; }
        public string DepartmentName { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string HomeAddress { get; set; }
    }
    // Check Employee List
    public class CheckEmployeeList
    {
        public List<EmployeeList> Data { get; set; }    
        public bool Status { get; set; }
        public string Message { get; set; }
    }
    //Show DepartMent List
    public class DepartmentList { 
    
        public int DepartmentId { get; set; }   
        public string DepartmentName { get; set; }

    }
    // Check Department List 
    public class CheckDepartmentList {
        public List<DepartmentList> Data { get;set; }
        public bool Status { get; set; }
        public string Message { get; set; } 
    
    }
    // Add Edit Delete Department
    public class CheckAddDepartment
    {
        public string DepartmentId { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }

    // Show Attendance List
    public class AttendanceList
    {
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } 

        public string Attendancedate { get; set; }    

        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set;}

    }
    // Check Attendance List
    public class CheckAttendanceList
    {
        public List<AttendanceList> Data { get; set;}
        public bool Status { get; set; }
        public string Message { get; set; } 
    }
    // Add Edit Delete Attendance 
    public class CheckAddAttendance
    {
        public string AttendanceId { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}