using System.ComponentModel.DataAnnotations;
using CosmeticDashboard.Models;

namespace CosmeticDashboard.Utilities
{
    public class ValidRegisterDomainAttribute : ValidationAttribute
    {
        //public override bool IsValid(object value, ValidationContext validationContext)
        //{
        //    var user = (User)validationContext.ObjectInstance;

        //    if(user.UserName == null)
        //    {
        //        return new ValidationResult("")
        //    }

        //}
    }
}
