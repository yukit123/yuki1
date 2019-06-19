using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Blog
    {
 
        public int BlogId { get; set; }
        public string Name { get; set; }
        //[NotMapped]
        public string strBlogId { get; set; }
        //[NotMapped]
        //public bool BlogId2 { get; set; }
        [NotMapped]
        [DisplayName("Document Date")]
        [Required(ErrorMessage = "Required field.")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime DateDocument { get; set; }

        [NotMapped]

        public DateTime Created { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Enter the issued date.")]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }


    }
}