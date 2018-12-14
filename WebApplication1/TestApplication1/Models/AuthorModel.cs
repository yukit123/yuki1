using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestApplication1.Models
{
    public class AuthorModel
    {
        public AuthorModel()
        {
            Books = new List<Book>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }

    public class Book
    {
       [Key]
        public int id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        [NotMapped]
        public string Radiobutton { get; set; }

    }
}