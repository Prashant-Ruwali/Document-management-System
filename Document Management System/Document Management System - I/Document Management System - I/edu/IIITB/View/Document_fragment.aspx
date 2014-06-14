<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Document_fragment.aspx.cs" Inherits="Document_Management_System___I.edu.IIITB.View.Document_fragment" %>
 
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<title> Create Fragment </title>

 <link href="../../../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

 <script type="text/javascript" src="../../../Scripts/jquery-1.6.min.js"></script>
 <script type="text/javascript" src="../../../Scripts/jquery-ui.js"></script>
<script type="text/javascript">
    $(function () {
        $("[id$=Text_date]").datepicker({
            showOn: 'button',
            buttonImageOnly: true,
            buttonImage: '../../../Images/calendar.gif'
        });
    });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
 
    <h2>Document Fragment Entry</h2>

    <table class="table table-striped" style="width:100%;">

        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="Name of the Fragment *"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Text_name" runat="server" Width="377px" required=true 
                    CssClass="form-control input-sm"></asp:TextBox>
            </td>
       </tr>

       <tr>
            <td class="style1">
                <asp:Label ID="Label5" runat="server" Text="Version of the Fragment *"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Text_version" runat="server" Width="377px" required=true
                    CssClass="form-control input-sm"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="Text_version" 
                    ErrorMessage="Please enter valid version number" ForeColor="#CC0000" 
                    SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9]+)"></asp:RegularExpressionValidator>
            </td>
       </tr>

        <tr>
            <td class="style1">
                <asp:Label ID="Label2" runat="server" Text="Date *"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Text_date" runat="server" Width="377px" required=true
                    CssClass="form-control input-sm"></asp:TextBox>
            </td>
       </tr>

         <tr>
            <td class="style1">
                <asp:Label ID="Label4" runat="server" Text="Keywords *"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Text_keywords" runat="server" Width="377px" required=true
                    CssClass="form-control input-sm"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="style1">
                <asp:Label ID="Label6" runat="server" Text="Authors *"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Text_authors" runat="server" Width="377px" required=true
                    CssClass="form-control input-sm"></asp:TextBox>
            </td>
        </tr>

       <tr>
            <td class="style1">
                <asp:Label ID="Label3" runat="server" Text="Content *"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Text_content" runat="server" Width="377px" Height="189px" Rows="10" 
                 Wrap="True" TextMode="MultiLine" style="overflow:auto;" required=true
                    CssClass="form-control input-sm"></asp:TextBox>
                
            </td>
        </tr>
        
</table>
           <center>
                <asp:Button ID="Button2" runat="server" Text="Submit" Width="192px" 
                    CssClass="btn btn-info" onclick="Button2_Click"/>
           </center>
    
</asp:Content>