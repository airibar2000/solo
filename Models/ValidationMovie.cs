using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace solo.Models
    {
    public class ValidationMovie : ValidationAttribute
        {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
            var movie = (Movie)validationContext.ObjectInstance;
            var release = DateTime.Now.Year - movie.ReleaseDate.Year;
            if (release > 0)
                {
                return ValidationResult.Success;
                }
            else
                return new ValidationResult("Releade date should be early than this year");

            
            }
        }
    }