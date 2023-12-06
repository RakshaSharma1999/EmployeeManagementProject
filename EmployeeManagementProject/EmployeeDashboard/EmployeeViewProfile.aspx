<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeViewProfile.aspx.cs" Inherits="EmployeeManagementProject.EmployeeDashboard.EmployeeViewProfile" %>
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

 <asp:Panel ID="ViewPanel" Visible="true" runat="server">
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
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
