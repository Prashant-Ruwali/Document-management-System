using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Document_Management_System___I.edu.IIITB.Model
{
    public class User_model
    {
        private String userName;        // UserName/ UserId of the user
        private String password;        // Password corresponding to the UserName of the user
        private String name;            // Full name of the User
        private String emailId;         // EmailId of the User
        private String userType;        // Type to which user belongs like Admin, Reviewer, User          
       
       // enum userType  { Admin = "Admin", Reviewer = "Reviewer", User = "User"};        // Type to which user belongs like Admin, Reviewer, User          

        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String EmailId
        {
            get { return emailId; }
            set { emailId = value; }
        }
        public String UserType
        {
            get { return userType; }
            set { userType = value; }
        }
    }
}