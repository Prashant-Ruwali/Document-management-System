using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Document_Management_System___I.edu.IIITB.Model
{
    public class Document_fragment_model
    {
        private String documentFragmentTitle;                // Name/ Title of the Document Fragment        
        private float documentFragmentVersion;               // Version of the Document Fragment
        private DateTime documentFragmentCreateDate;         // Create date of the version of the document fragment    
   
       /* Make Keyword String insted of List If you thing There should be only one Keyword assosiated with one doc Fragment */
        private List<String> keywords;                       // List of the Keywords related to the document
        private String documentFragmentContent;              // Content of the Document Fragment
        private List<String> list_documentFragmentAuthor;    // List of Authors in a fragment

        public String DocumentFragmentTitle
        {
            get { return documentFragmentTitle; }
            set { documentFragmentTitle = value; }
        }
        public float DocumentFragmentVersion
        {
            get { return documentFragmentVersion; }
            set { documentFragmentVersion = value; }
        }  
        public List<String> Keywords
        {
            get { return keywords; }
            set { keywords = value; }
        }
        public DateTime DocumentFragmentCreateDate
        {
            get { return documentFragmentCreateDate; }
            set { documentFragmentCreateDate = value; }
        }
        public String DocumentFragmentContent
        {
            get { return documentFragmentContent; }
            set { documentFragmentContent = value; }
        }
        public List<String> List_documentFragmentAuthor
        {
            get { return list_documentFragmentAuthor; }
            set { list_documentFragmentAuthor = value; }
        } 
    }
}