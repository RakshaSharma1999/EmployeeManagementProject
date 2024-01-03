<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EmployeeManagementProject.AdminPanelPages.Home" %>
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
                <h3>
                    <asp:Label ID="lblTotalEmployee" runat="server" Text=""></asp:Label></h3>

                <p>Total Employee</p>
              </div>
              <div class="icon">
              <i class="ion ion-person-add"></i>
              </div>
               
              <a href="EmployeeViewList.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i>

              </a>
                  
            </div>
          </div>
          <!-- ./col -->
          <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-success">
              <div class="inner">
                <h3>
                    <asp:Label ID="lblPendingRequest" runat="server" Text="Label"></asp:Label></h3>

                <p>Leave Pending Request</p>
              </div>
              <div class="icon">
                <i class="ion ion-stats-bars"></i>
              </div>
              <a href="LeaveView.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
          <!-- ./col -->
          <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-warning">
              <div class="inner">
                <h3>
                    <asp:Label ID="lblPendingProject" runat="server" Text=""></asp:Label></h3>

                <p>Penging Project</p>
              </div>
              <div class="icon">
                 <i class="fas fa-regular fa-file"></i>
              </div>
              <a href="ProjectView.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
          <!-- ./col -->
       
          <!-- ./col -->
        </div>
       
       
      </div><!-- /.container-fluid -->
    </section>
    <!-- /.content -->
  </div>
</asp:Content>
