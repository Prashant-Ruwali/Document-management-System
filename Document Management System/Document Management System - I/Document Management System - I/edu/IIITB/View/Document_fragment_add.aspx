<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Document_fragment_add.aspx.cs" Inherits="Document_Management_System___I.edu.IIITB.View.Document_fragment_add" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<title> Add Fragment To Document</title>
<link href="../../../Styles/reveal.css" rel="Stylesheet" type="text/css" />
<script type="text/javascript" src="../../../Scripts/jquery-1.6.min.js"></script>
<script type="text/javascript" src="../../../Scripts/jquery.reveal.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2>Document Fragment</h2>
    <div class="col-md-12">
    <div class="col-md-6">
    <table class="table table-striped" style="width:100%;">

        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="List of the Frgament present for the fragments"></asp:Label>
            </td>
       </tr>

       <tr>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
               CssClass="checkbox unstyled" onselectedindexchanged="CheckBoxList1_SelectedIndexChanged">
              
        </asp:CheckBoxList> 
        <div id="myModal" class="reveal-modal">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
	    </div>  
       </tr>

    </table>
    
    <table class="table table-striped" style="width:100%;">  
        <tr>
            <td class="style1">
                <asp:Button ID="Button1" runat="server" Text="Add all the selected Fragments" 
                    CssClass="btn btn-info" onclick="Button1_Click" />
            </td>
            <td class="style1">
                <asp:Button ID="fragmentDisplay" runat="server" Text="Show Fragment" 
                    CssClass="btn btn-info" onclick="fragmentDisplay_Click"/>
            </td>
            <td class="style1">
                <asp:Button ID="flatten" runat="server" Text="Flatten" CssClass="btn btn-info" 
                    onclick="flatten_Click"/>
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