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

    public partial class Document_Page : System.Web.UI.Page
    {
        IObjectContainer DB,DBG,DBU;
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = (string)Session["UserName"];
            string stringVersion;
            try
            {
                if (!IsPostBack)
                {
                    Config path = new Config();
                    DB = Db4oFactory.OpenFile(path.addressOfDocument);
                    DBG = Db4oFactory.OpenFile(path.addressOfGroup);
                    DBU = Db4oFactory.OpenFile(path.addressOfUser);

                    IList<Document_model> Alldocname = DB.Query<Document_model>();
                    IList<Group_model> dbqury = DBG.Query<Group_model>();
                    IList<User_model> user = DBU.Query<User_model>();

                    foreach (Document_model l1 in Alldocname)
                    {
                        foreach (Group_model g1 in dbqury)
                        {
                            if(g1.GroupName.Equals(l1.DocumentWorkflow))
                            {
                                if (l1.DocumentStatus.Equals("Pending"))
                                {
                                    foreach (string i in l1.List_reviever)
                                    {
                                        if ((i.Equals(username)))
                                        {
                                            RadioButtonList1.Items.Add(new ListItem(l1.DocumentTitle + " V" + l1.DocumentVersion, l1.DocumentTitle + ":" +l1.DocumentVersion));
                                          
                                        }
                                    }
                                }
                            }
                        }
                    }
                    DB.Close();
                    DBG.Close();
                    DBU.Close();
                }
            }
            catch
            {

            }

        }

        public IEnumerable<string> DocumentTitle { get; set; }

        protected void Submit_title_Click(object sender, EventArgs e)
        {
            int flag = 0;
            String docNameVersion;
                foreach (ListItem item in RadioButtonList1.Items)
                {

                    if (item.Selected)
                    {
                        docNameVersion = RadioButtonList1.SelectedItem.Value;
                        Session.Add("docNameVersionNo", docNameVersion);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Document fragment!!')", true);
                        Response.Redirect("./Document_Fragment_Review.aspx");
                    }
                    else
                    {
                         ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select at least one of the checkboxes')", true);
                    }
      
            }
        }
    }
}
