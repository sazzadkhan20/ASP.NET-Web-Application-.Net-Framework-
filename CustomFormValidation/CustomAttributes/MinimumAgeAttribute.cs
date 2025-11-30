using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace CustomFormValidation.CustomAttributes
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;
        public MinimumAgeAttribute() 
        {
            _minimumAge = 18;
        }

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;
            DateTime date = DateTime.Parse(value.ToString());
            // Console.Write(date);
            int age = DateTime.Now.Year - date.Year;
            return age > _minimumAge;
        }
    }
}