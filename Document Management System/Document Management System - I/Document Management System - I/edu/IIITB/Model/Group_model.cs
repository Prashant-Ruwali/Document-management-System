using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Document_Management_System___I.edu.IIITB.Model
{
    public class Group_model
    {
        private String groupName;
        private List<User_model> list_userModel;

        public String GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }

        public List<User_model> List_userModel
        {
            get { return list_userModel; }
            set { list_userModel = value; }
        }
    }
}