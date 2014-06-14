<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Document_Management_System___I.edu.IIITB.View.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<title> Search </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<center>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/621-h_main-w.png" />
    <br />
    <asp:TextBox ID="SearchKeyword" runat="server" Height="34px" 
        style="margin-top: 59px" Width="409px"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" 
        style="margin-top: 43px" Text="Submit" Width="147px" CssClass="btn btn-info" onclick="Button1_Click" />
 </center> 
</asp:Content>
