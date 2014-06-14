<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_group.aspx.cs" Inherits="Document_Management_System___I.edu.IIITB.View.Add_group" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<title> Create Group </title>
    <style type="text/css">
        .style1
        {
            width: 353px;
        }
        .style2
        {
            width: 118px;
        }
    </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>Add Group</h2>

    <table class="table table-striped" style="width:100%;">
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="Group Name *"></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="TextBox1" runat="server" required=true CssClass="form-control input-sm"></asp:TextBox>
               
                <asp:Button ID="Button2" runat="server" Text="Check Availability" 
                     CssClass="btn btn-search" onclick="Button2_Click" />
            </td>
        </tr>

        <tr>
            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="Select reviewers *"></asp:Label>
            </td>
            <td>
                <asp:CheckBoxList  CssClass="checkbox unstyled" ID="CheckBoxList1" runat="server">
                </asp:CheckBoxList>
            </td>
        </tr>
    </table>

    <center>
    <asp:Button ID="Button1" runat="server" Text="Submit"  CssClass="btn btn-info" onclick="Button1_Click" />
    </center>
</asp:Content>