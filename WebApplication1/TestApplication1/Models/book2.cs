using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestApplication1.Models
{
    public partial class book2
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public Guid Author_id { get; set; }
        [ForeignKey("Author_id")]
        public virtual author2 author2 { get; set; }
    }
}