<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeSalaryView.aspx.cs" Inherits="EmployeeManagementProject.EmployeeDashboard.EmployeeSalaryView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                

                <asp:Panel ID="ListPanel" Visible="true" runat="server">
                    <div class="row">
                        <!-- left column -->
                        <div class="col-md-12">

                            <!-- Horizontal Form -->
                            <div class="card card-info">
                                <div class="card-header">
                                    <h3 class="card-title">Employees Salary List</h3>
                                </div>
  
                                <div class="row">

                                    <div class="col-md-12">
                                        <asp:GridView ID="GridViewEmployeeSalary" AutoGenerateColumns="false" OnRowCommand="GridViewEmployeeSalary_RowCommand" runat="server" class="table table-bordered table-striped dataTable dtr-inline text-center" AllowPaging="true" OnPageIndexChanging="GridViewEmployeeSalary_PageIndexChanging">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Employee Id">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmployeeId" runat="server" Text='<%# Eval("EmployeeId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("FirstName") + " " + Eval("LastName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Basic Salary">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBasicSalary" runat="server" Text='<%# Eval("BasicSalary") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Gross Salary">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGrossSalary" runat="server" Text='<%# Eval("GrossSalary") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Net Salary">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNetSalary" runat="server" Text='<%# Eval("NetSalary") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Actions">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnView" runat="server" CommandName="ViewEmployeeSalary" CommandArgument='<%# Eval("SalaryId") %>'><i class="fas fa-solid fa-eye"></i></asp:LinkButton>

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
                                        


                                        <div class="col-md-6 text-justify">
                                             <label for="lblEmployeeId" >Employee ID : </label>
                                                <asp:Label ID="lblEmployeeId" runat="server" Text=""></asp:Label> <br/>

                                            <label for="lblFullName">Name : </label>
                                                <asp:Label ID="lblFullName" runat="server" Text=""></asp:Label> <br/>

                                             <label for="lblGrossSalary">GrossSalary :</label>
                                            <asp:Label ID="lblGrossSalary" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblBasicSalary">BasicSalary :</label>
                                            <asp:Label ID="lblBasicSalary" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblHRA" >House Rent Allowance :</label>
                                            <asp:Label ID="lblHRA" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblDA">Dearness Allowance :</label>
                                            <asp:Label ID="lblDA" runat="server" Text=""></asp:Label><br/>

                                             <label for="lblConveyanceAllowance">Conveyance Allowance :</label>
                                            <asp:Label ID="lblConveyanceAllowance" runat="server" Text=""></asp:Label><br/>

                                           

                                              <label for="lblMedicalAllowance">Medical Allowance :</label>
                                            <asp:Label ID="lblMedicalAllowance" runat="server" Text=""></asp:Label><br/>

                                           
                                              <label for="lblOtherAllowance">Other Allowance :</label>
                                            <asp:Label ID="lblOtherAllowance" runat="server" Text=""></asp:Label><br/>

                                              <label for="lblProvidentFund">Provident Fund :</label>
                                            <asp:Label ID="lblProvidentFund" runat="server" Text=""></asp:Label><br/>
                                              <label for="lblESI">ESI :</label>
                                            <asp:Label ID="lblESI" runat="server" Text=""></asp:Label><br/>
                                              <label for="lblProfessionalTax">Professional Tax :</label>
                                            <asp:Label ID="lblProfessionalTax" runat="server" Text=""></asp:Label><br/>
                                              <label for="lblNetSalary">Net Salary :</label>
                                            <asp:Label ID="lblNetSalary" runat="server" Text=""></asp:Label><br/>
                                        </div>

                                    </div>
                                    <div class="card-footer">

                                            <asp:Button ID="btnback" class="btn btn-primary" runat="server" Text="Back" OnClick="btnback_Click" />
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
