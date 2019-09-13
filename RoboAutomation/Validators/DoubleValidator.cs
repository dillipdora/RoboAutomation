using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RoboAutomation
{
    public class DoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool IsDouble = Double.TryParse(value.ToString(), out double val);

            if (!IsDouble)
                return new ValidationResult(false, $"Unable to convert {value.ToString()} to a double type");
            else
                return new ValidationResult(true, null);
        }
    }
}
