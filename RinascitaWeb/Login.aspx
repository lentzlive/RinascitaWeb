<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RinascitaWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="Dashboard">
    <meta name="keyword" content="Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina">

    <title>DASHGUM - Bootstrap Admin Template</title>

    <!-- Bootstrap core CSS -->
    <link href="assets/css/bootstrap.css" rel="stylesheet">
    <!--external css-->
    <link href="assets/font-awesome/css/font-awesome.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="assets/css/style.css" rel="stylesheet">
    <link href="assets/css/style-responsive.css" rel="stylesheet">

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>

    <!-- **********************************************************************************************************************************************************
      MAIN CONTENT
      *********************************************************************************************************************************************************** -->

    <div id="login-page">
        <div class="container">

            <form  id="formLogin" class="form-login" runat="server">
                <h2 class="form-login-heading">sign in now</h2>
                <div class="login-wrap">
            
                       <asp:TextBox ID="txtUser"  CssClass="form-control" placeholder="User ID" runat="server"></asp:TextBox>

                    <br/>
                  
                    <asp:TextBox ID="txtPassword"  CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
                    <label class="checkbox">
                        <span class="pull-right">
                            <a data-toggle="modal" href="login.html#myModal">Forgot Password?</a>

                        </span>
                    </label>
                
                    <asp:Button ID="cmdLogin" CssClass="btn btn-theme btn-block" runat="server" Text="Login" OnClick="cmdLogin_Click" />

                    <hr/>

           
                    <div class="registration">
                        Don't have an account yet?<br />
                        <a class="" href="#">Create an account
                        </a>
                    </div>

                </div>


            </form>

        </div>
    </div>

    <!-- js placed at the end of the document so the pages load faster -->
    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>

    <!--BACKSTRETCH-->
    <!-- You can use an image of whatever size. This script will stretch to fit in any screen size.-->
    <script type="text/javascript" src="assets/js/jquery.backstretch.min.js"></script>
    <script>
        $.backstretch("assets/img/website-backgrounds-hd-arena.jpg", { speed: 500 });
    </script>

</body>
</html>
