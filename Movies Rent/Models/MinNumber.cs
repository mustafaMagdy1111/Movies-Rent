using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Movies_Rent.Models;


namespace Movies_Rent.Models
{
    public class MinNumber:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Movie = (Movie)validationContext.ObjectInstance;

            if (Movie.NumberInStocks >20)
                return new ValidationResult("Range between 0 and 20");

            return ValidationResult.Success ;
        }
    }
}