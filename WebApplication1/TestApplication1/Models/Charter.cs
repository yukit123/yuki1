using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        //[DataType(DataType.DateTime)]
        ////[Column(TypeName = "DateTime2")]  DateTime2:http://www.entityframeworktutorial.net/code-first/column-dataannotations-attribute-in-code-first.aspx
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? CharterDate { get; set; }

        [NotMapped]
        public string FormattedDate => CharterDate.ToString(); // linq/lambda in model

        //[NotMapped]
        //public int? ContactReportAMSeconds // { get; set; }
        //{
        //    get
        //    {
        //        if (CharterDate == null)
        //            return 0;
        //        {
        //            var temp = (DateTime)CharterDate;
        //            var temp2 = new DateTime(temp.Year, temp.Month, temp.Day);
        //            TimeSpan ts1 = new TimeSpan(temp.Ticks);
        //            TimeSpan ts2 = new TimeSpan(temp2.Ticks);
        //            TimeSpan ts = new TimeSpan();
        //            ts = temp2.Subtract(temp);
        //            return Convert.ToInt32(ts);
        //        }
        //    }
        //}

        [NotMapped]
        public string str { get; set; }

        [NotMapped]
        [RegularExpression("^[ -~]+$", ErrorMessage = @"Allowed characters for item description: space, numbers, English letters and following special characters: ! "" # $ % & ' ( ) * + , - . / : ; < = > ? @ ` [ \ ~ ] ^ _ {{ | }}")]
        public string str2 { get; set; }

 




    }
}