using System;
using System.ComponentModel.DataAnnotations;

namespace TeamRankings.ViewModel
{
    public class MustBeInThePastAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dateTime = (DateTime)value;
            return dateTime >= DateTime.UtcNow ? new ValidationResult("Date and time must be in the past") : ValidationResult.Success;
        }
    }
}