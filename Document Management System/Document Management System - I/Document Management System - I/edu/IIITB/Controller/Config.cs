using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Document_Management_System___I.edu.IIITB.Controller
{
    public class Config
    {
        public string addressOfUser, addressOfDocument, addressofDocumentFragment, addressOfGroup, addressOfDiscardedDocument, outputFilePath;
        public Config()
        {
            addressOfUser = "E:\\Project\\DM\\Document Management System\\Document Management System - I\\Document Management System - I\\edu\\IIITB\\Database\\dmsUserInfo.yap";
            addressOfDocument = "E:\\Project\\DM\\Document Management System\\Document Management System - I\\Document Management System - I\\edu\\IIITB\\Database\\dmsDocumentDetail.yap";
            addressofDocumentFragment = "E:\\Project\\DM\\Document Management System\\Document Management System - I\\Document Management System - I\\edu\\IIITB\\Database\\dmsDocumentFragmentDetail.yap";
            addressOfGroup = "E:\\Project\\DM\\Document Management System\\Document Management System - I\\Document Management System - I\\edu\\IIITB\\Database\\dmsGroupDetail.yap";
            addressOfDiscardedDocument = "E:\\Project\\DM\\Document Management System\\Document Management System - I\\Document Management System - I\\edu\\IIITB\\Database\\discardedDocument.yap";
            outputFilePath = "E:\\Project\\DM\\Document Management System\\Document Management System - I\\Document Management System - I\\edu\\IIITB\\Document\\document.txt";
        }
    }
}