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
    public partial class Document_fragment_add : System.Web.UI.Page
    {
        IObjectContainer dbget,db,dbqury1;
        Document_model document_model;
        Config path = new Config();
        int flag = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            display_data.Visible = false;
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            document_model = (Document_model)context.Session["document"];

            if (!IsPostBack)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Document Added, add Fragments to save it to Database')", true);

                foreach (var List_element in document_model.List_documentKeywords)
                {
                    dbget = Db4oFactory.OpenFile(path.addressofDocumentFragment);
                    IList<Document_fragment_model> dbqury = dbget.Query<Document_fragment_model>();

                    if (dbqury.Count > 0)
                    {
                        foreach (Document_fragment_model document_fragment_detail in dbqury)
                        {
                            for (int i = 0; i < document_fragment_detail.Keywords.Count; i++)
                            {
                                if ((document_fragment_detail.Keywords[i]).Trim().Equals((List_element).Trim()))
                                {
                                    String data,key,revel;
                                    data = "<a href= \"#\">" +document_fragment_detail.DocumentFragmentTitle + " "  +"version" + " " +document_fragment_detail.DocumentFragmentVersion +"</a>" ;
                                    key = document_fragment_detail.DocumentFragmentTitle + ":" + document_fragment_detail.DocumentFragmentVersion;
                                    CheckBoxList1.Items.Add(new ListItem(data, key));
                                    revel = document_fragment_detail.DocumentFragmentTitle + document_fragment_detail.DocumentFragmentVersion;
                                }
                            }
                        }
                    }
                    dbget.Close();
                }
            }
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> compare = new List<string>();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String docname;
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    dbget = Db4oFactory.OpenFile(path.addressofDocumentFragment);
                    IList<Document_fragment_model> dbqury = dbget.Query<Document_fragment_model>();
                    List<String> compare = new List<string>();
                    compare = item.Value.Split(':').ToList();
                    if (dbqury.Count > 0)
                    {
                        foreach (Document_fragment_model document_fragment_detail in dbqury)
                        {
                            if (document_fragment_detail.DocumentFragmentTitle.Equals(compare[0]) && document_fragment_detail.DocumentFragmentVersion.Equals(float.Parse(compare[1])))
                            {
                                document_model.List_documentFragment.Add(document_fragment_detail);
                                flag = 1;
                            }
                        }
                    }
                    dbget.Close();
                }
            }
            docname=document_model.DocumentTitle;
            if (flag == 1)
            {
                int count = 0;
                db = Db4oFactory.OpenFile(path.addressOfDocument);
                dbqury1 = Db4oFactory.OpenFile(path.addressOfGroup);
                IList<Group_model> group = dbqury1.Query<Group_model>();
                
                foreach (Group_model g1 in group)
                {
                    if (g1.GroupName.Equals(document_model.DocumentWorkflow))
                    {
                        foreach (User_model u1 in g1.List_userModel)
                        {
                            count++;
                          document_model.List_reviever.Add(u1.Name);

                        }
                    }
                }
               if (document_model.Choice_of_level.Equals("2"))
                {

                    document_model.Count_document_reviever = count;
                    Response.Write("doc count is " + document_model.Count_document_reviever);
                }
                else
                {
                    document_model.Count_document_reviever = 1;
                }
               CheckBoxList1.SelectedIndex = -1;
               db.Store(document_model);
               db.Close();
               dbqury1.Close();
               Page.RegisterStartupScript("Alert&Redirect", "<script>alert('Document Saved Sucessfully'); location.href='./Document.aspx';</script>");
            }
        }

        protected void flatten_Click(object sender, EventArgs e)
        {
            dbget = Db4oFactory.OpenFile(path.addressofDocumentFragment);
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    IList<Document_fragment_model> dbqury = dbget.Query<Document_fragment_model>();
                    List<String> compare = new List<string>();
                    compare = item.Value.Split(':').ToList();
                    if (dbqury.Count > 0)
                    {
                        foreach (Document_fragment_model document_fragment_detail in dbqury)
                        {
                            if (document_fragment_detail.DocumentFragmentTitle.Equals(compare[0]) && document_fragment_detail.DocumentFragmentVersion.Equals(float.Parse(compare[1])))
                            {
                                document_model.List_documentFragment.Add(document_fragment_detail);
                            }
                        }
                    }
                }
            }

               Document_fragment_model documentFragmentModel = new Document_fragment_model()
               {
                    DocumentFragmentTitle = document_model.DocumentTitle,
                    DocumentFragmentVersion = document_model.DocumentVersion,
                    DocumentFragmentCreateDate = document_model.DocumentCreateDate,
                    List_documentFragmentAuthor = document_model.List_documentAuthor,
                    Keywords = document_model.List_documentKeywords
               };
                
               foreach(Document_fragment_model document_detail in document_model.List_documentFragment)
               {
                    documentFragmentModel.DocumentFragmentContent += document_detail.DocumentFragmentContent;
               }
               dbget.Close();


               dbget = Db4oFactory.OpenFile(path.addressofDocumentFragment);
               IList<Document_fragment_model> dbqurycheck = dbget.Query<Document_fragment_model>();
               if (dbqurycheck.Count > 0)
               {
                   foreach (Document_fragment_model document_fragment_detail in dbqurycheck)
                   {
                       if (document_fragment_detail.DocumentFragmentTitle.Equals(documentFragmentModel.DocumentFragmentTitle) && document_fragment_detail.DocumentFragmentVersion.Equals(documentFragmentModel.DocumentFragmentVersion))
                       {
                           flag = 1;
                       }
                   }
               }
               if (flag == 1)
               {
                   dbget.Close();
                   Page.RegisterStartupScript("Alert&Redirect", "<script>alert('DocumentFragment already present'); location.href='./Document.aspx';</script>");
               }
               else
               {
                   dbget.Store(documentFragmentModel);
                   dbget.Close();
                   Page.RegisterStartupScript("Alert&Redirect", "<script>alert('Fragment Created and Saved Sucessfully'); location.href='./Document.aspx';</script>");
               }
               
        }

        protected void fragmentDisplay_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    display_data.Visible = true;
                    dbget = Db4oFactory.OpenFile(path.addressofDocumentFragment);
                    IList<Document_fragment_model> dbqury = dbget.Query<Document_fragment_model>();
                    List<String> compare = new List<string>();
                    compare = item.Value.Split(':').ToList();
                    if (dbqury.Count > 0)
                    {
                        foreach (Document_fragment_model document_fragment_detail in dbqury)
                        {
                            if (document_fragment_detail.DocumentFragmentTitle.Equals(compare[0]) && document_fragment_detail.DocumentFragmentVersion.Equals(float.Parse(compare[1])))
                            {
                                ListBox1.Items.Add(".....................................................................................................................");
                                ListBox1.Items.Add("Name of The Fragment :  " + document_fragment_detail.DocumentFragmentTitle);
                                ListBox1.Items.Add(".....................................................................................................................");
                                ListBox1.Items.Add("Version of The Fragment :  " + document_fragment_detail.DocumentFragmentVersion);
                                ListBox1.Items.Add("");
                                ListBox1.Items.Add("Createdate of The Fragment :  " + document_fragment_detail.DocumentFragmentCreateDate);
                                ListBox1.Items.Add("");
                                ListBox1.Items.Add("Author of The Fragment :  " );
                                 foreach (String authors in document_fragment_detail.List_documentFragmentAuthor)
                                 {
                                     ListBox1.Items.Add(authors );
                                 }
                                ListBox1.Items.Add("");
                                 ListBox1.Items.Add("Keywords of The Fragment :  ");
                                 foreach (String keywords in document_fragment_detail.Keywords)
                                 {
                                     ListBox1.Items.Add(keywords);
                                 }
                                ListBox1.Items.Add("");
                                ListBox1.Items.Add("Content of The Fragment :  " + document_fragment_detail.DocumentFragmentContent);
                                ListBox1.Items.Add("");
                                ListBox1.Items.Add("...............................................END OF FRAGMENT.......................................................");
                            }
                        }
                    }
                    else
                    {
                        ListBox1.Items.Add("");
                        ListBox1.Items.Add("");
                        ListBox1.Items.Add("");
                        ListBox1.Items.Add("Select a valid document to disply ");
                        ListBox1.Items.Add("");
                        ListBox1.Items.Add("");
                    }
                    dbget.Close();
                }
            }
        }

                
    }
}