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
    public partial class WebForm2 : System.Web.UI.Page
    {
        IObjectContainer DB;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0, flag = 0, PageFlag = 0;
                Config path = new Config();
                DB = Db4oFactory.OpenFile(path.addressOfDocument);
                IList<Document_model> allDocumentList = DB.Query<Document_model>();
                List<Document_model> resultDocuments = new List<Document_model>();
                List<String> searchKeywordList = new List<string>();
                searchKeywordList =  SearchKeyword.Text.Split(',').ToList();
               
                if (allDocumentList.Count > 0)
                {
                    foreach (Document_model l1 in allDocumentList)
                    {
                        foreach (String key in l1.List_documentKeywords)
                        {
                            foreach(String searchKeyword in searchKeywordList)
                            {
                                if ((key.Trim().Equals(searchKeyword.Trim())) && (l1.DocumentStatus.Equals("Complete")))
                                {                               
                                    flag = 1;
                                    break;
                                }
                            }
                        }
                        if (flag == 1)
                        {
                            resultDocuments.Add(l1);
                            flag = 0;
                            PageFlag = 1;
                        }
                    }
                    Session["searchKey"] = SearchKeyword.Text;
                    Session["searchResultdocuments"] = resultDocuments;


                }
                if (PageFlag != 1)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No relevant results found')", true);
                }

                DB.Close();
                Response.Redirect("./SearchResult.aspx");
            }
            catch
            {
            }


        }
 
    }
}