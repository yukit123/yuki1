using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApplication1.Models
{
    public class Type_Service
    {
        [Key]
        public int Type_ServiceId { get; set; }
        public string NameService { get; set; }
        public virtual ICollection<Pation> Pations { get; set; }
    }
}