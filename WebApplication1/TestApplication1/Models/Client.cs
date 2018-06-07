using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApplication1.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        //[ScaffoldColumn(false)]
        public string Email { get; set; }

    }
}