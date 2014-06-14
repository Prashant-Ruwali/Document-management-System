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
    public partial class Document_Fragment_Review : System.Web.UI.Page
    {
        IObjectContainer DB;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            String docname_versionOfDoc;
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            docname_versionOfDoc=(String)context.Session["docNameVersionNo"];
            List<String> compare = new List<string>();
            string docname;
            float versionOfDoc;
            compare = docname_versionOfDoc.Split(':').ToList();
            docname = compare[0];
            versionOfDoc = float.Parse(compare[1]);
            

            try
            {
                
                Config path = new Config();
                DB = Db4oFactory.OpenFile(path.addressOfDocument);
                IList<Document_model> document = DB.Query<Document_model>();
                if (document.Count > 0)
                {
                    foreach (Document_model l1 in document)
                    {
                        
                        {
                            if (l1.DocumentTitle.Equals(docname)&&l1.DocumentVersion.Equals(versionOfDoc))
                            {
                                ListBox1.Items.Add(".....................................................................................................................");
                                ListBox1.Items.Add("Name of the Document: "+l1.DocumentTitle);
                                ListBox1.Items.Add(".....................................................................................................................");
                                ListBox1.Items.Add("");
                                ListBox1.Items.Add("Version of the Document : " + l1.DocumentVersion.ToString());
                                ListBox1.Items.Add("");
                                ListBox1.Items.Add("Type of the Document : " + l1.DocumentType);
                                ListBox1.Items.Add("");
                                ListBox1.Items.Add("Publisher Name of the Document : " + l1.DocumentPublisher);
                                ListBox1.Items.Add("");
                                ListBox1.Items.Add("Content of the Document : ");
                                foreach(Document_fragment_model data in l1.List_documentFragment)
                                    ListBox1.Items.Add(data.DocumentFragmentContent);
                                ListBox1.Items.Add("");
                                ListBox1.Items.Add("");
                                ListBox1.Items.Add("..................................................END OF DOCUMENT................................................");
                            }
                            
                        }
                    }

                }
                else
                {
                    Response.Write("not working");
                }
                DB.Close();
            }
            catch
            {
            }

        }

        protected void Add_Document_for_User_Click(object sender, EventArgs e)
        {
            int count;
            string docname;
         
            float versionOfDoc;
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string docname_versionOfDoc = (String)context.Session["docNameVersionNo"];
            List<String> compare = new List<string>();
            compare = docname_versionOfDoc.Split(':').ToList();
            docname = compare[0];
            versionOfDoc = float.Parse(compare[1]);
            string username = (string)Session["UserName"];
            try
            {
                
                Config path = new Config();
                DB = Db4oFactory.OpenFile(path.addressOfDocument);
                IObjectSet result = DB.QueryByExample(new Document_model(docname,versionOfDoc));
                Document_model docmodel=(Document_model)result.Next();
                 count = docmodel.Count_document_reviever-1;
                 docmodel.Count_document_reviever = count;
                 docmodel.List_reviever.Remove(username);
                
                 if (docmodel.Count_document_reviever == 0)
                 {
                     docmodel.DocumentStatus = "Complete";
                 }
                   
                DB.Ext().Store(docmodel,3);
                
                DB.Close();
                Page.RegisterStartupScript("Alert&Redirect", "<script>alert('Review Successfull!!'); location.href='./Document_page.aspx';</script>");
               }
            catch
            {
            }

        }

        protected void Discard_Document_Click(object sender, EventArgs e)
        {
            string docname;
            float versionOfDoc;
            string reasonToDiscard;
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string docname_versionOfDoc = (String)context.Session["docNameVersionNo"];
            List<String> compare = new List<string>();
            compare = docname_versionOfDoc.Split(':').ToList();
            docname = compare[0];
            versionOfDoc = float.Parse(compare[1]);
            string username = (string)Session["UserName"];
            reasonToDiscard = Textuser.Text;
            if (reasonToDiscard.Equals(""))
            {
                reasonToDiscard = "Reason to discard is not specified";
            }
            else
            {
            }
            try
            {
                Config path = new Config();
                DB = Db4oFactory.OpenFile(path.addressOfDocument);

                IObjectSet result = DB.QueryByExample(new Document_model(docname,versionOfDoc));
                Document_model docmodel = (Document_model)result.Next();
                DB.Delete(docmodel);
                DB.Close();

                Discarded_Document_model document_fragment_model = new Discarded_Document_model()
                {
                    ReasonToDiscard = reasonToDiscard,
                    DocumentTitle = docname,
                    DocumentVersion = versionOfDoc,
                    NameOfReviever = username
                };

                DB = Db4oFactory.OpenFile(path.addressOfDiscardedDocument);
                DB.Store(document_fragment_model);
                DB.Close();

                Page.RegisterStartupScript("Alert&Redirect", "<script>alert('Document Discarded Sucessfully'); location.href='./Document_page.aspx';</script>"); 
                
            }
            catch
            {
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Show", "<script> $('#myModal').modal('toggle');</script>");
        }
    }
}