<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="Leave.aspx.cs" Inherits="EmployeeManagementProject.EmployeeDashboard.Leave" %>

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
                <asp:Panel ID="AddPanel" Visible="false" runat="server">
                <div class="row">
                    <div class="col-md-12">
                         <div class="card card-info">
                              <div class="card-header">
                                    <h3 class="card-title">Apply Leave</h3>
                                </div>
                              <div class="card-body">
                                   <div class="row">
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="txtStartDate">Start Date</label>
                                                <asp:TextBox ID="txtStartDate" class="form-control" runat="server" TextMode="Date"></asp:TextBox>

                                                </div>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidatorStartDate" runat="server"
                                                ControlToValidate="txtStartDate" ForeColor="Red" ErrorMessage="Please Enter Start Date."
                                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                                             </div>
                                       <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="txtEndDate">End Date</label>
                                                <asp:TextBox ID="txtEndDate" class="form-control" runat="server" TextMode="Date"></asp:TextBox>

                                                </div>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidatorEndDate" runat="server"
                                                ControlToValidate="txtEndDate" ForeColor="Red" ErrorMessage="Please Enter End Date."
                                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                                             </div>
                                       </div>

                                  <div class="row">
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="txtReason">Reason</label>
                                                <asp:TextBox ID="txtReason" class="form-control" runat="server" ></asp:TextBox>

                                                </div>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ControlToValidate="txtReason" ForeColor="Red" ErrorMessage="Please Give Reason for Leave."
                                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                                             </div>
                                       <div class="col-md-6">
                                            <div class="form-group">
                                                 <label for="txtDescription">Description</label>
                                                <asp:TextBox ID="txtDescription" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>

                                                </div>
                                            
                                       </div>
                                      </div>
                                  </div>

                             <div class="card-footer">

                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn bg-gradient-info btn-lg" OnClick="btnSubmit_Click" />
                                   
                                </div>
                             </div>
                    </div>
                </div>
                    </asp:Panel>

                  <asp:Panel ID="ListPanel" Visible="true"  runat="server">
                    <div class="row">
                        <!-- left column -->
                        <div class="col-md-12">

                            <!-- Horizontal Form -->
                            <div class="card card-info">
                                <div class="card-header">
                                    <h3 class="card-title">Leave Request</h3>
                                </div>
                                <!-- /.card-header -->
                                <!-- form start -->

                                <div class="card-body">
                                    <div class="form-group row">

                                         <div class="col-sm-2">
                                            <asp:Button ID="btnAddNew" class="btn bg-gradient-info btn-lg" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
                                        </div>

                                    </div>

                                </div>

                                <!-- /.card-body -->



                                <div class="row">

                                    <div class="col-md-12">
                                        <asp:GridView ID="GridViewLeaveRequest" AutoGenerateColumns="false" OnRowCommand="GridViewLeaveRequest_RowCommand" runat="server" class="table table-bordered table-striped dataTable dtr-inline text-center" AllowPaging="true" OnPageIndexChanging="GridViewLeaveRequest_PageIndexChanging">
                                            <Columns>
                                                 <asp:TemplateField HeaderText="SrNo.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmployeeId" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
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
                                                      
                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteLeaveRequest" CommandArgument='<%# Eval("LeaveRequestId")%>'><i class="fas fa-solid fa-trash"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="btnView" runat="server" CommandName="ViewLeaveRequest" CommandArgument='<%# Eval("LeaveRequestId") %>'><i class="fas fa-solid fa-eye"></i></asp:LinkButton>

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
                                           

                                            <label for="lblLeaveStartDate">Leave Start Date : </label>
                                                <asp:Label ID="lblLeaveStartDate" runat="server" Text=""></asp:Label> <br/>

                                             <label for="lblLeaveEndDate">Leave End Date :</label>
                                            <asp:Label ID="lblLeaveEndDate" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblStatus">Status :</label>
                                            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblReason">Reason :</label>
                                            <asp:Label ID="lblReason" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblDescription">Description :</label>
                                            <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblApplyOn">ApplyOn :</label>
                                            <asp:Label ID="lblApplyOn" runat="server" Text=""></asp:Label><br/>

                                        </div>

                                        <div class="card-footer">
                                            <asp:Button ID="btnback" class="btn bg-gradient-info btn-lg" runat="server" Text="Back" OnClick="btnback_Click" />
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
    <!-- /.content-wrapper -->
</asp:Content>
