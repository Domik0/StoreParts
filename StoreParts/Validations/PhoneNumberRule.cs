using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StoreParts.Validations
{
    class PhoneNumberRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string phone = (string)value;
            if (!Regex.IsMatch(phone, @"^((\+7)+([0-9]){10})$"))
            //if (!Regex.IsMatch(phone, @"^([a-z][a-z0-9]{4,19})((@gmail\.com)|(@mail\.ru)|(@bk\.ru)|(@yandex\.ru)|(@outlook\.com))$"))
            //if (!Regex.IsMatch(phone, @"^(([А-Я][а-я]{1,}\s?){2}([А-Я][а-я]{1,}))$"))
            {
                return new ValidationResult(false,
                    "Некорректный номер");
            }
            return new ValidationResult(true, null);
        }
    }
}
