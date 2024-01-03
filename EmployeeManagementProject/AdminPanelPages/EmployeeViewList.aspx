<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EmployeeViewList.aspx.cs" Inherits="EmployeeManagementProject.AdminPanelPages.EmployeeViewList" %>
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
                                            <asp:TextBox ID="txtSearch" TextMode="Search" runat="server" class="form-control" placeholder="Search"></asp:TextBox>
                                        </div>

                                        <div class="col-sm-3">

                                    <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" class="form-control"></asp:DropDownList>

                                </div>
                                <div class="col-sm-3">

                                    <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" class="form-control"></asp:DropDownList>

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

                                                <asp:TemplateField HeaderText="Photo">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image" class="img-circle elevation-2" runat="server" Height="50px" Width="50px" ImageUrl='<%# "~/ProfileImages/" + Eval("ProfileImage") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("FirstName") + " " + Eval("LastName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mobile">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("MobileNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="EmailId">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("EmailId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Department">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDepartMentName" runat="server" Text='<%# Eval("DepartMentName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Actions">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="EditEmployeeDetails" CommandArgument='<%# Eval("EmployeeId") %>'><i class="fas fa-solid fa-marker"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteEmployeeDetails" CommandArgument='<%# Eval("EmployeeId")%>'><i class="fas fa-solid fa-trash"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="btnView" runat="server" CommandName="ViewEmployeeDetails" CommandArgument='<%# Eval("EmployeeId") %>'><i class="fas fa-solid fa-eye"></i></asp:LinkButton>

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
                                    <h3 class="card-title">Employee Details</h3>
                                </div>
                                <!-- /.card-header -->
                                <!-- form start -->

                                <div class="card-body">
                                    <div class="row text-center">
                                        <div class="col-md-6" >

                                            <asp:Image ID="ProfileImage" Width="50%" runat="server" />


                                        </div>


                                        <div class="col-md-6 text-justify">

                                            <label for="lblFullName" >Name : </label>
                                                <asp:Label ID="lblFullName" runat="server" Text=""></asp:Label> <br/>

                                             <label for="lblGender" >Gender :</label>
                                            <asp:Label ID="lblGender" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblBGName" >BloodGroup :</label>
                                            <asp:Label ID="lblBGName" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblDateOfBirth" >DateOfBirth :</label>
                                            <asp:Label ID="lblDateOfBirth" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblDateofJoining" >DateofJoining :</label>
                                            <asp:Label ID="lblDateofJoining" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblDepartMentName" >DepartMentName :</label>
                                            <asp:Label ID="lblDepartMentName" runat="server" Text=""></asp:Label><br/>

                                           

                                              <label for="lblMobileNo" >MobileNo :</label>
                                            <asp:Label ID="lblMobileNo" runat="server" Text=""></asp:Label><br/>

                                           
                                              <label for="lblEmailId" >EmailId :</label>
                                            <asp:Label ID="lblEmailId" runat="server" Text=""></asp:Label><br/>

                                              <label for="lblStateName" >StateName :</label>
                                            <asp:Label ID="lblStateName" runat="server" Text=""></asp:Label><br/>
                                              <label for="lblCityName" >CityName :</label>
                                            <asp:Label ID="lblCityName" runat="server" Text=""></asp:Label><br/>
                                              <label for="lblHomeAddress" >HomeAddress :</label>
                                            <asp:Label ID="lblHomeAddress" runat="server" Text=""></asp:Label><br/>
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

                <asp:Panel ID="EditPanel" Visible="false" runat="server">

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
                                      <asp:Button ID="btnEditBack" class="btn  bg-gradient-success btn-lg" runat="server" Text="Back" OnClick="btnEditBack_Click" />
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn bg-gradient-info btn-lg" OnClick="btnSubmit_Click" />
                                  
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


