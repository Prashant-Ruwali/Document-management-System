using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Document_Management_System___I.edu.IIITB.Model
{
    public class Discarded_Document_model
    {
        private String documentTitle;                            // Name/ Title of the document being entered to the system
        private float documentVersion;                           // Version of the document being saved in the system
        private String reasonToDiscard;
        private String nameOfReviever;
        public Discarded_Document_model()
        {
        }

        public String DocumentTitle
        {
            get { return documentTitle; }
            set { documentTitle = value; }
        }

        public String NameOfReviever
        {
            get { return nameOfReviever; }
            set { nameOfReviever = value; }
        }

        public float DocumentVersion
        {
            get { return documentVersion; }
            set { documentVersion = value; }
        }

        public string ReasonToDiscard
        {
            get { return reasonToDiscard; }
            set { reasonToDiscard = value; }
        }
    }
}