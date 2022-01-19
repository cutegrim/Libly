using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Libly.Models
{
    public class MinMemberAge:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            

            if (customer.MembershipId == Membership.Unknown || customer.MembershipId == Membership.PayAsYouGo)return ValidationResult.Success;

            if(customer.Birthday == null)
            {
                return new ValidationResult("The Date of Birth is required.");
            }
            var age = DateTime.Today.Year - customer.Birthday.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success : new ValidationResult("Customer have to be atleast 18 years old to go on membership");

        }
    }
}