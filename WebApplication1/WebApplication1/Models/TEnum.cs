using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TEnum
    {
        [Key]
        public int EnumId { get; set; }
        public EnumType EnumType { get; set; }
        public string EnumName { get; set; }

        [NotMapped]
        //[DataType(DataType.Date)]
        public DateTime Dateofbirth { get; set; }


    }
    public enum EnumType : int
    {
        [Display(Name = "Archive Description")]
        Male = 0,
        Female = 1
    }
}