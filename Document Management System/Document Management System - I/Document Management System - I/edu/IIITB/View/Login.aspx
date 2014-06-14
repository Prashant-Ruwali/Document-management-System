<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Document_Management_System___I.edu.IIITB.View.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Document Management System Login</title>
    <link href="../../../Styles/Index.css" type="text/css" rel="Stylesheet" />
    <link href="../../../Styles/bootstrap-theme.css" rel="Stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap.css" rel="Stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap-theme.min.css" rel="Stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap.min.css" rel="Stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap-select.css" rel="Stylesheet" type="text/css" />
     <link href="../../../Styles/bootstrap-select.min.css" rel="Stylesheet" type="text/css" />
     <link href="../../../Styles/Index.css" rel="Stylesheet" type="text/css" />

     <script type="text/javascript" src="../../../Scripts/jquery-1.6.min.js"></script>
    <script type="text/javascript" src="../../../Scripts/bootstrap.js"></script>
     <script type="text/javascript" src="../../../Styles/bootstrap-theme.min.css"></script>
     <script type="text/javascript" src="../../../Scripts/jquery-2.0.3.js"></script>
     <script type="text/javascript" src="../../../Scripts/bootstrap.min.js"></script>
     <script type="text/javascript" src="../../../Scripts/JScript.js"></script>
     <script type="text/javascript" src="../../../Scripts/bootstrap-select.js"></script>
     <script type="text/javascript" src="../../../Scripts/bootstrap-select.min.js"></script>
</head>
<body>
    <form id="Form1" runat="server">
      <div class="col-md-12">
      <div>
         <div id="myCarousel" class="carousel slide">
          <!-- Indicators -->
              <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class=""></li>
                <li data-target="#myCarousel" data-slide-to="1" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="2" class=""></li>
              </ol>
              <div class="carousel-inner">
                <div class="item">
                  <img src="../../../Images/largedms6.jpg" alt="First slide" style="height: 600px; width: 100%; display: block;">
                </div>
                <div class="item active">
                  <img src="../../../Images/largedms7.jpg" alt="Second slide" style="height: 600px; width: 100%; display: block;">
                </div>
                <div class="item">
                  <img src="../../../Images/largedms3.jpg"  alt="Third slide" style="height: 600px; width: 100%; display: block;">
                </div>
              </div>
             <a class="left carousel-control" href="#myCarousel" data-slide="prev"><span class="glyphicon glyphicon-chevron-left"></span></a> 
			<a class="right carousel-control" href="#myCarousel" data-slide="next"><span class="glyphicon glyphicon-chevron-left"></span></a>
        </div>
            <br />
            <center>
                <asp:Button ID="Button2" CssClass="btn btn-default" runat="server" Text="Login"  data-toggle="modal" data-target=".bs-example-modal-lg"
                    onclick="Button2_Click" style="width:100px"/>
                
                <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                  <div class="modal-dialog modal-lg">
                    <div class="modal-content">                       
                              <div class="col-md-2"></div>

                              <div class="col-md-8">
                              <br /><br /><br /><br /><br />
                              <center>
                               <asp:TextBox ID="Textuser" runat="server" placeholder="UserName or Email_Id" 
                                       required="True" CssClass="form-control input-sm"></asp:TextBox>
                                <br />
                                <br />
                                <asp:TextBox ID="Textpass" runat="server" TextMode="Password" 
                                       placeholder="Password" required="True" CssClass="form-control input-sm"></asp:TextBox>
                                <br />
                                <br />
                                <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" 
                                       CssClass="btn btn-default" />
                                </center>
                              </div>
                           <div class="col-md-2"></div>
                    </div>
                  </div>
                </div>
           </center>
       </div>
    </div>
    </form>
</body>
</html>
