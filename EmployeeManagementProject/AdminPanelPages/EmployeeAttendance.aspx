<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EmployeeAttendance.aspx.cs" Inherits="EmployeeManagementProject.AdminPanelPages.EmployeeAttendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
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
                        <div class="card card-info">
                            <div class="card-header">
                                <h3 class="card-title">Employee Attendance</h3>
                            </div>
                            <div class="card-body">
                          
                                <div class="row">

                                    <div class="col-md-12">
                                        <asp:GridView ID="GridAddAttendance" AutoGenerateColumns="false" OnRowDataBound="GridAddAttendance_RowDataBound" ShowFooter="true" runat="server" class="table table-bordered table-striped dataTable dtr-inline text-center" AllowPaging="true" >
                                            <Columns>
                                                <asp:BoundField DataField="RowNumber" Visible="false" HeaderText="NO." />
                                                <asp:TemplateField HeaderText="EmployeeId">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtEmployeeId" OnTextChanged="txtEmployeeId_TextChanged" runat="server" placeholder="Employee ID" Text='<%# Eval("EmployeeId")%>' AutoPostBack="true" class="form-control"></asp:TextBox>
                                                        <cc1:AutoCompleteExtender ServiceMethod="SearchStudent"
                                                            MinimumPrefixLength="2"
                                                            CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                                            TargetControlID="txtEmployeeId"
                                                            ID="AutoCompleteExtender1" runat="server">
                                                        </cc1:AutoCompleteExtender>
                                                        <asp:HiddenField ID="hdnWOEmployeeID" runat="server" Value='<%# Eval("ID")%>'></asp:HiddenField>
                                                        <asp:Label ID="lblEmpId" runat="server" Text='<%# Eval("EmployeeId") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="Attendance Date">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtDate" class="form-control" runat="server" TextMode="Date" Text='<%# Eval("Attendancedate") %>'></asp:TextBox>
                                                        <asp:HiddenField ID="hdnDateID" runat="server" Value='<%# Eval("DateID")%>'></asp:HiddenField>
                                                        <asp:Label ID="lblAttendanceDate" runat="server" Text='<%# Eval("Attendancedate") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CheckInTime">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtCheckInTime" class="form-control" runat="server" TextMode="Time" Text='<%# Eval("CheckInTime") %>'></asp:TextBox>
                                                        <asp:HiddenField ID="hdnCheckInID" runat="server" Value='<%# Eval("CheckInID")%>'></asp:HiddenField>
                                                        <asp:Label ID="lblCheckInTime" runat="server" Text='<%# Eval("CheckInTime") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="CheckOutTime">
                                                    <ItemTemplate>

                                                        <asp:TextBox ID="txtCheckOutTime" class="form-control" runat="server" TextMode="Time" Text='<%# Eval("CheckOutTime") %>'></asp:TextBox>
                                                        <asp:HiddenField ID="hdnCheckOutID" runat="server" Value='<%# Eval("CheckOutID")%>'></asp:HiddenField>
                                                        <asp:Label ID="lblCheckOutTime" runat="server" Text='<%# Eval("CheckOutTime") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="#" ItemStyle-Width="10%">

                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <FooterTemplate>
                                                        <asp:Button ID="ButtonAdd" OnClick="ButtonAdd_Click" runat="server" ValidationGroup="C" CausesValidation="false" Text="Add New" CssClass="btn btn-block bg-gradient-danger" />

                                                    </FooterTemplate>

                                                </asp:TemplateField>


                                            </Columns>

                                        </asp:GridView>

                                    </div>
                                </div>
                            </div>

                            <div class="card-footer">

                                <asp:Button ID="btnPresent" runat="server" Text="Present" class="btn bg-gradient-info btn-lg" OnClick="btnPresent_Click" />
                               
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
</asp:Content>
