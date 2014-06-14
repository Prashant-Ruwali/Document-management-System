<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="Document_Management_System___I.edu.IIITB.View.SearchResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<title>Create Document On Result</title>
<style type="text/css">
.rbshipcons
{
    margin-left: 5px;
    font-family: Arial, Helvetica, sans-serif;
    font-size: 14px;
    display: inline;
}
    .style1
    {
        width: 411px;
    }
    .style2
    {
        width: 333px;
    }
</style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2>Search Result</h2>
    <div class="col-md-12">
    <div class="col-md-6">
    <table class="table table-striped" style="width:100%;">

        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="List of the Frgament with Search Keywords"></asp:Label>
            </td>
       </tr>

       <tr>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
               CssClass="checkbox unstyled" >
              
        </asp:CheckBoxList> 
        <div id="myModal" class="reveal-modal">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
	    </div>  
       </tr>

    </table>
    
    <table class="table table-striped" style="width:100%;">  
        <tr>
            <td class="style2">
                 <asp:Button ID="GenerateDocument" runat="server" Text="Generate Document" CssClass="btn btn-info" 
                    onclick="Button1_Click" />
            </td>
            <td class="style1">
                <asp:Button ID="fragmentDisplay" runat="server" Text="Show Content" 
                    CssClass="btn btn-info" onclick="fragmentDisplay_Click" Width="100px"/>
            </td>
            <td class="style1">
               <!--- <asp:Button ID="flatten" runat="server" Text="Flatten" CssClass="btn btn-info" />--->
                <asp:Button ID="back" runat="server" Text="Back" CssClass="btn btn-info" 
                    onclick="back_Click" Width="100px" />
            </td>
       </tr>
       <tr>
        <td class="style2" colspan="3">
            <div id="download" runat="server">
                <p><b>Please Download Document From :<a href ="../Document/document.txt" target="_blank" > Here</a></b></p>
            </div>
        </td>
       </tr>
     </table>        
     </div>
      <div class="col-md-6">
            <div ID="display_data" runat="server" style="overflow:auto; Width:400px; Height:auto">
                <asp:ListBox ID="ListBox1" runat="server" Height="350px" >
                </asp:ListBox>
            </div>
      </div>
      </div>
</asp:Content>