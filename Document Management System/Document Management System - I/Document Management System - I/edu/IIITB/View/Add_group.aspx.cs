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
    public partial class Add_group : System.Web.UI.Page
    {
        IObjectContainer dbget,dbsave;
        Group_model group_model, group_model_proto;
        int flag = 1, flag1 = 1;
        Config path = new Config();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String reviewer = "Reviewer";
                dbget = Db4oFactory.OpenFile(path.addressOfUser);
                IList<User_model> dbqury = dbget.Query<User_model>();

                if (dbqury.Count > 0)
                {
                    foreach (var List_element in dbqury)
                    {
                        if (List_element.UserType.Equals(reviewer))
                            CheckBoxList1.Items.Add(new ListItem(List_element.Name, List_element.Name));
                    }
                }
                dbget.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            group_model_proto = new Group_model()
            {
                GroupName = TextBox1.Text
            };

            dbget = Db4oFactory.OpenFile(path.addressOfGroup);
            IObjectSet result = dbget.QueryByExample(group_model_proto);

            if (result.HasNext())
            {
                flag = 0;
                TextBox1.Text = "";
                CheckBoxList1.SelectedIndex = -1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Groupname already present, Choose new one')", true);
            }
            dbget.Close();
            if (flag == 1)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Groupname available')", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            group_model_proto = new Group_model()
            {
                GroupName = TextBox1.Text
            };

            dbget = Db4oFactory.OpenFile(path.addressOfGroup);
            IObjectSet result = dbget.QueryByExample(group_model_proto);

            if (result.HasNext())
            {
                flag = 0;
                TextBox1.Text = "";
                CheckBoxList1.SelectedIndex = -1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Groupname already present, Choose new one')", true);
            }

            dbget.Close();

            if (flag == 1)
            {
                group_model_proto = new Group_model()
                {
                    List_userModel = new List<User_model>()
                };

                foreach (ListItem item in CheckBoxList1.Items)
                {
                    if (item.Selected)
                    {
                        dbget = Db4oFactory.OpenFile(path.addressOfUser);
                        IList<User_model> dbqury = dbget.Query<User_model>();
                        if (dbqury.Count > 0)
                        {
                            foreach (User_model user_model in dbqury)
                            {
                                if (user_model.Name.Equals(item.Value))
                                {
                                    group_model_proto.List_userModel.Add(user_model);
                                }
                            }
                        }
                        dbget.Close();
                    }
                }
                        
                dbget = Db4oFactory.OpenFile(path.addressOfGroup);
                result = dbget.QueryByExample(group_model_proto);

                if (result.HasNext())
                {
                      flag1 = 0;
                      TextBox1.Text = "";
                      CheckBoxList1.SelectedIndex = -1;
                      ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Reviewer set in this already present in another group, Check in view group')", true);
                 }
                dbget.Close();

                if (flag1 == 1)
                {
                    group_model = new Group_model()
                    {
                        GroupName = TextBox1.Text,
                        List_userModel = new List<User_model>()
                    };

                    foreach (ListItem item in CheckBoxList1.Items)
                    {
                        if (item.Selected)
                        {
                            dbget = Db4oFactory.OpenFile(path.addressOfUser);
                            IList<User_model> dbqury = dbget.Query<User_model>();

                            if (dbqury.Count > 0)
                            {
                                foreach (User_model user_model in dbqury)
                                {
                                    if (user_model.Name.Equals(item.Value))
                                    {
                                        group_model.List_userModel.Add(user_model);
                                    }
                                }
                            }
                            dbget.Close();
                        }
                    }
                }
                dbsave = Db4oFactory.OpenFile(path.addressOfGroup);
                dbsave.Store(group_model);
                TextBox1.Text = "";
                CheckBoxList1.SelectedIndex = -1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Group has been added sucessfully')", true);
                dbsave.Close();
            }
        }
    }
}