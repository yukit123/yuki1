using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestApplication1.Models
{
    public class Charter
    {
        public int CharterID { get; set; }
        public string CharterDesignatorString { get; set; }

        public int CharterIdentifier { get; set; }
        public string CharterIdentifierString { get; set; }

        public string CharterDestinationLocation1 { get; set; }
        public string CharterDestinationLocation2 { get; set; }


        public string CharterDistanceString { get; set; }

        public string CharterSchoolDepartment { get; set; }
        public string CharterGroup { get; set; }

        public string CharterGroupLevelString { get; set; }

        public string CharterGroupGenderString { get; set; }

        public string CharterResourceTypeString { get; set; }

        [NotMapped]
        public string str { get; set; }




    }
}