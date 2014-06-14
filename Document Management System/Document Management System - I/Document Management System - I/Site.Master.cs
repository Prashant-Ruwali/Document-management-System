using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Document_Management_System___I
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NavigationMenu.Visible = false; 
            
            string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            if ((sPath.Equals("/edu/IIITB/View/Document.aspx")) || (sPath.Equals("/edu/IIITB/View/Add_user.aspx")) || (sPath.Equals("/edu/IIITB/View/Add_group.aspx")) || (sPath.Equals("/edu/IIITB/View/Document_fragment.aspx")) || (sPath.Equals("/edu/IIITB/View/View_Groups.aspx")) || (sPath.Equals("/edu/IIITB/View/Hello_admin.aspx")) || (sPath.Equals("/edu/IIITB/View/View_rejected.aspx")))
            {
                Menu1.Visible = false;
                NavigationMenu.Visible = true;
            }
            else if ((sPath.Equals("/edu/IIITB/View//Document_fragment_add.aspx")) || (sPath.Equals("/edu/IIITB/View//Document_fragment_Review.aspx")) || (sPath.Equals("/edu/IIITB/View/Search.aspx")) || (sPath.Equals("/edu/IIITB/View/SearchResult.aspx")) || (sPath.Equals("/edu/IIITB/View/showSelectedSearchDocument.aspx")))
            {
                Menu1.Visible = true;
            }
        }
    }
}
