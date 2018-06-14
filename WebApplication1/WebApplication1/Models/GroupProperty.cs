using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class GroupProperty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int GrpId { get; set; }
        public Group Group { get; set; }
    }
}