<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Salary.aspx.cs" Inherits="EmployeeManagementProject.AdminPanelPages.Salary" %>

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
                <asp:Panel ID="AddPanel" Visible="false" runat="server">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card card-info">
                            <div class="card-header">
                                <h3 class="card-title">Employee Salary</h3>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtEmployeeId">Employee ID</label>
                                            <asp:TextBox ID="txtEmployeeId" class="form-control" runat="server" placeholder="Enter Employee Id"></asp:TextBox>
                                            
                                        </div>
                                        </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtEmployeeName">Employee Name</label>
                                            <asp:TextBox ID="txtEmployeeName" class="form-control" placeholder="Enter Employee Name" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                      <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtGrossSalary">Gross Salary</label>
                                            <asp:TextBox ID="txtGrossSalary" class="form-control" OnTextChanged="txtGrossSalary_TextChanged" AutoPostBack="true" placeholder="Enter Gross Salary" runat="server"></asp:TextBox>
                                            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                                        </div>

                                    </div>
                                </div>

                                <div class="row">
                                  
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtBasicSalary">Basic Salary</label>
                                            <asp:TextBox ID="txtBasicSalary" class="form-control" BackColor="White" AutoPostBack="true" OnTextChanged="txtBasicSalary_TextChanged" ReadOnly="true" runat="server"></asp:TextBox>

                                        </div>

                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtHRA">House Rent Allowance</label>
                                            <asp:TextBox ID="txtHRA" class="form-control" BackColor="White" AutoPostBack="true" ReadOnly="true" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                     <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtDearnessAllowance">Dearness Allowance</label>
                                            <asp:TextBox ID="txtDearnessAllowance" class="form-control" BackColor="White" AutoPostBack="true" ReadOnly="true" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                 
                                </div>
                                <div class="row">
                                     <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtConveyanceAllowance">Conveyance Allowance</label>
                                            <asp:TextBox ID="txtConveyanceAllowance" class="form-control" placeholder="Enter Conveyance Allowance" OnTextChanged="txtConveyanceAllowance_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                       <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtMedicalAllowance">Medical Allowance</label>
                                            <asp:TextBox ID="txtMedicalAllowance" class="form-control" placeholder="Enter Medical Allowance" OnTextChanged="txtMedicalAllowance_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                      
                                         <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtOtherAllowance">Other Allowance</label>
                                            <asp:TextBox ID="txtOtherAllowance" class="form-control" BackColor="White" AutoPostBack="true" ReadOnly="true" runat="server"></asp:TextBox>

                                        </div>
                                    </div>

                                </div>
                                  

                               <h3>Employee Deductions</h3>
                                <div class="row">
                                     <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtProvidentFund">Provident Fund</label>
                                            <asp:TextBox ID="txtProvidentFund" class="form-control" BackColor="White" AutoPostBack="true" ReadOnly="true" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                      <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtESI">ESI</label>
                                            <asp:TextBox ID="txtESI" class="form-control" BackColor="White" AutoPostBack="true" ReadOnly="true" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                     <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtPT">Professional Tax</label>
                                            <asp:TextBox ID="txtPT" class="form-control" AutoPostBack="true" placeholder="Enter Professional Tax " OnTextChanged="txtPT_TextChanged" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                  <div class="row">
                                    
                                     <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtNetSalary">Net Salary</label>
                                            <asp:TextBox ID="txtNetSalary" AutoPostBack="true" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="card-footer">

                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn bg-gradient-info btn-lg" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn  bg-gradient-success btn-lg" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                    </asp:Panel>

                <asp:Panel ID="ListPanel" Visible="true" runat="server">
                    <div class="row">
                        <!-- left column -->
                        <div class="col-md-12">

                            <!-- Horizontal Form -->
                            <div class="card card-info">
                                <div class="card-header">
                                    <h3 class="card-title">Employees Salary List</h3>
                                </div>
                                <!-- /.card-header -->
                                <!-- form start -->

                                <div class="card-body">
                                    <div class="form-group row">
                                         <div class="col-sm-3">
                                            <asp:TextBox ID="txtSearchEmployeeId" TextMode="Search" runat="server" class="form-control" placeholder="Search Employee ID"></asp:TextBox>
                                        </div>

                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtSearch" TextMode="Search" runat="server" class="form-control" placeholder="Search Employee Name"></asp:TextBox>
                                        </div>

                                        
                                        <div class="col-sm-2">
                                            <asp:Button ID="btnSearch" class="btn btn-block bg-gradient-info" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button ID="btnClear" class="btn btn-block bg-gradient-success" runat="server" Text="Clear" OnClick="btnClear_Click" />
                                        </div>
                                         <div class="col-sm-2">
                                            <asp:Button ID="btnAddNew" class="btn btn-block bg-gradient-danger" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
                                        </div>
                                    </div>

                                </div>

                                <!-- /.card-body -->



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
                                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="EditEmployeeSalary" CommandArgument='<%# Eval("SalaryId") %>'><i class="fas fa-solid fa-marker"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteEmployeeSalary" CommandArgument='<%# Eval("SalaryId")%>'><i class="fas fa-solid fa-trash"></i></asp:LinkButton>
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

                                        

                                        <!-- /.card -->


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
    <!-- /.content-wrapper -->
</asp:Content>
