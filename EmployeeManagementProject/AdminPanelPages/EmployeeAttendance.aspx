<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EmployeeAttendance.aspx.cs" Inherits="EmployeeManagementProject.AdminPanelPages.EmployeeAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                  
                
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content-header -->

        <!-- Main content -->
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-12">
                         <div class="card card-info">
                              <div class="card-header">
                                    <h3 class="card-title">Employee Attendance</h3>
                                </div>
                              <div class="card-body">
                                   <div class="row">
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="txtEmployeeId">Employee ID</label>
                                                <asp:TextBox ID="txtEmployeeId" class="form-control" runat="server"></asp:TextBox>

                                                </div>
                                           
                                             </div>
                                       <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="txtDate">Date</label>
                                                <asp:TextBox ID="txtDate" class="form-control" runat="server" TextMode="Date"></asp:TextBox>

                                                </div>
                                            
                                       </div>
                                       </div>

                                  <div class="row">
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="txtCheckInTime">Check-In Time</label>
                                                <asp:TextBox ID="txtCheckInTime" class="form-control" runat="server" TextMode="Time" ></asp:TextBox>

                                                </div>
                                         
                                             </div>
                                      </div>
                                      <div class="row">
                                       <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="txtCheckOutTime">Check-Out Time</label>
                                                <asp:TextBox ID="txtCheckOutTime" class="form-control" runat="server" TextMode="Time"></asp:TextBox>

                                                </div>
                                            
                                       </div>
                                      </div>
                                  </div>

                             <div class="card-footer">

                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn bg-gradient-info btn-lg" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnClose" runat="server" Text="Close" class="btn  bg-gradient-success btn-lg" OnClick="btnClose_Click"/>
                                </div>
                             </div>
                    </div>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
</asp:Content>
