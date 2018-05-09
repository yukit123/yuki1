using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int product_id { get; set; } // unique integer product identifier
        public string model_code { get; set; } // product unique identifier
        public string full_product_name { get; set; } // product full name
    }

    public class Product2
    {
        public int product_id { get; set; } // unique integer product identifier
        public string model_code { get; set; } // product unique identifier
        public string full_product_name { get; set; } // product full name

        public int[] related_products { get; set; } //array of related products to this product
        public int[] related_accessories { get; set; } //array of related accessories products to this product
    }
}