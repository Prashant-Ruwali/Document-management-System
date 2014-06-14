<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View_rejected.aspx.cs" Inherits="Document_Management_System___I.edu.IIITB.View.View_rejected" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListBox ID="ListBox1" runat="server" Height="533px" Width="912px" 
                      style="margin-left: 0px" 
        onselectedindexchanged="ListBox1_SelectedIndexChanged">
                </asp:ListBox>
</asp:Content>