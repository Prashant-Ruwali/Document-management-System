<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Document_Fragment_Review.aspx.cs" Inherits="Document_Management_System___I.edu.IIITB.View.Document_Fragment_Review" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Review Fragment</title>
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

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Document Details</h1>
                <div style="Width:641px; overflow:auto"">
                <asp:ListBox ID="ListBox1" runat="server" Height="314px"
                      style="margin-left: 0px">
                </asp:ListBox>
                </div>
               <table>
                    <tr>
                        <td><asp:Button ID="Add_Document_for_User" runat="server" style="margin-left: 87px;" 
                        Text="Confirm Doc" CssClass="btn btn-info"  onclick="Add_Document_for_User_Click"  />  
                        </td>
                        <td>
                 <asp:Button ID="Discard_Document" runat="server" style="margin-left: 412px; margin-top: 0px;" 
                        Text="Discard Document"  CssClass="btn btn-info"   data-toggle="modal" data-target=".bs-example-modal-lg" onclick="Button2_Click"/> 
                        </td>
                     </tr>  
                <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                                      <div class="modal-dialog modal-lg">
                                        <div class="modal-content">                       
                                                        <br /><br /><br /><br />
                                                        <center>
                                                            <asp:TextBox ID="Textuser" runat="server" placeholder="Please enter a valid reason for discarding document" 
                                                           CssClass="form-control input-sm"></asp:TextBox>
                                                        <br /><br /><br /><br />
                                                            <asp:Button ID="submitReason" runat="server" Text="Submit" onclick="Discard_Document_Click"
                                                           CssClass="btn btn-default" />
                                                           <br /><br /><br />
                                                        </center>
                                                  </div>
                                      </div>
                            </div>
            </table>
</div>
  </asp:Content>
