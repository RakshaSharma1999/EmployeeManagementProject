using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementProject.BAL_Class;

namespace EmployeeManagementProject.AdminPanelPages
{
    public partial class EmployeeAttendance : System.Web.UI.Page
    {
        EmployeeDataBaseEntities db;
        General ObjG = new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddEmployeeAttendanceRow(true);
            }
        }

       

                    protected void GridAddAttendance_RowDataBound(object sender, GridViewRowEventArgs e)
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            try
                            {
                                Label lblEmpId = e.Row.FindControl("lblEmpId") as Label;
                                TextBox txtEmpId = e.Row.FindControl("txtEmployeeId") as TextBox;
                                Label lblAttendanceDate = e.Row.FindControl("lblAttendanceDate") as Label;
                                TextBox txtDate = e.Row.FindControl("txtDate") as TextBox;
                                Label lblCheckInTime = e.Row.FindControl("lblCheckInTime") as Label;
                                TextBox txtCheckInTime = e.Row.FindControl("txtCheckInTime") as TextBox;
                                Label lblCheckOutTime = e.Row.FindControl("lblCheckOutTime") as Label;
                                TextBox txtCheckOutTime = e.Row.FindControl("txtCheckOutTime") as TextBox;

                                txtEmpId.Text = lblEmpId.Text;
                                txtDate.Text = Convert.ToDateTime(lblAttendanceDate.Text).ToString("yyyy-MM-dd");
                                txtCheckInTime.Text = lblCheckInTime.Text;
                                txtCheckOutTime.Text = lblCheckOutTime.Text;

                                //ddlDays.SelectedItem.Text = lblDays.Text;
                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }
                        }
                    }

                    protected void txtEmployeeId_TextChanged(object sender, EventArgs e)
                    {


                    }

                    protected void ButtonAdd_Click(object sender, EventArgs e)
                    {
                        AddEmployeeAttendanceRow(true);
                    }

                    private void AddEmployeeAttendanceRow(bool AddBlankRow)
                    {
                        try
                        {

                            string hdnWOEmployeeID = "";
                            string hdnDateID = "";
                            string hdnCheckInID = "";
                            string hdnCheckOutID = "";

                            List<AttendanceModelList> ObjED = new List<AttendanceModelList>();

                            foreach (GridViewRow item in GridAddAttendance.Rows)
                            {


                                hdnWOEmployeeID = ((HiddenField)item.FindControl("hdnWOEmployeeID")).Value;
                                hdnDateID = ((HiddenField)item.FindControl("hdnDateID")).Value;
                                hdnCheckInID = ((HiddenField)item.FindControl("hdnCheckInID")).Value;
                                hdnCheckOutID = ((HiddenField)item.FindControl("hdnCheckOutID")).Value;


                                TextBox txtEmployeeId = (TextBox)item.FindControl("txtEmployeeId");
                                TextBox txtDate = (TextBox)item.FindControl("txtDate");
                                TextBox txtCheckInTime = (TextBox)item.FindControl("txtCheckInTime");
                                TextBox txtCheckOutTime = (TextBox)item.FindControl("txtCheckOutTime");

                                // Label lblEmployeeId = (Label)item.FindControl("lblEmployeeId");




                                AddEmployeeAttendance(ref ObjED, Convert.ToInt32(hdnWOEmployeeID), txtEmployeeId.Text, Convert.ToInt32(hdnDateID), Convert.ToInt32(hdnCheckInID), Convert.ToInt32(hdnCheckOutID), Convert.ToDateTime(txtDate.Text), txtCheckInTime.Text, txtCheckOutTime.Text);
                            }
                            if (AddBlankRow)
                                AddEmployeeAttendance(ref ObjED, 1, "0", 1, 1, 1, DateTime.Now, null, null);


                            GridAddAttendance.DataSource = ObjED;
                            GridAddAttendance.DataBind();
                            // ViewState["Data"] = ObjED;
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    private void AddEmployeeAttendance(ref List<AttendanceModelList> objEA, int ID, string EmployeeId, int DateID, int CheckInID, int CheckOutID, DateTime Date, string CheckInTime, string CheckOutTime)
                    {
                        TimeSpan.TryParse(CheckInTime, out TimeSpan parsedInTime);
                        TimeSpan.TryParse(CheckOutTime, out TimeSpan parsedOutTime);

                        AttendanceModelList objA = new AttendanceModelList();
                        objA.ID = ID;
                        objA.DateID = DateID;
                        objA.CheckInID = CheckInID;
                        objA.CheckOutID = CheckOutID;
                        objA.RowNumber = objEA.Count + 1;
                        objA.EmployeeId = Convert.ToInt32(EmployeeId);
                        objA.Attendancedate = Convert.ToDateTime(Date);
                        objA.CheckInTime = parsedInTime;
                        objA.CheckOutTime = parsedOutTime;

                        objEA.Add(objA);
                        // ViewState["ojbpro"] = objGP;
                    }

        protected void btnPresent_Click(object sender, EventArgs e)
        {
     db= new EmployeeDataBaseEntities();
            try
            {
                int _isInserted = -1;
                int SelectedItems = 0;
                foreach (GridViewRow row in GridAddAttendance.Rows)
                {

                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        Label lblEmployeeId = (row.Cells[0].FindControl("lblEmployeeId") as Label);
                        TextBox txtEmployeeName = (row.Cells[0].FindControl("txtEmployeeName") as TextBox);
                        DropDownList ddlCountry = (row.Cells[0].FindControl("ddlCountry") as DropDownList);
                        DropDownList ddlState = (row.Cells[0].FindControl("ddlState") as DropDownList);
                        DropDownList ddlCity = (row.Cells[0].FindControl("ddlCity") as DropDownList);

                        Label lblEmpId = (row.Cells[0].FindControl("lblEmployeeId") as Label);
                        TextBox txtEmpId = (row.Cells[0].FindControl("txtEmployeeId") as TextBox);
                        Label lblAttendanceDate = (row.Cells[0].FindControl("lblAttendanceDate") as Label);
                        TextBox txtDate = (row.Cells[0].FindControl("txtDate") as TextBox);
                        Label lblCheckInTime = (row.Cells[0].FindControl("lblCheckInTime") as Label);
                        TextBox txtCheckInTime = (row.Cells[0].FindControl("txtCheckInTime") as TextBox);
                        Label lblCheckOutTime = (row.Cells[0].FindControl("lblCheckOutTime") as Label);
                        TextBox txtCheckOutTime = (row.Cells[0].FindControl("txtCheckOutTime") as TextBox);

                        TimeSpan.TryParse(txtCheckInTime.Text, out TimeSpan parsedInTime);
                        TimeSpan.TryParse(txtCheckOutTime.Text, out TimeSpan parsedOutTime);

                        var SetAttendance = new Attendance
                        {
                            EmployeeId = Convert.ToInt32(txtEmpId.Text),
                            Attendancedate = Convert.ToDateTime(txtDate.Text),
                            CheckInTime = parsedInTime,
                            CheckOutTime = parsedOutTime,
                            AttendanceStatus="Present",
                            IsActive = true
                        };
                        db.Attendances.Add(SetAttendance);
                        _isInserted= db.SaveChanges();

                       
                        SelectedItems++;
                    }
                }
                if (_isInserted == -1)
                {


                    ObjG.ShowMessage(this, "Failed to Add Attendance.");

                }
                else
                {
                    string message = "Today Present Employee";
                    string url = "EmployeeAttendance.aspx";

                    ObjG.ShowMessageAndRedirect(this, message, url);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }
        }