<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="LeaveView.aspx.cs" Inherits="EmployeeManagementProject.AdminPanelPages.LeaveView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            

                  <asp:Panel ID="ListPanel" Visible="true"  runat="server">
                    <div class="row">
                        <!-- left column -->
                        <div class="col-md-12">

                            <!-- Horizontal Form -->
                            <div class="card card-info">
                                <div class="card-header">
                                    <h3 class="card-title">Employee Leave Request List</h3>
                                </div>
                                <!-- /.card-header -->
                                <div class="row">

                                    <div class="col-md-12">
                                        <asp:GridView ID="GridViewLeaveRequest" AutoGenerateColumns="false" OnRowDataBound="GridViewLeaveRequest_RowDataBound" OnRowCommand="GridViewLeaveRequest_RowCommand" runat="server" class="table table-bordered table-striped dataTable dtr-inline text-center" AllowPaging="true" OnPageIndexChanging="GridViewLeaveRequest_PageIndexChanging">
                                            <Columns>
                                                 <asp:TemplateField HeaderText="SrNo.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSrNo" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
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
                                                 <asp:TemplateField HeaderText="Leave Start Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLeaveStartDate" runat="server" Text='<%# Eval("LeaveStartDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Leave End Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLeaveEndDate" runat="server" Text='<%# Eval("LeaveEndDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                       
                                                  <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("StatusType") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Reason">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReason" runat="server" Text='<%# Eval("Reason") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="ApplyOn">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblApplyOn" runat="server" Text='<%# Eval("ApplyOn") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Actions">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnAction" CommandName="Action" CommandArgument='<%# Eval("LeaveRequestId") %>' class="btn btn-block bg-gradient-danger" runat="server" Text="Action" />
                                                       
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
                                    <h3 class="card-title">Leave Details</h3>
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

                                            <label for="lblLeaveStartDate">Leave Start Date : </label>
                                                <asp:Label ID="lblLeaveStartDate" runat="server" Text=""></asp:Label> <br/>

                                             <label for="lblLeaveEndDate">Leave End Date :</label>
                                            <asp:Label ID="lblLeaveEndDate" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblReason">Reason :</label>
                                            <asp:Label ID="lblReason" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblDescription">Description :</label>
                                            <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblApplyOn">ApplyOn :</label>
                                            <asp:Label ID="lblApplyOn" runat="server" Text=""></asp:Label>
                                            <div class="row">
                                                <div class="col-md-3">
                                            <div class="form-group">
                                             <label for="lblStatus">Status :</label>
                                            <asp:DropDownList ID="ddlStatus" class="form-control" runat="server"></asp:DropDownList>
                                                </div>
                                                    </div>
                                                </div>
                                        </div>

                                        <div class="card-footer">
                                            <asp:Button ID="btnSubmit" class="btn bg-gradient-info btn-lg" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                             <asp:Button ID="btnBack" class="btn  bg-gradient-success btn-lg" runat="server" Text="Back" OnClick="btnBack_Click" />
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
</asp:Content>
