<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DepartmentPage.aspx.cs" Inherits="EmployeeManagementProject.AdminPanelPages.DepartmentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
         <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
                
          
          </div><!-- /.col -->
         
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>

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
                <h3 class="card-title">Department List</h3>
              </div>
              <!-- /.card-header -->
              <!-- form start -->
                
                <div class="card-body">
                  <div class="form-group row">

                    <div class="col-sm-6">
                        <asp:TextBox ID="txtSearch" TextMode="Search" runat="server" class="form-control" placeholder="Search"></asp:TextBox>
                        </div>
                      <div class="col-sm-1">  
                        <asp:Button ID="btnSearch" class="btn btn-block bg-gradient-info" runat="server" Text="Search" OnClick="btnSearch_Click" />
                          </div>
                       <div class="col-sm-1">  
                         <asp:Button ID="btnClear" class="btn btn-block bg-gradient-success" runat="server" Text="Clear" OnClick="btnClear_Click" />
                           </div>
                       <div class="col-sm-2">  
                       <asp:Button ID="AddNew" class="btn btn-block btn-warning" runat="server" Text="Add New Department" OnClick="AddNew_Click" />
                    </div>
                 </div>
                
                </div>
                  
                <!-- /.card-body -->
               
             
           
          <div class="row">

                    <div class="col-md-12">
                        <asp:GridView ID="GridViewDepartment" AutoGenerateColumns="false" OnRowCommand="GridViewDepartment_RowCommand" runat="server" class="table table-bordered table-striped dataTable dtr-inline text-center" AllowPaging="true" OnPageIndexChanging="GridViewDepartment_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Srno">
                                    <ItemTemplate>
                                        <asp:Label ID="SrNo" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Department Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblname" runat="server" Text='<%# Eval("DepartMentName") %>'></asp:Label>
                                    </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="EditDepartment" CommandArgument='<%# Eval("DepartMentId") %>'><i class="fas fa-solid fa-marker"></i></asp:LinkButton>
                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteDepartment" CommandArgument='<%# Eval("DepartMentId")%>'><i class="fas fa-solid fa-trash"></i></asp:LinkButton>
                                        <asp:LinkButton ID="btnView" runat="server" CommandName="ViewDepartment" CommandArgument='<%# Eval("DepartMentId") %>'><i class="fas fa-solid fa-eye"></i></asp:LinkButton>
                                      
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

           <asp:Panel ID="AddPanel" Visible="false" runat="server">
          <div class="row">
                <div class="col-md-12">
                        <!-- general form elements -->
                        <div class="card card-info">
                            <div class="card-header">
                                <h3 class="card-title">Add Department</h3>
                            </div>
                            <!-- /.card-header -->
                            <!-- form start -->

                            <div class="card-body">
                                <div class="form-group">
                                    <label for="txtDepartmentName">Department Name</label>

                                    <asp:TextBox ID="txtDepartmentName" runat="server" class="form-control" placeholder="Enter Department Name"></asp:TextBox>
                                </div>

                            </div>
                            <!-- /.card-body -->

                            <div class="card-footer">

                                <asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn bg-gradient-info" OnClick="btnsubmit_Click" />
                                  <asp:Button ID="btnBack" class="btn  bg-gradient-success" runat="server" Text="Back" OnClick="btnBack_Click" />
                            </div>

                        </div>
                        <!-- /.card -->



                    </div>
          </div>
        <!-- /.row -->
            </asp:Panel>

           <asp:Panel ID="ViewPanel" Visible="false" runat="server">
                    <div class="row">
                        <!-- left column -->
                        <div class="col-md-12">

                            <!-- Horizontal Form -->
                            <div class="card card-info">
                                <div class="card-header">
                                    <h3 class="card-title">Department Details</h3>
                                </div>
                                <!-- /.card-header -->
                                <!-- form start -->

                                <div class="card-body">
                                    <div class="row text-center">
                                      


                                        <div class="col-md-12 text-justify">
                                             <label for="lblDepartmentId">Department ID : </label>
                                                <asp:Label ID="lblDepartmentId" runat="server" Text=""></asp:Label> <br/>


                                            <label for="lblDepartmentName">Department Name : </label>
                                                <asp:Label ID="lblDepartmentName" runat="server" Text=""></asp:Label> <br/>

                                             
                                        </div>

                                        <div class="card-footer">
                                            <asp:Button ID="btnBackView" class="btn bg-gradient-info btn-lg"  runat="server" Text="Back" OnClick="btnBackView_Click" />
                                        </div>

                                        <!-- /.card -->


                                    </div>
                                </div>
                                <!-- /.card-body -->





                            </div>
                        </div>
                    </div>
                </asp:Panel>

          </div>
        </div>

        </div>
</asp:Content>
