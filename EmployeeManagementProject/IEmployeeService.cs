using EmployeeManagementProject.BAL_Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace EmployeeManagementProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeService" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        void DoWork();

        #region Upload Multiple Photos
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UploadMultiplePhotos_New", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        FileUploadResponselistImage UploadMultiplePhotos_New(Stream stream);
        #endregion

        #region Add and Update Employee Details
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "SetEmployee", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckAddandDeleteEmployee SetEmployee(int EmpId, string FirstName, string LastName,string Gender, int BloodGroupId, int RoleId, int DepartmentId, string MobileNo, string EmailId, int StateId, int CityId, string HomeAddress);
        #endregion

        #region Employee List
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetEmployee", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckEmployeeList GetEmployee();
        #endregion

        #region Delete Employee Details
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteEmployeeDetails", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckAddandDeleteEmployee DeleteEmployeeDetails(int EmpId);
        #endregion

        #region Employee Search List
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "SearchEmplyee/{FirstName}/{LastName}/{MobileNo}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckEmployeeList SearchEmplyee(string FirstName, string LastName, string MobileNo);
        #endregion

        #region Department List
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetDepartmentList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckDepartmentList GetDepartmentList();
        #endregion

        #region Department Search List
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetSearchDepartmentList/{DepartmentName}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckDepartmentList GetSearchDepartmentList(string DepartmentName);
        #endregion

        #region Add and Update Department
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "SetDepartmentDetails", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckAddDepartment SetDepartmentDetails(string DepartmentId, string DepartmentName);
        #endregion

        #region Delete Employee Details
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteDepartmentDetails", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckAddDepartment DeleteDepartmentDetails(string DepartmentId);
        #endregion

        #region Attendance List
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetAttendanceList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckAttendanceList GetAttendanceList();
        #endregion

        #region Department Search List
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetSearchAttendance/{EmployeeId}/{AttendanceDate}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckAttendanceList GetSearchAttendance(string EmployeeId,string AttendanceDate);
        #endregion

        //#region Add and Update Attendance
        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "SetAttendanceDetails", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //CheckAddAttendance SetAttendanceDetails(string AtttendanceId, string EmployeeId);
        //#endregion

        #region Delete Employee Details
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteAttendance", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckAddAttendance DeleteAttendance(string AttendanceId);
        #endregion
    }
}
