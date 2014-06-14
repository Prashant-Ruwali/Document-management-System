<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="Document_Management_System___I.edu.IIITB.View.SearchResult1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <div>
    <h2>Documents Containing Keyword:</h2>
    <p> Please Select any Document </p>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        </asp:RadioButtonList>
        <br /><br />
        <asp:Button ID="Button1" runat="server" Text="Veiw Document" 
            onclick="Button1_Click" />
             &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
             <asp:Button ID="Button2" runat="server" Text="Back" onclick="Button2_Click" />
    </div>
</asp:Content>
