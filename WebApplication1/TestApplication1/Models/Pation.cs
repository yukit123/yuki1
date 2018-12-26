using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestApplication1.Models
{
    public class Pation
    {
        [Key]
        public int Id { get; set; }
        public string PationName { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        // public DateTime DateWared { get; set; } = DateTime.UtcNow.AddHours(3);
        public int Type_ServiceId { get; set; }
        [ForeignKey("Type_ServiceId")]
        public virtual Type_Service Type_Services { get; set; }
        //public ApplicationUser User { get; set; }

    }
}