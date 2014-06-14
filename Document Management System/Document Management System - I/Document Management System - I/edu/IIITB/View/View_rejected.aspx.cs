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
    public partial class View_rejected : System.Web.UI.Page
    {
        IObjectContainer DB;
        protected void Page_Load(object sender, EventArgs e)
        {
            Config path = new Config();
            DB = Db4oFactory.OpenFile(path.addressOfDiscardedDocument);
            IList<Discarded_Document_model> discarded_Document = DB.Query<Discarded_Document_model>();
            if (discarded_Document.Count > 0)
            {
                foreach (Discarded_Document_model dD1 in discarded_Document)
                {
                    ListBox1.Items.Add(".....................................................................................................................");
                    ListBox1.Items.Add("Document Name and Version:  " + dD1.DocumentTitle + " v" + dD1.DocumentVersion);
                    ListBox1.Items.Add(".....................................................................................................................");
                    ListBox1.Items.Add("");
                    ListBox1.Items.Add("Reason of regecting document: " + dD1.ReasonToDiscard);
                    ListBox1.Items.Add("");
                    ListBox1.Items.Add("Reviewer who discarded the document: " + dD1.NameOfReviever);
                    ListBox1.Items.Add("");
                }
            }
            else
            {
                ListBox1.Items.Add("");
                ListBox1.Items.Add("");
                ListBox1.Items.Add("There is no Item to display");
                ListBox1.Items.Add("");
                ListBox1.Items.Add("");
            }
            ListBox1.Items.Add("--------------------------------------------------------------------END-------------------------------------------------------");
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}