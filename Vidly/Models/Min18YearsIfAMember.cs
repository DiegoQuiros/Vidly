using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return (new ValidationResult("Birthdate is required."));

            if (DateTime.Today.Year - customer.BirthDate.Value.Year < 18)
                return (new ValidationResult("Must be 18 years of age to become a member."));

            return ValidationResult.Success;
        }
    }
}