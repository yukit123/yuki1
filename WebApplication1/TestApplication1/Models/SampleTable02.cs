using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApplication1.Models
{
    public class SampleTable02
    {
        [Key]
        public int SampleId { get; set; }
        public string SampleName { get; set; }
        public string SampleCategory { get; set; }
        public DateTime SampleDateTime { get; set; }
        public bool IsSampleProcessed { get; set; }

    }
}