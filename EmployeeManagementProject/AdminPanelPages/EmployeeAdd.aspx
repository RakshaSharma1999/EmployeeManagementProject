<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EmployeeAdd.aspx.cs" Inherits="EmployeeManagementProject.AdminPanelPages.EmployeeAdd" %>
<%@ MasterType VirtualPath="~/Admin.Master" %>
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
                  
                  
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content-header -->

        <!-- Main content -->
        <div class="content">
            <div class="container-fluid">
               


                <asp:Panel ID="AddPanel"  runat="server">
                    <div class="row">
                        <div class="col-md-12">
                            <!-- general form elements -->
                            <div class="card card-info">
                                <div class="card-header">
                                    <h3 class="card-title">Add Employee</h3>
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
                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server"
                                                ControlToValidate="txtFirstName" ForeColor="Red" ErrorMessage="Please Enter Your First Name."
                                                SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtLastName">Last Name</label>

                                                <asp:TextBox ID="txtLastName" runat="server" class="form-control" placeholder="Enter Last Name"></asp:TextBox>
                                            </div>
                                          <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server"
                                                ControlToValidate="txtLastName" ForeColor="Red" ErrorMessage="Please Enter Your Last Name."
                                                SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
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
                                                <label for="ddlRole">Role</label>

                                                <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
                                            </div>
                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorRole" runat="server"
                                                ControlToValidate="ddlRole" ForeColor="Red" ErrorMessage="Please Select Role."
                                                SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="ddlDepartment">Department</label>
                                                <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
                                            </div>
                                         <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidatorDepartment" runat="server"
                                                ControlToValidate="ddlDepartment" ForeColor="Red" ErrorMessage="Please Select Department."
                                                SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="ProfileUpload">Photo</label>

                                                <asp:FileUpload ID="ProfileUpload" runat="server" />
                                                 <asp:Button ID="btnFileUpload" class="btn  btn-secondary btn-sm" runat="server" Text="Upload" OnClick="btnFileUpload_Click"/>
                                                <asp:Image ID="ImageProfile" Width="30%" runat="server" />
                                                  <asp:Label ID="lblFilePath" runat="server" Text="" Visible="false"></asp:Label>
                                            </div>
                                      <%--      <asp:RequiredFieldValidator ID="RequiredFieldValidatorProfileUpload" runat="server"
                                                ControlToValidate="ProfileUpload" ForeColor="Red" ErrorMessage="Please Choose Your Profile Image."
                                                SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                        </div>

                                    </div>

                                </div>
                                <!-- /.card-body -->

                                <div class="card-footer">

                                    <asp:Button ID="btnNext" runat="server" Text="Next" class="btn bg-gradient-info btn-lg" OnClick="btnNext_Click" />
                                  
                                </div>

                            </div>
                            <!-- /.card -->



                        </div>
                    </div>
                    <!-- /.row -->
                </asp:Panel>


                <asp:Panel ID="ContactPanel" Visible="false" runat="server">
                    <div class="row">
                        <div class="col-md-12">
                            <!-- general form elements -->
                            <div class="card card-info">
                                <div class="card-header">
                                    <h3 class="card-title">Add Employee Contact Details</h3>
                                </div>
                                <!-- /.card-header -->
                                <!-- form start -->

                                <div class="card-body">

                                    <div class="row">
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
                                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorMobileNo" runat="server"
                                                ControlToValidate="txtMobileNo" ForeColor="Red" ErrorMessage="Please Enter Your Mobile Number."
                                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorMobileNo" runat="server"
                                                ControlToValidate="txtMobileNo" ErrorMessage="Pls enter only numeric value."
                                                SetFocusOnError="True" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>--%>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtEmailid">Email ID</label>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtEmailid" class="form-control" placeholder="Enter Email ID" TextMode="Email" runat="server"></asp:TextBox>

                                                    <div class="input-group-append">
                                                        <div class="input-group-text">
                                                            <span class="fas fa-envelope"></span>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                          <%--  <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator" runat="server"
                                                ControlToValidate="txtEmailid" ForeColor="Red" ErrorMessage="Invalid Email."
                                                SetFocusOnError="True"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server"
                                                ControlToValidate="txtEmailid" ForeColor="Red" ErrorMessage=" Please Enter EmailId ."
                                                SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="ddlState">State</label>

                                                <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                          <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidatorState" runat="server"
                                                ControlToValidate="ddlState" ForeColor="Red" ErrorMessage="Please Select State."
                                                SetFocusOnError="True"></asp:RequiredFieldValidator> --%>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="ddlCity">City</label>

                                                <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
                                            </div>
                                             <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorCity" runat="server"
                                                ControlToValidate="ddlCity" ForeColor="Red" ErrorMessage="Please Select City."
                                                SetFocusOnError="True"></asp:RequiredFieldValidator> --%>
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
                                    <asp:Button ID="btnPreviousdetails" class="btn  bg-gradient-success btn-lg" CausesValidation="False" runat="server" Text="Previous" OnClick="btnPreviousdetails_Click" />
                                  <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </div>

                            </div>
                            <!-- /.card -->



                        </div>
                    </div>
                    <!-- /.row -->
                </asp:Panel>


        

            </div>


        </div>
    </div>
       
</asp:Content>
