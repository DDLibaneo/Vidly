using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Minimum18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance; //Casting pra Customer, pois é um object

            if (customer.MembershipTypeId == MembershipType.Unknown || //Apenas para que primeiro seja selecionada o MembershipTypeId
                customer.MembershipTypeId == MembershipType.PayAsYouGo) 
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is Required");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Must be at least 18 years old to subscribe");
        }
    }
}