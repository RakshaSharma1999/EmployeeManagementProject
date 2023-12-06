<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EmployeeManagementProject.EmployeeDashboard.EmployeeHomeDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper" style="min-height: 203px;">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0 text-dark">Dashboard</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
           
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
    <!-- /.content-header -->

    <!-- Main content -->
    <section class="content">
      <div class="container-fluid">
        <!-- Small boxes (Stat box) -->
        <div class="row">
          <div class="col-lg-3 col-6">
            <!-- small box -->
              <a href="EmployeeViewProfile.aspx">
            <div class="small-box bg-info">
              <div class="inner">
                <h3>My</h3>

                <h3>Profile</h3>
                  <br />
              </div>
              <div class="icon">
               
                  <i class="fas fa-regular fa-user"></i>
              </div>
           <a href="EmployeeViewProfile.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
            </div>
                   </a>
          </div>
          <!-- ./col -->
          <div class="col-lg-3 col-6">
            <!-- small box -->
              <a href="ProjectEmployeeList.aspx">
            <div class="small-box bg-success">
              <div class="inner">
                <h3>Employee</h3>
                  <h3>Task</h3>
                  <br />
              </div>
              <div class="icon">
         <i class="fas fa-regular fa-file"></i>
              </div>
              <a href="ProjectEmployeeList.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
            </div>
                  </a>
          </div>
          <!-- ./col -->
          <div class="col-lg-3 col-6">
            <!-- small box -->
              <a href="EmployeeSalaryView.aspx">
            <div class="small-box bg-danger">
              <div class="inner">
                <h3>Emaployee</h3>

                <h3>Salary</h3>
                  <br />
              </div>
              <div class="icon">
                <i class="ion ion-stats-bars"></i>
              </div>
              <a href="EmployeeSalaryView.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
            </div>
                  </a>
          </div>
       
        </div>
        <!-- /.row -->
      
      </div><!-- /.container-fluid -->
    </section>
    <!-- /.content -->
  </div>
</asp:Content>
