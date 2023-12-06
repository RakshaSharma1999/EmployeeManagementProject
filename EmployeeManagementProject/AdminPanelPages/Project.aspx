<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="EmployeeManagementProject.AdminPanelPages.Project" %>
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
                <div class="row">
                    <div class="col-md-12">
                         <div class="card card-info">
                              <div class="card-header">
                                    <h3 class="card-title">Project Add</h3>
                                </div>
                              <div class="card-body">
                                   <div class="row">
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="txtProjectName">Project Name</label>
                                                <asp:TextBox ID="txtProjectName" class="form-control" runat="server"></asp:TextBox>

                                                </div>
                                           
                                             </div>
                                   <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="ddlStatus">Status</label>
                                                <asp:DropDownList ID="ddlStatus" AutoPostBack="true" class="form-control" runat="server"></asp:DropDownList>

                                                </div>
                                            
                                       </div>
                                       </div>

                                  <div class="row">
                                           <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="txtStartDate">Start Date</label>
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
                                       <div class="col-md-12">
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
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
</asp:Content>
