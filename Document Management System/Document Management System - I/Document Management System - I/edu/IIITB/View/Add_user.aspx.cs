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
    public partial class Add_user : System.Web.UI.Page
    {
        IObjectContainer db, dbget;
        int flag = 1;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Config path = new Config();

            User_model user_model = new User_model()
            {
                UserName = Textfullname.Text,
                Password = Textpassword.Text,
                Name = Textusername.Text,
                EmailId = Textemail.Text,
                UserType = DropDownList_usertype.SelectedValue
            };

            User_model user_model_proto = new User_model()
            {
                Name = Textusername.Text
            };

            dbget = Db4oFactory.OpenFile(path.addressOfUser);
            IObjectSet result = dbget.QueryByExample(user_model_proto);

            if (result.HasNext())
            {
                flag = 0;
                Textusername.Text = "";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username already present, Choose new one')", true);
            }
            
            dbget.Close();

            if (flag == 1)
            {
                db = Db4oFactory.OpenFile(path.addressOfUser);
                db.Store(user_model);
                db.Close();
           

                Textfullname.Text = "";
                Textpassword.Text = "";
                Textusername.Text = "";
                Textemail.Text = "";
                DropDownList_usertype.SelectedValue = "";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User has been added sucessfully')", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Config path = new Config();

            User_model user_model_proto = new User_model()
            {
                Name = Textusername.Text
            };

            dbget = Db4oFactory.OpenFile(path.addressOfUser);
            IObjectSet result = dbget.QueryByExample(user_model_proto);

            if (result.HasNext())
            {
                Textusername.Text = "";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username already present, Choose new one')", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username available')", true);

            dbget.Close();
        }
    }
}