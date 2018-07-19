using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestApplication1.Models
{
    public class CantbothExistValidatorAttribute : ValidationAttribute
    {

        //private readonly int _maxWords;
        //public CantbothExistValidatorAttribute(string maxWords) : base("{0}字符太多")
        //{
        //    _maxWords = maxWords;
        //}
        //public string Compare1 { get; set; }
        // public int MaxStringLength { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (Models.author2)validationContext.ObjectInstance;
            // DateTime EndDate = Convert.ToDateTime(model.Compare2);
            DateTime StartDate = Convert.ToDateTime(value);

            if (model.Compare2 != null)
            {
                return new ValidationResult
                    ("You can only enter either Production Number or Production Name, you can not enter both");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }

    public class author2
    {
        public author2()
        {
            book2 = new List<book2>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //自增
        public Guid Author_id { get; set; }
        public string Name { get; set; }
        public List<book2> book2 { get; set; }


        //private string _Compare1;
        [CantbothExistValidator]
        public string Compare1 { get; set; }
        //{
        // get { return _Compare1; }
        // set 
        // {
        //     Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Compare1" });
        //     if (string.IsNullOrEmpty(value))
        //     {
        //         throw new Exception("用户名不能为空.");
        //     }
        //        _Compare1 = value; 
        // }
        [CantbothExistValidator]
        public string Compare2 { get; set; }
    }




}
