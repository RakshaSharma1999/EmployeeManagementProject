<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EmployeeTask.aspx.cs" Inherits="EmployeeManagementProject.AdminPanelPages.EmployeeTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                  
                    <!-- /.col -->
                   
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
                 <asp:Panel ID="AddPanel" Visible="false" runat="server">
                <div class="row">
                    <div class="col-md-12">
                         <div class="card card-info">
                              <div class="card-header">
                                    <h3 class="card-title">Employee Task</h3>
                                </div>
                              <div class="card-body">
                                   <div class="row">
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="ddlProjectName">Project Name</label>
                                                <asp:DropDownList ID="ddlProjectName" class="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>

                                                </div>
                                           
                                             </div>
                                       <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="txtEmployeeId">Employee Id</label>
                                                <asp:TextBox ID="txtEmployeeId" class="form-control" runat="server"></asp:TextBox>

                                                </div>
                                            
                                       </div>
                                       </div>

                                  <div class="row">
                                      <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="txtStartDate">StartDate</label>
                                                <asp:TextBox ID="txtStartDate" class="form-control" runat="server" TextMode="Date"></asp:TextBox>

                                                </div>
                                            
                                       </div>
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="txtEndDate">End Date</label>
                                                <asp:TextBox ID="txtEndDate" class="form-control" runat="server" TextMode="Date" ></asp:TextBox>

                                                </div>
                                         
                                             </div>
                                             
                                      </div>
                                      <div class="row">
                                            <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="ddlStatus">Status</label>
                                                <asp:DropDownList ID="ddlStatus" AutoPostBack="true" class="form-control" runat="server"></asp:DropDownList>

                                                </div>
                                            
                                       </div>
                                      <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="txtDescription">Description</label>
                                                <asp:TextBox ID="txtDescription" class="form-control" TextMode="MultiLine" runat="server" ></asp:TextBox>

                                                </div>
                                            
                                       </div>
                                         
                                      </div>
                                  </div>

                             <div class="card-footer">

                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn bg-gradient-info btn-lg" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn  bg-gradient-success btn-lg" OnClick="btnCancel_Click"/>
                                </div>
                             </div>
                    </div>
                </div>
                     </asp:Panel>

                <asp:Panel ID="ListPanel" runat="server">
                    <div class="row">
                        <!-- left column -->
                        <div class="col-md-12">

                            <!-- Horizontal Form -->
                            <div class="card card-info">
                                <div class="card-header">
                                    <h3 class="card-title">Project List</h3>
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

                                         <div class="col-sm-2">
                                            <asp:Button ID="btnAddNew" class="btn btn-block bg-gradient-danger" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
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
                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="EditEmployeeTask" CommandArgument='<%# Eval("TaskId") %>'><i class="fas fa-solid fa-marker"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteEmployeeTask" CommandArgument='<%# Eval("TaskId")%>'><i class="fas fa-solid fa-trash"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="btnView" runat="server" CommandName="ViewEmployeeTask" CommandArgument='<%# Eval("TaskId") %>'><i class="fas fa-solid fa-eye"></i></asp:LinkButton>

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
                                                <asp:Label ID="lblEmployeeId" runat="server" Text=""></asp:Label> <br/>
                                            <label for="lblEmployeeName">Employee Name : </label>
                                                <asp:Label ID="lblEmployeeName" runat="server" Text=""></asp:Label> <br/>

                                            <label for="lblProjectName">Project Name : </label>
                                                <asp:Label ID="lblProjectName" runat="server" Text=""></asp:Label> <br/>

                                             <label for="lblStatus">Status :</label>
                                            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblStartDate">Start Date :</label>
                                            <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblEndDate">End Date :</label>
                                            <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblDescription">Description :</label>
                                            <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label><br/>

                                        </div>

                                        <div class="card-footer">
                                            <asp:Button ID="btnback" class="btn btn-primary" runat="server" Text="Back" OnClick="btnback_Click" />
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
    <!-- /.content-wrapper -->
</asp:Content>
