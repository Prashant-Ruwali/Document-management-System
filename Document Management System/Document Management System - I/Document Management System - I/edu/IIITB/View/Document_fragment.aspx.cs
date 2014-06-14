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
    public partial class Document_fragment : System.Web.UI.Page
    {
        IObjectContainer db,dbget;
        int flag = 1;
        Config path = new Config();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            Document_fragment_model document_fragment_model = new Document_fragment_model()
            {
                DocumentFragmentTitle = Text_name.Text,
                DocumentFragmentVersion = float.Parse(Text_version.Text),
                DocumentFragmentCreateDate = Convert.ToDateTime(Text_date.Text),
                DocumentFragmentContent = Text_content.Text,
                Keywords = Text_keywords.Text.Split(',').ToList(),
                List_documentFragmentAuthor = Text_authors.Text.Split(',').ToList()
            };

            dbget = Db4oFactory.OpenFile(path.addressofDocumentFragment);
            IList<Document_fragment_model> dbquery = dbget.Query<Document_fragment_model>();

            if (dbquery.Count > 0)
            {
                foreach (Document_fragment_model document_Fragment_Model in dbquery)
                {
                    if (document_fragment_model.DocumentFragmentTitle.Equals(document_Fragment_Model.DocumentFragmentTitle) && document_fragment_model.DocumentFragmentVersion.Equals(document_Fragment_Model.DocumentFragmentVersion))
                    {
                        flag = 0;
                        Text_name.Text = "";
                        Text_version.Text = "";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fragment Already present')", true);
                    }
                }
            }
            dbget.Close();

           if (flag == 1)
           {
               db = Db4oFactory.OpenFile(path.addressofDocumentFragment);
               db.Store(document_fragment_model);
               db.Close();

               Text_name.Text = "";
               Text_version.Text = "";
               Text_date.Text = "";
               Text_content.Text = "";
               Text_keywords.Text = "";
               Text_authors.Text = "";

               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fragment Saved Sucessfully')", true); 
           }
        }
 
      
    }
}