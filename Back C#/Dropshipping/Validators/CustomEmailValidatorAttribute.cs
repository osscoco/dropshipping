﻿using System.ComponentModel.DataAnnotations;

namespace API.Validators
{
    public class CustomEmailValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string? email = value.ToString();

                var emailAddressAttribute = new EmailAddressAttribute();

                if (!emailAddressAttribute.IsValid(email))
                {
                    return new ValidationResult("L\'email n\'est pas valide");
                }
            }

            return ValidationResult.Success!;
        }
    }
}
