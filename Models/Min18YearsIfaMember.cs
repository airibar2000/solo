using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using solo.Models;
namespace solo.Models
    {
    public class Min18YearsIfaMember : ValidationAttribute 
        {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == Models.MembershipType.PayAsYouGo && customer.Birthdate != null)
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("BirthDate is Required");
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18) ?
                ValidationResult.Success :
                new ValidationResult("Customer Should be at least 18 years old");

           }
        }
    }