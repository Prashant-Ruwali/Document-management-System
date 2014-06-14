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
    public partial class Login : System.Web.UI.Page
    {
        IObjectContainer db;
        string username;
        string password;
        string role;
        string email;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name_Input, password_Input, admin, user, reviewer;

            name_Input = Textuser.Text;
            password_Input = Textpass.Text;
            admin = "Admin";
            user = "User";
            reviewer = "Reviewer";

           Config path = new Config();
            db = Db4oFactory.OpenFile(path.addressOfUser);
            IList<User_model> dbqury = db.Query<User_model>();
            //Response.Write(dbqury.Count);
            if (dbqury.Count > 0)
            {
                 foreach (User_model user_model in dbqury)
                {
                     username = user_model.Name;
                     password = user_model.Password;
                     role = user_model.UserType;
                     email = user_model.EmailId;

                     if ((username.Equals(name_Input) || email.Equals(name_Input)) && password.Equals(password_Input) && role.Equals(admin))
                    {
                        Textuser.Text = "";
                        Textpass.Text = "";
                        db.Close();
                        Response.Redirect("./Hello_admin.aspx");
                    }

                     if ((username.Equals(name_Input) || email.Equals(name_Input)) && password.Equals(password_Input) && role.Equals(user))
                    {
                        Textuser.Text = "";
                        Textpass.Text = "";
                        db.Close();
                        Response.Redirect("./Search.aspx");
                    }

                     if ((username.Equals(name_Input) || email.Equals(name_Input)) && password.Equals(password_Input) && role.Equals(reviewer))
                     {
                         Session["UserName"] = username;
                         Textuser.Text = "";
                         Textpass.Text = "";
                         db.Close();
                         Response.Redirect("./Document_page.aspx");
                     }
                }
                 db.Close();
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
        }

    }
}