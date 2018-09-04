using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestApplication1.Models
{
    public class Tool
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //自增
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}