using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApplication1.Models
{
    public class RMA_History
    {
        public int Id { get; set; }
        [Required]
        public string Kundenummer { get; set; }
        public string Ordrenummer { get; set; }

        public string NewColum2 { get; set; }//new add

    }
}