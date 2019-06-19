using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestApplication1.Models
{
    public class book2
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        private string _Publisher;
        public string Publisher { get; set; }
        //get
        //    {
        //        return "PSE" + "-" + DateTime.Now.Year.ToString() + "_" + Id.ToString();
                 
        //    }
        //    set
        //    {
        //        this._Publisher = "PSE" + "-" + DateTime.Now.Year.ToString() + "_" + Id.ToString();
        //    }
        //}
        public Guid Author_id { get; set; }
        [ForeignKey("Author_id")]
        public virtual author2 author2 { get; set; }
    }
}