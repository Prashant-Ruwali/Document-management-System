<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Document.aspx.cs" Inherits="Document_Management_System___I.edu.IIITB.View.Document" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<title> Create Document </title> 

 <link href="../../../Styles/jquery-ui.css" rel="Stylesheet" type="text/css" />

 <script type="text/javascript" src="../../../Scripts/jquery-1.6.min.js"></script>
 <script type="text/javascript" src="../../../Scripts/jquery-ui.js"></script>
 <script type="text/javascript">
     $(function () {
         $("[id$=Textdate]").datepicker({
             showOn: 'button',
             buttonImageOnly: true,
             buttonImage: '../../../Images/calendar.gif'
         });
     });
    </script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <h2>Document Page</h2>

    <table class="table table-striped" style="width:100%;">
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="Name of the Document *"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Textname" runat="server" Width="381px" required=true
                    CssClass="form-control input-sm"></asp:TextBox>
            </td>
        </tr>

         <tr>
            <td class="style1">
                <asp:Label ID="Label6" runat="server" Text="Version of the Document *"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Textversion" runat="server" Width="381px" required=true
                    CssClass="form-control input-sm"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="Textversion" 
                    ErrorMessage="Please enter valid version number" ForeColor="#CC0000" 
                    ValidationExpression="[0-9]+(\.[0-9]+)"></asp:RegularExpressionValidator>
            </td>
        </tr>

        <tr>
            <td class="style1">
                <asp:Label ID="Label3" runat="server" Text="Date *"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Textdate" runat="server" Width="381px" required=true
                    CssClass="form-control input-sm"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="style1">
                <asp:Label ID="Label4" runat="server" Text="Type *"></asp:Label>
            </td>
            <td>
                <asp:DropDownList  ID="DropDownList1" CssClass="form-control" runat="server">
                    <asp:ListItem Value="0">Choose Type </asp:ListItem>
                    <asp:ListItem Value="Design Document">Design Document</asp:ListItem>
                    <asp:ListItem Value="Technical Specification Document">Technical Specification Document</asp:ListItem>
                    <asp:ListItem Value="Software Specification Document">Software Specification Document</asp:ListItem>
                    <asp:ListItem Value="Article">Article</asp:ListItem>
                    <asp:ListItem Value="Brochure">Brochure</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="style1">
                <asp:Label ID="Label9" runat="server" Text="Workflow *"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                   CssClass="form-control" onselectedindexchanged="DropDownList2_SelectedIndexChanged" ></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label10" runat="server" Text="Choice to verify *"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server" >
                    <asp:ListItem Value="0">Choose verification strategy</asp:ListItem>
                    <asp:ListItem Value="1">VerifybySingleReviewer</asp:ListItem>
                    <asp:ListItem Value="2">VerifybyAllReviewers</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>


        <tr>
            <td class="style1">
                <asp:Label ID="Label2" runat="server" Text="Keywords *"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Textkeyword" runat="server" Width="381px" required="true"
                    CssClass="form-control input-sm"></asp:TextBox>
            </td>
        </tr>

         <tr>
            <td class="style1">
                <asp:Label ID="Label7" runat="server" Text="Authors *"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextAuthors" runat="server" Width="381px" required=true
                    CssClass="form-control input-sm"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="style1">
                <asp:Label ID="Label8" runat="server" Text="Publisher *"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextPublisher" runat="server" Width="381px" required=true
                    CssClass="form-control input-sm" ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="style1">
                <asp:Label ID="Label5" runat="server" Text="Organization *"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextOrganization" runat="server" Width="381px" CssClass="form-control input-sm" ></asp:TextBox>
            </td>
        </tr>

            <td class="style1" colspan="2">
            <center>
                <asp:button ID="Button2" Text="Submit" runat="server" Width="192px" 
                   CssClass="btn btn-info" onclick="Button2_Click"/>
            </center>
            </td>
        </tr>
    </table>

</asp:Content>