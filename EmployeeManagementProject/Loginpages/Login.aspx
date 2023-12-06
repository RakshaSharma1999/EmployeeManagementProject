<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EmployeeManagementProject.Loginpages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Login</title>

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
    <form id="LoginForm" runat="server">
        <div class="login-box">
            <!-- /.login-logo -->
            <div class="card card-outline card-primary">
                <div class="card-header text-center">
                    <a href="#" class="h1"><b>All</b>Login</a>
                </div>
                <div class="card-body">
                    <p class="login-box-msg">Sign in to start your session</p>


                    <div class="input-group mb-3">
                        <asp:TextBox ID="txtemailid" runat="server" class="form-control" MaxLength="50" placeholder="Email"></asp:TextBox>
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-envelope"></span>
                            </div>
                        </div>
                    </div>
                    <div class="input-group mb-3">
            
                        <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" MaxLength="20" class="form-control" placeholder="Password"></asp:TextBox>
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-lock"></span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-8">
                            <div class="icheck-primary">
                                <asp:CheckBox ID="CheckBoxRemeberMe"  AutoPostBack="true" runat="server" />
                               
                                <label for="CheckBoxRemeberMe">
                                    Remember Me
             
                                </label>
                            </div>
                        </div>
                        <!-- /.col -->
                        <div class="col-4">
                          
                            <asp:Button ID="btnSubmit" runat="server" Text="Sign In" class="btn btn-primary btn-block" OnClick="btnSubmit_Click" />
                        </div>
                        <!-- /.col -->
                    </div>


                    <p class="mb-1">
                        <a href="CreateNewPassword.aspx">Create New Password</a>
                    </p>
                   
                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </div>
        <!-- /.login-box -->
        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
        <!-- jQuery -->
        <script src="../../plugins/jquery/jquery.min.js"></script>
        <!-- Bootstrap 4 -->
        <script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
        <!-- AdminLTE App -->
        <script src="../../dist/js/adminlte.min.js"></script>
    </form>
</body>
</html>
