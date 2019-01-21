﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationVidly.Models
{
    public class Min18YearsForMembership:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId== MembershipType.unknown || customer.MembershipTypeId == MembershipType.payAsUGo)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required.");

            }
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return age >= 18 ?
                ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to get a membership");

        }
    }
}