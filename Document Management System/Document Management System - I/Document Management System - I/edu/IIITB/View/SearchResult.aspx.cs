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
        IObjectContainer dbget, dbgetDoc;        
        Config path = new Config();       

        protected void Page_Load(object sender, EventArgs e)
        {
            display_data.Visible = false;
            download.Visible = false;
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            List<Document_model> resultDocuments = new List<Document_model>();
            resultDocuments = (List<Document_model>)context.Session["searchResultdocuments"];

            if (!IsPostBack)
            {               
                foreach (Document_model dm in resultDocuments )
                {
                    String data, key, revel;
                    data = "<a href= \"#\" style=\"Color : #000000; font-weight : bold;\">" + "Document :: " + dm.DocumentTitle + " : " + "version" + " " + dm.DocumentVersion + "</a>";
                    key = dm.DocumentTitle + ":" + dm.DocumentVersion;
                    CheckBoxList1.Items.Add(new ListItem(data, key));
                    revel = dm.DocumentTitle + dm.DocumentVersion;
                    foreach(Document_fragment_model df in dm.List_documentFragment)
                    {
                        data = "<a href= \"#\">" + "&nbsp;&nbsp;&nbsp;&nbsp;Fragment:: " + df.DocumentFragmentTitle + " : " + "version" + " " + df.DocumentFragmentVersion + "</a>";
                        key =df.DocumentFragmentTitle + ":" +df.DocumentFragmentVersion;
                        CheckBoxList1.Items.Add(new ListItem(data, key));
                        revel = df.DocumentFragmentTitle + df.DocumentFragmentVersion;
                    }
                }                              
            }                   
        }

        protected void fragmentDisplay_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            Boolean selected = false;
            display_data.Visible = true;
            foreach (ListItem item in CheckBoxList1.Items)
            {               
                if (item.Selected)
                {
                    selected = true;
                    display_data.Visible = true;
                    dbget = Db4oFactory.OpenFile(path.addressofDocumentFragment);
                    IList<Document_fragment_model> dbqury = dbget.Query<Document_fragment_model>();                   
                    dbgetDoc = Db4oFactory.OpenFile(path.addressOfDocument);
                    IList<Document_model> dbquryDoc = dbgetDoc.Query<Document_model>();

                    List<String> compare = new List<string>();
                    compare = item.Value.Split(':').ToList();

                    if (dbqury.Count > 0 || dbquryDoc.Count > 0)
                    {                       
                        // If Document Name is Seleced, Display all Fragments associated to it
                        try
                        {
                            if (item.Text.Substring(58, 11).Equals("Document ::"))
                            {
                                foreach (Document_model document in dbquryDoc)
                                {
                                    if (document.DocumentTitle.Equals(compare[0]) && document.DocumentVersion.Equals(float.Parse(compare[1])))
                                    {
                                        ListBox1.Items.Add("*********************************************************************************************************************");
                                        ListBox1.Items.Add("Name of The Document :  " + document.DocumentTitle);
                                        ListBox1.Items.Add("*********************************************************************************************************************");
                                        foreach (Document_fragment_model fragment in document.List_documentFragment)
                                        {
                                            //  if (fragment.DocumentFragmentTitle.Equals(compare[0]) && fragment.DocumentFragmentVersion.Equals(float.Parse(compare[1])))
                                            {
                                                ListBox1.Items.Add(".................................................................................................................");
                                                ListBox1.Items.Add("Name of The Fragment :  " + fragment.DocumentFragmentTitle);
                                                ListBox1.Items.Add(".................................................................................................................");
                                                ListBox1.Items.Add("Version of The Fragment :  " + fragment.DocumentFragmentVersion);
                                                ListBox1.Items.Add("");
                                                ListBox1.Items.Add("Createdate of The Fragment :  " + fragment.DocumentFragmentCreateDate);
                                                ListBox1.Items.Add("");
                                                ListBox1.Items.Add("Author of The Fragment :  ");
                                                foreach (String authors in fragment.List_documentFragmentAuthor)
                                                {
                                                    ListBox1.Items.Add(authors);
                                                }
                                                ListBox1.Items.Add("");
                                                ListBox1.Items.Add("    Keywords of The Fragment :  ");
                                                foreach (String keywords in fragment.Keywords)
                                                {
                                                    ListBox1.Items.Add(keywords);
                                                }
                                                ListBox1.Items.Add("");
                                                ListBox1.Items.Add("Content of The Fragment :  " + fragment.DocumentFragmentContent);
                                                ListBox1.Items.Add("");
                                                ListBox1.Items.Add("..............................................END OF FRAGMENT.....................................................");
                                            }
                                        }
                                        ListBox1.Items.Add("**********************************************END OF DOCUMENT*****************************************************");
                                    }
                                }
                            }
                            // Else Document Fragment of the Document is selected by user, just display Fragment  
                            else
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
                                        ListBox1.Items.Add("Author of The Fragment :  ");
                                        foreach (String authors in document_fragment_detail.List_documentFragmentAuthor)
                                        {
                                            ListBox1.Items.Add(authors);
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
                        } 
                        catch
                        {
                            // Else Document Fragment of the Document is selected by user, just display Fragment                            
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
                                        ListBox1.Items.Add("Author of The Fragment :  ");
                                        foreach (String authors in document_fragment_detail.List_documentFragmentAuthor)
                                        {
                                            ListBox1.Items.Add(authors);
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
                        }
                        Console.Out.WriteLine("Exception");
                    }
                    dbget.Close();
                    dbgetDoc.Close();
                }               
            }
            if (!selected)
            {
                ListBox1.Items.Add("");
                ListBox1.Items.Add("");
                ListBox1.Items.Add("");
                ListBox1.Items.Add("Please Select Document / Fragment to Display ");
                ListBox1.Items.Add("");
                ListBox1.Items.Add("");
            }    
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String filecontent = "";
            Config path = new Config();
            System.IO.StreamWriter file = new System.IO.StreamWriter(path.outputFilePath);
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                   // Boolean selected = false;
                   // display_data.Visible = true;
                    dbget = Db4oFactory.OpenFile(path.addressofDocumentFragment);
                    IList<Document_fragment_model> dbqury = dbget.Query<Document_fragment_model>();
                    dbgetDoc = Db4oFactory.OpenFile(path.addressOfDocument);
                    IList<Document_model> dbquryDoc = dbgetDoc.Query<Document_model>();

                    List<String> compare = new List<string>();
                    compare = item.Value.Split(':').ToList();

                    if (dbqury.Count > 0 || dbquryDoc.Count > 0)
                    {
                        // If Document Name is Seleced, Display all Fragments associated to it
                        try
                        {
                            if (item.Text.Substring(58, 11).Equals("Document ::"))
                            {
                                foreach (Document_model document in dbquryDoc)
                                {
                                    if (document.DocumentTitle.Equals(compare[0]) && document.DocumentVersion.Equals(float.Parse(compare[1])))
                                    {                                        
                                        filecontent += "\n\nName of The Document :  " + document.DocumentTitle + "\n\n";                                        
                                        foreach (Document_fragment_model fragment in document.List_documentFragment)
                                        {                                           
                                            filecontent += "Name of The Fragment  : " + fragment.DocumentFragmentTitle + "\n\n";                                            
                                            filecontent += "Content of The Fragment : \n" + fragment.DocumentFragmentContent + "\n\n";
                                        }                                      
                                    }
                                }
                            }
                            // Else Document Fragment of the Document is selected by user, just display Fragment  
                            else
                            {
                                foreach (Document_fragment_model document_fragment_detail in dbqury)
                                {
                                    if (document_fragment_detail.DocumentFragmentTitle.Equals(compare[0]) && document_fragment_detail.DocumentFragmentVersion.Equals(float.Parse(compare[1])))
                                    {
                                        filecontent += "Name of The Fragment  : " + document_fragment_detail.DocumentFragmentTitle + "\n\n";
                                        filecontent += "Content of The Fragment : \n" + document_fragment_detail.DocumentFragmentContent + "\n\n";
                                    }
                                }
                            }
                        }
                        catch
                        {
                            // Else Document Fragment of the Document is selected by user, just display Fragment                            
                            {
                                foreach (Document_fragment_model document_fragment_detail in dbqury)
                                {
                                    if (document_fragment_detail.DocumentFragmentTitle.Equals(compare[0]) && document_fragment_detail.DocumentFragmentVersion.Equals(float.Parse(compare[1])))
                                    {
                                        filecontent += "\n\nName of The Fragment  : " + document_fragment_detail.DocumentFragmentTitle + "\n";
                                        filecontent += "\nContent of The Fragment :\n" + document_fragment_detail.DocumentFragmentContent + "\n\n";
                                    }
                                }
                            }
                        }
                        Console.Out.WriteLine("Exception");
                    }
                    dbget.Close();
                    dbgetDoc.Close();                              
                }
            }
            file.WriteLine(filecontent);
            file.Close();
            download.Visible = true;         
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Search.aspx");
        }
    }
}