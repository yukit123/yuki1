using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApplication1.Models
{
    public class StudentAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public SelectList Provlist { get; set; }
    }
}