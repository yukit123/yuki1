using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestApplication1.Models
{
    public class author2
    {
        public author2()
        {
            book2 = new List<book2>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //自增
        public Guid Author_id { get; set; }
        public string Name { get; set; }
        public List<book2> book2 { get; set; }
    }
}