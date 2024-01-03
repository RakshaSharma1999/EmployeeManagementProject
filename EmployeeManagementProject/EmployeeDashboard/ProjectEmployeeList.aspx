<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="ProjectEmployeeList.aspx.cs" Inherits="EmployeeManagementProject.EmployeeDashboard.ProjectEmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <asp:Panel ID="ListPanel" Visible="true" runat="server">
                    <div class="row">
                        <!-- left column -->
                        <div class="col-md-12">

                            <!-- Horizontal Form -->
                            <div class="card card-info">
                                <div class="card-header">
                                    <h3 class="card-title">Task List</h3>
                                </div>
                                <!-- /.card-header -->
                                <!-- form start -->

                                <div class="card-body">
                                    <div class="form-group row">

                                        <div class="col-sm-5">
                                            <asp:TextBox ID="txtSearch" TextMode="Search" runat="server" class="form-control" placeholder="Search ProjectName / Status"></asp:TextBox>
                                        </div>

                                        <div class="col-sm-2">
                                            <asp:Button ID="btnSearch" class="btn btn-block bg-gradient-info" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button ID="btnClear" class="btn btn-block bg-gradient-success" runat="server" Text="Clear" OnClick="btnClear_Click" />
                                        </div>



                                    </div>

                                </div>

                                <!-- /.card-body -->



                                <div class="row">

                                    <div class="col-md-12">
                                        <asp:GridView ID="GridViewProject" AutoGenerateColumns="false" OnRowCommand="GridViewProject_RowCommand" runat="server" class="table table-bordered table-striped dataTable dtr-inline text-center" AllowPaging="true" OnPageIndexChanging="GridViewProject_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Employee Id">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmployeeId" runat="server" Text='<%# Eval("EmployeeId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Eval("FirstName")+" "+Eval("LastName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Project Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("ProjectName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Task Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTaskName" runat="server" Text='<%# Eval("TaskName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Start Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStartDate" runat="server" Text='<%# Eval("StartDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="End Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("EndDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("StatusName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Actions">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnAction" CommandName="Action" CommandArgument='<%# Eval("TaskId") %>' class="btn btn-block bg-gradient-danger" runat="server" Text="Action" />

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


                <asp:Panel ID="ViewPanel" Visible="false" runat="server">
                    <div class="row">
                        <!-- left column -->
                        <div class="col-md-12">

                            <!-- Horizontal Form -->
                            <div class="card card-info">
                                <div class="card-header">
                                    <h3 class="card-title">Project Details</h3>
                                </div>
                                <!-- /.card-header -->
                                <!-- form start -->

                                <div class="card-body">
                                    <div class="row text-center">



                                        <div class="col-md-12 text-justify">
                                            <label for="lblEmployeeId">Employee Id : </label>
                                            <asp:Label ID="lblEmployeeId" runat="server" Text=""></asp:Label>
                                            <br />
                                            <label for="lblEmployeeName">Employee Name : </label>
                                            <asp:Label ID="lblEmployeeName" runat="server" Text=""></asp:Label>
                                            <br />

                                            <label for="lblProjectName">Project Name : </label>
                                            <asp:Label ID="lblProjectName" runat="server" Text=""></asp:Label>
                                            <br />

                                            <label for="lblTaskName">Task Name : </label>
                                            <asp:Label ID="lblTaskName" runat="server" Text=""></asp:Label>
                                            <br />

                                            <label for="lblStartDate">Start Date :</label>
                                            <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label><br />

                                            <label for="lblEndDate">End Date :</label>
                                            <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label><br />

                                            <label for="lblDescription">Description :</label>
                                            <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label><br />

                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label for="lblStatus">Status :</label>
                                                        <asp:DropDownList ID="ddlStatus" class="form-control" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="card-footer">
                                            <asp:Button ID="btnSubmit" class="btn bg-gradient-info btn-lg" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                            <asp:Button ID="btnBack" class="btn  bg-gradient-success btn-lg" runat="server" Text="Back" OnClick="btnBack_Click" />
                                        </div>

                                        <!-- /.card -->


                                    </div>
                                </div>
                                <!-- /.card-body -->





                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content -->
    </div>
</asp:Content>
