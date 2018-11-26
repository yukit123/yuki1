using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestApplication1.Models
{
    public class Student121
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public virtual StudentAddress121 Address { get; set; }
    }

    public class StudentAddress121
    {
        [Key,ForeignKey("Student")]
        public int StudentAddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }

        public virtual Student121 Student { get; set; }
    }
}