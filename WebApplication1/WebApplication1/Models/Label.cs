using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class Label
    {
        //[Range(10, 100, ErrorMessage = "年龄不能大于{2} 不能小于{1}")]
        //[Range(10, 100, ErrorMessage = "The field is required and cannot be empty")]
        public int LabelId { get; set; }
        public string LabelName { get; set; }
        //public List<Label> labinfo { get; set; }
        public string url { get; set; }

        [NotMapped]
        //[Required]
        public List<int> ProdottiIds { get; set; }
        [NotMapped]
        public IList<SelectListItem> ListaProdotti { get; set; }
        [NotMapped]
        public List<Label2> ogrenciler { get; set; }
    }

    public class Label2
    {
        public int LabelId { get; set; }
        public string LabelName { get; set; }
        public List<Label> labinfo { get; set; }
 
    }

    //public enum Gender
    //{
    //    Male,
    //    Female
    //}
}