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
       
        <div class="row">
          <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-info">
            
              <div class="inner">
                <br />
                <h2> My Profile</h2>
               <br />
              
              </div>
              <div class="icon">
              <i class="ion ion-person-add"></i>
              </div>
               
              <a href="EmployeeViewProfile.aspx" class="small-box-footer">More info<i class="fas fa-arrow-circle-right"></i>

              </a>
                  
            </div>
          </div>
       
              <div class="col-lg-3 col-6">
    <!-- small box -->
    <div class="small-box bg-success">
    
      <div class="inner">
        <br />
        <h2> Salary </h2>
       <br />
      
      </div>
      <div class="icon">
    <i class="fas fa-light fa-credit-card"></i>
      </div>
       
      <a href="EmployeeSalaryView.aspx" class="small-box-footer">More info<i class="fas fa-arrow-circle-right"></i>

      </a>
          
    </div>
  </div>
              <div class="col-lg-3 col-6">
    <!-- small box -->
    <div class="small-box bg-warning">
      <div class="inner">
        <h2>
            <asp:Label ID="lblPendingTask" runat="server" Text=""></asp:Label></h2>

        <h2>Pending Task</h2>
      </div>
      <div class="icon">
         <i class="fas fa-regular fa-file"></i>
      </div>
      <a href="ProjectEmployeeList.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
    </div>
  </div>

        </div>
       
       
      </div><!-- /.container-fluid -->
    </section>
    <!-- /.content -->
  </div>
</asp:Content>


