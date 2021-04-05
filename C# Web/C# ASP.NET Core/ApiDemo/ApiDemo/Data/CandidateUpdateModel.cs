using System;
using System.ComponentModel.DataAnnotations;

namespace ApiDemo.Data
{
    public class CandidateUpdateModel
    {
        [Required]
        public string Names { get; set; }

        [Display(Name = "Years of Experience")]
        [Range(1, int.MaxValue)]
        public int YearsOfExperience { get; set; }
    }
}
