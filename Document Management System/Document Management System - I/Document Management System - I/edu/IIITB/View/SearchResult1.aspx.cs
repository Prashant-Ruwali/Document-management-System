using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Document_Management_System___I.edu.IIITB.Model;
using Document_Management_System___I.edu.IIITB.Controller;


namespace Document_Management_System___I.edu.IIITB.View
{
    public partial class SearchResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            List<Document_model> resultDocuments = new List<Document_model>();
            resultDocuments = (List<Document_model>)Session["searchResult"];
            if (!IsPostBack)
            {
                foreach (Document_model doc in resultDocuments)
                {
                    RadioButtonList1.Items.Add(new ListItem(doc.DocumentTitle, doc.DocumentTitle));
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in RadioButtonList1.Items)
            {
                if (item.Selected)
                {
                    Response.Write(RadioButtonList1.SelectedItem.Value);
                    Session["selectedDoc"] = RadioButtonList1.SelectedItem.Value;
                    Response.Redirect("./showSelectedSearchDocument.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select at least one of the documents')", true);
                }

            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Search.aspx");
        }
    }
}