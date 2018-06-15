﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApplication1.Models
{
    public class Group
    {
        [Key]
        public int GrpId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<GroupProperty> GroupProperty { get; set; }
    }
}