using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Document_Management_System___I.edu.IIITB.Controller;
using Document_Management_System___I.edu.IIITB.Model;

namespace Document_Management_System___I.edu.IIITB.View
{
    public partial class Document : System.Web.UI.Page
    {
        IObjectContainer dbget;                                                // Create container object for database
        int flag=1;
        Config path = new Config();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dbget = Db4oFactory.OpenFile(path.addressOfGroup);
                IList<Group_model> dbqury = dbget.Query<Group_model>();

                if (dbqury.Count > 0)
                {
                    DropDownList2.Items.Add(new ListItem("Select a Workflow", "Select a Workflow"));
                    foreach (var List_element in dbqury)
                    {
                        DropDownList2.Items.Add(new ListItem(List_element.GroupName, List_element.GroupName));
                    }
                    DropDownList2.Items.Add(new ListItem("No Workflow", "No Workflow"));
                }
                dbget.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Document_model document = new Document_model()                      // Create a instance for document model
            {                                                                   // Add all the required value to from the form
                DocumentTitle = Textname.Text,
                DocumentVersion = float.Parse(Textversion.Text),
                DocumentCreateDate = Convert.ToDateTime(Textdate.Text),
                DocumentType = DropDownList1.SelectedValue,
                DocumentPublisher = TextPublisher.Text,
                DocumentWorkflow = DropDownList2.SelectedValue,
                Choice_of_level = DropDownList3.SelectedValue,
                List_documentKeywords = Textkeyword.Text.Split(',').ToList(),
                List_documentAuthor = TextAuthors.Text.Split(',').ToList(),
                List_documentFragment = new List<Document_fragment_model>(),
                List_reviever= new List<String>(),    
                DocumentStatus = "Pending",
                Count_document_reviever=0
            };                 
                                                      // Open database for storing file

            if (DropDownList2.SelectedValue.Equals("No Workflow"))
                document.DocumentStatus = "Complete";
                    
            Document_model document_model_proto = new Document_model()
            {
               DocumentTitle = Textname.Text,
               DocumentVersion = float.Parse(Textversion.Text)
            };

             dbget = Db4oFactory.OpenFile(path.addressOfDocument);
             IObjectSet result = dbget.QueryByExample(document_model_proto);

             if (result.HasNext())
             {
                 flag = 0;
                 Textname.Text = "";
                 Page.RegisterStartupScript("Alert&Redirect", "<script>alert('Document Already present');</script>");
             }

            dbget.Close();


            if (flag == 1)
            {
                Session.Add("document", document);

                Textname.Text = "";
                Textversion.Text = "";
                Textdate.Text = "";
                DropDownList1.SelectedValue = "";
                Textkeyword.Text = "";
                TextAuthors.Text = "";
                TextPublisher.Text = "";
                TextOrganization.Text = "";
                Response.Redirect("./Document_fragment_add.aspx");
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedItem.Text.Equals("No Workflow"))
            {
                DropDownList3.Enabled = false;
            }
            else
            {
                DropDownList3.Enabled = true;
            }
        }
    }
}