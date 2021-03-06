﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class expert
    {
        public Guid id { get; set; }
        [Required(ErrorMessage = "Please provide first name")]
        [Display(Name = "First Name")]
        [StringLength(3)]//StringLength 验证用户输入的长度，但与初始显示无关（如果在GET action中预设该字段为“123123”，则不起作用）
        public string first_name { get; set; }
        [Required(ErrorMessage = "Please provide last name")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string last_name { get; set; }

        //[Display(Name = "Preference")]
        //public List<string> preference { get; set; }
        public string ischeck { get; set; }


    }
}