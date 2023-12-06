<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AttendanceView.aspx.cs" Inherits="EmployeeManagementProject.AttendanceView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                    </div>
                    <!-- /.col -->
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">EmployeeView</li>
                        </ol>
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content-header -->

        <!-- Main content -->
        <div class="content">
            <div class="container-fluid">

                <asp:Panel ID="ListPanel" runat="server">
                    <div class="row">
                        <!-- left column -->
                        <div class="col-md-12">

                            <!-- Horizontal Form -->
                            <div class="card card-info">
                                <div class="card-header">
                                    <h3 class="card-title">Employees List</h3>
                                </div>
                                <!-- /.card-header -->
                                <!-- form start -->

                                <div class="card-body">
                                    <div class="form-group row">

                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtSearch" TextMode="Search" runat="server" class="form-control" placeholder="Search Employee Id"></asp:TextBox>
                                        </div>

                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtSearchDate" TextMode="Date" runat="server" class="form-control"></asp:TextBox>

                                        </div>

                                        <div class="col-sm-1">
                                            <asp:Button ID="btnSearch" class="btn btn-block bg-gradient-info" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                        </div>
                                        <div class="col-sm-1">
                                            <asp:Button ID="btnClear" class="btn btn-block bg-gradient-success" runat="server" Text="Clear" OnClick="btnClear_Click" />
                                        </div>

                                    </div>

                                </div>

                                <!-- /.card-body -->



                                <div class="row">

                                    <div class="col-md-12">
                                        <asp:GridView ID="GridViewEmployee" AutoGenerateColumns="false" OnRowCommand="GridViewEmployee_RowCommand" runat="server" class="table table-bordered table-striped dataTable dtr-inline text-center" AllowPaging="true" OnPageIndexChanging="GridViewEmployee_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="EmployeeId">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpId" runat="server" Text='<%# Eval("EmployeeId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Employee Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("FirstName") + " " + Eval("LastName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Attendance Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAttendanceDate" runat="server" Text='<%# Eval("Attendancedate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CheckInTime">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCheckInTime" runat="server" Text='<%# Eval("CheckInTime") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="CheckOutTime">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCheckOutTime" runat="server" Text='<%# Eval("CheckOutTime") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Actions">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="EditEmployeeAttendance" CommandArgument='<%# Eval("AttendanceId") %>'><i class="fas fa-solid fa-marker"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteEmployeeAttendance" CommandArgument='<%# Eval("AttendanceId")%>'><i class="fas fa-solid fa-trash"></i></asp:LinkButton>


                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                            </Columns>

                                        </asp:GridView>

                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </asp:Panel>



                <asp:Panel ID="EditPanel" Visible="false" runat="server">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="card card-info">
                                <div class="card-header">
                                    <h3 class="card-title">Employee Attendance Edit</h3>
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
                                                <asp:TextBox ID="txtCheckInTime" class="form-control" runat="server" TextMode="Time"></asp:TextBox>

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
                                    <asp:Button ID="btnClose" runat="server" Text="Close" class="btn  bg-gradient-success btn-lg" OnClick="btnClose_Click" />
                                </div>
                            </div>
                        </div>
                    </div>


                </asp:Panel>

            </div>
        </div>
    </div>
</asp:Content>
