using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        //private readonly string _comparisonProperty;

        //public CantbothExistValidator(string comparisonProperty)
        //{
        //    _comparisonProperty = comparisonProperty;
        //}

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

    public class DateLessThanAttribute : ValidationAttribute
    {
        private readonly int _comparisonProperty;

        public DateLessThanAttribute(int comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var currentValue = (int)value;

            //var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            //if (property == null)
                throw new ArgumentException("Property with this name not found");

            //var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);

            //if (currentValue > comparisonValue)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
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
        public virtual List<book2> book2 { get; set; }//virtual为后加不需要迁移，加了之后可以懒加载
        //private string _Compare1;
        //[CantbothExistValidator]
        [DateLessThan(50, ErrorMessage = "Not valid")]
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
