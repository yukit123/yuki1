using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Label
    {
        [Range(10, 100, ErrorMessage = "年龄不能大于{2} 不能小于{1}")]
        public int LabelId { get; set; }
        public string LabelName { get; set; }
        //public List<Label> labinfo { get; set; }
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