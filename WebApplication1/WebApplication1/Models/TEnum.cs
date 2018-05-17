using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
       
    }
    public enum EnumType : int
    {
        Yes = 0,
        No = 1
    }
}