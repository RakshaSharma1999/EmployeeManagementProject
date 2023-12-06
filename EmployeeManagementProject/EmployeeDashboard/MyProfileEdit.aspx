<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="MyProfileEdit.aspx.cs" Inherits="EmployeeManagementProject.EmployeeDashboard.MyProfileEdit" %>
<%@ MasterType VirtualPath="~/UserMaster.Master" %>
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
                      <div class="row">
                        <div class="col-md-12">
                            <!-- general form elements -->
                            <div class="card card-info">
                                <div class="card-header">
                                    <h3 class="card-title">Edit Employee Details</h3>
                                </div>
                                <!-- /.card-header -->
                                <!-- form start -->

                                <div class="card-body">


                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtFirstName">First Name</label>

                                                <asp:TextBox ID="txtFirstName" runat="server" class="form-control" placeholder="Enter First Name"></asp:TextBox>

                                            </div>
                                     
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtLastName">Last Name</label>

                                                <asp:TextBox ID="txtLastName" runat="server" class="form-control" placeholder="Enter Last Name"></asp:TextBox>
                                            </div>
                                      
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtDateofBirth">Date Of Birth</label>

                                                <asp:TextBox ID="txtDateofBirth" runat="server" class="form-control" TextMode="Date"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="RadioButtonGender">Gender</label>
                                                <asp:RadioButtonList ID="RadioButtonGender" runat="server">
                                                    <asp:ListItem Text="Male" Value="Male"> </asp:ListItem>
                                                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                                </asp:RadioButtonList>
                                               
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="ddlBloodgroup">BloodGroup</label>
                                                <asp:DropDownList ID="ddlBloodgroup" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
                                            </div>
                                        </div>

                                      <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="ddlDepartment">Department</label>
                                                <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
                                            </div>
                                       
                                        </div>

                                    </div>

                                    <div class="row">
                                       

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="ProfileUpload">Photo</label>

                                                <asp:FileUpload ID="ProfileUpload" runat="server" />
                                                 <asp:Button ID="btnFileUpload" class="btn  btn-secondary btn-sm" runat="server" Text="Upload" OnClick="btnFileUpload_Click"/>
                                                <asp:Image ID="ImageProfile" Width="30%" runat="server" />
                                                  <asp:Label ID="lblFilePath" runat="server" Text="" Visible="false"></asp:Label>
                                            </div>
                                  
                                        </div>

                                            <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtMobileNo">Mobile Number</label>
                                                <div class="input-group ">
                                                    <asp:TextBox ID="txtMobileNo" class="form-control" placeholder="Enter Mobile Number" runat="server" TextMode="Phone" MaxLength="10"></asp:TextBox>

                                                    <div class="input-group-append" color="#CCCCFF">
                                                        <span class="input-group-text">
                                                            <i class="fas fa-phone"></i></span>
                                                    </div>
                                                </div>


                                            </div>
                                      
                                        </div>

                                    </div>

                                 

                                      <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="ddlState">State</label>

                                                <asp:DropDownList ID="ddlEditState" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlEditState_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                    
                                        </div>

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="ddlCity">City</label>

                                                <asp:DropDownList ID="ddlEditCity" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
                                            </div>
                                          
                                        </div>

                                    </div>
                                      <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label for="txtAddress">Address</label>
                                                <asp:TextBox ID="txtAddress" class="form-control" runat="server" TextMode="MultiLine" ></asp:TextBox>
                                            </div>
                                         
                                        </div>

                                      

                                    </div>
                                </div>
                                <!-- /.card-body -->

                                <div class="card-footer">
                                     
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn bg-gradient-info btn-lg" OnClick="btnSubmit_Click" />
                                  
                                </div>

                            </div>
                        </div>
                    </div>
            </div>
        </div>
    </div>
</asp:Content>
