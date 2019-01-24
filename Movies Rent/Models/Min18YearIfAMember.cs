using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Movies_Rent.Models;

namespace Movies_Rent.Models
{
    public class Min18YearIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer =  (customer) validationContext.ObjectInstance;

            if (customer.MemberShipTypeId==1)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("BirthDate is Required");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age > 18) ? ValidationResult.Success : new ValidationResult("Customer shoud be 18 years old");

        }
    }
}