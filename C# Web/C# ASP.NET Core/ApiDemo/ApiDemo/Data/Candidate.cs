using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ApiDemo.Data
{
    public class Candidate : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        public string Names { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [EgnValidation]
        public string Egn { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Years of Experience")]
        [Range(1, int.MaxValue)]
        public int YearsOfExperience { get; set; }

        public CandidateType CandidateType { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (int.Parse(this.Egn.Substring(0, 2))
                != this.DateOfBirth.Year % 100)
            {
                yield return new ValidationResult("Egn and year of birth are not a valid combination!");
            }
        }
    }

    public class EgnValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var valueAsString = value.ToString();

            if (!Regex.IsMatch(valueAsString, "[0-9]{10}"))
            {
                return new ValidationResult("Egn must be 10 characters long!");
            }

            var weight = new[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            int checkSum = 0;
            for (int i = 0; i < 9; i++)
            {
                checkSum += (valueAsString[i] - '0') * weight[i];
            }

            var lastDigit = checkSum % 11;
            if (lastDigit == 10)
            {
                lastDigit = 0;
            }

            if (valueAsString[9] - '0' != lastDigit)
            {
                return new ValidationResult("Egn is not valid!");
            }

            return ValidationResult.Success;
        }
    }
}
