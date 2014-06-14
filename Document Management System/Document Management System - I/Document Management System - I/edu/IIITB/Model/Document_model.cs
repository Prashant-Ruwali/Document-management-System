using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Document_Management_System___I.edu.IIITB.Model
{
    public class Document_model
    {
        private String documentTitle;                            // Name/ Title of the document being entered to the system
        private float documentVersion;                           // Version of the document being saved in the system
        private DateTime documentCreateDate;                     // Create date of that Version of the Document
        private String documentType;                             // Type of the document like MOM, article, research paper, design document etc
        private String documentWorkflow;                    // It will keep the workflow of the document
        private List<String> list_documentAuthor;                // List of all the Authors/ Co-Authorsrelated to the document
        private List<String> list_documentKeywords;              // List of all the Keywords related to the document
        private List<Document_fragment_model> list_documentFragment;    // List of all the document fragment related to the document
        private String documentPublisher;                        // Name of the publisher of the document       
        private String documentStatus;
                                       // Status of the Document 'Reviewed', 'Pending' or 'In Process'
        // enum documentStatus { Reviewed, Pending, InProcess};  // Status of the Document 'Reviewed', 'Pending' or 'In Process'
        private String choice_of_level;
        private int count_document_reviever;
        private List<String> list_reviever;
        public Document_model(String DocumentTitle)
        {
            this.documentTitle = DocumentTitle;
        }
        public Document_model(String DocumentTitle,float documentVersion)
        {
            this.documentTitle = DocumentTitle;
            this.documentVersion=documentVersion;
        }

        public void ChangeStatus(String Status) 
        {
            this.DocumentStatus = Status;
        }

        public Document_model()
        {
        }

        public String DocumentTitle
        {
            get { return documentTitle; }
            set { documentTitle = value; }
        }

        public String Choice_of_level
        {
            get { return choice_of_level; }
            set { choice_of_level = value; }
        }       

        public float DocumentVersion
        {
            get { return documentVersion; }
            set { documentVersion = value; }
        }        
        public DateTime DocumentCreateDate
        {
            get { return documentCreateDate; }
            set { documentCreateDate = value; }
        }        
        public String DocumentType
        {
            get { return documentType; }
            set { documentType = value; }
        }
        public String DocumentWorkflow
        {
            get { return documentWorkflow; }
            set { documentWorkflow = value; }
        }

        public List<String> List_documentAuthor
        {
            get { return list_documentAuthor; }
            set { list_documentAuthor = value; }
        }        
        public List<String> List_documentKeywords
        {
            get { return list_documentKeywords; }
            set { list_documentKeywords = value; }
        }
        public List<Document_fragment_model> List_documentFragment
        {
            get { return list_documentFragment; }
            set { list_documentFragment = value; }
        }
        public String DocumentPublisher
        {
            get { return documentPublisher; }
            set { documentPublisher = value; }
        }

        public String DocumentStatus
        {
            get { return documentStatus; }
            set { documentStatus = value; }
        }
        public int Count_document_reviever
        {
            get { return count_document_reviever; }
            set { count_document_reviever = value; }
        }
        public List<String> List_reviever
        {
            get { return list_reviever; }
            set { list_reviever = value; }
        }

       
    }
}