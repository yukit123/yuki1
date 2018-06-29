using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApplication1.Models
{
    public class CountrySize
    {
        public int Id { get; set; }
        //[Required]
        public string country { get; set; }
        //[Required]
        public string size { get; set; }
        public int value { get; set; }
    }
}