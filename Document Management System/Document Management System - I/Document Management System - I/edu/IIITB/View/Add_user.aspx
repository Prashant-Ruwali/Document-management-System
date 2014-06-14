<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_user.aspx.cs" Inherits="Document_Management_System___I.edu.IIITB.View.Add_user" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<title> Create User </title>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>Add User</h2>

     <table class="table table-striped" style="width:100%;">

        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="Full Name : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Textfullname" runat="server" Width="277px" CssClass="form-control input-sm" required=true></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Password : " ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Textpassword" runat="server" Width="277px" TextMode="Password" CssClass="form-control input-sm" required=true></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="Username : " ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Textusername" runat="server" Width="277px" CssClass="form-control input-sm" required=true></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="Check Availability" 
                     CssClass="btn btn-search" onclick="Button2_Click" />
            </td>
        </tr>

        <tr>
            <td class="style2">
                <asp:Label ID="Label5" runat="server" Text="Email Id : " TextMode="Email"></asp:Label>
            </td>
            <td>
               <asp:TextBox ID="Textemail" runat="server" Width="277px" CssClass="form-control input-sm" required=true></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="Textemail" ErrorMessage="Please enter a valid email" 
                ForeColor="#CC0000" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>           
            </td>
        </tr>

        <tr>
            <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="Enter Role : "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList_usertype" CssClass="form-control" runat="server">
                    <asp:ListItem>Select a Type</asp:ListItem>
                    <asp:ListItem>Admin</asp:ListItem>
                    <asp:ListItem>Reviewer</asp:ListItem>
                    <asp:ListItem>User</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

          <tr>
            <td class="style1">
                <br />
            </td>
            <td>
                <br />
            </td>
        </tr>

        <tr>
            <td class="style1" colspan="2">
                <center>
                    <asp:Button ID="Button1" runat="server" Text="Submit"  CssClass="btn btn-info" onclick="Button1_Click" />
                </center>
            </td>
        </tr>

    </table>   
</asp:Content>