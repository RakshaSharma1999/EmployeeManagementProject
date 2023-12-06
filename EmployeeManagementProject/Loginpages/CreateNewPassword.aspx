<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateNewPassword.aspx.cs" Inherits="EmployeeManagementProject.Loginpages.CreateNewPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <title>AdminLTE 3 | Forgot Password (v2)</title>

  <!-- Google Font: Source Sans Pro -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback"/>
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css"/>
  <!-- icheck bootstrap -->
  <link rel="stylesheet" href="../../plugins/icheck-bootstrap/icheck-bootstrap.min.css"/>
  <!-- Theme style -->
    <link rel="stylesheet" href="../../dist/css/adminlte.min.css"/>
</head>
<body class="hold-transition login-page">
<div class="login-box">
  <div class="card card-outline card-primary">
    <div class="card-header text-center">
      <a href="../../index2.html" class="h1"><b>Create</b>Password</a>
    </div>
    <asp:Panel ID="EmailVerifyPanel" runat="server">
    <div class="card-body">
      <p class="login-box-msg">Enter Your Email ID</p>
      
    <form id="CreatePassword" runat="server">
        <div class="input-group mb-3">
      <asp:TextBox ID="txtemailid" class="form-control" placeholder="Email ID" TextMode="Email"  runat="server"></asp:TextBox>
          
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-envelope"></span>
            </div>
          </div>
      </div>
        <div class="row">
          <div class="col-12">
    <asp:Button ID="btnVerifyEmail" class="btn btn-primary btn-block" runat="server" Text="Verify Address" OnClick="btnVerifyEmail_Click" />
           <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label> 
             <asp:Label ID="lblCode" runat="server" Text="" Visible="false"></asp:Label>
          </div>
          <!-- /.col -->
        </div>
      </form>
      <p class="mt-3 mb-1">
        <a href="Login.aspx">Login</a>
      </p>
    </div>
        </asp:Panel>
      
      <asp:Panel ID="VerifyCodePanel" Visible="false" runat="server">
    <div class="card-body">
      <p class="login-box-msg">Enter Your Email ID</p>
      
    <form id="Form1" runat="server">
        <div class="input-group mb-3">
      <asp:TextBox ID="txtVerify" class="form-control" placeholder="Enter Code"  runat="server"></asp:TextBox>
          
        
      </div>
        <div class="row">
          <div class="col-12">
    <asp:Button ID="btnVerifyCodeNext" class="btn btn-primary btn-block" runat="server" Text="Next" OnClick="btnVerifyCodeNext_Click" />
           <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label> 
          </div>
          <!-- /.col -->
        </div>
      </form>
      <p class="mt-3 mb-1">
        <a href="Login.aspx">Login</a>
      </p>
    </div>
        </asp:Panel>


        <asp:Panel ID="CreatePasswordPanel" Visible="false" runat="server">
    <div class="card-body">
      <p class="login-box-msg">Cretae Password</p>
      
    <form id="Form2" runat="server">
          <div class="input-group mb-3">
    <asp:TextBox ID="txtPassword" class="form-control" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox>
         
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
        <asp:TextBox ID="txtConfirmPassword" TextMode="Password" class="form-control" placeholder="Confirm Password" runat="server"></asp:TextBox>
     
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock"></span>
            </div>
          </div>
        </div>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" 
                        ErrorMessage="Both pass r diff." SetFocusOnError="True"></asp:CompareValidator>
        <div class="row">
          <div class="col-12">
    <asp:Button ID="btnCreatePassword" class="btn btn-primary btn-block" runat="server" Text="Create" OnClick="btnCreatePassword_Click" />
           <asp:Label ID="Label1" runat="server" Text=""></asp:Label> 
          </div>
          <!-- /.col -->
        </div>
      </form>
      <p class="mt-3 mb-1">
        <a href="Login.aspx">Login</a>
      </p>
    </div>
        </asp:Panel>
    <!-- /.login-card-body -->
  </div>
</div>
<!-- /.login-box -->

<!-- jQuery -->
<script src="../../plugins/jquery/jquery.min.js"></script>
<!-- Bootstrap 4 -->
<script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
<!-- AdminLTE App -->
<script src="../../dist/js/adminlte.min.js"></script>
</body>
</html>
