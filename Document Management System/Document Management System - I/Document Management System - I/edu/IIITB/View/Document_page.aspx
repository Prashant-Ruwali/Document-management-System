<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Document_Page.aspx.cs" Inherits="Document_Management_System___I.edu.IIITB.View.Document_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<title> List of Document </title>
<style type="text/css">
.rbshipcons
{
    margin-left: 5px;
    font-family: Arial, Helvetica, sans-serif;
    font-size: 14px;
    display: inline;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


        <h2>List of Documents</h2>
        <div>
      
            <asp:RadioButtonList ID="RadioButtonList1" CssClass="rbshipcons" runat="server">
            </asp:RadioButtonList>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
            <asp:Button ID="Submit_title" runat="server" Text="Get Document" 
                CssClass="btn btn-info" onclick="Submit_title_Click" style="margin-left: 296px" />
        </div>
</asp:Content>
