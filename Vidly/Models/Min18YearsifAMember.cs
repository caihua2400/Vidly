using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsifAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId==0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            if (customer.Birthdate == null) return new ValidationResult("Birthdate is required");
            var age = DateTime.Today.Year - customer.Birthdate.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("age should be greater than 18");
        }
    }
}