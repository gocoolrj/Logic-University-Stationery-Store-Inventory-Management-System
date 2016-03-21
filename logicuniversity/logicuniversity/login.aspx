<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="logicuniversity.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
      <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login</title>
	<!-- Bootstrap Styles-->
    <link href="web/css/bootstrap.css" rel="stylesheet" />
     <!-- FontAwesome Styles-->
    <link href="web/css/font-awesome.css" rel="stylesheet" />
        <!-- Custom Styles-->
    <link href="web/css/custom-styles.css" rel="stylesheet" />
     <!-- Google Fonts-->
   <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
</head>
<body>

        <div id="page-login" >
             
			 <div class="row">
                    <div class="col-md-9"> 
                        <h1 class="page-header">
                          <img src="images/univlogo.jpg" width="100px"/> Logic University<br/> <small>Stationery Inventory System</small>
                        </h1>
                    </div>
             </div> 
             <form role="form" runat="server">   
             <div class="row">
                <div class="col-md-9">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="row">  <img src="images/stationery_icon.png" width="335px" />
                                <div class="col-lg-6">
                                    
                                                
                                            <label>User ID</label>
                                            <!--input class="form-control"-->
                                            <asp:TextBox ID="txtUserID" runat="server" class="form-control" required="true" Width="376px"></asp:TextBox>
                                            <br/>
                                            <label>Password</label>
                                            <asp:TextBox ID="txtPassword" runat="server" class="form-control" TextMode="Password" required="true" Width="376px"></asp:TextBox>
                                            <br/>
                                            <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-primary" OnClick="btnLogin_Click" />
                                            <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label>
                                 </div>
                                 <br/>
                                 <div class="col-lg-3">
                                      
                                 </div>                   
                                <!-- /.col-lg-6 (nested) -->
                            </div>        
                                        
                            <!-- /.row (nested) -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-12 -->
            </div>
            </form>
            
            <footer><p>Copyright © SA40 ADProject Team-2  2015 </p></footer>
		</div>
             <!-- /. PAGE INNER  -->
           
         <!-- /. PAGE WRAPPER  -->
     
    <!-- JS Scripts-->
    <!-- jQuery Js -->
    <script src="web/js/jquery-1.10.2.js"></script>
      <!-- Bootstrap Js -->
    <script src="web/js/bootstrap.min.js"></script>
    <!-- Metis Meu Js -->
    <script src="web/js/jquery.metisMenu.js"></script>
      <!-- Custom Js -->
    <script src="web/js/custom-scripts.js"></script>
</body>
</html>