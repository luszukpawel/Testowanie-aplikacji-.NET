using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace GamesStudios
{
    [AttributeUsage(AttributeTargets.Property |
    AttributeTargets.Field, AllowMultiple = false)]
    sealed public class DataValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var date = (DateTime)value;
            bool result = true;
            if (date.Year <= 1800)
            {
                result = false;
            }
            return result;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }
    }
}