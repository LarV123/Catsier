using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace Catsier.Validators {
	class JumlahValidationRule : ValidationRule {
		public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
			try {
				if (int.Parse((string)value) > 0) {
					return ValidationResult.ValidResult;
				}
			}catch(Exception e) {
				return new ValidationResult(false, "Invalid");
			}
			return new ValidationResult(false, "Invalid");
		}
	}
}
