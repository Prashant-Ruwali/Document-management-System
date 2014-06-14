using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using System.Web.UI.WebControls;
using Document_Management_System___I.edu.IIITB.Model;
using Document_Management_System___I.edu.IIITB.Controller;


namespace Document_Management_System___I.edu.IIITB.View
{
    public partial class View_Groups : System.Web.UI.Page
    {
        IObjectContainer DB,DBG,DBU;
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string docname = (string)Session["RBValue"];
            Response.Write(Session["RBValue"]);
            int i, flag = 0, flag1 = 0;
            try
            {

                Config path = new Config();
                DB = Db4oFactory.OpenFile(path.addressOfDocument);
                DBG = Db4oFactory.OpenFile(path.addressOfGroup);
                DBU = Db4oFactory.OpenFile(path.addressOfUser);
                IList<Document_model> doc = DB.Query<Document_model>();
                IList<Group_model> group = DBG.Query<Group_model>();
                IList<User_model> user = DBU.Query<User_model>();
                if (group.Count > 0)
                {
                    
                    foreach (Group_model g1 in group)
                    {
                        flag = 0;
                        ListBox1.Items.Add(".....................................................................................................................");
                        ListBox1.Items.Add("Group Name:  "+g1.GroupName);
                        ListBox1.Items.Add(".....................................................................................................................");
                        ListBox1.Items.Add("");
                        ListBox1.Items.Add("Users: ");
                        ListBox1.Items.Add("");
                        foreach (User_model u1 in g1.List_userModel)
                        {
                            
                            ListBox1.Items.Add(u1.UserName);
                        }
                        ListBox1.Items.Add("");
                        ListBox1.Items.Add("");
                        ListBox1.Items.Add("List of documents to be reviewed: ");
                        ListBox1.Items.Add("");
                        i = 1;
                        foreach (Document_model d1 in doc)
                        {
                            if (d1.DocumentWorkflow.Equals(g1.GroupName) && d1.DocumentStatus.Equals("Pending"))
                            {
                                ListBox1.Items.Add(i+". "+d1.DocumentTitle +" & Version : " + d1.DocumentVersion);
                                ListBox1.Items.Add("");
                                flag = 1;
                                i++;
                            }
                        }
                  
                        if (flag == 0)
                        {
                            ListBox1.Items.Add("No documents to review");
                            ListBox1.Items.Add("");
                             
                        }
                        ListBox1.Items.Add("");
                        ListBox1.Items.Add("List of documents reviewed: ");
                        ListBox1.Items.Add("");
                        i = 1;
                        foreach (Document_model d1 in doc)
                        {
                            if (d1.DocumentWorkflow.Equals(g1.GroupName) && d1.DocumentStatus.Equals("Complete"))
                            {
                                ListBox1.Items.Add(i + ". " + d1.DocumentTitle);
                                ListBox1.Items.Add("");
                                flag1 = 1;
                                i++;
                            }
                        }
                        if (flag1 == 0)
                        {
                            ListBox1.Items.Add("No documents to review");
                            ListBox1.Items.Add("");

                        }
                   
                    }
                }
                else
                {
                    ListBox1.Items.Add("Sorry no groups to display");
                    
                }
                ListBox1.Items.Add("--------------------------------------------------------------------END----------------------------------------------------------------------");
                DB.Close();
                DBG.Close();
                DBU.Close();
            }
            catch
            {
            }

        }
    }
}